using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Models.Entity.Codegenerate
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Codegenerate.file_template")]
    public class FileTemplate
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true)]
         public int Id { get; set; }
        /// <summary>
        /// 项目Id
        ///</summary>
         [SugarColumn(ColumnName="ProjectId"  )]
         public int ProjectId { get; set; }
        /// <summary>
        /// 项目名称
        ///</summary>
         [SugarColumn(ColumnName="ProjectName"  )]
         public string ProjectName { get; set; }
        /// <summary>
        /// 项目类型
        ///</summary>
         [SugarColumn(ColumnName="ProjectType"  )]
         public string ProjectType { get; set; }
        /// <summary>
        /// 项目类型Id
        ///</summary>
         [SugarColumn(ColumnName="ProjectTypeId"  )]
         public int ProjectTypeId { get; set; }
        /// <summary>
        /// 文件类型
        ///</summary>
         [SugarColumn(ColumnName="FileType"  )]
         public string FileType { get; set; }
        /// <summary>
        /// 文件类型Id
        ///</summary>
         [SugarColumn(ColumnName="FileTypeId"  )]
         public int FileTypeId { get; set; }
        /// <summary>
        /// 上一级目录Id
        ///</summary>
         [SugarColumn(ColumnName="UpperlevelDirectoryId"  )]
         public int UpperlevelDirectoryId { get; set; }
        /// <summary>
        /// 上一级目录名称
        ///</summary>
         [SugarColumn(ColumnName="UpperlevelDirectoryName"  )]
         public string UpperlevelDirectoryName { get; set; }
        /// <summary>
        /// 文件名称
        ///</summary>
         [SugarColumn(ColumnName="FileName"  )]
         public string FileName { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="IsDeleted"  )]
         public bool IsDeleted { get; set; }
        /// <summary>
        /// 内容
        ///</summary>
         [SugarColumn(ColumnName="Content"  )]
         public string Content { get; set; }
        /// <summary>
        /// 生成循环类型id
        ///</summary>
        [SugarColumn(ColumnName = "GenerateTypeId")]
        public int GenerateTypeId { get; set; }
    }
}
