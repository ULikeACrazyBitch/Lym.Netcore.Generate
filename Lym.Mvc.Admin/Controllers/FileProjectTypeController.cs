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
    public class FileProjectTypeController : Controller
    {
        private readonly IFileProjectRepository _fileProjectRepository;
        private readonly IFileProjectTypeRepository _fileProjectTypeRepository;
        private readonly FileProjectTypeBusiness _fileProjectTypeBusiness;
        public FileProjectTypeController(IFileProjectTypeRepository fileProjectTypeRepository, FileProjectTypeBusiness fileProjectTypeBusiness, IFileProjectRepository fileProjectRepository)
        {
            _fileProjectTypeRepository = fileProjectTypeRepository;
            _fileProjectTypeBusiness = fileProjectTypeBusiness;
            _fileProjectRepository = fileProjectRepository;
        }
        public IActionResult List()
        {
            var fileProjects = _fileProjectRepository.GetAll();
            ViewBag.fileProjects = fileProjects;
            return View();
        }


        public IActionResult GetProjectList(int page, int limit, int projectId, string projectTypeName)
        {
            var result = _fileProjectTypeBusiness.GetDatabasePageList(page, limit, projectId, projectTypeName);
            return Json(result);

        }

        public IActionResult Add()
        {
            var fileProjects = _fileProjectRepository.GetAll();
            ViewBag.fileProjects = fileProjects;

            return View();
        }

        public IActionResult Save(FileProjecttype fileProjecttype)
        {
            if (fileProjecttype.Id == 0)
            {
                _fileProjectTypeRepository.Add(fileProjecttype);
            }
            else
            {
                _fileProjectTypeRepository.Update(fileProjecttype);
            }

            return Json(new
            {
                code = 0,
                msg = "成功"
            });
        }

        public IActionResult Edit(int id)
        {
            var fileProjects = _fileProjectRepository.GetAll();
            ViewBag.fileProjects = fileProjects;
            var projecttype = _fileProjectTypeRepository.GetId(id);
            ViewBag.projecttype = projecttype;
            return View();
        }

        public IActionResult Del(int id)
        {
            _fileProjectTypeRepository.Delete(id);

            return Json(new
            {
                code = 0,
                msg = "成功"
            });
        }
    }
}
