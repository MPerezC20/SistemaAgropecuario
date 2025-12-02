namespace SistemaAgropecuario.Forms
{
    partial class frmInventario
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
            panelBotones = new Panel();
            btnGenerarReporte = new Button();
            btnActualizar = new Button();
            dgvInventario = new DataGridView();
            grpFiltros = new GroupBox();
            cmbCategoria = new ComboBox();
            chkStockBajo = new CheckBox();
            btnFiltrar = new Button();
            label2 = new Label();
            label1 = new Label();
            panelHeader.SuspendLayout();
            panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            grpFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(54, 77, 72); // CAMBIADO a RGB(54, 77, 72)
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(4, 5, 4, 5);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1179, 92);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(16, 28);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(360, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTIÓN DE INVENTARIO";
            // 
            // panelBotones
            // 
            panelBotones.BackColor = Color.WhiteSmoke;
            panelBotones.Controls.Add(btnGenerarReporte);
            panelBotones.Controls.Add(btnActualizar);
            panelBotones.Dock = DockStyle.Top;
            panelBotones.Location = new Point(0, 92);
            panelBotones.Margin = new Padding(4, 5, 4, 5);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(1179, 77);
            panelBotones.TabIndex = 1;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.BackColor = Color.FromArgb(70, 130, 180);
            btnGenerarReporte.FlatAppearance.BorderSize = 0;
            btnGenerarReporte.FlatStyle = FlatStyle.Flat;
            btnGenerarReporte.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerarReporte.ForeColor = Color.White;
            btnGenerarReporte.Location = new Point(147, 15);
            btnGenerarReporte.Margin = new Padding(4, 5, 4, 5);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(200, 46);
            btnGenerarReporte.TabIndex = 1;
            btnGenerarReporte.Text = "GENERAR REPORTE";
            btnGenerarReporte.UseVisualStyleBackColor = false;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(54, 77, 72); // CAMBIADO a RGB(54, 77, 72)
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(0, 15);
            btnActualizar.Margin = new Padding(4, 5, 4, 5);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(133, 46);
            btnActualizar.TabIndex = 0;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // dgvInventario
            // 
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AllowUserToDeleteRows = false;
            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventario.BackgroundColor = Color.White;
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Dock = DockStyle.Fill;
            dgvInventario.Location = new Point(0, 323);
            dgvInventario.Margin = new Padding(4, 5, 4, 5);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.ReadOnly = true;
            dgvInventario.RowHeadersWidth = 51;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.Size = new Size(1179, 540);
            dgvInventario.TabIndex = 2;
            // 
            // grpFiltros
            // 
            grpFiltros.BackColor = Color.White;
            grpFiltros.Controls.Add(cmbCategoria);
            grpFiltros.Controls.Add(chkStockBajo);
            grpFiltros.Controls.Add(btnFiltrar);
            grpFiltros.Controls.Add(label2);
            grpFiltros.Controls.Add(label1);
            grpFiltros.Dock = DockStyle.Top;
            grpFiltros.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpFiltros.Location = new Point(0, 169);
            grpFiltros.Margin = new Padding(4, 5, 4, 5);
            grpFiltros.Name = "grpFiltros";
            grpFiltros.Padding = new Padding(4, 5, 4, 5);
            grpFiltros.Size = new Size(1179, 154);
            grpFiltros.TabIndex = 3;
            grpFiltros.TabStop = false;
            grpFiltros.Text = "Filtros de Búsqueda";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(200, 46);
            cmbCategoria.Margin = new Padding(4, 5, 4, 5);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(265, 25);
            cmbCategoria.TabIndex = 4;
            // 
            // chkStockBajo
            // 
            chkStockBajo.AutoSize = true;
            chkStockBajo.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkStockBajo.Location = new Point(533, 49);
            chkStockBajo.Margin = new Padding(4, 5, 4, 5);
            chkStockBajo.Name = "chkStockBajo";
            chkStockBajo.Size = new Size(180, 21);
            chkStockBajo.TabIndex = 3;
            chkStockBajo.Text = "Mostrar solo stock bajo";
            chkStockBajo.UseVisualStyleBackColor = true;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(108, 117, 125);
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(800, 38);
            btnFiltrar.Margin = new Padding(4, 5, 4, 5);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(133, 46);
            btnFiltrar.TabIndex = 2;
            btnFiltrar.Text = "FILTRAR";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(27, 92);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(500, 17);
            label2.TabIndex = 1;
            label2.Text = "Nota: Los productos con stock en rojo indican niveles por debajo del mínimo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 51);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(141, 17);
            label1.TabIndex = 0;
            label1.Text = "Filtrar por Categoría:";
            // 
            // frmInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1179, 863);
            Controls.Add(dgvInventario);
            Controls.Add(grpFiltros);
            Controls.Add(panelBotones);
            Controls.Add(panelHeader);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmInventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Inventario - AgroCampo S.A.";
            Load += frmInventario_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            grpFiltros.ResumeLayout(false);
            grpFiltros.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.CheckBox chkStockBajo;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}