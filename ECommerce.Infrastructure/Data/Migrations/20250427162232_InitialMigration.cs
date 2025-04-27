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

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "id", "cpf", "endereco", "Nome", "telefone" },
                values: new object[,]
                {
                    { 1L, 11111111111L, "Rua Teste, 123", "Cliente Admin", 0L },
                    { 2L, 22222222222L, "Rua Teste, 124", "Cliente Comum", 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_cpf",
                table: "cliente",
                column: "cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
