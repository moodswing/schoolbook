using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class Anotations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotations_Students_StudentId",
                table: "Anotations");

            migrationBuilder.DropIndex(
                name: "IX_Anotations_StudentId",
                table: "Anotations");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Anotations");

            migrationBuilder.AddColumn<int>(
                name: "AnotationId",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllClass",
                table: "Anotations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Anotations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Anotations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Score",
                value: 3.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Score",
                value: 5.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3,
                column: "Score",
                value: 6.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 4,
                column: "Score",
                value: 6.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 5,
                column: "Score",
                value: 3.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 6,
                column: "Score",
                value: 4.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 7,
                column: "Score",
                value: 1.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 8,
                column: "Score",
                value: 6.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 9,
                column: "Score",
                value: 2.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 10,
                column: "Score",
                value: 4.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 11,
                column: "Score",
                value: 4.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 12,
                column: "Score",
                value: 2.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 13,
                column: "Score",
                value: 2.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 14,
                column: "Score",
                value: 3.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 15,
                column: "Score",
                value: 2.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 16,
                column: "Score",
                value: 2.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 17,
                column: "Score",
                value: 5.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 18,
                column: "Score",
                value: 3.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 19,
                column: "Score",
                value: 6.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 20,
                column: "Score",
                value: 2.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 21,
                column: "Score",
                value: 6.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 22,
                column: "Score",
                value: 2.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 23,
                column: "Score",
                value: 5.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 24,
                column: "Score",
                value: 1.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 25,
                column: "Score",
                value: 3.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 26,
                column: "Score",
                value: 4.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 27,
                column: "Score",
                value: 4.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 28,
                column: "Score",
                value: 3.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 29,
                column: "Score",
                value: 2.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 30,
                column: "Score",
                value: 3.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 31,
                column: "Score",
                value: 5.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 32,
                column: "Score",
                value: 4.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 33,
                column: "Score",
                value: 4.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 34,
                column: "Score",
                value: 6.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 35,
                column: "Score",
                value: 6.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 36,
                column: "Score",
                value: 2.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 37,
                column: "Score",
                value: 5.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 38,
                column: "Score",
                value: 3.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 39,
                column: "Score",
                value: 4.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 40,
                column: "Score",
                value: 6.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 41,
                column: "Score",
                value: 3.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 42,
                column: "Score",
                value: 3.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 43,
                column: "Score",
                value: 6.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 44,
                column: "Score",
                value: 3.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 45,
                column: "Score",
                value: 6.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 46,
                column: "Score",
                value: 4.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 47,
                column: "Score",
                value: 3.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 48,
                column: "Score",
                value: 1.7m);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AnotationId",
                table: "Students",
                column: "AnotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Anotations_ClassId",
                table: "Anotations",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anotations_Classes_ClassId",
                table: "Anotations",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Anotations_AnotationId",
                table: "Students",
                column: "AnotationId",
                principalTable: "Anotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotations_Classes_ClassId",
                table: "Anotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Anotations_AnotationId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AnotationId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Anotations_ClassId",
                table: "Anotations");

            migrationBuilder.DropColumn(
                name: "AnotationId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AllClass",
                table: "Anotations");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Anotations");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Anotations");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Anotations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Score",
                value: 5.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Score",
                value: 6.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3,
                column: "Score",
                value: 1.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 4,
                column: "Score",
                value: 3.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 5,
                column: "Score",
                value: 6.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 6,
                column: "Score",
                value: 4.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 7,
                column: "Score",
                value: 3.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 8,
                column: "Score",
                value: 2.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 9,
                column: "Score",
                value: 5.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 10,
                column: "Score",
                value: 3.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 11,
                column: "Score",
                value: 6.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 12,
                column: "Score",
                value: 1.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 13,
                column: "Score",
                value: 4.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 14,
                column: "Score",
                value: 6.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 15,
                column: "Score",
                value: 4.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 16,
                column: "Score",
                value: 1.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 17,
                column: "Score",
                value: 6.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 18,
                column: "Score",
                value: 4.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 19,
                column: "Score",
                value: 6.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 20,
                column: "Score",
                value: 3.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 21,
                column: "Score",
                value: 2.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 22,
                column: "Score",
                value: 5.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 23,
                column: "Score",
                value: 5.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 24,
                column: "Score",
                value: 6.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 25,
                column: "Score",
                value: 1.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 26,
                column: "Score",
                value: 5.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 27,
                column: "Score",
                value: 4.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 28,
                column: "Score",
                value: 3.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 29,
                column: "Score",
                value: 5.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 30,
                column: "Score",
                value: 5.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 31,
                column: "Score",
                value: 2.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 32,
                column: "Score",
                value: 3.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 33,
                column: "Score",
                value: 1.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 34,
                column: "Score",
                value: 2.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 35,
                column: "Score",
                value: 2.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 36,
                column: "Score",
                value: 5.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 37,
                column: "Score",
                value: 3.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 38,
                column: "Score",
                value: 5.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 39,
                column: "Score",
                value: 6.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 40,
                column: "Score",
                value: 3.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 41,
                column: "Score",
                value: 5.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 42,
                column: "Score",
                value: 2.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 43,
                column: "Score",
                value: 1.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 44,
                column: "Score",
                value: 6.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 45,
                column: "Score",
                value: 1.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 46,
                column: "Score",
                value: 2.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 47,
                column: "Score",
                value: 5.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 48,
                column: "Score",
                value: 3.6m);

            migrationBuilder.CreateIndex(
                name: "IX_Anotations_StudentId",
                table: "Anotations",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anotations_Students_StudentId",
                table: "Anotations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
