// ------------------------------
// ��ģ����CodeBuilder��������,���������� Fireasy.Data.Entity 1.5 ���ݿ��
// ��Ȩ���� (C) Fireasy 2011

// ��Ŀ����: ʵ���ܲ�����Ŀ
// ģ������: Identitys ʵ����(������֤Ԫ����)
// �����д: Huangxd
// �ļ�·��: C:\Users\Ruibron\Desktop\Model\Identitys_EX.cs
// ����ʱ��: 2013/10/15 10:28:27
// ------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Fireasy.Data.Entity;

namespace Fireasy.Data.Entity.Test.Model
{
    //���Ҫ����ʵ����֤����ʹ���������ԣ����� IdentitysMetadata �ж�����֤���ԡ�
    [MetadataType(typeof(IdentitysMetadata))] 
    public partial class Identitys
    {
    }

    public class IdentitysMetadata
    {
        
        /// <summary>
        /// ���� Id1 ����֤���ԡ�
        /// </summary>
        //[Display(Description = "Id1")]
        [Required]
        public object Id1 { get; set; }

        /// <summary>
        /// ���� Id2 ����֤���ԡ�
        /// </summary>
        //[Display(Description = "Id2")]
        [Required]
        public object Id2 { get; set; }

        /// <summary>
        /// ���� Id3 ����֤���ԡ�
        /// </summary>
        //[Display(Description = "Id3")]
        [Required]
        public object Id3 { get; set; }

    }
}