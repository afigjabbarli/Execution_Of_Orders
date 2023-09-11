using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok.Migrations
{
    public partial class Add_table_to_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "Password",
                value: "$2a$11$KZM89PZQL/lCHM7JCLnTzeAwUrRuyQANoP07AjsY8JGlSUvBmrX3G");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "Password",
                value: "$2a$11$nsqeTYFg2NjNjVIhzjo9gu2YaStErb05wHcCLrgopSmdW7yMafMOS");
        }
    }
}
