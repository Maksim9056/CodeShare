using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeShare_Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rate",
                columns: new[] { "RateId", "Name_Rate" },
                values: new object[,]
                {
                    { 1L, "Плохо" },
                    { 2L, "Средне" },
                    { 3L, "Хорошо" },
                    { 4L, "Отлично" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rate",
                keyColumn: "RateId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Rate",
                keyColumn: "RateId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Rate",
                keyColumn: "RateId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Rate",
                keyColumn: "RateId",
                keyValue: 4L);
        }
    }
}
