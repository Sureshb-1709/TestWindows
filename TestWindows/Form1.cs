using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            Message(btnCut.Text);
        }


        private void Message(string msg)
        {
            IHubProxy _hub;
            string url = @"http://localhost:59099/";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("employeeHub");
            connection.Start().Wait();

            //_hub.On("ReceiveLength", x => Console.WriteLine("Cut"));

            string line = msg;
            if (msg != null)
            {
                _hub.Invoke("sendNotifications", line).Wait();
            }
        }
    }
}
