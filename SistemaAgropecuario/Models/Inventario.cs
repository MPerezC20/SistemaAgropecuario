using System;

namespace SistemaAgropecuario.Models
{
    public class Inventario
    {
        public int IdInventario { get; set; }
        public int IdProducto { get; set; }
        public int CantidadDisponible { get; set; }
        public int CantidadMinima { get; set; }
        public int CantidadMaxima { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }

        // Propiedades calculadas para mostrar en grid
        public string EstadoStock
        {
            get
            {
                if (CantidadDisponible < CantidadMinima)
                    return "STOCK BAJO";
                else if (CantidadDisponible > CantidadMaxima * 0.8)
                    return "STOCK ALTO";
                else
                    return "NORMAL";
            }
        }
    }
}