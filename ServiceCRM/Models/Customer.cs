using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServiceCRM.Models
{

   

    public partial class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name ="First Name") ]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(254)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [StringLength(20)]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [StringLength(80)]
        public string Company { get; set; }

        [StringLength(80)]
        public string Address { get; set; }

        [StringLength(80)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [StringLength(20)]
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(128)]
        public string IdUser { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] CreatedOn { get; set; }
    }
}
