/*==============================================================*/
/* Table: TS_ACCESSORY                                          */
/*==============================================================*/
create table TS_ACCESSORY 
(
   ID                   VARCHAR2(36)         not null,
   BIZ_ID               VARCHAR2(36)         not null,
   BIZ_TYPE             VARCHAR2(50)         not null,
   NAME                 VARCHAR2(50)         not null,
   ORIGINAL_NAME        VARCHAR2(50),
   PATH                 VARCHAR2(200)        not null,
   DEL_FLAG             INTEGER              default 0,
   ENCRYPTION           INTEGER              default 0,
   EXTEND               VARCHAR2(10),
   CREATED_TIME         DATE,
   constraint PK_SS_ACCESSORY primary key (ID)
);

comment on table TS_ACCESSORY is
'����';

comment on column TS_ACCESSORY.ID is
'ID';

comment on column TS_ACCESSORY.BIZ_ID is
'ҵ��ID';

comment on column TS_ACCESSORY.BIZ_TYPE is
'ҵ������';

comment on column TS_ACCESSORY.NAME is
'����';

comment on column TS_ACCESSORY.ORIGINAL_NAME is
'Դ�ļ�����';

comment on column TS_ACCESSORY.PATH is
'·��';

comment on column TS_ACCESSORY.DEL_FLAG is
'ɾ�����';

comment on column TS_ACCESSORY.ENCRYPTION is
'�Ƿ����';

comment on column TS_ACCESSORY.EXTEND is
'��չ��';

comment on column TS_ACCESSORY.CREATED_TIME is
'��������';

/*==============================================================*/
/* Table: TS_APP                                                */
/*==============================================================*/
create table TS_APP 
(
   ID                   VARCHAR2(36)         not null,
   TYPE                 INTEGER,
   NO                   VARCHAR2(50),
   NAME                 nvarchar2(100),
   REMARK               nvarchar2(200),
   STATE                INTEGER              default 1 not null,
   DEL_FLAG             INTEGER              default 0 not null,
   constraint PK_SS_APP primary key (ID)
);

comment on table TS_APP is
'Ӧ��';

comment on column TS_APP.ID is
'ID';

comment on column TS_APP.TYPE is
'���';

comment on column TS_APP.NO is
'����';

comment on column TS_APP.NAME is
'����';

comment on column TS_APP.REMARK is
'��ע';

comment on column TS_APP.STATE is
'״̬';

comment on column TS_APP.DEL_FLAG is
'ɾ�����';

/*==============================================================*/
/* Table: TS_DICT_ITEM                                          */
/*==============================================================*/
create table TS_DICT_ITEM 
(
   ID                   VARCHAR2(36)         not null,
   TYPE_ID              VARCHAR2(36)         not null,
   NAME                 nvarchar2(50)         not null,
   VALUE                INTEGER              not null,
   ORDER_NO             INTEGER,
   FLAG                 INTEGER,
   constraint PK_SS_DICT_ITEM primary key (ID)
);

comment on table TS_DICT_ITEM is
'�ֵ�ֵ';

comment on column TS_DICT_ITEM.ID is
'ID';

comment on column TS_DICT_ITEM.TYPE_ID is
'�ֵ����ID';

comment on column TS_DICT_ITEM.NAME is
'����';

comment on column TS_DICT_ITEM.VALUE is
'ֵ';

comment on column TS_DICT_ITEM.ORDER_NO is
'����';

comment on column TS_DICT_ITEM.FLAG is
'��־λ';

/*==============================================================*/
/* Table: TS_DICT_TYPE                                          */
/*==============================================================*/
create table TS_DICT_TYPE 
(
   ID                   VARCHAR2(36)         not null,
   APP_ID               VARCHAR2(36),
   CODE                 VARCHAR2(20)         not null,
   NAME                 nvarchar2(50)         not null,
   REMARK               nvarchar2(200),
   constraint PK_SS_DICT_TYPE primary key (ID)
);

comment on table TS_DICT_TYPE is
'�ֵ����';

comment on column TS_DICT_TYPE.ID is
'ID';

comment on column TS_DICT_TYPE.APP_ID is
'Ӧ��ID';

comment on column TS_DICT_TYPE.CODE is
'����';

comment on column TS_DICT_TYPE.NAME is
'����';

comment on column TS_DICT_TYPE.REMARK is
'��ע';

/*==============================================================*/
/* Table: TS_LOGIN_LOG                                          */
/*==============================================================*/
create table TS_LOGIN_LOG 
(
   ID                   VARCHAR2(36)         not null,
   USER_ID              VARCHAR2(36)         not null,
   LOGIN_TIME           DATE,
   LOGIN_IP             VARCHAR2(50),
   LOGIN_TYPE           INTEGER,
   constraint PK_SS_LOGIN_LOG primary key (ID)
);

comment on table TS_LOGIN_LOG is
'��¼��־';

comment on column TS_LOGIN_LOG.ID is
'ID';

comment on column TS_LOGIN_LOG.USER_ID is
'�û�ID';

comment on column TS_LOGIN_LOG.LOGIN_TIME is
'��¼ʱ��';

comment on column TS_LOGIN_LOG.LOGIN_IP is
'��¼IP';

comment on column TS_LOGIN_LOG.LOGIN_TYPE is
'��¼���';

/*==============================================================*/
/* Table: TS_MODULE                                             */
/*==============================================================*/
create table TS_MODULE 
(
   ID                   VARCHAR2(36)         not null,
   APP_ID               VARCHAR2(36),
   CODE                 VARCHAR2(50)         not null,
   NAME                 nvarchar2(50)         not null,
   ICON1                VARCHAR2(200),
   ICON2                VARCHAR2(200),
   ICON3                VARCHAR2(200),
   URL                  VARCHAR2(50),
   ARGUMENTS            VARCHAR2(50),
   DESCRIPTION          nvarchar2(100),
   STATE                INTEGER              default 1 not null,
   DEL_FLAG             INTEGER              default 0 not null,
   PYCODE               VARCHAR2(50),
   ORDER_NO             INTEGER              default 0,
   constraint PK_SS_MODULE primary key (ID)
);

comment on table TS_MODULE is
'ģ��';

comment on column TS_MODULE.ID is
'ID';

comment on column TS_MODULE.APP_ID is
'Ӧ��ID';

comment on column TS_MODULE.CODE is
'����';

comment on column TS_MODULE.NAME is
'����';

comment on column TS_MODULE.ICON1 is
'ͼ��1';

comment on column TS_MODULE.ICON2 is
'ͼ��2';

comment on column TS_MODULE.ICON3 is
'ͼ��3';

comment on column TS_MODULE.URL is
'��ַ';

comment on column TS_MODULE.ARGUMENTS is
'����';

comment on column TS_MODULE.DESCRIPTION is
'����';

comment on column TS_MODULE.STATE is
'״̬';

comment on column TS_MODULE.DEL_FLAG is
'�Ƿ�ɾ��';

comment on column TS_MODULE.PYCODE is
'ƴ����';

comment on column TS_MODULE.ORDER_NO is
'����';

/*==============================================================*/
/* Table: TS_MODULE_PERMISSION                                  */
/*==============================================================*/
create table TS_MODULE_PERMISSION 
(
   ID                   VARCHAR2(36)         not null,
   ROLE_ID              VARCHAR2(36)         not null,
   MODULE_ID            VARCHAR2(36)         not null,
   constraint PK_SS_MODULE_PERMISSION primary key (ID)
);

comment on table TS_MODULE_PERMISSION is
'ģ��Ȩ��';

comment on column TS_MODULE_PERMISSION.ID is
'ID';

comment on column TS_MODULE_PERMISSION.ROLE_ID is
'��ɫID';

comment on column TS_MODULE_PERMISSION.MODULE_ID is
'ģ��ID';

/*==============================================================*/
/* Table: TS_OPERATION                                          */
/*==============================================================*/
create table TS_OPERATION 
(
   ID                   VARCHAR2(36)         not null,
   MODULE_ID            VARCHAR2(36)         not null,
   CODE                 VARCHAR2(50)         not null,
   NAME                 nvarchar2(10)         not null,
   ICON                 VARCHAR2(50),
   ORDER_NO             INTEGER              default 0,
   constraint PK_SS_OPERATION primary key (ID)
);

comment on table TS_OPERATION is
'����';

comment on column TS_OPERATION.ID is
'ID';

comment on column TS_OPERATION.MODULE_ID is
'ģ��ID';

comment on column TS_OPERATION.CODE is
'����';

comment on column TS_OPERATION.NAME is
'����';

comment on column TS_OPERATION.ICON is
'ͼ��';

comment on column TS_OPERATION.ORDER_NO is
'����';

/*==============================================================*/
/* Table: TS_OPERATION_PERMISSION                               */
/*==============================================================*/
create table TS_OPERATION_PERMISSION 
(
   ID                   VARCHAR2(36)         not null,
   ROLE_ID              VARCHAR2(36)         not null,
   OPERATION_ID         VARCHAR2(36)         not null,
   constraint PK_SS_OPERATION_PERMISSION primary key (ID)
);

comment on table TS_OPERATION_PERMISSION is
'����Ȩ��';

comment on column TS_OPERATION_PERMISSION.ID is
'ID';

comment on column TS_OPERATION_PERMISSION.ROLE_ID is
'��ɫID';

comment on column TS_OPERATION_PERMISSION.OPERATION_ID is
'����ID';

/*==============================================================*/
/* Table: TS_ORG                                                */
/*==============================================================*/
create table TS_ORG 
(
   ID                   VARCHAR2(36)         not null,
   CODE                 VARCHAR2(50)         not null,
   NO                   VARCHAR2(50),
   NAME                 nvarchar2(50)         not null,
   FULL_NAME            nvarchar2(600)        not null,
   TYPE                 INTEGER              default 0 not null,
   STATE                INTEGER              default 1 not null,
   DEL_FLAG             INTEGER              default 0 not null,
   PYCODE               VARCHAR2(50),
   ORDER_NO             INTEGER              default 0,
   constraint PK_SS_ORG primary key (ID)
);

comment on table TS_ORG is
'���Ż���';

comment on column TS_ORG.ID is
'ID';

comment on column TS_ORG.CODE is
'�ڲ�����';

comment on column TS_ORG.NO is
'����';

comment on column TS_ORG.NAME is
'����';

comment on column TS_ORG.FULL_NAME is
'��������';

comment on column TS_ORG.TYPE is
'����';

comment on column TS_ORG.STATE is
'״̬';

comment on column TS_ORG.DEL_FLAG is
'ɾ�����';

comment on column TS_ORG.PYCODE is
'ƴ����';

comment on column TS_ORG.ORDER_NO is
'����';

/*==============================================================*/
/* Table: TS_ORG_PERMISSION                                     */
/*==============================================================*/
create table TS_ORG_PERMISSION 
(
   ID                   VARCHAR2(36)         not null,
   ROLE_ID              VARCHAR2(36)         not null,
   ORG_ID               VARCHAR2(36)         not null,
   constraint PK_SS_ORG_PERMISSION primary key (ID)
);

comment on table TS_ORG_PERMISSION is
'���ݣ�������Ȩ��';

comment on column TS_ORG_PERMISSION.ROLE_ID is
'��ɫID';

comment on column TS_ORG_PERMISSION.ORG_ID is
'����ID';

/*==============================================================*/
/* Table: TS_RESOURCE                                           */
/*==============================================================*/
create table TS_RESOURCE 
(
   ID                   VARCHAR2(36)         not null,
   NAME                 nvarchar2(50)         not null,
   PYCODE               VARCHAR2(50),
   URL                  VARCHAR2(50),
   STATE                INTEGER              default 1 not null,
   DEL_FLAG             INTEGER              default 0 not null,
   METHOD               VARCHAR2(10),
   DESCRIPTION          VARCHAR2(200),
   SECURITY             INTEGER              not null,
   constraint PK_SS_RESOURCE primary key (ID)
);

comment on table TS_RESOURCE is
'��Դ';

comment on column TS_RESOURCE.ID is
'ID';

comment on column TS_RESOURCE.NAME is
'����';

comment on column TS_RESOURCE.PYCODE is
'ƴ����';

comment on column TS_RESOURCE.URL is
'��ַ';

comment on column TS_RESOURCE.STATE is
'״̬';

comment on column TS_RESOURCE.DEL_FLAG is
'ɾ�����';

comment on column TS_RESOURCE.METHOD is
'HTTP����';

comment on column TS_RESOURCE.DESCRIPTION is
'����';

comment on column TS_RESOURCE.SECURITY is
'��ȫ����';

/*==============================================================*/
/* Table: TS_ROLE                                               */
/*==============================================================*/
create table TS_ROLE 
(
   ID                   VARCHAR2(36)         not null,
   APP_ID               VARCHAR2(36),
   NAME                 nvarchar2(50)         not null,
   DESCRIPTION          nvarchar2(100),
   DEL_FLAG             INTEGER              default 0 not null,
   STATE                INTEGER              default 1,
   PYCODE               VARCHAR2(50),
   TYPE                 INTEGER              not null,
   ORG_ID               VARCHAR2(50),
   constraint PK_SS_ROLE primary key (ID)
);

comment on table TS_ROLE is
'��ɫ';

comment on column TS_ROLE.ID is
'ID';

comment on column TS_ROLE.APP_ID is
'Ӧ��ID';

comment on column TS_ROLE.NAME is
'����';

comment on column TS_ROLE.DESCRIPTION is
'����';

comment on column TS_ROLE.DEL_FLAG is
'ɾ�����';

comment on column TS_ROLE.STATE is
'״̬';

comment on column TS_ROLE.PYCODE is
'ƴ����';

comment on column TS_ROLE.TYPE is
'���';

comment on column TS_ROLE.ORG_ID is
'����ID';

/*==============================================================*/
/* Table: TS_USER                                               */
/*==============================================================*/
create table TS_USER 
(
   ID                   VARCHAR2(36)         not null,
   ORG_ID               VARCHAR2(36),
   ACCOUNT              VARCHAR2(50)         not null,
   NAME                 nvarchar2(20)         not null,
   PASSWORD             VARCHAR2(50)         not null,
   STATE                INTEGER              default 1 not null,
   TYPE                 INTEGER,
   DEL_FLAG             INTEGER              default 0 not null,
   PYCODE               VARCHAR2(20),
   ORDER_NO             INTEGER,
   EMAIL                VARCHAR2(50),
   MOBILE               VARCHAR2(20),
   constraint PK_SS_USER primary key (ID)
);

comment on table TS_USER is
'�û�';

comment on column TS_USER.ID is
'ID';

comment on column TS_USER.ORG_ID is
'����ID';

comment on column TS_USER.ACCOUNT is
'�ʺ�';

comment on column TS_USER.NAME is
'����';

comment on column TS_USER.PASSWORD is
'����';

comment on column TS_USER.STATE is
'״̬';

comment on column TS_USER.TYPE is
'���';

comment on column TS_USER.DEL_FLAG is
'ɾ�����';

comment on column TS_USER.PYCODE is
'ƴ����';

comment on column TS_USER.ORDER_NO is
'����';

comment on column TS_USER.EMAIL is
'�����ʼ�';

comment on column TS_USER.MOBILE is
'�ֻ�����';

/*==============================================================*/
/* Table: TS_USER_ROLES                                         */
/*==============================================================*/
create table TS_USER_ROLES 
(
   ID                   VARCHAR2(36)         not null,
   USER_ID              VARCHAR2(36)         not null,
   ROLE_ID              VARCHAR2(36)         not null,
   constraint PK_SS_USER_ROLES primary key (ID)
);

comment on table TS_USER_ROLES is
'�û���ɫ';

comment on column TS_USER_ROLES.USER_ID is
'�û�ID';

comment on column TS_USER_ROLES.ROLE_ID is
'��ɫID';