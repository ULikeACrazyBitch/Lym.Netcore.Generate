using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Model.Entity.SdtQueuesystem
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("sdt_queuesystem.deviceinfo")]
    public class Deviceinfo
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true )]
         public Guid Id{ get; set; }
        /// <summary>
        /// 接口地址
        ///</summary>
         [SugarColumn(ColumnName="IP"  )]
         public string IP{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="MAC"  )]
         public string MAC{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="PageType"  )]
         public string PageType{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Remark"  )]
         public string Remark{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Poster"  )]
         public string Poster{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="ClinicId"  )]
         public string ClinicId{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="UnitId"  )]
         public string UnitId{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="DocId"  )]
         public string DocId{ get; set; }
        /// <summary>
        /// 创建时间
        ///</summary>
         [SugarColumn(ColumnName="CreateTime"  )]
         public DateTime CreateTime{ get; set; }
        /// <summary>
        /// 状态 1启用 0禁用
        ///</summary>
         [SugarColumn(ColumnName="State"  )]
         public string State{ get; set; }
        /// <summary>
        /// 医生名称（逗号分隔）
        ///</summary>
         [SugarColumn(ColumnName="DoctorName"  )]
         public string DoctorName{ get; set; }
    }
}
