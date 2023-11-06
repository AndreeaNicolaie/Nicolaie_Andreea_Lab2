using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nicolaie_Andreea_Lab2.Models;

namespace Nicolaie_Andreea_Lab2.Data
{
    public class Nicolaie_Andreea_Lab2Context : DbContext
    {
        public Nicolaie_Andreea_Lab2Context (DbContextOptions<Nicolaie_Andreea_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Nicolaie_Andreea_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Nicolaie_Andreea_Lab2.Models.Borrowing> Borrowings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Borrowing)
                .WithOne(b => b.Book)
                .HasForeignKey<Borrowing>(b => b.BookID);
        }

        public DbSet<Nicolaie_Andreea_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Nicolaie_Andreea_Lab2.Models.Author>? Author { get; set; }

        public DbSet<Nicolaie_Andreea_Lab2.Models.Category>? Category { get; set; }

        public DbSet<Nicolaie_Andreea_Lab2.Models.Member>? Member { get; set; }
    }
}
