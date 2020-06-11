using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FastFupService.Model;

namespace FastFupService.Data
{
    public class FastFupServiceContext : DbContext
    {
        public FastFupServiceContext (DbContextOptions<FastFupServiceContext> options)
            : base(options)
        {
        }

        public DbSet<FastFupService.Model.TransportTab> TransportTab { get; set; }
    }
}
