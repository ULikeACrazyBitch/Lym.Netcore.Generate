using Lym.Business.CodeGenerate;
using Lym.Model.ApiResult;
using Lym.Models.Entity.Codegenerate;
using Lym.Mvc.Admin.Tools;
using Lym.Respository.Interface.CodeGenerate;
using Lym.Respository.Service.CodeGenerate;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lym.Mvc.Admin.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly DatabaseBusiness _databaseBusiness;
        private readonly IDatabaseRepository _databaseRespository;
        public DatabaseController(DatabaseBusiness databaseBusiness, IDatabaseRepository databaseRespository)
        {
            _databaseBusiness = databaseBusiness;
            _databaseRespository = databaseRespository;
        }
        public IActionResult List()
        {
            return View();
        }


        public IActionResult GetDatabaseList(string projectname)
        { 
            var result = _databaseBusiness.GetDatabasePageList(projectname);
            return Json(result);

        }

        public IActionResult Add()
        {
            List<SqlSugarDbType> sqlSugarDbTypeList = new List<SqlSugarDbType>();
            foreach (DbType type in Enum.GetValues(typeof(DbType)))
            {
                SqlSugarDbType sqlSugarDbType = new SqlSugarDbType()
                {
                    Id = ((int)type),
                    Title = type.ToString(),

                };
                sqlSugarDbTypeList.Add(sqlSugarDbType);
            }

            ViewBag.SqlSugarDbTypeList = sqlSugarDbTypeList;
            return View();
        }

        public IActionResult Save(Database database)
        {
            if (database.Id == 0)
            {
                database.IsDeleted = false;
                database.ChangeTime = DateTime.Now;
                _databaseRespository.Add(database);
            }
            else
            {
                database.ChangeTime = DateTime.Now;
                _databaseRespository.Update(database);
            }

            return Json(new
            {
                code = 0,
                msg = "成功"
            });
        }

        public IActionResult Edit(int id)
        {
            List<SqlSugarDbType> sqlSugarDbTypeList = new List<SqlSugarDbType>();
            foreach (DbType type in Enum.GetValues(typeof(DbType)))
            {
                SqlSugarDbType sqlSugarDbType = new SqlSugarDbType()
                {
                    Id = ((int)type),
                    Title = type.ToString(),

                };
                sqlSugarDbTypeList.Add(sqlSugarDbType);
            }

            ViewBag.SqlSugarDbTypeList = sqlSugarDbTypeList;
            var database = _databaseRespository.GetId(id);
            ViewBag.database = database;
            return View();
        }

        public IActionResult Del(int id)
        {
            _databaseRespository.Delete(id);

            return Json(new
            {
                code = 0,
                msg = "成功"
            });
        }

    }

}
