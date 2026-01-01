using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WelcomeAreas_Images_ImageId",
                table: "WelcomeAreas");

            migrationBuilder.DropIndex(
                name: "IX_WelcomeAreas_ImageId",
                table: "WelcomeAreas");

            migrationBuilder.DropIndex(
                name: "IX_Images_AboutId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "WelcomeAreas");

            migrationBuilder.AlterColumn<string>(
                name: "AboutId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "WelcomeAreaId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AboutId",
                table: "Images",
                column: "AboutId",
                unique: true,
                filter: "[AboutId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_WelcomeAreaId",
                table: "Images",
                column: "WelcomeAreaId",
                unique: true,
                filter: "[WelcomeAreaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_WelcomeAreas_WelcomeAreaId",
                table: "Images",
                column: "WelcomeAreaId",
                principalTable: "WelcomeAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_WelcomeAreas_WelcomeAreaId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AboutId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_WelcomeAreaId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "WelcomeAreaId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "WelcomeAreas",
                type: "nvarchar(450)",
                nullable: true);

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
                name: "IX_WelcomeAreas_ImageId",
                table: "WelcomeAreas",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AboutId",
                table: "Images",
                column: "AboutId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WelcomeAreas_Images_ImageId",
                table: "WelcomeAreas",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
