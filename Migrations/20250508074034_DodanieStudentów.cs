using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp3.Migrations
{
    /// <inheritdoc />
    public partial class DodanieStudentów : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studenci",
                columns: table => new
                {
                    StudnetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ocena = table.Column<decimal>(type: "DECIMAL(2,1)", nullable: true),
                    Wiek = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenci", x => x.StudnetId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studenci");
        }
    }
}
