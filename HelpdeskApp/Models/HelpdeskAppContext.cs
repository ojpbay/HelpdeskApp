using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpdeskApp.Models
{
    public class HelpdeskAppContext : DbContext
    {
        public HelpdeskAppContext(DbContextOptions<HelpdeskAppContext> options)
            : base(options)
        { }

        public DbSet<DataItem> Items { get; set; }

        //Add-Migration XXX
        //Update-Database
    }
}
