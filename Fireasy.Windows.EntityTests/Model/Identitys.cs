// ------------------------------
// ��ģ����CodeBuilder��������,���������� Fireasy.Data.Entity 1.5 ���ݿ��
// ��Ȩ���� (C) Fireasy 2011

// ��Ŀ����: ʵ���ܲ�����Ŀ
// ģ������: Identitys ʵ����
// �����д: Huangxd
// �ļ�·��: C:\Users\Ruibron\Desktop\Model\Identitys.cs
// ����ʱ��: 2013/10/15 10:28:27
// ------------------------------

using System;
using Fireasy.Data.Entity;

namespace Fireasy.Data.Entity.Test.Model
{
    /// <summary>
    /// Identitys ʵ���ࡣ
    /// </summary>
    [Serializable]
    [EntityMapping("Identitys")]
    public partial class Identitys : EntityObject
    {
        #region Static Property Definition
        
        /// <summary>
        /// Id1���������ԡ�
        /// </summary>
        public static readonly IProperty EpId1 = PropertyUnity.RegisterProperty<Identitys>(s => s.Id1, new PropertyMapInfo { IsPrimaryKey = true, GenerateType = IdentityGenerateType.AutoIncrement, IsNullable = false, FieldName = "Id1" });

        /// <summary>
        /// Id2���������ԡ�
        /// </summary>
        public static readonly IProperty EpId2 = PropertyUnity.RegisterProperty<Identitys>(s => s.Id2, new PropertyMapInfo { IsPrimaryKey = true, GenerateType = IdentityGenerateType.Generator, IsNullable = false, FieldName = "Id2" });

        /// <summary>
        /// Id2���������ԡ�
        /// </summary>
        public static readonly IProperty EpId3 = PropertyUnity.RegisterProperty<Identitys>(s => s.Id3, new PropertyMapInfo { IsPrimaryKey = true, IsNullable = false, FieldName = "Id3" });

        #endregion

        #region Properties
        
        /// <summary>
        /// ��ȡ������Id1��
        /// </summary>
        public int Id1
        {
            get { return (int)GetValue(EpId1); }
            set { SetValue(EpId1, value); }
        }

        /// <summary>
        /// ��ȡ������Id2��
        /// </summary>
        public int Id2
        {
            get { return (int)GetValue(EpId2); }
            set { SetValue(EpId2, value); }
        }

        /// <summary>
        /// ��ȡ������Id3��
        /// </summary>
        public string Id3
        {
            get { return (string)GetValue(EpId3); }
            set { SetValue(EpId3, value); }
        }

        #endregion

    }
}