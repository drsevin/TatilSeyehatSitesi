using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTatilSitesi.Migrations
{
    /// <inheritdoc />
    public partial class YeniMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kullanici",
                table: "AdminSinifis");

            migrationBuilder.AlterColumn<string>(
                name: "Sifre",
                table: "AdminSinifis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "AdminSinifis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "AdminSinifis");

            migrationBuilder.AlterColumn<string>(
                name: "Sifre",
                table: "AdminSinifis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Kullanici",
                table: "AdminSinifis",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
