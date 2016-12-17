namespace ServiceCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public int? IdCustomer { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Activity Type")]
        public string ActivityType { get; set; }

        [Column(TypeName = "Date")]
        [Display(Name = "Due On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DueDate { get; set; }

        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [StringLength(254)]     
        public string Status { get; set; }

        [Column(TypeName = "Date")]
        [Display(Name = "Completed Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CompletedOn { get; set; }

        [Required]
        [StringLength(254)]
        public string  IdUser { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] CreatedOn { get; set; }
    }
}
