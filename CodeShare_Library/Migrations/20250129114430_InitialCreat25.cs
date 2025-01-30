using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeShare_Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id_Programming_language = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Programming_language = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id_Programming_language);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    RateId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name_Rate = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.RateId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolesId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameRole = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolesId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsersName = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreateAt = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UsersId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RolesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Changes_in_the_system",
                columns: table => new
                {
                    Changes_in_the_systemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text_update = table.Column<string>(type: "text", nullable: false),
                    Action_Type = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreateAt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Changes_in_the_system", x => x.Changes_in_the_systemId);
                    table.ForeignKey(
                        name: "FK_Changes_in_the_system_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CodeSnippets",
                columns: table => new
                {
                    CodeSnippetsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsAdmin = table.Column<long>(type: "bigint", nullable: false),
                    CreateAt = table.Column<string>(type: "text", nullable: false),
                    UpdateAt = table.Column<string>(type: "text", nullable: false),
                    Programming_language = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeSnippets", x => x.CodeSnippetsId);
                    table.ForeignKey(
                        name: "FK_CodeSnippets_Language_Programming_language",
                        column: x => x.Programming_language,
                        principalTable: "Language",
                        principalColumn: "Id_Programming_language",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CodeSnippets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name_Comment = table.Column<string>(type: "text", nullable: false),
                    Selected_Range = table.Column<string>(type: "text", nullable: false),
                    RatingId = table.Column<long>(type: "bigint", nullable: false),
                    SnippetsId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreateAt = table.Column<string>(type: "text", nullable: false),
                    Comment_Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_CodeSnippets_SnippetsId",
                        column: x => x.SnippetsId,
                        principalTable: "CodeSnippets",
                        principalColumn: "CodeSnippetsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Rate_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rate",
                        principalColumn: "RateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    HistoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Change_date = table.Column<string>(type: "text", nullable: false),
                    SnippetId = table.Column<long>(type: "bigint", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_History_CodeSnippets_SnippetId",
                        column: x => x.SnippetId,
                        principalTable: "CodeSnippets",
                        principalColumn: "CodeSnippetsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    SettingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Visibility_Setting = table.Column<string>(type: "text", nullable: false),
                    Hide = table.Column<string>(type: "text", nullable: false),
                    Prohibition = table.Column<bool>(type: "boolean", nullable: false),
                    Block = table.Column<bool>(type: "boolean", nullable: false),
                    SnippetId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.SettingId);
                    table.ForeignKey(
                        name: "FK_Setting_CodeSnippets_SnippetId",
                        column: x => x.SnippetId,
                        principalTable: "CodeSnippets",
                        principalColumn: "CodeSnippetsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageDate = table.Column<string>(type: "text", nullable: false),
                    LogotypeId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreateAt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Image_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logotype",
                columns: table => new
                {
                    LogotypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name_Logotype = table.Column<string>(type: "text", nullable: false),
                    ImageId = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Inactive = table.Column<bool>(type: "boolean", nullable: false),
                    Realtime = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logotype", x => x.LogotypeId);
                    table.ForeignKey(
                        name: "FK_Logotype_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id_Programming_language", "Programming_language" },
                values: new object[,]
                {
                    { 1L, "C#" },
                    { 2L, "Python" },
                    { 3L, "Java" },
                    { 4L, "Go" },
                    { 5L, "PHP" },
                    { 6L, "JavaScript" },
                    { 7L, "C++" },
                    { 8L, "C" },
                    { 9L, "TypeScript" },
                    { 10L, "Swift" },
                    { 11L, "Kotlin" },
                    { 12L, "Rust" },
                    { 13L, "Ruby" },
                    { 14L, "Dart" },
                    { 15L, "Scala" },
                    { 16L, "Objective-C" },
                    { 17L, "Perl" },
                    { 18L, "Lua" },
                    { 19L, "Haskell" },
                    { 20L, "Elixir" },
                    { 21L, "F#" },
                    { 22L, "R" },
                    { 23L, "Julia" },
                    { 24L, "SQL" },
                    { 25L, "Bash" },
                    { 26L, "Shell" },
                    { 27L, "PowerShell" },
                    { 28L, "MATLAB" },
                    { 29L, "COBOL" },
                    { 30L, "Fortran" },
                    { 31L, "Ada" },
                    { 32L, "Lisp" },
                    { 33L, "Scheme" },
                    { 34L, "Prolog" },
                    { 35L, "Smalltalk" },
                    { 36L, "Erlang" },
                    { 37L, "APL" },
                    { 38L, "Awk" },
                    { 39L, "Groovy" },
                    { 40L, "Tcl" },
                    { 41L, "Racket" },
                    { 42L, "ML" },
                    { 43L, "OCaml" },
                    { 44L, "Forth" },
                    { 45L, "Delphi" },
                    { 46L, "D" },
                    { 47L, "Crystal" },
                    { 48L, "FoxPro" },
                    { 49L, "REXX" },
                    { 50L, "Clipper" },
                    { 51L, "PL/SQL" },
                    { 52L, "T-SQL" },
                    { 53L, "ABAP" },
                    { 54L, "XQuery" },
                    { 55L, "VHDL" },
                    { 56L, "Verilog" },
                    { 57L, "ActionScript" },
                    { 58L, "Modula-2" },
                    { 59L, "PostScript" },
                    { 60L, "Eiffel" },
                    { 61L, "J" },
                    { 62L, "IDL" },
                    { 63L, "IDL (CORBA)" },
                    { 64L, "Logo" },
                    { 65L, "X10" },
                    { 66L, "Nim" },
                    { 67L, "Zig" },
                    { 68L, "Hack" },
                    { 69L, "J#" },
                    { 70L, "VBScript" },
                    { 71L, "QBasic" },
                    { 72L, "Fantom" },
                    { 73L, "RPG" },
                    { 74L, "Chapel" },
                    { 75L, "IDL" },
                    { 76L, "Haxe" },
                    { 77L, "Transact-SQL" },
                    { 78L, "Sed" },
                    { 79L, "Pike" },
                    { 80L, "IDL (IDL4)" },
                    { 81L, "OpenCL" },
                    { 82L, "IDL (Interactive Data Language)" },
                    { 83L, "IDL (Industrial Design Language)" },
                    { 84L, "IDL (Interface Definition Language)" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolesId", "NameRole" },
                values: new object[,]
                {
                    { 1L, "Админ" },
                    { 2L, "Пользователь" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UsersId", "CreateAt", "Email", "Password", "Phone", "RoleId", "UpdatedAt", "UsersName" },
                values: new object[] { 1L, "2025-01-10 12:00:00", "Admin@mail.ru", "Admin", "", 1L, "2025-01-10 12:00:00", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Changes_in_the_system_UserId",
                table: "Changes_in_the_system",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeSnippets_Programming_language",
                table: "CodeSnippets",
                column: "Programming_language");

            migrationBuilder.CreateIndex(
                name: "IX_CodeSnippets_UserId",
                table: "CodeSnippets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_RatingId",
                table: "Comment",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_SnippetsId",
                table: "Comment",
                column: "SnippetsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_History_SnippetId",
                table: "History",
                column: "SnippetId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_LogotypeId",
                table: "Image",
                column: "LogotypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_UserId",
                table: "Image",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Logotype_ImageId",
                table: "Logotype",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Setting_SnippetId",
                table: "Setting",
                column: "SnippetId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Logotype_LogotypeId",
                table: "Image",
                column: "LogotypeId",
                principalTable: "Logotype",
                principalColumn: "LogotypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Users_UserId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Logotype_LogotypeId",
                table: "Image");

            migrationBuilder.DropTable(
                name: "Changes_in_the_system");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "CodeSnippets");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Logotype");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
