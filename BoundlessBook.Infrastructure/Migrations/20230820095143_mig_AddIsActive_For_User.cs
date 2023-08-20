using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoundlessBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_AddIsActive_For_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "user",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "user",
                table: "Users");
        }
    }
}
