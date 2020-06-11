using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFupService.Model
{
    public class TransportTabContext : DbContext
    {
        public TransportTabContext(DbContextOptions<TransportTabContext> options) : base(options)
        {

        }

        public System.Data.Entity.DbSet<TransportTab> InMemoryTransportTab { get; set; }
    }
}
