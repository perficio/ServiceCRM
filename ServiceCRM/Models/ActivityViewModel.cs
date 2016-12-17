using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceCRM.Models
{
    public class ActivityViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string FullName { get; set; }
        public string ActivityType { get; set; }
        public DateTime? DueDate {get; set;} 
        public string Status { get; set; }
        public DateTime? CompletedOn { get; set; }
     
    }
}