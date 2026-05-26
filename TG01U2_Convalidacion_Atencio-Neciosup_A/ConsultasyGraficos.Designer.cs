namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    partial class ConsultasyGraficos
    {
        private System.ComponentModel.IContainer components = null;
        internal System.Windows.Forms.Button btnConvalidaciones;
        internal System.Windows.Forms.Button btnEstadisticas;
        internal System.Windows.Forms.Button btnBusqueda;
        internal System.Windows.Forms.Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnConvalidaciones = new Button();
            btnEstadisticas = new Button();
            btnBusqueda = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnConvalidaciones
            // 
            btnConvalidaciones.Location = new Point(32, 36);
            btnConvalidaciones.Margin = new Padding(3, 4, 3, 4);
            btnConvalidaciones.Name = "btnConvalidaciones";
            btnConvalidaciones.Size = new Size(137, 53);
            btnConvalidaciones.TabIndex = 0;
            btnConvalidaciones.Text = "Convalidaciones";
            btnConvalidaciones.UseVisualStyleBackColor = true;
            // 
            // btnEstadisticas
            // 
            btnEstadisticas.Location = new Point(33, 97);
            btnEstadisticas.Margin = new Padding(3, 4, 3, 4);
            btnEstadisticas.Name = "btnEstadisticas";
            btnEstadisticas.Size = new Size(137, 53);
            btnEstadisticas.TabIndex = 1;
            btnEstadisticas.Text = "Estadísticas";
            btnEstadisticas.UseVisualStyleBackColor = true;
            // 
            // btnBusqueda
            // 
            btnBusqueda.Location = new Point(175, 36);
            btnBusqueda.Margin = new Padding(3, 4, 3, 4);
            btnBusqueda.Name = "btnBusqueda";
            btnBusqueda.Size = new Size(137, 53);
            btnBusqueda.TabIndex = 2;
            btnBusqueda.Text = "Búsqueda";
            btnBusqueda.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(176, 97);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(137, 53);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // ConsultasyGraficos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(347, 186);
            Controls.Add(btnSalir);
            Controls.Add(btnBusqueda);
            Controls.Add(btnEstadisticas);
            Controls.Add(btnConvalidaciones);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ConsultasyGraficos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Convalidación";
            ResumeLayout(false);
        }
    }
}
