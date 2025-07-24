using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Listfy_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRolesForUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "roleId",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roleId",
                table: "User");
        }
    }
}
