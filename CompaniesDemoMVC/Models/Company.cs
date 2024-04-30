using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompaniesDemoMVC.Models
{
    public class Company
    {
        [Required]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]  
        public int Salary { get; set; }
    }
}