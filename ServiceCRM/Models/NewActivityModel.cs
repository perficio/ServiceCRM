using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceCRM.Models
{
    public class NewActivityModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public Activity Activity { get; set; }
        public List<Status> Status { get; set; }
        public List<ActivityType> ActivityType { get; set; }
    }
    public class Status
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public bool Checked { get; set; }

    }
    public class ActivityType
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public bool Checked { get; set; }

    }
}