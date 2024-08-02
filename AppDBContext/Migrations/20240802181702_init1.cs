using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDBContext.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Admins_AdminId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Manufacturers_ManufacturerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ManufacturerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Manufacturers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_AppUserId",
                table: "Manufacturers",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AppUserId",
                table: "Admins",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_AppUserId",
                table: "Admins",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturers_AspNetUsers_AppUserId",
                table: "Manufacturers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_AppUserId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturers_AspNetUsers_AppUserId",
                table: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_AppUserId",
                table: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Admins_AppUserId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ManufacturerId",
                table: "AspNetUsers",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Admins_AdminId",
                table: "AspNetUsers",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Manufacturers_ManufacturerId",
                table: "AspNetUsers",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id");
        }
    }
}
