using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediEval.Migrations
{
    public partial class MedicineIdtoID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MedicineID",
                table: "Medicines",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Medicines",
                newName: "MedicineID");
        }
    }
}
