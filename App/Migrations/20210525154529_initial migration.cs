using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreGalvanizeTeam.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Classification = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseName = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Classification", "FirstName", "LastName" },
                values: new object[] { 1, 14, 0, "Samuel", "Adams" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Classification", "FirstName", "LastName" },
                values: new object[] { 2, 16, 1, "Jack", "Daniels" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Classification", "FirstName", "LastName" },
                values: new object[] { 3, 17, 3, "Jim", "Bean" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Classification", "FirstName", "LastName" },
                values: new object[] { 4, 15, 2, "Johnnie", "Walker" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Classification", "FirstName", "LastName" },
                values: new object[] { 5, 20, 1, "Don", "Julio" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Classification", "FirstName", "LastName" },
                values: new object[] { 6, 18, 3, "Jose", "Cuervo" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "Value" },
                values: new object[] { 1, "English I", 1, 90m });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "Value" },
                values: new object[] { 2, "Calculus II", 1, 70m });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "Value" },
                values: new object[] { 3, "Theater Appreciation", 2, 50m });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "Value" },
                values: new object[] { 4, "Dynamic Programming", 2, 85m });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "Value" },
                values: new object[] { 5, "Data Structures", 2, 15m });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "Value" },
                values: new object[] { 6, "Senior Design I", 3, 97m });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "Value" },
                values: new object[] { 7, "Cloud Computing", 3, 75m });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "Value" },
                values: new object[] { 8, "Mixology", 5, 20m });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "Value" },
                values: new object[] { 9, "Mixology II", 5, 95m });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "Value" },
                values: new object[] { 10, "Mixology", 6, 16m });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
