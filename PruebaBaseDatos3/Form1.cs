using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaBaseDatos3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObtenerDatos();
        }

        private void ObtenerDatos()
        {
            //Lo primero que hacemos es configurar la cadena de conexión y abrirla:
            SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-BATY ; database=base1 ; integrated security = true");
            sqlConnection.Open();

            //El comando SQL para recuperar todas la filas de la tabla articulos es:
            string cadena = "select codigo, descripcion, precio from Table_1";

            //Seguidamente seguimos con la creación del objeto de la clase SqlCommand pasando el string con el comando SQL y la referencia a la conexión:
            SqlCommand sqlCommand = new SqlCommand(cadena, sqlConnection);

            //llamamos al método ExecuteReader del objeto SqlCommand para recuperar los datos que genera el SQL Server:
            //Este método retorna un objeto de la clase SqlDataReader que almacena el resultado del comando SQL select.
            SqlDataReader registros = sqlCommand.ExecuteReader();

            //Para acceder a cada fila retornada por el comando SQL select,
            //debemos disponer una estructura repetitiva while y llamar en cada vuelta del ciclo al método Read:
            while (registros.Read())
            {
                textBox1.AppendText(registros["codigo"] + " - " + registros["descripcion"] + " - " + registros["precio"]);
                textBox1.AppendText(Environment.NewLine); //Esto crea saltos de linea
            }
            //Cerramos la conexion.
            sqlConnection.Close();
        }
    }
}
