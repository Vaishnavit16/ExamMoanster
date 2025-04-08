using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infras.Migrations
{
    /// <inheritdoc />
    public partial class kkkkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "scheduleExams",
                columns: table => new
                {
                    ScheduleExamID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsResultOpen = table.Column<bool>(type: "bit", nullable: false),
                    IsObjective = table.Column<bool>(type: "bit", nullable: false),
                    PackagePurchaseID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scheduleExams", x => x.ScheduleExamID);
                    table.ForeignKey(
                        name: "FK_scheduleExams_ CompanyTbl_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: " CompanyTbl",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scheduleExams_ PackagePurchaseTbl_PackagePurchaseID",
                        column: x => x.PackagePurchaseID,
                        principalTable: " PackagePurchaseTbl",
                        principalColumn: "PackagePurchaseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleExamDetTbl_ScheduleExamID",
                table: "ScheduleExamDetTbl",
                column: "ScheduleExamID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleExamCandidateTbl_ScheduleExamID",
                table: "ScheduleExamCandidateTbl",
                column: "ScheduleExamID");

            migrationBuilder.CreateIndex(
                name: "IX_scheduleExams_CompanyID",
                table: "scheduleExams",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_scheduleExams_PackagePurchaseID",
                table: "scheduleExams",
                column: "PackagePurchaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleExamCandidateTbl_scheduleExams_ScheduleExamID",
                table: "ScheduleExamCandidateTbl",
                column: "ScheduleExamID",
                principalTable: "scheduleExams",
                principalColumn: "ScheduleExamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleExamDetTbl_scheduleExams_ScheduleExamID",
                table: "ScheduleExamDetTbl",
                column: "ScheduleExamID",
                principalTable: "scheduleExams",
                principalColumn: "ScheduleExamID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleExamCandidateTbl_scheduleExams_ScheduleExamID",
                table: "ScheduleExamCandidateTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleExamDetTbl_scheduleExams_ScheduleExamID",
                table: "ScheduleExamDetTbl");

            migrationBuilder.DropTable(
                name: "scheduleExams");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleExamDetTbl_ScheduleExamID",
                table: "ScheduleExamDetTbl");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleExamCandidateTbl_ScheduleExamID",
                table: "ScheduleExamCandidateTbl");
        }
    }
}
