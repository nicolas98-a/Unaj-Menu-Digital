namespace Tp.Restaurante.Domain.DTOs
{
    public class ResponseGetAllMercaderiaDto
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public int Precio { get; set; }

        public string Ingredientes { get; set; }

        public string Preparacion { get; set; }

        public string Imagen { get; set; }
        public int MercaderiaId { get; set; }
    }
}
