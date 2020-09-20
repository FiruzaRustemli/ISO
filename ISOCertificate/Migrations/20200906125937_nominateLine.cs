using Microsoft.EntityFrameworkCore.Migrations;

namespace ISOCertificate.Migrations
{
    public partial class nominateLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NominateLine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigateId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Organization = table.Column<string>(nullable: true),
                    TeamTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NominateLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NominateLine_Investigate_InvestigateId",
                        column: x => x.InvestigateId,
                        principalTable: "Investigate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NominateLine_NominateLineType_TeamTypeId",
                        column: x => x.TeamTypeId,
                        principalTable: "NominateLineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NominateLine_InvestigateId",
                table: "NominateLine",
                column: "InvestigateId");

            migrationBuilder.CreateIndex(
                name: "IX_NominateLine_TeamTypeId",
                table: "NominateLine",
                column: "TeamTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NominateLine");
        }
    }
}
