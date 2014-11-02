using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace webtest.Models
{
    [MetadataType(typeof(CustomerModelMetadata))]
    public partial class customer
    {
    }

    public class CustomerModelMetadata
    {
        [Required]
        [Display(Name = "First Name")]
        public string firstname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string companyname { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [RegularExpression(@"\d{3}-\d{3}-\d{4}", ErrorMessage = "Invalid phone format.  Use ###-###-####")]
        public string phone { get; set; }

        [Display(Name = "Picture")]
        public byte[] picture { get; set; }

        [Required]
        [Display(Name = "Street")]
        public string street { get; set; }

        [Required]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required]
        [Display(Name = "State")]
        [StringLength(2, ErrorMessage = "Use the 2 charater state code.")]
        public string state { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Postal Code")]
        public string postalcode { get; set; }
    }
}