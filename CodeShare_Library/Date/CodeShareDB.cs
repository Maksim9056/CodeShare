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
            //Database.Migrate();
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
        public DbSet<Roles> Roles { get; set; } // Добавьте таблицу ролей


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                // Users <-> Roles
                modelBuilder.Entity<Users>()
                    .HasOne<Roles>()
                    .WithMany()
                    .HasForeignKey(u => u.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                // CodeSnippets <-> Users
                modelBuilder.Entity<CodeSnippets>()
                    .HasOne<Users>()
                    .WithMany()
                    .HasForeignKey(cs => cs.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Changes_in_the_system <-> Users
                modelBuilder.Entity<Changes_in_the_system>()
                    .HasOne<Users>()
                    .WithMany()
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Comment <-> Users
                modelBuilder.Entity<Comment>()
                    .HasOne<Users>()
                    .WithMany()
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Comment <-> CodeSnippets
                modelBuilder.Entity<Comment>()
                    .HasOne<CodeSnippets>()
                    .WithMany()
                    .HasForeignKey(c => c.SnippetsId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Comment <-> Rate
                modelBuilder.Entity<Comment>()
                    .HasOne<Rate>()
                    .WithMany()
                    .HasForeignKey(c => c.RatingId)
                    .OnDelete(DeleteBehavior.Restrict);

                // History <-> CodeSnippets
                modelBuilder.Entity<History>()
                    .HasOne<CodeSnippets>()
                    .WithMany()
                    .HasForeignKey(h => h.SnippetId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Image <-> Users
                modelBuilder.Entity<Image>()
                    .HasOne<Users>()
                    .WithMany()
                    .HasForeignKey(i => i.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Image <-> Logotype
                modelBuilder.Entity<Image>()
                    .HasOne<Logotype>()
                    .WithMany()
                    .HasForeignKey(i => i.LogotypeId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Logotype <-> Image
                modelBuilder.Entity<Logotype>()
                    .HasOne<Image>()
                    .WithMany()
                    .HasForeignKey(l => l.ImageId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Setting <-> CodeSnippets
                modelBuilder.Entity<Setting>()
                    .HasOne<CodeSnippets>()
                    .WithMany()
                    .HasForeignKey(s => s.SnippetId)
                    .OnDelete(DeleteBehavior.Cascade);
              

                // Данные для таблицы Roles
                modelBuilder.Entity<Roles>().HasData(
                    new Roles { RolesId = 1, NameRole = "Админ" }
                );
                modelBuilder.Entity<Roles>().HasData(
                new Roles { RolesId = 2, NameRole = "Пользователь" }
                );

                // Данные для таблицы Users
                modelBuilder.Entity<Users>().HasData(
                    new Users
                    {
                        UsersId = 1,
                        UsersName = "Admin",
                        //CreateAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        CreateAt = "2025-01-10 12:00:00",

                        Email = "Admin@mail.ru",
                        Password = "Admin",
                        Phone = "",
                        RoleId = 1,
                        //UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        UpdatedAt = "2025-01-10 12:00:00"

                    }
                );

                base.OnModelCreating(modelBuilder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
// // // Настройка внешнего ключа без навигационных свойств
// modelBuilder.Entity<CodeSnippets>()
//     .HasOne<Users>()
//     .WithMany()
//     .HasForeignKey(o => o.UserId)
//     .OnDelete(DeleteBehavior.Cascade);

// modelBuilder.Entity<Logotype>()
//  .HasOne<Image>()
//  .WithMany()
//  .HasForeignKey(o => o.ImageId)
//  .OnDelete(DeleteBehavior.Cascade);




// modelBuilder.Entity<Image>()
//  .HasOne<Logotype>()
//  .WithMany()
//  .HasForeignKey(o => o.LogotypeId)
//  .OnDelete(DeleteBehavior.Cascade);


// modelBuilder.Entity<Image>()
//               .HasOne<Users>()
//               .WithMany()
//               .HasForeignKey(o => o.UserId)

//               .OnDelete(DeleteBehavior.Cascade);


// modelBuilder.Entity<CodeSnippets>()
//               .HasOne<Users>()
//               .WithMany()
//               .HasForeignKey(o => o.UserId)

//               .OnDelete(DeleteBehavior.Cascade);

// modelBuilder.Entity<Changes_in_the_system>()
//             .HasOne<Users>()
//             .WithMany()
//             .HasForeignKey(o => o.UserId)

//             .OnDelete(DeleteBehavior.Cascade);


// modelBuilder.Entity<Users>()
//    .HasOne<Roles>()
//    .WithMany()
//    .HasForeignKey(o => o.RoleId)

//    .OnDelete(DeleteBehavior.Cascade);


// modelBuilder.Entity<History>()
// .HasOne<CodeSnippets>()
// .WithMany()
// .HasForeignKey(o => o.SnippetId)

// .OnDelete(DeleteBehavior.Cascade);
// modelBuilder.Entity<Comment>()
//   .HasOne<Rate>()
//   .WithMany()
//   .HasForeignKey(o => o.RatingId)
//   .OnDelete(DeleteBehavior.Cascade);

// modelBuilder.Entity<Comment>()
//.HasOne<Users>()
//.WithMany()
//.HasForeignKey(o => o.UserId)
//.OnDelete(DeleteBehavior.Cascade);


// modelBuilder.Entity<Comment>()
//.HasOne<CodeSnippets>()
//.WithMany()
//.HasForeignKey(o => o.SnippetsId)
//.OnDelete(DeleteBehavior.Cascade);


// modelBuilder.Entity<Setting>()
// .HasOne<CodeSnippets>()
// .WithMany()
// .HasForeignKey(o => o.SnippetId)
// .OnDelete(DeleteBehavior.Cascade);
