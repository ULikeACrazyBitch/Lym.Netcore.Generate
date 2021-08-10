using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Model.Entity.SdtQueuesystem
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("sdt_queuesystem.doctorinfo")]
    public class Doctorinfo
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true )]
         public Guid Id{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="DocId"  )]
         public string DocId{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Name"  )]
         public string Name{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Sex"  )]
         public string Sex{ get; set; }
        /// <summary>
        /// 医生职称
        ///</summary>
         [SugarColumn(ColumnName="JobTitle"  )]
         public string JobTitle{ get; set; }
        /// <summary>
        /// 职称编号
        ///</summary>
         [SugarColumn(ColumnName="JobNumber"  )]
         public string JobNumber{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="ComputerIP"  )]
         public string ComputerIP{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Photo"  )]
         public string Photo{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="ClinicId"  )]
         public string ClinicId{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="ClinicName"  )]
         public string ClinicName{ get; set; }
        /// <summary>
        /// 科室ID
        ///</summary>
         [SugarColumn(ColumnName="UnitId"  )]
         public string UnitId{ get; set; }
        /// <summary>
        /// 科室名称
        ///</summary>
         [SugarColumn(ColumnName="UnitName"  )]
         public string UnitName{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="RoomName"  )]
         public string RoomName{ get; set; }
        /// <summary>
        /// 创建时间
        ///</summary>
         [SugarColumn(ColumnName="CreateTime"  )]
         public DateTime CreateTime{ get; set; }
        /// <summary>
        /// 图片的URL
        ///</summary>
         [SugarColumn(ColumnName="DoctorIMG"  )]
         public string DoctorIMG{ get; set; }
        /// <summary>
        /// 状态 1启用 0禁用
        ///</summary>
         [SugarColumn(ColumnName="State"  )]
         public string State{ get; set; }
    }
}
