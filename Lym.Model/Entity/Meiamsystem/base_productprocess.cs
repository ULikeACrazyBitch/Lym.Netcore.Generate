using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lym.Model.Entity.Meiamsystem.Model
{
    ///<summary>
    ///工序定义
    ///</summary>
    [SugarTable("base_productprocess")]
    public partial class base_productprocess
    {
           public base_productprocess(){


           }
           /// <summary>
           /// Desc:UUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:工序编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ProcessNo {get;set;}

           /// <summary>
           /// Desc:工序名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ProcessName {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remark {get;set;}

           /// <summary>
           /// Desc:是否启用
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte Enable {get;set;}

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
