using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SistemaAgropecuario.Models;
using SistemaAgropecuario.Data;
using MySqlConnector;

namespace SistemaAgropecuario.Forms
{
    public partial class frmProductos : Form
    {
        private List<Producto> productos = new List<Producto>();

        public frmProductos()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            LlenarCombobox();
            ConfigurarEstilos();
            CargarProductosDesdeBD();     // Primero intenta cargar de la BD

            if (productos.Count == 0)
            {
                // Si la BD está vacía, carga datos de ejemplo
                CargarDatosEjemplo();
            }
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            // Si quieres recargar aquí desde la BD, lo puedes hacer.
        }

        private void ConfigurarEstilos()
        {
            this.BackColor = Color.White;

            // Estilos para botones
            btnNuevo.BackColor = Color.FromArgb(70, 130, 180);
            btnGuardar.BackColor = Color.FromArgb(54, 77, 72); // CAMBIADO a RGB(54, 77, 72)
            btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            btnCancelar.BackColor = Color.FromArgb(108, 117, 125);

            foreach (Control control in panelBotones.Controls)
            {
                var btn = control as Button;
                if (btn != null)
                {
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                    btn.Font = new Font("Arial", 9, FontStyle.Bold);
                }
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.AutoGenerateColumns = true;
            dgvProductos.DefaultCellStyle.Font = new Font("Arial", 9);
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(54, 77, 72); // VERDE AZULADO
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LlenarCombobox()
        {
            // Valores EXACTOS según tu tabla MySQL: ENUM('fruta','verdura','grano','hortaliza','cereal','otro')
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new string[]
            {
                "fruta",
                "verdura",
                "grano",
                "hortaliza",
                "cereal",
                "otro"
            });

            cmbUnidad.Items.Clear();
            cmbUnidad.Items.AddRange(new string[]
            {
                "kg", "lb", "caja", "unidad", "saco", "bulto"
            });
        }

        private void CargarDatosEjemplo()
        {
            productos.Clear();

            productos.Add(new Producto
            {
                IdProducto = 1,
                Nombre = "Maíz Amarillo",
                Categoria = "grano",
                PrecioUnitario = 5.50m,
                UnidadMedida = "kg",
                Descripcion = "Maíz amarillo de primera calidad",
                FechaCreacion = DateTime.Now.AddDays(-30),
                Estado = "activo"
            });

            productos.Add(new Producto
            {
                IdProducto = 2,
                Nombre = "Tomate Saladette",
                Categoria = "hortaliza",
                PrecioUnitario = 3.20m,
                UnidadMedida = "kg",
                Descripcion = "Tomate fresco tipo saladette",
                FechaCreacion = DateTime.Now.AddDays(-15),
                Estado = "activo"
            });

            productos.Add(new Producto
            {
                IdProducto = 3,
                Nombre = "Frijol Negro",
                Categoria = "otro",
                PrecioUnitario = 8.75m,
                UnidadMedida = "kg",
                Descripcion = "Frijol negro seleccionado premium",
                FechaCreacion = DateTime.Now.AddDays(-7),
                Estado = "activo"
            });

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productos;
        }

        // ===================== BD: CARGAR / GUARDAR / ELIMINAR =====================

        private void CargarProductosDesdeBD()
        {
            productos.Clear();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT id_producto, nombre, descripcion, categoria,
                               precio_unitario, unidad_medida, fecha_creacion, estado
                        FROM productos
                        ORDER BY id_producto";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        int iId = reader.GetOrdinal("id_producto");
                        int iNombre = reader.GetOrdinal("nombre");
                        int iDesc = reader.GetOrdinal("descripcion");
                        int iCat = reader.GetOrdinal("categoria");
                        int iPrecio = reader.GetOrdinal("precio_unitario");
                        int iUnidad = reader.GetOrdinal("unidad_medida");
                        int iFecha = reader.GetOrdinal("fecha_creacion");
                        int iEstado = reader.GetOrdinal("estado");

                        while (reader.Read())
                        {
                            var p = new Producto
                            {
                                IdProducto = reader.GetInt32(iId),
                                Nombre = reader.GetString(iNombre),
                                Descripcion = reader.IsDBNull(iDesc) ? string.Empty : reader.GetString(iDesc),
                                Categoria = reader.IsDBNull(iCat) ? string.Empty : reader.GetString(iCat),
                                PrecioUnitario = reader.GetDecimal(iPrecio),
                                UnidadMedida = reader.IsDBNull(iUnidad) ? string.Empty : reader.GetString(iUnidad),
                                FechaCreacion = reader.GetDateTime(iFecha),
                                Estado = reader.IsDBNull(iEstado) ? "activo" : reader.GetString(iEstado)
                            };

                            productos.Add(p);
                        }
                    }
                }

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos desde la base de datos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarProductoEnBD(Producto p)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO productos
                            (nombre, descripcion, categoria, precio_unitario,
                             unidad_medida, fecha_creacion, estado)
                        VALUES
                            (@nombre, @descripcion, @categoria, @precio,
                             @unidad, @fecha, @estado);";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", p.Descripcion ?? string.Empty);
                        cmd.Parameters.AddWithValue("@categoria", p.Categoria);
                        cmd.Parameters.AddWithValue("@precio", p.PrecioUnitario);
                        cmd.Parameters.AddWithValue("@unidad", p.UnidadMedida);
                        cmd.Parameters.AddWithValue("@fecha", p.FechaCreacion);
                        cmd.Parameters.AddWithValue("@estado", p.Estado ?? "activo");

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarProductoEnBD(int idProducto)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = "DELETE FROM productos WHERE id_producto = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idProducto);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar en la base de datos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================ EVENTOS DE BOTONES ============================

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    var producto = new Producto
                    {
                        IdProducto = 0, // se asigna en la BD (AUTO_INCREMENT)
                        Nombre = txtNombre.Text.Trim(),
                        Descripcion = txtDescripcion.Text.Trim(),
                        Categoria = cmbCategoria.Text,
                        PrecioUnitario = decimal.Parse(txtPrecio.Text),
                        UnidadMedida = cmbUnidad.Text,
                        FechaCreacion = DateTime.Now,
                        Estado = "activo"
                    };

                    // Guardar en BD
                    GuardarProductoEnBD(producto);

                    MessageBox.Show("Producto guardado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar desde BD para ver el nuevo ID real
                    CargarProductosDesdeBD();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var producto = dgvProductos.SelectedRows[0].DataBoundItem as Producto;
                if (producto != null)
                {
                    if (MessageBox.Show($"¿Eliminar el producto {producto.Nombre}?",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        // Eliminar de la BD
                        EliminarProductoEnBD(producto.IdProducto);

                        MessageBox.Show("Producto eliminado", "Éxito");
                        CargarProductosDesdeBD();
                        LimpiarFormulario();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto", "Aviso");
            }
        }

        // ========================= VALIDACIONES Y UTILIDADES ========================

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación");
                txtNombre.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a cero.", "Validación");
                txtPrecio.Focus();
                return false;
            }

            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una categoría.", "Validación");
                cmbCategoria.Focus();
                return false;
            }

            if (cmbUnidad.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una unidad.", "Validación");
                cmbUnidad.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbUnidad.SelectedIndex = -1;
            dgvProductos.ClearSelection();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var producto = dgvProductos.SelectedRows[0].DataBoundItem as Producto;

                if (producto != null)
                {
                    txtNombre.Text = producto.Nombre;
                    txtDescripcion.Text = producto.Descripcion;
                    txtPrecio.Text = producto.PrecioUnitario.ToString("F2");

                    cmbCategoria.SelectedItem = producto.Categoria;
                    cmbUnidad.SelectedItem = producto.UnidadMedida;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números, control y punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Evitar más de un punto decimal
            if (e.KeyChar == '.' && sender is TextBox tb && tb.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
