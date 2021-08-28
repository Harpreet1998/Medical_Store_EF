using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_Store_EF.Models
{
    public class Stock
    {
        public int Id { get; set; }
        [Required]
        public string Item_Name { get; set; }
        public string Item_detail { get; set; }
        public Decimal Price { get; set; }
       public int Quantity { get; set; }
       
        








    }
}
