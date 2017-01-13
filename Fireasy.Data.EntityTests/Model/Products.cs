// ------------------------------
// ��ģ����CodeBuilder��������,���������� Fireasy.Data.Entity 1.5 ���ݿ��
// ��Ȩ���� (C) Fireasy 2011

// ��Ŀ����: ʵ���ܲ�����Ŀ
// ģ������: ��Ʒ�� ʵ����
// �����д: Huangxd
// �ļ�·��: C:\Users\Ruibron\Desktop\Model\Products.cs
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
    [EntityMapping("products", Description = "")]
    [MetadataType(typeof(ProductsMetadata))]
    public partial class Products : LighEntityObject<Products>, IIntegralQueryable
    {
        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "ProductID", Description = "", IsPrimaryKey = true, IsNullable = false)]
        public virtual long ProductID { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "ProductName", Description = "", Length = 40, IsNullable = false)]
        [InterfaceMemberMapping(typeof(IIntegralQueryable), "ProductName")]
        public virtual string ProductName { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "SupplierID", Description = "", IsNullable = true)]
        public virtual long? SupplierID { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "CategoryID", Description = "", IsNullable = true)]
        public virtual long? CategoryID { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "QuantityPerUnit", Description = "", Length = 20, IsNullable = true)]
        public virtual string QuantityPerUnit { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "UnitPrice", Description = "", IsNullable = true)]
        public virtual double? UnitPrice { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "UnitsInStock", Description = "", IsNullable = true)]
        public virtual long? UnitsInStock { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "UnitsOnOrder", Description = "", IsNullable = true)]
        public virtual long? UnitsOnOrder { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "ReorderLevel", Description = "", IsNullable = true)]
        public virtual RecorderLevel ReorderLevel { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "Discontinued", Description = "", IsNullable = false)]
        public virtual bool Discontinued { get; set; }

        /// <summary>
        /// ��ȡ�����ù��� <see cref="categories"/> ����
        /// </summary>
        public virtual Categories categories { get; set; }

        /// <summary>
        /// ��ȡ������ <see cref="order details"/> ����ʵ�弯��
        /// </summary>
        public virtual EntitySet<OrderDetails> OrderDetailses { get; set; }

        public string Name { get; set; }
    }

    public class ProductsMetadata
    {
        /// <summary>
        /// ���� ProductID ����֤���ԡ�
        /// </summary>
        [Required]
        public object ProductID { get; set; }

        /// <summary>
        /// ���� ProductName ����֤���ԡ�
        /// </summary>
        [Required]
        [StringLength(40)]
        public object ProductName { get; set; }

        /// <summary>
        /// ���� SupplierID ����֤���ԡ�
        /// </summary>
        public object SupplierID { get; set; }

        /// <summary>
        /// ���� CategoryID ����֤���ԡ�
        /// </summary>
        public object CategoryID { get; set; }

        /// <summary>
        /// ���� QuantityPerUnit ����֤���ԡ�
        /// </summary>
        [StringLength(20)]
        public object QuantityPerUnit { get; set; }

        /// <summary>
        /// ���� UnitPrice ����֤���ԡ�
        /// </summary>
        public object UnitPrice { get; set; }

        /// <summary>
        /// ���� UnitsInStock ����֤���ԡ�
        /// </summary>
        public object UnitsInStock { get; set; }

        /// <summary>
        /// ���� UnitsOnOrder ����֤���ԡ�
        /// </summary>
        public object UnitsOnOrder { get; set; }

        /// <summary>
        /// ���� ReorderLevel ����֤���ԡ�
        /// </summary>
        public object ReorderLevel { get; set; }

        /// <summary>
        /// ���� Discontinued ����֤���ԡ�
        /// </summary>
        [Required]
        public object Discontinued { get; set; }

    }

    
    public interface IIntegralQueryable : IEntity
    {
        string Name { get; set; }
    }

}