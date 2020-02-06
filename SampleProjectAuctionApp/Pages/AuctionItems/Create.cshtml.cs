using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleProjectAuctionApp.Data;
using SampleProjectAuctionApp.Models;

namespace SampleProjectAuctionApp.Pages.AuctionItems
{
    public class CreateModel : PageModel
    {
        private readonly SampleProjectAuctionApp.Data.RazorPagesAuctionContext _context;

        public CreateModel(SampleProjectAuctionApp.Data.RazorPagesAuctionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AuctionItem AuctionItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AuctionItem.Add(AuctionItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}