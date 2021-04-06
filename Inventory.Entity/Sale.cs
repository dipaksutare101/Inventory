using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory.Entity
{
    public class Sale
    {
        [Key]
        public int Saleid { get; set; }
        [Required]
        public int Customerid { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public DateTime? Saledate { get; set; }
        [Required]
        [RegularExpression("[0-9]{1,3}",ErrorMessage ="SaleNo must be Numeric and Minum 1 to 3 digit")]
        public int SaleNo { get; set; }
        public string Remark { get; set; }
        public decimal Amount { get; set; }


    }

    public class Saledetail
    {
        public int Saledetailid { get; set; }
        public int Saleid { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public int Rate { get; set; }
        public decimal Amount { get; set; }
    }
}