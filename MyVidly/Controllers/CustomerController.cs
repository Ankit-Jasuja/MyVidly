using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyVidly.Models;

namespace MyVidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().FirstOrDefault(x => x.Id == id);
            return View(customer);
        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>{ new Customer {Id = 1,Name = "Raju"},new Customer{ Id = 5, Name = "Ramesh" } };
        }
    }
}