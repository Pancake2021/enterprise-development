using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityStats.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "Faculty",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentId",
                table: "DepartmentSpecialty",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "Department",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_RegistrationNumber",
                table: "Faculty",
                column: "RegistrationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSpecialty_DepartmentId",
                table: "DepartmentSpecialty",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_FacultyId",
                table: "Department",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Faculty_FacultyId",
                table: "Department",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSpecialty_Department_DepartmentId",
                table: "DepartmentSpecialty",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSpecialty_Specialty_SpecialtyId",
                table: "DepartmentSpecialty",
                column: "SpecialtyId",
                principalTable: "Specialty",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculty_University_RegistrationNumber",
                table: "Faculty",
                column: "RegistrationNumber",
                principalTable: "University",
                principalColumn: "RegistrationNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Faculty_FacultyId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSpecialty_Department_DepartmentId",
                table: "DepartmentSpecialty");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSpecialty_Specialty_SpecialtyId",
                table: "DepartmentSpecialty");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculty_University_RegistrationNumber",
                table: "Faculty");

            migrationBuilder.DropIndex(
                name: "IX_Faculty_RegistrationNumber",
                table: "Faculty");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentSpecialty_DepartmentId",
                table: "DepartmentSpecialty");

            migrationBuilder.DropIndex(
                name: "IX_Department_FacultyId",
                table: "Department");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "Faculty",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentId",
                table: "DepartmentSpecialty",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "Department",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
