using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PruebaBaseDatos6
{
    public partial class Form1 : Form
    {
        //Como vamos a necesitar la conexion en ambos botones, lo definimos como un atributo de la clase Form1
        SqlConnection conexion = new SqlConnection("server=DESKTOP-BATY ; database=base1 ; integrated security = true");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //El algoritmo de consulta es idéntico al del proyecto de PruebaBaseDatos4:
            conexion.Open();
            string cod = textBox1.Text;
            string cadena = "select descripcion, precio from Table_1 where codigo=" + cod;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                textBox2.Text = registro["descripcion"].ToString();
                textBox3.Text = registro["precio"].ToString();
                button2.Enabled = true;
            }
            else
                MessageBox.Show("No existe un artículo con el código ingresado");
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conexion.Open();

            //Obtenemos los 3 valores ingresados de los Textbox
            string cod = textBox1.Text;
            string descri = textBox2.Text;
            string precio = textBox3.Text;
            //y los confecionamos en un string con el comando Sql
            string cadena = "update Table_1 set descripcion='" + descri + "', precio=" + precio + " where codigo=" + cod;

            //Creamos el objeto SqlCommand y por parametro le pasamos el comando SQL de borrado y la conexion
            SqlCommand comando = new SqlCommand(cadena, conexion);

            /*Llamamos al método ExecuteNonQuery que se comunica con el SQL Server para que 
              ejecute el comando configurado previamente y retorna la cantidad de registros
              afectados*/
            int cant;
            cant = comando.ExecuteNonQuery();

            //Si retorna un uno significa que se efectuó la modificación:
            if (cant == 1)
            {
                MessageBox.Show("Se modificaron los datos del artículo");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
                MessageBox.Show("No existe un artículo con el código ingresado");
            conexion.Close();
            button2.Enabled = false;
        }
    }
}
