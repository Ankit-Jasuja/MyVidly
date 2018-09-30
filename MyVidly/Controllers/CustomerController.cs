using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyVidly.Models;

namespace MyVidly.Controllers
{
    public class CustomerController : Controller
    {
        public ApplicationDbContext Context { get; set; }
        public CustomerController()
        {
            Context = new ApplicationDbContext();
        }
        
        // GET: Customer
        public ActionResult Index()
        {
            // var customers = Context.Customers;//when this line is executed,entity framework is not going to query the data base,this is called defered execution
            //the query is executed when we iterate over customers object
            //this means query will not be executed immediately.

            var customers = Context.Customers.ToList(); //query will be executed immediately
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = Context.Customers.FirstOrDefault(x => x.Id == id);
            return View(customer);
        }

        private List<Customer> GetCustomers()
        {
             return new List<Customer>{ new Customer {Id = 1,Name = "Raju"},new Customer{ Id = 5, Name = "Ramesh" } };
        }
    }
}