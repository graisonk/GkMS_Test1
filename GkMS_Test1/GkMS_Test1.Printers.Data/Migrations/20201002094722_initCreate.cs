using Microsoft.EntityFrameworkCore.Migrations;

namespace GkMS_Test1.Printers.Data.Migrations
{
    public partial class initCreate : Migration
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
                    SearchableName = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Printers");
        }
    }
}
