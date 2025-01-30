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

        public DbSet<Language> Language { get; set; }
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

                modelBuilder.Entity<CodeSnippets>()
                .HasOne<Language>()
                .WithMany()
                .HasForeignKey(u => u.Programming_language)
                .OnDelete(DeleteBehavior.Restrict);
                // CodeSnippets <-> Users
                //modelBuilder.Entity<CodeSnippets>()
                //    .HasOne<Language>()
                //    .WithMany()
                //    .HasForeignKey(cs => cs.Id_Programming_language)
                //    .OnDelete(DeleteBehavior.Cascade);

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

                modelBuilder.Entity<Language>().HasData(
    new Language { Id_Programming_language = 1, Programming_language = "C#" },
    new Language { Id_Programming_language = 2, Programming_language = "Python" },
    new Language { Id_Programming_language = 3, Programming_language = "Java" },
    new Language { Id_Programming_language = 4, Programming_language = "Go" },
    new Language { Id_Programming_language = 5, Programming_language = "PHP" },
    new Language { Id_Programming_language = 6, Programming_language = "JavaScript" },
    new Language { Id_Programming_language = 7, Programming_language = "C++" },
    new Language { Id_Programming_language = 8, Programming_language = "C" },
    new Language { Id_Programming_language = 9, Programming_language = "TypeScript" },
    new Language { Id_Programming_language = 10, Programming_language = "Swift" },
    new Language { Id_Programming_language = 11, Programming_language = "Kotlin" },
    new Language { Id_Programming_language = 12, Programming_language = "Rust" },
    new Language { Id_Programming_language = 13, Programming_language = "Ruby" },
    new Language { Id_Programming_language = 14, Programming_language = "Dart" },
    new Language { Id_Programming_language = 15, Programming_language = "Scala" },
    new Language { Id_Programming_language = 16, Programming_language = "Objective-C" },
    new Language { Id_Programming_language = 17, Programming_language = "Perl" },
    new Language { Id_Programming_language = 18, Programming_language = "Lua" },
    new Language { Id_Programming_language = 19, Programming_language = "Haskell" },
    new Language { Id_Programming_language = 20, Programming_language = "Elixir" },
    new Language { Id_Programming_language = 21, Programming_language = "F#" },
    new Language { Id_Programming_language = 22, Programming_language = "R" },
    new Language { Id_Programming_language = 23, Programming_language = "Julia" },
    new Language { Id_Programming_language = 24, Programming_language = "SQL" },
    new Language { Id_Programming_language = 25, Programming_language = "Bash" },
    new Language { Id_Programming_language = 26, Programming_language = "Shell" },
    new Language { Id_Programming_language = 27, Programming_language = "PowerShell" },
    new Language { Id_Programming_language = 28, Programming_language = "MATLAB" },
    new Language { Id_Programming_language = 29, Programming_language = "COBOL" },
    new Language { Id_Programming_language = 30, Programming_language = "Fortran" },
    new Language { Id_Programming_language = 31, Programming_language = "Ada" },
    new Language { Id_Programming_language = 32, Programming_language = "Lisp" },
    new Language { Id_Programming_language = 33, Programming_language = "Scheme" },
    new Language { Id_Programming_language = 34, Programming_language = "Prolog" },
    new Language { Id_Programming_language = 35, Programming_language = "Smalltalk" },
    new Language { Id_Programming_language = 36, Programming_language = "Erlang" },
    new Language { Id_Programming_language = 37, Programming_language = "APL" },
    new Language { Id_Programming_language = 38, Programming_language = "Awk" },
    new Language { Id_Programming_language = 39, Programming_language = "Groovy" },
    new Language { Id_Programming_language = 40, Programming_language = "Tcl" },
    new Language { Id_Programming_language = 41, Programming_language = "Racket" },
    new Language { Id_Programming_language = 42, Programming_language = "ML" },
    new Language { Id_Programming_language = 43, Programming_language = "OCaml" },
    new Language { Id_Programming_language = 44, Programming_language = "Forth" },
    new Language { Id_Programming_language = 45, Programming_language = "Delphi" },
    new Language { Id_Programming_language = 46, Programming_language = "D" },
    new Language { Id_Programming_language = 47, Programming_language = "Crystal" },
    new Language { Id_Programming_language = 48, Programming_language = "FoxPro" },
    new Language { Id_Programming_language = 49, Programming_language = "REXX" },
    new Language { Id_Programming_language = 50, Programming_language = "Clipper" },
    new Language { Id_Programming_language = 51, Programming_language = "PL/SQL" },
    new Language { Id_Programming_language = 52, Programming_language = "T-SQL" },
    new Language { Id_Programming_language = 53, Programming_language = "ABAP" },
    new Language { Id_Programming_language = 54, Programming_language = "XQuery" },
    new Language { Id_Programming_language = 55, Programming_language = "VHDL" },
    new Language { Id_Programming_language = 56, Programming_language = "Verilog" },
    new Language { Id_Programming_language = 57, Programming_language = "ActionScript" },
    new Language { Id_Programming_language = 58, Programming_language = "Modula-2" },
    new Language { Id_Programming_language = 59, Programming_language = "PostScript" },
    new Language { Id_Programming_language = 60, Programming_language = "Eiffel" },
    new Language { Id_Programming_language = 61, Programming_language = "J" },
    new Language { Id_Programming_language = 62, Programming_language = "IDL" },
    new Language { Id_Programming_language = 63, Programming_language = "IDL (CORBA)" },
    new Language { Id_Programming_language = 64, Programming_language = "Logo" },
    new Language { Id_Programming_language = 65, Programming_language = "X10" },
    new Language { Id_Programming_language = 66, Programming_language = "Nim" },
    new Language { Id_Programming_language = 67, Programming_language = "Zig" },
    new Language { Id_Programming_language = 68, Programming_language = "Hack" },
    new Language { Id_Programming_language = 69, Programming_language = "J#" },
    new Language { Id_Programming_language = 70, Programming_language = "VBScript" },
    new Language { Id_Programming_language = 71, Programming_language = "QBasic" },
    new Language { Id_Programming_language = 72, Programming_language = "Fantom" },
    new Language { Id_Programming_language = 73, Programming_language = "RPG" },
    new Language { Id_Programming_language = 74, Programming_language = "Chapel" },
    new Language { Id_Programming_language = 75, Programming_language = "IDL" },
    new Language { Id_Programming_language = 76, Programming_language = "Haxe" },
    new Language { Id_Programming_language = 77, Programming_language = "Transact-SQL" },
    new Language { Id_Programming_language = 78, Programming_language = "Sed" },
    new Language { Id_Programming_language = 79, Programming_language = "Pike" },
    new Language { Id_Programming_language = 80, Programming_language = "IDL (IDL4)" },
    new Language { Id_Programming_language = 81, Programming_language = "OpenCL" },
    new Language { Id_Programming_language = 82, Programming_language = "IDL (Interactive Data Language)" },
    new Language { Id_Programming_language = 83, Programming_language = "IDL (Industrial Design Language)" },
    new Language { Id_Programming_language = 84, Programming_language = "IDL (Interface Definition Language)" }
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
