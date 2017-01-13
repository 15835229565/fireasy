/*==============================================================*/
/* Table: TS_ACCESSORY                                          */
/*==============================================================*/
create table TS_ACCESSORY
(
   ID                   varchar(36) not null comment 'ID',
   BIZ_ID               varchar(36) not null comment 'ҵ��ID',
   BIZ_TYPE             varchar(50) not null comment 'ҵ������',
   NAME                 varchar(50) not null comment '����',
   ORIGINAL_NAME        varchar(50) comment 'Դ�ļ�����',
   PATH                 varchar(200) not null comment '·��',
   DEL_FLAG             int default 0 comment 'ɾ�����',
   ENCRYPTION           int default 0 comment '�Ƿ����',
   EXTEND               varchar(10) comment '��չ��',
   CREATED_TIME         datetime comment '��������',
   primary key (ID)
);

alter table TS_ACCESSORY comment '����';

/*==============================================================*/
/* Table: TS_LOGIN_LOG                                          */
/*==============================================================*/
create table TS_LOGIN_LOG
(
   ID                   varchar(36) not null comment 'ID',
   USER_ID              varchar(36) not null comment '�û�ID',
   LOGIN_TIME           datetime comment '��¼ʱ��',
   LOGIN_IP             varchar(50) comment '��¼IP',
   LOGIN_TYPE           int comment '��¼���',
   primary key (ID)
);

alter table TS_LOGIN_LOG comment '��¼��־';

/*==============================================================*/
/* Table: TS_MODULE                                             */
/*==============================================================*/
create table TS_MODULE
(
   ID                   varchar(36) not null comment 'ID',
   APP_ID               varchar(36) comment 'Ӧ��ID',
   CODE                 varchar(50) not null comment '����',
   NAME                 nvarchar(50) not null comment '����',
   ICON1                varchar(200) comment 'ͼ��1',
   ICON2                varchar(200) comment 'ͼ��2',
   ICON3                varchar(200) comment 'ͼ��3',
   URL                  varchar(50) comment '��ַ',
   ARGUMENTS            varchar(50) comment '����',
   DESCRIPTION          nvarchar(100) comment '����',
   STATE                int not null default 1 comment '״̬',
   DEL_FLAG             int not null default 0 comment '�Ƿ�ɾ��',
   PYCODE               varchar(50) comment 'ƴ����',
   ORDER_NO             int default 0 comment '����',
   primary key (ID)
);

alter table TS_MODULE comment 'ģ��';

/*==============================================================*/
/* Table: TS_MODULE_PERMISSION                                  */
/*==============================================================*/
create table TS_MODULE_PERMISSION
(
   ID                   varchar(36) not null comment 'ID',
   ROLE_ID              varchar(36) not null comment '��ɫID',
   MODULE_ID            varchar(36) not null comment 'ģ��ID',
   primary key (ID)
);

alter table TS_MODULE_PERMISSION comment 'ģ��Ȩ��';

/*==============================================================*/
/* Table: TS_OPERATION                                          */
/*==============================================================*/
create table TS_OPERATION
(
   ID                   varchar(36) not null comment 'ID',
   MODULE_ID            varchar(36) not null comment 'ģ��ID',
   CODE                 varchar(50) not null comment '����',
   NAME                 nvarchar(10) not null comment '����',
   ICON                 varchar(50) comment 'ͼ��',
   ORDER_NO             int default 0 comment '����',
   primary key (ID)
);

alter table TS_OPERATION comment '����';

/*==============================================================*/
/* Table: TS_OPERATION_PERMISSION                               */
/*==============================================================*/
create table TS_OPERATION_PERMISSION
(
   ID                   varchar(36) not null comment 'ID',
   ROLE_ID              varchar(36) not null comment '��ɫID',
   OPERATION_ID         varchar(36) not null comment '����ID',
   primary key (ID)
);

alter table TS_OPERATION_PERMISSION comment '����Ȩ��';

/*==============================================================*/
/* Table: TS_ORG                                                */
/*==============================================================*/
create table TS_ORG
(
   ID                   varchar(36) not null comment 'ID',
   CODE                 varchar(50) not null comment '�ڲ�����',
   NO                   varchar(50) comment '����',
   NAME                 nvarchar(50) not null comment '����',
   FULL_NAME            nvarchar(600) not null comment '��������',
   TYPE                 int not null default 0 comment '����',
   STATE                int not null default 1 comment '״̬',
   DEL_FLAG             int not null default 0 comment 'ɾ�����',
   PYCODE               varchar(50) comment 'ƴ����',
   ORDER_NO             int default 0 comment '����',
   primary key (ID)
);

alter table TS_ORG comment '���Ż���';

/*==============================================================*/
/* Table: TS_ORG_PERMISSION                                     */
/*==============================================================*/
create table TS_ORG_PERMISSION
(
   ID                   varchar(36) not null,
   ROLE_ID              varchar(36) not null comment '��ɫID',
   ORG_ID               varchar(36) not null comment '����ID',
   primary key (ID)
);

alter table TS_ORG_PERMISSION comment '���ݣ�������Ȩ��';

/*==============================================================*/
/* Table: TS_RESOURCE                                           */
/*==============================================================*/
create table TS_RESOURCE
(
   ID                   varchar(36) not null comment 'ID',
   NAME                 nvarchar(50) not null comment '����',
   PYCODE               varchar(50) comment 'ƴ����',
   URL                  varchar(50) comment '��ַ',
   STATE                int not null default 1 comment '״̬',
   DEL_FLAG             int not null default 0 comment 'ɾ�����',
   METHOD               varchar(10) comment 'HTTP����',
   DESCRIPTION          varchar(200) comment '����',
   SECURITY             int not null comment '��ȫ����',
   primary key (ID)
);

alter table TS_RESOURCE comment '��Դ';

/*==============================================================*/
/* Table: TS_ROLE                                               */
/*==============================================================*/
create table TS_ROLE
(
   ID                   varchar(36) not null comment 'ID',
   APP_ID               varchar(36) comment 'Ӧ��ID',
   NAME                 nvarchar(50) not null comment '����',
   DESCRIPTION          nvarchar(100) comment '����',
   DEL_FLAG             int not null default 0 comment 'ɾ�����',
   STATE                int default 1 comment '״̬',
   PYCODE               varchar(50) comment 'ƴ����',
   TYPE                 int not null comment '���',
   ORG_ID               varchar(50) comment '����ID',
   primary key (ID)
);

alter table TS_ROLE comment '��ɫ';

/*==============================================================*/
/* Table: TS_USER                                               */
/*==============================================================*/
create table TS_USER
(
   ID                   varchar(36) not null comment 'ID',
   ORG_ID               varchar(36) comment '����ID',
   ACCOUNT              varchar(50) not null comment '�ʺ�',
   NAME                 nvarchar(20) not null comment '����',
   PASSWORD             varchar(50) not null comment '����',
   STATE                int not null default 1 comment '״̬',
   TYPE                 int comment '���',
   DEL_FLAG             int not null default 0 comment 'ɾ�����',
   PYCODE               varchar(20) comment 'ƴ����',
   ORDER_NO             int comment '����',
   EMAIL                varchar(50) comment '�����ʼ�',
   MOBILE               varchar(20) comment '�ֻ�����',
   primary key (ID)
);

alter table TS_USER comment '�û�';

/*==============================================================*/
/* Table: TS_USER_ROLES                                         */
/*==============================================================*/
create table TS_USER_ROLES
(
   ID                   varchar(36) not null,
   USER_ID              varchar(36) not null comment '�û�ID',
   ROLE_ID              varchar(36) not null comment '��ɫID',
   primary key (ID)
);

alter table TS_USER_ROLES comment '�û���ɫ';



insert into TS_MODULE (id, app_id, code, name, icon1, icon2, icon3, url, arguments, description, state, del_flag, pycode, order_no)
values ('b5e2a884-25a1-4a67-afe5-667383afcac4', null, '0001', 'ϵͳ����', null, null, null, null, null, null, 1, 0, 'XTGL', 1);
insert into TS_MODULE (id, app_id, code, name, icon1, icon2, icon3, url, arguments, description, state, del_flag, pycode, order_no)
values ('da85b83a-19bb-410c-8ab5-9293d89cfe84', null, '00010010', 'ģ�����', null, null, null, 'Admin/ModuleList.aspx', null, null, 1, 0, 'MKGL', 1);
insert into TS_MODULE (id, app_id, code, name, icon1, icon2, icon3, url, arguments, description, state, del_flag, pycode, order_no)
values ('fd9e7af8-4ec2-4e16-9481-32a288a63807', null, '00010008', '�û�����', null, null, null, 'Admin/UserList.aspx', null, null, 1, 0, 'YHGL', 2);
insert into TS_MODULE (id, app_id, code, name, icon1, icon2, icon3, url, arguments, description, state, del_flag, pycode, order_no)
values ('a8073844-675a-41a6-a449-844e6b818d17', null, '00010012', '���ܽ�ɫ����', null, null, null, 'Admin/RoleList.aspx', 'type=0', null, 1, 0, 'GNJSGL', 3);
insert into TS_MODULE (id, app_id, code, name, icon1, icon2, icon3, url, arguments, description, state, del_flag, pycode, order_no)
values ('39c24158-3918-47ee-bafa-48bb9fd797cc', null, '00010013', '���ݽ�ɫ����', null, null, null, 'Admin/RoleList.aspx', 'type=1', null, 1, 0, 'SJJSGL', 4);
insert into TS_MODULE (id, app_id, code, name, icon1, icon2, icon3, url, arguments, description, state, del_flag, pycode, order_no)
values ('5dd79144-f817-4c4d-92c5-6c1f6834c9f1', null, '00010014', '��������', null, null, null, 'Admin/OrgList.aspx', null, null, 1, 0, 'JGGL', 5);
insert into TS_MODULE (id, app_id, code, name, icon1, icon2, icon3, url, arguments, description, state, del_flag, pycode, order_no)
values ('ba994ec7-a0c1-4eb4-aa8f-4107b93c7d87', null, '00010015', '��Դ����', null, null, null, 'Admin/ResourceList.aspx', null, null, 1, 0, 'ZYGL', 6);

insert into TS_OPERATION (id, module_id, code, name, icon)
values ('0f1f497a-0d8c-4dd8-94cb-328b2a49cd9f', 'fd9e7af8-4ec2-4e16-9481-32a288a63807', 'right', 'Ȩ��', 'icon-tip');
insert into TS_OPERATION (id, module_id, code, name, icon)
values ('c72b3711-d4f4-401c-9617-20d036a32ff8', 'a8073844-675a-41a6-a449-844e6b818d17', 'right', '��Ȩ', 'icon-tip');
insert into TS_OPERATION (id, module_id, code, name, icon)
values ('3702eb74-c1f3-40be-852a-8fd07be8d40d', '39c24158-3918-47ee-bafa-48bb9fd797cc', 'right', '��Ȩ', 'icon-tip');
insert into TS_OPERATION (id, module_id, code, name, icon)
values ('f38f6dea-72f5-4411-876a-b8c9b5a9cd5f', 'da85b83a-19bb-410c-8ab5-9293d89cfe84', 'operation', '����', 'icon-tip');

insert into TS_ORG (id, code, no, name, full_name, type, state, del_flag, pycode)
values ('786bdb03-52b9-499e-bf2d-3047b671fe3b', '0001', 'admin', '����Ա��', '����Ա��', 0, 1, 0, 'GLYZ');

insert into TS_ROLE (id, app_id, name, description, del_flag, state, pycode, org_id, type)
values ('c9639448-6da0-4790-8111-7ca5b145b13b', null, '��������Ա', null, 0, 1, null, '786bdb03-52b9-499e-bf2d-3047b671fe3b', 0);

insert into TS_USER (id, org_id, account, name, password, state, del_flag, pycode)
values ('0858f9db-1536-4c7d-9ad5-84f59e45f232', '786bdb03-52b9-499e-bf2d-3047b671fe3b', 'admin', '����Ա', '21232F297A57A5A743894AE4A801FC3', 1, 0, 'GLY');

insert into TS_USER_ROLES (id, user_id, role_id)
values ('378c898d-4156-4f86-a9e5-33df386d2916', '0858f9db-1536-4c7d-9ad5-84f59e45f232', 'c9639448-6da0-4790-8111-7ca5b145b13b');

insert into TS_MODULE_PERMISSION (id, role_id, module_id)
values ('dc97803a-bd25-4486-b18e-751abe316d8e', 'c9639448-6da0-4790-8111-7ca5b145b13b', 'b5e2a884-25a1-4a67-afe5-667383afcac4');
insert into TS_MODULE_PERMISSION (id, role_id, module_id)
values ('704087c1-d821-4712-967f-503c4eaba8eb', 'c9639448-6da0-4790-8111-7ca5b145b13b', '5dd79144-f817-4c4d-92c5-6c1f6834c9f1');
insert into TS_MODULE_PERMISSION (id, role_id, module_id)
values ('31997523-097b-4ea7-a2b2-58eaad9c6f90', 'c9639448-6da0-4790-8111-7ca5b145b13b', 'da85b83a-19bb-410c-8ab5-9293d89cfe84');
insert into TS_MODULE_PERMISSION (id, role_id, module_id)
values ('0c3ec2cc-a4ec-447a-a29c-329c17aa4633', 'c9639448-6da0-4790-8111-7ca5b145b13b', 'a8073844-675a-41a6-a449-844e6b818d17');
insert into TS_MODULE_PERMISSION (id, role_id, module_id)
values ('01c3e697-98f3-4af4-844d-99e2da11cc9b', 'c9639448-6da0-4790-8111-7ca5b145b13b', '39c24158-3918-47ee-bafa-48bb9fd797cc');
insert into TS_MODULE_PERMISSION (id, role_id, module_id)
values ('2aba1ee3-072f-496e-9c2e-01c879f06fa5', 'c9639448-6da0-4790-8111-7ca5b145b13b', 'fd9e7af8-4ec2-4e16-9481-32a288a63807');
insert into TS_MODULE_PERMISSION (id, role_id, module_id)
values ('1e693250-1656-45c9-9050-65d6c65a3af8', 'c9639448-6da0-4790-8111-7ca5b145b13b', 'ba994ec7-a0c1-4eb4-aa8f-4107b93c7d87');

insert into TS_OPERATION_PERMISSION (id, role_id, operation_id)
values ('88cc2028-30e3-4c9d-85a5-d7b1ae0cd8e1', 'c9639448-6da0-4790-8111-7ca5b145b13b', 'f38f6dea-72f5-4411-876a-b8c9b5a9cd5f');
insert into TS_OPERATION_PERMISSION (id, role_id, operation_id)
values ('cf6fb4a8-06bf-41e2-b50b-857d42783ff1', 'c9639448-6da0-4790-8111-7ca5b145b13b', 'c72b3711-d4f4-401c-9617-20d036a32ff8');
insert into TS_OPERATION_PERMISSION (id, role_id, operation_id)
values ('cfb5984a-6dea-43f1-ba42-4f4bfa9cbae8', 'c9639448-6da0-4790-8111-7ca5b145b13b', '3702eb74-c1f3-40be-852a-8fd07be8d40d');
insert into TS_OPERATION_PERMISSION (id, role_id, operation_id)
values ('e1dc847f-14b8-456c-ae32-8d9e0c2e6b84', 'c9639448-6da0-4790-8111-7ca5b145b13b', '0f1f497a-0d8c-4dd8-94cb-328b2a49cd9f');