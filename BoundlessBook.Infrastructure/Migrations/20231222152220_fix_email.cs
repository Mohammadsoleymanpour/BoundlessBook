using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoundlessBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                schema: "user",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "user",
                table: "Users",
                column: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                schema: "user",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "user",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }
    }
}
