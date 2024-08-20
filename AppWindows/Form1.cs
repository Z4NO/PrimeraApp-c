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

                // Consulta para el admin
                string selectAdminQuery = "SELECT * FROM admin WHERE Nombre = @nombre";
                using (MySqlCommand cmd = new MySqlCommand(selectAdminQuery, conexionConnection))
                {
                    cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && textBox2.Text.Equals(reader["Contraseña"].ToString()))
                        {
                            MessageBox.Show("Bienvenido " + textBox1.Text);
                            Form2 Ventana2 = new Form2(list);
                            Ventana2.ShowDialog();
                            this.Hide();
                        }
                        else
                        {
                            reader.Close();

                            // Consulta para el usuario
                            string selectUserQuery = "SELECT * FROM users WHERE Nombre = @nombre";
                            using (MySqlCommand cmdUser = new MySqlCommand(selectUserQuery, conexionConnection))
                            {
                                cmdUser.Parameters.AddWithValue("@nombre", textBox1.Text);
                                using (MySqlDataReader readerUser = cmdUser.ExecuteReader())
                                {
                                    if (readerUser.Read() && Convert.ToBoolean(readerUser["Registrado"]) && textBox2.Text.Equals("user"))
                                    {
                                        MessageBox.Show("Bienvenido " + textBox1.Text);
                                        Form3 Ventana3 = new Form3(textBox1.Text, Convert.ToString(readerUser["ID"]));
                                        Ventana3.ShowDialog();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Usuario o contraseña incorrecta o No estas todavía registrado");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la siguiente operación por el siguiente motivo: " + ex.Message);
            }
            
        }



    }

}

