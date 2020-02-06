using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleProjectAuctionApp.Data;
using SampleProjectAuctionApp.Models;

namespace SampleProjectAuctionApp.Pages.AuctionItems
{
    public class DeleteModel : PageModel
    {
        private readonly SampleProjectAuctionApp.Data.RazorPagesAuctionContext _context;

        public DeleteModel(SampleProjectAuctionApp.Data.RazorPagesAuctionContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AuctionItem = await _context.AuctionItem.FindAsync(id);

            if (AuctionItem != null)
            {
                _context.AuctionItem.Remove(AuctionItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
