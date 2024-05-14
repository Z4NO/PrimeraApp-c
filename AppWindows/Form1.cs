using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppWindows
{
    public partial class Form1 : Form
    {
        public List<Alumno> list = new List<Alumno>();

        private static String conexion = "server=localhost;port=3306;uid=root;pwd='';database=users;";
        private MySqlConnection conexionConnection = new MySqlConnection(conexion);
        private void ConectarBase()
        {
            try
            {
                conexionConnection.Open();
                MessageBox.Show("Connectado a la base de datos");
                conexionConnection.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"No se pudo conectar por el anterior error");
            }
        }
        public Form1()
        {
            InitializeComponent();
            ConectarBase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void LabeNombre_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                conexionConnection.Open();

                // Crear la consulta SQL con parámetros
                String Select = "SELECT * FROM admin WHERE Nombre =" + "'" + textBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(Select, conexionConnection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (textBox2.Text.Equals(reader["Contraseña"].ToString()) && reader != null)
                {
                    Form2 Ventana2 = new Form2(list);
                    Ventana2.ShowDialog();
                    conexionConnection.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show("No se pudo realizar la siguiente operacion por el siguiente motivo =  " + ex.Message);  
            }
        }
     
    }
    
}

