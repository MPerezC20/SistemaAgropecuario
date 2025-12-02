using System;

namespace SistemaAgropecuario.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }

        public string NombreEmpresa { get; set; } = string.Empty;

        public string ContactoNombre { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string TipoInsumo { get; set; } = string.Empty;

        public DateTime FechaRegistro { get; set; }

        public string Estado { get; set; } = "activo";
    }
}
