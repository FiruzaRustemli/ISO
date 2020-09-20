using Microsoft.EntityFrameworkCore.Migrations;

namespace ISOCertificate.Migrations
{
    public partial class UnsafeIdTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_UnSafeConditionType_UnSafeConditionTypeId",
                table: "Investigate");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_UnSafeConditionTypeId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "UnSafeConditionTypeId",
                table: "Investigate");

            migrationBuilder.AddColumn<int>(
                name: "UnSafeConditionTypeId1",
                table: "Investigate",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_UnSafeConditionTypeId1",
                table: "Investigate",
                column: "UnSafeConditionTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_UnSafeConditionType_UnSafeConditionTypeId1",
                table: "Investigate",
                column: "UnSafeConditionTypeId1",
                principalTable: "UnSafeConditionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_UnSafeConditionType_UnSafeConditionTypeId1",
                table: "Investigate");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_UnSafeConditionTypeId1",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "UnSafeConditionTypeId1",
                table: "Investigate");

            migrationBuilder.AddColumn<int>(
                name: "UnSafeConditionTypeId",
                table: "Investigate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_UnSafeConditionTypeId",
                table: "Investigate",
                column: "UnSafeConditionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_UnSafeConditionType_UnSafeConditionTypeId",
                table: "Investigate",
                column: "UnSafeConditionTypeId",
                principalTable: "UnSafeConditionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
