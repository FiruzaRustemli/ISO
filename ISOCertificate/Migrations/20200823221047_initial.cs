using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ISOCertificate.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    PhotoURL = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Gender = table.Column<byte>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: true),
                    VerifyCode = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodilyLocationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodilyLocationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroundConditionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundConditionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroundType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IlluminationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IlluminationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IlnessTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IlnessTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InjuredActionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InjuredActionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InjuryType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InjuryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialCategorie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialCategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialReleasedie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialReleasedie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccurenceReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurenceReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccurenceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurenceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReleasedToType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleasedToType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnSafeConditionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnSafeConditionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnSafeFactType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnSafeFactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WheatherType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheatherType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuModule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuModule_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuModule_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Investigate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Activity = table.Column<string>(nullable: true),
                    OccurenceReasonId = table.Column<int>(nullable: true),
                    OccurenceTypeId = table.Column<int>(nullable: true),
                    WheatherTypeId = table.Column<int>(nullable: true),
                    GroundTypeId = table.Column<int>(nullable: true),
                    GroundConditionTypeId = table.Column<int>(nullable: true),
                    IlluminationTypeId = table.Column<int>(nullable: true),
                    ContactTypeId = table.Column<int>(nullable: true),
                    InjuryTypeId = table.Column<int>(nullable: true),
                    IlnessTypeId = table.Column<int>(nullable: true),
                    BodilyLocationTypeId = table.Column<int>(nullable: true),
                    InjuredActionTypeId = table.Column<int>(nullable: true),
                    ReleaseTypeId = table.Column<int>(nullable: true),
                    ReleasedToTypeId = table.Column<int>(nullable: true),
                    UnSafeFactTypeId = table.Column<int>(nullable: true),
                    UnSafeConditionTypeId = table.Column<int>(nullable: true),
                    DescriptionIncident = table.Column<string>(nullable: true),
                    DescriptionImmediate = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    SType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investigate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investigate_BodilyLocationType_BodilyLocationTypeId",
                        column: x => x.BodilyLocationTypeId,
                        principalTable: "BodilyLocationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_ContactType_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_GroundConditionType_GroundConditionTypeId",
                        column: x => x.GroundConditionTypeId,
                        principalTable: "GroundConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_GroundType_GroundTypeId",
                        column: x => x.GroundTypeId,
                        principalTable: "GroundType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_IlluminationType_IlluminationTypeId",
                        column: x => x.IlluminationTypeId,
                        principalTable: "IlluminationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_IlnessTypes_IlnessTypeId",
                        column: x => x.IlnessTypeId,
                        principalTable: "IlnessTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_InjuredActionType_InjuredActionTypeId",
                        column: x => x.InjuredActionTypeId,
                        principalTable: "InjuredActionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_InjuryType_InjuryTypeId",
                        column: x => x.InjuryTypeId,
                        principalTable: "InjuryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_OccurenceReason_OccurenceReasonId",
                        column: x => x.OccurenceReasonId,
                        principalTable: "OccurenceReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_OccurenceType_OccurenceTypeId",
                        column: x => x.OccurenceTypeId,
                        principalTable: "OccurenceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_ReleaseType_ReleaseTypeId",
                        column: x => x.ReleaseTypeId,
                        principalTable: "ReleaseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_ReleasedToType_ReleasedToTypeId",
                        column: x => x.ReleasedToTypeId,
                        principalTable: "ReleasedToType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_UnSafeConditionType_UnSafeConditionTypeId",
                        column: x => x.UnSafeConditionTypeId,
                        principalTable: "UnSafeConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_UnSafeFactType_UnSafeFactTypeId",
                        column: x => x.UnSafeFactTypeId,
                        principalTable: "UnSafeFactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigate_WheatherType_WheatherTypeId",
                        column: x => x.WheatherTypeId,
                        principalTable: "WheatherType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigateId = table.Column<int>(nullable: false),
                    DocumentTypeId = table.Column<int>(nullable: false),
                    DocumentName = table.Column<string>(nullable: false),
                    Attachment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Image_Investigate_InvestigateId",
                        column: x => x.InvestigateId,
                        principalTable: "Investigate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestigateLine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigateId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: false),
                    Organization = table.Column<string>(nullable: false),
                    LineTypeId = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigateLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigateLine_Investigate_InvestigateId",
                        column: x => x.InvestigateId,
                        principalTable: "Investigate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestigateLine_LineType_LineTypeId",
                        column: x => x.LineTypeId,
                        principalTable: "LineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigateId = table.Column<int>(nullable: false),
                    MaterialCategoryId = table.Column<int>(nullable: false),
                    MaterialReleasedId = table.Column<int>(nullable: false),
                    QuantityReleased = table.Column<double>(type: "float", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    Pollution = table.Column<double>(type: "float", nullable: false),
                    QuantityRecovered = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_Investigate_InvestigateId",
                        column: x => x.InvestigateId,
                        principalTable: "Investigate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Material_MaterialCategorie_MaterialCategoryId",
                        column: x => x.MaterialCategoryId,
                        principalTable: "MaterialCategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Material_MaterialReleasedie_MaterialReleasedId",
                        column: x => x.MaterialReleasedId,
                        principalTable: "MaterialReleasedie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Image_DocumentTypeId",
                table: "Image",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_InvestigateId",
                table: "Image",
                column: "InvestigateId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_BodilyLocationTypeId",
                table: "Investigate",
                column: "BodilyLocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_ContactTypeId",
                table: "Investigate",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_GroundConditionTypeId",
                table: "Investigate",
                column: "GroundConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_GroundTypeId",
                table: "Investigate",
                column: "GroundTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_IlluminationTypeId",
                table: "Investigate",
                column: "IlluminationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_IlnessTypeId",
                table: "Investigate",
                column: "IlnessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_InjuredActionTypeId",
                table: "Investigate",
                column: "InjuredActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_InjuryTypeId",
                table: "Investigate",
                column: "InjuryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_OccurenceReasonId",
                table: "Investigate",
                column: "OccurenceReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_OccurenceTypeId",
                table: "Investigate",
                column: "OccurenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_ReleaseTypeId",
                table: "Investigate",
                column: "ReleaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_ReleasedToTypeId",
                table: "Investigate",
                column: "ReleasedToTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_UnSafeConditionTypeId",
                table: "Investigate",
                column: "UnSafeConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_UnSafeFactTypeId",
                table: "Investigate",
                column: "UnSafeFactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigate_WheatherTypeId",
                table: "Investigate",
                column: "WheatherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigateLine_InvestigateId",
                table: "InvestigateLine",
                column: "InvestigateId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigateLine_LineTypeId",
                table: "InvestigateLine",
                column: "LineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_InvestigateId",
                table: "Material",
                column: "InvestigateId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_MaterialCategoryId",
                table: "Material",
                column: "MaterialCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_MaterialReleasedId",
                table: "Material",
                column: "MaterialReleasedId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModule_MenuId",
                table: "MenuModule",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModule_ModuleId",
                table: "MenuModule",
                column: "ModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "InvestigateLine");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "MenuModule");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "LineType");

            migrationBuilder.DropTable(
                name: "Investigate");

            migrationBuilder.DropTable(
                name: "MaterialCategorie");

            migrationBuilder.DropTable(
                name: "MaterialReleasedie");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "BodilyLocationType");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropTable(
                name: "GroundConditionType");

            migrationBuilder.DropTable(
                name: "GroundType");

            migrationBuilder.DropTable(
                name: "IlluminationType");

            migrationBuilder.DropTable(
                name: "IlnessTypes");

            migrationBuilder.DropTable(
                name: "InjuredActionType");

            migrationBuilder.DropTable(
                name: "InjuryType");

            migrationBuilder.DropTable(
                name: "OccurenceReason");

            migrationBuilder.DropTable(
                name: "OccurenceType");

            migrationBuilder.DropTable(
                name: "ReleaseType");

            migrationBuilder.DropTable(
                name: "ReleasedToType");

            migrationBuilder.DropTable(
                name: "UnSafeConditionType");

            migrationBuilder.DropTable(
                name: "UnSafeFactType");

            migrationBuilder.DropTable(
                name: "WheatherType");
        }
    }
}
