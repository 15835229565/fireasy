﻿// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Web;
using Fireasy.Web.UI;

namespace Fireasy.EasyUI.Mvc
{
    public static class LinkButtonExtensions
    {
        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 linkbutton 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id">ID 属性值。</param>
        /// <param name="onClick">单击时执行的 js 脚本。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper LinkButton(this System.Web.Mvc.HtmlHelper htmlHelper, string id, string onClick, LinkButtonSettings settings = null)
        {
            return new HtmlHelper().LinkButton(id, onClick, settings);
        }
    }
}
