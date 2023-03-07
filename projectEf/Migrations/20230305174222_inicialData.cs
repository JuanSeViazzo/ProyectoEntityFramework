using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectEf.Migrations
{
    public partial class inicialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("0af42020-57e2-4b2d-a666-a579268e75b5"), null, "personal activities", 50 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("11d14284-1d76-493f-8b12-9cd72c81cfe4"), null, "pending activities", 20 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "WorkId", "CategoryId", "CreationDate", "Description", "Title", "WorkPriority" },
                values: new object[] { new Guid("11d14284-1d76-493f-8b12-9cd72c81cf10"), new Guid("0af42020-57e2-4b2d-a666-a579268e75b5"), new DateTime(2023, 3, 5, 14, 42, 21, 984, DateTimeKind.Local).AddTicks(830), null, "finish watching a movie on netflix", 2 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "WorkId", "CategoryId", "CreationDate", "Description", "Title", "WorkPriority" },
                values: new object[] { new Guid("11d14284-1d76-493f-8b12-9cd72c81cfe4"), new Guid("11d14284-1d76-493f-8b12-9cd72c81cfe4"), new DateTime(2023, 3, 5, 14, 42, 21, 984, DateTimeKind.Local).AddTicks(816), null, "payment of public services", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "WorkId",
                keyValue: new Guid("11d14284-1d76-493f-8b12-9cd72c81cf10"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "WorkId",
                keyValue: new Guid("11d14284-1d76-493f-8b12-9cd72c81cfe4"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryId",
                keyValue: new Guid("0af42020-57e2-4b2d-a666-a579268e75b5"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryId",
                keyValue: new Guid("11d14284-1d76-493f-8b12-9cd72c81cfe4"));
        }
    }
}
