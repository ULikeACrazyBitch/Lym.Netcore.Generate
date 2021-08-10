using System;
using System.Collections.Generic;
using System.Text;

namespace Lym.Application.Dto.Generate
{
    public class GenerateDto
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 项目类型名称
        /// </summary>
        public string ProjectType { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DatabaseName { get; set; }
        /// <summary>
        /// 数据库文件名称（大写）
        /// </summary>
        public string DatabaseFileName { get; set; }
        /// <summary>
        /// 数据库表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 数据库表字段信息
        /// </summary> 
        public List<PropertyGens> PropertyGenList { get; set; }

    }

    public class PropertyGens
    {
        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string DbColumnName { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 是否为自增长
        /// </summary>
        public bool IsIdentity { get; set; }
        /// <summary>
        /// 不能为空
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// 无
        /// </summary>
        public object CodeTableId { get; set; } 
        /// <summary>
        /// class类属性名称
        /// </summary>
        public string ClassProperName { get; set; }
    }
}
