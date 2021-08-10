using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lym.Model.Entity.Meiamsystem.Model
{
    ///<summary>
    ///系统菜单
    ///</summary>
    [SugarTable("sys_menu")]
    public partial class sys_menu
    {
           public sys_menu(){


           }
           /// <summary>
           /// Desc:UUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:菜单名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Name {get;set;}

           /// <summary>
           /// Desc:图标
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Icon {get;set;}

           /// <summary>
           /// Desc:路由地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Path {get;set;}

           /// <summary>
           /// Desc:组件路径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Component {get;set;}

           /// <summary>
           /// Desc:默认排序
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int SortIndex {get;set;}

           /// <summary>
           /// Desc:浏览权限
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ViewPower {get;set;}

           /// <summary>
           /// Desc:上级菜单
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ParentUID {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remark {get;set;}

           /// <summary>
           /// Desc:可用系统(0-PC，1-Wx)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int System {get;set;}

           /// <summary>
           /// Desc:是否外链
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte isFrame {get;set;}

           /// <summary>
           /// Desc:是否可见
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte Hidden {get;set;}

           /// <summary>
           /// Desc:是否缓存
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte KeepAlive {get;set;}

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

    }
}
