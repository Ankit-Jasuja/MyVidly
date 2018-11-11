using System.Data.Entity;
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

            var customers = Context.Customers.Include(c=>c.MembershipType).ToList(); //query will be executed immediately

            //by default:only customer object is loaded,their relative types are not loaded meaning MemberShip Type object is not loaded and hence it is null.
            //So we want to load customers and membershipType together,this is called eager loading.(this is why we used include keyword here)
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = Context.Customers.Include(c => c.MembershipType).FirstOrDefault(x => x.Id == id);
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = Context.MembershipTypes.ToList();
            var customerViewModel = new CustomerViewModel
            {
                MembershipTypes = membershipTypes,
            };
            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            Context.Customers.Add(customer);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}