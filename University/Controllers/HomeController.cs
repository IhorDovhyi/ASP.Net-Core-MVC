using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using University.Models;

namespace University.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            return View(_unitOfWork.GetRepository<Course>().GetAll());
        }
        public async Task<IActionResult> GroupsInCourse(int? id)
        {
            if (id != null)
            {
                return View(_unitOfWork.GetRepository<Group>().GetAll().Where(g => g.CourseId == id).ToList());
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> EditGroup(int? id)
        {
            if (id != null)
            {
                Group group = _unitOfWork.GetRepository<Group>().Get(id);
                if (group != null)
                    return View(group);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditGroup(Group group)
        {
            if (_unitOfWork.GetRepository<Course>().GetAll().Any(c => c.CourseId == group.CourseId))
            {
                _unitOfWork.GetRepository<Group>().Update(group);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> StudentsInGroups(int? id)
        {
            if (id != null)
            {
                return View(_unitOfWork.GetRepository<Student>().GetAll().Where(s => s.GroupId == id).ToList());
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> EditStudent(int? id)
        {
            if (id != null)
            {
                Student student = _unitOfWork.GetRepository<Student>().Get(id);
                if (student != null)
                    return View(student);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditStudent(Student student)
        {
            if (_unitOfWork.GetRepository<Course>().GetAll().Any(c => c.CourseId == student.GroupId))
            {
                _unitOfWork.GetRepository<Student>().Update(student);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("DeleteGroup")]
        public async Task<IActionResult> DeleteGroup(int? id)
        {
            if (id != null)
            {
                int numb = _unitOfWork.GetRepository<Student>().GetAll().Count(s => s.GroupId == id);
                if (numb != 0)
                    return Content("You cant delete group with students"); 
            }
            return NotFound();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
