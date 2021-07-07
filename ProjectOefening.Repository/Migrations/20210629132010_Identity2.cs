using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectOefening.Repository.Migrations
{
    public partial class Identity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_OwnerId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_OwnerId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_OwnerId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_OwnerId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Playlists");

            migrationBuilder.AddColumn<string>(
                name: "EmailAdress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAdress",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Playlists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OwnerId",
                table: "Reviews",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_OwnerId",
                table: "Playlists",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_OwnerId",
                table: "Playlists",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_OwnerId",
                table: "Reviews",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
