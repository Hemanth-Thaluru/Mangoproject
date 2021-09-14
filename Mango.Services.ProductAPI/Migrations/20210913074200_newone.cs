using Microsoft.EntityFrameworkCore.Migrations;

namespace Mango.Services.ProductAPI.Migrations
{
    public partial class newone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nam",
                table: "Products",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Nam");
        }
    }
}
