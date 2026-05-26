using OxyPlot.WindowsForms;
using System.Windows.Forms;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    partial class FormEstadisticas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblFiltro;
        private ComboBox cmbFiltro;
        private Label lblTotal;
        private DataGridView dgvConsultas;
        private PlotView graficoEstadistico;

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
            lblFiltro = new Label();
            cmbFiltro = new ComboBox();
            lblTotal = new Label();
            dgvConsultas = new DataGridView();
            graficoEstadistico = new PlotView();
            ((System.ComponentModel.ISupportInitialize)dgvConsultas).BeginInit();
            SuspendLayout();
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Location = new Point(23, 27);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(204, 20);
            lblFiltro.TabIndex = 0;
            lblFiltro.Text = "Seleccione el tipo de reporte:";
            // 
            // cmbFiltro
            // 
            cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltro.FormattingEnabled = true;
            cmbFiltro.Items.AddRange(new object[] { "Por País", "Por Universidad", "Por Año", "Por Semestre", "Por Estudiante" });
            cmbFiltro.Location = new Point(240, 24);
            cmbFiltro.Margin = new Padding(3, 4, 3, 4);
            cmbFiltro.Name = "cmbFiltro";
            cmbFiltro.Size = new Size(228, 28);
            cmbFiltro.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(514, 27);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(202, 23);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total Convalidaciones: 0";
            // 
            // dgvConsultas
            // 
            dgvConsultas.AllowUserToAddRows = false;
            dgvConsultas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConsultas.ColumnHeadersHeight = 29;
            dgvConsultas.Location = new Point(23, 80);
            dgvConsultas.Margin = new Padding(3, 4, 3, 4);
            dgvConsultas.Name = "dgvConsultas";
            dgvConsultas.ReadOnly = true;
            dgvConsultas.RowHeadersWidth = 51;
            dgvConsultas.Size = new Size(343, 640);
            dgvConsultas.TabIndex = 3;
            // 
            // graficoEstadistico
            // 
            graficoEstadistico.Location = new Point(389, 80);
            graficoEstadistico.Margin = new Padding(3, 4, 3, 4);
            graficoEstadistico.Name = "graficoEstadistico";
            graficoEstadistico.PanCursor = Cursors.Hand;
            graficoEstadistico.Size = new Size(537, 640);
            graficoEstadistico.TabIndex = 4;
            graficoEstadistico.ZoomHorizontalCursor = Cursors.SizeWE;
            graficoEstadistico.ZoomRectangleCursor = Cursors.SizeNWSE;
            graficoEstadistico.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // FormEstadisticas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 800);
            Controls.Add(graficoEstadistico);
            Controls.Add(dgvConsultas);
            Controls.Add(lblTotal);
            Controls.Add(cmbFiltro);
            Controls.Add(lblFiltro);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormEstadisticas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consultas y Gráficos Estadísticos";
            ((System.ComponentModel.ISupportInitialize)dgvConsultas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
