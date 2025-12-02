using System;

namespace SistemaAgropecuario.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;

        public decimal PrecioUnitario { get; set; }

        public string UnidadMedida { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; }

        public string Estado { get; set; } = "activo";

        // Para mostrar formato de precio
        public string PrecioFormateado => PrecioUnitario.ToString("C2");
    }
}
