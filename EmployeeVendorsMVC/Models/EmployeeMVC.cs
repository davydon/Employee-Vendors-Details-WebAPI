using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeVendorsMVC.Models
{
    public class EmployeeMVC
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string OtherName { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string D_O_B { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string ResumptionDate { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Salary { get; set; }
    }
}