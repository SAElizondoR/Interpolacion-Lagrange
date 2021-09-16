using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

// compilar con  ! mcs form.cs -r:System.Data.dll -r:System.Drawing.dll -r:System.Windows.Forms.dll

public class Program {
    private static Form f;
    private static Label etiqueta1;
    private static NumericUpDown num1;
    private static Label etiqueta2;
    private static NumericUpDown num2;
    private static Button btn;
    private static Label resultado;
    private static DataTable tabla;
    private static DataGridView cuadricula1;

    [STAThread]
    public static void Main() {
	f = new Form();
	f.Text = "Interpolación de Lagrange";
	f.Size = new Size(300, 400);
	
	
	etiqueta1 = new Label();
	etiqueta1.Text = "Cantidad de datos:";
	etiqueta1.Size = new Size(etiqueta1.PreferredWidth, etiqueta1.PreferredHeight);
	
	num1 = new NumericUpDown();
	// num1.Dock = System.Windows.Forms.DockStyle.Top;
	num1.Location = new Point(2,20);
	num1.Name = "num1";
	num1.Size = new Size(228, 20);
	num1.Value = 0;
	num1.Maximum = 100;
	num1.Minimum = 0;
	num1.ValueChanged += new EventHandler(num1_Cambio);
	// num1.Show();

	etiqueta2 = new Label();
	etiqueta2.Text = "Valor a encontrar:";
	etiqueta2.Size = new Size(etiqueta2.PreferredWidth, etiqueta2.PreferredHeight);
	etiqueta2.Location = new Point(2, 40);

	num2 = new NumericUpDown();
	num2.Location = new Point(2,60);
	num2.Name = "num2";
	num2.Size = new Size(228, 20);
	num2.Value = 0;
	num2.Maximum = 1000;
	num2.Minimum = -1000;
	num2.DecimalPlaces = 2;
	num2.Increment = 0.1M;

	btn = new Button();
	btn.Text = "Resolver";
	btn.Location = new Point(2, 90);
	btn.Size = new Size(70, 20);
	btn.Click += new EventHandler(btn_Seleccionado);

	resultado = new Label();
	resultado.Text = "Resultado:";
	resultado.Location = new Point(2, 120);
        
	// añadir elementos a la ventana
	f.Controls.Add(etiqueta1);
	f.Controls.Add(num1);
	f.Controls.Add(etiqueta2);
	f.Controls.Add(num2);
	f.Controls.Add(btn);
	f.Controls.Add(resultado);
	
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
	cuadricula1.Location = new Point(2, 160);
	cuadricula1.Size = new Size(245, 25 + 22 * Decimal.ToInt32(num_renglones));
        cuadricula1.DataSource = tabla;
	cuadricula1.AllowUserToAddRows = false;

	f.Controls.Add(cuadricula1);
    }

    private static void btn_Seleccionado(object remitente, EventArgs e) {
	//Console.WriteLine("Hello World!");
        /* float x[101], y[101], res = 0, evaluar = 0;
	 float prodnumerador = 0, prodenominador = 0;
	 int pares = 0, i = 0, j = 0;*/
	float[] x = new float[101];
	float[] y = new float[101];
	float? res = null, evaluar = 0, prodnumerador = 0, prodenominador = 0;
	int pares = 0, i = 0, j = 0;

	/*printf("\t----------METODO DE LAGRANGE-----------\n\n");
	printf("\n\t%cCuantos pares ordenados desea ingresar? : ", 168);
	scanf("%i", &pares);*/
	pares = Decimal.ToInt32(num1.Value);

	/*for (i = 0; i < pares; i++){
	    printf("\n\tIngrese el par %i,%i: \n\t", i, i);
	    scanf("%f,%f", &x[i], &y[i]);
	}*/
	for (i = 0; i < pares; i++){
	    x[i] = (float)cuadricula1.Rows[i].Cells[0].Value;
	    y[i] = (float)cuadricula1.Rows[i].Cells[1].Value;;
	}

	/*printf("\n\t%cPara que valor de x desea evaluar? : ", 168);
	scanf("%f", &evaluar);*/
	evaluar= (float)num2.Value;

	if (pares != 0)
	    res = 0;
	
	for (i = 0; i < pares; i++){
	    prodnumerador = 1;
	    prodenominador = 1;
	    for (j = 0; j < pares; j++){
		if (i != j){
		    prodnumerador = prodnumerador * (evaluar - x[j]);
		    prodenominador = prodenominador * (x[i] - x[j]);
		}
	    }
	    res = res + y[i] * (prodnumerador / prodenominador);
	}

	//printf("\n\t y(%.3f) = %f", evaluar, res);
	if(res != null && !Double.IsNaN(Convert.ToDouble(res)))
	    resultado.Text = ($"Resultado:\ny({evaluar})={res}");
	else
	    resultado.Text = ($"Resultado:\ny({evaluar})=N. D.");
    }
}
