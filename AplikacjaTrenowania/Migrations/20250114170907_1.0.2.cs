using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikacjaTrenowania.Migrations
{
    /// <inheritdoc />
    public partial class _102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Trening",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Trening_UserId",
                table: "Trening",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trening_AspNetUsers_UserId",
                table: "Trening",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trening_AspNetUsers_UserId",
                table: "Trening");

            migrationBuilder.DropIndex(
                name: "IX_Trening_UserId",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trening");
        }
    }
}
