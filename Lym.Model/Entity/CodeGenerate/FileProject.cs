using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Models.Entity.Codegenerate
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Codegenerate.file_project")]
    public class FileProject
    {
        /// <summary>
        /// 项目Id
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true)]
         public int Id { get; set; }
        /// <summary>
        /// 项目名称
        ///</summary>
         [SugarColumn(ColumnName="ProjectName"  )]
         public string ProjectName { get; set; }
    }
}
