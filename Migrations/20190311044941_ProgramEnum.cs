using Microsoft.EntityFrameworkCore.Migrations;

namespace bit285_assignment3_api.Migrations
{
    public partial class ProgramEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Program",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Program",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
