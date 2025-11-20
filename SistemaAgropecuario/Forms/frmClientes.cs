using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaAgropecuario.Models;

namespace SistemaAgropecuario.Forms
{
    public partial class frmClientes : Form
    {
        private List<Cliente> clientes = new List<Cliente>();

        public frmClientes()
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
            cmbTipoCliente.Items.AddRange(new string[] { "Minorista", "Mayorista", "Distribuidor" });
        }

        private void CargarDatosEjemplo()
        {
            clientes.Clear();

            clientes.Add(new Cliente
            {
                IdCliente = 1,
                Nombre = "Juan Pérez",
                Direccion = "Av. Principal 123",
                Telefono = "555-1234",
                Email = "juan@email.com",
                TipoCliente = "Minorista"
            });

            clientes.Add(new Cliente
            {
                IdCliente = 2,
                Nombre = "María García",
                Direccion = "Calle Secundaria 456",
                Telefono = "555-5678",
                Email = "maria@email.com",
                TipoCliente = "Mayorista"
            });

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientes;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var nuevoCliente = new Cliente
                {
                    IdCliente = clientes.Count + 1,
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text,
                    TipoCliente = cmbTipoCliente.Text,
                    FechaRegistro = DateTime.Now
                };

                clientes.Add(nuevoCliente);

                MessageBox.Show("Cliente guardado correctamente", "Éxito");
                CargarDatosEjemplo();
                LimpiarFormulario();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                var cliente = dgvClientes.SelectedRows[0].DataBoundItem as Cliente;
                if (cliente != null)
                {
                    if (MessageBox.Show($"¿Eliminar al cliente: {cliente.Nombre}?",
                        "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        clientes.RemoveAll(c => c.IdCliente == cliente.IdCliente);
                        MessageBox.Show("Cliente eliminado");
                        CargarDatosEjemplo();
                        LimpiarFormulario();
                    }
                }
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio");
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cmbTipoCliente.SelectedIndex = -1;
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                var cliente = dgvClientes.SelectedRows[0].DataBoundItem as Cliente;
                if (cliente != null)
                {
                    txtNombre.Text = cliente.Nombre;
                    txtDireccion.Text = cliente.Direccion;
                    txtTelefono.Text = cliente.Telefono;
                    txtEmail.Text = cliente.Email;
                    cmbTipoCliente.SelectedItem = cliente.TipoCliente;
                }
            }
        }
    }
}