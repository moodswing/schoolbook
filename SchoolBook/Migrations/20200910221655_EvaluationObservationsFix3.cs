using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class EvaluationObservationsFix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Order", "Url" },
                values: new object[] { "Observaciones", 3, "/ClassBook/Observations" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Url" },
                values: new object[] { "Asistencia", "Attendance" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[] { "Atrasos", 1, null, 6, "Delays" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[] { "Alumnos", 0, "small-icon svgcollege-019-reading-book", 2, null });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Order", "Url" },
                values: new object[] { "Ficha Alumno", 1, "Student" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[] { "Accidente Escolar", 7, null, 2, "Accidents" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[] { "Administración", 0, "small-icon svgcollege-043-test", 4, null });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Order", "Url" },
                values: new object[] { "Credenciales", 1, "Credentials" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[] { "Cambiar Contraseña", 10, null, 2, "Password" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[] { "Horarios", 0, "small-icon svgcollege-005-alarm", 3, null });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Order", "Url" },
                values: new object[] { "Crear Horarios", 1, "ScheduleMaker" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Order", "Url" },
                values: new object[] { "Horario Por Asignatura", 2, "ScheduleMaker?type=1" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "Order", "Url" },
                values: new object[] { "Horario Por Curso", 3, "ScheduleMaker?type=2" });

            migrationBuilder.InsertData(
                table: "MenuOptions",
                columns: new[] { "Id", "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[] { 18, "Horario Por Profesor", 13, null, 4, "ScheduleMaker?type=3" });

            migrationBuilder.InsertData(
                table: "Observations",
                columns: new[] { "Id", "Date", "Description", "EvaluationId", "LastModification", "ObserverId", "StudentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Local), "No quiso entregar la prueba.", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "868465e8-48d1-4b1e-96e0-87bfca64f213", 5 },
                    { 2, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Local), "No entrega trabajo a la fecha..", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "868465e8-48d1-4b1e-96e0-87bfca64f213", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Score",
                value: 1.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Score",
                value: 2.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3,
                column: "Score",
                value: 2.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 4,
                column: "Score",
                value: 1.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 5,
                column: "Score",
                value: 5.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 6,
                column: "Score",
                value: 4.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 7,
                column: "Score",
                value: 4.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 8,
                column: "Score",
                value: 1.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 9,
                column: "Score",
                value: 5.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 11,
                column: "Score",
                value: 4.9m);

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
                value: 5.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 14,
                column: "Score",
                value: 1.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 15,
                column: "Score",
                value: 1.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 16,
                column: "Score",
                value: 6.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 17,
                column: "Score",
                value: 1.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 18,
                column: "Score",
                value: 6.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 19,
                column: "Score",
                value: 3.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 21,
                column: "Score",
                value: 4.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 22,
                column: "Score",
                value: 2.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 23,
                column: "Score",
                value: 6.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 24,
                column: "Score",
                value: 2.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 25,
                column: "Score",
                value: 2.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 26,
                column: "Score",
                value: 6.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 27,
                column: "Score",
                value: 6.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 28,
                column: "Score",
                value: 3.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 29,
                column: "Score",
                value: 4.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 30,
                column: "Score",
                value: 2.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 31,
                column: "Score",
                value: 3.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 32,
                column: "Score",
                value: 6.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 33,
                column: "Score",
                value: 2.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 34,
                column: "Score",
                value: 6.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 35,
                column: "Score",
                value: 6.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 36,
                column: "Score",
                value: 2.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 37,
                column: "Score",
                value: 6.5m);

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
                value: 6.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 40,
                column: "Score",
                value: 4.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 41,
                column: "Score",
                value: 4.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 42,
                column: "Score",
                value: 3.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 43,
                column: "Score",
                value: 3.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 44,
                column: "Score",
                value: 7.0m);

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
                value: 5.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 47,
                column: "Score",
                value: 5.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 48,
                column: "Score",
                value: 5.0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Order", "Url" },
                values: new object[] { "Asistencia", 4, "Attendance" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Url" },
                values: new object[] { "Atrasos", "Delays" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[] { "Alumnos", 0, "small-icon svgcollege-019-reading-book", 2, null });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[] { "Ficha Alumno", 7, null, 1, "Student" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Order", "Url" },
                values: new object[] { "Accidente Escolar", 2, "Accidents" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[] { "Administración", 0, "small-icon svgcollege-043-test", 4, null });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[] { "Credenciales", 10, null, 1, "Credentials" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Order", "Url" },
                values: new object[] { "Cambiar Contraseña", 2, "Password" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[] { "Horarios", 0, "small-icon svgcollege-005-alarm", 3, null });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[] { "Crear Horarios", 13, null, 1, "ScheduleMaker" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Order", "Url" },
                values: new object[] { "Horario Por Asignatura", 2, "ScheduleMaker?type=1" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Order", "Url" },
                values: new object[] { "Horario Por Curso", 3, "ScheduleMaker?type=2" });

            migrationBuilder.UpdateData(
                table: "MenuOptions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "Order", "Url" },
                values: new object[] { "Horario Por Profesor", 4, "ScheduleMaker?type=3" });

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Score",
                value: 2.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Score",
                value: 1.5m);

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
                value: 3.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 5,
                column: "Score",
                value: 5.7m);

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
                value: 5.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 8,
                column: "Score",
                value: 1.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 9,
                column: "Score",
                value: 6.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 11,
                column: "Score",
                value: 2.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 12,
                column: "Score",
                value: 2.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 13,
                column: "Score",
                value: 2.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 14,
                column: "Score",
                value: 6.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 15,
                column: "Score",
                value: 3.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 16,
                column: "Score",
                value: 2.3m);

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
                value: 3.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 19,
                column: "Score",
                value: 6.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 21,
                column: "Score",
                value: 5.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 22,
                column: "Score",
                value: 5.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 23,
                column: "Score",
                value: 5.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 24,
                column: "Score",
                value: 4.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 25,
                column: "Score",
                value: 1.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 26,
                column: "Score",
                value: 1.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 27,
                column: "Score",
                value: 1.4m);

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
                value: 2.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 30,
                column: "Score",
                value: 2.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 31,
                column: "Score",
                value: 5.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 32,
                column: "Score",
                value: 5.1m);

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
                value: 4.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 35,
                column: "Score",
                value: 3.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 36,
                column: "Score",
                value: 5.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 37,
                column: "Score",
                value: 5.2m);

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
                value: 1.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 40,
                column: "Score",
                value: 4.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 41,
                column: "Score",
                value: 4.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 42,
                column: "Score",
                value: 5.4m);

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
                value: 2.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 45,
                column: "Score",
                value: 4.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 46,
                column: "Score",
                value: 2.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 47,
                column: "Score",
                value: 6.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 48,
                column: "Score",
                value: 1.0m);
        }
    }
}
