using Microsoft.AspNetCore.Mvc;
using myproject.Models; 
using myproject.ViewModels; 

namespace StudentMVC.Controllers
{
    public class StudentController : Controller
    {
        // Temporary storage for submitted information.
        private static List<StudentCourseViewModel> studentCourses = new();

        // GET: /Student/Index //http://localhost:port/ , http://localhost:port/student
        // Displays the submitted students and courses.
        public IActionResult Index()  
        {
            return View(studentCourses);
        }

        // GET: http://loclahost:port/student/create
        // Displays the Create form.
        [HttpGet]
        public IActionResult Create() //http
        {
            return View();
        }

        // POST: http://loclahost:port/student/create
        // Receives the submitted form information.
        [HttpPost]
        public IActionResult Create(StudentCreateViewModel viewModel)
        {
            // Check the validation rules.
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Create a Student Model from the ViewModel.
            var student = new Student
            {
                Id = studentCourses.Count + 1,
                Name = viewModel.Name,
                Program = viewModel.Program
            };

            // Create a Course Model from the ViewModel.
            var course = new Course
            {
                Id = studentCourses.Count + 1,
                CourseCode = viewModel.CourseCode,
                CourseName = viewModel.CourseName,
                Instructor = viewModel.Instructor
            };

            // Combine the Student and Course Models
            // into a ViewModel for the Index View.
            var studentCourse = new StudentCourseViewModel
            {
                Student = student,
                Course = course,
                EnrollmentDate = viewModel.EnrollmentDate
            };

            // Store the combined information temporarily.
            studentCourses.Add(studentCourse);

            // Return to the Index page.
            return RedirectToAction("Index");
        }
    }
}