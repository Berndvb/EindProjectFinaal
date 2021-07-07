using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectOefening.Repository.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistMedia");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Host",
                table: "Medias");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmId1",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MusicId",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PodcastId",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PodcastId1",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TVSerieId",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TVSerieId1",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_ArtistId",
                table: "Medias",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_FilmId",
                table: "Artists",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_FilmId1",
                table: "Artists",
                column: "FilmId1");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_MusicId",
                table: "Artists",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_PodcastId",
                table: "Artists",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_PodcastId1",
                table: "Artists",
                column: "PodcastId1");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_TVSerieId",
                table: "Artists",
                column: "TVSerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_TVSerieId1",
                table: "Artists",
                column: "TVSerieId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Medias_FilmId",
                table: "Artists",
                column: "FilmId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Medias_FilmId1",
                table: "Artists",
                column: "FilmId1",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Medias_MusicId",
                table: "Artists",
                column: "MusicId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Medias_PodcastId",
                table: "Artists",
                column: "PodcastId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Medias_PodcastId1",
                table: "Artists",
                column: "PodcastId1",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Medias_TVSerieId",
                table: "Artists",
                column: "TVSerieId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Medias_TVSerieId1",
                table: "Artists",
                column: "TVSerieId1",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Artists_ArtistId",
                table: "Medias",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_FilmId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_FilmId1",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_MusicId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_PodcastId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_PodcastId1",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_TVSerieId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_TVSerieId1",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Artists_ArtistId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_ArtistId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Artists_FilmId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_FilmId1",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_MusicId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_PodcastId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_PodcastId1",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_TVSerieId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_TVSerieId1",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "FilmId1",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "MusicId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "PodcastId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "PodcastId1",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "TVSerieId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "TVSerieId1",
                table: "Artists");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Host",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArtistMedia",
                columns: table => new
                {
                    ArtistsId = table.Column<int>(type: "int", nullable: false),
                    MediasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistMedia", x => new { x.ArtistsId, x.MediasId });
                    table.ForeignKey(
                        name: "FK_ArtistMedia_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistMedia_Medias_MediasId",
                        column: x => x.MediasId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMedia_MediasId",
                table: "ArtistMedia",
                column: "MediasId");
        }
    }
}
