using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace ReporteEjemplo
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                String query = "Select pro.NombreProducto,cat.NombreCategoria,pro.PrecioUnitario,pro.UnidadesEnExistencia" +
                    " From Productos pro inner join Categorias2 cat" + " On pro.IdCategoria = cat.id;";
                OdbcConnection cnn;

                cnn = new OdbcConnection("Driver={SQL Server};Server=1CAE-GUA-PC152\\SQLEXPRESS;UID=;PWD=;Database=Neptuno;");
                cnn.Open();

                Ejemplo Reporte = new Ejemplo();
                DsReporteEjemplo dsReportePCE = new DsReporteEjemplo();
                OdbcDataAdapter adapter = new OdbcDataAdapter(query, cnn);
                adapter.Fill(dsReportePCE, "Productos");
                Reporte.SetDataSource(dsReportePCE);

                crystalReportViewer1.ReportSource = Reporte;

                MessageBox.Show("Conectado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto la db: " + ex.ToString());
            }
        }
    }
}
