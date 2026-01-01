using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class FixAboutImageOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_AboutId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Abouts");

            migrationBuilder.AlterColumn<string>(
                name: "AboutId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AboutId",
                table: "Images",
                column: "AboutId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_AboutId",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "AboutId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AboutId",
                table: "Images",
                column: "AboutId",
                unique: true,
                filter: "[AboutId] IS NOT NULL");
        }
    }
}
