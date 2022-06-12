using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace clientnew
{
    public partial class MainPage : ContentPage
    {              //  Int32 port = 13000;
        TcpClient client = new TcpClient("192.168.1.100", 13000); //se connecte au serveur au lancement de l'application
        public MainPage()
        {
            InitializeComponent();
        
        }
        async public void envoi(string message) //envoi un message au serveur
        {
            try { 
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);// Send the message to the connected TcpServer.
           
            data = new Byte[256]; 
            String responseData = String.Empty;

            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            message_server.Text = responseData; //affiche le message recu
            }catch (Exception ex) { }
        }
     /*   async public void Receive() 
        {
            Byte[] data;
            NetworkStream stream = client.GetStream();
            data = new Byte[256]; String responseData = String.Empty;

            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            message_server.Text = responseData;
        }*/
        
        async public void essai_a(object sender, EventArgs e)
        {
            //Console.WriteLine("a");
            envoi("a");
            //Connect("192.168.1.34", "a");
        }
        async public void essai_b(object sender, EventArgs e)
        {
            envoi("b");
              // Connect("192.168.1.34", "b");
        }

    }
}
