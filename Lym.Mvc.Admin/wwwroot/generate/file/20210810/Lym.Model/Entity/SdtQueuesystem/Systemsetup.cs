using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Model.Entity.SdtQueuesystem
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("sdt_queuesystem.systemsetup")]
    public class Systemsetup
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true )]
         public Guid Id{ get; set; }
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
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Logo"  )]
         public string Logo{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="MessageContent"  )]
         public string MessageContent{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="DeviceType"  )]
         public string DeviceType{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="ClassType"  )]
         public string ClassType{ get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Interval"  )]
         public string Interval{ get; set; }
        /// <summary>
        /// 创建时间
        ///</summary>
         [SugarColumn(ColumnName="CreateTime"  )]
         public DateTime CreateTime{ get; set; }
        /// <summary>
        /// 医院的Logo图片URL 候诊列表专用
        ///</summary>
         [SugarColumn(ColumnName="HospitalLogoURL"  )]
         public string HospitalLogoURL{ get; set; }
        /// <summary>
        /// 在诊室门口专用
        ///</summary>
         [SugarColumn(ColumnName="HospitalLogoURL1"  )]
         public string HospitalLogoURL1{ get; set; }
    }
}
