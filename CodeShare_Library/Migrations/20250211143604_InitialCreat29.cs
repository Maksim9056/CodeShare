using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeShare_Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Comment",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Comment");
        }
    }
}
