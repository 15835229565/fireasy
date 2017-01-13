// ------------------------------
// ��ģ����CodeBuilder��������,���������� Fireasy.Data.Entity 1.5 ���ݿ��
// ��Ȩ���� (C) Fireasy 2011

// ��Ŀ����: ʵ���ܲ�����Ŀ
// ģ������: ������ϸ�� ʵ����
// �����д: Huangxd
// �ļ�·��: C:\Users\Ruibron\Desktop\Model\OrderDetails.cs
// ����ʱ��: 2013/8/14 9:59:25
// ------------------------------

using System;
using Fireasy.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Fireasy.Data.Entity.Test.Model
{
    [Serializable]
    [EntityMapping("order details", Description = "")]
    [MetadataType(typeof(OrderDetailsMetadata))]
    public partial class OrderDetails : LighEntityObject<OrderDetails>
    {
        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "OrderID", Description = "", IsPrimaryKey = true, IsNullable = false)]
        public virtual long OrderID { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "ProductID", Description = "", IsPrimaryKey = true, IsNullable = false)]
        public virtual long ProductID { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "UnitPrice", Description = "", IsNullable = false)]
        public virtual double UnitPrice { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "Quantity", Description = "", IsNullable = false)]
        public virtual long Quantity { get; set; }

        /// <summary>
        /// ��ȡ�����á�
        /// </summary>

        [PropertyMapping(ColumnName = "Discount", Description = "", IsNullable = false)]
        public virtual double Discount { get; set; }

        /// <summary>
        /// ��ȡ�����ù��� <see cref="products"/> ����
        /// </summary>
        public virtual Products Products { get; set; }

        /// <summary>
        /// ��ȡ�����ù��� <see cref="orders"/> ����
        /// </summary>
        public virtual Orders Orders { get; set; }

    }

    public class OrderDetailsMetadata
    {
        /// <summary>
        /// ���� OrderID ����֤���ԡ�
        /// </summary>
        [Required]
        public object OrderID { get; set; }

        /// <summary>
        /// ���� ProductID ����֤���ԡ�
        /// </summary>
        [Required]
        public object ProductID { get; set; }

        /// <summary>
        /// ���� UnitPrice ����֤���ԡ�
        /// </summary>
        [Required]
        public object UnitPrice { get; set; }

        /// <summary>
        /// ���� Quantity ����֤���ԡ�
        /// </summary>
        [Required]
        public object Quantity { get; set; }

        /// <summary>
        /// ���� Discount ����֤���ԡ�
        /// </summary>
        [Required]
        public object Discount { get; set; }

    }
}