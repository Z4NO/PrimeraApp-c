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

namespace AppWindows
{
    public partial class Crear_tarea : Form
    {
        public Crear_tarea()
        {
            InitializeComponent();
            textBox2.ReadOnly = true;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String path = BuscarTarea();
            var  res = MessageBox.Show("Estas seguro que quierea entregar esta tarea? = " + path,"Entrga",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                String consulta = "UPDATE ";
                MessageBox.Show("Tarea entregada con exito", "Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tarea no entregada", "Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

            public void completarTarea()
            {
                this.Completada = true;
            }

            public void ObtenerArchivoDeLaBaseDeDatos()
            {
                //Obtener archivo de la base de datos
                String consulta = "SELECT Archivo FROM Tareas WHERE Nombre = " + this.Nombre;

            }
        }

        
    }
}
