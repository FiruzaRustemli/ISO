using Microsoft.EntityFrameworkCore.Migrations;

namespace ISOCertificate.Migrations
{
    public partial class investigateNoTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "No",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Investigate",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "No",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Investigate");
        }
    }
}
