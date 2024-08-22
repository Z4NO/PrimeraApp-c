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
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.AspNetCore.SignalR.Client;



namespace AppWindows
{
    public partial class Form3 : Form
    {


        static String path = "";
        private static String conexion = "server=localhost;port=3306;uid=root;pwd='';database=users;convert zero datetime=True";
        private MySqlConnection conexionConnection = new MySqlConnection(conexion);

        private HubConnection conecction;



        String Nombre;
        String id;
        private Form4 tareas_cargadas;
        

        private void ConectarBase()
        {
            try
            {
                conexionConnection.Open();
                MessageBox.Show("Connectado a la base de datos");
                conexionConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "No se pudo conectar por el anterior error");
            }
        }

        private async void ConectarSignalR()
        {

            // Crear la conexión a SignalR
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7065/PruebaHub")
                .Build();

            // Iniciar la conexión
            await connection.StartAsync();

            // Mensaje a la consola cuando la conexión es exitosa 
            MessageBox.Show("Conexión exitosa");

            // Configurar el manejador para recibir mensajes
            connection.On<string>("AwaitMessage", (message) =>
            {
                MessageBox.Show("Mensaje recibido: " + message);
            });

            
        }

        public Form3(String Nombre, String id )
        {
            InitializeComponent();
            this.Nombre = Nombre;
            this.id = id;
            
            ConectarBase();
            this.tareas_cargadas = new Form4(this.conexionConnection, id);
            OpenFormInPanel(tareas_cargadas);

            panel7.Visible = false;

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
            ConectarSignalR();
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            if(panel7.Visible == true)
            {
                panel7.Visible = false;
            }else if(panel7.Visible == false)
            {
                panel7.Visible = true;
            }

        }


        private void CrearTareas(String nombre, int Prioridad, String descripción)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OpenFormInPanel(object Formhijo)
        {
            if (this.panelControaldor.Controls.Count > 0)
                this.panelControaldor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelControaldor.Controls.Add(fh);
            this.panelControaldor.Tag = fh;
            fh.Show();

            fh.FormClosing += new FormClosingEventHandler(FormHijo_FormClosing);

        }

        private void FormHijo_FormClosing(object sender, FormClosingEventArgs e)
        {
            OpenFormInPanel(tareas_cargadas);
        }

        private void Tareas_Click(object sender, EventArgs e)
        {
            //BOTON PARA ENTREGAR UNA TAREA
            Crear_tarea entregar = new Crear_tarea(this.id);
            OpenFormInPanel(entregar);
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(tareas_cargadas);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
