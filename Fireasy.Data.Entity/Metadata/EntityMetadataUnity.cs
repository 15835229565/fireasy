﻿using Fireasy.Common;
using Fireasy.Common.Extensions;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Fireasy.Data.Entity.Metadata
{
    /// <summary>
    /// 实体元数据的管理单元。
    /// </summary>
    public static class EntityMetadataUnity
    {
        private static ConcurrentDictionary<Type, EntityMetadata> cache = new ConcurrentDictionary<Type,EntityMetadata>();

        /// <summary>
        /// 获取指定类型的实体元数据。
        /// </summary>
        /// <param name="entityType">实体类型。</param>
        /// <returns></returns>
        public static EntityMetadata GetEntityMetadata(Type entityType)
        {
            Guard.ArgumentNull(entityType, "entityType");
            var cacheKey = entityType.FullName;

            var lazy = new Lazy<EntityMetadata>(() =>
                {
                    var metadata = new EntityMetadata(entityType);
                    Debug.WriteLine("Entity metadata of '" + entityType + "' registered.");

                    //由于此代码段是缓存项创建工厂函数，此时的 metadata 并未添加到缓存中，接下来 PropertyUnity 
                    //会再一次获取 EntityMetadata，因此需要在此线程中共享出 EntityMetadata
                    using (var scope = new Scope { Metadata = metadata })
                    {
                        if (typeof(IEntityPropertyInitialize).IsAssignableFrom(entityType))
                        {
                            entityType.New<IEntityPropertyInitialize>().Initialize();
                        }
                        else
                        {
                            //需要找出其中的一个字段，然后以引发 RegisterProperty 调用
                            var field = entityType.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public).FirstOrDefault();
                            if (field != null)
                            {
                                field.GetValue(null);
                            }
                        }
                    }

                    return metadata;
                });

            return cache.GetOrAdd(entityType, k => lazy.Value);
        }

        /// <summary>
        /// 获取指定类型的实体元数据的内部方法。
        /// </summary>
        /// <param name="entityType">实体类型。</param>
        /// <returns></returns>
        internal static EntityMetadata InternalGetEntityMetadata(Type entityType)
        {
            return EntityMetadataUnity.Scope.Current != null ?
                EntityMetadataUnity.Scope.Current.Metadata :
                GetEntityMetadata(entityType);
        }

        private class Scope : Scope<Scope>
        {
            internal EntityMetadata Metadata { get; set; }
        }
    }
}