using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Medical_Store_EF.Data;
using Medical_Store_EF.Models;

namespace Medical_Store_EF.Pages.Order
{
    public class CreateModel : PageModel
    {
        private readonly Medical_Store_EF.Data.Medical_Store_EFContext _context;

        public CreateModel(Medical_Store_EF.Data.Medical_Store_EFContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Address");
        ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Name");
        ViewData["StockId"] = new SelectList(_context.Set<Stock>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Stock_Order Stock_Order { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Stock_Order.Add(Stock_Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
