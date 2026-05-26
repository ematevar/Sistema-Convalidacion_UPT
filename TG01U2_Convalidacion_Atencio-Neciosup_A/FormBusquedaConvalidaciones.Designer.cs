namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    partial class FormBusquedaConvalidaciones
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
        /// the contents of this method by the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbxFiltros = new GroupBox();
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
            gbxFiltros.Size = new Size(994, 213);
            gbxFiltros.TabIndex = 0;
            gbxFiltros.TabStop = false;
            gbxFiltros.Text = "Filtros de Búsqueda";
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.LightGray;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.Black;
            btnLimpiar.Location = new Point(821, 120);
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
            btnBuscar.Location = new Point(821, 67);
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
            cmbAnio.Location = new Point(192, 156);
            cmbAnio.Margin = new Padding(3, 4, 3, 4);
            cmbAnio.Name = "cmbAnio";
            cmbAnio.Size = new Size(228, 28);
            cmbAnio.TabIndex = 10;
            cmbAnio.SelectedIndexChanged += BtnBuscar_Click;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(11, 160);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(42, 20);
            lblAnio.TabIndex = 9;
            lblAnio.Text = "Año:";
            // 
            // txtIdConvalidacion
            // 
            txtIdConvalidacion.Location = new Point(581, 103);
            txtIdConvalidacion.Margin = new Padding(3, 4, 3, 4);
            txtIdConvalidacion.Name = "txtIdConvalidacion";
            txtIdConvalidacion.Size = new Size(228, 27);
            txtIdConvalidacion.TabIndex = 8;
            txtIdConvalidacion.TextChanged += BtnBuscar_Click;
            // 
            // lblIdConvalidacion
            // 
            lblIdConvalidacion.AutoSize = true;
            lblIdConvalidacion.Location = new Point(444, 107);
            lblIdConvalidacion.Name = "lblIdConvalidacion";
            lblIdConvalidacion.Size = new Size(130, 20);
            lblIdConvalidacion.TabIndex = 7;
            lblIdConvalidacion.Text = "ID Convalidación:";
            // 
            // txtUniversidad
            // 
            txtUniversidad.Location = new Point(192, 103);
            txtUniversidad.Margin = new Padding(3, 4, 3, 4);
            txtUniversidad.Name = "txtUniversidad";
            txtUniversidad.Size = new Size(228, 27);
            txtUniversidad.TabIndex = 6;
            txtUniversidad.TextChanged += BtnBuscar_Click;
            // 
            // lblUniversidad
            // 
            lblUniversidad.AutoSize = true;
            lblUniversidad.Location = new Point(11, 107);
            lblUniversidad.Name = "lblUniversidad";
            lblUniversidad.Size = new Size(96, 20);
            lblUniversidad.TabIndex = 5;
            lblUniversidad.Text = "Universidad:";
            // 
            // cmbPais
            // 
            cmbPais.FormattingEnabled = true;
            cmbPais.Items.AddRange(new object[] { "", "Perú", "Colombia", "Bolivia", "Argentina", "Chile", "España", "México", "Ecuador", "Brasil", "Francia", "Italia", "Paraguay", "Grecia" });
            cmbPais.Location = new Point(581, 49);
            cmbPais.Margin = new Padding(3, 4, 3, 4);
            cmbPais.Name = "cmbPais";
            cmbPais.Size = new Size(228, 28);
            cmbPais.TabIndex = 4;
            cmbPais.SelectedIndexChanged += BtnBuscar_Click;
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Location = new Point(444, 53);
            lblPais.Name = "lblPais";
            lblPais.Size = new Size(113, 20);
            lblPais.TabIndex = 3;
            lblPais.Text = "País de Origen:";
            // 
            // txtNombreEstudiante
            // 
            txtNombreEstudiante.Location = new Point(192, 49);
            txtNombreEstudiante.Margin = new Padding(3, 4, 3, 4);
            txtNombreEstudiante.Name = "txtNombreEstudiante";
            txtNombreEstudiante.Size = new Size(228, 27);
            txtNombreEstudiante.TabIndex = 2;
            txtNombreEstudiante.TextChanged += BtnBuscar_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(11, 53);
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
            dgvResultados.Location = new Point(11, 280);
            dgvResultados.Margin = new Padding(3, 4, 3, 4);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.Size = new Size(994, 587);
            dgvResultados.TabIndex = 2;
            // 
            // lblResultados
            // 
            lblResultados.AutoSize = true;
            lblResultados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResultados.Location = new Point(11, 240);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(228, 23);
            lblResultados.TabIndex = 1;
            lblResultados.Text = "Resultados de la Búsqueda:";
            // 
            // FormBusquedaConvalidaciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 933);
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

        private System.Windows.Forms.GroupBox gbxFiltros;
        private System.Windows.Forms.Label lblNombre;
        internal System.Windows.Forms.TextBox txtNombreEstudiante;
        private System.Windows.Forms.Label lblPais;
        internal System.Windows.Forms.ComboBox cmbPais;
        private System.Windows.Forms.Label lblUniversidad;
        internal System.Windows.Forms.TextBox txtUniversidad;
        private System.Windows.Forms.Label lblIdConvalidacion;
        internal System.Windows.Forms.TextBox txtIdConvalidacion;
        private System.Windows.Forms.Label lblAnio;
        internal System.Windows.Forms.ComboBox cmbAnio;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblResultados;
        internal System.Windows.Forms.DataGridView dgvResultados;
    }
}
