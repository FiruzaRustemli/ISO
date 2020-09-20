using Microsoft.EntityFrameworkCore.Migrations;

namespace ISOCertificate.Migrations
{
    public partial class investformfact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionIncident",
                table: "Investigate",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvestigateUnsafeFact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigateId = table.Column<int>(nullable: true),
                    UnSafeFactTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigateUnsafeFact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigateUnsafeFact_Investigate_InvestigateId",
                        column: x => x.InvestigateId,
                        principalTable: "Investigate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvestigateUnsafeFact_UnSafeFactType_UnSafeFactTypeId",
                        column: x => x.UnSafeFactTypeId,
                        principalTable: "UnSafeFactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestigateUnsafeFact_InvestigateId",
                table: "InvestigateUnsafeFact",
                column: "InvestigateId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigateUnsafeFact_UnSafeFactTypeId",
                table: "InvestigateUnsafeFact",
                column: "UnSafeFactTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestigateUnsafeFact");

            migrationBuilder.DropColumn(
                name: "DescriptionIncident",
                table: "Investigate");
        }
    }
}
