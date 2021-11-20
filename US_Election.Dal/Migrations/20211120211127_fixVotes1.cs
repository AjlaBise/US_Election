using Microsoft.EntityFrameworkCore.Migrations;

namespace US_Election.Dal.Migrations
{
    public partial class fixVotes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateName",
                table: "Vote");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CandidateName",
                table: "Vote",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
