using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaAgropecuario.Models;

namespace SistemaAgropecuario.Forms
{
    public partial class frmProveedores : Form
    {
        private List<Proveedor> proveedores = new List<Proveedor>();

        public frmProveedores()
        {
            InitializeComponent();
            LlenarCombobox();
            CargarDatosEjemplo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
        private void LlenarCombobox()
        {
            cmbTipoInsumo.Items.AddRange(new string[] { "Semillas", "Fertilizantes", "Equipos", "Herramientas", "Agroquímicos" });
        }

        private void CargarDatosEjemplo()
        {
            proveedores.Clear();

            proveedores.Add(new Proveedor
            {
                IdProveedor = 1,
                NombreEmpresa = "AgroSemillas S.A.",
                ContactoNombre = "Carlos López",
                Direccion = "Zona Industrial 789",
                Telefono = "555-9012",
                Email = "ventas@agrosemillas.com",
                TipoInsumo = "Semillas"
            });

            proveedores.Add(new Proveedor
            {
                IdProveedor = 2,
                NombreEmpresa = "FertiMundo",
                ContactoNombre = "Ana Rodríguez",
                Direccion = "Av. Agricultura 321",
                Telefono = "555-3456",
                Email = "info@fertimundo.com",
                TipoInsumo = "Fertilizantes"
            });

            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = proveedores;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var nuevoProveedor = new Proveedor
                {
                    IdProveedor = proveedores.Count + 1,
                    NombreEmpresa = txtEmpresa.Text,
                    ContactoNombre = txtContacto.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text,
                    TipoInsumo = cmbTipoInsumo.Text,
                    FechaRegistro = DateTime.Now
                };

                proveedores.Add(nuevoProveedor);

                MessageBox.Show("Proveedor guardado correctamente", "Éxito");
                CargarDatosEjemplo();
                LimpiarFormulario();
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtEmpresa.Text))
            {
                MessageBox.Show("El nombre de la empresa es obligatorio");
                txtEmpresa.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            txtEmpresa.Clear();
            txtContacto.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cmbTipoInsumo.SelectedIndex = -1;
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                var proveedor = dgvProveedores.SelectedRows[0].DataBoundItem as Proveedor;
                if (proveedor != null)
                {
                    txtEmpresa.Text = proveedor.NombreEmpresa;
                    txtContacto.Text = proveedor.ContactoNombre;
                    txtDireccion.Text = proveedor.Direccion;
                    txtTelefono.Text = proveedor.Telefono;
                    txtEmail.Text = proveedor.Email;
                    cmbTipoInsumo.SelectedItem = proveedor.TipoInsumo;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                var proveedor = dgvProveedores.SelectedRows[0].DataBoundItem as Proveedor;
                if (proveedor != null)
                {
                    if (MessageBox.Show($"¿Eliminar al proveedor: {proveedor.NombreEmpresa}?",
                        "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        proveedores.RemoveAll(p => p.IdProveedor == proveedor.IdProveedor);
                        MessageBox.Show("Proveedor eliminado");
                        CargarDatosEjemplo();
                        LimpiarFormulario();
                    }
                }
            }
        }
    }
}