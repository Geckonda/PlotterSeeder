using Microsoft.EntityFrameworkCore;
using SeederForPlotter.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeederForPlotter
{
    public class ApplicationDBContext: DbContext
    {
        public static string connectionString { get; } = @"Server=(localdb)\mssqllocaldb;Database=PlotCreator;Trusted_Connection=True;";
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Access_Modificator> Modificators => Set<Access_Modificator>();
        public DbSet<Rating> Ratings => Set<Rating>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Book_Status> Statuses => Set<Book_Status>();
        public DbSet<Worldview> Worldview => Set<Worldview>();

        public ApplicationDBContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
