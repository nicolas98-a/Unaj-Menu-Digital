using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tp.Restaurante.AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormaEntrega",
                columns: table => new
                {
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaEntrega", x => x.FormaEntregaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMercaderia",
                columns: table => new
                {
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMercaderia", x => x.TipoMercaderiaId);
                });

            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioTotal = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comandas_FormaEntrega_FormaEntregaId",
                        column: x => x.FormaEntregaId,
                        principalTable: "FormaEntrega",
                        principalColumn: "FormaEntregaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mercaderias",
                columns: table => new
                {
                    MercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Ingredientes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Preparacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercaderias", x => x.MercaderiaId);
                    table.ForeignKey(
                        name: "FK_Mercaderias_TipoMercaderia_TipoMercaderiaId",
                        column: x => x.TipoMercaderiaId,
                        principalTable: "TipoMercaderia",
                        principalColumn: "TipoMercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComandaMercaderias",
                columns: table => new
                {
                    ComandaMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MercaderiaId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaMercaderias", x => new { x.ComandaId, x.MercaderiaId, x.ComandaMercaderiaId });
                    table.ForeignKey(
                        name: "FK_ComandaMercaderias_Comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderias_Mercaderias_MercaderiaId",
                        column: x => x.MercaderiaId,
                        principalTable: "Mercaderias",
                        principalColumn: "MercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormaEntrega",
                columns: new[] { "FormaEntregaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Salon" },
                    { 2, "Delivery" },
                    { 3, "Pedidos Ya" }
                });

            migrationBuilder.InsertData(
                table: "TipoMercaderia",
                columns: new[] { "TipoMercaderiaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Entrada" },
                    { 2, "Minutas" },
                    { 3, "Pastas" },
                    { 4, "Parrilla" },
                    { 5, "Pizzas" },
                    { 6, "Sandwich" },
                    { 7, "Ensaladas" },
                    { 8, "Bebidas" },
                    { 9, "Cerveza Artesanal" },
                    { 10, "Postres" }
                });

            migrationBuilder.InsertData(
                table: "Mercaderias",
                columns: new[] { "MercaderiaId", "Imagen", "Ingredientes", "Nombre", "Precio", "Preparacion", "TipoMercaderiaId" },
                values: new object[,]
                {
                    { 8, "https://imagenes.montevideo.com.uy/imgnoticias/201704/_W576_H432/608221.jpg", "tomate, mayonesa, etc...", "Tomates rellenos", 150, "rellenar el tomate", 1 },
                    { 1, "https://unareceta.com/wp-content/uploads/2014/07/pollo-al-horno-a-la-miel-.jpg", "pollo, condimentos,...", "Pollo al horno", 400, "al horno", 2 },
                    { 3, "https://static.misionesonline.news/wp-content/uploads/2020/05/28163533/milaaa.jpg", "carne, pan rallado, huevo, papas, condimentos,...", "Milanesas con fritas", 200, "frito", 2 },
                    { 6, "https://www.cucinare.tv/wp-content/uploads/2018/11/Pastel-de-papas.jpg", "carne picada, papas, condimentos,...", "Pastel de papas", 500, "al horno", 2 },
                    { 9, "https://media-cdn.tripadvisor.com/media/photo-s/1a/13/cd/e8/mi-plato-de-ravioles.jpg", "harina, verduras, salsa de tomate, etc...", "Ravioles con salsa", 350, "preparar los ravioles, hacer la salsa", 3 },
                    { 2, "https://www.recetas-argentinas.com/base/stock/Recipe/81-image/81-image_web.jpg", "carne, condimentos,...", "Carne asada", 600, "a la parrilla", 4 },
                    { 5, "https://http2.mlstatic.com/D_NQ_NP_777487-MLA44257220736_122020-O.jpg", "harina, muzzarella, salsa de tomate, condimentos,...", "Pizza de muzzarella", 450, "al horno", 5 },
                    { 10, "https://blog.kakaocdn.net/dn/EDJZG/btqy5S3BO90/m6OkKqvnN51sRkbiFG6PW0/img.jpg", "pan, lechuga, carne , etc...", "Sandwich completo", 350, "cortar el pan....", 6 },
                    { 11, "https://www.superama.com.mx/views/micrositio/recetas/images/comidasaludable/ensaladamixta/Web_fotoreceta.jpg", "lechuga, tomate, etc...", "Ensalada mixta", 250, "hacer la ensalada....", 7 },
                    { 4, "https://www.cocacolaespana.es/content/dam/one/es/es/body/sostenibilidad/nuestros-productos/historia-envases-coca-cola/tamanos-237.jpg", "agua, azucar, etc...", "Coca Cola", 100, "gaseosa", 8 },
                    { 7, "https://economipedia.com/wp-content/uploads/Cerveza-artesanal-1.jpg", "malta", "Cerveza", 250, "liquido", 9 },
                    { 12, "https://www.bacanal.com.ar/wp-content/uploads/2019/08/flan-casero-mixto.jpg", "huevos, leche, crema, dulce de leche, etc...", "Flan mixto", 100, "hacer el flan....", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderias_MercaderiaId",
                table: "ComandaMercaderias",
                column: "MercaderiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_FormaEntregaId",
                table: "Comandas",
                column: "FormaEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercaderias_TipoMercaderiaId",
                table: "Mercaderias",
                column: "TipoMercaderiaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandaMercaderias");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "Mercaderias");

            migrationBuilder.DropTable(
                name: "FormaEntrega");

            migrationBuilder.DropTable(
                name: "TipoMercaderia");
        }
    }
}
