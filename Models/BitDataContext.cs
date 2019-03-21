using System;
using Microsoft.EntityFrameworkCore;

namespace bit285_assignment3_api.Models
{
    public class BitDataContext : DbContext
    {
        public BitDataContext(DbContextOptions<BitDataContext> options)
        : base(options)
        {
           Database.EnsureCreated();
        }

        //Access to Collections representing DB tables
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }


        //TODO: on VS-MAC use the reference https://www.ciclosoftware.com/2018/03/14/sql-server-with-net-core-and-entityframework-on-mac/
        //TODO: Update with your Database, User, and Password
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=BitData;User=SA; Password=<YourStrong!Passw0rd>");
        }
    }


}
