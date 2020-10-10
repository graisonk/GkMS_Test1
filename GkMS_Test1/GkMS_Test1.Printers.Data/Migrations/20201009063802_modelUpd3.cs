using Microsoft.EntityFrameworkCore.Migrations;

namespace GkMS_Test1.Printers.Data.Migrations
{
    public partial class modelUpd3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Ref_Users_RefDbId",
                table: "Ref_Users",
                column: "RefDbId");

            migrationBuilder.CreateTable(
                name: "PrinterRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrinterId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    ValFrom = table.Column<int>(nullable: false),
                    ValTo = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrinterRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrinterRates_Printers_PrinterId",
                        column: x => x.PrinterId,
                        principalTable: "Printers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrinterRates_Ref_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Ref_Users",
                        principalColumn: "RefDbId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPrinters_UserId",
                table: "UserPrinters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrinterRates_PrinterId",
                table: "PrinterRates",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_PrinterRates_UserId",
                table: "PrinterRates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPrinters_Ref_Users_UserId",
                table: "UserPrinters",
                column: "UserId",
                principalTable: "Ref_Users",
                principalColumn: "RefDbId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPrinters_Ref_Users_UserId",
                table: "UserPrinters");

            migrationBuilder.DropTable(
                name: "PrinterRates");

            migrationBuilder.DropIndex(
                name: "IX_UserPrinters_UserId",
                table: "UserPrinters");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Ref_Users_RefDbId",
                table: "Ref_Users");
        }
    }
}
