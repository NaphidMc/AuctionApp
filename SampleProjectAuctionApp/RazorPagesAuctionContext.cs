using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SampleProjectAuctionApp
{
    public class RazorPagesAuctionContext : DbContext
    {
        public RazorPagesAuctionContext(DbContextOptions<RazorPagesAuctionContext> options) : base(options)
        {

        }
    }
}