using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaAgropecuario.Models;
using SistemaAgropecuario.Data;
using MySqlConnector;

namespace SistemaAgropecuario.Forms
{
    public partial class frmProveedores : Form
    {
        private List<Proveedor> proveedores = new List<Proveedor>();

        public frmProveedores()
        {
            InitializeComponent();
            LlenarCombobox();
            CargarProveedoresDesdeBD();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LlenarCombobox()
        {
            cmbTipoInsumo.Items.AddRange(new string[]
            {
                "Semillas", "Fertilizantes", "Equipos", "Servicios", "Otros"
            });
        }

        // Carga proveedores desde la base de datos
        private void CargarProveedoresDesdeBD()
        {
            proveedores.Clear();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT id_proveedor, nombre_empresa, contacto_nombre,
                               direccion, telefono, email, tipo_insumo,
                               fecha_registro
                        FROM proveedores
                        WHERE estado = 'activo';";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = new Proveedor
                            {
                                IdProveedor = reader.GetInt32("id_proveedor"),
                                NombreEmpresa = reader["nombre_empresa"]?.ToString() ?? string.Empty,
                                ContactoNombre = reader["contacto_nombre"]?.ToString() ?? string.Empty,
                                Direccion = reader["direccion"]?.ToString() ?? string.Empty,
                                Telefono = reader["telefono"]?.ToString() ?? string.Empty,
                                Email = reader["email"]?.ToString() ?? string.Empty,
                                TipoInsumo = reader["tipo_insumo"]?.ToString() ?? string.Empty,
                                FechaRegistro = reader.GetDateTime("fecha_registro"),
                                Estado = "activo"
                            };

                            proveedores.Add(p);
                        }
                    }
                }

                dgvProveedores.DataSource = null;
                dgvProveedores.DataSource = proveedores;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        string query = @"
                            INSERT INTO proveedores
                                (nombre_empresa, contacto_nombre, direccion,
                                 telefono, email, tipo_insumo, fecha_registro, estado)
                            VALUES
                                (@empresa, @contacto, @direccion,
                                 @telefono, @correo, @tipo, NOW(), 'activo');";

                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@empresa", txtEmpresa.Text.Trim());
                            cmd.Parameters.AddWithValue("@contacto", txtContacto.Text.Trim());
                            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                            cmd.Parameters.AddWithValue("@correo", txtEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@tipo", cmbTipoInsumo.Text.Trim().ToLower());

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Proveedor guardado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarProveedoresDesdeBD();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar proveedor: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            if (cmbTipoInsumo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de insumo");
                cmbTipoInsumo.Focus();
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
            dgvProveedores.ClearSelection();
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
                    if (MessageBox.Show(
                        $"¿Eliminar al proveedor: {proveedor.NombreEmpresa}?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            using (var conn = DatabaseConnection.GetConnection())
                            {
                                conn.Open();

                                string query = "UPDATE proveedores SET estado = 'inactivo' WHERE id_proveedor = @id;";

                                using (var cmd = new MySqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", proveedor.IdProveedor);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show("Proveedor eliminado", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CargarProveedoresDesdeBD();
                            LimpiarFormulario();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar proveedor: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
        }
    }
}
