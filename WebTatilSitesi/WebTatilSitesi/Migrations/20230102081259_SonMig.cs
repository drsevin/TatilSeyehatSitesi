using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTatilSitesi.Migrations
{
    /// <inheritdoc />
    public partial class SonMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminSinifis_Girises_GirisiesID",
                table: "AdminSinifis");

            migrationBuilder.DropIndex(
                name: "IX_AdminSinifis_GirisiesID",
                table: "AdminSinifis");

            migrationBuilder.DropColumn(
                name: "Adminid",
                table: "AdminSinifis");

            migrationBuilder.DropColumn(
                name: "GirisiesID",
                table: "AdminSinifis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Adminid",
                table: "AdminSinifis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GirisiesID",
                table: "AdminSinifis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminSinifis_GirisiesID",
                table: "AdminSinifis",
                column: "GirisiesID");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminSinifis_Girises_GirisiesID",
                table: "AdminSinifis",
                column: "GirisiesID",
                principalTable: "Girises",
                principalColumn: "ID");
        }
    }
}
