using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace clean.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id_Categoria = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigoCategoria = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id_Categoria);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id_Producto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigoProducto = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Precio = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id_Producto);
                });

            migrationBuilder.CreateTable(
                name: "Producto_Categorias",
                columns: table => new
                {
                    Id_Producto_Categoria = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoria_id = table.Column<int>(type: "integer", nullable: false),
                    producto_id = table.Column<int>(type: "integer", nullable: false),
                    Id_Categoria = table.Column<int>(type: "integer", nullable: true),
                    Id_Producto = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto_Categorias", x => x.Id_Producto_Categoria);
                    table.ForeignKey(
                        name: "FK_Producto_Categorias_Categorias_Id_Categoria",
                        column: x => x.Id_Categoria,
                        principalTable: "Categorias",
                        principalColumn: "Id_Categoria");
                    table.ForeignKey(
                        name: "FK_Producto_Categorias_Productos_Id_Producto",
                        column: x => x.Id_Producto,
                        principalTable: "Productos",
                        principalColumn: "Id_Producto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Categorias_Id_Categoria",
                table: "Producto_Categorias",
                column: "Id_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Categorias_Id_Producto",
                table: "Producto_Categorias",
                column: "Id_Producto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto_Categorias");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
