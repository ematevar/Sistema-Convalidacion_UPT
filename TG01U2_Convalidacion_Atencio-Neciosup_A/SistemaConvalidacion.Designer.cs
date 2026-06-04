// ============================================================
// ARCHIVO: SistemaConvalidacion.Designer.cs
// CAMBIO:  Se agrega lblCodigoEstudiante y txtCodigoEstudiante
//          dentro del grupo gbDatosEstudiante.
//          Busca "── NUEVO" para localizar exactamente qué agregar.
// ============================================================

namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    partial class SistemaConvalidacion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            gbDatosEstudiante   = new GroupBox();
            lblCodigoEstudiante = new Label();     // ← NUEVO
            txtCodigoEstudiante = new TextBox();   // ← NUEVO
            lblSemestre         = new Label();
            cmbSemestre         = new ComboBox();
            lblAnio             = new Label();
            txtAnio             = new TextBox();
            lblPais             = new Label();
            cmbPais             = new ComboBox();
            lblUniversidad      = new Label();
            txtUniversidad      = new TextBox();
            lblNombre           = new Label();
            txtNombre           = new TextBox();
            gbRegistroCursos    = new GroupBox();
            lblCursoUPT         = new Label();
            cmbCursosUPT        = new ComboBox();
            lblNotaExtranjera   = new Label();
            txtNotaExtranjera   = new TextBox();
            btnAgregarCurso     = new Button();
            dgvCursos           = new DataGridView();
            lblTotalCreditos    = new Label();
            txtTotal            = new TextBox();
            btnGuardarConvalidacion = new Button();
            btnEliminarCurso        = new Button();
            btnLimpiarFormulario    = new Button();

            gbRegistroCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).BeginInit();
            gbDatosEstudiante.SuspendLayout();
            SuspendLayout();

            // ── gbDatosEstudiante ─────────────────────────────────────────────
            gbDatosEstudiante.Controls.Add(lblCodigoEstudiante); // ← NUEVO
            gbDatosEstudiante.Controls.Add(txtCodigoEstudiante); // ← NUEVO
            gbDatosEstudiante.Controls.Add(lblSemestre);
            gbDatosEstudiante.Controls.Add(cmbSemestre);
            gbDatosEstudiante.Controls.Add(lblAnio);
            gbDatosEstudiante.Controls.Add(txtAnio);
            gbDatosEstudiante.Controls.Add(lblPais);
            gbDatosEstudiante.Controls.Add(cmbPais);
            gbDatosEstudiante.Controls.Add(lblUniversidad);
            gbDatosEstudiante.Controls.Add(txtUniversidad);
            gbDatosEstudiante.Controls.Add(lblNombre);
            gbDatosEstudiante.Controls.Add(txtNombre);
            gbDatosEstudiante.Font      = new Font("Segoe UI", 9F);
            gbDatosEstudiante.Location  = new Point(25, 25);
            gbDatosEstudiante.Name      = "gbDatosEstudiante";
            gbDatosEstudiante.Padding   = new Padding(3, 4, 3, 4);
            gbDatosEstudiante.Size      = new Size(830, 230);   // ← altura aumentada para nueva fila
            gbDatosEstudiante.TabIndex  = 0;
            gbDatosEstudiante.TabStop   = false;
            gbDatosEstudiante.Text      = "Información del Estudiante y Movilidad Internacional";

            // ── NUEVO: lblCodigoEstudiante / txtCodigoEstudiante ──────────────
            //    Se ubica en la primera fila, antes del nombre.
            lblCodigoEstudiante.AutoSize = true;
            lblCodigoEstudiante.Location = new Point(20, 38);
            lblCodigoEstudiante.Name     = "lblCodigoEstudiante";
            lblCodigoEstudiante.Size     = new Size(140, 20);
            lblCodigoEstudiante.TabIndex = 20;
            lblCodigoEstudiante.Text     = "Código del Estudiante:";

            txtCodigoEstudiante.Location    = new Point(20, 66);
            txtCodigoEstudiante.Name        = "txtCodigoEstudiante";
            txtCodigoEstudiante.Size        = new Size(150, 27);
            txtCodigoEstudiante.TabIndex    = 1;
            txtCodigoEstudiante.MaxLength   = 10;
            // Solo números (0-9) - validado en tiempo de entrada

            // ── lblNombre / txtNombre (se mueven a la segunda posición en X) ──
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(190, 38);
            lblNombre.Name     = "lblNombre";
            lblNombre.Size     = new Size(165, 20);
            lblNombre.TabIndex = 9;
            lblNombre.Text     = "Nombre del Estudiante:";

            txtNombre.Location = new Point(190, 66);
            txtNombre.Name     = "txtNombre";
            txtNombre.Size     = new Size(210, 27);
            txtNombre.TabIndex = 2;

            // ── txtUniversidad ────────────────────────────────────────────────
            lblUniversidad.AutoSize = true;
            lblUniversidad.Location = new Point(420, 38);
            lblUniversidad.Name     = "lblUniversidad";
            lblUniversidad.Size     = new Size(160, 20);
            lblUniversidad.TabIndex = 8;
            lblUniversidad.Text     = "Universidad de Origen:";

            txtUniversidad.Location = new Point(420, 66);
            txtUniversidad.Name     = "txtUniversidad";
            txtUniversidad.Size     = new Size(200, 27);
            txtUniversidad.TabIndex = 3;

            // ── cmbPais ───────────────────────────────────────────────────────
            lblPais.AutoSize = true;
            lblPais.Location = new Point(635, 38);
            lblPais.Name     = "lblPais";
            lblPais.Size     = new Size(107, 20);
            lblPais.TabIndex = 7;
            lblPais.Text     = "País de Origen:";

            cmbPais.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPais.FormattingEnabled = true;
            cmbPais.Items.AddRange(new object[]
            {
                "Seleccione un país...",
                "Argentina", "Bolivia", "Brasil", "Chile", "Colombia",
                "Ecuador", "España", "Francia", "Grecia", "Italia",
                "México", "Paraguay", "Perú"
            });
            cmbPais.Location      = new Point(635, 66);
            cmbPais.Name          = "cmbPais";
            cmbPais.Size          = new Size(175, 28);
            cmbPais.TabIndex      = 4;
            cmbPais.SelectedIndex = 0;

            // ── Segunda fila: Año y Semestre ──────────────────────────────────
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(20, 115);
            lblAnio.Name     = "lblAnio";
            lblAnio.Size     = new Size(118, 20);
            lblAnio.TabIndex = 6;
            lblAnio.Text     = "Año Académico:";

            txtAnio.Location = new Point(20, 143);
            txtAnio.Name     = "txtAnio";
            txtAnio.Size     = new Size(120, 27);
            txtAnio.TabIndex = 5;

            lblSemestre.AutoSize = true;
            lblSemestre.Location = new Point(160, 115);
            lblSemestre.Name     = "lblSemestre";
            lblSemestre.Size     = new Size(73, 20);
            lblSemestre.TabIndex = 0;
            lblSemestre.Text     = "Semestre:";

            cmbSemestre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSemestre.Items.AddRange(new object[] { "1", "2" });
            cmbSemestre.Location = new Point(160, 143);
            cmbSemestre.Name     = "cmbSemestre";
            cmbSemestre.Size     = new Size(100, 28);
            cmbSemestre.TabIndex = 6;

            // ── gbRegistroCursos (se desplaza hacia abajo por la altura extra) ─
            gbRegistroCursos.Controls.Add(lblCursoUPT);
            gbRegistroCursos.Controls.Add(cmbCursosUPT);
            gbRegistroCursos.Controls.Add(lblNotaExtranjera);
            gbRegistroCursos.Controls.Add(txtNotaExtranjera);
            gbRegistroCursos.Controls.Add(btnAgregarCurso);
            gbRegistroCursos.Font     = new Font("Segoe UI", 9F);
            gbRegistroCursos.Location = new Point(25, 270);  // ← 25 más abajo
            gbRegistroCursos.Name     = "gbRegistroCursos";
            gbRegistroCursos.Padding  = new Padding(3, 4, 3, 4);
            gbRegistroCursos.Size     = new Size(830, 125);
            gbRegistroCursos.TabIndex = 6;
            gbRegistroCursos.TabStop  = false;
            gbRegistroCursos.Text     = "Asignaturas y Equivalencias de Calificación";

            lblCursoUPT.AutoSize = true;
            lblCursoUPT.Location = new Point(20, 38);
            lblCursoUPT.Name     = "lblCursoUPT";
            lblCursoUPT.Size     = new Size(160, 20);
            lblCursoUPT.TabIndex = 0;
            lblCursoUPT.Text     = "Curso Equivalente UPT:";

            cmbCursosUPT.DropDownStyle     = ComboBoxStyle.DropDownList;
            cmbCursosUPT.FormattingEnabled = true;
            cmbCursosUPT.Location          = new Point(20, 66);
            cmbCursosUPT.Name              = "cmbCursosUPT";
            cmbCursosUPT.Size              = new Size(350, 28);
            cmbCursosUPT.TabIndex          = 7;

            lblNotaExtranjera.AutoSize = true;
            lblNotaExtranjera.Location = new Point(390, 38);
            lblNotaExtranjera.Name     = "lblNotaExtranjera";
            lblNotaExtranjera.Size     = new Size(181, 20);
            lblNotaExtranjera.TabIndex = 8;
            lblNotaExtranjera.Text     = "Nota Obtenida Extranjera:";

            txtNotaExtranjera.Location = new Point(390, 66);
            txtNotaExtranjera.Name     = "txtNotaExtranjera";
            txtNotaExtranjera.Size     = new Size(180, 27);
            txtNotaExtranjera.TabIndex = 8;

            btnAgregarCurso.BackColor = Color.LimeGreen;
            btnAgregarCurso.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregarCurso.ForeColor = Color.White;
            btnAgregarCurso.Location  = new Point(590, 60);
            btnAgregarCurso.Name      = "btnAgregarCurso";
            btnAgregarCurso.Size      = new Size(210, 44);
            btnAgregarCurso.TabIndex  = 9;
            btnAgregarCurso.Text      = "+ Agregar Asignatura";
            btnAgregarCurso.UseVisualStyleBackColor = false;

            // ── dgvCursos (se desplaza hacia abajo) ──────────────────────────
            dgvCursos.AllowUserToAddRows              = false;
            dgvCursos.AutoSizeColumnsMode             = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCursos.ColumnHeadersHeightSizeMode     = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCursos.Location                        = new Point(25, 420);  // ← ajustado
            dgvCursos.Name                            = "dgvCursos";
            dgvCursos.RowHeadersWidth                 = 51;
            dgvCursos.RowTemplate.Height              = 24;
            dgvCursos.Size                            = new Size(830, 300);
            dgvCursos.TabIndex                        = 10;

            // ── Total créditos ────────────────────────────────────────────────
            lblTotalCreditos.AutoSize = true;
            lblTotalCreditos.Font     = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblTotalCreditos.Location = new Point(25, 740);
            lblTotalCreditos.Name     = "lblTotalCreditos";
            lblTotalCreditos.Size     = new Size(258, 25);
            lblTotalCreditos.TabIndex = 11;
            lblTotalCreditos.Text     = "Total Créditos Convalidados:";

            txtTotal.Location  = new Point(289, 741);
            txtTotal.Name      = "txtTotal";
            txtTotal.ReadOnly  = true;
            txtTotal.Size      = new Size(100, 27);
            txtTotal.TabIndex  = 10;
            txtTotal.BackColor = Color.WhiteSmoke;
            txtTotal.Text      = "0";

            // ── Botones inferiores ────────────────────────────────────────────
            btnGuardarConvalidacion.BackColor = Color.RoyalBlue;
            btnGuardarConvalidacion.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardarConvalidacion.ForeColor = Color.White;
            btnGuardarConvalidacion.Location  = new Point(240, 790);
            btnGuardarConvalidacion.Name      = "btnGuardarConvalidacion";
            btnGuardarConvalidacion.Size      = new Size(200, 56);
            btnGuardarConvalidacion.TabIndex  = 12;
            btnGuardarConvalidacion.Text      = "✓ Guardar Registro";
            btnGuardarConvalidacion.UseVisualStyleBackColor = false;

            btnEliminarCurso.BackColor = Color.Red;
            btnEliminarCurso.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminarCurso.ForeColor = Color.White;
            btnEliminarCurso.Location  = new Point(460, 790);
            btnEliminarCurso.Name      = "btnEliminarCurso";
            btnEliminarCurso.Size      = new Size(200, 56);
            btnEliminarCurso.TabIndex  = 13;
            btnEliminarCurso.Text      = "✕ Eliminar Seleccionado";
            btnEliminarCurso.UseVisualStyleBackColor = false;

            btnLimpiarFormulario.BackColor = Color.Orange;
            btnLimpiarFormulario.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiarFormulario.ForeColor = Color.White;
            btnLimpiarFormulario.Location  = new Point(680, 790);
            btnLimpiarFormulario.Name      = "btnLimpiarFormulario";
            btnLimpiarFormulario.Size      = new Size(165, 56);
            btnLimpiarFormulario.TabIndex  = 14;
            btnLimpiarFormulario.Text      = "Nuevo Registro";
            btnLimpiarFormulario.UseVisualStyleBackColor = false;

            // ── Form ──────────────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(882, 870);  // ← altura aumentada
            Controls.Add(btnLimpiarFormulario);
            Controls.Add(btnEliminarCurso);
            Controls.Add(txtTotal);
            Controls.Add(btnGuardarConvalidacion);
            Controls.Add(lblTotalCreditos);
            Controls.Add(dgvCursos);
            Controls.Add(gbRegistroCursos);
            Controls.Add(gbDatosEstudiante);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox     = false;
            Name            = "SistemaConvalidacion";
            StartPosition   = FormStartPosition.CenterScreen;
            Text            = "Sistema de Reconocimiento de Movilidad Internacional - UPT";

            gbRegistroCursos.ResumeLayout(false);
            gbRegistroCursos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).EndInit();
            gbDatosEstudiante.ResumeLayout(false);
            gbDatosEstudiante.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox  gbDatosEstudiante;
        // ── NUEVO ──────────────────────────────────────────────────────────────
        private Label     lblCodigoEstudiante;
        private TextBox   txtCodigoEstudiante;
        // ── Existentes ─────────────────────────────────────────────────────────
        private Label     lblNombre;
        private TextBox   txtNombre;
        private Label     lblUniversidad;
        private TextBox   txtUniversidad;
        private Label     lblPais;
        private ComboBox  cmbPais;
        private Label     lblAnio;
        private TextBox   txtAnio;
        private Label     lblSemestre;
        private ComboBox  cmbSemestre;
        private GroupBox  gbRegistroCursos;
        private Label     lblCursoUPT;
        private ComboBox  cmbCursosUPT;
        private Label     lblNotaExtranjera;
        private TextBox   txtNotaExtranjera;
        private Button    btnAgregarCurso;
        private DataGridView dgvCursos;
        private Label     lblTotalCreditos;
        private TextBox   txtTotal;
        private Button    btnGuardarConvalidacion;
        private Button    btnEliminarCurso;
        private Button    btnLimpiarFormulario;
    }
}
