using Microsoft.EntityFrameworkCore;
using System.Net;
using AuthorData;
using System.Collections.Generic;

namespace AuthConsole
{
    public class AuthContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AuthorDB");
        }

    }
}
