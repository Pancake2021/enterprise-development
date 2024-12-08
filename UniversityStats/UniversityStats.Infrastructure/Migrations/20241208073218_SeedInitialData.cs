using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityStats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Ведущий технический университет", "Технический университет" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "UniversityId" },
                values: new object[] { 1, "Факультет информационных технологий", 1 });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[] { 1, 1, "Кафедра программной инженерии" });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[] { 1, 1, "Программная инженерия" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "SpecialtyId" },
                values: new object[] { 1, "ПИ-21", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
