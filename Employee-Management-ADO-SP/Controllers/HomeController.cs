using Employee_Management_ADO_SP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Employee_Management_ADO_SP.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly EmployeeDataAccessLayer _dal;

        public HomeController()
        {
            _dal = new EmployeeDataAccessLayer();
        }

        // Read Operation
        public IActionResult Index()
        {
            List<Employees> emps = _dal.getAllEmployees();
            return View(emps);
        }


        // Create Operation Form View. By Default this is HttpGet Method
        public IActionResult Create()
        {
            return View();
        }


        // Create Operation Data POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employees emp)
        {
            try
            {
                _dal.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //throw ex;
                return View();
            }
        }


        // Edit Operation Form View.
        public IActionResult Edit(int id)
        {
            Employees emp = _dal.getEmployeeByID(id);
            return View(emp);
        }


        // Edit Operation Data POST.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employees emp)
        {
            try
            {
                _dal.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //throw ex;
                return View();
            }
        }


        // Details Operation Form View.
        public IActionResult Details(int id)
        {
            Employees emp = _dal.getEmployeeByID(id);
            return View(emp);
        }


        // Delete Operation Form View.
        public IActionResult Delete(int id)
        {
            Employees emp = _dal.getEmployeeByID(id);
            return View(emp);
        }


        // Delete Operation Data POST.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employees emp)
        {
            try
            {
                _dal.DeleteEmployee(emp.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
                //return View();
            }
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
