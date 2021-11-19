using Microsoft.EntityFrameworkCore.Migrations;

namespace US_Election.Dal.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 1,
                column: "OverrideFile",
                value: false);

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 2,
                column: "OverrideFile",
                value: false);

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 3,
                column: "OverrideFile",
                value: false);

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 4,
                column: "OverrideFile",
                value: false);

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 5,
                column: "OverrideFile",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 1,
                column: "OverrideFile",
                value: null);

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 2,
                column: "OverrideFile",
                value: null);

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 3,
                column: "OverrideFile",
                value: null);

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 4,
                column: "OverrideFile",
                value: null);

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 5,
                column: "OverrideFile",
                value: null);
        }
    }
}
