using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaAgropecuario.Models;
using SistemaAgropecuario.Data;
using MySqlConnector;

namespace SistemaAgropecuario.Forms
{
    public partial class frmClientes : Form
    {
        private List<Cliente> clientes = new List<Cliente>();

        public frmClientes()
        {
            InitializeComponent();
            LlenarCombobox();
            CargarDatosEjemplo(); // ahora carga desde la BD

            btnCancelar.Click += btnCancelar_Click;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LlenarCombobox()
        {
            cmbTipoCliente.Items.AddRange(new string[] { "minorista", "mayorista", "distribuidor" });
        }

        // AHORA: carga los clientes desde la tabla 'clientes'
        private void CargarDatosEjemplo()
        {
            clientes.Clear();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                        SELECT id_cliente, nombre, direccion, telefono, email,
                               tipo_cliente, fecha_registro
                        FROM clientes
                        WHERE estado = 'activo';";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idxId = reader.GetOrdinal("id_cliente");
                            int idxNombre = reader.GetOrdinal("nombre");
                            int idxDireccion = reader.GetOrdinal("direccion");
                            int idxTelefono = reader.GetOrdinal("telefono");
                            int idxEmail = reader.GetOrdinal("email");
                            int idxTipo = reader.GetOrdinal("tipo_cliente");
                            int idxFecha = reader.GetOrdinal("fecha_registro");

                            var cliente = new Cliente
                            {
                                IdCliente = reader.GetInt32(idxId),
                                Nombre = !reader.IsDBNull(idxNombre) ? reader.GetString(idxNombre) : "",
                                Direccion = !reader.IsDBNull(idxDireccion) ? reader.GetString(idxDireccion) : "",
                                Telefono = !reader.IsDBNull(idxTelefono) ? reader.GetString(idxTelefono) : "",
                                Email = !reader.IsDBNull(idxEmail) ? reader.GetString(idxEmail) : "",
                                TipoCliente = !reader.IsDBNull(idxTipo) ? reader.GetString(idxTipo) : "",
                                FechaRegistro = !reader.IsDBNull(idxFecha) ? reader.GetDateTime(idxFecha) : DateTime.Now
                            };

                            clientes.Add(cliente);
                        }
                    }
                }

                dgvClientes.DataSource = null;
                dgvClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    using (var conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();

                        string sql = @"
                            INSERT INTO clientes
                                (nombre, direccion, telefono, email, tipo_cliente, fecha_registro, estado)
                            VALUES
                                (@nombre, @direccion, @telefono, @email, @tipo, NOW(), 'activo');";

                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@tipo", cmbTipoCliente.Text.ToLower());

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Cliente guardado correctamente", "Éxito");
                    CargarDatosEjemplo();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el cliente: " + ex.Message);
                }
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
                        try
                        {
                            using (var conn = DatabaseConnection.GetConnection())
                            {
                                conn.Open();

                                // Puedes cambiar por UPDATE clientes SET estado='inactivo' si quieres baja lógica
                                string sql = "DELETE FROM clientes WHERE id_cliente = @id;";

                                using (var cmd = new MySqlCommand(sql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", cliente.IdCliente);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show("Cliente eliminado");
                            CargarDatosEjemplo();
                            LimpiarFormulario();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
                        }
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

            if (string.IsNullOrWhiteSpace(cmbTipoCliente.Text))
            {
                MessageBox.Show("El tipo de cliente es obligatorio");
                cmbTipoCliente.Focus();
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

        private void frmClientes_Load(object sender, EventArgs e)
        {

        }
    }
}
