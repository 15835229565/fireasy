// ------------------------------
// ��ģ����CodeBuilder��������,���������� Fireasy.Data.Entity 1.5 ���ݿ��
// ��Ȩ���� (C) Fireasy 2011

// ��Ŀ����: ʵ���ܲ�����Ŀ
// ģ������: ��ϵ����
// �����д: Huangxd
// �ļ�·��: $FilePath$
// ����ʱ��: 2013/8/14 9:59:25
// ------------------------------

#region NAMESPACE
using Fireasy.Data.Entity;
#endregion NAMESPACE

[assembly: Relationship("Categories:Products", typeof(Fireasy.Data.Entity.Test.Model.Categories), typeof(Fireasy.Data.Entity.Test.Model.Products), "CategoryID=>CategoryID")]
[assembly: Relationship("Customers:Orders", typeof(Fireasy.Data.Entity.Test.Model.Customers), typeof(Fireasy.Data.Entity.Test.Model.Orders), "CustomerID=>CustomerID")]
[assembly: Relationship("Orders:Order Details", typeof(Fireasy.Data.Entity.Test.Model.Orders), typeof(Fireasy.Data.Entity.Test.Model.OrderDetails), "OrderID=>OrderID")]
[assembly: Relationship("Products:Order Details", typeof(Fireasy.Data.Entity.Test.Model.Products), typeof(Fireasy.Data.Entity.Test.Model.OrderDetails), "ProductID=>ProductID")]
[assembly: Relationship("Orders1:Order Details", typeof(Fireasy.Data.Entity.Test.Model.Orders), typeof(Fireasy.Data.Entity.Test.Model.OrderDetails), "OrderID=>OrderID")]
