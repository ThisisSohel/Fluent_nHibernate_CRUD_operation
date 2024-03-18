using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using studentBasicInfo.Models;

namespace studentBasicInfo.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;

        public StudentController()
        {
            _studentRepository = new StudentRepository();
        }

        public ActionResult Index()
        {
            var students = _studentRepository.GetAllStudents();
            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.AddStudent(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = _studentRepository.GetStudentById(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = _studentRepository.GetStudentById(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student != null)
            {
                _studentRepository.DeleteStudent(student);
            }
            return RedirectToAction("Index");
        }
    }
}
