using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GkMS_Test1.Printers.Data.Migrations
{
    public partial class modelUpd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Status = table.Column<int>(nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPrinters_PrinterId",
                table: "UserPrinters",
                column: "PrinterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPrinters");
        }
    }
}
