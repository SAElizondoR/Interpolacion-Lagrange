using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

// compilar con mcs form.cs -r:System.Data.dll -r:System.Drawing.dll -r:System.Windows.Forms.dll

public class Program {
    private static Form f;
    private static Label etiqueta1;
    private static NumericUpDown num1;
    private static DataTable tabla;
    private static DataGridView cuadricula1;

    [STAThread]
    public static void Main() {
	f = new Form();
	f.Text = "Interpolación de Lagrange";
	
	
	etiqueta1 = new Label();
	etiqueta1.Text = "Cantidad de datos";
	etiqueta1.Size = new Size(etiqueta1.PreferredWidth, etiqueta1.PreferredHeight);
	num1 = new NumericUpDown();
	// num1.Dock = System.Windows.Forms.DockStyle.Top;
	num1.Location = new Point(0,22);
	num1.Name = "num1";
	num1.Size = new Size(228, 20);
	num1.Value = 1;
	num1.Maximum = 100;
	num1.Minimum = 1;
	num1.ValueChanged += new EventHandler(num1_Cambio);
	// num1.Show();
        
	// añadir elementos a la ventana
	f.Controls.Add(etiqueta1);
	f.Controls.Add(num1);
	
	Application.Run(f);
    }

    private static void num1_Cambio(object remitente, EventArgs e) {
	var num_renglones = num1.Value;

	if(f.Controls.Contains(cuadricula1)) {
	    f.Controls.Remove(cuadricula1);
	    cuadricula1.Dispose();
	}
	
	tabla = new DataTable();
	tabla.Columns.Add("X", typeof(float));
	tabla.Columns.Add("Y", typeof(float));
	for(int i = 0; i < num_renglones; i++) {
	    tabla.Rows.Add(new object[] {0, 0});
	}

	cuadricula1 = new DataGridView();
	cuadricula1.Location = new Point(0, 50);
	cuadricula1.Size = new Size(300, 300);
        cuadricula1.DataSource = tabla;

	f.Controls.Add(cuadricula1);
    }
}
