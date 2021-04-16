using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entity
{
    public class Image_Table
    {
        [Key]
        public int id { get; set; }
        public string Title { get; set; }
        public string image { get; set; }
    }
}
