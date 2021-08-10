using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Model.Entity.SdtQueuesystem
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("sdt_queuesystem.unitinfo")]
    public class Unitinfo
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true )]
         public Guid Id{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="UnitId"  )]
         public string UnitId{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="UnitName"  )]
         public string UnitName{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="ClinicId"  )]
         public string ClinicId{ get; set; }
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
    }
}
