using System;

namespace SistemaAgropecuario.Models
{
    public class Inventario
    {
        public int IdInventario { get; set; }
        public int IdProducto { get; set; }

        public decimal CantidadDisponible { get; set; }
        public decimal CantidadMinima { get; set; }
        public decimal CantidadMaxima { get; set; }

        public string Ubicacion { get; set; } = string.Empty;

        public DateTime FechaUltimaActualizacion { get; set; }

        // Propiedad calculada para mostrar en el grid
        public string EstadoStock
        {
            get
            {
                if (CantidadDisponible < CantidadMinima)
                    return "STOCK BAJO";
                else if (CantidadDisponible > CantidadMaxima * 0.8m)
                    return "STOCK ALTO";
                else
                    return "NORMAL";
            }
        }
    }
}
