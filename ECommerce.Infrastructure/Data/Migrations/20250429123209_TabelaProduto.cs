using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TabelaProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    descricao = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estoque = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "produto",
                columns: new[] { "id", "descricao", "estoque", "nome", "preco" },
                values: new object[,]
                {
                    { 1L, "Descrição do Produto Inicial", 50, "Produto Inicial", 99.90m },
                    { 2L, "Produto com estoque maior", 100, "Produto Extra", 49.90m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produto");
        }
    }
}
