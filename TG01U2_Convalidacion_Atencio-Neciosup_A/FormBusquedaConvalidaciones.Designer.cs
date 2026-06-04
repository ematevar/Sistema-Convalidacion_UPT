// ============================================================
// ARCHIVO: FormBusquedaConvalidaciones.Designer.cs
// CAMBIOS:
//  1. Se agrega lblCodigoEstudiante y txtCodigoEstudiante
//     en el panel de filtros (gbxFiltros)
//  2. Se agregan btnExportarExcel y btnExportarPdf
// ============================================================

namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    partial class FormBusquedaConvalidaciones
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            gbxFiltros = new GroupBox();
            btnExportarPdf = new Button();
            btnExportarExcel = new Button();
            lblCodigoEstudiante = new Label();
            txtCodigoEstudiante = new TextBox();
            btnLimpiar = new Button();
            btnBuscar = new Button();
            cmbAnio = new ComboBox();
            lblAnio = new Label();
            txtIdConvalidacion = new TextBox();
            lblIdConvalidacion = new Label();
            txtUniversidad = new TextBox();
            lblUniversidad = new Label();
            cmbPais = new ComboBox();
            lblPais = new Label();
            txtNombreEstudiante = new TextBox();
            lblNombre = new Label();
            dgvResultados = new DataGridView();
            lblResultados = new Label();
            gbxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // gbxFiltros
            // 
            gbxFiltros.Controls.Add(btnExportarPdf);
            gbxFiltros.Controls.Add(btnExportarExcel);
            gbxFiltros.Controls.Add(lblCodigoEstudiante);
            gbxFiltros.Controls.Add(txtCodigoEstudiante);
            gbxFiltros.Controls.Add(btnLimpiar);
            gbxFiltros.Controls.Add(btnBuscar);
            gbxFiltros.Controls.Add(cmbAnio);
            gbxFiltros.Controls.Add(lblAnio);
            gbxFiltros.Controls.Add(txtIdConvalidacion);
            gbxFiltros.Controls.Add(lblIdConvalidacion);
            gbxFiltros.Controls.Add(txtUniversidad);
            gbxFiltros.Controls.Add(lblUniversidad);
            gbxFiltros.Controls.Add(cmbPais);
            gbxFiltros.Controls.Add(lblPais);
            gbxFiltros.Controls.Add(txtNombreEstudiante);
            gbxFiltros.Controls.Add(lblNombre);
            gbxFiltros.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gbxFiltros.Location = new Point(11, 13);
            gbxFiltros.Margin = new Padding(3, 4, 3, 4);
            gbxFiltros.Name = "gbxFiltros";
            gbxFiltros.Padding = new Padding(3, 4, 3, 4);
            gbxFiltros.Size = new Size(1040, 260);
            gbxFiltros.TabIndex = 0;
            gbxFiltros.TabStop = false;
            gbxFiltros.Text = "Filtros de Búsqueda";
            // 
            // btnExportarPdf
            // 
            btnExportarPdf.BackColor = Color.Firebrick;
            btnExportarPdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportarPdf.ForeColor = Color.White;
            btnExportarPdf.Location = new Point(185, 200);
            btnExportarPdf.Margin = new Padding(3, 4, 3, 4);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(280, 40);
            btnExportarPdf.TabIndex = 31;
            btnExportarPdf.Text = "Exportar a PDF (lista / ficha)";
            btnExportarPdf.UseVisualStyleBackColor = false;
            btnExportarPdf.Click += BtnExportarPdf_Click;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.BackColor = Color.SeaGreen;
            btnExportarExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.Location = new Point(11, 200);
            btnExportarExcel.Margin = new Padding(3, 4, 3, 4);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(160, 40);
            btnExportarExcel.TabIndex = 30;
            btnExportarExcel.Text = "Exportar a Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += BtnExportarExcel_Click;
            // 
            // lblCodigoEstudiante
            // 
            lblCodigoEstudiante.AutoSize = true;
            lblCodigoEstudiante.Location = new Point(11, 30);
            lblCodigoEstudiante.Name = "lblCodigoEstudiante";
            lblCodigoEstudiante.Size = new Size(140, 20);
            lblCodigoEstudiante.TabIndex = 20;
            lblCodigoEstudiante.Text = "Código Estudiante:";
            // 
            // txtCodigoEstudiante
            // 
            txtCodigoEstudiante.Location = new Point(11, 55);
            txtCodigoEstudiante.Margin = new Padding(3, 4, 3, 4);
            txtCodigoEstudiante.Name = "txtCodigoEstudiante";
            txtCodigoEstudiante.Size = new Size(160, 27);
            txtCodigoEstudiante.TabIndex = 21;
            txtCodigoEstudiante.TextChanged += BtnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.LightGray;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.Black;
            btnLimpiar.Location = new Point(850, 90);
            btnLimpiar.Margin = new Padding(3, 4, 3, 4);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(91, 40);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += BtnLimpiar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.LightBlue;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.Black;
            btnBuscar.Location = new Point(850, 40);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(91, 40);
            btnBuscar.TabIndex = 11;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += BtnBuscar_Click;
            // 
            // cmbAnio
            // 
            cmbAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAnio.FormattingEnabled = true;
            cmbAnio.Items.AddRange(new object[] { "Todos" });
            cmbAnio.Location = new Point(225, 125);
            cmbAnio.Margin = new Padding(3, 4, 3, 4);
            cmbAnio.Name = "cmbAnio";
            cmbAnio.Size = new Size(140, 28);
            cmbAnio.TabIndex = 10;
            cmbAnio.SelectedIndexChanged += BtnBuscar_Click;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(225, 100);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(42, 20);
            lblAnio.TabIndex = 9;
            lblAnio.Text = "Año:";
            // 
            // txtIdConvalidacion
            // 
            txtIdConvalidacion.Location = new Point(615, 55);
            txtIdConvalidacion.Margin = new Padding(3, 4, 3, 4);
            txtIdConvalidacion.Name = "txtIdConvalidacion";
            txtIdConvalidacion.Size = new Size(160, 27);
            txtIdConvalidacion.TabIndex = 8;
            txtIdConvalidacion.TextChanged += BtnBuscar_Click;
            // 
            // lblIdConvalidacion
            // 
            lblIdConvalidacion.AutoSize = true;
            lblIdConvalidacion.Location = new Point(615, 30);
            lblIdConvalidacion.Name = "lblIdConvalidacion";
            lblIdConvalidacion.Size = new Size(130, 20);
            lblIdConvalidacion.TabIndex = 7;
            lblIdConvalidacion.Text = "ID Convalidación:";
            // 
            // txtUniversidad
            // 
            txtUniversidad.Location = new Point(11, 125);
            txtUniversidad.Margin = new Padding(3, 4, 3, 4);
            txtUniversidad.Name = "txtUniversidad";
            txtUniversidad.Size = new Size(200, 27);
            txtUniversidad.TabIndex = 6;
            txtUniversidad.TextChanged += BtnBuscar_Click;
            // 
            // lblUniversidad
            // 
            lblUniversidad.AutoSize = true;
            lblUniversidad.Location = new Point(11, 100);
            lblUniversidad.Name = "lblUniversidad";
            lblUniversidad.Size = new Size(96, 20);
            lblUniversidad.TabIndex = 5;
            lblUniversidad.Text = "Universidad:";
            // 
            // cmbPais
            // 
            cmbPais.FormattingEnabled = true;
            cmbPais.Items.AddRange(new object[] { "", "Perú", "Colombia", "Bolivia", "Argentina", "Chile", "España", "México", "Ecuador", "Brasil", "Francia", "Italia", "Paraguay", "Grecia" });
            cmbPais.Location = new Point(400, 55);
            cmbPais.Margin = new Padding(3, 4, 3, 4);
            cmbPais.Name = "cmbPais";
            cmbPais.Size = new Size(200, 28);
            cmbPais.TabIndex = 4;
            cmbPais.SelectedIndexChanged += BtnBuscar_Click;
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Location = new Point(400, 30);
            lblPais.Name = "lblPais";
            lblPais.Size = new Size(113, 20);
            lblPais.TabIndex = 3;
            lblPais.Text = "País de Origen:";
            // 
            // txtNombreEstudiante
            // 
            txtNombreEstudiante.Location = new Point(185, 55);
            txtNombreEstudiante.Margin = new Padding(3, 4, 3, 4);
            txtNombreEstudiante.Name = "txtNombreEstudiante";
            txtNombreEstudiante.Size = new Size(200, 27);
            txtNombreEstudiante.TabIndex = 2;
            txtNombreEstudiante.TextChanged += BtnBuscar_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(185, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(174, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre del Estudiante:";
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.ColumnHeadersHeight = 29;
            dgvResultados.Location = new Point(11, 320);
            dgvResultados.Margin = new Padding(3, 4, 3, 4);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.Size = new Size(1040, 560);
            dgvResultados.TabIndex = 2;
            // 
            // lblResultados
            // 
            lblResultados.AutoSize = true;
            lblResultados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResultados.Location = new Point(11, 290);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(228, 23);
            lblResultados.TabIndex = 1;
            lblResultados.Text = "Resultados de la Búsqueda:";
            // 
            // FormBusquedaConvalidaciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 910);
            Controls.Add(dgvResultados);
            Controls.Add(lblResultados);
            Controls.Add(gbxFiltros);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormBusquedaConvalidaciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Búsqueda de Convalidaciones";
            gbxFiltros.ResumeLayout(false);
            gbxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox  gbxFiltros;
        // ── NUEVO ─────────────────────────────────────────────────────────────────
        private Label     lblCodigoEstudiante;
        internal TextBox  txtCodigoEstudiante;
        internal Button   btnExportarExcel;
        internal Button   btnExportarPdf;
        // ── Existentes ────────────────────────────────────────────────────────────
        private Label     lblNombre;
        internal TextBox  txtNombreEstudiante;
        private Label     lblPais;
        internal ComboBox cmbPais;
        private Label     lblUniversidad;
        internal TextBox  txtUniversidad;
        private Label     lblIdConvalidacion;
        internal TextBox  txtIdConvalidacion;
        private Label     lblAnio;
        internal ComboBox cmbAnio;
        internal Button   btnBuscar;
        internal Button   btnLimpiar;
        private Label     lblResultados;
        internal DataGridView dgvResultados;
    }
}
