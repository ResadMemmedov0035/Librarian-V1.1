using System.Configuration;
using EFCoreLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary
{
    public class LibrarianDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = ConfigurationManager.ConnectionStrings["LibrarianDbConnStr"].ConnectionString;
            optionsBuilder.UseSqlServer(connStr);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
