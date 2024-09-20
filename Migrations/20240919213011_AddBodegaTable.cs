using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace induccionef.Migrations
{
    /// <inheritdoc />
    public partial class AddBodegaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodegaId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bodegas",
                columns: table => new
                {
                    BodegaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodegas", x => x.BodegaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BodegaId",
                table: "Products",
                column: "BodegaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Bodegas_BodegaId",
                table: "Products",
                column: "BodegaId",
                principalTable: "Bodegas",
                principalColumn: "BodegaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Bodegas_BodegaId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Bodegas");

            migrationBuilder.DropIndex(
                name: "IX_Products_BodegaId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BodegaId",
                table: "Products");
        }
    }
}
