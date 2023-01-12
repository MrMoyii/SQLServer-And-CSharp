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

namespace pruebabasedatos2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=DESKTOP-BATY ; database=base1 ; integrated security = true");
            conexion.Open();
            string descri = textBox1.Text;
            string precio = textBox2.Text;
            string cadena = "insert into Table_1(descripcion,precio) values ('" + descri + "'," + precio + ")";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Los datos se guardaron correctamente");
            textBox1.Text = "";
            textBox2.Text = "";
            conexion.Close();
        }
    }
}
