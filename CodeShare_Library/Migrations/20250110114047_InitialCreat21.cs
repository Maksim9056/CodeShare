using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeShare_Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 1L,
                column: "NameRole",
                value: "Админ");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolesId", "NameRole" },
                values: new object[] { 2L, "Пользователь" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 2L);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 1L,
                column: "NameRole",
                value: "Admin");
        }
    }
}
