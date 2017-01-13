﻿// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using Fireasy.Common;
using Fireasy.Common.Extensions;
using Fireasy.Data.Provider;

namespace Fireasy.Data
{
    /// <summary>
    /// 扩展的数据库连接字符串。无法继承此类。
    /// </summary>
    /// <remarks>连接字符串中可使用特殊的名称来标记数据库文件的有效地址，这些标识包含|datadirectory|或来自 <see cref="Environment.SpecialFolder"/> 枚举项，如|System|、|ApplicationData|，同时，也可以使用../路径命令符。</remarks>
    public sealed class ConnectionString
    {
        private string connectionString;

        /// <summary>
        /// 将连接字符串转换为 <see cref="ConnectionString"/> 对象。
        /// </summary>
        /// <param name="connectionString">表示连接数据库的字符串。</param>
        /// <returns></returns>
        public static implicit operator ConnectionString(string connectionString)
        {
            return new ConnectionString(connectionString);
        }

        /// <summary>
        /// 将 <see cref="ConnectionString"/> 转换为字符串。
        /// </summary>
        /// <param name="connectionString">扩展数据库连接字符串对象。</param>
        /// <returns></returns>
        public static explicit operator string(ConnectionString connectionString)
        {
            return connectionString != null ? connectionString.ToString() : string.Empty;
        }

        /// <summary>
        /// 使用连接字符串初始化 <see cref="ConnectionString"/> 类的新实例。
        /// </summary>
        /// <param name="connectionString">数据库连接字符串。</param>
        /// <exception cref="ArgumentNullException">connectionString 为 null。</exception>
        public ConnectionString(string connectionString)
        {
            Guard.ArgumentNull(connectionString, "connectionString");
            Properties = new ConnectionProperties();
            this.connectionString = ParseConnectionString(connectionString);
        }

        /// <summary>
        /// 获取数据库提供者类型名称，该名称可以是 <see cref="ProviderType"/> 枚举或实现 <see cref="IProvider"/> 接口的类的名称。
        /// </summary>
        public string ProviderType { get; private set; }

        /// <summary>
        /// 获取数据库类型名称，该类型实现 <see cref="IDatabase"/> 接口。
        /// </summary>
        public string DatabaseType { get; private set; }

        /// <summary>
        /// 获取提供命令执行的调试跟踪支持。
        /// </summary>
        public bool IsTracking { get; private set; }

        /// <summary>
        /// 获取连接字符串的属性字典。
        /// </summary>
        public ConnectionProperties Properties { get; private set; }

        /// <summary>
        /// 输出处理过的可用于数据库连接的字符串。
        /// </summary>
        /// <returns>数据库连接字符串。</returns>
        public override string ToString()
        {
            return connectionString;
        }

        /// <summary>
        /// 更新连接字符串。
        /// </summary>
        /// <returns></returns>
        internal string Update()
        {
            var builder = new StringBuilder();

            foreach (var key in Properties.Keys)
            {
                var value = Properties[key];
                builder.AppendFormat("{0}={1};", key, value);
            }

            return builder.ToString();
        }

        /// <summary>
        /// 解析数据库连接字符串，去除字符串内的 version、|datadirectory| 等参数。
        /// </summary>
        /// <param name="constr">配置的源连接字符串。</param>
        /// <returns>可用于进行数据库连接的字符串。</returns>
        private string ParseConnectionString(string constr)
        {
            var builder = new StringBuilder();

            //循环每节属性
            var args = constr.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string par in args)
            {
                var segs = par.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (segs.Length == 0)
                {
                    continue;
                }

                var name = segs[0].Trim();
                var value = segs[1].Trim();
                if (!ParseParameter(name, value))
                {
                    DbUtility.ParseDataDirectory(ref value);
                    builder.AppendFormat("{0}={1};", name, value);
                }

                Properties.Add(name.ToLower(), value);
            }

            return builder.ToString();
        }

        /// <summary>
        /// 解析参数。
        /// </summary>
        /// <param name="name">参数的名称。</param>
        /// <param name="value">值。</param>
        /// <returns>如果解析出特有的参数，则为 true。</returns>
        private bool ParseParameter(string name, string value)
        {
            if (name.Equals("version", StringComparison.OrdinalIgnoreCase))
            {
                //    Version = Convert.ToDecimal(value);
            }
            else if (name.Equals("provider type", StringComparison.OrdinalIgnoreCase))
            {
                ProviderType = value;
            }
            else if (name.Equals("database type", StringComparison.OrdinalIgnoreCase))
            {
                DatabaseType = value;
            }
            else if (name.Equals("tracking", StringComparison.OrdinalIgnoreCase))
            {
                IsTracking = value.To<bool>();
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}