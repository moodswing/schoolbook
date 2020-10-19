using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class EvaluationObservationsFix5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Mal comportamiento");

            migrationBuilder.UpdateData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "StudentId", "Title" },
                values: new object[] { "Sigue sin entregar la prueba!!", 5, "Falta de respeto" });

            migrationBuilder.InsertData(
                table: "Observations",
                columns: new[] { "Id", "Date", "Description", "EvaluationId", "LastModification", "ObserverId", "StudentId", "Title" },
                values: new object[,]
                {
                    { 8, new DateTime(2020, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), "No entrega trabajo a la fecha.", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "868465e8-48d1-4b1e-96e0-87bfca64f213", 2, "Flojera maximas" },
                    { 7, new DateTime(2020, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), "Se nos jue :'(", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "868465e8-48d1-4b1e-96e0-87bfca64f213", 5, "Un trágico final" },
                    { 3, new DateTime(2020, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), "Oye hasta cuando po!", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "868465e8-48d1-4b1e-96e0-87bfca64f213", 5, "Sin interes alguno" },
                    { 5, new DateTime(2020, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), "Expulsado.", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "868465e8-48d1-4b1e-96e0-87bfca64f213", 5, "Falló en la vida" },
                    { 4, new DateTime(2020, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), "Anotación negativa!", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "868465e8-48d1-4b1e-96e0-87bfca64f213", 5, "Comportamiento agresivo" },
                    { 6, new DateTime(2020, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), "Cayó en las drogas :(", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "868465e8-48d1-4b1e-96e0-87bfca64f213", 5, "Sin esperanzas" }
                });

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Score",
                value: 4.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Score",
                value: 5.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3,
                column: "Score",
                value: 1.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 4,
                column: "Score",
                value: 2.4m);

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
                value: 6.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 7,
                column: "Score",
                value: 2.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 8,
                column: "Score",
                value: 1.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 9,
                column: "Score",
                value: 4.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 10,
                column: "Score",
                value: 2.3m);

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
                value: 1.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 13,
                column: "Score",
                value: 6.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 14,
                column: "Score",
                value: 4.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 15,
                column: "Score",
                value: 5.0m);

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
                value: 5.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 18,
                column: "Score",
                value: 3.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 19,
                column: "Score",
                value: 4.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 20,
                column: "Score",
                value: 4.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 21,
                column: "Score",
                value: 5.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 22,
                column: "Score",
                value: 5.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 23,
                column: "Score",
                value: 6.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 24,
                column: "Score",
                value: 6.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 25,
                column: "Score",
                value: 1.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 26,
                column: "Score",
                value: 2.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 27,
                column: "Score",
                value: 5.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 28,
                column: "Score",
                value: 2.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 29,
                column: "Score",
                value: 5.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 30,
                column: "Score",
                value: 3.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 31,
                column: "Score",
                value: 6.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 32,
                column: "Score",
                value: 4.8m);

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
                value: 1.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 35,
                column: "Score",
                value: 3.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 36,
                column: "Score",
                value: 1.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 37,
                column: "Score",
                value: 6.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 38,
                column: "Score",
                value: 5.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 39,
                column: "Score",
                value: 6.6m);

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
                value: 6.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 42,
                column: "Score",
                value: 1.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 43,
                column: "Score",
                value: 1.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 44,
                column: "Score",
                value: 6.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 45,
                column: "Score",
                value: 6.2m);

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
                value: 4.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 48,
                column: "Score",
                value: 5.5m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "StudentId", "Title" },
                values: new object[] { "No entrega trabajo a la fecha..", 2, null });

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Score",
                value: 2.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Score",
                value: 4.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3,
                column: "Score",
                value: 3.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 4,
                column: "Score",
                value: 4.4m);

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
                value: 5.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 7,
                column: "Score",
                value: 4.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 8,
                column: "Score",
                value: 2.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 9,
                column: "Score",
                value: 1.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 10,
                column: "Score",
                value: 3.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 11,
                column: "Score",
                value: 1.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 12,
                column: "Score",
                value: 3.1m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 13,
                column: "Score",
                value: 4.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 14,
                column: "Score",
                value: 5.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 15,
                column: "Score",
                value: 5.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 16,
                column: "Score",
                value: 4.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 17,
                column: "Score",
                value: 1.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 18,
                column: "Score",
                value: 4.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 19,
                column: "Score",
                value: 3.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 20,
                column: "Score",
                value: 7.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 21,
                column: "Score",
                value: 4.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 22,
                column: "Score",
                value: 5.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 23,
                column: "Score",
                value: 1.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 24,
                column: "Score",
                value: 4.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 25,
                column: "Score",
                value: 5.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 26,
                column: "Score",
                value: 6.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 27,
                column: "Score",
                value: 1.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 28,
                column: "Score",
                value: 5.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 29,
                column: "Score",
                value: 7.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 30,
                column: "Score",
                value: 5.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 31,
                column: "Score",
                value: 1.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 32,
                column: "Score",
                value: 5.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 33,
                column: "Score",
                value: 5.7m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 34,
                column: "Score",
                value: 6.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 35,
                column: "Score",
                value: 5.2m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 36,
                column: "Score",
                value: 1.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 37,
                column: "Score",
                value: 2.4m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 38,
                column: "Score",
                value: 3.0m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 39,
                column: "Score",
                value: 6.9m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 40,
                column: "Score",
                value: 3.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 41,
                column: "Score",
                value: 4.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 42,
                column: "Score",
                value: 1.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 43,
                column: "Score",
                value: 5.8m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 44,
                column: "Score",
                value: 4.5m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 45,
                column: "Score",
                value: 1.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 46,
                column: "Score",
                value: 3.3m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 47,
                column: "Score",
                value: 5.6m);

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 48,
                column: "Score",
                value: 6.6m);
        }
    }
}
