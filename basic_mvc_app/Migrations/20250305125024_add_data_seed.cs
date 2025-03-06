using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_mvc_app.Migrations
{
    /// <inheritdoc />
    public partial class add_data_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "admin@admin.com", "Admin", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
