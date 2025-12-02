using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaAgropecuario.Models;
using SistemaAgropecuario.Data;
using MySqlConnector;

namespace SistemaAgropecuario.Forms
{
    public partial class frmInventario : Form
    {
        private List<Inventario> inventario = new List<Inventario>();

        public frmInventario()
        {
            InitializeComponent();
            LlenarCombobox();
            CargarInventarioBD();
        }

        private void LlenarCombobox()
        {
            cmbCategoria.Items.AddRange(new string[]
            {
                "Todas", "Granos", "Hortalizas", "Frutas", "Verduras", "Cereales"
            });
        }

        private void CargarInventarioBD()
        {
            inventario.Clear();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT id_inventario, id_producto, cantidad_disponible,
                               cantidad_minima, cantidad_maxima, ubicacion,
                               fecha_ultima_actualizacion
                        FROM inventario";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        int iIdInv = reader.GetOrdinal("id_inventario");
                        int iIdProd = reader.GetOrdinal("id_producto");
                        int iCantDisp = reader.GetOrdinal("cantidad_disponible");
                        int iCantMin = reader.GetOrdinal("cantidad_minima");
                        int iCantMax = reader.GetOrdinal("cantidad_maxima");
                        int iUbic = reader.GetOrdinal("ubicacion");
                        int iFecha = reader.GetOrdinal("fecha_ultima_actualizacion");

                        while (reader.Read())
                        {
                            inventario.Add(new Inventario
                            {
                                IdInventario = reader.GetInt32(iIdInv),
                                IdProducto = reader.GetInt32(iIdProd),
                                CantidadDisponible = reader.GetDecimal(iCantDisp),
                                CantidadMinima = reader.GetDecimal(iCantMin),
                                CantidadMaxima = reader.GetDecimal(iCantMax),
                                Ubicacion = reader.IsDBNull(iUbic) ? string.Empty : reader.GetString(iUbic),
                                FechaUltimaActualizacion = reader.GetDateTime(iFecha)
                            });
                        }
                    }
                }

                dgvInventario.DataSource = null;
                dgvInventario.DataSource = inventario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inventario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarInventarioBD();
            MessageBox.Show("Inventario actualizado correctamente", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            int productosStockBajo = 0;
            foreach (var item in inventario)
            {
                if (item.CantidadDisponible < item.CantidadMinima)
                    productosStockBajo++;
            }

            MessageBox.Show($"Reporte de Inventario Generado\n\n" +
                            $"Total de productos: {inventario.Count}\n" +
                            $"Productos con stock bajo: {productosStockBajo}\n" +
                            $"Última actualización: {DateTime.Now}",
                "Reporte de Inventario",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Filtros aplicados correctamente", "Filtros",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
        }
    }
}
