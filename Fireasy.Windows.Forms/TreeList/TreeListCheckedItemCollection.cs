﻿using System.Collections.ObjectModel;

namespace Fireasy.Windows.Forms
{
    public class TreeListCheckedItemCollection : ObservableCollection<TreeListItem>
    {
        private bool isForbid;
        private TreeList treelist;

        /// <summary>
        /// 初始化 <see cref="TreeListCheckedItemCollection"/> 类的新实例。
        /// </summary>
        /// <param name="treelist"></param>
        internal TreeListCheckedItemCollection(TreeList treelist)
        {
            this.treelist = treelist;
        }

        protected override void InsertItem(int index, TreeListItem item)
        {
            if (isForbid)
            {
                base.InsertItem(index, item);
                return;
            }

            treelist.CheckItem(item, true);
        }

        protected override void RemoveItem(int index)
        {
            if (isForbid)
            {
                base.RemoveItem(index);
                return;
            }

            treelist.CheckItem(this[index], false);
        }

        /// <summary>
        /// 从集合中清除所有项。
        /// </summary>
        protected override void ClearItems()
        {
            if (!isForbid)
            {
                foreach (var item in Items)
                {
                    item.SetChecked(false);
                }

                if (treelist != null)
                {
                    treelist.UpdateItems();
                }
            }

            base.ClearItems();
        }

        /// <summary>
        /// 内部清理，防止递归调用。
        /// </summary>
        internal void InternalClear()
        {
            isForbid = true;
            Clear();
            isForbid = false;
        }

        internal void InternalAdd(TreeListItem item)
        {
            isForbid = true;
            Add(item);
            isForbid = false;
        }

        internal void InternalRemove(TreeListItem item)
        {
            isForbid = true;
            Remove(item);
            isForbid = false;
        }
    }
}
