using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SistemaAgropecuario.Models;

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
            CargarDatosEjemplo();
            ConfigurarEstilos();
        }

        private void ConfigurarEstilos()
        {
            this.BackColor = Color.White;

            // Estilos para botones
            btnNuevo.BackColor = Color.FromArgb(70, 130, 180);
            btnGuardar.BackColor = Color.FromArgb(34, 139, 34);
            btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            btnCancelar.BackColor = Color.FromArgb(108, 117, 125);

            foreach (Control control in panelBotones.Controls)
            {
                if (control is Button btn)
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
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34);
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LlenarCombobox()
        {
            cmbCategoria.Items.AddRange(new string[] { "Granos", "Hortalizas", "Frutas", "Verduras", "Cereales", "Legumbres" });
            cmbUnidad.Items.AddRange(new string[] { "kg", "lb", "caja", "unidad", "saco", "bulto" });
        }

        private void CargarDatosEjemplo()
        {
            productos.Clear();

            productos.Add(new Producto
            {
                IdProducto = 1,
                Nombre = "Maíz Amarillo",
                Categoria = "Granos",
                PrecioUnitario = 5.50m,
                UnidadMedida = "kg",
                Descripcion = "Maíz amarillo de primera calidad",
                FechaCreacion = DateTime.Now.AddDays(-30)
            });

            productos.Add(new Producto
            {
                IdProducto = 2,
                Nombre = "Tomate Saladette",
                Categoria = "Hortalizas",
                PrecioUnitario = 3.20m,
                UnidadMedida = "kg",
                Descripcion = "Tomate fresco tipo saladette",
                FechaCreacion = DateTime.Now.AddDays(-15)
            });

            productos.Add(new Producto
            {
                IdProducto = 3,
                Nombre = "Frijol Negro",
                Categoria = "Legumbres",
                PrecioUnitario = 8.75m,
                UnidadMedida = "kg",
                Descripcion = "Frijol negro seleccionado premium",
                FechaCreacion = DateTime.Now.AddDays(-7)
            });

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productos;
        }

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
                        IdProducto = productos.Count + 1,
                        Nombre = txtNombre.Text.Trim(),
                        Descripcion = txtDescripcion.Text.Trim(),
                        Categoria = cmbCategoria.Text,
                        PrecioUnitario = decimal.Parse(txtPrecio.Text),
                        UnidadMedida = cmbUnidad.Text,
                        FechaCreacion = DateTime.Now
                    };

                    productos.Add(producto);

                    MessageBox.Show("✅ Producto guardado correctamente", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDatosEjemplo();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Error al guardar: {ex.Message}", "Error",
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
                    if (MessageBox.Show($"¿Eliminar: {producto.Nombre}?",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        productos.RemoveAll(p => p.IdProducto == producto.IdProducto);
                        MessageBox.Show("✅ Producto eliminado", "Éxito");
                        CargarDatosEjemplo();
                        LimpiarFormulario();
                    }
                }
            }
            else
            {
                MessageBox.Show("⚠️ Seleccione un producto", "Advertencia");
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("📝 Nombre obligatorio", "Validación");
                txtNombre.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("💰 Precio debe ser mayor a cero", "Validación");
                txtPrecio.Focus();
                return false;
            }

            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("📂 Seleccione categoría", "Validación");
                cmbCategoria.Focus();
                return false;
            }

            if (cmbUnidad.SelectedIndex == -1)
            {
                MessageBox.Show("⚖️ Seleccione unidad", "Validación");
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}