using Microsoft.AspNet.Identity;
using ServiceCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceCRM.Controllers
{
    public class ActivityController : Controller
    {

        private ApplicationDbContext _context;

        public ActivityController()
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
            ViewBag.CustomerCount = _context.Customers.Where(c => c.IdUser == id).Count();
            var activities = (from activity in _context.Activities
                                join customer in _context.Customers
                                on activity.IdCustomer equals customer.Id
                              where activity.IdUser == id
                                select new ActivityViewModel
                                {
                                    Id = activity.Id,
                                    CustomerName = customer.Company,
                                    FullName = customer.FirstName +  " " + customer.LastName,
                                    ActivityType = activity.ActivityType,
                                    DueDate = activity.DueDate,
                                    Status = activity.Status,
                                    CompletedOn = activity.CompletedOn
                                }).ToList();  
         
             
            return View(activities);
        }

         
 
        public ActionResult Create()
        {
            var id = this.User.Identity.GetUserId();
            var CustomerList = _context.Customers.Where(c=> c.IdUser == id).ToList();
            List<Status> status = new List<Status>();

            status.Add(new Status { Text = "Schedule", Value = "Schedule" });

            status.Add(new Status { Text = "Pending", Value = "Pending" });

            status.Add(new Status { Text = "In Progress", Value = "In Progress"});

            status.Add(new Status { Text = "Completed", Value = "Completed" });

            List<ActivityType> activitytype = new List<ActivityType>();

            activitytype.Add(new ActivityType { Text = "Call", Value = "Call" });

            activitytype.Add(new ActivityType { Text = "Appointment", Value = "Appointment" });

            activitytype.Add(new ActivityType { Text = "Email", Value = "Email" });
 
            Activity activity = new Models.Activity();
            activity.IdUser = id;
            var CreateModel = new NewActivityModel
            {
                Customers = CustomerList,
                Status  = status,
                ActivityType = activitytype,
                Activity = activity
            };
            return View("ActivityForm",CreateModel);
        }

         
        [HttpPost]
        public ActionResult Save(Activity  activity)
        {
            try
            {
                if (activity.Id == 0)
                {
                    _context.Activities.Add(activity);
                }
                else
                {
                    var activityInDb = _context.Activities.Single(c => c.Id == activity.Id);
                    activityInDb.IdCustomer = activity.IdCustomer;
                    activityInDb.ActivityType = activity.ActivityType;
                    activityInDb.DueDate = activity.DueDate;
                    activityInDb.CompletedOn = activity.CompletedOn;
                    activityInDb.Status = activity.Status;
                    activityInDb.Notes = activity.Notes;
                }


                _context.SaveChanges();
                return RedirectToAction("List", "Activity");
 
            }
            catch
            {
                return RedirectToAction("List", "Activity");
            }
        }

         
        public ActionResult Edit(int id)
        {
            var idUser = this.User.Identity.GetUserId();
            var CustomerList = _context.Customers.Where(c => c.IdUser == idUser).ToList();
            List<Status> status = new List<Status>();
            status.Add(new Status { Text = "Schedule", Value = "Schedule" });
            status.Add(new Status { Text = "Pending", Value = "Pending" });
            status.Add(new Status { Text = "In Progress", Value = "In Progress" });
            status.Add(new Status { Text = "Completed", Value = "Completed" });

            List<ActivityType> activitytype = new List<ActivityType>();
            activitytype.Add(new ActivityType { Text = "Call", Value = "Call" });
            activitytype.Add(new ActivityType { Text = "Appointment", Value = "Appointment" });
            activitytype.Add(new ActivityType { Text = "Email", Value = "Email" });

            var activity = _context.Activities.SingleOrDefault(c => c.Id == id);
            if (activity == null)
                return HttpNotFound();
            var EditModel = new NewActivityModel
            {
                Customers = CustomerList,
                Status = status,
                ActivityType = activitytype,
                Activity = activity
            };

            return View("ActivityForm", EditModel);
        }

        
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

         
        public ActionResult Delete(int id)
        {
            return View();
        }

         
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
