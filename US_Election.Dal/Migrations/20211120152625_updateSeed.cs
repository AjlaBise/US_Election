using Microsoft.EntityFrameworkCore.Migrations;

namespace US_Election.Dal.Migrations
{
    public partial class updateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 1,
                column: "NumberOfVotes",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ElectorateId", "NumberOfVotes" },
                values: new object[] { 1, 0 });

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ElectorateId", "NumberOfVotes" },
                values: new object[] { 1, 0 });

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 4,
                column: "NumberOfVotes",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CandidateId", "ElectorateId", "NumberOfVotes" },
                values: new object[] { 5, 1, 0 });

            migrationBuilder.InsertData(
                table: "Vote",
                columns: new[] { "Id", "CandidateId", "ElectorateId", "NumberOfVotes", "OverrideFile" },
                values: new object[,]
                {
                    { 6, 1, 2, 0, false },
                    { 7, 2, 2, 0, false },
                    { 8, 3, 2, 0, false },
                    { 9, 4, 2, 0, false },
                    { 10, 5, 2, 0, false },
                    { 11, 1, 3, 0, false },
                    { 12, 2, 3, 0, false },
                    { 13, 3, 3, 0, false },
                    { 14, 4, 3, 0, false },
                    { 15, 5, 3, 0, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 1,
                column: "NumberOfVotes",
                value: 4287);

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ElectorateId", "NumberOfVotes" },
                values: new object[] { 2, 7287 });

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ElectorateId", "NumberOfVotes" },
                values: new object[] { 3, 12547 });

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 4,
                column: "NumberOfVotes",
                value: 74287);

            migrationBuilder.UpdateData(
                table: "Vote",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CandidateId", "ElectorateId", "NumberOfVotes" },
                values: new object[] { 1, 2, 11287 });
        }
    }
}
