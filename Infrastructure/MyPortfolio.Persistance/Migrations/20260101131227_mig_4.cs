using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaAccounts_Abouts_AboutId",
                table: "SocialMediaAccounts");

            migrationBuilder.DropIndex(
                name: "IX_SocialMediaAccounts_AboutId",
                table: "SocialMediaAccounts");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "SocialMediaAccounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutId",
                table: "SocialMediaAccounts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaAccounts_AboutId",
                table: "SocialMediaAccounts",
                column: "AboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaAccounts_Abouts_AboutId",
                table: "SocialMediaAccounts",
                column: "AboutId",
                principalTable: "Abouts",
                principalColumn: "Id");
        }
    }
}
