namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    partial class SistemaConvalidacion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            gbDatosEstudiante = new GroupBox();
            lblSemestre = new Label();
            txtSemestre = new TextBox();
            lblAnio = new Label();
            txtAnio = new TextBox();
            lblPais = new Label();
            cmbPais = new ComboBox();
            lblUniversidad = new Label();
            txtUniversidad = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            gbRegistroCursos = new GroupBox();
            lblCursoUPT = new Label();
            cmbCursosUPT = new ComboBox();
            lblNotaExtranjera = new Label();
            txtNotaExtranjera = new TextBox();
            btnAgregarCurso = new Button();
            dgvCursos = new DataGridView();
            lblTotalCreditos = new Label();
            btnGuardarConvalidacion = new Button();
            txtTotal = new TextBox();
            btnEliminarCurso = new Button();
            btnLimpiarFormulario = new Button();
            gbRegistroCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).BeginInit();
            gbDatosEstudiante.SuspendLayout();
            SuspendLayout();
            // 
            // gbDatosEstudiante
            // 
            gbDatosEstudiante.Controls.Add(lblSemestre);
            gbDatosEstudiante.Controls.Add(txtSemestre);
            gbDatosEstudiante.Controls.Add(lblAnio);
            gbDatosEstudiante.Controls.Add(txtAnio);
            gbDatosEstudiante.Controls.Add(lblPais);
            gbDatosEstudiante.Controls.Add(cmbPais);
            gbDatosEstudiante.Controls.Add(lblUniversidad);
            gbDatosEstudiante.Controls.Add(txtUniversidad);
            gbDatosEstudiante.Controls.Add(lblNombre);
            gbDatosEstudiante.Controls.Add(txtNombre);
            gbDatosEstudiante.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbDatosEstudiante.Location = new Point(25, 25);
            gbDatosEstudiante.Margin = new Padding(3, 4, 3, 4);
            gbDatosEstudiante.Name = "gbDatosEstudiante";
            gbDatosEstudiante.Padding = new Padding(3, 4, 3, 4);
            gbDatosEstudiante.Size = new Size(830, 188);
            gbDatosEstudiante.TabIndex = 0;
            gbDatosEstudiante.TabStop = false;
            gbDatosEstudiante.Text = "Información del Estudiante y Movilidad Internacional";
            // 
            // lblSemestre
            // 
            lblSemestre.AutoSize = true;
            lblSemestre.Location = new Point(160, 112);
            lblSemestre.Name = "lblSemestre";
            lblSemestre.Size = new Size(73, 20);
            lblSemestre.TabIndex = 0;
            lblSemestre.Text = "Semestre:";
            // 
            // txtSemestre
            // 
            txtSemestre.Location = new Point(160, 141);
            txtSemestre.Margin = new Padding(3, 4, 3, 4);
            txtSemestre.Name = "txtSemestre";
            txtSemestre.Size = new Size(140, 27);
            txtSemestre.TabIndex = 5;
            txtSemestre.TextChanged += txtSemestre_TextChanged;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(20, 112);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(118, 20);
            lblAnio.TabIndex = 6;
            lblAnio.Text = "Año Académico:";
            // 
            // txtAnio
            // 
            txtAnio.Location = new Point(20, 141);
            txtAnio.Margin = new Padding(3, 4, 3, 4);
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new Size(120, 27);
            txtAnio.TabIndex = 4;
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Location = new Point(560, 38);
            lblPais.Name = "lblPais";
            lblPais.Size = new Size(107, 20);
            lblPais.TabIndex = 7;
            lblPais.Text = "País de Origen:";
            // 
            // cmbPais
            // 
            cmbPais.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPais.FormattingEnabled = true;
            cmbPais.Items.AddRange(new object[] { "Perú", "Argentina", "Bolivia", "Brasil", "Chile", "Colombia", "Ecuador", "Paraguay", "México", "España", "Francia", "Grecia", "Italia" });
            cmbPais.Location = new Point(560, 66);
            cmbPais.Margin = new Padding(3, 4, 3, 4);
            cmbPais.Name = "cmbPais";
            cmbPais.Size = new Size(240, 28);
            cmbPais.TabIndex = 3;
            // 
            // lblUniversidad
            // 
            lblUniversidad.AutoSize = true;
            lblUniversidad.Location = new Point(290, 38);
            lblUniversidad.Name = "lblUniversidad";
            lblUniversidad.Size = new Size(160, 20);
            lblUniversidad.TabIndex = 8;
            lblUniversidad.Text = "Universidad de Origen:";
            // 
            // txtUniversidad
            // 
            txtUniversidad.Location = new Point(290, 66);
            txtUniversidad.Margin = new Padding(3, 4, 3, 4);
            txtUniversidad.Name = "txtUniversidad";
            txtUniversidad.Size = new Size(250, 27);
            txtUniversidad.TabIndex = 2;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 38);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(165, 20);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Nombre del Estudiante:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(20, 66);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 27);
            txtNombre.TabIndex = 1;
            // 
            // gbRegistroCursos
            // 
            gbRegistroCursos.Controls.Add(lblCursoUPT);
            gbRegistroCursos.Controls.Add(cmbCursosUPT);
            gbRegistroCursos.Controls.Add(lblNotaExtranjera);
            gbRegistroCursos.Controls.Add(txtNotaExtranjera);
            gbRegistroCursos.Controls.Add(btnAgregarCurso);
            gbRegistroCursos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbRegistroCursos.Location = new Point(25, 231);
            gbRegistroCursos.Margin = new Padding(3, 4, 3, 4);
            gbRegistroCursos.Name = "gbRegistroCursos";
            gbRegistroCursos.Padding = new Padding(3, 4, 3, 4);
            gbRegistroCursos.Size = new Size(830, 125);
            gbRegistroCursos.TabIndex = 6;
            gbRegistroCursos.TabStop = false;
            gbRegistroCursos.Text = "Asignaturas y Equivalencias de Calificación";
            // 
            // lblCursoUPT
            // 
            lblCursoUPT.AutoSize = true;
            lblCursoUPT.Location = new Point(20, 38);
            lblCursoUPT.Name = "lblCursoUPT";
            lblCursoUPT.Size = new Size(160, 20);
            lblCursoUPT.TabIndex = 0;
            lblCursoUPT.Text = "Curso Equivalente UPT:";
            // 
            // cmbCursosUPT
            // 
            cmbCursosUPT.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCursosUPT.FormattingEnabled = true;
            cmbCursosUPT.Location = new Point(20, 66);
            cmbCursosUPT.Margin = new Padding(3, 4, 3, 4);
            cmbCursosUPT.Name = "cmbCursosUPT";
            cmbCursosUPT.Size = new Size(350, 28);
            cmbCursosUPT.TabIndex = 7;
            // 
            // lblNotaExtranjera
            // 
            lblNotaExtranjera.AutoSize = true;
            lblNotaExtranjera.Location = new Point(390, 38);
            lblNotaExtranjera.Name = "lblNotaExtranjera";
            lblNotaExtranjera.Size = new Size(181, 20);
            lblNotaExtranjera.TabIndex = 8;
            lblNotaExtranjera.Text = "Nota Obtenida Extranjera:";
            // 
            // txtNotaExtranjera
            // 
            txtNotaExtranjera.Location = new Point(390, 66);
            txtNotaExtranjera.Margin = new Padding(3, 4, 3, 4);
            txtNotaExtranjera.Name = "txtNotaExtranjera";
            txtNotaExtranjera.Size = new Size(180, 27);
            txtNotaExtranjera.TabIndex = 8;
            // 
            // btnAgregarCurso
            // 
            btnAgregarCurso.BackColor = Color.LimeGreen;
            btnAgregarCurso.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarCurso.ForeColor = Color.White;
            btnAgregarCurso.Location = new Point(590, 60);
            btnAgregarCurso.Margin = new Padding(3, 4, 3, 4);
            btnAgregarCurso.Name = "btnAgregarCurso";
            btnAgregarCurso.Size = new Size(210, 44);
            btnAgregarCurso.TabIndex = 9;
            btnAgregarCurso.Text = "+ Agregar Asignatura";
            btnAgregarCurso.UseVisualStyleBackColor = false;
            // 
            // dgvCursos
            // 
            dgvCursos.AllowUserToAddRows = false;
            dgvCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCursos.Location = new Point(25, 381);
            dgvCursos.Margin = new Padding(3, 4, 3, 4);
            dgvCursos.Name = "dgvCursos";
            dgvCursos.RowHeadersWidth = 51;
            dgvCursos.RowTemplate.Height = 24;
            dgvCursos.Size = new Size(830, 312);
            dgvCursos.TabIndex = 10;
            dgvCursos.CellEndEdit += dgvCursos_CellEndEdit;
            // 
            // lblTotalCreditos
            // 
            lblTotalCreditos.AutoSize = true;
            lblTotalCreditos.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalCreditos.Location = new Point(25, 712);
            lblTotalCreditos.Name = "lblTotalCreditos";
            lblTotalCreditos.Size = new Size(258, 25);
            lblTotalCreditos.TabIndex = 11;
            lblTotalCreditos.Text = "Total Créditos Convalidados: ";
            // 
            // btnGuardarConvalidacion
            // 
            btnGuardarConvalidacion.BackColor = Color.RoyalBlue;
            btnGuardarConvalidacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarConvalidacion.ForeColor = Color.White;
            btnGuardarConvalidacion.Location = new Point(240, 762);
            btnGuardarConvalidacion.Margin = new Padding(3, 4, 3, 4);
            btnGuardarConvalidacion.Name = "btnGuardarConvalidacion";
            btnGuardarConvalidacion.Size = new Size(200, 56);
            btnGuardarConvalidacion.TabIndex = 12;
            btnGuardarConvalidacion.Text = "✓ Guardar Registro";
            btnGuardarConvalidacion.UseVisualStyleBackColor = false;
            // 
            // txtTotal
            //
            txtTotal.Location = new Point(289, 713);
            txtTotal.Margin = new Padding(3, 4, 3, 4);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(140, 27);
            txtTotal.TabIndex = 10;
            txtTotal.BackColor = Color.WhiteSmoke;
            // 
            // btnEliminarCurso
            // 
            btnEliminarCurso.BackColor = Color.Red;
            btnEliminarCurso.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminarCurso.ForeColor = Color.White;
            btnEliminarCurso.Location = new Point(470, 762);
            btnEliminarCurso.Margin = new Padding(3, 4, 3, 4);
            btnEliminarCurso.Name = "btnEliminarCurso";
            btnEliminarCurso.Size = new Size(200, 56);
            btnEliminarCurso.TabIndex = 13;
            btnEliminarCurso.Text = "✕ Eliminar Seleccionado";
            btnEliminarCurso.UseVisualStyleBackColor = false;
            // 
            // btnLimpiarFormulario
            // 
            btnLimpiarFormulario.BackColor = Color.Orange;
            btnLimpiarFormulario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiarFormulario.ForeColor = Color.White;
            btnLimpiarFormulario.Location = new Point(690, 762);
            btnLimpiarFormulario.Margin = new Padding(3, 4, 3, 4);
            btnLimpiarFormulario.Name = "btnLimpiarFormulario";
            btnLimpiarFormulario.Size = new Size(165, 56);
            btnLimpiarFormulario.TabIndex = 14;
            btnLimpiarFormulario.Text = "Nuevo Registro";
            btnLimpiarFormulario.UseVisualStyleBackColor = false;
            // 
            // SistemaConvalidacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 854);
            Controls.Add(btnLimpiarFormulario);
            Controls.Add(btnEliminarCurso);
            Controls.Add(txtTotal);
            Controls.Add(btnGuardarConvalidacion);
            Controls.Add(lblTotalCreditos);
            Controls.Add(dgvCursos);
            Controls.Add(gbRegistroCursos);
            Controls.Add(gbDatosEstudiante);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "SistemaConvalidacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Reconocimiento de Movilidad Internacional - UPT";
            gbRegistroCursos.ResumeLayout(false);
            gbRegistroCursos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).EndInit();
            gbDatosEstudiante.ResumeLayout(false);
            gbDatosEstudiante.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosEstudiante;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblUniversidad;
        private System.Windows.Forms.TextBox txtUniversidad;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.ComboBox cmbPais;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label lblSemestre;
        private System.Windows.Forms.TextBox txtSemestre;

        private System.Windows.Forms.GroupBox gbRegistroCursos;
        private System.Windows.Forms.Label lblCursoUPT;
        private System.Windows.Forms.ComboBox cmbCursosUPT;
        private System.Windows.Forms.Label lblNotaExtranjera;
        private System.Windows.Forms.TextBox txtNotaExtranjera;
        private System.Windows.Forms.Button btnAgregarCurso;

        private System.Windows.Forms.DataGridView dgvCursos;
        private System.Windows.Forms.Label lblTotalCreditos;
        private System.Windows.Forms.Button btnGuardarConvalidacion;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnEliminarCurso;
        private System.Windows.Forms.Button btnLimpiarFormulario;
    }
}