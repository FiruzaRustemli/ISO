using Microsoft.EntityFrameworkCore.Migrations;

namespace ISOCertificate.Migrations
{
    public partial class nominateEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_NominateLineType_NominateLineTypeId",
                table: "Investigate");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_NominateLineTypeId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "NominateLineTypeId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "NominatedLineType",
                table: "Investigate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NominateLineTypeId",
                table: "Investigate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NominatedLineType",
                table: "Investigate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_NominateLineTypeId",
                table: "Investigate",
                column: "NominateLineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_NominateLineType_NominateLineTypeId",
                table: "Investigate",
                column: "NominateLineTypeId",
                principalTable: "NominateLineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
