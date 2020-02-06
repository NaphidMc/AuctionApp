using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleProjectAuctionApp.Models;

namespace SampleProjectAuctionApp.Data
{
    public class RazorPagesAuctionContext : DbContext
    {
        public RazorPagesAuctionContext(DbContextOptions<RazorPagesAuctionContext> options) : base(options)
        {

        }

        public DbSet<SampleProjectAuctionApp.Models.AuctionItem> AuctionItem { get; set; }
    }
}