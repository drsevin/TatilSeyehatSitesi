using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTatilSitesi.Migrations
{
    /// <inheritdoc />
    public partial class GuncelMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YorumSinifis_BlogSinifis_BlogID",
                table: "YorumSinifis");

            migrationBuilder.RenameColumn(
                name: "BlogID",
                table: "YorumSinifis",
                newName: "Blogid");

            migrationBuilder.RenameIndex(
                name: "IX_YorumSinifis_BlogID",
                table: "YorumSinifis",
                newName: "IX_YorumSinifis_Blogid");

            migrationBuilder.AlterColumn<int>(
                name: "Blogid",
                table: "YorumSinifis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_YorumSinifis_BlogSinifis_Blogid",
                table: "YorumSinifis",
                column: "Blogid",
                principalTable: "BlogSinifis",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YorumSinifis_BlogSinifis_Blogid",
                table: "YorumSinifis");

            migrationBuilder.RenameColumn(
                name: "Blogid",
                table: "YorumSinifis",
                newName: "BlogID");

            migrationBuilder.RenameIndex(
                name: "IX_YorumSinifis_Blogid",
                table: "YorumSinifis",
                newName: "IX_YorumSinifis_BlogID");

            migrationBuilder.AlterColumn<int>(
                name: "BlogID",
                table: "YorumSinifis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_YorumSinifis_BlogSinifis_BlogID",
                table: "YorumSinifis",
                column: "BlogID",
                principalTable: "BlogSinifis",
                principalColumn: "ID");
        }
    }
}
