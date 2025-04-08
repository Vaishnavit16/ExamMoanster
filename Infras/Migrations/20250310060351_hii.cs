using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infras.Migrations
{
    /// <inheritdoc />
    public partial class hii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: " CompanyTbl",
                columns: table => new
                {
                    CompanyID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ CompanyTbl", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "CandidateTbl",
                columns: table => new
                {
                    CandidateID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateTbl", x => x.CandidateID);
                });

            migrationBuilder.CreateTable(
                name: "MockTestCategoryTbl",
                columns: table => new
                {
                    MockTestCategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MockTestCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MockTestCategoryTbl", x => x.MockTestCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "OfferDiscountTbl",
                columns: table => new
                {
                    OfferDiscountID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicableTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ispercentile = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferDiscountTbl", x => x.OfferDiscountID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModeTbl",
                columns: table => new
                {
                    PaymentModeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentModeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModeTbl", x => x.PaymentModeID);
                });

            migrationBuilder.CreateTable(
                name: "SiteAdminTbl",
                columns: table => new
                {
                    SiteAdminID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobileno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteAdminTbl", x => x.SiteAdminID);
                });

            migrationBuilder.CreateTable(
                name: "TestPackageTbl",
                columns: table => new
                {
                    TestPackageID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PackageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxCandidatePerExam = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPackageTbl", x => x.TestPackageID);
                });

            migrationBuilder.CreateTable(
                name: "CompanyComplaintTbl",
                columns: table => new
                {
                    CompantComplaintID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComplaintDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyComplaintTbl", x => x.CompantComplaintID);
                    table.ForeignKey(
                        name: "FK_CompanyComplaintTbl_ CompanyTbl_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: " CompanyTbl",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTrailTbl",
                columns: table => new
                {
                    CompanyTrailID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrailStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrailEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrailActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTrailTbl", x => x.CompanyTrailID);
                    table.ForeignKey(
                        name: "FK_CompanyTrailTbl_ CompanyTbl_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: " CompanyTbl",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionDBCategoryTbl",
                columns: table => new
                {
                    QuestionDBCategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionDBCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionDBCategoryTbl", x => x.QuestionDBCategoryID);
                    table.ForeignKey(
                        name: "FK_QuestionDBCategoryTbl_ CompanyTbl_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: " CompanyTbl",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: " MockTestSubjectTbl",
                columns: table => new
                {
                    MockTestSubjectID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MockTestCategoryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ MockTestSubjectTbl", x => x.MockTestSubjectID);
                    table.ForeignKey(
                        name: "FK_ MockTestSubjectTbl_MockTestCategoryTbl_MockTestCategoryID",
                        column: x => x.MockTestCategoryID,
                        principalTable: "MockTestCategoryTbl",
                        principalColumn: "MockTestCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: " PackagePurchaseTbl",
                columns: table => new
                {
                    PackagePurchaseID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PackageDuration = table.Column<long>(type: "bigint", nullable: false),
                    TestPackageID = table.Column<long>(type: "bigint", nullable: false),
                    PackagePurchaseTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ PackagePurchaseTbl", x => x.PackagePurchaseID);
                    table.ForeignKey(
                        name: "FK_ PackagePurchaseTbl_ CompanyTbl_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: " CompanyTbl",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ PackagePurchaseTbl_TestPackageTbl_TestPackageID",
                        column: x => x.TestPackageID,
                        principalTable: "TestPackageTbl",
                        principalColumn: "TestPackageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestPackageDetTbl",
                columns: table => new
                {
                    TestPackageDetID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestPackageID = table.Column<long>(type: "bigint", nullable: false),
                    NoofTest = table.Column<long>(type: "bigint", nullable: false),
                    ValidityInMonths = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPackageDetTbl", x => x.TestPackageDetID);
                    table.ForeignKey(
                        name: "FK_TestPackageDetTbl_TestPackageTbl_TestPackageID",
                        column: x => x.TestPackageID,
                        principalTable: "TestPackageTbl",
                        principalColumn: "TestPackageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyComplaintSolutionTbl",
                columns: table => new
                {
                    CompanyComplaintSolutionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolutionDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompantComplaintID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyComplaintSolutionTbl", x => x.CompanyComplaintSolutionID);
                    table.ForeignKey(
                        name: "FK_CompanyComplaintSolutionTbl_CompanyComplaintTbl_CompantComplaintID",
                        column: x => x.CompantComplaintID,
                        principalTable: "CompanyComplaintTbl",
                        principalColumn: "CompantComplaintID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionBankTbl",
                columns: table => new
                {
                    QuestionBankID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionBankTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionDBCategoryID = table.Column<long>(type: "bigint", nullable: false),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionBankTbl", x => x.QuestionBankID);
                    table.ForeignKey(
                        name: "FK_QuestionBankTbl_ CompanyTbl_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: " CompanyTbl",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionBankTbl_QuestionDBCategoryTbl_QuestionDBCategoryID",
                        column: x => x.QuestionDBCategoryID,
                        principalTable: "QuestionDBCategoryTbl",
                        principalColumn: "QuestionDBCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MockTestQuestionTbl",
                columns: table => new
                {
                    MockTestQuestionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MockTestSubjectID = table.Column<long>(type: "bigint", nullable: false),
                    Questions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsObjective = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MockTestQuestionTbl", x => x.MockTestQuestionID);
                    table.ForeignKey(
                        name: "FK_MockTestQuestionTbl_ MockTestSubjectTbl_MockTestSubjectID",
                        column: x => x.MockTestSubjectID,
                        principalTable: " MockTestSubjectTbl",
                        principalColumn: "MockTestSubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MockTestTbl",
                columns: table => new
                {
                    MockTestID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MockTestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MockTestSubjectID = table.Column<long>(type: "bigint", nullable: false),
                    NoofQuestion = table.Column<long>(type: "bigint", nullable: false),
                    MarksPerQuestion = table.Column<long>(type: "bigint", nullable: false),
                    IsNegavtive = table.Column<bool>(type: "bit", nullable: false),
                    PassingMarks = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MockTestTbl", x => x.MockTestID);
                    table.ForeignKey(
                        name: "FK_MockTestTbl_ MockTestSubjectTbl_MockTestSubjectID",
                        column: x => x.MockTestSubjectID,
                        principalTable: " MockTestSubjectTbl",
                        principalColumn: "MockTestSubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackagePurchasePaymentTbl",
                columns: table => new
                {
                    PackagePurchasePaymentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackagePurchaseID = table.Column<long>(type: "bigint", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentModeID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagePurchasePaymentTbl", x => x.PackagePurchasePaymentID);
                    table.ForeignKey(
                        name: "FK_PackagePurchasePaymentTbl_ PackagePurchaseTbl_PackagePurchaseID",
                        column: x => x.PackagePurchaseID,
                        principalTable: " PackagePurchaseTbl",
                        principalColumn: "PackagePurchaseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PackagePurchasePaymentTbl_PaymentModeTbl_PaymentModeID",
                        column: x => x.PaymentModeID,
                        principalTable: "PaymentModeTbl",
                        principalColumn: "PaymentModeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleExamTbl",
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

            migrationBuilder.CreateTable(
                name: "QuestionTbl",
                columns: table => new
                {
                    QuestionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsObjective = table.Column<bool>(type: "bit", nullable: false),
                    QuestionBankID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTbl", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK_QuestionTbl_QuestionBankTbl_QuestionBankID",
                        column: x => x.QuestionBankID,
                        principalTable: "QuestionBankTbl",
                        principalColumn: "QuestionBankID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MockTestQuestionOptionsTbl",
                columns: table => new
                {
                    MockTestQuestionOptionsID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MockTestQuestionID = table.Column<long>(type: "bigint", nullable: false)
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
                name: "CandidatePerformanceTbl",
                columns: table => new
                {
                    CandidatePerformanceID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateID = table.Column<long>(type: "bigint", nullable: false),
                    MockTestID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatePerformanceTbl", x => x.CandidatePerformanceID);
                    table.ForeignKey(
                        name: "FK_CandidatePerformanceTbl_CandidateTbl_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "CandidateTbl",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidatePerformanceTbl_MockTestTbl_MockTestID",
                        column: x => x.MockTestID,
                        principalTable: "MockTestTbl",
                        principalColumn: "MockTestID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "packageCardPayments",
                columns: table => new
                {
                    PackageCardPaymentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackagePurchasePaymentID = table.Column<long>(type: "bigint", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packageCardPayments", x => x.PackageCardPaymentID);
                    table.ForeignKey(
                        name: "FK_packageCardPayments_PackagePurchasePaymentTbl_PackagePurchasePaymentID",
                        column: x => x.PackagePurchasePaymentID,
                        principalTable: "PackagePurchasePaymentTbl",
                        principalColumn: "PackagePurchasePaymentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageUPIPayments",
                columns: table => new
                {
                    PackageUPIPaymentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagePurchasePaymentID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageUPIPayments", x => x.PackageUPIPaymentID);
                    table.ForeignKey(
                        name: "FK_PackageUPIPayments_PackagePurchasePaymentTbl_PackagePurchasePaymentID",
                        column: x => x.PackagePurchasePaymentID,
                        principalTable: "PackagePurchasePaymentTbl",
                        principalColumn: "PackagePurchasePaymentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleExamCandidateTbl",
                columns: table => new
                {
                    ScheduleExamCandidateID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleExamID = table.Column<long>(type: "bigint", nullable: false),
                    CandidateID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleExamCandidateTbl", x => x.ScheduleExamCandidateID);
                    table.ForeignKey(
                        name: "FK_ScheduleExamCandidateTbl_CandidateTbl_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "CandidateTbl",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleExamCandidateTbl_ScheduleExamTbl_ScheduleExamID",
                        column: x => x.ScheduleExamID,
                        principalTable: "ScheduleExamTbl",
                        principalColumn: "ScheduleExamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleExamDetTbl",
                columns: table => new
                {
                    ScheduleExamDetID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarksPerQuestion = table.Column<long>(type: "bigint", nullable: false),
                    PassingMarks = table.Column<long>(type: "bigint", nullable: false),
                    ScheduleExamID = table.Column<long>(type: "bigint", nullable: false),
                    QuestionBankID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleExamDetTbl", x => x.ScheduleExamDetID);
                    table.ForeignKey(
                        name: "FK_ScheduleExamDetTbl_QuestionBankTbl_QuestionBankID",
                        column: x => x.QuestionBankID,
                        principalTable: "QuestionBankTbl",
                        principalColumn: "QuestionBankID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleExamDetTbl_ScheduleExamTbl_ScheduleExamID",
                        column: x => x.ScheduleExamID,
                        principalTable: "ScheduleExamTbl",
                        principalColumn: "ScheduleExamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswerTbl",
                columns: table => new
                {
                    QuestionAnswerID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswerTbl", x => x.QuestionAnswerID);
                    table.ForeignKey(
                        name: "FK_QuestionAnswerTbl_QuestionTbl_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "QuestionTbl",
                        principalColumn: "QuestionID",
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

            migrationBuilder.CreateTable(
                name: "CandidatePerformanceDetTbl",
                columns: table => new
                {
                    CandidatePerformanceDetID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolvedQuestion = table.Column<long>(type: "bigint", nullable: false),
                    ObtainedMarks = table.Column<long>(type: "bigint", nullable: false),
                    MockTestID = table.Column<long>(type: "bigint", nullable: false),
                    CandidatePerformanceID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatePerformanceDetTbl", x => x.CandidatePerformanceDetID);
                    table.ForeignKey(
                        name: "FK_CandidatePerformanceDetTbl_CandidatePerformanceTbl_CandidatePerformanceID",
                        column: x => x.CandidatePerformanceID,
                        principalTable: "CandidatePerformanceTbl",
                        principalColumn: "CandidatePerformanceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidatePerformanceDetTbl_MockTestTbl_MockTestID",
                        column: x => x.MockTestID,
                        principalTable: "MockTestTbl",
                        principalColumn: "MockTestID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleExamResultTbl",
                columns: table => new
                {
                    ScheduleExamResultID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResultDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleExamCandidateID = table.Column<long>(type: "bigint", nullable: false),
                    GenerationFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleExamResultTbl", x => x.ScheduleExamResultID);
                    table.ForeignKey(
                        name: "FK_ScheduleExamResultTbl_ScheduleExamCandidateTbl_ScheduleExamCandidateID",
                        column: x => x.ScheduleExamCandidateID,
                        principalTable: "ScheduleExamCandidateTbl",
                        principalColumn: "ScheduleExamCandidateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ MockTestSubjectTbl_MockTestCategoryID",
                table: " MockTestSubjectTbl",
                column: "MockTestCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ PackagePurchaseTbl_CompanyID",
                table: " PackagePurchaseTbl",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ PackagePurchaseTbl_TestPackageID",
                table: " PackagePurchaseTbl",
                column: "TestPackageID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePerformanceDetTbl_CandidatePerformanceID",
                table: "CandidatePerformanceDetTbl",
                column: "CandidatePerformanceID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePerformanceDetTbl_MockTestID",
                table: "CandidatePerformanceDetTbl",
                column: "MockTestID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePerformanceTbl_CandidateID",
                table: "CandidatePerformanceTbl",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePerformanceTbl_MockTestID",
                table: "CandidatePerformanceTbl",
                column: "MockTestID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyComplaintSolutionTbl_CompantComplaintID",
                table: "CompanyComplaintSolutionTbl",
                column: "CompantComplaintID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyComplaintTbl_CompanyID",
                table: "CompanyComplaintTbl",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTrailTbl_CompanyID",
                table: "CompanyTrailTbl",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_MockTestQuestionAnswerTbl_MockTestQuestionOptionsID",
                table: "MockTestQuestionAnswerTbl",
                column: "MockTestQuestionOptionsID");

            migrationBuilder.CreateIndex(
                name: "IX_MockTestQuestionOptionsTbl_MockTestQuestionID",
                table: "MockTestQuestionOptionsTbl",
                column: "MockTestQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_MockTestQuestionTbl_MockTestSubjectID",
                table: "MockTestQuestionTbl",
                column: "MockTestSubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_MockTestTbl_MockTestSubjectID",
                table: "MockTestTbl",
                column: "MockTestSubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_packageCardPayments_PackagePurchasePaymentID",
                table: "packageCardPayments",
                column: "PackagePurchasePaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_PackagePurchasePaymentTbl_PackagePurchaseID",
                table: "PackagePurchasePaymentTbl",
                column: "PackagePurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_PackagePurchasePaymentTbl_PaymentModeID",
                table: "PackagePurchasePaymentTbl",
                column: "PaymentModeID");

            migrationBuilder.CreateIndex(
                name: "IX_PackageUPIPayments_PackagePurchasePaymentID",
                table: "PackageUPIPayments",
                column: "PackagePurchasePaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerTbl_QuestionID",
                table: "QuestionAnswerTbl",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBankTbl_CompanyID",
                table: "QuestionBankTbl",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBankTbl_QuestionDBCategoryID",
                table: "QuestionBankTbl",
                column: "QuestionDBCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionDBCategoryTbl_CompanyID",
                table: "QuestionDBCategoryTbl",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTbl_QuestionBankID",
                table: "QuestionTbl",
                column: "QuestionBankID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleExamCandidateTbl_CandidateID",
                table: "ScheduleExamCandidateTbl",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleExamCandidateTbl_ScheduleExamID",
                table: "ScheduleExamCandidateTbl",
                column: "ScheduleExamID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleExamDetTbl_QuestionBankID",
                table: "ScheduleExamDetTbl",
                column: "QuestionBankID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleExamDetTbl_ScheduleExamID",
                table: "ScheduleExamDetTbl",
                column: "ScheduleExamID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleExamResultTbl_ScheduleExamCandidateID",
                table: "ScheduleExamResultTbl",
                column: "ScheduleExamCandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleExamTbl_CompanyID",
                table: "ScheduleExamTbl",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleExamTbl_PackagePurchaseID",
                table: "ScheduleExamTbl",
                column: "PackagePurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_TestPackageDetTbl_TestPackageID",
                table: "TestPackageDetTbl",
                column: "TestPackageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatePerformanceDetTbl");

            migrationBuilder.DropTable(
                name: "CompanyComplaintSolutionTbl");

            migrationBuilder.DropTable(
                name: "CompanyTrailTbl");

            migrationBuilder.DropTable(
                name: "MockTestQuestionAnswerTbl");

            migrationBuilder.DropTable(
                name: "OfferDiscountTbl");

            migrationBuilder.DropTable(
                name: "packageCardPayments");

            migrationBuilder.DropTable(
                name: "PackageUPIPayments");

            migrationBuilder.DropTable(
                name: "QuestionAnswerTbl");

            migrationBuilder.DropTable(
                name: "ScheduleExamDetTbl");

            migrationBuilder.DropTable(
                name: "ScheduleExamResultTbl");

            migrationBuilder.DropTable(
                name: "SiteAdminTbl");

            migrationBuilder.DropTable(
                name: "TestPackageDetTbl");

            migrationBuilder.DropTable(
                name: "CandidatePerformanceTbl");

            migrationBuilder.DropTable(
                name: "CompanyComplaintTbl");

            migrationBuilder.DropTable(
                name: "MockTestQuestionOptionsTbl");

            migrationBuilder.DropTable(
                name: "PackagePurchasePaymentTbl");

            migrationBuilder.DropTable(
                name: "QuestionTbl");

            migrationBuilder.DropTable(
                name: "ScheduleExamCandidateTbl");

            migrationBuilder.DropTable(
                name: "MockTestTbl");

            migrationBuilder.DropTable(
                name: "MockTestQuestionTbl");

            migrationBuilder.DropTable(
                name: "PaymentModeTbl");

            migrationBuilder.DropTable(
                name: "QuestionBankTbl");

            migrationBuilder.DropTable(
                name: "CandidateTbl");

            migrationBuilder.DropTable(
                name: "ScheduleExamTbl");

            migrationBuilder.DropTable(
                name: " MockTestSubjectTbl");

            migrationBuilder.DropTable(
                name: "QuestionDBCategoryTbl");

            migrationBuilder.DropTable(
                name: " PackagePurchaseTbl");

            migrationBuilder.DropTable(
                name: "MockTestCategoryTbl");

            migrationBuilder.DropTable(
                name: " CompanyTbl");

            migrationBuilder.DropTable(
                name: "TestPackageTbl");
        }
    }
}
