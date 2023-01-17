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

namespace PruebaBaseDatos7
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
            string cadena = "insert into Table_1(descripcion,precio) values (@descripcion,@precio)";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
            comando.Parameters.Add("@precio", SqlDbType.Float);
            comando.Parameters["@descripcion"].Value = textBox1.Text;
            comando.Parameters["@precio"].Value = float.Parse(textBox2.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Los datos se guardaron correctamente");
            textBox1.Text = "";
            textBox2.Text = "";
            conexion.Close();
        }
    }
}
