using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SistemaAgropecuario.Forms;

namespace SistemaAgropecuario
{
    public partial class Form1 : Form
    {
        // Colores basados en RGB(23, 43, 38) - Tema elegante
        private readonly Color COLOR_MENU = Color.FromArgb(23, 43, 38);
        private readonly Color COLOR_ENCABEZADO = Color.FromArgb(30, 50, 45);
        private readonly Color COLOR_BOTON = Color.White;
        private readonly Color COLOR_BOTON_HOVER = Color.FromArgb(245, 248, 247);
        private readonly Color COLOR_TEXTO_BOTON = Color.FromArgb(23, 43, 38);
        private readonly Color COLOR_TEXTO_BOTON_HOVER = Color.FromArgb(40, 70, 65);
        private readonly Color COLOR_FONDO = Color.FromArgb(250, 252, 251);
        private readonly Color COLOR_TEXTO_PRINCIPAL = Color.FromArgb(23, 43, 38);
        private readonly Color COLOR_TEXTO_SECUNDARIO = Color.FromArgb(100, 120, 115);
        private readonly Color COLOR_ACENTO = Color.FromArgb(60, 150, 130);
        private readonly Color COLOR_SOMBRA = Color.FromArgb(220, 230, 227);

        // Clase para botones redondeados personalizados
        public class RoundedButton : Button
        {
            private int _borderRadius = 20;
            private Color _borderColor = Color.FromArgb(220, 230, 225);
            private Color _hoverBorderColor = Color.FromArgb(40, 70, 65);

            public RoundedButton()
            {
                this.FlatStyle = FlatStyle.Flat;
                this.FlatAppearance.BorderSize = 0;
                this.Cursor = Cursors.Hand;
                this.Padding = new Padding(5);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                // Crear un camino redondeado
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                GraphicsPath path = GetRoundedPath(rect, _borderRadius);

                // Establecer la región del botón
                this.Region = new Region(path);

                // Dibujar borde
                using (Pen pen = new Pen(this.FlatAppearance.MouseOverBackColor == Color.Empty ?
                    _borderColor : _hoverBorderColor, 1))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }

            private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
            {
                GraphicsPath path = new GraphicsPath();
                float curveSize = radius * 2F;

                path.StartFigure();
                path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
                path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
                path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
                path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
                path.CloseFigure();

                return path;
            }
        }

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
            this.BackColor = COLOR_FONDO;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CrearInterfazVisual()
        {
            // Panel del menú lateral
            Panel panelMenu = new Panel();
            panelMenu.BackColor = COLOR_MENU;
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Width = 240;

            // Logo/Header del menú con degradado elegante
            Panel panelHeaderMenu = new Panel();
            panelHeaderMenu.BackColor = COLOR_ENCABEZADO;
            panelHeaderMenu.Dock = DockStyle.Top;
            panelHeaderMenu.Height = 120;
            panelHeaderMenu.Paint += (sender, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    panelHeaderMenu.ClientRectangle,
                    Color.FromArgb(28, 48, 43),
                    COLOR_ENCABEZADO,
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, panelHeaderMenu.ClientRectangle);
                }
            };

            // Logo con icono y texto
            Panel panelLogo = new Panel();
            panelLogo.Size = new Size(180, 60);
            panelLogo.Location = new Point(30, 30);
            panelLogo.BackColor = Color.Transparent;

            Label lblIcon = new Label();
            lblIcon.Text = "🌿";
            lblIcon.Font = new Font("Arial", 18, FontStyle.Bold);
            lblIcon.ForeColor = Color.White;
            lblIcon.Location = new Point(0, 10);
            lblIcon.AutoSize = true;

            Label lblTitulo = new Label();
            lblTitulo.Text = "AgroCampo\nS.A.";
            lblTitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(50, 10);
            lblTitulo.AutoSize = true;

            panelLogo.Controls.Add(lblIcon);
            panelLogo.Controls.Add(lblTitulo);
            panelHeaderMenu.Controls.Add(panelLogo);
            panelMenu.Controls.Add(panelHeaderMenu);

            // Botones del menú
            string[] botones = { "📦 PRODUCTOS", "👥 CLIENTES", "🏢 PROVEEDORES", "💰 VENTAS", "📊 INVENTARIO", "❌ SALIR" };
            string[] tooltips = {
                "Gestionar productos agrícolas",
                "Administrar clientes",
                "Gestionar proveedores",
                "Procesar ventas y facturación",
                "Control de inventario y stock",
                "Salir del sistema"
            };

            for (int i = 0; i < botones.Length; i++)
            {
                // Usar el botón personalizado redondeado
                RoundedButton btn = new RoundedButton();
                btn.Text = botones[i];
                btn.Size = new Size(210, 50);
                btn.Location = new Point(15, 140 + (i * 60));
                btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                btn.BackColor = COLOR_BOTON;
                btn.ForeColor = COLOR_TEXTO_BOTON;
                btn.Tag = tooltips[i];
                btn.TextAlign = ContentAlignment.MiddleLeft; // Texto alineado a la izquierda

                // Agregar sombra sutil
                btn.Paint += (sender, e) =>
                {
                    ControlPaint.DrawBorder(e.Graphics, btn.ClientRectangle,
                        COLOR_SOMBRA, 1, ButtonBorderStyle.Solid,
                        COLOR_SOMBRA, 1, ButtonBorderStyle.Solid,
                        COLOR_SOMBRA, 1, ButtonBorderStyle.Solid,
                        COLOR_SOMBRA, 1, ButtonBorderStyle.Solid);
                };

                // Efectos hover
                btn.MouseEnter += (s, e) => {
                    btn.BackColor = COLOR_BOTON_HOVER;
                    btn.ForeColor = COLOR_TEXTO_BOTON_HOVER;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    btn.Invalidate();
                };
                btn.MouseLeave += (s, e) => {
                    btn.BackColor = COLOR_BOTON;
                    btn.ForeColor = COLOR_TEXTO_BOTON;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    btn.Invalidate();
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

            // Panel principal de contenido elegante
            Panel panelContenido = new Panel();
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.BackColor = COLOR_FONDO;
            panelContenido.Padding = new Padding(40);

            // Panel central con efecto de elevación - TAMAÑO ADECUADO
            Panel panelCentral = new Panel();
            panelCentral.Size = new Size(800, 450); // Tamaño óptimo
            panelCentral.BackColor = Color.White;
            panelCentral.BorderStyle = BorderStyle.None;

            // Sombra elegante para el panel central
            panelCentral.Paint += (sender, e) =>
            {
                Rectangle rect = panelCentral.ClientRectangle;
                rect.Inflate(-10, -10);

                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 20;
                    float curveSize = radius * 2F;

                    path.StartFigure();
                    path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
                    path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
                    path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
                    path.CloseFigure();

                    // Relleno con degradado
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        rect,
                        Color.FromArgb(255, 255, 255),
                        Color.FromArgb(250, 252, 251),
                        LinearGradientMode.Vertical))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, path);
                    }

                    // Borde sutil
                    using (Pen pen = new Pen(Color.FromArgb(230, 235, 233), 2))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            // CONTENIDO CON MEJOR ESPACIADO Y JERARQUÍA
            // Título principal - TAMAÑO ADECUADO
            Label lblBienvenida = new Label();
            lblBienvenida.Text = "Bienvenido al Sistema de Gestión";
            lblBienvenida.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblBienvenida.ForeColor = COLOR_TEXTO_PRINCIPAL;
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter;
            lblBienvenida.AutoSize = true;
            // Posición dinámica - superior
            lblBienvenida.Location = new Point(
                (panelCentral.Width - lblBienvenida.Width) / 2,
                60);

            // Nombre de empresa - TAMAÑO ADECUADO
            Label lblEmpresa = new Label();
            lblEmpresa.Text = "AgroCampo S.A.";
            lblEmpresa.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblEmpresa.ForeColor = COLOR_ACENTO;
            lblEmpresa.TextAlign = ContentAlignment.MiddleCenter;
            lblEmpresa.AutoSize = true;
            // Posición dinámica - debajo del título
            lblEmpresa.Location = new Point(
                (panelCentral.Width - lblEmpresa.Width) / 2,
                110);

            // Descripción - TAMAÑO ADECUADO
            Label lblDescripcion = new Label();
            lblDescripcion.Text = "Sistema Integral de Gestión Agropecuaria";
            lblDescripcion.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            lblDescripcion.ForeColor = COLOR_TEXTO_SECUNDARIO;
            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
            lblDescripcion.AutoSize = true;
            // Posición dinámica - debajo del nombre de empresa
            lblDescripcion.Location = new Point(
                (panelCentral.Width - lblDescripcion.Width) / 2,
                170);

            // Línea divisoria decorativa - ESPACIO ADECUADO
            Panel lineaDivisoria = new Panel();
            lineaDivisoria.Size = new Size(350, 2);
            lineaDivisoria.Location = new Point(
                (panelCentral.Width - lineaDivisoria.Width) / 2,
                220); // Más espacio antes de la línea
            lineaDivisoria.BackColor = Color.FromArgb(230, 235, 233);

            // Icono decorativo - POSICIÓN CORRECTA
            Label lblIconoDecorativo = new Label();
            lblIconoDecorativo.Text = "🚜🌱🧑‍🌾";
            lblIconoDecorativo.Font = new Font("Arial", 40, FontStyle.Bold);
            lblIconoDecorativo.ForeColor = Color.FromArgb(54, 77, 72);
            lblIconoDecorativo.TextAlign = ContentAlignment.MiddleCenter;
            lblIconoDecorativo.AutoSize = true;
            // Posición dinámica - después de la línea divisoria
            lblIconoDecorativo.Location = new Point(
                (panelCentral.Width - lblIconoDecorativo.Width) / 2,
                240);

            // Instrucciones - POSICIÓN FINAL
            Label lblInstrucciones = new Label();
            lblInstrucciones.Text = "Seleccione una opción del menú lateral para comenzar";
            lblInstrucciones.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            lblInstrucciones.ForeColor = COLOR_TEXTO_SECUNDARIO;
            lblInstrucciones.TextAlign = ContentAlignment.MiddleCenter;
            lblInstrucciones.AutoSize = true;
            // Posición dinámica - en la parte inferior
            lblInstrucciones.Location = new Point(
                (panelCentral.Width - lblInstrucciones.Width) / 2,
                330);

            // Agregar elementos al panel central EN ORDEN CORRECTO
            panelCentral.Controls.Add(lblBienvenida);
            panelCentral.Controls.Add(lblEmpresa);
            panelCentral.Controls.Add(lblDescripcion);
            panelCentral.Controls.Add(lineaDivisoria);
            panelCentral.Controls.Add(lblIconoDecorativo);
            panelCentral.Controls.Add(lblInstrucciones);

            // Agregar panel central al contenido y centrarlo
            panelContenido.Controls.Add(panelCentral);
            this.Controls.Add(panelContenido);

            // Función para recalcular posiciones
            void RecalcularPosiciones()
            {
                // Recalcular todas las posiciones dinámicamente
                lblBienvenida.Location = new Point(
                    (panelCentral.Width - lblBienvenida.Width) / 2,
                    60);

                lblEmpresa.Location = new Point(
                    (panelCentral.Width - lblEmpresa.Width) / 2,
                    110);

                lblDescripcion.Location = new Point(
                    (panelCentral.Width - lblDescripcion.Width) / 2,
                    170);

                lineaDivisoria.Location = new Point(
                    (panelCentral.Width - lineaDivisoria.Width) / 2,
                    220);

                lblIconoDecorativo.Location = new Point(
                    (panelCentral.Width - lblIconoDecorativo.Width) / 2,
                    240);

                lblInstrucciones.Location = new Point(
                    (panelCentral.Width - lblInstrucciones.Width) / 2,
                    330);
            }

            // Asegurar que el contenido se centre al cambiar tamaño
            this.Resize += (sender, e) =>
            {
                panelCentral.Location = new Point(
                    (panelContenido.Width - panelCentral.Width) / 2,
                    (panelContenido.Height - panelCentral.Height) / 3);

                RecalcularPosiciones();
            };

            // Posicionar inicialmente el panel central
            panelCentral.Location = new Point(
                (panelContenido.Width - panelCentral.Width) / 2,
                (panelContenido.Height - panelCentral.Height) / 3);

            // Recalcular posiciones iniciales
            RecalcularPosiciones();
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