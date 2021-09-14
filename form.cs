using System;
using System.Windows.Forms;

public class Program {
    [STAThread]
    public static void Main() {
	var f = new Form();
	f.Text = "Olas";
	Application.Run(f);
    }
}
