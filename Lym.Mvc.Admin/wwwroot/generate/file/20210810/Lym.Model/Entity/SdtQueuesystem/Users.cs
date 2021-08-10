using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Model.Entity.SdtQueuesystem
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("sdt_queuesystem.users")]
    public class Users
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true )]
         public string Id{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Account"  )]
         public string Account{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Password"  )]
         public string Password{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="State"  )]
         public string State{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Remark"  )]
         public string Remark{ get; set; }
        /// <summary>
        /// 创建时间
        ///</summary>
         [SugarColumn(ColumnName="CreateTime"  )]
         public DateTime CreateTime{ get; set; }
    }
}
