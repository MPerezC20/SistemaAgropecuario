using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaAgropecuario.Models;

namespace SistemaAgropecuario.Forms
{
    public partial class frmVentas : Form
    {
        private List<VentaItem> carrito = new List<VentaItem>();

        public frmVentas()
        {
            InitializeComponent();
            LlenarCombobox();
            ActualizarTotal();
        }

        private void LlenarCombobox()
        {
            // Datos de ejemplo para productos
            cmbProductos.Items.AddRange(new object[] {
                new { Text = "Maíz Amarillo - $5.50/kg", Precio = 5.50m },
                new { Text = "Tomate Saladette - $3.20/kg", Precio = 3.20m },
                new { Text = "Frijol Negro - $8.75/kg", Precio = 8.75m },
                new { Text = "Zanahoria - $2.80/kg", Precio = 2.80m }
            });

            cmbProductos.DisplayMember = "Text";
            cmbProductos.ValueMember = "Precio";
        }

        private void btnProcesarVenta_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agregue productos antes de procesar la venta.",
                              "Carrito Vacío",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtClienteSeleccionado.Text == "Seleccione un cliente...")
            {
                MessageBox.Show("Debe seleccionar un cliente antes de procesar la venta.",
                              "Cliente Requerido",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = CalcularTotal();

            MessageBox.Show($"✅ Venta procesada correctamente\n\n" +
                          $"Cliente: {txtClienteSeleccionado.Text}\n" +
                          $"Productos: {carrito.Count}\n" +
                          $"Total: ${total:F2}\n\n" +
                          $"Esta funcionalidad se conectará a la base de datos",
                          "Proceso de Venta Completado",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar carrito después de la venta
            carrito.Clear();
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = carrito;
            ActualizarTotal();
            txtClienteSeleccionado.Text = "Seleccione un cliente...";
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            // Simulación de búsqueda de cliente
            string[] clientes = { "Juan Pérez (Minorista)", "María García (Mayorista)", "Carlos López (Distribuidor)" };

            string clienteSeleccionado = Microsoft.VisualBasic.Interaction.InputBox(
                "Seleccione un cliente:", "Búsqueda de Cliente", "", -1, -1);

            if (!string.IsNullOrEmpty(clienteSeleccionado))
            {
                txtClienteSeleccionado.Text = clienteSeleccionado;
                MessageBox.Show($"Cliente seleccionado: {clienteSeleccionado}",
                              "Cliente Seleccionado",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto para agregar al carrito.",
                              "Producto Requerido",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener datos del producto seleccionado
            var producto = cmbProductos.SelectedItem;
            string nombreProducto = producto.GetType().GetProperty("Text").GetValue(producto).ToString();
            decimal precio = (decimal)producto.GetType().GetProperty("Precio").GetValue(producto);
            int cantidad = (int)nudCantidad.Value;

            // Extraer solo el nombre del producto (sin precio)
            string nombre = nombreProducto.Split('-')[0].Trim();

            // Agregar al carrito
            var item = new VentaItem
            {
                Producto = nombre,
                Cantidad = cantidad,
                PrecioUnitario = precio,
                Subtotal = cantidad * precio
            };

            carrito.Add(item);

            // Actualizar DataGridView
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = carrito;

            ActualizarTotal();

            MessageBox.Show($"✅ Producto agregado al carrito\n\n" +
                          $"Producto: {nombre}\n" +
                          $"Cantidad: {cantidad}\n" +
                          $"Subtotal: ${item.Subtotal:F2}",
                          "Producto Agregado",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            if (carrito.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de cancelar la venta? Se perderán todos los productos del carrito.",
                    "Cancelar Venta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    carrito.Clear();
                    dgvCarrito.DataSource = null;
                    dgvCarrito.DataSource = carrito;
                    ActualizarTotal();
                    txtClienteSeleccionado.Text = "Seleccione un cliente...";

                    MessageBox.Show("Venta cancelada. Carrito vacío.",
                                  "Venta Cancelada",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay productos en el carrito para cancelar.",
                              "Carrito Vacío",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ActualizarTotal()
        {
            decimal total = CalcularTotal();
            lblTotal.Text = $"$ {total:F2}";
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in carrito)
            {
                total += item.Subtotal;
            }
            return total;
        }
    }

    // Clase para representar items del carrito
    public class VentaItem
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}