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
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AssignmentGroup> Groups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(new Contact { Id = 1, FullName = "Brad Bobley" });
            modelBuilder.Entity<Contact>().HasData(new Contact { Id = 2, FullName = "Bob Bradley" });
            modelBuilder.Entity<Contact>().HasData(new Contact { Id = 3, FullName = "Chris Crosby" });

            modelBuilder.Entity<AssignmentGroup>().HasData(new AssignmentGroup { Id = 1, Name = "Desktop support" });
            modelBuilder.Entity<AssignmentGroup>().HasData(new AssignmentGroup { Id = 2, Name = "Helpdesk" });
            modelBuilder.Entity<AssignmentGroup>().HasData(new AssignmentGroup { Id = 3, Name = "Application support" });

            modelBuilder.Entity<DataItem>().HasData(new { Id = 1, Description = "NullaPede.mov", ContactId = 1, AssignmentGroupId = 1 });
            modelBuilder.Entity<DataItem>().HasData(new { Id = 2, Description = "NecNisiVolutpat.ppt", ContactId = 1, AssignmentGroupId = 1 });
            modelBuilder.Entity<DataItem>().HasData(new { Id = 3, Description = "JustoPellentesque.tiff", ContactId = 1, AssignmentGroupId = 1 });
            modelBuilder.Entity<DataItem>().HasData(new { Id = 4, Description = "LobortisSapienSapien.xls", ContactId = 1, AssignmentGroupId = 2 });
            modelBuilder.Entity<DataItem>().HasData(new { Id = 5, Description = "ConsequatVarius.mp3", ContactId = 2, AssignmentGroupId = 2 });
            modelBuilder.Entity<DataItem>().HasData(new { Id = 6, Description = "BibendumMorbi.xls", ContactId = 2, AssignmentGroupId = 2 });
            modelBuilder.Entity<DataItem>().HasData(new { Id = 7, Description = "Parturient.tiff", ContactId = 3, AssignmentGroupId = 2 });
            modelBuilder.Entity<DataItem>().HasData(new { Id = 8, Description = "AugueVestibulum.pdf", ContactId = 3, AssignmentGroupId = 3 });
            modelBuilder.Entity<DataItem>().HasData(new { Id = 9, Description = "NibhLigula.png", ContactId = 3, AssignmentGroupId = 3 });
            modelBuilder.Entity<DataItem>().HasData(new { Id = 10, Description = "IpsumPrimisIn.jpeg", ContactId = 3, AssignmentGroupId = 3 });

            base.OnModelCreating(modelBuilder);
        }

        //Add-Migration XXX
        //Update-Database
    }
}
