using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp;
using FireSharp.Config;
using FireSharp.Exceptions;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;

namespace PartsHunter
{
    public partial class Form1 : Form
    {

        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "TM374FQNi942pHZVUhXPCuJIlkCiimQGmdlP0Gfj",
            BasePath = "https://partshunter-99d4a-default-rtdb.firebaseio.com/"
        };



        private IFirebaseClient Client;

        public Form1()
        {
            InitializeComponent();

            Client = new FireSharp.FirebaseClient(Config);
            
            if (Client == null)            
                MessageBox.Show("Error Connection");            
        }

        private async void button25_Click(object sender, EventArgs e)
        {
            //Push_New_Component();
        }


        void Push_New_Component(string category, string description, int quantity, int box, int drawer)
        {
            var todo = new
            {
                Description = description,
                Quantity = quantity,
                Box = box,
                Drawer = drawer
            };

            PushResponse response = Client.Push(category, todo);

            string retorno = JsonConvert.SerializeObject(response).ToString();
        }

        private void button28_Click(object sender, EventArgs e)
        {


            FirebaseResponse response = Client.Get(textBox1.Text);

            if (response != null)
            {
                response = null;
            }



            /*
            string retorno = new string { StatusCode = response.StatusCode.ToString(), Body = response.Body };
            retorno.StatusCode = response.StatusCode.ToString();
            retorno.Body = response.Body;
            return retorno;
            */
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
