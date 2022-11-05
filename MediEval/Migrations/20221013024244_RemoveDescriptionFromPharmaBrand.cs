using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediEval.Migrations
{
    public partial class RemoveDescriptionFromPharmaBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PharmaBrands");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PharmaBrands",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
