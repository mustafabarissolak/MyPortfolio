using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "WebSite",
                table: "Abouts");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ContactInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebSite",
                table: "ContactInfos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "WebSite",
                table: "ContactInfos");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebSite",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
