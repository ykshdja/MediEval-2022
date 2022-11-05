using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediEval.Migrations
{
    public partial class pharmacyMedicineChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacy_Medicines_Medicines_Pharmacy_ID",
                table: "Pharmacy_Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacy_Medicines_Pharmacies_Medicine_ID",
                table: "Pharmacy_Medicines");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacy_Medicines_Medicines_Medicine_ID",
                table: "Pharmacy_Medicines",
                column: "Medicine_ID",
                principalTable: "Medicines",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacy_Medicines_Pharmacies_Pharmacy_ID",
                table: "Pharmacy_Medicines",
                column: "Pharmacy_ID",
                principalTable: "Pharmacies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacy_Medicines_Medicines_Medicine_ID",
                table: "Pharmacy_Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacy_Medicines_Pharmacies_Pharmacy_ID",
                table: "Pharmacy_Medicines");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacy_Medicines_Medicines_Pharmacy_ID",
                table: "Pharmacy_Medicines",
                column: "Pharmacy_ID",
                principalTable: "Medicines",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacy_Medicines_Pharmacies_Medicine_ID",
                table: "Pharmacy_Medicines",
                column: "Medicine_ID",
                principalTable: "Pharmacies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
