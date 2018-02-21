namespace HtppHeaders.Models
{
     using Microsoft.EntityFrameworkCore;

     using System;
     using System.IO;
     using System.Collections.Generic;
     using System.ComponentModel.DataAnnotations;

     
    public class HeaderContext : DbContext
    {
        public HeaderContext(DbContextOptions<HeaderContext> options) : base(options){}

        public DbSet<HeaderStore> HttpHeaders{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeaderStore>().Property(h => h.Id).ValueGeneratedOnAdd();
        }

    }
      
}