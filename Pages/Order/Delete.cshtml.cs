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
    public class DeleteModel : PageModel
    {
        private readonly Medical_Store_EF.Data.Medical_Store_EFContext _context;

        public DeleteModel(Medical_Store_EF.Data.Medical_Store_EFContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stock_Order Stock_Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stock_Order = await _context.Stock_Order
                .Include(s => s.Client)
                .Include(s => s.Company)
                .Include(s => s.Stock).FirstOrDefaultAsync(m => m.Id == id);

            if (Stock_Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stock_Order = await _context.Stock_Order.FindAsync(id);

            if (Stock_Order != null)
            {
                _context.Stock_Order.Remove(Stock_Order);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
