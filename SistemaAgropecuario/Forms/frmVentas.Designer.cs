namespace SistemaAgropecuario.Forms
{
    partial class frmVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitulo = new Label();
            panelPrincipal = new Panel();
            panelContenido = new Panel();
            splitContainer = new SplitContainer();
            panelIzquierdo = new Panel();
            grpProductos = new GroupBox();
            panelAgregarProducto = new Panel();
            btnAgregarProducto = new Button();
            panelCantidad = new Panel();
            label3 = new Label();
            nudCantidad = new NumericUpDown();
            panelProducto = new Panel();
            label2 = new Label();
            cmbProductos = new ComboBox();
            grpCliente = new GroupBox();
            panelClienteSeleccionado = new Panel();
            txtClienteSeleccionado = new TextBox();
            label1 = new Label();
            panelBuscarCliente = new Panel();
            txtFiltroCliente = new TextBox();
            btnBuscarCliente = new Button();
            panelDerecho = new Panel();
            panelCarritoContainer = new Panel();
            grpCarrito = new GroupBox();
            dgvCarrito = new DataGridView();
            grpTotal = new GroupBox();
            panelTotal = new Panel();
            lblTotal = new Label();
            label4 = new Label();
            panelBotones = new Panel();
            btnProcesarVenta = new Button();
            btnCancelarVenta = new Button();
            panelHeader.SuspendLayout();
            panelPrincipal.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panelIzquierdo.SuspendLayout();
            grpProductos.SuspendLayout();
            panelAgregarProducto.SuspendLayout();
            panelCantidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            panelProducto.SuspendLayout();
            grpCliente.SuspendLayout();
            panelClienteSeleccionado.SuspendLayout();
            panelBuscarCliente.SuspendLayout();
            panelDerecho.SuspendLayout();
            panelCarritoContainer.SuspendLayout();
            grpCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            grpTotal.SuspendLayout();
            panelTotal.SuspendLayout();
            panelBotones.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(54, 77, 72);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(4, 5, 4, 5);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1333, 92);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 28);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(304, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "PROCESO DE VENTAS";
            // 
            // panelPrincipal
            // 
            panelPrincipal.Controls.Add(panelContenido);
            panelPrincipal.Controls.Add(panelBotones);
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.Location = new Point(0, 92);
            panelPrincipal.Margin = new Padding(4, 5, 4, 5);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Padding = new Padding(15, 15, 15, 0);
            panelPrincipal.Size = new Size(1333, 925);
            panelPrincipal.TabIndex = 1;
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(splitContainer);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(15, 15);
            panelContenido.Margin = new Padding(4, 5, 4, 5);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(1303, 713);
            panelContenido.TabIndex = 6;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Margin = new Padding(4, 5, 4, 5);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(panelIzquierdo);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panelDerecho);
            splitContainer.Panel2.Controls.Add(grpTotal);
            splitContainer.Size = new Size(1303, 713);
            splitContainer.SplitterDistance = 650;
            splitContainer.SplitterWidth = 5;
            splitContainer.TabIndex = 4;
            // 
            // panelIzquierdo
            // 
            panelIzquierdo.Controls.Add(grpProductos);
            panelIzquierdo.Controls.Add(grpCliente);
            panelIzquierdo.Dock = DockStyle.Fill;
            panelIzquierdo.Location = new Point(0, 0);
            panelIzquierdo.Margin = new Padding(4, 5, 4, 5);
            panelIzquierdo.Name = "panelIzquierdo";
            panelIzquierdo.Padding = new Padding(0, 0, 8, 0);
            panelIzquierdo.Size = new Size(650, 713);
            panelIzquierdo.TabIndex = 0;
            // 
            // grpProductos
            // 
            grpProductos.Controls.Add(panelAgregarProducto);
            grpProductos.Controls.Add(panelCantidad);
            grpProductos.Controls.Add(panelProducto);
            grpProductos.Dock = DockStyle.Fill;
            grpProductos.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpProductos.ForeColor = Color.FromArgb(64, 64, 64);
            grpProductos.Location = new Point(0, 200);
            grpProductos.Margin = new Padding(4, 5, 4, 5);
            grpProductos.Name = "grpProductos";
            grpProductos.Padding = new Padding(4, 5, 4, 5);
            grpProductos.Size = new Size(642, 513);
            grpProductos.TabIndex = 1;
            grpProductos.TabStop = false;
            grpProductos.Text = "Agregar Productos al Carrito";
            // 
            // panelAgregarProducto
            // 
            panelAgregarProducto.Controls.Add(btnAgregarProducto);
            panelAgregarProducto.Dock = DockStyle.Top;
            panelAgregarProducto.Location = new Point(4, 233);
            panelAgregarProducto.Margin = new Padding(4, 5, 4, 5);
            panelAgregarProducto.Name = "panelAgregarProducto";
            panelAgregarProducto.Padding = new Padding(8, 15, 8, 8);
            panelAgregarProducto.Size = new Size(634, 66);
            panelAgregarProducto.TabIndex = 2;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.BackColor = Color.FromArgb(54, 77, 72);
            btnAgregarProducto.Dock = DockStyle.Fill;
            btnAgregarProducto.FlatAppearance.BorderSize = 0;
            btnAgregarProducto.FlatStyle = FlatStyle.Flat;
            btnAgregarProducto.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarProducto.ForeColor = Color.White;
            btnAgregarProducto.Location = new Point(8, 15);
            btnAgregarProducto.Margin = new Padding(4, 5, 4, 5);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(618, 43);
            btnAgregarProducto.TabIndex = 4;
            btnAgregarProducto.Text = "AGREGAR AL CARRITO";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // panelCantidad
            // 
            panelCantidad.Controls.Add(label3);
            panelCantidad.Controls.Add(nudCantidad);
            panelCantidad.Dock = DockStyle.Top;
            panelCantidad.Location = new Point(4, 133);
            panelCantidad.Margin = new Padding(4, 5, 4, 5);
            panelCantidad.Name = "panelCantidad";
            panelCantidad.Padding = new Padding(8, 8, 8, 15);
            panelCantidad.Size = new Size(634, 100);
            panelCantidad.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(8, 8);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 8, 0, 0);
            label3.Size = new Size(74, 31);
            label3.TabIndex = 4;
            label3.Text = "Cantidad:";
            // 
            // nudCantidad
            // 
            nudCantidad.Dock = DockStyle.Bottom;
            nudCantidad.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudCantidad.Location = new Point(8, 56);
            nudCantidad.Margin = new Padding(4, 5, 4, 5);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(618, 30);
            nudCantidad.TabIndex = 3;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // panelProducto
            // 
            panelProducto.Controls.Add(label2);
            panelProducto.Controls.Add(cmbProductos);
            panelProducto.Dock = DockStyle.Top;
            panelProducto.Location = new Point(4, 33);
            panelProducto.Margin = new Padding(4, 5, 4, 5);
            panelProducto.Name = "panelProducto";
            panelProducto.Padding = new Padding(8, 8, 8, 15);
            panelProducto.Size = new Size(634, 100);
            panelProducto.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(8, 8);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 8, 0, 0);
            label2.Size = new Size(151, 31);
            label2.TabIndex = 3;
            label2.Text = "Seleccionar Producto:";
            // 
            // cmbProductos
            // 
            cmbProductos.Dock = DockStyle.Bottom;
            cmbProductos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductos.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(8, 55);
            cmbProductos.Margin = new Padding(4, 5, 4, 5);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(618, 30);
            cmbProductos.TabIndex = 2;
            // 
            // grpCliente
            // 
            grpCliente.Controls.Add(panelClienteSeleccionado);
            grpCliente.Controls.Add(panelBuscarCliente);
            grpCliente.Dock = DockStyle.Top;
            grpCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpCliente.ForeColor = Color.FromArgb(64, 64, 64);
            grpCliente.Location = new Point(0, 0);
            grpCliente.Margin = new Padding(4, 5, 4, 5);
            grpCliente.Name = "grpCliente";
            grpCliente.Padding = new Padding(4, 5, 4, 5);
            grpCliente.Size = new Size(642, 200);
            grpCliente.TabIndex = 0;
            grpCliente.TabStop = false;
            grpCliente.Text = "Datos del Cliente";
            // 
            // panelClienteSeleccionado
            // 
            panelClienteSeleccionado.Controls.Add(txtClienteSeleccionado);
            panelClienteSeleccionado.Controls.Add(label1);
            panelClienteSeleccionado.Dock = DockStyle.Top;
            panelClienteSeleccionado.Location = new Point(4, 33);
            panelClienteSeleccionado.Margin = new Padding(4, 5, 4, 5);
            panelClienteSeleccionado.Name = "panelClienteSeleccionado";
            panelClienteSeleccionado.Padding = new Padding(8, 8, 8, 8);
            panelClienteSeleccionado.Size = new Size(634, 100);
            panelClienteSeleccionado.TabIndex = 4;
            // 
            // txtClienteSeleccionado
            // 
            txtClienteSeleccionado.BackColor = Color.WhiteSmoke;
            txtClienteSeleccionado.BorderStyle = BorderStyle.FixedSingle;
            txtClienteSeleccionado.Dock = DockStyle.Bottom;
            txtClienteSeleccionado.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtClienteSeleccionado.Location = new Point(8, 62);
            txtClienteSeleccionado.Margin = new Padding(4, 5, 4, 5);
            txtClienteSeleccionado.Name = "txtClienteSeleccionado";
            txtClienteSeleccionado.ReadOnly = true;
            txtClienteSeleccionado.Size = new Size(618, 30);
            txtClienteSeleccionado.TabIndex = 3;
            txtClienteSeleccionado.Text = "Seleccione un cliente...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(8, 8);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 8, 0, 0);
            label1.Size = new Size(152, 31);
            label1.TabIndex = 2;
            label1.Text = "Cliente Seleccionado:";
            // 
            // panelBuscarCliente
            // 
            panelBuscarCliente.Controls.Add(txtFiltroCliente);
            panelBuscarCliente.Controls.Add(btnBuscarCliente);
            panelBuscarCliente.Dock = DockStyle.Bottom;
            panelBuscarCliente.Location = new Point(4, 133);
            panelBuscarCliente.Margin = new Padding(4, 5, 4, 5);
            panelBuscarCliente.Name = "panelBuscarCliente";
            panelBuscarCliente.Padding = new Padding(8, 0, 8, 8);
            panelBuscarCliente.Size = new Size(634, 62);
            panelBuscarCliente.TabIndex = 3;
            // 
            // txtFiltroCliente
            // 
            txtFiltroCliente.BorderStyle = BorderStyle.FixedSingle;
            txtFiltroCliente.Dock = DockStyle.Fill;
            txtFiltroCliente.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFiltroCliente.Location = new Point(8, 0);
            txtFiltroCliente.Margin = new Padding(4, 5, 4, 5);
            txtFiltroCliente.Name = "txtFiltroCliente";
            txtFiltroCliente.PlaceholderText = "Ingrese ID o nombre del cliente...";
            txtFiltroCliente.Size = new Size(520, 29);
            txtFiltroCliente.TabIndex = 2;
            txtFiltroCliente.KeyPress += txtFiltroCliente_KeyPress;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.BackColor = Color.FromArgb(70, 130, 180);
            btnBuscarCliente.Dock = DockStyle.Right;
            btnBuscarCliente.FlatAppearance.BorderSize = 0;
            btnBuscarCliente.FlatStyle = FlatStyle.Flat;
            btnBuscarCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscarCliente.ForeColor = Color.White;
            btnBuscarCliente.Location = new Point(528, 0);
            btnBuscarCliente.Margin = new Padding(4, 5, 4, 5);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(98, 54);
            btnBuscarCliente.TabIndex = 1;
            btnBuscarCliente.Text = "BUSCAR";
            btnBuscarCliente.UseVisualStyleBackColor = false;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // panelDerecho
            // 
            panelDerecho.Controls.Add(panelCarritoContainer);
            panelDerecho.Dock = DockStyle.Fill;
            panelDerecho.Location = new Point(0, 0);
            panelDerecho.Margin = new Padding(4, 5, 4, 5);
            panelDerecho.Name = "panelDerecho";
            panelDerecho.Size = new Size(648, 440);
            panelDerecho.TabIndex = 2;
            // 
            // panelCarritoContainer
            // 
            panelCarritoContainer.Controls.Add(grpCarrito);
            panelCarritoContainer.Dock = DockStyle.Fill;
            panelCarritoContainer.Location = new Point(0, 0);
            panelCarritoContainer.Margin = new Padding(4, 5, 4, 5);
            panelCarritoContainer.Name = "panelCarritoContainer";
            panelCarritoContainer.Padding = new Padding(8, 0, 0, 0);
            panelCarritoContainer.Size = new Size(648, 440);
            panelCarritoContainer.TabIndex = 2;
            // 
            // grpCarrito
            // 
            grpCarrito.Controls.Add(dgvCarrito);
            grpCarrito.Dock = DockStyle.Fill;
            grpCarrito.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpCarrito.ForeColor = Color.FromArgb(64, 64, 64);
            grpCarrito.Location = new Point(8, 0);
            grpCarrito.Margin = new Padding(4, 5, 4, 5);
            grpCarrito.Name = "grpCarrito";
            grpCarrito.Padding = new Padding(4, 5, 4, 5);
            grpCarrito.Size = new Size(640, 440);
            grpCarrito.TabIndex = 0;
            grpCarrito.TabStop = false;
            grpCarrito.Text = "Carrito de Compra";
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AllowUserToDeleteRows = false;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.BackgroundColor = Color.White;
            dgvCarrito.BorderStyle = BorderStyle.None;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Dock = DockStyle.Fill;
            dgvCarrito.GridColor = Color.Gainsboro;
            dgvCarrito.Location = new Point(4, 33);
            dgvCarrito.Margin = new Padding(4, 5, 4, 5);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.Size = new Size(632, 402);
            dgvCarrito.TabIndex = 0;
            // 
            // grpTotal
            // 
            grpTotal.BackColor = Color.FromArgb(245, 245, 245);
            grpTotal.Controls.Add(panelTotal);
            grpTotal.Dock = DockStyle.Bottom;
            grpTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpTotal.ForeColor = Color.FromArgb(64, 64, 64);
            grpTotal.Location = new Point(0, 440);
            grpTotal.Margin = new Padding(4, 5, 4, 5);
            grpTotal.Name = "grpTotal";
            grpTotal.Padding = new Padding(4, 5, 4, 5);
            grpTotal.Size = new Size(648, 273);
            grpTotal.TabIndex = 2;
            grpTotal.TabStop = false;
            grpTotal.Text = "Total de la Venta";
            // 
            // panelTotal
            // 
            panelTotal.Controls.Add(lblTotal);
            panelTotal.Controls.Add(label4);
            panelTotal.Dock = DockStyle.Fill;
            panelTotal.Location = new Point(4, 33);
            panelTotal.Margin = new Padding(4, 5, 4, 5);
            panelTotal.Name = "panelTotal";
            panelTotal.Padding = new Padding(20, 40, 20, 20);
            panelTotal.Size = new Size(640, 235);
            panelTotal.TabIndex = 2;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Dock = DockStyle.Right;
            lblTotal.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(54, 77, 72);
            lblTotal.Location = new Point(425, 40);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(195, 54);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "$ 0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 40);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(101, 32);
            label4.TabIndex = 1;
            label4.Text = "TOTAL:";
            // 
            // panelBotones
            // 
            panelBotones.Controls.Add(btnProcesarVenta);
            panelBotones.Controls.Add(btnCancelarVenta);
            panelBotones.Dock = DockStyle.Bottom;
            panelBotones.Location = new Point(15, 728);
            panelBotones.Margin = new Padding(4, 5, 4, 5);
            panelBotones.Name = "panelBotones";
            panelBotones.Padding = new Padding(0, 15, 0, 0);
            panelBotones.Size = new Size(1303, 137);
            panelBotones.TabIndex = 5;
            // 
            // btnProcesarVenta
            // 
            btnProcesarVenta.BackColor = Color.FromArgb(54, 77, 72);
            btnProcesarVenta.Dock = DockStyle.Left;
            btnProcesarVenta.FlatAppearance.BorderSize = 0;
            btnProcesarVenta.FlatStyle = FlatStyle.Flat;
            btnProcesarVenta.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProcesarVenta.ForeColor = Color.White;
            btnProcesarVenta.Location = new Point(0, 15);
            btnProcesarVenta.Margin = new Padding(4, 5, 4, 5);
            btnProcesarVenta.Name = "btnProcesarVenta";
            btnProcesarVenta.Size = new Size(650, 122);
            btnProcesarVenta.TabIndex = 0;
            btnProcesarVenta.Text = "PROCESAR VENTA";
            btnProcesarVenta.UseVisualStyleBackColor = false;
            btnProcesarVenta.Click += btnProcesarVenta_Click;
            // 
            // btnCancelarVenta
            // 
            btnCancelarVenta.BackColor = Color.FromArgb(108, 117, 125);
            btnCancelarVenta.Dock = DockStyle.Right;
            btnCancelarVenta.FlatAppearance.BorderSize = 0;
            btnCancelarVenta.FlatStyle = FlatStyle.Flat;
            btnCancelarVenta.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarVenta.ForeColor = Color.White;
            btnCancelarVenta.Location = new Point(653, 15);
            btnCancelarVenta.Margin = new Padding(4, 5, 4, 5);
            btnCancelarVenta.Name = "btnCancelarVenta";
            btnCancelarVenta.Size = new Size(650, 122);
            btnCancelarVenta.TabIndex = 1;
            btnCancelarVenta.Text = "CANCELAR VENTA";
            btnCancelarVenta.UseVisualStyleBackColor = false;
            btnCancelarVenta.Click += btnCancelarVenta_Click;
            // 
            // frmVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1333, 1017);
            Controls.Add(panelPrincipal);
            Controls.Add(panelHeader);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proceso de Ventas - AgroCampo S.A.";
            Load += frmVentas_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelPrincipal.ResumeLayout(false);
            panelContenido.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panelIzquierdo.ResumeLayout(false);
            grpProductos.ResumeLayout(false);
            panelAgregarProducto.ResumeLayout(false);
            panelCantidad.ResumeLayout(false);
            panelCantidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            panelProducto.ResumeLayout(false);
            panelProducto.PerformLayout();
            grpCliente.ResumeLayout(false);
            panelClienteSeleccionado.ResumeLayout(false);
            panelClienteSeleccionado.PerformLayout();
            panelBuscarCliente.ResumeLayout(false);
            panelBuscarCliente.PerformLayout();
            panelDerecho.ResumeLayout(false);
            panelCarritoContainer.ResumeLayout(false);
            grpCarrito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            grpTotal.ResumeLayout(false);
            panelTotal.ResumeLayout(false);
            panelTotal.PerformLayout();
            panelBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.TextBox txtClienteSeleccionado;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpProductos;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpCarrito;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.GroupBox grpTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnProcesarVenta;
        private System.Windows.Forms.Button btnCancelarVenta;
        private Panel panelBotones;
        private Panel panelIzquierdo;
        private Panel panelDerecho;
        private Panel panelClienteSeleccionado;
        private Panel panelBuscarCliente;
        private Panel panelAgregarProducto;
        private Panel panelCantidad;
        private Panel panelProducto;
        private Panel panelTotal;
        private Panel panelContenido;
        private Panel panelCarritoContainer;
        private TextBox txtFiltroCliente;
    }
}