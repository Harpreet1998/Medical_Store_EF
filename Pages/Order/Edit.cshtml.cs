using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medical_Store_EF.Data;
using Medical_Store_EF.Models;

namespace Medical_Store_EF.Pages.Order
{
    public class EditModel : PageModel
    {
        private readonly Medical_Store_EF.Data.Medical_Store_EFContext _context;

        public EditModel(Medical_Store_EF.Data.Medical_Store_EFContext context)
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
           ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Address");
           ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Name");
           ViewData["StockId"] = new SelectList(_context.Set<Stock>(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Stock_Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Stock_OrderExists(Stock_Order.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Stock_OrderExists(int id)
        {
            return _context.Stock_Order.Any(e => e.Id == id);
        }
    }
}
