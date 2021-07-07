using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectOefening.Repository.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "TVSerie_Director",
                table: "Medias");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Genretype",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArtistType",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OwnerId",
                table: "Reviews",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_OwnerId",
                table: "Reviews",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_OwnerId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_OwnerId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Genretype",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ArtistType",
                table: "Artists");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TVSerie_Director",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
