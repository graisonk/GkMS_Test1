using Microsoft.EntityFrameworkCore.Migrations;

namespace GkMS_Test1.Printers.Data.Migrations
{
    public partial class modelUpd4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrinterRates_Ref_Users_UserId",
                table: "PrinterRates");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPrinters_Ref_Users_UserId",
                table: "UserPrinters");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Ref_Users_RefDbId",
                table: "Ref_Users");

            migrationBuilder.AddForeignKey(
                name: "FK_PrinterRates_Ref_Users_UserId",
                table: "PrinterRates",
                column: "UserId",
                principalTable: "Ref_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPrinters_Ref_Users_UserId",
                table: "UserPrinters",
                column: "UserId",
                principalTable: "Ref_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrinterRates_Ref_Users_UserId",
                table: "PrinterRates");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPrinters_Ref_Users_UserId",
                table: "UserPrinters");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Ref_Users_RefDbId",
                table: "Ref_Users",
                column: "RefDbId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrinterRates_Ref_Users_UserId",
                table: "PrinterRates",
                column: "UserId",
                principalTable: "Ref_Users",
                principalColumn: "RefDbId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPrinters_Ref_Users_UserId",
                table: "UserPrinters",
                column: "UserId",
                principalTable: "Ref_Users",
                principalColumn: "RefDbId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
