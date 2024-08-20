using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppWindows
{
    public partial class Crear_tarea : Form
    {

        static String path = "";
        private static String conexion = "server=localhost;port=3306;uid=root;pwd='';database=users;";
        private MySqlConnection conexionConnection = new MySqlConnection(conexion);
        String id;

        private void ConectarBase()
        {
            try
            {
                conexionConnection.Open();
                conexionConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "No se pudo conectar por el anterior error");
            }

        }
        public Crear_tarea(String id)
        {
            InitializeComponent();
            textBox2.ReadOnly = true;
            this.id = id;
            ConectarBase();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Estas seguro que quieres entregar esta tarea? = " + path, "Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                String consulta = "UPDATE tareas SET Completado=True, Archivo=@path WHERE Nombre=@Nombre AND FK_ID=@ID";

                // Usar using para asegurar que la conexión se cierre adecuadamente
                using (MySqlConnection conexionConnection = new MySqlConnection(conexion))
                {
                    try
                    {
                        conexionConnection.Open();
                        using (MySqlCommand cmdUser = new MySqlCommand(consulta, conexionConnection))
                        {
                            cmdUser.Parameters.AddWithValue("@Nombre", textBox1.Text);
                            cmdUser.Parameters.AddWithValue("@path", textBox2.Text);
                            cmdUser.Parameters.AddWithValue("@ID", id);

                            // Ejecutar el comando
                            int rowsAffected = cmdUser.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Tarea entregada con éxito", "Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se encontró la tarea a entregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Tarea no entregada", "Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            path = BuscarTarea();

            textBox2.Text = path;
        }

        private String  BuscarTarea()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();

                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                }
            }

            MessageBox.Show(fileContent, "Estas a punto de entregar la siguiente tarea = " + filePath, MessageBoxButtons.OK);
            return filePath;
        }

        public class Tarea
        {
            public String Nombre { get; set; }
            public int Prioridad { get; set; }
            public String Descripción { get; set; }
            public Boolean Completada { get; set; }
            public FileInfo archivo { get; set; }
            public Tarea(String Nombre, int Prioridad, String Descripción)
            {
                this.Nombre = Nombre;
                if (Prioridad < 1 || Prioridad > 5)
                {
                    throw new Exception("La prioridad debe ser un número entre 1 y 5");
                }
                else
                {
                    this.Prioridad = Prioridad;
                }
                this.Descripción = Descripción;
                this.Completada = false;

            }

            //METODO LEER ARCHIVO (TAREA) (NO FUNCIONA) (DEBEMOS ADAPTARLO A UNA VENTANA)
            public void LeerArchivo()
            {
                if (archivo.Exists)
                {
                    using (StreamReader sr = archivo.OpenText())
                    {
                        String s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
            }

            
        }

       
    }
}
