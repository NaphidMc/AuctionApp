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
    public class IndexModel : PageModel
    {
        private readonly SampleProjectAuctionApp.Data.RazorPagesAuctionContext _context;

        public IndexModel(SampleProjectAuctionApp.Data.RazorPagesAuctionContext context)
        {
            _context = context;
        }

        public IList<AuctionItem> AuctionItem { get;set; }

        public async Task OnGetAsync()
        {
            AuctionItem = await _context.AuctionItem.ToListAsync();
        }
    }
}
