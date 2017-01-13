﻿// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;

namespace Fireasy.Common.Ioc.Configuration
{
    /// <summary>
    /// 表示服务与组件的注册键对。
    /// </summary>
    public class RegistrationSetting
    {
        /// <summary>
        /// 获取或设置服务的类型。
        /// </summary>
        public Type ServiceType { get; set; }

        /// <summary>
        /// 获取或设置组件的类型。
        /// </summary>
        public Type ComponentType { get; set; }

    }
}
