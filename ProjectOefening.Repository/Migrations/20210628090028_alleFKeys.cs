using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectOefening.Repository.Migrations
{
    public partial class alleFKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropIndex(
                name: "IX_Artists_MusicId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_PodcastId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "MusicId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "PodcastId",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "TVSerieId1",
                table: "Artists",
                newName: "MusicArtistId");

            migrationBuilder.RenameColumn(
                name: "TVSerieId",
                table: "Artists",
                newName: "HostId");

            migrationBuilder.RenameColumn(
                name: "PodcastId1",
                table: "Artists",
                newName: "GuestId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_TVSerieId1",
                table: "Artists",
                newName: "IX_Artists_MusicArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_TVSerieId",
                table: "Artists",
                newName: "IX_Artists_HostId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_PodcastId1",
                table: "Artists",
                newName: "IX_Artists_GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Medias_GuestId",
                table: "Artists",
                column: "GuestId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Medias_HostId",
                table: "Artists",
                column: "HostId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Medias_MusicArtistId",
                table: "Artists",
                column: "MusicArtistId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_GuestId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_HostId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_MusicArtistId",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "MusicArtistId",
                table: "Artists",
                newName: "TVSerieId1");

            migrationBuilder.RenameColumn(
                name: "HostId",
                table: "Artists",
                newName: "TVSerieId");

            migrationBuilder.RenameColumn(
                name: "GuestId",
                table: "Artists",
                newName: "PodcastId1");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_MusicArtistId",
                table: "Artists",
                newName: "IX_Artists_TVSerieId1");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_HostId",
                table: "Artists",
                newName: "IX_Artists_TVSerieId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_GuestId",
                table: "Artists",
                newName: "IX_Artists_PodcastId1");

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

            migrationBuilder.CreateIndex(
                name: "IX_Artists_MusicId",
                table: "Artists",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_PodcastId",
                table: "Artists",
                column: "PodcastId");

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
        }
    }
}
