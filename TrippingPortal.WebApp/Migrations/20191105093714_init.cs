using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TrippingPortal.WebApp.Migrations
{
    public partial class init : Migration
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
                name: "EventClassifications",
                columns: table => new
                {
                    EventClassificationId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventClassifications", x => x.EventClassificationId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    EventStartTime = table.Column<DateTime>(nullable: false),
                    EventEndTime = table.Column<DateTime>(nullable: false),
                    EventClassificationId = table.Column<int>(nullable: false),
                    PreliminaryReportFilePath = table.Column<string>(nullable: true),
                    RldcFinalReportFilePath = table.Column<string>(nullable: true),
                    UtilityFinalReportFilePath = table.Column<string>(nullable: true),
                    PcmDiscussionReportFilePath = table.Column<string>(nullable: true),
                    UtilityFinalReportUploadTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_EventClassifications_EventClassificationId",
                        column: x => x.EventClassificationId,
                        principalTable: "EventClassifications",
                        principalColumn: "EventClassificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trippings",
                columns: table => new
                {
                    TrippingId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(nullable: false),
                    ForeignId = table.Column<int>(nullable: false),
                    ElementName = table.Column<string>(nullable: false),
                    ElementType = table.Column<string>(nullable: false),
                    OutageTime = table.Column<DateTime>(nullable: false),
                    RevivalTime = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: false),
                    Remarks = table.Column<string>(nullable: false),
                    OutageType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trippings", x => x.TrippingId);
                    table.ForeignKey(
                        name: "FK_Trippings_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
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
                    Discriminator = table.Column<string>(nullable: false),
                    EventId = table.Column<int>(nullable: true),
                    TrippingId = table.Column<int>(nullable: true),
                    TrippingId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Trippings_TrippingId",
                        column: x => x.TrippingId,
                        principalTable: "Trippings",
                        principalColumn: "TrippingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Trippings_TrippingId1",
                        column: x => x.TrippingId1,
                        principalTable: "Trippings",
                        principalColumn: "TrippingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    TrippingId = table.Column<int>(nullable: true),
                    TrippingId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Owners_Trippings_TrippingId",
                        column: x => x.TrippingId,
                        principalTable: "Trippings",
                        principalColumn: "TrippingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Owners_Trippings_TrippingId1",
                        column: x => x.TrippingId1,
                        principalTable: "Trippings",
                        principalColumn: "TrippingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
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
                name: "EventELs",
                columns: table => new
                {
                    EventELId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(nullable: false),
                    Filename = table.Column<string>(nullable: true),
                    UploadUtilityId = table.Column<string>(nullable: true),
                    UploadedById = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 11, 5, 15, 7, 14, 280, DateTimeKind.Local).AddTicks(2067)),
                    UpdatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 11, 5, 15, 7, 14, 282, DateTimeKind.Local).AddTicks(3567))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventELs", x => x.EventELId);
                    table.ForeignKey(
                        name: "FK_EventELs_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventELs_AspNetUsers_UploadUtilityId",
                        column: x => x.UploadUtilityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventELs_AspNetUsers_UploadedById",
                        column: x => x.UploadedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrippingDRs",
                columns: table => new
                {
                    TrippingDRId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrippingId = table.Column<int>(nullable: false),
                    IsOtherEndOrLV = table.Column<bool>(nullable: false),
                    Filename = table.Column<string>(nullable: true),
                    UploadUtilityId = table.Column<string>(nullable: true),
                    FileUploadTime = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 11, 5, 15, 7, 14, 283, DateTimeKind.Local).AddTicks(7001)),
                    UpdatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 11, 5, 15, 7, 14, 283, DateTimeKind.Local).AddTicks(7196))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrippingDRs", x => x.TrippingDRId);
                    table.ForeignKey(
                        name: "FK_TrippingDRs_Trippings_TrippingId",
                        column: x => x.TrippingId,
                        principalTable: "Trippings",
                        principalColumn: "TrippingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrippingDRs_AspNetUsers_UploadUtilityId",
                        column: x => x.UploadUtilityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrippingELs",
                columns: table => new
                {
                    TrippingELId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrippingId = table.Column<int>(nullable: false),
                    Filename = table.Column<string>(nullable: true),
                    UploadUtilityId = table.Column<string>(nullable: true),
                    FileUploadTime = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 11, 5, 15, 7, 14, 283, DateTimeKind.Local).AddTicks(5905)),
                    UpdatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 11, 5, 15, 7, 14, 283, DateTimeKind.Local).AddTicks(6124))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrippingELs", x => x.TrippingELId);
                    table.ForeignKey(
                        name: "FK_TrippingELs_Trippings_TrippingId",
                        column: x => x.TrippingId,
                        principalTable: "Trippings",
                        principalColumn: "TrippingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrippingELs_AspNetUsers_UploadUtilityId",
                        column: x => x.UploadUtilityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrippingBayOwners",
                columns: table => new
                {
                    TrippingId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    TrippingBayOwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrippingBayOwners", x => new { x.TrippingId, x.OwnerId });
                    table.ForeignKey(
                        name: "FK_TrippingBayOwners_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrippingBayOwners_Trippings_TrippingId",
                        column: x => x.TrippingId,
                        principalTable: "Trippings",
                        principalColumn: "TrippingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrippingElementOwners",
                columns: table => new
                {
                    TrippingId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    TrippingElementOwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrippingElementOwners", x => new { x.TrippingId, x.OwnerId });
                    table.ForeignKey(
                        name: "FK_TrippingElementOwners_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrippingElementOwners_Trippings_TrippingId",
                        column: x => x.TrippingId,
                        principalTable: "Trippings",
                        principalColumn: "TrippingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtilityOwners",
                columns: table => new
                {
                    UtilityId = table.Column<string>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    UtilityOwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityOwners", x => new { x.UtilityId, x.OwnerId });
                    table.ForeignKey(
                        name: "FK_UtilityOwners_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtilityOwners_AspNetUsers_UtilityId",
                        column: x => x.UtilityId,
                        principalTable: "AspNetUsers",
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
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EventId",
                table: "AspNetUsers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TrippingId",
                table: "AspNetUsers",
                column: "TrippingId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TrippingId1",
                table: "AspNetUsers",
                column: "TrippingId1");

            migrationBuilder.CreateIndex(
                name: "IX_EventClassifications_Name",
                table: "EventClassifications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventELs_EventId",
                table: "EventELs",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventELs_UploadUtilityId",
                table: "EventELs",
                column: "UploadUtilityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventELs_UploadedById",
                table: "EventELs",
                column: "UploadedById");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventClassificationId",
                table: "Events",
                column: "EventClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_Name",
                table: "Owners",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_TrippingId",
                table: "Owners",
                column: "TrippingId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_TrippingId1",
                table: "Owners",
                column: "TrippingId1");

            migrationBuilder.CreateIndex(
                name: "IX_TrippingBayOwners_OwnerId",
                table: "TrippingBayOwners",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrippingDRs_TrippingId",
                table: "TrippingDRs",
                column: "TrippingId");

            migrationBuilder.CreateIndex(
                name: "IX_TrippingDRs_UploadUtilityId",
                table: "TrippingDRs",
                column: "UploadUtilityId");

            migrationBuilder.CreateIndex(
                name: "IX_TrippingElementOwners_OwnerId",
                table: "TrippingElementOwners",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrippingELs_TrippingId",
                table: "TrippingELs",
                column: "TrippingId");

            migrationBuilder.CreateIndex(
                name: "IX_TrippingELs_UploadUtilityId",
                table: "TrippingELs",
                column: "UploadUtilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Trippings_EventId",
                table: "Trippings",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilityOwners_OwnerId",
                table: "UtilityOwners",
                column: "OwnerId");
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
                name: "EventELs");

            migrationBuilder.DropTable(
                name: "TrippingBayOwners");

            migrationBuilder.DropTable(
                name: "TrippingDRs");

            migrationBuilder.DropTable(
                name: "TrippingElementOwners");

            migrationBuilder.DropTable(
                name: "TrippingELs");

            migrationBuilder.DropTable(
                name: "UtilityOwners");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Trippings");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventClassifications");
        }
    }
}
