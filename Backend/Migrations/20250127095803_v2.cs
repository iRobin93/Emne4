using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_forecast",
                table: "forecast");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "forecast");

            migrationBuilder.AddPrimaryKey(
                name: "PK_forecast",
                table: "forecast",
                column: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_forecast",
                table: "forecast");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "forecast",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_forecast",
                table: "forecast",
                column: "Id");
        }
    }
}
