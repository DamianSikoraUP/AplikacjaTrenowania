using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikacjaTrenowania.Migrations
{
    /// <inheritdoc />
    public partial class _103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RodzajTreningu",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "WybierzCwiczenie",
                table: "Trening");

            migrationBuilder.AddColumn<int>(
                name: "IdKategorii",
                table: "Trening",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DefinicjaTreningu",
                columns: table => new
                {
                    IdKategorii = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RodzajTreningu = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    WybierzCwiczenie = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefinicjaTreningu", x => x.IdKategorii);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trening_IdKategorii",
                table: "Trening",
                column: "IdKategorii",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trening_DefinicjaTreningu_IdKategorii",
                table: "Trening",
                column: "IdKategorii",
                principalTable: "DefinicjaTreningu",
                principalColumn: "IdKategorii",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trening_DefinicjaTreningu_IdKategorii",
                table: "Trening");

            migrationBuilder.DropTable(
                name: "DefinicjaTreningu");

            migrationBuilder.DropIndex(
                name: "IX_Trening_IdKategorii",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "IdKategorii",
                table: "Trening");

            migrationBuilder.AddColumn<string>(
                name: "RodzajTreningu",
                table: "Trening",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WybierzCwiczenie",
                table: "Trening",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
