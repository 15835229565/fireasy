// ------------------------------
// ��ģ����CodeBuilder��������,���������� Fireasy.Data.Entity 1.5 ���ݿ��
// ��Ȩ���� (C) Fireasy 2011

// ��Ŀ����: ʵ���ܲ�����Ŀ
// ģ������: ������ ʵ����
// �����д: Huangxd
// �ļ�·��: C:\Users\Ruibron\Desktop\Model\Orders.cs
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
    [EntityMapping("orders", Description = "")]
    [MetadataType(typeof(OrdersMetadata))]
    public partial class Orders : LighEntityObject<Orders>
    {
        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "OrderID", Description = "", IsPrimaryKey = true, IsNullable = false)]
        public virtual long OrderID { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "CustomerID", Description = "", Length = 5, IsNullable = true)]
        public virtual string CustomerID { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "EmployeeID", Description = "", IsNullable = true)]
        public virtual long? EmployeeID { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "OrderDate", Description = "", Length = 2147483647, IsNullable = true)]
        public virtual DateTime? OrderDate { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "RequiredDate", Description = "", Length = 2147483647, IsNullable = true)]
        public virtual DateTime? RequiredDate { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "ShippedDate", Description = "", Length = 2147483647, IsNullable = true)]
        public virtual string ShippedDate { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "ShipVia", Description = "", IsNullable = true)]
        public virtual long? ShipVia { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "Freight", Description = "", IsNullable = true)]
        public virtual decimal? Freight { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "ShipName", Description = "", Length = 40, IsNullable = true)]
        public virtual string ShipName { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "ShipAddress", Description = "", Length = 60, IsNullable = true)]
        public virtual string ShipAddress { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "ShipCity", Description = "", Length = 15, IsNullable = true)]
        public virtual string ShipCity { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "ShipRegion", Description = "", Length = 15, IsNullable = true)]
        public virtual string ShipRegion { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "ShipPostalCode", Description = "", Length = 10, IsNullable = true)]
        public virtual string ShipPostalCode { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "ShipCountry", Description = "", Length = 15, IsNullable = true)]
        public virtual string ShipCountry { get; set; }

        /// <summary>
        /// ��ȡ�����ù��� <see cref="customers"/> ����
        /// </summary>
        public virtual Customers Customers { get; set; }

        /// <summary>
        /// ��ȡ������ <see cref="order details"/> ����ʵ�弯��
        /// </summary>
        public virtual EntitySet<OrderDetails> OrderDetailses { get; set; }

    }

    public class OrdersMetadata
    {
        /// <summary>
        /// ���� OrderID ����֤���ԡ�
        /// </summary>
        [Required]
        public object OrderID { get; set; }

        /// <summary>
        /// ���� CustomerID ����֤���ԡ�
        /// </summary>
        [StringLength(5)]
        public object CustomerID { get; set; }

        /// <summary>
        /// ���� EmployeeID ����֤���ԡ�
        /// </summary>
        public object EmployeeID { get; set; }

        /// <summary>
        /// ���� OrderDate ����֤���ԡ�
        /// </summary>
        [StringLength(2147483647)]
        public object OrderDate { get; set; }

        /// <summary>
        /// ���� RequiredDate ����֤���ԡ�
        /// </summary>
        [StringLength(2147483647)]
        public object RequiredDate { get; set; }

        /// <summary>
        /// ���� ShippedDate ����֤���ԡ�
        /// </summary>
        [StringLength(2147483647)]
        public object ShippedDate { get; set; }

        /// <summary>
        /// ���� ShipVia ����֤���ԡ�
        /// </summary>
        public object ShipVia { get; set; }

        /// <summary>
        /// ���� Freight ����֤���ԡ�
        /// </summary>
        public object Freight { get; set; }

        /// <summary>
        /// ���� ShipName ����֤���ԡ�
        /// </summary>
        [StringLength(40)]
        public object ShipName { get; set; }

        /// <summary>
        /// ���� ShipAddress ����֤���ԡ�
        /// </summary>
        [StringLength(60)]
        public object ShipAddress { get; set; }

        /// <summary>
        /// ���� ShipCity ����֤���ԡ�
        /// </summary>
        [StringLength(15)]
        public object ShipCity { get; set; }

        /// <summary>
        /// ���� ShipRegion ����֤���ԡ�
        /// </summary>
        [StringLength(15)]
        public object ShipRegion { get; set; }

        /// <summary>
        /// ���� ShipPostalCode ����֤���ԡ�
        /// </summary>
        [StringLength(10)]
        public object ShipPostalCode { get; set; }

        /// <summary>
        /// ���� ShipCountry ����֤���ԡ�
        /// </summary>
        [StringLength(15)]
        public object ShipCountry { get; set; }

    }
}