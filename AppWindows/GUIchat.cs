using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWindows
{
    public partial class GUIchat : Form
    {
        
        private String Nombre;
        private HubConnection con;

        public async void ConectarDesconectarSignalR()
        {

            // Crear la conexión a SignalR
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7065/PruebaHub")
                .Build();

            con = connection;
            //Comprobamos si la conexión está activa
            if (con.State == HubConnectionState.Connected)
            {
                // Desconectar
                await con.StopAsync();
            }
            else
            {
                // Conectar
                await con.StartAsync();
            }

            // Configurar el manejador para recibir mensajes
            con.On<string>("AwaitMessage", (message) =>
            {
                RecibirMensaje(message);
            });
            


        }
        public GUIchat(String nombre)
        {
            this.Nombre = nombre;
            InitializeComponent();
            ConectarDesconectarSignalR();

        }


        private void GUIchat_Closed(object sender, EventArgs e)
        {
            // Cerrar la conexión
            ConectarDesconectarSignalR();
        }

        private void GUIchat_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Multiline = true;
            textBox1.ReadOnly = true;
            textBox1.Font = new Font("Arial", 20, FontStyle.Regular);
            Dock = DockStyle.Fill;
        }
        private void RecibirMensaje(string mensaje)
        {
            if(textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action(() => RecibirMensaje(mensaje)));
            }
            else
            {
                textBox1.AppendText(Nombre+": " + mensaje + Environment.NewLine);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        private async Task EnviarMensaje(string mensaje)
        {
            if (con != null && con.State == HubConnectionState.Connected)
            {
                await con.SendAsync("SendMessage", mensaje);
            }
        }

        private  async void button2_Click(object sender, EventArgs e)
        {
            await EnviarMensaje(textBox2.Text);
            textBox2.Clear();
        }
    }
}
