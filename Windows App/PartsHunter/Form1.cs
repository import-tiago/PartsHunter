using System;
using System.Drawing;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System.IO.Ports;

using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace PartsHunter
{
    public partial class Form1 : Form
    {
        bool Form_Closing = false;
        string Selected_Drawer = "0";

        const int SEARCH = 0;
        const int REGISTER = 1;

        dynamic decodedJSON;

        JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

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

            timerCOM.Enabled = true;            
        }

        private void timerCOM_Tick_1(object sender, EventArgs e)
        {
            atualizaListaCOMs();
        }

        private void atualizaListaCOMs()
        {
            int i;
            bool quantDiferente;    //flag para sinalizar que a quantidade de portas mudou

            i = 0;
            quantDiferente = false;

            //se a quantidade de portas mudou
            if (comboBox1.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (comboBox1.Items[i++].Equals(s) == false)
                    {
                        quantDiferente = true;
                    }
                }
            }
            else
            {
                quantDiferente = true;
            }

            //Se não foi detectado diferença
            if (quantDiferente == false)
            {
                return;                     //retorna
            }

            //limpa comboBox
            comboBox1.Items.Clear();

            //adiciona todas as COM diponíveis na lista
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }
            //seleciona a primeira posição da lista
            comboBox1.SelectedIndex = 0;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = Client.Get(textBoxSearch.Text);

            if (response != null)
            {
                response = null;
            }
        }

        private void btConectar_Click(object sender, EventArgs e)
        {
            if (SerialPort.IsOpen == false)
            {
                try
                {
                    SerialPort.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    SerialPort.Open();

                }
                catch
                {
                    return;

                }
                if (SerialPort.IsOpen)
                {
                    btCOMConnect.BackColor = Color.LightCoral;
                    btCOMConnect.Text = "Disconnect";
                    comboBox1.Enabled = false;                    
                }
            }
            else
            {

                try
                {
                    Send_UART("0");
                    Highlight_Selected_Drawer("0", SEARCH);
                    Highlight_Selected_Drawer("0", REGISTER);
                    SerialPort.Close();
                    comboBox1.Enabled = true;
                    btCOMConnect.BackColor = Color.LightGreen;
                    btCOMConnect.Text = "Connect";
                    
                }
                catch
                {
                    return;
                }

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Closing = true;

            Send_UART("0");

            if (SerialPort.IsOpen == true)
                SerialPort.Close();
        }

        private void btnDrawer_1_Click(object sender, EventArgs e)
        {
            if(Send_UART(btnDrawer_1.Text))
                Highlight_Selected_Drawer(btnDrawer_1.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_2_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_2.Text))
                Highlight_Selected_Drawer(btnDrawer_2.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_3_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_3.Text))
                Highlight_Selected_Drawer(btnDrawer_3.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_4_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_4.Text))
                Highlight_Selected_Drawer(btnDrawer_4.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_5_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_5.Text))
                Highlight_Selected_Drawer(btnDrawer_5.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_6_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_6.Text))
                Highlight_Selected_Drawer(btnDrawer_6.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_7_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_7.Text))
                Highlight_Selected_Drawer(btnDrawer_7.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_8_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_8.Text))
                Highlight_Selected_Drawer(btnDrawer_8.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_9_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_9.Text))
                Highlight_Selected_Drawer(btnDrawer_9.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_10_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_10.Text))
                Highlight_Selected_Drawer(btnDrawer_10.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_11_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_11.Text))
                Highlight_Selected_Drawer(btnDrawer_11.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_12_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_12.Text))
                Highlight_Selected_Drawer(btnDrawer_12.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_13_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_13.Text))
                Highlight_Selected_Drawer(btnDrawer_13.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_14_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_14.Text))
                Highlight_Selected_Drawer(btnDrawer_14.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_15_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_15.Text))
                Highlight_Selected_Drawer(btnDrawer_15.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_16_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_16.Text))
                Highlight_Selected_Drawer(btnDrawer_16.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_17_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_17.Text))
                Highlight_Selected_Drawer(btnDrawer_17.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_18_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_18.Text))
                Highlight_Selected_Drawer(btnDrawer_18.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_19_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_19.Text))
                Highlight_Selected_Drawer(btnDrawer_19.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_20_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_20.Text))
                Highlight_Selected_Drawer(btnDrawer_20.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_21_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_21.Text))
                Highlight_Selected_Drawer(btnDrawer_21.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_22_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_22.Text))
                Highlight_Selected_Drawer(btnDrawer_22.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_23_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_23.Text))
                Highlight_Selected_Drawer(btnDrawer_23.Text, tabControl1.SelectedIndex);
        }

        private void btnDrawer_24_Click(object sender, EventArgs e)
        {
            if (Send_UART(btnDrawer_24.Text))
            Highlight_Selected_Drawer(btnDrawer_24.Text, tabControl1.SelectedIndex);
        }

        private bool Send_UART(string number)
        {
            bool r;
            if (SerialPort.IsOpen == true)
            {
                SerialPort.Write(number);
                r = true;
            }
            else
            {
                if (Form_Closing == false)
                    MessageBox.Show("Connect first...");
                r = false;
            }

            return r;
        }


        void Highlight_Selected_Drawer(string number, int action)
        {
            
            if (action == SEARCH)
            {
                btnDrawer_1.BackColor = Color.Azure;
                btnDrawer_2.BackColor = Color.Azure;
                btnDrawer_3.BackColor = Color.Azure;
                btnDrawer_4.BackColor = Color.Azure;
                btnDrawer_5.BackColor = Color.Azure;
                btnDrawer_6.BackColor = Color.Azure;
                btnDrawer_7.BackColor = Color.Azure;
                btnDrawer_8.BackColor = Color.Azure;
                btnDrawer_9.BackColor = Color.Azure;
                btnDrawer_10.BackColor = Color.Azure;
                btnDrawer_11.BackColor = Color.Azure;
                btnDrawer_12.BackColor = Color.Azure;
                btnDrawer_13.BackColor = Color.Azure;
                btnDrawer_14.BackColor = Color.Azure;
                btnDrawer_15.BackColor = Color.Azure;
                btnDrawer_16.BackColor = Color.Azure;
                btnDrawer_17.BackColor = Color.Azure;
                btnDrawer_18.BackColor = Color.Azure;
                btnDrawer_19.BackColor = Color.Azure;
                btnDrawer_20.BackColor = Color.Azure;
                btnDrawer_21.BackColor = Color.Azure;
                btnDrawer_22.BackColor = Color.Azure;
                btnDrawer_23.BackColor = Color.Azure;
                btnDrawer_24.BackColor = Color.Azure;

                switch (number)
                {
                    case "1": btnDrawer_1.BackColor = Color.LightGreen; break;
                    case "2": btnDrawer_2.BackColor = Color.LightGreen; break;
                    case "3": btnDrawer_3.BackColor = Color.LightGreen; break;
                    case "4": btnDrawer_4.BackColor = Color.LightGreen; break;
                    case "5": btnDrawer_5.BackColor = Color.LightGreen; break;
                    case "6": btnDrawer_6.BackColor = Color.LightGreen; break;
                    case "7": btnDrawer_7.BackColor = Color.LightGreen; break;
                    case "8": btnDrawer_8.BackColor = Color.LightGreen; break;
                    case "9": btnDrawer_9.BackColor = Color.LightGreen; break;
                    case "10": btnDrawer_10.BackColor = Color.LightGreen; break;
                    case "11": btnDrawer_11.BackColor = Color.LightGreen; break;
                    case "12": btnDrawer_12.BackColor = Color.LightGreen; break;
                    case "13": btnDrawer_13.BackColor = Color.LightGreen; break;
                    case "14": btnDrawer_14.BackColor = Color.LightGreen; break;
                    case "15": btnDrawer_15.BackColor = Color.LightGreen; break;
                    case "16": btnDrawer_16.BackColor = Color.LightGreen; break;
                    case "17": btnDrawer_17.BackColor = Color.LightGreen; break;
                    case "18": btnDrawer_18.BackColor = Color.LightGreen; break;
                    case "19": btnDrawer_19.BackColor = Color.LightGreen; break;
                    case "20": btnDrawer_20.BackColor = Color.LightGreen; break;
                    case "21": btnDrawer_21.BackColor = Color.LightGreen; break;
                    case "22": btnDrawer_22.BackColor = Color.LightGreen; break;
                    case "23": btnDrawer_23.BackColor = Color.LightGreen; break;
                    case "24": btnDrawer_24.BackColor = Color.LightGreen; break;
                }
            }
            else if (action == REGISTER)
            {
                Selected_Drawer = number;

                btnSelected_Drawer_1.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_2.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_3.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_4.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_5.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_6.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_7.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_8.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_9.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_10.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_11.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_12.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_13.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_14.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_15.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_16.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_17.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_18.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_19.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_20.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_21.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_22.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_23.BackColor = Color.LemonChiffon;
                btnSelected_Drawer_24.BackColor = Color.LemonChiffon;

                switch (number)
                {
                    case "1": btnSelected_Drawer_1.BackColor = Color.LightCoral; break;
                    case "2": btnSelected_Drawer_2.BackColor = Color.LightCoral; break;
                    case "3": btnSelected_Drawer_3.BackColor = Color.LightCoral; break;
                    case "4": btnSelected_Drawer_4.BackColor = Color.LightCoral; break;
                    case "5": btnSelected_Drawer_5.BackColor = Color.LightCoral; break;
                    case "6": btnSelected_Drawer_6.BackColor = Color.LightCoral; break;
                    case "7": btnSelected_Drawer_7.BackColor = Color.LightCoral; break;
                    case "8": btnSelected_Drawer_8.BackColor = Color.LightCoral; break;
                    case "9": btnSelected_Drawer_9.BackColor = Color.LightCoral; break;
                    case "10": btnSelected_Drawer_10.BackColor = Color.LightCoral; break;
                    case "11": btnSelected_Drawer_11.BackColor = Color.LightCoral; break;
                    case "12": btnSelected_Drawer_12.BackColor = Color.LightCoral; break;
                    case "13": btnSelected_Drawer_13.BackColor = Color.LightCoral; break;
                    case "14": btnSelected_Drawer_14.BackColor = Color.LightCoral; break;
                    case "15": btnSelected_Drawer_15.BackColor = Color.LightCoral; break;
                    case "16": btnSelected_Drawer_16.BackColor = Color.LightCoral; break;
                    case "17": btnSelected_Drawer_17.BackColor = Color.LightCoral; break;
                    case "18": btnSelected_Drawer_18.BackColor = Color.LightCoral; break;
                    case "19": btnSelected_Drawer_19.BackColor = Color.LightCoral; break;
                    case "20": btnSelected_Drawer_20.BackColor = Color.LightCoral; break;
                    case "21": btnSelected_Drawer_21.BackColor = Color.LightCoral; break;
                    case "22": btnSelected_Drawer_22.BackColor = Color.LightCoral; break;
                    case "23": btnSelected_Drawer_23.BackColor = Color.LightCoral; break;
                    case "24": btnSelected_Drawer_24.BackColor = Color.LightCoral; break;
                }
            }
        }

        private void btnSelected_Drawer_1_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_1.Text, tabControl1.SelectedIndex);

        }      

        private void btnSelected_Drawer_2_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_2.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_3_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_3.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_4_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_4.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_5_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_5.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_6_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_6.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_7_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_7.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_8_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_8.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_9_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_9.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_10_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_10.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_11_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_11.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_12_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_12.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_13_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_13.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_14_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_14.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_15_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_15.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_16_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_16.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_17_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_17.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_18_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_18.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_19_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_19.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_20_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_20.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_21_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_21.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_22_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_22.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_23_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_23.Text, tabControl1.SelectedIndex);
        }

        private void btnSelected_Drawer_24_Click(object sender, EventArgs e)
        {
            Highlight_Selected_Drawer(btnSelected_Drawer_24.Text, tabControl1.SelectedIndex);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SerialPort.IsOpen == false)
            {
                if(tabControl1.SelectedIndex > 0)
                    MessageBox.Show("Connect first...");
                tabControl1.SelectedIndex = 0;
                tabControl1.TabIndex= 0;
                
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Push_New_Component(comboBoxCategory.Text,
                               textBoxDescription.Text,
                               textBoxQuantity.Text,
                               textBoxNewBox.Text,
                               Selected_Drawer);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            comboBoxSearchCategory.Text = comboBoxSearchCategory.Items[0].ToString();

            SerialPort.PortName = "COM5";
            SerialPort.Open();
            btCOMConnect.BackColor = Color.LightCoral;
            btCOMConnect.Text = "Disconnect";
            comboBox1.Enabled = false;

            GetFirebase(String.Empty);            
            foreach (var key in decodedJSON.Keys)
            {
                comboBoxCategory.Items.Add(key);
                comboBoxSearchCategory.Items.Add(key);
            }
                    

        }

        void Push_New_Component(string category, string description, string quantity, string box, string drawer)
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

        void GetFirebase(string input)
        {            
            FirebaseResponse response = Client.Get(input);

            string stringJSON = response.Body;

             decodedJSON = serializer.DeserializeObject(stringJSON);
            if (decodedJSON == null)
                decodedJSON = decodedJSON = serializer.DeserializeObject("{void:0}");
        }

        void SearchByCategory()
        {
            string[] newRow;
            GetFirebase(comboBoxSearchCategory.Text);
            dataGridViewResults.AllowUserToAddRows = true;
            dataGridViewResults.Rows.Clear();           
            
            foreach (var key in decodedJSON.Keys)
            {
                if (key != "void")
                {
                    int numberResults = decodedJSON.Keys.Count;
                    labelNumberResults.Text = numberResults.ToString() + " results found";

                    foreach (DataGridViewRow row in dataGridViewResults.Rows)
                    {
                        newRow = new string[] { decodedJSON[key]["Description"], decodedJSON[key]["Quantity"], decodedJSON[key]["Box"], decodedJSON[key]["Drawer"] };
                           
                        if (row.Cells[0].Value != decodedJSON[key]["Description"])
                        {
                            dataGridViewResults.Rows.Add(newRow);
                            break;
                        }
                    }
                }
                else
                {
                    Send_UART("0");
                    Highlight_Selected_Drawer("0", SEARCH);
                    Highlight_Selected_Drawer("0", REGISTER);
                    labelNumberResults.Text = "0" + " results found";
                }
            }
            dataGridViewResults.AllowUserToAddRows = false;
        }

        void SearchByDescription(string input)
        {
            string[] newRow;
            GetFirebase("");
            
            
            dataGridViewResults.AllowUserToAddRows = true;
            
            
            dataGridViewResults.Rows.Clear();

            foreach (var key in decodedJSON.Keys)
            {
                if (key != "void")
                {
                    foreach (var key2 in decodedJSON[key].Keys)
                    {
                        string s = decodedJSON[key][key2]["Description"].ToString();

                        string[] words = input.Split(' ');



                        foreach (var w in words)
                        {

                            if (s.Contains(w))
                            {
                                foreach (DataGridViewRow row in dataGridViewResults.Rows)
                                {
                                    newRow = new string[] { decodedJSON[key][key2]["Description"], decodedJSON[key][key2]["Quantity"], decodedJSON[key][key2]["Box"], decodedJSON[key][key2]["Drawer"] };

                                    if (row.Cells[0].Value != decodedJSON[key][key2]["Description"])
                                    {
                                        dataGridViewResults.Rows.Add(newRow);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                labelNumberResults.Text = "0" + " results found";
                            }
                        }
                    }
                }
                else
                {
                    Send_UART("0");
                    Highlight_Selected_Drawer("0", SEARCH);
                    Highlight_Selected_Drawer("0", REGISTER);
                    labelNumberResults.Text = "0" + " results found";
                }                
            }
            dataGridViewResults.AllowUserToAddRows = false;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchByDescription(textBoxSearch.Text);
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchByCategory();
            }
        }


        private void dataGridViewResults_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                int x = dataGridViewResults.SelectedCells[0].RowIndex;


                var y = dataGridViewResults[3, x].Value.ToString();                

                if (Send_UART(y.ToString()))
                    Highlight_Selected_Drawer(y.ToString(), tabControl1.SelectedIndex);
            }
            catch
            {
                
            }
        }

        private void buttonListAll_Click(object sender, EventArgs e)
        {
            if(comboBoxSearchCategory.SelectedIndex != 0)
                SearchByCategory();
            else
                MessageBox.Show("Select a category");
        }
    }
}
