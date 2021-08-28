using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_Store_EF.Models
{
    public class Stock_Order
    {

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int StockId { get; set; }
        public Stock Stock { get; set; }

        public int Quantity { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
    }
}
