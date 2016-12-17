using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ServiceCRM.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
namespace ServiceCRM.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        } 

        public ActionResult List()
        {
            var id = this.User.Identity.GetUserId();       
            var customers = _context.Customers.Where(c=> c.IdUser == id).ToList();
            return View(customers);
        }

        public ActionResult Create()
        {
            var id = this.User.Identity.GetUserId();
            Customer customer = new Models.Customer();
            customer.IdUser =   id;
            return View("CustomerForm",customer);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            } else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.Company = customer.Company;
                customerInDb.Address = customer.Address;
                customerInDb.City = customer.City;
                customerInDb.State = customer.State;
                customerInDb.PostalCode = customer.PostalCode;
                customerInDb.Email = customer.Email;
                customerInDb.Phone = customer.Phone;

            }
            _context.SaveChanges();
            return RedirectToAction("List", "Customer");
        }
        [HttpGet]
        public ActionResult QuickActivity(int IdCustomer)
        {
            var id = this.User.Identity.GetUserId();
            var CustomerList = _context.Customers.Where(c => c.IdUser ==id).ToList();
            List<Status> status = new List<Status>();
            status.Add(new Status { Text = "Schedule", Value = "Schedule" });
            status.Add(new Status { Text = "Pending", Value = "Pending" });
            status.Add(new Status { Text = "In Progress", Value = "In Progress" });
            status.Add(new Status { Text = "Completed", Value = "Completed" });

            List<ActivityType> activitytype = new List<ActivityType>();
            activitytype.Add(new ActivityType { Text = "Call", Value = "Call" });
            activitytype.Add(new ActivityType { Text = "Appointment", Value = "Appointment" });
            activitytype.Add(new ActivityType { Text = "Email", Value = "Email" });

            Activity activity = new Models.Activity();
            activity.IdUser = id;
            activity.IdCustomer = IdCustomer;
            var CreateModel = new NewActivityModel
            {
                Customers = CustomerList,
                Status = status,
                ActivityType = activitytype,
                Activity = activity
            };
            return PartialView("ActivityForm", CreateModel);
        }

        [HttpPost]
        public ActionResult SaveActivity(Activity activity)
        {
            try
            {
               
                _context.Activities.Add(activity);
                _context.SaveChanges();
                return RedirectToAction("List", "Customer");

            }
            catch
            {
                return RedirectToAction("List", "Customer");
            }
        }

        public ActionResult Edit(int id)
        {
           var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
 
            return View("CustomerForm", customer);
        }
       

    }
}
