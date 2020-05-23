using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AptMgmtPortal.Data.AptMgmtMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingPeriods",
                columns: table => new
                {
                    BillingPeriodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodStart = table.Column<DateTimeOffset>(nullable: false),
                    PeriodEnd = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingPeriods", x => x.BillingPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRequestTypes",
                columns: table => new
                {
                    MaintenanceRequestTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequestTypes", x => x.MaintenanceRequestTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAccountType = table.Column<string>(nullable: false),
                    LoginName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRequests",
                columns: table => new
                {
                    MaintenanceRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOpened = table.Column<DateTimeOffset>(nullable: false),
                    TimeClosed = table.Column<DateTimeOffset>(nullable: true),
                    OpeningUserId = table.Column<int>(nullable: false),
                    ClosingUserId = table.Column<int>(nullable: false),
                    MaintenanceRequestTypeId = table.Column<int>(nullable: false),
                    OpenNotes = table.Column<string>(nullable: true),
                    ResolutionNotes = table.Column<string>(nullable: true),
                    InternalNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequests", x => x.MaintenanceRequestId);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Users_ClosingUserId",
                        column: x => x.ClosingUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_MaintenanceRequestTypes_MaintenanceRequestTypeId",
                        column: x => x.MaintenanceRequestTypeId,
                        principalTable: "MaintenanceRequestTypes",
                        principalColumn: "MaintenanceRequestTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Users_OpeningUserId",
                        column: x => x.OpeningUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tenents",
                columns: table => new
                {
                    TenentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitNumber = table.Column<string>(nullable: true),
                    IsPresent = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenents", x => x.TenentId);
                    table.ForeignKey(
                        name: "FK_Tenents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PaymentFor = table.Column<int>(nullable: false),
                    Timepaid = table.Column<DateTimeOffset>(nullable: true),
                    BillingPeriodId = table.Column<int>(nullable: false),
                    TenentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_BillingPeriods_BillingPeriodId",
                        column: x => x.BillingPeriodId,
                        principalTable: "BillingPeriods",
                        principalColumn: "BillingPeriodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Tenents_TenentId",
                        column: x => x.TenentId,
                        principalTable: "Tenents",
                        principalColumn: "TenentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantResourceUsages",
                columns: table => new
                {
                    TenantResourceUsageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SampleTime = table.Column<DateTimeOffset>(nullable: false),
                    UsageAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ResourceType = table.Column<int>(nullable: false),
                    TenentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantResourceUsages", x => x.TenantResourceUsageId);
                    table.ForeignKey(
                        name: "FK_TenantResourceUsages_Tenents_TenentId",
                        column: x => x.TenentId,
                        principalTable: "Tenents",
                        principalColumn: "TenentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_ClosingUserId",
                table: "MaintenanceRequests",
                column: "ClosingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_MaintenanceRequestTypeId",
                table: "MaintenanceRequests",
                column: "MaintenanceRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_OpeningUserId",
                table: "MaintenanceRequests",
                column: "OpeningUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BillingPeriodId",
                table: "Payments",
                column: "BillingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TenentId",
                table: "Payments",
                column: "TenentId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantResourceUsages_TenentId",
                table: "TenantResourceUsages",
                column: "TenentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenents_UserId",
                table: "Tenents",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceRequests");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "TenantResourceUsages");

            migrationBuilder.DropTable(
                name: "MaintenanceRequestTypes");

            migrationBuilder.DropTable(
                name: "BillingPeriods");

            migrationBuilder.DropTable(
                name: "Tenents");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
