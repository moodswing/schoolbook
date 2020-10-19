using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class EvaluationObservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ObserverId1 = table.Column<string>(nullable: true),
                    ObserverId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    EvaluationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observations_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Observations_AspNetUsers_ObserverId1",
                        column: x => x.ObserverId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Observations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Local));

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
                value: 4.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3,
                column: "Score",
                value: 6.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 4,
                column: "Score",
                value: 4.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 5,
                column: "Score",
                value: 1.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 6,
                column: "Score",
                value: 6.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 7,
                column: "Score",
                value: 2.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 8,
                column: "Score",
                value: 6.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 9,
                column: "Score",
                value: 1.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 10,
                column: "Score",
                value: 3.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 11,
                column: "Score",
                value: 1.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 12,
                column: "Score",
                value: 6.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 13,
                column: "Score",
                value: 4.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 14,
                column: "Score",
                value: 2.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 15,
                column: "Score",
                value: 4.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 16,
                column: "Score",
                value: 4.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 17,
                column: "Score",
                value: 1.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 18,
                column: "Score",
                value: 2.0m);

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
                value: 3.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 21,
                column: "Score",
                value: 6.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 22,
                column: "Score",
                value: 4.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 23,
                column: "Score",
                value: 6.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 24,
                column: "Score",
                value: 3.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 25,
                column: "Score",
                value: 4.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 26,
                column: "Score",
                value: 5.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 27,
                column: "Score",
                value: 6.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 28,
                column: "Score",
                value: 4.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 29,
                column: "Score",
                value: 6.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 30,
                column: "Score",
                value: 3.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 31,
                column: "Score",
                value: 2.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 32,
                column: "Score",
                value: 1.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 33,
                column: "Score",
                value: 2.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 34,
                column: "Score",
                value: 5.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 35,
                column: "Score",
                value: 1.7m);

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
                value: 3.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 38,
                column: "Score",
                value: 2.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 39,
                column: "Score",
                value: 5.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 41,
                column: "Score",
                value: 3.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 42,
                column: "Score",
                value: 3.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 43,
                column: "Score",
                value: 1.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 44,
                column: "Score",
                value: 1.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 45,
                column: "Score",
                value: 2.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 46,
                column: "Score",
                value: 6.9m);

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
                value: 3.2m);

            migrationBuilder.CreateIndex(
                name: "IX_Observations_EvaluationId",
                table: "Observations",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_ObserverId1",
                table: "Observations",
                column: "ObserverId1");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_StudentId",
                table: "Observations",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Score",
                value: 2.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Score",
                value: 3.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3,
                column: "Score",
                value: 1.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 4,
                column: "Score",
                value: 3.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 5,
                column: "Score",
                value: 6.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 6,
                column: "Score",
                value: 2.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 7,
                column: "Score",
                value: 5.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 8,
                column: "Score",
                value: 1.6m);

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
                value: 1.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 11,
                column: "Score",
                value: 6.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 12,
                column: "Score",
                value: 7.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 13,
                column: "Score",
                value: 4.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 14,
                column: "Score",
                value: 3.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 15,
                column: "Score",
                value: 1.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 16,
                column: "Score",
                value: 1.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 17,
                column: "Score",
                value: 6.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 18,
                column: "Score",
                value: 1.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 19,
                column: "Score",
                value: 4.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 20,
                column: "Score",
                value: 6.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 21,
                column: "Score",
                value: 4.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 22,
                column: "Score",
                value: 3.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 23,
                column: "Score",
                value: 5.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 24,
                column: "Score",
                value: 4.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 25,
                column: "Score",
                value: 4.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 26,
                column: "Score",
                value: 4.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 27,
                column: "Score",
                value: 4.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 28,
                column: "Score",
                value: 6.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 29,
                column: "Score",
                value: 5.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 30,
                column: "Score",
                value: 6.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 31,
                column: "Score",
                value: 2.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 32,
                column: "Score",
                value: 5.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 33,
                column: "Score",
                value: 3.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 34,
                column: "Score",
                value: 6.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 35,
                column: "Score",
                value: 3.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 36,
                column: "Score",
                value: 1.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 37,
                column: "Score",
                value: 5.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 38,
                column: "Score",
                value: 4.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 39,
                column: "Score",
                value: 2.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 41,
                column: "Score",
                value: 1.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 42,
                column: "Score",
                value: 3.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 43,
                column: "Score",
                value: 5.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 44,
                column: "Score",
                value: 1.2m);

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
                value: 5.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 47,
                column: "Score",
                value: 1.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 48,
                column: "Score",
                value: 1.2m);
        }
    }
}
