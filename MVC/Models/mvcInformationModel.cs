using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcInformationModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Field is Required")]
        public string Name { get; set; }
        public string Position { get; set; }
        public string Age { get; set; }
        
        public string Salary { get; set; }
    }
}