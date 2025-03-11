using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatchWebApi.Migrations
{
    /// <inheritdoc />
    public partial class admiuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "ManagerId", "Password", "RoleId" },
                values: new object[] { 1, "admin@gmail.com", "Deepak", "Kumar", 1, "pass@123", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
