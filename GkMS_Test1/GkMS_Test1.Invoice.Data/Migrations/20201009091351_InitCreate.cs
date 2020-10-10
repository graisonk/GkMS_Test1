using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GkMS_Test1.Invoice.Data.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Printers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(300)", nullable: false),
                    Serial = table.Column<string>(type: "varchar(50)", nullable: true),
                    Hsn = table.Column<string>(type: "varchar(10)", nullable: true),
                    Cgst = table.Column<double>(nullable: false),
                    Sgst = table.Column<double>(nullable: false),
                    SearchableName = table.Column<string>(type: "varchar(100)", nullable: true),
                    RefDbId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(30)", nullable: true),
                    GstNo = table.Column<string>(type: "varchar(20)", nullable: true),
                    PanNo = table.Column<string>(type: "varchar(20)", nullable: true),
                    RefDbId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    PrinterId = table.Column<int>(nullable: false),
                    InvNo = table.Column<int>(nullable: false),
                    ReadingPrev = table.Column<int>(nullable: false),
                    ReadingCurr = table.Column<int>(nullable: false),
                    AmtTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Printers_PrinterId",
                        column: x => x.PrinterId,
                        principalTable: "Printers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    Rate = table.Column<double>(nullable: false),
                    RefDbId = table.Column<int>(nullable: false)
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
                        name: "FK_PrinterRates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserPrinters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    PrinterId = table.Column<int>(nullable: false),
                    DateInstall = table.Column<DateTime>(nullable: false),
                    Period = table.Column<string>(type: "varchar(15)", nullable: true),
                    DepositAmt = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    RefDbId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrinters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPrinters_Printers_PrinterId",
                        column: x => x.PrinterId,
                        principalTable: "Printers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPrinters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PrinterId",
                table: "Invoices",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrinterRates_PrinterId",
                table: "PrinterRates",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_PrinterRates_UserId",
                table: "PrinterRates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrinters_PrinterId",
                table: "UserPrinters",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrinters_UserId",
                table: "UserPrinters",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "PrinterRates");

            migrationBuilder.DropTable(
                name: "UserPrinters");

            migrationBuilder.DropTable(
                name: "Printers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
