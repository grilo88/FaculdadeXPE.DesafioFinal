using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TabelasPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    data_pedido = table.Column<DateTime>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    valor_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cliente_id = table.Column<long>(type: "INTEGER", nullable: false)
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
                    id = table.Column<long>(type: "INTEGER", nullable: false),
                    pedido_id = table.Column<long>(type: "INTEGER", nullable: false),
                    PedidoId1 = table.Column<long>(type: "INTEGER", nullable: false),
                    produto_id = table.Column<long>(type: "INTEGER", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    preco_unitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido_item", x => new { x.pedido_id, x.id });
                    table.ForeignKey(
                        name: "FK_pedido_item_pedido_PedidoId1",
                        column: x => x.PedidoId1,
                        principalTable: "pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "pedido",
                columns: new[] { "id", "cliente_id", "data_pedido", "status", "valor_total" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aguardando Pagamento", 0m },
                    { 2L, 2L, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enviado", 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_pedido_cliente_id",
                table: "pedido",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_data_pedido",
                table: "pedido",
                column: "data_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_status",
                table: "pedido",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_item_PedidoId1",
                table: "pedido_item",
                column: "PedidoId1");

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
        }
    }
}
