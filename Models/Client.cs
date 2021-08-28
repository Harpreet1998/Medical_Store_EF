using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_Store_EF.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }
        [Required]
        public string Address { get; set; }
        public string City { get; set; }
    }
}
