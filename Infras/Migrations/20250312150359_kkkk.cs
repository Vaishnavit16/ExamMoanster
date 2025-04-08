using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infras.Migrations
{
    /// <inheritdoc />
    public partial class kkkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleExamCandidateTbl_ScheduleExamTbl_ScheduleExamID",
                table: "ScheduleExamCandidateTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleExamDetTbl_ScheduleExamTbl_ScheduleExamID",
                table: "ScheduleExamDetTbl");

            migrationBuilder.DropTable(
                name: "ScheduleExamTbl");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleExamDetTbl_ScheduleExamID",
                table: "ScheduleExamDetTbl");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleExamCandidateTbl_ScheduleExamID",
                table: "ScheduleExamCandidateTbl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleExamTbl",
                columns: table => new
                {
                    ScheduleExamID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false),
                    PackagePurchaseID = table.Column<long>(type: "bigint", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsObjective = table.Column<bool>(type: "bit", nullable: false),
                    IsResultOpen = table.Column<bool>(type: "bit", nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleExamTbl", x => x.ScheduleExamID);
                    table.ForeignKey(
                        name: "FK_ScheduleExamTbl_ CompanyTbl_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: " CompanyTbl",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleExamTbl_ PackagePurchaseTbl_PackagePurchaseID",
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
                name: "IX_ScheduleExamTbl_CompanyID",
                table: "ScheduleExamTbl",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleExamTbl_PackagePurchaseID",
                table: "ScheduleExamTbl",
                column: "PackagePurchaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleExamCandidateTbl_ScheduleExamTbl_ScheduleExamID",
                table: "ScheduleExamCandidateTbl",
                column: "ScheduleExamID",
                principalTable: "ScheduleExamTbl",
                principalColumn: "ScheduleExamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleExamDetTbl_ScheduleExamTbl_ScheduleExamID",
                table: "ScheduleExamDetTbl",
                column: "ScheduleExamID",
                principalTable: "ScheduleExamTbl",
                principalColumn: "ScheduleExamID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
