using System;
using System.Drawing;
using System.Windows.Forms;

// compilar con mcs form.cs -r:System.Drawing.dll -r:System.Windows.Forms.dll

public class Program {
    [STAThread]
    public static void Main() {
	var f = new Form();
	f.Text = "Interpolación de Lagrange";

	var etiqueta1 = new Label();
	etiqueta1.Text = "Cantidad de datos";
	etiqueta1.Size = new Size(etiqueta1.PreferredWidth, etiqueta1.PreferredHeight + 2);
	
	var num1 = new NumericUpDown();
	num1.Dock = System.Windows.Forms.DockStyle.Top;
	num1.Value = 1;
	num1.Maximum = 100;
	num1.Minimum = 1;

	f.Controls.Add(etiqueta1);
	f.Controls.Add(num1);
	
	Application.Run(f);
    }
}
