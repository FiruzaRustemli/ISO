using Microsoft.EntityFrameworkCore.Migrations;

namespace ISOCertificate.Migrations
{
    public partial class investUnCondTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestigateUnsafe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigateId = table.Column<int>(nullable: true),
                    UnSafeConditionTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigateUnsafe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigateUnsafe_Investigate_InvestigateId",
                        column: x => x.InvestigateId,
                        principalTable: "Investigate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvestigateUnsafe_UnSafeConditionType_UnSafeConditionTypeId",
                        column: x => x.UnSafeConditionTypeId,
                        principalTable: "UnSafeConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestigateUnsafe_InvestigateId",
                table: "InvestigateUnsafe",
                column: "InvestigateId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigateUnsafe_UnSafeConditionTypeId",
                table: "InvestigateUnsafe",
                column: "UnSafeConditionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestigateUnsafe");
        }
    }
}
