using Microsoft.EntityFrameworkCore.Migrations;

namespace ISOCertificate.Migrations
{
    public partial class editline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestigateLine_NominateLineType_NominateLineTypeId",
                table: "InvestigateLine");

            migrationBuilder.DropIndex(
                name: "IX_InvestigateLine_NominateLineTypeId",
                table: "InvestigateLine");

            migrationBuilder.DropColumn(
                name: "NominateLineTypeId",
                table: "InvestigateLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NominateLineTypeId",
                table: "InvestigateLine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvestigateLine_NominateLineTypeId",
                table: "InvestigateLine",
                column: "NominateLineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestigateLine_NominateLineType_NominateLineTypeId",
                table: "InvestigateLine",
                column: "NominateLineTypeId",
                principalTable: "NominateLineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
