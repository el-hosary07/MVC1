using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using WeekTaskMVC.Data;
using WeekTaskMVC.Models;
using WeekTaskMVC.ViewModels;
using static Azure.Core.HttpHeader;

namespace WeekTaskMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AplicationDbContext _context = new AplicationDbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(FilterVM filterVM)
        {
            var doctors=_context.Doctors.AsQueryable();
            //ViewBag.doctors= doctors.ToList();
            ViewData["doctors"] = doctors.ToList();
            if (filterVM.DoctorName is not null ) 
            {
                doctors=doctors.Where(e=>e.Name.Contains(filterVM.DoctorName));
                
            }

            if (filterVM.Specialization is not null)
            {
                doctors = doctors.Where(e => e.Specialization.Contains(filterVM.Specialization));

            }
            return View(doctors.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BookAnAppoitment(int Id)
        {
            var app = _context.Doctors.FirstOrDefault(e=>e.Id == Id);

            return View(app);
        }
        [HttpPost]
        public IActionResult BookAnAppoitment(int DocId, string PatientName, DateOnly AppData, TimeOnly AppTime)
        {

            _context.Appointments.Add(new Appointment() {PatientName = PatientName, AppointmentDate = AppData, AppointmentTime = AppTime, DoctorId = DocId });
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        //[HttpPost]
        //public IActionResult BookAnAppoitment(int DocId, string PatientName, DateOnly AppData, TimeOnly AppTime)
        //{
        //    _context.Appointments.Add(new AppointmentVM() { CustomerName = PatientName,DoctorId=DocId ,AppointDate=AppData,AppointTime=AppTime,CustomerId=0};


        //    return View();
        //}

        public ViewResult PersonalInfo(string name , decimal salary )
        {
            List<Person> person = new List<Person>();
            person.AddRange(new Person
            {
                Id = 1,
                Name = "zaid",
                Address = "Giza",
                Salary = 100

            }, new Person
            {
                Id = 2,
                Name = "atef",
                Address = "Giza",
                Salary = 10000

            }, new Person
            {
                Id = 3,
                Name = "zaid",
                Address = "Giza",
                Salary = 1000

            });

            var persons =person.Where(e => e.Salary > salary && e.Name.Contains(name));

            var totalCount=persons.Count();

            return View(viewName: "PersonalInformation", new PersonVM
            {
               Persons = persons.ToList(),
                TotalCount = totalCount
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
