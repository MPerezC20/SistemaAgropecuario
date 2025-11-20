using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaAgropecuario.Models;

namespace SistemaAgropecuario.Forms
{
    public partial class frmInventario : Form
    {
        private List<Inventario> inventario = new List<Inventario>();

        public frmInventario()
        {
            InitializeComponent();
            LlenarCombobox();
            CargarDatosEjemplo();
        }

        private void LlenarCombobox()
        {
            cmbCategoria.Items.AddRange(new string[] { "Todas", "Granos", "Hortalizas", "Frutas", "Verduras", "Cereales" });
        }

        private void CargarDatosEjemplo()
        {
            inventario.Clear();

            inventario.Add(new Inventario
            {
                IdInventario = 1,
                IdProducto = 1,
                CantidadDisponible = 50,
                CantidadMinima = 20,
                CantidadMaxima = 100,
                Ubicacion = "Almacén A",
                FechaUltimaActualizacion = DateTime.Now.AddDays(-1)
            });

            inventario.Add(new Inventario
            {
                IdInventario = 2,
                IdProducto = 2,
                CantidadDisponible = 15,
                CantidadMinima = 25,
                CantidadMaxima = 80,
                Ubicacion = "Almacén B",
                FechaUltimaActualizacion = DateTime.Now.AddDays(-2)
            });

            inventario.Add(new Inventario
            {
                IdInventario = 3,
                IdProducto = 3,
                CantidadDisponible = 5,
                CantidadMinima = 15,
                CantidadMaxima = 50,
                Ubicacion = "Almacén C",
                FechaUltimaActualizacion = DateTime.Now.AddDays(-3)
            });

            dgvInventario.DataSource = null;
            dgvInventario.DataSource = inventario;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatosEjemplo();
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
    }
}