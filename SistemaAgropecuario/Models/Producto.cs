using System;

namespace SistemaAgropecuario.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string UnidadMedida { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; } = "activo";

        // Para mostrar en DataGridView
        public string PrecioFormateado => PrecioUnitario.ToString("C2");
    }
}