﻿// <auto-generated />
using CodeShare_Library.Date;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CodeShare_Library.Migrations
{
    [DbContext(typeof(CodeShareDB))]
    [Migration("20250224182855_InitialCreatms12122")]
    partial class InitialCreatms12122
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CodeShare_Library.Models.Changes_in_the_system", b =>
                {
                    b.Property<long>("Changes_in_the_systemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Changes_in_the_systemId"));

                    b.Property<string>("Action_Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreateAt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text_update")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Changes_in_the_systemId");

                    b.HasIndex("UserId");

                    b.ToTable("Changes_in_the_system");
                });

            modelBuilder.Entity("CodeShare_Library.Models.CodeSnippets", b =>
                {
                    b.Property<long>("CodeSnippetsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("CodeSnippetsId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreateAt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("IsAdmin")
                        .HasColumnType("bigint");

                    b.Property<long>("Programming_language")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdateAt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("CodeSnippetsId");

                    b.HasIndex("Programming_language");

                    b.HasIndex("UserId");

                    b.ToTable("CodeSnippets");
                });

            modelBuilder.Entity("CodeShare_Library.Models.Comment", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("CommentId"));

                    b.Property<string>("Comment_Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreateAt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("boolean");

                    b.Property<string>("Name_Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("RatingId")
                        .HasColumnType("bigint");

                    b.Property<string>("Selected_Range")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("SnippetsId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("CommentId");

                    b.HasIndex("RatingId");

                    b.HasIndex("SnippetsId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("CodeShare_Library.Models.History", b =>
                {
                    b.Property<long>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("HistoryId"));

                    b.Property<string>("Change_date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("SnippetId")
                        .HasColumnType("bigint");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("HistoryId");

                    b.HasIndex("SnippetId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("CodeShare_Library.Models.Image", b =>
                {
                    b.Property<long>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ImageId"));

                    b.Property<string>("CreateAt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("LogotypeId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("ImageId");

                    b.HasIndex("LogotypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("CodeShare_Library.Models.Language", b =>
                {
                    b.Property<long>("Id_Programming_language")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id_Programming_language"));

                    b.Property<string>("Programming_language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Programming_language");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            Id_Programming_language = 1L,
                            Programming_language = "C#"
                        },
                        new
                        {
                            Id_Programming_language = 2L,
                            Programming_language = "Python"
                        },
                        new
                        {
                            Id_Programming_language = 3L,
                            Programming_language = "Java"
                        },
                        new
                        {
                            Id_Programming_language = 4L,
                            Programming_language = "Go"
                        },
                        new
                        {
                            Id_Programming_language = 5L,
                            Programming_language = "PHP"
                        },
                        new
                        {
                            Id_Programming_language = 6L,
                            Programming_language = "JavaScript"
                        },
                        new
                        {
                            Id_Programming_language = 7L,
                            Programming_language = "C++"
                        },
                        new
                        {
                            Id_Programming_language = 8L,
                            Programming_language = "C"
                        },
                        new
                        {
                            Id_Programming_language = 9L,
                            Programming_language = "TypeScript"
                        },
                        new
                        {
                            Id_Programming_language = 10L,
                            Programming_language = "Swift"
                        },
                        new
                        {
                            Id_Programming_language = 11L,
                            Programming_language = "Kotlin"
                        },
                        new
                        {
                            Id_Programming_language = 12L,
                            Programming_language = "Rust"
                        },
                        new
                        {
                            Id_Programming_language = 13L,
                            Programming_language = "Ruby"
                        },
                        new
                        {
                            Id_Programming_language = 14L,
                            Programming_language = "Dart"
                        },
                        new
                        {
                            Id_Programming_language = 15L,
                            Programming_language = "Scala"
                        },
                        new
                        {
                            Id_Programming_language = 16L,
                            Programming_language = "Objective-C"
                        },
                        new
                        {
                            Id_Programming_language = 17L,
                            Programming_language = "Perl"
                        },
                        new
                        {
                            Id_Programming_language = 18L,
                            Programming_language = "Lua"
                        },
                        new
                        {
                            Id_Programming_language = 19L,
                            Programming_language = "Haskell"
                        },
                        new
                        {
                            Id_Programming_language = 20L,
                            Programming_language = "Elixir"
                        },
                        new
                        {
                            Id_Programming_language = 21L,
                            Programming_language = "F#"
                        },
                        new
                        {
                            Id_Programming_language = 22L,
                            Programming_language = "R"
                        },
                        new
                        {
                            Id_Programming_language = 23L,
                            Programming_language = "Julia"
                        },
                        new
                        {
                            Id_Programming_language = 24L,
                            Programming_language = "SQL"
                        },
                        new
                        {
                            Id_Programming_language = 25L,
                            Programming_language = "Bash"
                        },
                        new
                        {
                            Id_Programming_language = 26L,
                            Programming_language = "Shell"
                        },
                        new
                        {
                            Id_Programming_language = 27L,
                            Programming_language = "PowerShell"
                        },
                        new
                        {
                            Id_Programming_language = 28L,
                            Programming_language = "MATLAB"
                        },
                        new
                        {
                            Id_Programming_language = 29L,
                            Programming_language = "COBOL"
                        },
                        new
                        {
                            Id_Programming_language = 30L,
                            Programming_language = "Fortran"
                        },
                        new
                        {
                            Id_Programming_language = 31L,
                            Programming_language = "Ada"
                        },
                        new
                        {
                            Id_Programming_language = 32L,
                            Programming_language = "Lisp"
                        },
                        new
                        {
                            Id_Programming_language = 33L,
                            Programming_language = "Scheme"
                        },
                        new
                        {
                            Id_Programming_language = 34L,
                            Programming_language = "Prolog"
                        },
                        new
                        {
                            Id_Programming_language = 35L,
                            Programming_language = "Smalltalk"
                        },
                        new
                        {
                            Id_Programming_language = 36L,
                            Programming_language = "Erlang"
                        },
                        new
                        {
                            Id_Programming_language = 37L,
                            Programming_language = "APL"
                        },
                        new
                        {
                            Id_Programming_language = 38L,
                            Programming_language = "Awk"
                        },
                        new
                        {
                            Id_Programming_language = 39L,
                            Programming_language = "Groovy"
                        },
                        new
                        {
                            Id_Programming_language = 40L,
                            Programming_language = "Tcl"
                        },
                        new
                        {
                            Id_Programming_language = 41L,
                            Programming_language = "Racket"
                        },
                        new
                        {
                            Id_Programming_language = 42L,
                            Programming_language = "ML"
                        },
                        new
                        {
                            Id_Programming_language = 43L,
                            Programming_language = "OCaml"
                        },
                        new
                        {
                            Id_Programming_language = 44L,
                            Programming_language = "Forth"
                        },
                        new
                        {
                            Id_Programming_language = 45L,
                            Programming_language = "Delphi"
                        },
                        new
                        {
                            Id_Programming_language = 46L,
                            Programming_language = "D"
                        },
                        new
                        {
                            Id_Programming_language = 47L,
                            Programming_language = "Crystal"
                        },
                        new
                        {
                            Id_Programming_language = 48L,
                            Programming_language = "FoxPro"
                        },
                        new
                        {
                            Id_Programming_language = 49L,
                            Programming_language = "REXX"
                        },
                        new
                        {
                            Id_Programming_language = 50L,
                            Programming_language = "Clipper"
                        },
                        new
                        {
                            Id_Programming_language = 51L,
                            Programming_language = "PL/SQL"
                        },
                        new
                        {
                            Id_Programming_language = 52L,
                            Programming_language = "T-SQL"
                        },
                        new
                        {
                            Id_Programming_language = 53L,
                            Programming_language = "ABAP"
                        },
                        new
                        {
                            Id_Programming_language = 54L,
                            Programming_language = "XQuery"
                        },
                        new
                        {
                            Id_Programming_language = 55L,
                            Programming_language = "VHDL"
                        },
                        new
                        {
                            Id_Programming_language = 56L,
                            Programming_language = "Verilog"
                        },
                        new
                        {
                            Id_Programming_language = 57L,
                            Programming_language = "ActionScript"
                        },
                        new
                        {
                            Id_Programming_language = 58L,
                            Programming_language = "Modula-2"
                        },
                        new
                        {
                            Id_Programming_language = 59L,
                            Programming_language = "PostScript"
                        },
                        new
                        {
                            Id_Programming_language = 60L,
                            Programming_language = "Eiffel"
                        },
                        new
                        {
                            Id_Programming_language = 61L,
                            Programming_language = "J"
                        },
                        new
                        {
                            Id_Programming_language = 62L,
                            Programming_language = "IDL"
                        },
                        new
                        {
                            Id_Programming_language = 63L,
                            Programming_language = "IDL (CORBA)"
                        },
                        new
                        {
                            Id_Programming_language = 64L,
                            Programming_language = "Logo"
                        },
                        new
                        {
                            Id_Programming_language = 65L,
                            Programming_language = "X10"
                        },
                        new
                        {
                            Id_Programming_language = 66L,
                            Programming_language = "Nim"
                        },
                        new
                        {
                            Id_Programming_language = 67L,
                            Programming_language = "Zig"
                        },
                        new
                        {
                            Id_Programming_language = 68L,
                            Programming_language = "Hack"
                        },
                        new
                        {
                            Id_Programming_language = 69L,
                            Programming_language = "J#"
                        },
                        new
                        {
                            Id_Programming_language = 70L,
                            Programming_language = "VBScript"
                        },
                        new
                        {
                            Id_Programming_language = 71L,
                            Programming_language = "QBasic"
                        },
                        new
                        {
                            Id_Programming_language = 72L,
                            Programming_language = "Fantom"
                        },
                        new
                        {
                            Id_Programming_language = 73L,
                            Programming_language = "RPG"
                        },
                        new
                        {
                            Id_Programming_language = 74L,
                            Programming_language = "Chapel"
                        },
                        new
                        {
                            Id_Programming_language = 75L,
                            Programming_language = "IDL"
                        },
                        new
                        {
                            Id_Programming_language = 76L,
                            Programming_language = "Haxe"
                        },
                        new
                        {
                            Id_Programming_language = 77L,
                            Programming_language = "Transact-SQL"
                        },
                        new
                        {
                            Id_Programming_language = 78L,
                            Programming_language = "Sed"
                        },
                        new
                        {
                            Id_Programming_language = 79L,
                            Programming_language = "Pike"
                        },
                        new
                        {
                            Id_Programming_language = 80L,
                            Programming_language = "IDL (IDL4)"
                        },
                        new
                        {
                            Id_Programming_language = 81L,
                            Programming_language = "OpenCL"
                        },
                        new
                        {
                            Id_Programming_language = 82L,
                            Programming_language = "IDL (Interactive Data Language)"
                        },
                        new
                        {
                            Id_Programming_language = 83L,
                            Programming_language = "IDL (Industrial Design Language)"
                        },
                        new
                        {
                            Id_Programming_language = 84L,
                            Programming_language = "IDL (Interface Definition Language)"
                        });
                });

            modelBuilder.Entity("CodeShare_Library.Models.Logotype", b =>
                {
                    b.Property<long>("LogotypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("LogotypeId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<long>("ImageId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Inactive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name_Logotype")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Realtime")
                        .HasColumnType("boolean");

                    b.HasKey("LogotypeId");

                    b.HasIndex("ImageId");

                    b.ToTable("Logotype");
                });

            modelBuilder.Entity("CodeShare_Library.Models.Rate", b =>
                {
                    b.Property<long>("RateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("RateId"));

                    b.Property<string>("Name_Rate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RateId");

                    b.ToTable("Rate");

                    b.HasData(
                        new
                        {
                            RateId = 1L,
                            Name_Rate = "Плохо"
                        },
                        new
                        {
                            RateId = 2L,
                            Name_Rate = "Средне"
                        },
                        new
                        {
                            RateId = 3L,
                            Name_Rate = "Хорошо"
                        },
                        new
                        {
                            RateId = 4L,
                            Name_Rate = "Отлично"
                        });
                });

            modelBuilder.Entity("CodeShare_Library.Models.Roles", b =>
                {
                    b.Property<long>("RolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("RolesId"));

                    b.Property<string>("NameRole")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RolesId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RolesId = 1L,
                            NameRole = "Админ"
                        },
                        new
                        {
                            RolesId = 2L,
                            NameRole = "Пользователь"
                        });
                });

            modelBuilder.Entity("CodeShare_Library.Models.Setting", b =>
                {
                    b.Property<long>("SettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("SettingId"));

                    b.Property<bool>("Block")
                        .HasColumnType("boolean");

                    b.Property<string>("Hide")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Prohibition")
                        .HasColumnType("boolean");

                    b.Property<long>("SnippetId")
                        .HasColumnType("bigint");

                    b.Property<string>("Visibility_Setting")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SettingId");

                    b.HasIndex("SnippetId");

                    b.ToTable("Setting");
                });

            modelBuilder.Entity("CodeShare_Library.Models.Users", b =>
                {
                    b.Property<long>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("UsersId"));

                    b.Property<string>("CreateAt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("UpdatedAt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UsersName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UsersId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UsersId = 1L,
                            CreateAt = "2025-01-10 12:00:00",
                            Email = "Admin@mail.ru",
                            Password = "Admin",
                            Phone = "",
                            RoleId = 1L,
                            UpdatedAt = "2025-01-10 12:00:00",
                            UsersName = "Admin"
                        });
                });

            modelBuilder.Entity("CodeShare_Library.Models.Changes_in_the_system", b =>
                {
                    b.HasOne("CodeShare_Library.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeShare_Library.Models.CodeSnippets", b =>
                {
                    b.HasOne("CodeShare_Library.Models.Language", null)
                        .WithMany()
                        .HasForeignKey("Programming_language")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CodeShare_Library.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeShare_Library.Models.Comment", b =>
                {
                    b.HasOne("CodeShare_Library.Models.Rate", null)
                        .WithMany()
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CodeShare_Library.Models.CodeSnippets", null)
                        .WithMany()
                        .HasForeignKey("SnippetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeShare_Library.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeShare_Library.Models.History", b =>
                {
                    b.HasOne("CodeShare_Library.Models.CodeSnippets", null)
                        .WithMany()
                        .HasForeignKey("SnippetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeShare_Library.Models.Image", b =>
                {
                    b.HasOne("CodeShare_Library.Models.Logotype", null)
                        .WithMany()
                        .HasForeignKey("LogotypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CodeShare_Library.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CodeShare_Library.Models.Logotype", b =>
                {
                    b.HasOne("CodeShare_Library.Models.Image", null)
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeShare_Library.Models.Setting", b =>
                {
                    b.HasOne("CodeShare_Library.Models.CodeSnippets", null)
                        .WithMany()
                        .HasForeignKey("SnippetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeShare_Library.Models.Users", b =>
                {
                    b.HasOne("CodeShare_Library.Models.Roles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
