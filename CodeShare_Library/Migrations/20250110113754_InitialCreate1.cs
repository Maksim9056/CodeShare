using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CodeShare_Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Programming_language = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeSnippets", x => x.CodeSnippetsId);
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
                table: "Roles",
                columns: new[] { "RolesId", "NameRole" },
                values: new object[] { 1L, "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UsersId", "CreateAt", "Email", "Password", "Phone", "RoleId", "UpdatedAt", "UsersName" },
                values: new object[] { 1L, "2025-01-10 12:00:00", "Admin@mail.ru", "Admin", "", 1L, "2025-01-10 12:00:00", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Changes_in_the_system_UserId",
                table: "Changes_in_the_system",
                column: "UserId");

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
