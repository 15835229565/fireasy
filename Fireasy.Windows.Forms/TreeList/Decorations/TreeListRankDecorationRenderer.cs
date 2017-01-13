﻿using System;

namespace Fireasy.Windows.Forms
{
    /// <summary>
    /// 使 <see cref="TreeListCell"/> 呈现为星形评分样式。
    /// </summary>
    public class TreeListRankDecorationRenderer : TreeListDefaultDecorationRenderer
    {
        /// <summary>
        /// 绘制指定的 <see cref="TreeListCell"/> 对象。
        /// </summary>
        /// <param name="e"></param>
        public override void DrawCell(TreeListCellRenderEventArgs e)
        {
            if (e.Cell.Value == null)
            {
                return;
            }

            var iw = Properties.Resources.start2.Width;
            var ih = Properties.Resources.start2.Height;
            var l = e.Bounds.X + 2;
            var t = e.Bounds.Y + (e.Bounds.Height - ih) / 2;
            var r = Convert.ToDecimal(e.Cell.Value);

            for (var i = 0; i < r; i++)
            {
                e.Graphics.DrawImage(Properties.Resources.start2, l, t);
                l += iw + 4;
            }
        }
    }
}
