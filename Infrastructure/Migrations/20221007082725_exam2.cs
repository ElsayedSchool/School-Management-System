using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class exam2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Classes_ClassId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Session_SessionId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_Exam_ExamId",
                table: "ExamResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_Students_StudentId",
                table: "ExamResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamResult",
                table: "ExamResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_SessionId",
                table: "Exam");

            migrationBuilder.RenameTable(
                name: "ExamResult",
                newName: "ExamsResults");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "Exams");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResult_ExamId",
                table: "ExamsResults",
                newName: "IX_ExamsResults_ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_ClassId",
                table: "Exams",
                newName: "IX_Exams_ClassId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "UserProfile",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 10, 7, 10, 27, 25, 180, DateTimeKind.Local).AddTicks(2214),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 10, 7, 10, 21, 29, 753, DateTimeKind.Local).AddTicks(7989));

            migrationBuilder.AlterColumn<int>(
                name: "SessionId",
                table: "Exams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamsResults",
                table: "ExamsResults",
                columns: new[] { "StudentId", "ExamId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SessionId",
                table: "Exams",
                column: "SessionId",
                unique: true,
                filter: "[SessionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Classes_ClassId",
                table: "Exams",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Session_SessionId",
                table: "Exams",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamsResults_Exams_ExamId",
                table: "ExamsResults",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamsResults_Students_StudentId",
                table: "ExamsResults",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Classes_ClassId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Session_SessionId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamsResults_Exams_ExamId",
                table: "ExamsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamsResults_Students_StudentId",
                table: "ExamsResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamsResults",
                table: "ExamsResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_SessionId",
                table: "Exams");

            migrationBuilder.RenameTable(
                name: "ExamsResults",
                newName: "ExamResult");

            migrationBuilder.RenameTable(
                name: "Exams",
                newName: "Exam");

            migrationBuilder.RenameIndex(
                name: "IX_ExamsResults_ExamId",
                table: "ExamResult",
                newName: "IX_ExamResult_ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_ClassId",
                table: "Exam",
                newName: "IX_Exam_ClassId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "UserProfile",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 10, 7, 10, 21, 29, 753, DateTimeKind.Local).AddTicks(7989),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 10, 7, 10, 27, 25, 180, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.AlterColumn<int>(
                name: "SessionId",
                table: "Exam",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamResult",
                table: "ExamResult",
                columns: new[] { "StudentId", "ExamId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_SessionId",
                table: "Exam",
                column: "SessionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Classes_ClassId",
                table: "Exam",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Session_SessionId",
                table: "Exam",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_Exam_ExamId",
                table: "ExamResult",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_Students_StudentId",
                table: "ExamResult",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
