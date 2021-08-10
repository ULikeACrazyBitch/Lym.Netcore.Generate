using Lym.Business.CodeGenerate;
using Lym.Models.Entity.Codegenerate;
using Lym.Respository.Interface.CodeGenerate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lym.Mvc.Admin.Controllers
{
    public class FileProjectController : Controller
    {
        private readonly FileProjectBusiness _projectBusiness;
        private readonly IFileProjectRepository _projectRepository;
        public FileProjectController(FileProjectBusiness projectBusiness, IFileProjectRepository projectRepository)
        {
            _projectBusiness = projectBusiness;
            _projectRepository = projectRepository;
        }
        public IActionResult List()
        {
            return View();
        }


        public IActionResult GetProjectList(string projectname)
        {
            var result = _projectBusiness.GetDatabasePageList(projectname);
            return Json(result);

        }

        public IActionResult Add()
        { 
            return View();
        }

        public IActionResult Save(FileProject project)
        {
            if (project.Id == 0)
            { 
                _projectRepository.Add(project);
            }
            else
            {
                _projectRepository.Update(project);
            }

            return Json(new
            {
                code = 0,
                msg = "成功"
            });
        }

        public IActionResult Edit(int id)
        {
           
            var project = _projectRepository.GetId(id);
            ViewBag.project = project;
            return View();
        }

        public IActionResult Del(int id)
        {
            _projectRepository.Delete(id);

            return Json(new
            {
                code = 0,
                msg = "成功"
            });
        }
    }
}
