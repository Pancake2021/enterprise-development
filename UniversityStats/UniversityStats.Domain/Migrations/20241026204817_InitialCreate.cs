using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityStats.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FacultyId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameDepartment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DepartmentSpecialty",
                columns: table => new
                {
                    SpecialtyId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartmentId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentSpecialty", x => x.SpecialtyId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    FacultyId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameFaculty = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistrationNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.FacultyId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    SpecialtyId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameSpecialty = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberOfGroups = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.SpecialtyId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    RegistrationNumber = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameUniversity = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BuildingOwnership = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RectorFullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Degree = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.RegistrationNumber);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentId", "FacultyId", "NameDepartment" },
                values: new object[,]
                {
                    { "1001-DI", "1001", "Department of Information" },
                    { "1001-DSE", "1001", "Department of Software Engineering" },
                    { "1002-DR", "1002", "Department of Robotics" },
                    { "1003-DF", "1003", "Department of Finance" },
                    { "1004-DL", "1004", "Department of Languages" },
                    { "2001-DS", "2001", "Department of Surgery" },
                    { "2002-DP", "2002", "Department of Pharmacy" },
                    { "3001-DCP", "3001", "Department of Crop Production" },
                    { "4001-DD", "4001", "Department of Drawing" },
                    { "4001-DP", "4001", "Department of Painting" },
                    { "4002-DL", "4002", "Department of Languages" },
                    { "4003-DSP", "4003", "Department of Sports Physiologys" },
                    { "5001-DL", "5001", "Department of Law" },
                    { "6001-DI", "6001", "Department of Information" },
                    { "6002-DSE", "6002", "Department of Science Education" },
                    { "6003-DL", "6003", "Department of Languages" },
                    { "6004-DF", "6004", "Department of Finance" },
                    { "7001-DSP", "7001", "Department of Sports Physiologys" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentSpecialty",
                columns: new[] { "SpecialtyId", "DepartmentId" },
                values: new object[,]
                {
                    { "1001.04.03", "1001-DI" },
                    { "1001.05.03", "1001-DSE" },
                    { "1002.04.02", "1002-DR" },
                    { "1002.05.01", "1002-DR" },
                    { "1003.04.05", "1003-DF" },
                    { "1004.04.03", "1004-DL" },
                    { "2001.05.02", "2001-DS" },
                    { "2001.06.02", "2001-DS" },
                    { "2002.04.02", "2002-DP" },
                    { "2002.04.04", "2002-DP" },
                    { "3001.04.01", "3001-DCP" },
                    { "3001.04.03", "3001-DCP" },
                    { "4001.04.01", "4001-DP" },
                    { "4001.04.04", "4001-DD" },
                    { "4002.04.02", "4002-DL" },
                    { "4003.04.03", "4003-DSP" },
                    { "5001.04.01", "5001-DL" },
                    { "5001.05.02", "5001-DL" },
                    { "6001.05.02", "6001-DI" },
                    { "6002.04.02", "6002-DSE" },
                    { "6003.04.02", "6003-DL" },
                    { "6004.04.02", "6004-DF" },
                    { "7001.03.02", "7001-DSP" }
                });

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "FacultyId", "NameFaculty", "RegistrationNumber" },
                values: new object[,]
                {
                    { "1001", "Faculty of Information Technology", "UNI001" },
                    { "1002", "Faculty of Mechanical Engineering", "UNI001" },
                    { "1003", "Faculty of Finance and Banking", "UNI001" },
                    { "1004", "Faculty of Translation", "UNI001" },
                    { "2001", "Faculty of Medicine", "UNI002" },
                    { "2002", "Faculty of Agronomy", "UNI002" },
                    { "3001", "Faculty of Pedagogye", "UNI003" },
                    { "4001", "Faculty of Fine Arts", "UNI004" },
                    { "4002", "Faculty of Translation", "UNI004" },
                    { "4003", "Faculty of Sports Science", "UNI004" },
                    { "5001", "Faculty of International Law", "UNI005" },
                    { "6001", "Faculty of Information Technology", "UNI006" },
                    { "6002", "Faculty of Pedagogye", "UNI006" },
                    { "6003", "Faculty of Translation", "UNI006" },
                    { "6004", "Faculty of Finance and Banking", "UNI006" },
                    { "7001", "Faculty of Sports Science", "UNI007" }
                });

            migrationBuilder.InsertData(
                table: "Specialty",
                columns: new[] { "SpecialtyId", "NameSpecialty", "NumberOfGroups" },
                values: new object[,]
                {
                    { "1001.04.03", "Computer Science", 8 },
                    { "1001.05.03", "Computer Software Science", 7 },
                    { "1002.04.02", "Mechanical Collaboration", 5 },
                    { "1002.05.01", "Mechanical Engineering", 10 },
                    { "1003.04.05", "Finance and Banking", 9 },
                    { "1004.04.03", "Translation Studies", 11 },
                    { "2001.05.02", "Medicine", 3 },
                    { "2001.06.02", "Doctor", 5 },
                    { "2002.04.02", "Agronomy", 4 },
                    { "2002.04.04", "Pedagogye", 6 },
                    { "3001.04.01", "Pedagogye", 8 },
                    { "3001.04.03", "Sports Science", 2 },
                    { "4001.04.01", "Fine Arts", 5 },
                    { "4001.04.04", "Beauty Arts", 6 },
                    { "4002.04.02", "Translation Studies", 6 },
                    { "4003.04.03", "Sports Science", 4 },
                    { "5001.04.01", "Foreign Law", 5 },
                    { "5001.05.02", "International Law", 3 },
                    { "6001.05.02", "Computer Software Science", 7 },
                    { "6002.04.02", "Pedagogye", 8 },
                    { "6003.04.02", "Translation Studies", 8 },
                    { "6004.04.02", "Finance and Banking", 5 },
                    { "7001.03.02", "Sports Science", 7 }
                });

            migrationBuilder.InsertData(
                table: "University",
                columns: new[] { "RegistrationNumber", "Address", "BuildingOwnership", "Degree", "NameUniversity", "PropertyType", "RectorFullName", "Title" },
                values: new object[,]
                {
                    { "UNI001", "34 Tech Street", "Federal", "PhD", "University of Technology and Economics", "Municipal", "Ivan Yefimovich Petrov", "Professor" },
                    { "UNI002", "456 Health Road", "Private", "Doctor", "Medical University", "Private", "Anna Ivanova Vladimirovna", "Professor" },
                    { "UNI003", "321 Education Street", "Municipal", "PhD", "Pedagogical University", "Municipal", "Olga Petrova", "Professor" },
                    { "UNI004", "654 Art Boulevard", "Private", "MA", "University of Arts", "Private", "Marina Vasilievna Smirnova", "Associate Professor" },
                    { "UNI005", "852 Justice Boulevard", "Municipal", "PhD", "Law University", "Private", "Nikolai Vasilyevich Sergeev", "Professor" },
                    { "UNI006", "741 Pology Street", "Municipal", "PhD", "University of Foreign Languages", "Municipal", "Tatiana Nikolaevna Fedorova", "Professor" },
                    { "UNI007", "963 Lenin Prospekt", "Federal", "PhD", "Sports University", "Municipal", "Sergey Sergeevich Kozlov", "Professor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "DepartmentSpecialty");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropTable(
                name: "University");
        }
    }
}
