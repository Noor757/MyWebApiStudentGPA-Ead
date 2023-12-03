using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApiStudentGPA.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentDbDto2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RollNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDbDto2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectDbDto2",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectDbDto2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjectDbDto2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SID = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    GPA = table.Column<double>(type: "float", nullable: false),
                    StudentDbDtoId = table.Column<int>(type: "int", nullable: true),
                    SubjectDbDtoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjectDbDto2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubjectDbDto2_StudentDbDto2_SID",
                        column: x => x.SID,
                        principalTable: "StudentDbDto2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjectDbDto2_StudentDbDto2_StudentDbDtoId",
                        column: x => x.StudentDbDtoId,
                        principalTable: "StudentDbDto2",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentSubjectDbDto2_SubjectDbDto2_SubjectDbDtoid",
                        column: x => x.SubjectDbDtoid,
                        principalTable: "SubjectDbDto2",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StudentSubjectDbDto2_SubjectDbDto2_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectDbDto2",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjectMarksDbDto2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Marks = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjectMarksDbDto2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubjectMarksDbDto2_StudentDbDto2_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentDbDto2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjectMarksDbDto2_SubjectDbDto2_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectDbDto2",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectDbDto2_SID",
                table: "StudentSubjectDbDto2",
                column: "SID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectDbDto2_StudentDbDtoId",
                table: "StudentSubjectDbDto2",
                column: "StudentDbDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectDbDto2_SubjectDbDtoid",
                table: "StudentSubjectDbDto2",
                column: "SubjectDbDtoid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectDbDto2_SubjectId",
                table: "StudentSubjectDbDto2",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectMarksDbDto2_StudentId",
                table: "StudentSubjectMarksDbDto2",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectMarksDbDto2_SubjectId",
                table: "StudentSubjectMarksDbDto2",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubjectDbDto2");

            migrationBuilder.DropTable(
                name: "StudentSubjectMarksDbDto2");

            migrationBuilder.DropTable(
                name: "StudentDbDto2");

            migrationBuilder.DropTable(
                name: "SubjectDbDto2");
        }
    }
}
