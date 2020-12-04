using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentApp.Migrations
{
    public partial class fff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeTypes_sys_EmployeeTypeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_sys_EmployeeTypeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "sys_EmployeeTypeId",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId",
                principalTable: "EmployeeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "sys_EmployeeTypeId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_sys_EmployeeTypeId",
                table: "Employees",
                column: "sys_EmployeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeTypes_sys_EmployeeTypeId",
                table: "Employees",
                column: "sys_EmployeeTypeId",
                principalTable: "EmployeeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
