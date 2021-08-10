using System;
using System.Collections.Generic;
using System.Text;

namespace Lym.Application.Dto.Generate
{
    public class FileTemplateDto
    { 
        public int Id { get; set; }
        /// <summary>
        /// 项目Id
        ///</summary>
        
        public int ProjectId { get; set; }
        /// <summary>
        /// 项目名称
        ///</summary> 
        public string ProjectName { get; set; }
        /// <summary>
        /// 项目类型
        ///</summary> 
        public string ProjectType { get; set; }
        /// <summary>
        /// 项目类型Id
        ///</summary> 
        public int ProjectTypeId { get; set; }
        /// <summary>
        /// 文件类型
        ///</summary> 
        public string FileType { get; set; }
        /// <summary>
        /// 文件类型Id
        ///</summary> 
        public int FileTypeId { get; set; }
        /// <summary>
        /// 上一级目录Id
        ///</summary> 
        public int UpperlevelDirectoryId { get; set; }
        /// <summary>
        /// 上一级目录名称
        ///</summary> 
        public string UpperlevelDirectoryName { get; set; }
        /// <summary>
        /// 文件名称
        ///</summary> 
        public string FileName { get; set; }
        /// <summary>
        /// 
        ///</summary> 
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 内容
        ///</summary> 
        public string Content { get; set; }
        /// <summary>
        /// 生成循环类型id
        ///</summary> 
        public int GenerateTypeId { get; set; }
        /// <summary>
        /// 使用数据库名称
        /// </summary>
        public string DatabaseName { get; set; }
        /// <summary>
        /// 数据库文件名称（大写）
        /// </summary>
        public string DatabaseFileName { get; set; }
        /// <summary>
        /// 文件类名
        /// </summary> 
        public string ClassName { get; set; }
        /// <summary>
        /// 数据库表名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 描述
        /// </summary> 
        public string Description { get; set; }
    }
}
