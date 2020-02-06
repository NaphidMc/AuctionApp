using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleProjectAuctionApp.Data;
using SampleProjectAuctionApp.Models;

namespace SampleProjectAuctionApp.Pages.AuctionItems
{
    public class EditModel : PageModel
    {
        private readonly SampleProjectAuctionApp.Data.RazorPagesAuctionContext _context;

        public EditModel(SampleProjectAuctionApp.Data.RazorPagesAuctionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuctionItem AuctionItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AuctionItem = await _context.AuctionItem.FirstOrDefaultAsync(m => m.ID == id);

            if (AuctionItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AuctionItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionItemExists(AuctionItem.ID))
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

        private bool AuctionItemExists(int id)
        {
            return _context.AuctionItem.Any(e => e.ID == id);
        }
    }
}
