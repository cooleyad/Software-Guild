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
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);
            }
            else
            {
                var viewModel = new StudentVM();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
            }

                
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult EditStudent(int studentId)
        {

            var viewStudent = new StudentVM();

            viewStudent.Student = StudentRepository.Get(studentId);
            viewStudent.SetCourseItems(CourseRepository.GetAll());
            viewStudent.SetMajorItems(MajorRepository.GetAll());
            viewStudent.SetStateItems(StateRepository.GetAll());

            if (!(viewStudent.Student.Courses == null))
            {
                viewStudent.SelectedCourseIds = viewStudent.Student.Courses.Select(s => s.CourseId).ToList();
            }

            return View(viewStudent);
        }
        [HttpPost]
        public ActionResult EditStudent(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
                StudentRepository.Edit(studentVM.Student);
                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                studentVM.SetStateItems(StateRepository.GetAll());
                if (!(studentVM.Student.Courses == null))
                {
                    studentVM.SelectedCourseIds = studentVM.Student.Courses.Select(s => s.CourseId).ToList();
                }
                return View(studentVM);
            }
        }

        [HttpGet]

        public ActionResult DeleteStudent(int studentId)
        {
            var model = StudentRepository.Get(studentId);   

            return View(model);
        }
        [HttpPost]
        [ActionName("DeleteStudent")]
        public ActionResult DeleteMoreStudents(int studentId)
        {
            StudentRepository.Delete(studentId);
            return RedirectToAction("List");

        }
    }
}