using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Medical_Store_EF.Data;
using Medical_Store_EF.Models;

namespace Medical_Store_EF.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly Medical_Store_EF.Data.Medical_Store_EFContext _context;

        public IndexModel(Medical_Store_EF.Data.Medical_Store_EFContext context)
        {
            _context = context;
        }

        public IList<Stock_Order> Stock_Order { get;set; }

        public async Task OnGetAsync()
        {
            Stock_Order = await _context.Stock_Order
                .Include(s => s.Client)
                .Include(s => s.Company)
                .Include(s => s.Stock).ToListAsync();
        }
    }
}
