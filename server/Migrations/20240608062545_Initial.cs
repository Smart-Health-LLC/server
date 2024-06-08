using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseScheduleFamilies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseScheduleFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SleepPeriods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserScheduleAttemptId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Bio = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    SignUpDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseSchedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TotalSleepTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    BaseScheduleFamilyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseSchedules_BaseScheduleFamilies_BaseScheduleFamilyId",
                        column: x => x.BaseScheduleFamilyId,
                        principalTable: "BaseScheduleFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FallingAsleepMarks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SleepPeriodId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FallingAsleepMarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FallingAsleepMarks_SleepPeriods_SleepPeriodId",
                        column: x => x.SleepPeriodId,
                        principalTable: "SleepPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissedChecks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SleepPeriodId = table.Column<long>(type: "bigint", nullable: false),
                    Day = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissedChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissedChecks_SleepPeriods_SleepPeriodId",
                        column: x => x.SleepPeriodId,
                        principalTable: "SleepPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oversleeps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SleepPeriodId = table.Column<long>(type: "bigint", nullable: false),
                    Day = table.Column<DateOnly>(type: "date", nullable: false),
                    Amount = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oversleeps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oversleeps_SleepPeriods_SleepPeriodId",
                        column: x => x.SleepPeriodId,
                        principalTable: "SleepPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkippedPeriods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SleepPeriodId = table.Column<long>(type: "bigint", nullable: false),
                    Day = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkippedPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkippedPeriods_SleepPeriods_SleepPeriodId",
                        column: x => x.SleepPeriodId,
                        principalTable: "SleepPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SleepPeriodChanges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SleepPeriodId = table.Column<long>(type: "bigint", nullable: false),
                    TimeStart = table.Column<TimeSpan>(type: "interval", nullable: false),
                    TimeEnd = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CreatedAd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepPeriodChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SleepPeriodChanges_SleepPeriods_SleepPeriodId",
                        column: x => x.SleepPeriodId,
                        principalTable: "SleepPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WakingUpMarks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SleepPeriodId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WakingUpMarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WakingUpMarks_SleepPeriods_SleepPeriodId",
                        column: x => x.SleepPeriodId,
                        principalTable: "SleepPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Captures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TypeName = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Captures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Captures_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JwtLastTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ExpiryDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JwtLastTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JwtLastTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseSleepPeriods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    BaseScheduleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseSleepPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseSleepPeriods_BaseSchedules_BaseScheduleId",
                        column: x => x.BaseScheduleId,
                        principalTable: "BaseSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserScheduleAttempts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDropped = table.Column<bool>(type: "boolean", nullable: false),
                    IsAdopted = table.Column<bool>(type: "boolean", nullable: false),
                    DateStarted = table.Column<DateOnly>(type: "date", nullable: false),
                    DateFinished = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BaseScheduleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserScheduleAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserScheduleAttempts_BaseSchedules_BaseScheduleId",
                        column: x => x.BaseScheduleId,
                        principalTable: "BaseSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserScheduleAttempts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    UserScheduleAttemptId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_UserScheduleAttempts_UserScheduleAttemptId",
                        column: x => x.UserScheduleAttemptId,
                        principalTable: "UserScheduleAttempts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NoteSleepPeriod",
                columns: table => new
                {
                    NotesId = table.Column<long>(type: "bigint", nullable: false),
                    SleepPeriodsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteSleepPeriod", x => new { x.NotesId, x.SleepPeriodsId });
                    table.ForeignKey(
                        name: "FK_NoteSleepPeriod_Notes_NotesId",
                        column: x => x.NotesId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteSleepPeriod_SleepPeriods_SleepPeriodsId",
                        column: x => x.SleepPeriodsId,
                        principalTable: "SleepPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BaseScheduleFamilies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Biphasic" },
                    { 2L, "Everyman" },
                    { 3L, "Dual core" },
                    { 4L, "Tri core" },
                    { 5L, "Core-only" },
                    { 6L, "Nap-only" },
                    { 7L, "Flexible" },
                    { 8L, "Non-reducing" }
                });

            migrationBuilder.InsertData(
                table: "BaseSchedules",
                columns: new[] { "Id", "BaseScheduleFamilyId", "Description", "Name", "ShortName", "TotalSleepTime" },
                values: new object[,]
                {
                    { 1L, 1L, "", "BiphasicX", "", new TimeSpan(0, 5, 0, 0, 0) },
                    { 2L, 1L, "", "Siesta", "", new TimeSpan(0, 5, 0, 0, 0) },
                    { 3L, 1L, "", "Siesta Ext", "", new TimeSpan(0, 5, 0, 0, 0) },
                    { 4L, 3L, "", "Bimaxion", "", new TimeSpan(0, 5, 0, 0, 0) },
                    { 5L, 2L, "", "Everyman 1", "E1", new TimeSpan(0, 5, 0, 0, 0) },
                    { 6L, 2L, "", "Everyman 1 Ext", "E1-ext", new TimeSpan(0, 5, 0, 0, 0) },
                    { 7L, 2L, "", "Everyman 2", "E2", new TimeSpan(0, 5, 0, 0, 0) },
                    { 8L, 2L, "", "Everyman 3", "E3", new TimeSpan(0, 5, 0, 0, 0) },
                    { 9L, 2L, "", "Everyman 3 Ext", "E3-ext", new TimeSpan(0, 5, 0, 0, 0) },
                    { 10L, 2L, "", "Everyman 4", "E4", new TimeSpan(0, 5, 0, 0, 0) },
                    { 11L, 2L, "", "Everyman 5", "E5", new TimeSpan(0, 5, 0, 0, 0) },
                    { 12L, 6L, "", "Dymaxion", "", new TimeSpan(0, 5, 0, 0, 0) },
                    { 13L, 3L, "", "Dual Core 1", "DC1", new TimeSpan(0, 5, 0, 0, 0) },
                    { 14L, 3L, "", "Dual Core 1 Ext", "DC1-ext", new TimeSpan(0, 5, 0, 0, 0) },
                    { 15L, 3L, "", "Dual Core 2", "DC2", new TimeSpan(0, 5, 0, 0, 0) },
                    { 16L, 3L, "", "Dual Core 3", "DC3", new TimeSpan(0, 5, 0, 0, 0) },
                    { 17L, 3L, "", "Dual Core 4", "DC4", new TimeSpan(0, 5, 0, 0, 0) },
                    { 18L, 4L, "", "Triphasic", "", new TimeSpan(0, 5, 0, 0, 0) },
                    { 19L, 4L, "", "Triphasic Ext", "", new TimeSpan(0, 5, 0, 0, 0) },
                    { 20L, 5L, "", "Segmented", "", new TimeSpan(0, 5, 0, 0, 0) },
                    { 21L, 5L, "", "Segmented Ext", "", new TimeSpan(0, 5, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "BaseSleepPeriods",
                columns: new[] { "Id", "BaseScheduleId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1L, 1L, new TimeOnly(23, 6, 55), new TimeOnly(5, 23, 34) },
                    { 2L, 1L, new TimeOnly(17, 57, 37), new TimeOnly(19, 30, 15) },
                    { 3L, 1L, new TimeOnly(14, 11, 26), new TimeOnly(11, 3, 4) },
                    { 4L, 2L, new TimeOnly(0, 54, 39), new TimeOnly(19, 47, 27) },
                    { 5L, 2L, new TimeOnly(5, 58, 43), new TimeOnly(9, 47, 49) },
                    { 6L, 2L, new TimeOnly(0, 10, 54), new TimeOnly(23, 5, 40) },
                    { 7L, 3L, new TimeOnly(12, 45, 47), new TimeOnly(4, 49, 49) },
                    { 8L, 3L, new TimeOnly(6, 37, 55), new TimeOnly(1, 36, 8) },
                    { 9L, 3L, new TimeOnly(13, 33, 29), new TimeOnly(22, 16, 43) },
                    { 10L, 4L, new TimeOnly(13, 28, 32), new TimeOnly(4, 43, 26) },
                    { 11L, 4L, new TimeOnly(11, 14, 26), new TimeOnly(7, 3, 9) },
                    { 12L, 4L, new TimeOnly(14, 29, 22), new TimeOnly(23, 19, 36) },
                    { 13L, 5L, new TimeOnly(12, 11, 54), new TimeOnly(19, 10, 19) },
                    { 14L, 5L, new TimeOnly(2, 26, 42), new TimeOnly(6, 53, 41) },
                    { 15L, 5L, new TimeOnly(7, 29, 12), new TimeOnly(7, 42, 45) },
                    { 16L, 6L, new TimeOnly(14, 25, 43), new TimeOnly(0, 56, 52) },
                    { 17L, 6L, new TimeOnly(23, 31, 42), new TimeOnly(5, 59, 19) },
                    { 18L, 6L, new TimeOnly(20, 46, 56), new TimeOnly(1, 47, 42) },
                    { 19L, 7L, new TimeOnly(23, 30, 51), new TimeOnly(14, 3, 42) },
                    { 20L, 7L, new TimeOnly(12, 14, 0), new TimeOnly(6, 10, 31) },
                    { 21L, 7L, new TimeOnly(4, 26, 44), new TimeOnly(4, 7, 43) },
                    { 22L, 8L, new TimeOnly(22, 11, 4), new TimeOnly(6, 11, 19) },
                    { 23L, 8L, new TimeOnly(17, 50, 15), new TimeOnly(4, 44, 19) },
                    { 24L, 8L, new TimeOnly(3, 21, 24), new TimeOnly(19, 41, 42) },
                    { 25L, 9L, new TimeOnly(1, 28, 58), new TimeOnly(11, 58, 47) },
                    { 26L, 9L, new TimeOnly(0, 20, 1), new TimeOnly(22, 46, 2) },
                    { 27L, 9L, new TimeOnly(2, 56, 30), new TimeOnly(22, 30, 16) },
                    { 28L, 10L, new TimeOnly(10, 25, 30), new TimeOnly(5, 3, 58) },
                    { 29L, 10L, new TimeOnly(21, 44, 30), new TimeOnly(3, 6, 52) },
                    { 30L, 10L, new TimeOnly(15, 57, 25), new TimeOnly(21, 5, 12) },
                    { 31L, 11L, new TimeOnly(1, 57, 0), new TimeOnly(12, 44, 26) },
                    { 32L, 11L, new TimeOnly(14, 44, 59), new TimeOnly(9, 37, 34) },
                    { 33L, 11L, new TimeOnly(11, 55, 42), new TimeOnly(13, 30, 54) },
                    { 34L, 12L, new TimeOnly(8, 13, 11), new TimeOnly(5, 30, 19) },
                    { 35L, 12L, new TimeOnly(3, 22, 51), new TimeOnly(17, 31, 34) },
                    { 36L, 12L, new TimeOnly(17, 16, 31), new TimeOnly(7, 16, 7) },
                    { 37L, 13L, new TimeOnly(2, 54, 2), new TimeOnly(17, 55, 41) },
                    { 38L, 13L, new TimeOnly(9, 32, 53), new TimeOnly(15, 52, 29) },
                    { 39L, 13L, new TimeOnly(16, 38, 24), new TimeOnly(23, 18, 4) },
                    { 40L, 14L, new TimeOnly(4, 21, 8), new TimeOnly(12, 40, 29) },
                    { 41L, 14L, new TimeOnly(8, 37, 20), new TimeOnly(12, 19, 31) },
                    { 42L, 14L, new TimeOnly(9, 4, 13), new TimeOnly(4, 48, 49) },
                    { 43L, 15L, new TimeOnly(7, 17, 42), new TimeOnly(20, 26, 24) },
                    { 44L, 15L, new TimeOnly(20, 55, 36), new TimeOnly(3, 55, 46) },
                    { 45L, 15L, new TimeOnly(20, 32, 54), new TimeOnly(17, 20, 7) },
                    { 46L, 16L, new TimeOnly(23, 5, 50), new TimeOnly(13, 9, 42) },
                    { 47L, 16L, new TimeOnly(19, 21, 43), new TimeOnly(6, 52, 39) },
                    { 48L, 16L, new TimeOnly(23, 19, 51), new TimeOnly(2, 24, 9) },
                    { 49L, 17L, new TimeOnly(0, 48, 47), new TimeOnly(9, 35, 38) },
                    { 50L, 17L, new TimeOnly(22, 26, 45), new TimeOnly(5, 39, 34) },
                    { 51L, 17L, new TimeOnly(19, 5, 57), new TimeOnly(18, 19, 55) },
                    { 52L, 18L, new TimeOnly(4, 4, 34), new TimeOnly(23, 27, 16) },
                    { 53L, 18L, new TimeOnly(19, 48, 29), new TimeOnly(11, 10, 51) },
                    { 54L, 18L, new TimeOnly(1, 27, 8), new TimeOnly(4, 42, 39) },
                    { 55L, 19L, new TimeOnly(21, 15, 50), new TimeOnly(1, 55, 41) },
                    { 56L, 19L, new TimeOnly(20, 12, 5), new TimeOnly(17, 22, 35) },
                    { 57L, 19L, new TimeOnly(9, 11, 32), new TimeOnly(22, 14, 39) },
                    { 58L, 20L, new TimeOnly(23, 51, 53), new TimeOnly(15, 9, 57) },
                    { 59L, 20L, new TimeOnly(10, 54, 13), new TimeOnly(7, 48, 56) },
                    { 60L, 20L, new TimeOnly(9, 20, 21), new TimeOnly(19, 16, 37) },
                    { 61L, 21L, new TimeOnly(15, 8, 48), new TimeOnly(16, 54, 3) },
                    { 62L, 21L, new TimeOnly(15, 56, 48), new TimeOnly(12, 18, 35) },
                    { 63L, 21L, new TimeOnly(10, 18, 19), new TimeOnly(6, 2, 43) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseSchedules_BaseScheduleFamilyId",
                table: "BaseSchedules",
                column: "BaseScheduleFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseSleepPeriods_BaseScheduleId",
                table: "BaseSleepPeriods",
                column: "BaseScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Captures_UserId",
                table: "Captures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FallingAsleepMarks_SleepPeriodId",
                table: "FallingAsleepMarks",
                column: "SleepPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_JwtLastTokens_UserId",
                table: "JwtLastTokens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MissedChecks_SleepPeriodId",
                table: "MissedChecks",
                column: "SleepPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserScheduleAttemptId",
                table: "Notes",
                column: "UserScheduleAttemptId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteSleepPeriod_SleepPeriodsId",
                table: "NoteSleepPeriod",
                column: "SleepPeriodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Oversleeps_SleepPeriodId",
                table: "Oversleeps",
                column: "SleepPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_SkippedPeriods_SleepPeriodId",
                table: "SkippedPeriods",
                column: "SleepPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_SleepPeriodChanges_SleepPeriodId",
                table: "SleepPeriodChanges",
                column: "SleepPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_UserScheduleAttempts_BaseScheduleId",
                table: "UserScheduleAttempts",
                column: "BaseScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserScheduleAttempts_UserId",
                table: "UserScheduleAttempts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WakingUpMarks_SleepPeriodId",
                table: "WakingUpMarks",
                column: "SleepPeriodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseSleepPeriods");

            migrationBuilder.DropTable(
                name: "Captures");

            migrationBuilder.DropTable(
                name: "FallingAsleepMarks");

            migrationBuilder.DropTable(
                name: "JwtLastTokens");

            migrationBuilder.DropTable(
                name: "MissedChecks");

            migrationBuilder.DropTable(
                name: "NoteSleepPeriod");

            migrationBuilder.DropTable(
                name: "Oversleeps");

            migrationBuilder.DropTable(
                name: "SkippedPeriods");

            migrationBuilder.DropTable(
                name: "SleepPeriodChanges");

            migrationBuilder.DropTable(
                name: "WakingUpMarks");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "SleepPeriods");

            migrationBuilder.DropTable(
                name: "UserScheduleAttempts");

            migrationBuilder.DropTable(
                name: "BaseSchedules");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BaseScheduleFamilies");
        }
    }
}
