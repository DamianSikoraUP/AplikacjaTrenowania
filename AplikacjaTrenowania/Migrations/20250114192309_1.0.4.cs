using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikacjaTrenowania.Migrations
{
    /// <inheritdoc />
    public partial class _104 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trening_IdKategorii",
                table: "Trening");

            migrationBuilder.CreateIndex(
                name: "IX_Trening_IdKategorii",
                table: "Trening",
                column: "IdKategorii");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trening_IdKategorii",
                table: "Trening");

            migrationBuilder.CreateIndex(
                name: "IX_Trening_IdKategorii",
                table: "Trening",
                column: "IdKategorii",
                unique: true);
        }
    }
}
