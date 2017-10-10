using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult EditStudent(int studentId)
        {
            var student = StudentRepository.Get(studentId);

            StudentVM studentVm = new StudentVM();

            studentVm.Student = student;
            studentVm.SelectedCourseIds = student.Courses.Select(c => c.CourseId).ToList();
            studentVm.SetCourseItems(CourseRepository.GetAll());
            studentVm.SetMajorItems(MajorRepository.GetAll());
            studentVm.SetStateItems(StateRepository.GetAll());

            return View(studentVm);
        }
        [HttpPost]
        public ActionResult EditStudent(StudentVM student)
        {
            if (ModelState.IsValid)
            {
                StudentRepository.Edit(student.Student);
            }
            else
            {
                return View(student);
            }
            return RedirectToAction("List");
        }

        [HttpGet]

        public ActionResult DeleteStudent (int studentId)
        {
            var model = StudentRepository.Get(studentId);

            return View(model);
        }
        [HttpPost]
        [ActionName("DeleteStudent")]
        public ActionResult DeleteMoreStudents (int studentId)
        {
            StudentRepository.Delete(studentId);
            return RedirectToAction("List");

        }
    }
}