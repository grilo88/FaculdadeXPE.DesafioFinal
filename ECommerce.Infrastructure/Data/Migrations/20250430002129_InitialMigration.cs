using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    cpf = table.Column<long>(type: "INTEGER", maxLength: 11, nullable: false),
                    endereco = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    telefone = table.Column<long>(type: "INTEGER", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    valor_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cliente_id = table.Column<long>(type: "INTEGER", nullable: false),
                    data_criado = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedido_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pedido_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pedido_id = table.Column<long>(type: "INTEGER", nullable: false),
                    produto_id = table.Column<long>(type: "INTEGER", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    preco_unitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedido_item_pedido_pedido_id",
                        column: x => x.pedido_id,
                        principalTable: "pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_item_produto_produto_id",
                        column: x => x.produto_id,
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "id", "cpf", "endereco", "Nome", "telefone" },
                values: new object[,]
                {
                    { 1L, 11111111111L, "Rua Teste, 123", "Cliente Admin", 0L },
                    { 2L, 22222222222L, "Rua Teste, 124", "Cliente Comum", 0L }
                });

            migrationBuilder.InsertData(
                table: "produto",
                columns: new[] { "id", "descricao", "estoque", "nome", "preco" },
                values: new object[,]
                {
                    { 1L, "Descrição do Produto Inicial", 50, "Produto Inicial", 99.90m },
                    { 2L, "Produto com estoque maior", 100, "Produto Extra", 49.90m }
                });

            migrationBuilder.InsertData(
                table: "pedido",
                columns: new[] { "id", "cliente_id", "data_criado", "status", "valor_total" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aguardando Pagamento", 0m },
                    { 2L, 2L, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enviado", 0m }
                });

            migrationBuilder.InsertData(
                table: "pedido_item",
                columns: new[] { "id", "pedido_id", "preco_unitario", "produto_id", "quantidade" },
                values: new object[,]
                {
                    { 1L, 1L, 33.4m, 1L, 5 },
                    { 2L, 2L, 43.67m, 2L, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_cpf",
                table: "cliente",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pedido_cliente_id",
                table: "pedido",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_data_criado",
                table: "pedido",
                column: "data_criado");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_status",
                table: "pedido",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_item_pedido_id",
                table: "pedido_item",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_item_produto_id",
                table: "pedido_item",
                column: "produto_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pedido_item");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
