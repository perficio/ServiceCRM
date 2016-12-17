using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ServiceCRM.Models;
 

namespace ServiceCRM.Controllers.Api
{
    public class ActivitiesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Activities
        public IQueryable<ActivityViewModel> GetActivities()
        {
            IQueryable<ActivityViewModel > activities = (from activity in db.Activities
                              join customer in db.Customers
                              on activity.IdCustomer equals customer.Id
                              select new ActivityViewModel
                              {
                                  Id = activity.Id,
                                  CustomerName = customer.Company,
                                  FullName = customer.FirstName + " " + customer.LastName,
                                  ActivityType = activity.ActivityType,
                                  DueDate = activity.DueDate,
                                  Status = activity.Status,
                                  CompletedOn = activity.CompletedOn

                              });
            return activities;
        }

        // GET: api/Activities/5
        [ResponseType(typeof(Activity))]
        public IHttpActionResult GetActivity(int id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // PUT: api/Activities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActivity(int id, Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activity.Id)
            {
                return BadRequest();
            }

            db.Entry(activity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Activities
        [ResponseType(typeof(Activity))]
        public IHttpActionResult PostActivity(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Activities.Add(activity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = activity.Id }, activity);
        }

        // DELETE: api/Activities/5
        [ResponseType(typeof(Activity))]
        public IHttpActionResult DeleteActivity(int id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            db.Activities.Remove(activity);
            db.SaveChanges();

            return Ok(activity);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteAllActivity(int id)
        {
           var activities = db.Activities.Where(a=> a.IdCustomer == id);
            if (activities == null)
            {
                return NotFound();
            }

            db.Activities.RemoveRange(activities);
            db.SaveChanges();

            return Ok(activities);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityExists(int id)
        {
            return db.Activities.Count(e => e.Id == id) > 0;
        }
    }
}