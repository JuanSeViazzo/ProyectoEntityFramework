using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectEf.Migrations
{
    public partial class ColumnWeightCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Categoria",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Categoria");
        }
    }
}
