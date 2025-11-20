using System;

namespace SistemaAgropecuario.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string NombreEmpresa { get; set; }
        public string ContactoNombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string TipoInsumo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; } = "activo";
    }
}