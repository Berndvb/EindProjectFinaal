using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectOefening.Repository.Migrations
{
    public partial class foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_FilmId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_FilmId1",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "FilmId1",
                table: "Artists",
                newName: "DirectorId");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "Artists",
                newName: "ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_FilmId1",
                table: "Artists",
                newName: "IX_Artists_DirectorId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_FilmId",
                table: "Artists",
                newName: "IX_Artists_ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Medias_ActorId",
                table: "Artists",
                column: "ActorId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Medias_DirectorId",
                table: "Artists",
                column: "DirectorId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_ActorId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Medias_DirectorId",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "DirectorId",
                table: "Artists",
                newName: "FilmId1");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "Artists",
                newName: "FilmId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_DirectorId",
                table: "Artists",
                newName: "IX_Artists_FilmId1");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_ActorId",
                table: "Artists",
                newName: "IX_Artists_FilmId");

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
        }
    }
}
