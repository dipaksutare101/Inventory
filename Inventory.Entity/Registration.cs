using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory.Entity
{
    public class Registration
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        
        public string Gender { get; set; }

        public int cityid { get; set; }

        public string cityname { get; set; }
        public Boolean isstudent { get; set; }
    }
}