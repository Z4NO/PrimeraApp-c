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
                MessageBox.Show("Mensaje recibido: " + message);
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
    }
}
