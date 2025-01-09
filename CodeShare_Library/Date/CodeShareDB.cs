using CodeShare_Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Date
{
    public class CodeShareDB : DbContext
    {
        public CodeShareDB(DbContextOptions<CodeShareDB> options) : base(options)
        {

            Database.Migrate();
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<CodeSnippets> CodeSnippets { get; set; }

        public DbSet<Image> Image { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Rate> Rate { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<Logotype> Logotype { get; set; }
        public DbSet<Changes_in_the_system> Changes_in_the_system { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
