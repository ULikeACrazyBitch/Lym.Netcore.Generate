using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lym.Model.Entity.Meiamsystem.Model
{
    ///<summary>
    ///计划任务
    ///</summary>
    [SugarTable("sys_tasksqz")]
    public partial class sys_tasksqz
    {
           public sys_tasksqz(){


           }
           /// <summary>
           /// Desc:UID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:任务名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Name {get;set;}

           /// <summary>
           /// Desc:任务分组
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string JobGroup {get;set;}

           /// <summary>
           /// Desc:运行时间表达式
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Cron {get;set;}

           /// <summary>
           /// Desc:程序集名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string AssemblyName {get;set;}

           /// <summary>
           /// Desc:任务所在类
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ClassName {get;set;}

           /// <summary>
           /// Desc:任务描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remark {get;set;}

           /// <summary>
           /// Desc:执行次数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int RunTimes {get;set;}

           /// <summary>
           /// Desc:开始时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? BeginTime {get;set;}

           /// <summary>
           /// Desc:结束时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? EndTime {get;set;}

           /// <summary>
           /// Desc:触发器类型（0、simple 1、cron）
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int TriggerType {get;set;}

           /// <summary>
           /// Desc:执行间隔时间(单位:秒)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int IntervalSecond {get;set;}

           /// <summary>
           /// Desc:是否启动
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte IsStart {get;set;}

           /// <summary>
           /// Desc:传入参数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string JobParams {get;set;}

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
