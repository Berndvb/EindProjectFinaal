using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectOefening.Repository.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Medias_MediaItemId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_MediaItemId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "MediaItemId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MediaId",
                table: "Reviews",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Medias_MediaId",
                table: "Reviews",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Medias_MediaId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_MediaId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "MediaItemId",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MediaItemId",
                table: "Reviews",
                column: "MediaItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Medias_MediaItemId",
                table: "Reviews",
                column: "MediaItemId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
