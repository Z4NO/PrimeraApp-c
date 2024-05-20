using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.IO;



namespace AppWindows
{
    public partial class Form3 : Form
    {
        String Nombre;
        public Form3(String Nombre)
        {
            InitializeComponent();
            this.Nombre = Nombre;
            

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox1.Visible = false;
            BtnRestaurar.Visible = true;

        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            BtnRestaurar.Visible=false;
            pictureBox1.Visible=true;
        }

        private void panelControaldor_Paint(object sender, PaintEventArgs e)
        {

        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern IntPtr SendMessage(System.IntPtr hWnd, int wMsg,int WParam, int Pram);

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            

        }


        private void CrearTareas(String nombre, int Prioridad, String descripción)
        {

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
                if( Prioridad < 1 || Prioridad > 5)
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
