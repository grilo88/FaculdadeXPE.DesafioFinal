using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FaculdadeXPE.ECommerceOnline.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    login = table.Column<string>(type: "TEXT", nullable: false),
                    senha = table.Column<string>(type: "TEXT", nullable: false),
                    data_criado = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    cpf = table.Column<long>(type: "INTEGER", maxLength: 11, nullable: false),
                    endereco = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    telefone = table.Column<long>(type: "INTEGER", maxLength: 15, nullable: false),
                    usuario_id = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_cliente_usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "id", "login", "nome", "senha" },
                values: new object[,]
                {
                    { 1L, "admin", "Usuário Administrador", "123456" },
                    { 2L, "comum", "Usuário Comum", "123456" }
                });

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "id", "cpf", "endereco", "Nome", "telefone", "usuario_id" },
                values: new object[,]
                {
                    { 1L, 11111111111L, "Rua Teste, 123", "Cliente Admin", 0L, 1L },
                    { 2L, 22222222222L, "Rua Teste, 124", "Cliente Comum", 0L, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_cpf",
                table: "cliente",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cliente_usuario_id",
                table: "cliente",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_login",
                table: "usuario",
                column: "login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
