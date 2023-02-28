using Ajax_Crud_App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Ajax_Crud_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<StudentModel> students = new List<StudentModel>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            students = new List<StudentModel>();
            students.Add(new StudentModel() { Id = 1, Email = "ankush1802@outlook.com", Name = "Ankush" });
            students.Add(new StudentModel() { Id = 2, Email = "rohit@outlook.com", Name = "Rohit" });
            students.Add(new StudentModel() { Id = 3, Email = "sunny@outlook.com", Name = "Sunny" });
            students.Add(new StudentModel() { Id = 4, Email = "amit@outlook.com", Name = "Amit" });
        }

        public IActionResult Index()
        {
            return View(students);
        }

        [HttpGet]
        public JsonResult GetDetailsById(int id)
        {
            var student = students.Where(d => d.Id.Equals(id)).FirstOrDefault();
            JsonResponseViewModel model = new JsonResponseViewModel();
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }

        [HttpPost]
        public JsonResult InsertStudent(IFormCollection formCollection)
        {
            StudentModel student = new StudentModel();
            student.Email = formCollection["email"].ToString();
            student.Name = formCollection["name"].ToString();

            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL AND HANDLE THE RESPONSE
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }

        [HttpPut]

        public JsonResult UpdateStudent(IFormCollection formCollection)
        {
            StudentModel student = new StudentModel();
            student.Id = int.Parse(formCollection["id"].ToString());
            student.Email = formCollection["email"].ToString();
            student.Name = formCollection["name"].ToString();

            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL AND HANDLE THE RESPONSE
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }

        [HttpDelete]
        public JsonResult DeleteStudent(IFormCollection formCollection)
        {
            StudentModel student = new StudentModel();
            student.Id = int.Parse(formCollection["id"]);

            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL AND HANDLE THE RESPONSE
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
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
    }
}