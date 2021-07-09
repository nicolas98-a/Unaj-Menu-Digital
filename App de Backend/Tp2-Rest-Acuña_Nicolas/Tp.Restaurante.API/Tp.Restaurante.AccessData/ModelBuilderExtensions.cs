using Microsoft.EntityFrameworkCore;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.AccessData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Cargo tipos de mercaderia en la tabla TipoMercaderia de la base de datos
            modelBuilder.Entity<TipoMercaderia>(entity =>
            {
                entity.ToTable("TipoMercaderia");
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 1,
                    Descripcion = "Entrada"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 2,
                    Descripcion = "Minutas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 3,
                    Descripcion = "Pastas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 4,
                    Descripcion = "Parrilla"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 5,
                    Descripcion = "Pizzas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 6,
                    Descripcion = "Sandwich"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 7,
                    Descripcion = "Ensaladas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 8,
                    Descripcion = "Bebidas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 9,
                    Descripcion = "Cerveza Artesanal"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 10,
                    Descripcion = "Postres"
                });
            });

            //Cargo formas de entrge a la tabla FormEntrega de la base de datos
            modelBuilder.Entity<FormaEntrega>(entity =>
            {
                entity.ToTable("FormaEntrega");
                entity.HasData(new FormaEntrega
                {
                    FormaEntregaId = 1,
                    Descripcion = "Salon"
                });
                entity.HasData(new FormaEntrega
                {
                    FormaEntregaId = 2,
                    Descripcion = "Delivery"
                });
                entity.HasData(new FormaEntrega
                {
                    FormaEntregaId = 3,
                    Descripcion = "Pedidos Ya"
                });
            });
            // Cargo mercaderias a la base de datos
            
            modelBuilder.Entity<Mercaderia>(entity =>
            {
                entity.ToTable("Mercaderias");
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 1,
                    Nombre = "Pollo al horno",
                    Precio = 400,
                    Ingredientes = "pollo, condimentos,...",
                    Preparacion = "al horno",
                    Imagen = "https://unareceta.com/wp-content/uploads/2014/07/pollo-al-horno-a-la-miel-.jpg",
                    TipoMercaderiaId = 2

                });
                
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 2,
                    Nombre = "Carne asada",
                    Precio = 600,
                    Ingredientes = "carne, condimentos,...",
                    Preparacion = "a la parrilla",
                    Imagen = "https://www.recetas-argentinas.com/base/stock/Recipe/81-image/81-image_web.jpg",
                    TipoMercaderiaId = 4

                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 3,
                    Nombre = "Milanesas con fritas",
                    Precio = 200,
                    Ingredientes = "carne, pan rallado, huevo, papas, condimentos,...",
                    Preparacion = "frito",
                    Imagen = "https://static.misionesonline.news/wp-content/uploads/2020/05/28163533/milaaa.jpg",
                    TipoMercaderiaId = 2

                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 4,
                    Nombre = "Coca Cola",
                    Precio = 100,
                    Ingredientes = "agua, azucar, etc...",
                    Preparacion = "gaseosa",
                    Imagen = "https://www.cocacolaespana.es/content/dam/one/es/es/body/sostenibilidad/nuestros-productos/historia-envases-coca-cola/tamanos-237.jpg",
                    TipoMercaderiaId = 8

                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 5,
                    Nombre = "Pizza de muzzarella",
                    Precio = 450,
                    Ingredientes = "harina, muzzarella, salsa de tomate, condimentos,...",
                    Preparacion = "al horno",
                    Imagen = "https://http2.mlstatic.com/D_NQ_NP_777487-MLA44257220736_122020-O.jpg",
                    TipoMercaderiaId = 5

                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 6,
                    Nombre = "Pastel de papas",
                    Precio = 500,
                    Ingredientes = "carne picada, papas, condimentos,...",
                    Preparacion = "al horno",
                    Imagen = "https://www.cucinare.tv/wp-content/uploads/2018/11/Pastel-de-papas.jpg",
                    TipoMercaderiaId = 2

                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 7,
                    Nombre = "Cerveza",
                    Precio = 250,
                    Ingredientes = "malta",
                    Preparacion = "liquido",
                    Imagen = "https://economipedia.com/wp-content/uploads/Cerveza-artesanal-1.jpg",
                    TipoMercaderiaId = 9

                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 8,
                    Nombre = "Tomates rellenos",
                    Precio = 150,
                    Ingredientes = "tomate, mayonesa, etc...",
                    Preparacion = "rellenar el tomate",
                    Imagen = "https://imagenes.montevideo.com.uy/imgnoticias/201704/_W576_H432/608221.jpg",
                    TipoMercaderiaId = 1

                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 9,
                    Nombre = "Ravioles con salsa",
                    Precio = 350,
                    Ingredientes = "harina, verduras, salsa de tomate, etc...",
                    Preparacion = "preparar los ravioles, hacer la salsa",
                    Imagen = "https://media-cdn.tripadvisor.com/media/photo-s/1a/13/cd/e8/mi-plato-de-ravioles.jpg",
                    TipoMercaderiaId = 3

                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 10,
                    Nombre = "Sandwich completo",
                    Precio = 350,
                    Ingredientes = "pan, lechuga, carne , etc...",
                    Preparacion = "cortar el pan....",
                    Imagen = "https://blog.kakaocdn.net/dn/EDJZG/btqy5S3BO90/m6OkKqvnN51sRkbiFG6PW0/img.jpg",
                    TipoMercaderiaId = 6

                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 11,
                    Nombre = "Ensalada mixta",
                    Precio = 250,
                    Ingredientes = "lechuga, tomate, etc...",
                    Preparacion = "hacer la ensalada....",
                    Imagen = "https://www.superama.com.mx/views/micrositio/recetas/images/comidasaludable/ensaladamixta/Web_fotoreceta.jpg",
                    TipoMercaderiaId = 7

                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 12,
                    Nombre = "Flan mixto",
                    Precio = 100,
                    Ingredientes = "huevos, leche, crema, dulce de leche, etc...",
                    Preparacion = "hacer el flan....",
                    Imagen = "https://www.bacanal.com.ar/wp-content/uploads/2019/08/flan-casero-mixto.jpg",
                    TipoMercaderiaId = 10

                });
                
            });
        
        }
    }
}
