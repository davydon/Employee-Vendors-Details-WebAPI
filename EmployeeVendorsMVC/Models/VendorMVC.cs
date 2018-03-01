using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeVendorsMVC.Models
{
    public class VendorMVC
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Field can't be empty")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Product { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string ContactPerson { get; set; }
    }
}