using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBTestWPF.Migrations
{
    /// <inheritdoc />
    public partial class TeamCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    TeamMembers = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersWPF_TeamId",
                table: "UsersWPF",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersWPF_Team_TeamId",
                table: "UsersWPF",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersWPF_Team_TeamId",
                table: "UsersWPF");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropIndex(
                name: "IX_UsersWPF_TeamId",
                table: "UsersWPF");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "UsersWPF");
        }
    }
}
