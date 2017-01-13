// ------------------------------
// ��ģ����CodeBuilder��������,���������� Fireasy.Data.Entity 1.5 ���ݿ��
// ��Ȩ���� (C) Fireasy 2011

// ��Ŀ����: ʵ���ܲ�����Ŀ
// ģ������: ����� ʵ����
// �����д: Huangxd
// �ļ�·��: C:\Users\Ruibron\Desktop\Model\Categories.cs
// ����ʱ��: 2013/8/14 9:59:25
// ------------------------------

using System;
using Fireasy.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Fireasy.Data.Entity.Test.Model
{
    /// <summary>
    ///  ʵ���ࡣ
    /// </summary>
    [Serializable]
    [EntityMapping("Categories", Description = "")]
    [MetadataType(typeof(CategoriesMetadata))]
    public partial class Categories : LighEntityObject<Categories>
    {
        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "CategoryID", Description = "", IsPrimaryKey = true, IsNullable = false)]
        public virtual long CategoryID { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "CategoryName", Description = "", Length = 15, IsNullable = false)]
        public virtual string CategoryName { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "Description", Description = "", Length = 2147483647, IsNullable = true)]
        public virtual string Description { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "Picture", Description = "", IsNullable = true)]
        public virtual byte[] Picture { get; set; }

        /// <summary>
        /// ��ȡ������ <see cref="products"/> ����ʵ�弯��
        /// </summary>
        public virtual EntitySet<Products> productses { get; set; }

    }

    public class CategoriesMetadata
    {
        /// <summary>
        /// ���� CategoryID ����֤���ԡ�
        /// </summary>
        [Required]
        public object CategoryID { get; set; }

        /// <summary>
        /// ���� CategoryName ����֤���ԡ�
        /// </summary>
        [Required]
        [StringLength(15)]
        public object CategoryName { get; set; }

        /// <summary>
        /// ���� Description ����֤���ԡ�
        /// </summary>
        [StringLength(2147483647)]
        public object Description { get; set; }

        /// <summary>
        /// ���� Picture ����֤���ԡ�
        /// </summary>
        public object Picture { get; set; }

    }
}