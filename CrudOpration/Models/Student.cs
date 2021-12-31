using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudOpration.Models
{
    public class Student
    {

        public int StdId { get; set; }

        //[Required(ErrorMessage = "Enter the name")]
        //[MaxLength(20, ErrorMessage = "Enter Maxium 20 character")]
        //[MinLength(4, ErrorMessage = "Enter Minimum 4 character")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Field can't be empty")]
        //// [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Enter the Adress")]
        //[MaxLength(20, ErrorMessage = "Enter Maxium 20 character")]
        //[MinLength(4, ErrorMessage = "Enter Minimum 4 character")]
        public string Address { get; set; }
        //[Required(ErrorMessage = " Mobile is required.")]
        public string Mobile { get; set; }
    }
}