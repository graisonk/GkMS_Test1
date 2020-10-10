using Microsoft.EntityFrameworkCore.Migrations;

namespace GkMS_Test1.Printers.Data.Migrations
{
    public partial class modelUpd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ref_Users",
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
                    table.PrimaryKey("PK_Ref_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ref_Users");
        }
    }
}
