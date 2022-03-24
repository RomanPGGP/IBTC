using Microsoft.EntityFrameworkCore.Migrations;

namespace CAIBT.Data.Migrations
{
    public partial class Ord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CostumerId",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostumerId",
                table: "Orders");
        }
    }
}
