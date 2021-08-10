using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Model.Entity.SdtQueuesystem
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("sdt_queuesystem.unittitle")]
    public class Unittitle
    {
        /// <summary>
        /// 主键
        ///</summary>
         [SugarColumn(ColumnName="id" ,IsPrimaryKey = true )]
         public string Id{ get; set; }
        /// <summary>
        /// 职称ID
        ///</summary>
         [SugarColumn(ColumnName="UnitTitleId"  )]
         public string UnitTitleId{ get; set; }
        /// <summary>
        /// 职称名称
        ///</summary>
         [SugarColumn(ColumnName="UnitTitleName"  )]
         public string UnitTitleName{ get; set; }
        /// <summary>
        /// 状态 1启用 0禁用
        ///</summary>
         [SugarColumn(ColumnName="State"  )]
         public string State{ get; set; }
        /// <summary>
        /// 创建时间
        ///</summary>
         [SugarColumn(ColumnName="CreateTime"  )]
         public DateTime CreateTime{ get; set; }
    }
}
