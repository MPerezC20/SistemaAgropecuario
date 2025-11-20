using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaAgropecuario.Forms;

namespace SistemaAgropecuario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigurarFormularioPrincipal();
            CrearInterfazVisual();
        }

        private void ConfigurarFormularioPrincipal()
        {
            this.Text = "AgroCampo S.A. - Sistema de Gestión Integral";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(240, 245, 240);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CrearInterfazVisual()
        {
            // Panel del menú lateral
            Panel panelMenu = new Panel();
            panelMenu.BackColor = Color.FromArgb(34, 139, 34);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Width = 220;

            // Logo/Header del menú
            Panel panelHeaderMenu = new Panel();
            panelHeaderMenu.BackColor = Color.FromArgb(25, 110, 25);
            panelHeaderMenu.Dock = DockStyle.Top;
            panelHeaderMenu.Height = 100;

            Label lblLogo = new Label();
            lblLogo.Text = "🌱 AgroCampo S.A.";
            lblLogo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Dock = DockStyle.Fill;
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;

            panelHeaderMenu.Controls.Add(lblLogo);
            panelMenu.Controls.Add(panelHeaderMenu);

            // Botones del menú
            string[] botones = { "📦 PRODUCTOS", "👥 CLIENTES", "🏢 PROVEEDORES", "💰 VENTAS", "📊 INVENTARIO", "❌ SALIR" };
            string[] tooltips = {
                "Gestionar productos agrícolas",
                "Administrar clientes",
                "Gestionar proveedores",
                "Procesar ventas",
                "Control de inventario",
                "Salir del sistema"
            };

            for (int i = 0; i < botones.Length; i++)
            {
                Button btn = new Button();
                btn.Text = botones[i];
                btn.Size = new Size(200, 45);
                btn.Location = new Point(10, 120 + (i * 55));
                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(34, 139, 34);
                btn.Font = new Font("Arial", 10, FontStyle.Bold);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.Tag = tooltips[i];

                // Efectos hover
                btn.MouseEnter += (s, e) => {
                    btn.BackColor = Color.FromArgb(240, 255, 240);
                    btn.ForeColor = Color.FromArgb(25, 110, 25);
                };
                btn.MouseLeave += (s, e) => {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.FromArgb(34, 139, 34);
                };

                // CORRECCIÓN: Usar el texto actual del botón en lugar del array
                btn.Click += (sender, e) => {
                    string textoBoton = btn.Text;
                    string opcionLimpia = textoBoton
                        .Replace("📦 ", "")
                        .Replace("👥 ", "")
                        .Replace("🏢 ", "")
                        .Replace("💰 ", "")
                        .Replace("📊 ", "")
                        .Replace("❌ ", "");
                    ManejarClickBoton(opcionLimpia);
                };

                panelMenu.Controls.Add(btn);
            }

            this.Controls.Add(panelMenu);

            // Panel principal de contenido
            Panel panelContenido = new Panel();
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.BackColor = Color.White;
            panelContenido.BackgroundImageLayout = ImageLayout.Center;

            // Bienvenida
            Label lblBienvenida = new Label();
            lblBienvenida.Text = "¡Bienvenido al Sistema de Gestión AgroCampo S.A.!";
            lblBienvenida.Font = new Font("Arial", 20, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(34, 139, 34);
            lblBienvenida.Location = new Point(250, 100);
            lblBienvenida.AutoSize = true;

            Label lblInstrucciones = new Label();
            lblInstrucciones.Text = "Seleccione una opción del menú lateral para comenzar";
            lblInstrucciones.Font = new Font("Arial", 12, FontStyle.Regular);
            lblInstrucciones.ForeColor = Color.Gray;
            lblInstrucciones.Location = new Point(250, 150);
            lblInstrucciones.AutoSize = true;

            panelContenido.Controls.Add(lblBienvenida);
            panelContenido.Controls.Add(lblInstrucciones);

            this.Controls.Add(panelContenido);
        }

        private void ManejarClickBoton(string opcion)
        {
            Form formulario = null;

            switch (opcion)
            {
                case "PRODUCTOS":
                    formulario = new frmProductos();
                    break;
                case "CLIENTES":
                    formulario = new frmClientes();
                    break;
                case "PROVEEDORES":
                    formulario = new frmProveedores();
                    break;
                case "VENTAS":
                    formulario = new frmVentas();
                    break;
                case "INVENTARIO":
                    formulario = new frmInventario();
                    break;
                case "SALIR":
                    if (MessageBox.Show("¿Está seguro que desea salir del sistema?",
                        "Confirmar Salida",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    break;
            }

            if (formulario != null)
            {
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.ShowDialog();
            }
        }
    }
}