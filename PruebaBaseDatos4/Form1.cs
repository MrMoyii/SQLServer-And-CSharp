using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; //Importo la clase para poder conectarme a la bbdd
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaBaseDatos4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //nos conectamos con el motor de base de datos y abrir la conexión:
            SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-BATY ; database=base1 ; integrated security = true");
            sqlConnection.Open();

            //recuperamos lo que se ingreso en el TextBox
            string cod = textBox1.Text;

            //almacenamos en un string el comando SQL select para recuperar la descripción 
            //y el precio del artículo cuyo código coincide con el valor ingresado por teclado:
            string cadena = "select descripcion, precio from Table_1 where codigo=" + cod;

            //Creamos un objeto de la clase SqlCommand pasando el comando SQL y la referencia a la conexión:
            SqlCommand sqlCommand = new SqlCommand(cadena, sqlConnection);

            //Recuperamos un objeto de la clase SqlDataReader que retorna el objeto 
            //de la clase SqlCommand mediante el llamando al método EcecuteReader:
            SqlDataReader registro = sqlCommand.ExecuteReader();

            //si el comando select recuperó un registro de la tabla Table_1, luego el metodo Read
            //verifica que haya filas en la tabla, de ser asi entonces se imprime por pantalla los datos
            if (registro.Read())
            {
                label4.Text = registro["descripcion"].ToString();
                label5.Text = registro["precio"].ToString();
            }
            else //En el caso que hayamos ingresado un código inexistente procedemos a mostrar un mensaje por el else:
                MessageBox.Show("No existe un artículo con el código ingresado");
        }
    }
}
