using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infras.Migrations
{
    /// <inheritdoc />
    public partial class sa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MockTestQuestionAnswerTbl");

            migrationBuilder.DropTable(
                name: "MockTestQuestionOptionsTbl");

            migrationBuilder.DropColumn(
                name: "IsObjective",
                table: "MockTestQuestionTbl");

            migrationBuilder.CreateTable(
                name: "mockTestQueOptions",
                columns: table => new
                {
                    MocktestQueOptionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MockTestQuestionID = table.Column<long>(type: "bigint", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCurrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mockTestQueOptions", x => x.MocktestQueOptionID);
                    table.ForeignKey(
                        name: "FK_mockTestQueOptions_MockTestQuestionTbl_MockTestQuestionID",
                        column: x => x.MockTestQuestionID,
                        principalTable: "MockTestQuestionTbl",
                        principalColumn: "MockTestQuestionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mockTestQueOptions_MockTestQuestionID",
                table: "mockTestQueOptions",
                column: "MockTestQuestionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mockTestQueOptions");

            migrationBuilder.AddColumn<bool>(
                name: "IsObjective",
                table: "MockTestQuestionTbl",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MockTestQuestionOptionsTbl",
                columns: table => new
                {
                    MockTestQuestionOptionsID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MockTestQuestionID = table.Column<long>(type: "bigint", nullable: false),
                    Option1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MockTestQuestionOptionsTbl", x => x.MockTestQuestionOptionsID);
                    table.ForeignKey(
                        name: "FK_MockTestQuestionOptionsTbl_MockTestQuestionTbl_MockTestQuestionID",
                        column: x => x.MockTestQuestionID,
                        principalTable: "MockTestQuestionTbl",
                        principalColumn: "MockTestQuestionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MockTestQuestionAnswerTbl",
                columns: table => new
                {
                    MockTestQuestionAnswerID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MockTestQuestionOptionsID = table.Column<long>(type: "bigint", nullable: false),
                    CorrectOption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MockTestQuestionAnswerTbl", x => x.MockTestQuestionAnswerID);
                    table.ForeignKey(
                        name: "FK_MockTestQuestionAnswerTbl_MockTestQuestionOptionsTbl_MockTestQuestionOptionsID",
                        column: x => x.MockTestQuestionOptionsID,
                        principalTable: "MockTestQuestionOptionsTbl",
                        principalColumn: "MockTestQuestionOptionsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MockTestQuestionAnswerTbl_MockTestQuestionOptionsID",
                table: "MockTestQuestionAnswerTbl",
                column: "MockTestQuestionOptionsID");

            migrationBuilder.CreateIndex(
                name: "IX_MockTestQuestionOptionsTbl_MockTestQuestionID",
                table: "MockTestQuestionOptionsTbl",
                column: "MockTestQuestionID");
        }
    }
}
