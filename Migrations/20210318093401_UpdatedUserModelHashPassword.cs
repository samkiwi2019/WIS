using Microsoft.EntityFrameworkCore.Migrations;

namespace WIS.Migrations
{
    public partial class UpdatedUserModelHashPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hash",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "HashPassword");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashPassword",
                table: "Users",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);
        }
    }
}
