using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Model.Entity.SdtQueuesystem
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("sdt_queuesystem.patientwait")]
    public class Patientwait
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true )]
         public Guid Id{ get; set; }
        /// <summary>
        /// 接口地址
        ///</summary>
         [SugarColumn(ColumnName="RoomName"  )]
         public string RoomName{ get; set; }
        /// <summary>
        /// 医生表中DocId
        ///</summary>
         [SugarColumn(ColumnName="DoctorId"  )]
         public string DoctorId{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Name"  )]
         public string Name{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Visiting"  )]
         public string Visiting{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="WaitQueue"  )]
         public string WaitQueue{ get; set; }
        /// <summary>
        /// 1：生效  2：待生效   -99已失效
        ///</summary>
         [SugarColumn(ColumnName="State"  )]
         public int State{ get; set; }
        /// <summary>
        /// 创建时间
        ///</summary>
         [SugarColumn(ColumnName="CreateTime"  )]
         public DateTime CreateTime{ get; set; }
    }
}
