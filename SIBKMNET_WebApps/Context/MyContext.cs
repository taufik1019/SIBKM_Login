using Microsoft.EntityFrameworkCore;
using SIBKMNET_WebApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApps.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }

        // mengatur connection string (done)
        // menambahkan model unntuk diolah dan / atau migrasi

        /*
         * Code first
         * Database First
         */

        public DbSet<Province> Provinces { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Area> Areas { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
