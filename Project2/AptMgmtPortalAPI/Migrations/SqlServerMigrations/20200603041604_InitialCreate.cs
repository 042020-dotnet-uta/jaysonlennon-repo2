using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AptMgmtPortalAPI.Migrations.SqlServerMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    AgreementId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.AgreementId);
                });

            migrationBuilder.CreateTable(
                name: "BillingPeriods",
                columns: table => new
                {
                    BillingPeriodId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PeriodStart = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingPeriods", x => x.BillingPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRequests",
                columns: table => new
                {
                    MaintenanceRequestId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeOpened = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    TimeClosed = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: true),
                    OpeningUserId = table.Column<int>(nullable: false),
                    ClosingUserId = table.Column<int>(nullable: true),
                    MaintenanceRequestType = table.Column<string>(nullable: true),
                    CloseReason = table.Column<string>(nullable: true),
                    OpenNotes = table.Column<string>(nullable: true),
                    ResolutionNotes = table.Column<string>(nullable: true),
                    InternalNotes = table.Column<string>(nullable: true),
                    UnitNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequests", x => x.MaintenanceRequestId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<double>(nullable: false),
                    ResourceType = table.Column<int>(nullable: false),
                    TimePaid = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    BillingPeriodId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "ResourceUsageRates",
                columns: table => new
                {
                    ResourceUsageRateId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResourceType = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    PeriodStart = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceUsageRates", x => x.ResourceUsageRateId);
                });

            migrationBuilder.CreateTable(
                name: "SignedAgreements",
                columns: table => new
                {
                    SignedAgreementId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenantId = table.Column<int>(nullable: false),
                    AgreementId = table.Column<int>(nullable: false),
                    SignedDate = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignedAgreements", x => x.SignedAgreementId);
                });

            migrationBuilder.CreateTable(
                name: "TenantResourceUsages",
                columns: table => new
                {
                    TenantResourceUsageId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SampleTime = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    UsageAmount = table.Column<double>(nullable: false),
                    ResourceType = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantResourceUsages", x => x.TenantResourceUsageId);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    TenantId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.TenantId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UnitNumber = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserAccountType = table.Column<string>(nullable: false),
                    LoginName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ApiKey = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "Text", "Title" },
                values: new object[] { 1, "This is a really long lease agreement text", "Lease Agreement" });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "Text", "Title" },
                values: new object[] { 2, "This is a really long utility agreement text", "Utility Agreement" });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "Text", "Title" },
                values: new object[] { 3, "This is a really long internet connection agreement text", "Internet Connection Agreement" });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 1, new DateTime(2020, 6, 3, 21, 16, 4, 562, DateTimeKind.Local).AddTicks(1), new DateTime(2020, 5, 3, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 2, new DateTime(2020, 6, 3, 21, 16, 4, 562, DateTimeKind.Local).AddTicks(515), new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 3, new DateTime(2020, 6, 3, 21, 16, 4, 562, DateTimeKind.Local).AddTicks(535), new DateTime(2019, 12, 5, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 4, new DateTime(2020, 6, 3, 21, 16, 4, 562, DateTimeKind.Local).AddTicks(538), new DateTime(2019, 6, 8, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471) });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 10, null, null, "Call Plumber", null, "No water", 8, null, null, new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), "108" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 9, null, null, "Call Plumber", null, "No water", 7, null, null, new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), "107" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 8, null, null, "Call Plumber", null, "No water", 6, null, null, new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), "106" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 6, null, null, "Call Plumber", null, "No water", 4, null, null, new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), "104" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 7, null, null, "Call Plumber", null, "No water", 5, null, null, new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), "105" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 4, "CanceledByTenant", 1, "Call Plumber", null, "No water", 2, "Fixed", new DateTime(2020, 5, 3, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), "102" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 3, "CanceledByManagement", 1, "Call Plumber", null, "No water", 1, "Fixed", new DateTime(2020, 5, 3, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2019, 12, 5, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 2, "Completed", 1, "Call Comcast", null, "No Interet", 1, "Fixed", new DateTime(2020, 5, 3, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 1, "Completed", 1, "Call Plumber", "Plumbing", "No water", 1, "Fully restored.", new DateTime(2020, 6, 2, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(7072), new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 5, "CanceledByManagement", 2, "Call Plumber", null, "No water", 3, "Fixed", new DateTime(2020, 5, 3, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), "103" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 37, 100.11, 1, 0, 8, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2334) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 28, 100.11, 1, 4, 6, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2312) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 29, 100.11, 1, 3, 6, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2315) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 30, 100.11, 1, 1, 6, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2317) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 31, 100.11, 1, 2, 7, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2319) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 32, 100.11, 1, 0, 7, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2322) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 33, 100.11, 1, 4, 7, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2324) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 34, 100.11, 1, 3, 7, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2327) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 35, 100.11, 1, 1, 7, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2329) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 36, 100.11, 1, 2, 8, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2331) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 38, 100.11, 1, 4, 8, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2336) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 46, 100.11, 1, 2, 10, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2356) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 40, 100.11, 1, 1, 8, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2341) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 41, 100.11, 1, 2, 9, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2344) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 42, 100.11, 1, 0, 9, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2347) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 43, 100.11, 1, 4, 9, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2349) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 44, 100.11, 1, 3, 9, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2352) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 45, 100.11, 1, 1, 9, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2354) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 27, 100.11, 1, 0, 6, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2309) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 47, 100.11, 1, 0, 10, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2359) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 48, 100.11, 1, 4, 10, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2361) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 50, 100.11, 1, 1, 10, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2366) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 39, 100.11, 1, 3, 8, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2339) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 26, 100.11, 1, 2, 6, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2307) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 49, 100.11, 1, 3, 10, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2363) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 24, 100.11, 1, 3, 5, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2302) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 1, 100.11, 1, 2, 1, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(1762) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 25, 100.11, 1, 1, 5, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2304) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 2, 100.11, 1, 0, 1, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2230) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 3, 100.11, 1, 4, 1, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2248) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 4, 100.11, 1, 3, 1, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2251) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 5, 100.11, 1, 1, 1, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2253) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 6, 100.11, 1, 2, 2, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2257) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 8, 100.11, 1, 4, 2, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2262) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 9, 100.11, 1, 3, 2, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2264) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 10, 100.11, 1, 1, 2, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2267) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 11, 100.11, 1, 2, 3, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2270) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 7, 100.11, 1, 0, 2, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2259) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 13, 100.11, 1, 4, 3, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2275) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 23, 100.11, 1, 4, 5, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2299) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 12, 100.11, 1, 0, 3, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2273) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 21, 100.11, 1, 2, 5, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2295) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 20, 100.11, 1, 1, 4, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2292) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 19, 100.11, 1, 3, 4, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2290) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 22, 100.11, 1, 0, 5, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2297) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 17, 100.11, 1, 0, 4, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2285) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 16, 100.11, 1, 2, 4, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2282) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 15, 100.11, 1, 1, 3, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2280) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 14, 100.11, 1, 3, 3, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2278) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 18, 100.11, 1, 4, 4, new DateTime(2020, 6, 1, 21, 16, 4, 561, DateTimeKind.Local).AddTicks(2287) });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 1, new DateTime(2020, 11, 29, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(8071), new DateTime(2019, 12, 5, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 40.450000000000003, 2 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 2, new DateTime(2020, 11, 29, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(8900), new DateTime(2019, 12, 5, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 3.4500000000000002, 0 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 3, new DateTime(2020, 11, 29, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(8924), new DateTime(2019, 12, 5, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 1100.0, 4 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 4, new DateTime(2020, 11, 29, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(8927), new DateTime(2019, 12, 5, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 20.550000000000001, 3 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 5, new DateTime(2020, 11, 29, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(8929), new DateTime(2019, 12, 5, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 1.75, 1 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 7, 1, new DateTime(2020, 6, 2, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(5789), new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 7 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 10, 1, new DateTime(2020, 6, 2, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(5797), new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 10 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 9, 3, new DateTime(2020, 6, 2, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(5794), new DateTime(2019, 6, 8, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2019, 6, 8, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 9 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 8, 2, new DateTime(2020, 6, 2, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(5791), new DateTime(2019, 12, 5, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2019, 12, 5, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 8 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 6, 3, new DateTime(2020, 6, 2, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(5787), new DateTime(2019, 6, 8, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2019, 6, 8, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 6 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 2, 2, new DateTime(2020, 6, 2, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(5753), new DateTime(2019, 12, 5, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2019, 12, 5, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 2 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 4, 1, new DateTime(2020, 6, 2, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(5782), new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 4 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 3, 3, new DateTime(2020, 6, 2, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(5779), new DateTime(2019, 6, 8, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2019, 6, 8, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 3 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 1, 1, new DateTime(2020, 6, 2, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(4941), new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2020, 3, 4, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 1 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 5, 2, new DateTime(2020, 6, 2, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(5784), new DateTime(2019, 12, 5, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), new DateTime(2019, 12, 5, 21, 16, 4, 549, DateTimeKind.Local).AddTicks(8471), 5 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 17, 0, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1994), 4, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 18, 4, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1996), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 19, 3, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1998), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 20, 1, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2000), 4, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 21, 2, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2003), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 22, 0, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2005), 5, 60.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 23, 4, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2008), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 24, 3, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2010), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 25, 1, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2012), 5, 40.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 26, 2, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2015), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 27, 0, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2017), 6, 60.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 29, 3, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2022), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 30, 1, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2024), 6, 31.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 31, 2, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2026), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 32, 0, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2028), 7, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 33, 4, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2031), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 38, 4, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2043), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 34, 3, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2033), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 35, 1, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2035), 7, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 36, 2, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2039), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 37, 0, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2041), 8, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 16, 2, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1991), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 28, 4, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2019), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 15, 1, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1988), 3, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 46, 2, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2062), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 13, 4, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1983), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 39, 3, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2046), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 50, 1, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2072), 10, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 49, 3, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2069), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 48, 4, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2067), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 47, 0, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2065), 10, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 45, 1, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2060), 9, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 44, 3, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2058), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 43, 4, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2055), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 42, 0, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2053), 9, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 41, 2, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2050), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 14, 3, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1985), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 1, 2, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1426), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 3, 4, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1957), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 4, 3, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1960), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 5, 1, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1963), 1, 40.399999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 6, 2, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1966), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 7, 0, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1968), 2, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 8, 4, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1971), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 9, 3, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1973), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 10, 1, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1976), 2, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 11, 2, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1978), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 12, 0, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1980), 3, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 2, 0, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(1939), 1, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 40, 1, new DateTime(2020, 6, 1, 21, 16, 4, 560, DateTimeKind.Local).AddTicks(2048), 8, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 1, "jayson@gmail.com", "Jayson", "Lennon", "555-164-317", 3 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 9, "linda@gmail.com", "Linda", "Lopez", "555-607-558", 11 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 8, "frances@gmail.com", "Frances ", "Hook", "555-871-503", 10 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 7, "ruth@gmail.com", "Ruth ", "Williams", "555-337-777", 9 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 6, "deon@gmail.com", "Deon ", "Smith", "555-514-298", 8 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 5, "melvin@gmail.com", "Melvin", "Johnson", "555-858-445", 7 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 4, "sulav@gmail.com", "Sulav", "Aryal", "555-787-595", 6 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 3, "michael@gmail.com", "Michael", "Walker", "555-115-412", 5 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 2, "david@gmail.com", "David", "Sawyer", "555-195-162", 4 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 10, "regina@gmail.com", "Regina", "McCoy", "555-504-625", 12 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 10, 10, "110" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 9, 9, "109" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 8, 8, "108" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 6, 6, "106" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 7, 7, "107" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 4, 4, "104" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 3, 3, "103" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 2, 2, "102" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 1, 1, "101" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 5, 5, "105" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 11, "test-key11", "linda", "", "linda", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 10, "test-key10", "frances", "", "frances", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 9, "test-key9", "ruth", "", "ruth", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 8, "test-key8", "deon", "", "deon", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 7, "test-key7", "melvin", "", "melvin", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 4, "test-key4", "david", "", "david", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 5, "test-key5", "michael", "", "michael", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 3, "test-key3", "jayson", "", "jayson", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 2, "test-key2", "manager", "manager", "manager", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Manager" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 1, "test-key1", "admin", "admin", "admin", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 12, "test-key12", "regina", "", "regina", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 6, "test-key6", "sulav", "", "sulav", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 13, "test-key13", "sulav2", "", "sulav2", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitNumber",
                table: "Units",
                column: "UnitNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropTable(
                name: "BillingPeriods");

            migrationBuilder.DropTable(
                name: "MaintenanceRequests");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ResourceUsageRates");

            migrationBuilder.DropTable(
                name: "SignedAgreements");

            migrationBuilder.DropTable(
                name: "TenantResourceUsages");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
