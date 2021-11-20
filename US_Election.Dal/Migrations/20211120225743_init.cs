using Microsoft.EntityFrameworkCore.Migrations;

namespace US_Election.Dal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Electorate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electorate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exception",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorMessage = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exception", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(nullable: false),
                    ElectorateId = table.Column<int>(nullable: false),
                    NumberOfVotes = table.Column<int>(nullable: false),
                    OverrideFile = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vote_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vote_Electorate_ElectorateId",
                        column: x => x.ElectorateId,
                        principalTable: "Electorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Candidate",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "DT", "Donald Trump" },
                    { 2, "HC", "Hillary Clinton" },
                    { 3, "JB", " Joe Biden" },
                    { 4, "JFK", "  John F. Kennedy" },
                    { 5, "JR", "Jack Randall" }
                });

            migrationBuilder.InsertData(
                table: "Electorate",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "New York" },
                    { 2, "Washington" },
                    { 3, "Texas" }
                });

            migrationBuilder.InsertData(
                table: "Vote",
                columns: new[] { "Id", "CandidateId", "ElectorateId", "NumberOfVotes", "OverrideFile" },
                values: new object[,]
                {
                    { 1, 1, 1, 0, false },
                    { 2, 2, 1, 0, false },
                    { 3, 3, 1, 0, false },
                    { 4, 4, 1, 0, false },
                    { 5, 5, 1, 0, false },
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

            migrationBuilder.CreateIndex(
                name: "IX_Vote_CandidateId",
                table: "Vote",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_ElectorateId",
                table: "Vote",
                column: "ElectorateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exception");

            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Electorate");
        }
    }
}
