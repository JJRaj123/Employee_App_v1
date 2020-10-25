using Microsoft.EntityFrameworkCore.Migrations;

namespace Employees_App_v1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Department",
                columns: table => new
                {
                    Department_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Department", x => x.Department_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Employee",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(nullable: true),
                    Last_Name = table.Column<string>(nullable: true),
                    Email_Id = table.Column<string>(nullable: true),
                    Manager_Id = table.Column<int>(nullable: false),
                    DepartmentIdDepartment_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Employee", x => x.Employee_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Employee_tbl_Department_DepartmentIdDepartment_Id",
                        column: x => x.DepartmentIdDepartment_Id,
                        principalTable: "tbl_Department",
                        principalColumn: "Department_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Employee_DepartmentIdDepartment_Id",
                table: "tbl_Employee",
                column: "DepartmentIdDepartment_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Employee");

            migrationBuilder.DropTable(
                name: "tbl_Department");
        }
    }
}
