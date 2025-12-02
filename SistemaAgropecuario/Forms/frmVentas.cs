using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaAgropecuario.Models;
using SistemaAgropecuario.Data;
using MySqlConnector;
using Microsoft.VisualBasic; // Para Interaction.InputBox

namespace SistemaAgropecuario.Forms
{
    public partial class frmVentas : Form
    {
        private List<VentaItem> carrito = new List<VentaItem>();
        private List<ClienteMini> clientes = new List<ClienteMini>();
        private int? clienteSeleccionadoId = null;

        private List<ProductoCombo> productos = new List<ProductoCombo>();

        public frmVentas()
        {
            InitializeComponent();
            CargarProductosDesdeBD();
            CargarClientesDesdeBD();
            ActualizarTotal();
        }

        // -------------------- CARGA DE DATOS --------------------

        private void CargarProductosDesdeBD()
        {
            productos.Clear();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT id_producto, nombre, precio_unitario 
                                     FROM productos 
                                     WHERE estado = 'activo';";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new ProductoCombo
                            {
                                IdProducto = reader.GetInt32("id_producto"),
                                Nombre = reader["nombre"]?.ToString() ?? "",
                                Precio = reader.GetDecimal("precio_unitario")
                            });
                        }
                    }
                }

                cmbProductos.DataSource = null;
                cmbProductos.DataSource = productos;
                cmbProductos.DisplayMember = "Texto";   // Maíz Amarillo - $5.50
                cmbProductos.ValueMember = "Precio";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarClientesDesdeBD()
        {
            clientes.Clear();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT id_cliente, nombre 
                                     FROM clientes 
                                     WHERE estado = 'activo';";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new ClienteMini
                            {
                                IdCliente = reader.GetInt32("id_cliente"),
                                Nombre = reader["nombre"]?.ToString() ?? ""
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtClienteSeleccionado.Text = "Seleccione un cliente...";
            clienteSeleccionadoId = null;
        }

        // -------------------- BOTÓN PROCESAR VENTA --------------------

        private void btnProcesarVenta_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agregue productos antes de procesar la venta.",
                              "Carrito Vacío",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clienteSeleccionadoId == null)
            {
                MessageBox.Show("Debe seleccionar un cliente antes de procesar la venta.",
                              "Cliente Requerido",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = CalcularTotal();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        // Insertar en VENTAS
                        string sqlVenta = @"
                            INSERT INTO ventas
                                (id_cliente, fecha_venta, total_venta, estado_venta, metodo_pago)
                            VALUES
                                (@idCliente, NOW(), @total, 'completada', 'efectivo');";

                        long idVenta;

                        using (var cmdVenta = new MySqlCommand(sqlVenta, conn, tx))
                        {
                            cmdVenta.Parameters.AddWithValue("@idCliente", clienteSeleccionadoId.Value);
                            cmdVenta.Parameters.AddWithValue("@total", total);
                            cmdVenta.ExecuteNonQuery();
                            idVenta = cmdVenta.LastInsertedId;
                        }

                        // Insertar DETALLES
                        string sqlDetalle = @"
                            INSERT INTO detalle_venta
                                (id_venta, id_producto, cantidad, precio_unitario, subtotal)
                            VALUES
                                (@idVenta, @idProd, @cant, @precio, @sub);";

                        using (var cmdDet = new MySqlCommand(sqlDetalle, conn, tx))
                        {
                            cmdDet.Parameters.Add("@idVenta", MySqlDbType.Int32);
                            cmdDet.Parameters.Add("@idProd", MySqlDbType.Int32);
                            cmdDet.Parameters.Add("@cant", MySqlDbType.Decimal);
                            cmdDet.Parameters.Add("@precio", MySqlDbType.Decimal);
                            cmdDet.Parameters.Add("@sub", MySqlDbType.Decimal);

                            foreach (var item in carrito)
                            {
                                cmdDet.Parameters["@idVenta"].Value = (int)idVenta;
                                cmdDet.Parameters["@idProd"].Value = item.IdProducto;
                                cmdDet.Parameters["@cant"].Value = item.Cantidad;
                                cmdDet.Parameters["@precio"].Value = item.PrecioUnitario;
                                cmdDet.Parameters["@sub"].Value = item.Subtotal;

                                cmdDet.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                    }
                }

                MessageBox.Show($"✅ Venta procesada correctamente\n\n" +
                              $"Cliente: {txtClienteSeleccionado.Text}\n" +
                              $"Productos: {carrito.Count}\n" +
                              $"Total: ${total:F2}",
                              "Proceso de Venta Completado",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar carrito después de la venta
                carrito.Clear();
                dgvCarrito.DataSource = null;
                dgvCarrito.DataSource = carrito;
                ActualizarTotal();
                txtClienteSeleccionado.Text = "Seleccione un cliente...";
                clienteSeleccionadoId = null;
                txtFiltroCliente.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la venta: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------- FILTRO DE CLIENTE --------------------

        private void txtFiltroCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir Enter para buscar
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                BuscarClientePorFiltro();
            }
        }

        // -------------------- BOTÓN BUSCAR CLIENTE --------------------

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarClientePorFiltro();
        }

        private void BuscarClientePorFiltro()
        {
            if (clientes.Count == 0)
            {
                MessageBox.Show("No hay clientes registrados.", "Clientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string filtro = txtFiltroCliente.Text.Trim();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                MessageBox.Show("Ingrese un ID o nombre para buscar.", "Búsqueda Vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar por ID (si es numérico)
            if (int.TryParse(filtro, out int idCliente))
            {
                var cliente = clientes.Find(c => c.IdCliente == idCliente);
                if (cliente != null)
                {
                    SeleccionarCliente(cliente);
                    return;
                }
            }

            // Buscar por nombre (búsqueda parcial)
            var clientesEncontrados = clientes.FindAll(c =>
                c.Nombre.ToLower().Contains(filtro.ToLower()));

            if (clientesEncontrados.Count == 0)
            {
                MessageBox.Show("No se encontró ningún cliente con ese criterio.",
                    "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (clientesEncontrados.Count == 1)
            {
                // Si solo hay uno, seleccionarlo directamente
                SeleccionarCliente(clientesEncontrados[0]);
            }
            else
            {
                // Si hay múltiples, mostrar lista para seleccionar
                MostrarListaClientes(clientesEncontrados);
            }
        }

        private void SeleccionarCliente(ClienteMini cliente)
        {
            clienteSeleccionadoId = cliente.IdCliente;
            txtClienteSeleccionado.Text = cliente.Nombre;

            // Opcional: mostrar mensaje de confirmación
            MessageBox.Show($"✅ Cliente seleccionado: {cliente.Nombre}",
                          "Cliente Seleccionado",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarListaClientes(List<ClienteMini> listaClientes)
        {
            string listado = "ID   -   Nombre\n\n";
            foreach (var c in listaClientes)
            {
                listado += $"{c.IdCliente} - {c.Nombre}\n";
            }

            string input = Interaction.InputBox(
                "Múltiples clientes encontrados:\n\n" + listado + "\nIngrese el ID del cliente deseado:",
                "Seleccionar Cliente",
                "", -1, -1);

            if (int.TryParse(input, out int idCli))
            {
                var cliente = listaClientes.Find(c => c.IdCliente == idCli);
                if (cliente != null)
                {
                    SeleccionarCliente(cliente);
                }
                else
                {
                    MessageBox.Show("No se encontró un cliente con ese ID en los resultados.",
                        "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // -------------------- BOTÓN AGREGAR PRODUCTO --------------------

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto para agregar al carrito.",
                              "Producto Requerido",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(cmbProductos.SelectedItem is ProductoCombo prod))
            {
                MessageBox.Show("Error al obtener el producto seleccionado.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cantidadInt = (int)nudCantidad.Value;
            if (cantidadInt <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.",
                    "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal cantidad = cantidadInt;

            var item = new VentaItem
            {
                IdProducto = prod.IdProducto,
                Producto = prod.Nombre,
                Cantidad = cantidad,
                PrecioUnitario = prod.Precio,
                Subtotal = cantidad * prod.Precio
            };

            carrito.Add(item);

            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = carrito;

            ActualizarTotal();

            MessageBox.Show($"✅ Producto agregado al carrito\n\n" +
                          $"Producto: {prod.Nombre}\n" +
                          $"Cantidad: {cantidad}\n" +
                          $"Subtotal: ${item.Subtotal:F2}",
                          "Producto Agregado",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // -------------------- BOTÓN CANCELAR VENTA --------------------

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
                    clienteSeleccionadoId = null;
                    txtFiltroCliente.Clear();

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

        // -------------------- CÁLCULOS --------------------

        private void ActualizarTotal()
        {
            decimal total = CalcularTotal();
            lblTotal.Text = $"$ {total:F2}";
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in carrito)
                total += item.Subtotal;
            return total;
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            // Establecer foco inicial
            txtFiltroCliente.Focus();
        }

        // -------------------- VALIDACIÓN DE DATAGRIDVIEW --------------------

        private void dgvCarrito_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Asegurar que el DataGridView se vea bien
            if (dgvCarrito.Columns.Count > 0)
            {
                dgvCarrito.Columns[0].HeaderText = "Producto";
                dgvCarrito.Columns[1].HeaderText = "Cantidad";
                dgvCarrito.Columns[2].HeaderText = "Precio Unitario";
                dgvCarrito.Columns[3].HeaderText = "Subtotal";

                // Formatear columnas numéricas
                if (dgvCarrito.Columns.Count >= 4)
                {
                    dgvCarrito.Columns[2].DefaultCellStyle.Format = "C2";
                    dgvCarrito.Columns[3].DefaultCellStyle.Format = "C2";
                }
            }
        }

        // --------- CLASES AUXILIARES ----------

        // Item del carrito
        public class VentaItem
        {
            public int IdProducto { get; set; }
            public string Producto { get; set; } = string.Empty;
            public decimal Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal Subtotal { get; set; }
        }

        // Para combo de productos
        internal class ProductoCombo
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public decimal Precio { get; set; }

            public string Texto => $"{Nombre} - ${Precio:F2}";
        }

        // Para selección de clientes
        internal class ClienteMini
        {
            public int IdCliente { get; set; }
            public string Nombre { get; set; } = string.Empty;
        }
    }
}