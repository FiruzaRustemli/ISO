using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ISOCertificate.Migrations
{
    public partial class SecondUserCreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "InvestigateLine");

            migrationBuilder.AddColumn<int>(
                name: "NominateLineTypeId",
                table: "InvestigateLine",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Time",
                table: "Investigate",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "BriefDecription",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifyDescription",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonLearnedId",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NominateLineTypeId",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NominatedLineType",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OccurenceCauseId",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OutcomeBuisnessId",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OutcomeEnviromentId",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OutcomePeopleId",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OutcomePropertyId",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PossibleBuisnessId",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PossibleEnviromentId",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PossiblePeopleId",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PossiblePropertyId",
                table: "Investigate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonDescription",
                table: "Investigate",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EvaluationLine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigateId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationLine_Investigate_InvestigateId",
                        column: x => x.InvestigateId,
                        principalTable: "Investigate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventLine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigateId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    Time = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLine_Investigate_InvestigateId",
                        column: x => x.InvestigateId,
                        principalTable: "Investigate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonLearned",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonLearned", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NominateLineType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NominateLineType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccurenceCause",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurenceCause", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutcomeBuisness",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeBuisness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutcomeEnviroment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeEnviroment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutcomePeople",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomePeople", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutcomeProperty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PossibleBuisness",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibleBuisness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PossibleEnviroment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibleEnviroment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PossiblePeople",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossiblePeople", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PossibleProperty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibleProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreventLine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigateId = table.Column<int>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    Person = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreventLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreventLine_Investigate_InvestigateId",
                        column: x => x.InvestigateId,
                        principalTable: "Investigate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestigateLine_NominateLineTypeId",
                table: "InvestigateLine",
                column: "NominateLineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_LessonLearnedId",
                table: "Investigate",
                column: "LessonLearnedId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_NominateLineTypeId",
                table: "Investigate",
                column: "NominateLineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_OccurenceCauseId",
                table: "Investigate",
                column: "OccurenceCauseId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_OutcomeBuisnessId",
                table: "Investigate",
                column: "OutcomeBuisnessId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_OutcomeEnviromentId",
                table: "Investigate",
                column: "OutcomeEnviromentId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_OutcomePeopleId",
                table: "Investigate",
                column: "OutcomePeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_OutcomePropertyId",
                table: "Investigate",
                column: "OutcomePropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_PossibleBuisnessId",
                table: "Investigate",
                column: "PossibleBuisnessId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_PossibleEnviromentId",
                table: "Investigate",
                column: "PossibleEnviromentId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_PossiblePeopleId",
                table: "Investigate",
                column: "PossiblePeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_PossiblePropertyId",
                table: "Investigate",
                column: "PossiblePropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationLine_InvestigateId",
                table: "EvaluationLine",
                column: "InvestigateId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLine_InvestigateId",
                table: "EventLine",
                column: "InvestigateId");

            migrationBuilder.CreateIndex(
                name: "IX_PreventLine_InvestigateId",
                table: "PreventLine",
                column: "InvestigateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_LessonLearned_LessonLearnedId",
                table: "Investigate",
                column: "LessonLearnedId",
                principalTable: "LessonLearned",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_NominateLineType_NominateLineTypeId",
                table: "Investigate",
                column: "NominateLineTypeId",
                principalTable: "NominateLineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_OccurenceCause_OccurenceCauseId",
                table: "Investigate",
                column: "OccurenceCauseId",
                principalTable: "OccurenceCause",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_OutcomeBuisness_OutcomeBuisnessId",
                table: "Investigate",
                column: "OutcomeBuisnessId",
                principalTable: "OutcomeBuisness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_OutcomeEnviroment_OutcomeEnviromentId",
                table: "Investigate",
                column: "OutcomeEnviromentId",
                principalTable: "OutcomeEnviroment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_OutcomePeople_OutcomePeopleId",
                table: "Investigate",
                column: "OutcomePeopleId",
                principalTable: "OutcomePeople",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_OutcomeProperty_OutcomePropertyId",
                table: "Investigate",
                column: "OutcomePropertyId",
                principalTable: "OutcomeProperty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_PossibleBuisness_PossibleBuisnessId",
                table: "Investigate",
                column: "PossibleBuisnessId",
                principalTable: "PossibleBuisness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_PossibleEnviroment_PossibleEnviromentId",
                table: "Investigate",
                column: "PossibleEnviromentId",
                principalTable: "PossibleEnviroment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_PossiblePeople_PossiblePeopleId",
                table: "Investigate",
                column: "PossiblePeopleId",
                principalTable: "PossiblePeople",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investigate_PossibleProperty_PossiblePropertyId",
                table: "Investigate",
                column: "PossiblePropertyId",
                principalTable: "PossibleProperty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvestigateLine_NominateLineType_NominateLineTypeId",
                table: "InvestigateLine",
                column: "NominateLineTypeId",
                principalTable: "NominateLineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_LessonLearned_LessonLearnedId",
                table: "Investigate");

            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_NominateLineType_NominateLineTypeId",
                table: "Investigate");

            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_OccurenceCause_OccurenceCauseId",
                table: "Investigate");

            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_OutcomeBuisness_OutcomeBuisnessId",
                table: "Investigate");

            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_OutcomeEnviroment_OutcomeEnviromentId",
                table: "Investigate");

            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_OutcomePeople_OutcomePeopleId",
                table: "Investigate");

            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_OutcomeProperty_OutcomePropertyId",
                table: "Investigate");

            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_PossibleBuisness_PossibleBuisnessId",
                table: "Investigate");

            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_PossibleEnviroment_PossibleEnviromentId",
                table: "Investigate");

            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_PossiblePeople_PossiblePeopleId",
                table: "Investigate");

            migrationBuilder.DropForeignKey(
                name: "FK_Investigate_PossibleProperty_PossiblePropertyId",
                table: "Investigate");

            migrationBuilder.DropForeignKey(
                name: "FK_InvestigateLine_NominateLineType_NominateLineTypeId",
                table: "InvestigateLine");

            migrationBuilder.DropTable(
                name: "EvaluationLine");

            migrationBuilder.DropTable(
                name: "EventLine");

            migrationBuilder.DropTable(
                name: "LessonLearned");

            migrationBuilder.DropTable(
                name: "NominateLineType");

            migrationBuilder.DropTable(
                name: "OccurenceCause");

            migrationBuilder.DropTable(
                name: "OutcomeBuisness");

            migrationBuilder.DropTable(
                name: "OutcomeEnviroment");

            migrationBuilder.DropTable(
                name: "OutcomePeople");

            migrationBuilder.DropTable(
                name: "OutcomeProperty");

            migrationBuilder.DropTable(
                name: "PossibleBuisness");

            migrationBuilder.DropTable(
                name: "PossibleEnviroment");

            migrationBuilder.DropTable(
                name: "PossiblePeople");

            migrationBuilder.DropTable(
                name: "PossibleProperty");

            migrationBuilder.DropTable(
                name: "PreventLine");

            migrationBuilder.DropIndex(
                name: "IX_InvestigateLine_NominateLineTypeId",
                table: "InvestigateLine");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_LessonLearnedId",
                table: "Investigate");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_NominateLineTypeId",
                table: "Investigate");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_OccurenceCauseId",
                table: "Investigate");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_OutcomeBuisnessId",
                table: "Investigate");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_OutcomeEnviromentId",
                table: "Investigate");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_OutcomePeopleId",
                table: "Investigate");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_OutcomePropertyId",
                table: "Investigate");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_PossibleBuisnessId",
                table: "Investigate");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_PossibleEnviromentId",
                table: "Investigate");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_PossiblePeopleId",
                table: "Investigate");

            migrationBuilder.DropIndex(
                name: "IX_Investigate_PossiblePropertyId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "NominateLineTypeId",
                table: "InvestigateLine");

            migrationBuilder.DropColumn(
                name: "BriefDecription",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "IdentifyDescription",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "LessonLearnedId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "NominateLineTypeId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "NominatedLineType",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "OccurenceCauseId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "OutcomeBuisnessId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "OutcomeEnviromentId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "OutcomePeopleId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "OutcomePropertyId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "PossibleBuisnessId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "PossibleEnviromentId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "PossiblePeopleId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "PossiblePropertyId",
                table: "Investigate");

            migrationBuilder.DropColumn(
                name: "ReasonDescription",
                table: "Investigate");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "InvestigateLine",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Time",
                table: "Investigate",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
