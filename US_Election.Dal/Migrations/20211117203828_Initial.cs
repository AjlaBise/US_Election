using Microsoft.EntityFrameworkCore.Migrations;

namespace US_Election.Dal.Migrations
{
    public partial class Initial : Migration
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
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(nullable: false),
                    ElectorateId = table.Column<int>(nullable: false),
                    NumberOfVotes = table.Column<int>(nullable: false)
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
                columns: new[] { "Id", "CandidateId", "ElectorateId", "NumberOfVotes" },
                values: new object[,]
                {
                    { 1, 1, 1, 4287 },
                    { 4, 4, 1, 74287 },
                    { 2, 2, 2, 7287 },
                    { 5, 1, 2, 11287 },
                    { 3, 3, 3, 12547 }
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
                name: "Vote");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Electorate");
        }
    }
}
