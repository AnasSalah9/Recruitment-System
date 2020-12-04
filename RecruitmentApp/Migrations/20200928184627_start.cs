using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentApp.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    UniversityName = table.Column<string>(maxLength: 100, nullable: false),
                    UniversityMajor = table.Column<string>(maxLength: 100, nullable: false),
                    GraduationYear = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: false),
                    LinkedInAccount = table.Column<string>(maxLength: 150, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDepartments",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDepartments", x => new { x.CompanyId, x.DepartmentName });
                    table.ForeignKey(
                        name: "FK_CompanyDepartments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    UniversityName = table.Column<string>(maxLength: 100, nullable: true),
                    UniversityMajor = table.Column<string>(maxLength: 100, nullable: true),
                    GraduationYear = table.Column<int>(nullable: false),
                    LinkedInAccount = table.Column<string>(maxLength: 150, nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: true),
                    EmployeePosition = table.Column<string>(maxLength: 100, nullable: false),
                    HiringDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EmployeeStatusId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 100, nullable: true),
                    EmployeeTypeId = table.Column<int>(nullable: false),
                    sys_EmployeeTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeStatuses_EmployeeStatusId",
                        column: x => x.EmployeeStatusId,
                        principalTable: "EmployeeStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_sys_EmployeeTypeId",
                        column: x => x.sys_EmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_CompanyDepartments_CompanyId_DepartmentName",
                        columns: x => new { x.CompanyId, x.DepartmentName },
                        principalTable: "CompanyDepartments",
                        principalColumns: new[] { "CompanyId", "DepartmentName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: true),
                    Position = table.Column<string>(maxLength: 50, nullable: false),
                    JobDescribtion = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_CompanyDepartments_CompanyId_DepartmentName",
                        columns: x => new { x.CompanyId, x.DepartmentName },
                        principalTable: "CompanyDepartments",
                        principalColumns: new[] { "CompanyId", "DepartmentName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLoginDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LoginEmail = table.Column<string>(maxLength: 100, nullable: false),
                    EmployeePassword = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLoginDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLoginDatas_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: false),
                    CurrentPhaseId = table.Column<int>(nullable: false),
                    ApplicationStatusId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_ApplicationStatuses_ApplicationStatusId",
                        column: x => x.ApplicationStatusId,
                        principalTable: "ApplicationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Phases_CurrentPhaseId",
                        column: x => x.CurrentPhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationPhaseComments",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false),
                    PhaseId = table.Column<int>(nullable: false),
                    PhaseTask = table.Column<string>(maxLength: 100, nullable: true),
                    Comment = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationPhaseComments", x => new { x.ApplicationId, x.PhaseId });
                    table.ForeignKey(
                        name: "FK_ApplicationPhaseComments_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationPhaseComments_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationReviewers",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false),
                    ReviewerId = table.Column<int>(nullable: false),
                    PhaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationReviewers", x => new { x.ApplicationId, x.ReviewerId, x.PhaseId });
                    table.ForeignKey(
                        name: "FK_ApplicationReviewers_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationReviewers_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationReviewers_Employees_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPhaseComments_PhaseId",
                table: "ApplicationPhaseComments",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationReviewers_PhaseId",
                table: "ApplicationReviewers",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationReviewers_ReviewerId",
                table: "ApplicationReviewers",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationStatusId",
                table: "Applications",
                column: "ApplicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CandidateId",
                table: "Applications",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CurrentPhaseId",
                table: "Applications",
                column: "CurrentPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobId",
                table: "Applications",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeStatusId",
                table: "Employees",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_sys_EmployeeTypeId",
                table: "Employees",
                column: "sys_EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId_DepartmentName",
                table: "Employees",
                columns: new[] { "CompanyId", "DepartmentName" });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId_DepartmentName",
                table: "Jobs",
                columns: new[] { "CompanyId", "DepartmentName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationPhaseComments");

            migrationBuilder.DropTable(
                name: "ApplicationReviewers");

            migrationBuilder.DropTable(
                name: "EmployeeLoginDatas");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ApplicationStatuses");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "EmployeeStatuses");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "CompanyDepartments");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
