using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infras.Migrations
{
    /// <inheritdoc />
    public partial class sam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ObtainedMarks",
                table: "ScheduleExamResultTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SolvedQuestions",
                table: "ScheduleExamResultTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObtainedMarks",
                table: "ScheduleExamResultTbl");

            migrationBuilder.DropColumn(
                name: "SolvedQuestions",
                table: "ScheduleExamResultTbl");
        }
    }
}
