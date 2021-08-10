using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lym.Model.Entity.Meiamsystem.Model
{
    ///<summary>
    ///用户管理
    ///</summary>
    [SugarTable("sys_users")]
    public partial class sys_users
    {
           public sys_users(){


           }
           /// <summary>
           /// Desc:用户账号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserID {get;set;}

           /// <summary>
           /// Desc:用户名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:用户昵称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string NickName {get;set;}

           /// <summary>
           /// Desc:邮箱
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Email {get;set;}

           /// <summary>
           /// Desc:密码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Password {get;set;}

           /// <summary>
           /// Desc:性别
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Sex {get;set;}

           /// <summary>
           /// Desc:头像地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string AvatarUrl {get;set;}

           /// <summary>
           /// Desc:QQ
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string QQ {get;set;}

           /// <summary>
           /// Desc:手机号码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Phone {get;set;}

           /// <summary>
           /// Desc:用户所在省份编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ProvinceID {get;set;}

           /// <summary>
           /// Desc:用户所在省份
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Province {get;set;}

           /// <summary>
           /// Desc:用户所在城市编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CityID {get;set;}

           /// <summary>
           /// Desc:用户所在城市
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string City {get;set;}

           /// <summary>
           /// Desc:用户所在县/区编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CountyID {get;set;}

           /// <summary>
           /// Desc:用户所在县/区
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string County {get;set;}

           /// <summary>
           /// Desc:地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Address {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remark {get;set;}

           /// <summary>
           /// Desc:身份证
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IdentityCard {get;set;}

           /// <summary>
           /// Desc:生日
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? Birthday {get;set;}

           /// <summary>
           /// Desc:上次登录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? LastLoginTime {get;set;}

           /// <summary>
           /// Desc:是否启用
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte Enabled {get;set;}

           /// <summary>
           /// Desc:单用户模式
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte OneSession {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime CreateTime {get;set;}

           /// <summary>
           /// Desc:最后更新时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime UpdateTime {get;set;}

           /// <summary>
           /// Desc:创建人编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CreateID {get;set;}

           /// <summary>
           /// Desc:创建人
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CreateName {get;set;}

           /// <summary>
           /// Desc:更新人编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UpdateID {get;set;}

           /// <summary>
           /// Desc:更新人
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UpdateName {get;set;}

           /// <summary>
           /// Desc:超级管理员
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte Administrator {get;set;}

    }
}
