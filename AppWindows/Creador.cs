using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using System.Net.Mail;
using System.Net;

namespace AppWindows
{
    public partial class Creador : Form
    {
        String id;
        private static String conexion = "server=localhost;port=3306;uid=root;pwd='';database=users;";
        private MySqlConnection conexionConnection = new MySqlConnection(conexion);
        public Creador(String ID)
        {
            InitializeComponent();
            id = ID;
        }

        private void Creador_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Creamos la consulta para insertar los daatos de la tarea
            conexionConnection.Open();
            String query = "INSERT INTO tareas (Nombre, FK_ID, Completado, Archivo, fecha) VALUES (@Nombre, @FK_ID, @Completado, @Archivo, @fecha)";
            MySqlCommand comando = new MySqlCommand(query, conexionConnection);
            comando.Parameters.AddWithValue("@Nombre", textBox1.Text);
            comando.Parameters.AddWithValue("@FK_ID", id);
            comando.Parameters.AddWithValue("@Completado", false);
            comando.Parameters.AddWithValue("@Archivo", "");
            comando.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
            comando.ExecuteNonQuery();
            conexionConnection.Close();


            this.Close();
        }
    }
}
