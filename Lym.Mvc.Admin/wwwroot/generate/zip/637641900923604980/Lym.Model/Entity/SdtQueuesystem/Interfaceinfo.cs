using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Model.Entity.SdtQueuesystem
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("sdt_queuesystem.interfaceinfo")]
    public class Interfaceinfo
    {
        /// <summary>
        /// 主键
        ///</summary>
         [SugarColumn(ColumnName="Id"  )]
         public Guid Id{ get; set; }
        /// <summary>
        /// 接口地址
        ///</summary>
         [SugarColumn(ColumnName="Address"  )]
         public string Address{ get; set; }
        /// <summary>
        /// 标识
        ///</summary>
         [SugarColumn(ColumnName="Code"  )]
         public string Code{ get; set; }
        /// <summary>
        /// 功能描述
        ///</summary>
         [SugarColumn(ColumnName="Describe"  )]
         public string Describe{ get; set; }
        /// <summary>
        /// 创建时间
        ///</summary>
         [SugarColumn(ColumnName="CreateTime"  )]
         public DateTime CreateTime{ get; set; }
    }
}
