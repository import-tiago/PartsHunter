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
using System.ComponentModel;

namespace PartsHunter
{
    public partial class Form1 : Form
    {
        bool Form_Closing = false;
        string Selected_Drawer = "0";

        const int SEARCH = 0;
        const int REGISTER = 1;

        dynamic JSON_Firebase;
        dynamic JSON_UART;

        string String_UART;

        bool Get_Number_Boxes_Okay = false;
        int Number_Boxes = 0;
        int Last_Selected_Registered_Box = 0;
        int Current_Selected_Registered_Box = 0;
        bool Pre_Load_Done = false;
        string Last_Draw_Highlight = "0";
        string Current_Button_Click = String.Empty;
        string Last_Button_Click = String.Empty;

        dynamic[] Last_Button_Properties = {"", Color.Transparent};

        bool validatedCategory;
        bool validatedDescription;
        bool validatedQuantity;

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
                    Get_Number_Registered_Box();
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
                    Highlight_Selected_Drawer("0", SEARCH, Color.WhiteSmoke);
                    Highlight_Selected_Drawer("0", REGISTER, Color.WhiteSmoke);
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


        void Highlight_Selected_Drawer(string number, int action, Color color)
        {
            
            if (action == SEARCH)
            {
                btnDrawer_1.BackColor = Color.WhiteSmoke;
                btnDrawer_2.BackColor = Color.WhiteSmoke;
                btnDrawer_3.BackColor = Color.WhiteSmoke;
                btnDrawer_4.BackColor = Color.WhiteSmoke;
                btnDrawer_5.BackColor = Color.WhiteSmoke;
                btnDrawer_6.BackColor = Color.WhiteSmoke;
                btnDrawer_7.BackColor = Color.WhiteSmoke;
                btnDrawer_8.BackColor = Color.WhiteSmoke;
                btnDrawer_9.BackColor = Color.WhiteSmoke;
                btnDrawer_10.BackColor = Color.WhiteSmoke;
                btnDrawer_11.BackColor = Color.WhiteSmoke;
                btnDrawer_12.BackColor = Color.WhiteSmoke;
                btnDrawer_13.BackColor = Color.WhiteSmoke;
                btnDrawer_14.BackColor = Color.WhiteSmoke;
                btnDrawer_15.BackColor = Color.WhiteSmoke;
                btnDrawer_16.BackColor = Color.WhiteSmoke;
                btnDrawer_17.BackColor = Color.WhiteSmoke;
                btnDrawer_18.BackColor = Color.WhiteSmoke;
                btnDrawer_19.BackColor = Color.WhiteSmoke;
                btnDrawer_20.BackColor = Color.WhiteSmoke;
                btnDrawer_21.BackColor = Color.WhiteSmoke;
                btnDrawer_22.BackColor = Color.WhiteSmoke;
                btnDrawer_23.BackColor = Color.WhiteSmoke;
                btnDrawer_24.BackColor = Color.WhiteSmoke;

                switch (number)
                {
                    case "1": btnDrawer_1.BackColor = color; break;
                    case "2": btnDrawer_2.BackColor = color; break;
                    case "3": btnDrawer_3.BackColor = color; break;
                    case "4": btnDrawer_4.BackColor = color; break;
                    case "5": btnDrawer_5.BackColor = color; break;
                    case "6": btnDrawer_6.BackColor = color; break;
                    case "7": btnDrawer_7.BackColor = color; break;
                    case "8": btnDrawer_8.BackColor = color; break;
                    case "9": btnDrawer_9.BackColor = color; break;
                    case "10": btnDrawer_10.BackColor = color; break;
                    case "11": btnDrawer_11.BackColor = color; break;
                    case "12": btnDrawer_12.BackColor = color; break;
                    case "13": btnDrawer_13.BackColor = color; break;
                    case "14": btnDrawer_14.BackColor = color; break;
                    case "15": btnDrawer_15.BackColor = color; break;
                    case "16": btnDrawer_16.BackColor = color; break;
                    case "17": btnDrawer_17.BackColor = color; break;
                    case "18": btnDrawer_18.BackColor = color; break;
                    case "19": btnDrawer_19.BackColor = color; break;
                    case "20": btnDrawer_20.BackColor = color; break;
                    case "21": btnDrawer_21.BackColor = color; break;
                    case "22": btnDrawer_22.BackColor = color; break;
                    case "23": btnDrawer_23.BackColor = color; break;
                    case "24": btnDrawer_24.BackColor = color; break;
                }
            }
            else if (action == REGISTER)
            {
                Selected_Drawer = number;

                switch (number)
                {
                    case "1": btnSelected_Drawer_1.BackColor = color; break;
                    case "2": btnSelected_Drawer_2.BackColor = color; break;
                    case "3": btnSelected_Drawer_3.BackColor = color; break;
                    case "4": btnSelected_Drawer_4.BackColor = color; break;
                    case "5": btnSelected_Drawer_5.BackColor = color; break;
                    case "6": btnSelected_Drawer_6.BackColor = color; break;
                    case "7": btnSelected_Drawer_7.BackColor = color; break;
                    case "8": btnSelected_Drawer_8.BackColor = color; break;
                    case "9": btnSelected_Drawer_9.BackColor = color; break;
                    case "10": btnSelected_Drawer_10.BackColor = color; break;
                    case "11": btnSelected_Drawer_11.BackColor = color; break;
                    case "12": btnSelected_Drawer_12.BackColor = color; break;
                    case "13": btnSelected_Drawer_13.BackColor = color; break;
                    case "14": btnSelected_Drawer_14.BackColor = color; break;
                    case "15": btnSelected_Drawer_15.BackColor = color; break;
                    case "16": btnSelected_Drawer_16.BackColor = color; break;
                    case "17": btnSelected_Drawer_17.BackColor = color; break;
                    case "18": btnSelected_Drawer_18.BackColor = color; break;
                    case "19": btnSelected_Drawer_19.BackColor = color; break;
                    case "20": btnSelected_Drawer_20.BackColor = color; break;
                    case "21": btnSelected_Drawer_21.BackColor = color; break;
                    case "22": btnSelected_Drawer_22.BackColor = color; break;
                    case "23": btnSelected_Drawer_23.BackColor = color; break;
                    case "24": btnSelected_Drawer_24.BackColor = color; break;
                }
            }
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
            else
            {
                if (tabControl1.SelectedIndex == 1 && !Pre_Load_Done)
                {
                    Pre_Load_Done = true;
                    Fill_All_Fields_With_Firebase_Data();
                }
            }
        }
  
        private void Form1_Load(object sender, EventArgs e)
        {
            labelNumberResults.Visible = false;
            comboBoxSearchCategory.Text = comboBoxSearchCategory.Items[0].ToString();
            comboBoxCategory.Text = comboBoxCategory.Items[0].ToString();
            SerialPort.PortName = "COM5";
            SerialPort.Open();
            btCOMConnect.BackColor = Color.LightCoral;
            btCOMConnect.Text = "Disconnect";
            comboBox1.Enabled = false;

            //Get_Number_Registered_Box();
            GetFirebase(String.Empty);    
            
            foreach (var key in JSON_Firebase.Keys)
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

            string String_Firebase = response.Body;

             JSON_Firebase = serializer.DeserializeObject(String_Firebase);

            if (JSON_Firebase == null)
                JSON_Firebase = JSON_Firebase = serializer.DeserializeObject("{void:0}");
        }

        void SearchByCategory()
        {
            string[] newRow;
            GetFirebase(comboBoxSearchCategory.Text.ToUpper());
            dataGridViewResults.AllowUserToAddRows = true;
            dataGridViewResults.Rows.Clear();           
            
            foreach (var key in JSON_Firebase.Keys)
            {
                if (key != "void")
                {
                    int numberResults = JSON_Firebase.Keys.Count;
                    labelNumberResults.Text = numberResults.ToString() + " results found";

                    foreach (DataGridViewRow row in dataGridViewResults.Rows)
                    {
                        newRow = new string[] { JSON_Firebase[key]["Description"], JSON_Firebase[key]["Quantity"], JSON_Firebase[key]["Box"], JSON_Firebase[key]["Drawer"] };
                           
                        if (row.Cells[0].Value != JSON_Firebase[key]["Description"])
                        {
                            dataGridViewResults.Rows.Add(newRow);
                            break;
                        }
                    }
                }
                else
                {
                    Send_UART("0");
                    Highlight_Selected_Drawer("0", SEARCH, Color.WhiteSmoke);
                    Highlight_Selected_Drawer("0", REGISTER, Color.WhiteSmoke);
                    labelNumberResults.Text = "0" + " results found";
                }
            }
            dataGridViewResults.AllowUserToAddRows = false;
        }

        void SearchByDescription(string input)
        {
            string[] newRow;
            int numberResults = 0;
            GetFirebase("");
            
            
            dataGridViewResults.AllowUserToAddRows = true;
            
            
            dataGridViewResults.Rows.Clear();

            foreach (var key in JSON_Firebase.Keys)
            {
                if (key != "void")
                {
                    foreach (var key2 in JSON_Firebase[key].Keys)
                    {
                        string s = JSON_Firebase[key][key2]["Description"].ToString();

                        string[] words = input.Split(' ');



                        foreach (var w in words)
                        {

                            if (s.Contains(w))
                            {
                                foreach (DataGridViewRow row in dataGridViewResults.Rows)
                                {
                                    newRow = new string[] { JSON_Firebase[key][key2]["Description"], JSON_Firebase[key][key2]["Quantity"], JSON_Firebase[key][key2]["Box"], JSON_Firebase[key][key2]["Drawer"] };

                                    if (row.Cells[0].Value != JSON_Firebase[key][key2]["Description"])
                                    {
                                        dataGridViewResults.Rows.Add(newRow);
                                        numberResults++;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                //labelNumberResults.Text = "0" + " results found";
                            }
                        }
                    }
                }
                else
                {
                    Send_UART("0");
                    Highlight_Selected_Drawer("0", SEARCH, Color.WhiteSmoke);
                    Highlight_Selected_Drawer("0", REGISTER, Color.WhiteSmoke);
                    labelNumberResults.Text = "0" + " results found";
                }                
            }
            dataGridViewResults.AllowUserToAddRows = false;
            labelNumberResults.Text = numberResults.ToString() + " results found";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {            
            SearchByDescription(textBoxSearch.Text.ToUpper());
            labelNumberResults.Visible = true;
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
                    Highlight_Selected_Drawer(y.ToString(), tabControl1.SelectedIndex, Color.LightGreen);
            }
            catch
            {
                
            }
        }

        private void buttonListAll_Click(object sender, EventArgs e)
        {

            if (comboBoxSearchCategory.SelectedIndex != 0)
            {
                SearchByCategory();
                labelNumberResults.Visible = true;
            }
            else
                MessageBox.Show("Select a category");

        }


        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String_UART = SerialPort.ReadExisting();              //le o dado disponível na serial
            this.Invoke(new EventHandler(trataDadoRecebido));   //chama outra thread para escrever o dado no text box
        }

        private void trataDadoRecebido(object sender, EventArgs e)
        {
            string s = "";
            try
            {
                string stringJson = String_UART.Substring(String_UART.IndexOf("{"), 50);
                stringJson = stringJson.Substring(0, stringJson.IndexOf("}")+1);
                JSON_UART = serializer.DeserializeObject(stringJson);
                 s = JSON_UART["Number Boxes"];

                if (int.Parse(s) > 0)
                {
                    Number_Boxes = int.Parse(s);
                    Send_UART("OK\r\n");
                    Send_UART("OK\r\n");
                    Send_UART("OK\r\n");
                    Send_UART("OK\r\n");
                    Send_UART("OK\r\n");
                    Send_UART("OK\r\n");
                    Get_Number_Boxes_Okay = true;
                }
                else
                {
                    if (Get_Number_Boxes_Okay == false)
                        Get_Number_Registered_Box();
                }
            }
            catch
            {

            }

         
        }

        void Get_Number_Registered_Box()
        {
            Send_UART("BOX?\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Number_Boxes
            FindRegisteredComponent(textBoxDescription.Text);
        }

        void FindRegisteredComponent(string input)
        {
            string[] newRow;
            int numberResults = 0;
            GetFirebase("");

            dataGridViewResults.AllowUserToAddRows = true;

            dataGridViewResults.Rows.Clear();

            foreach (var key in JSON_Firebase.Keys)
            {
                if (key != "void")
                {
                    foreach (var key2 in JSON_Firebase[key].Keys)
                    {
                        string s = JSON_Firebase[key][key2]["Description"].ToString();

                        string[] words = input.Split(' ');



                        foreach (var w in words)
                        {

                            if (s.Contains(w))
                            {
                                foreach (DataGridViewRow row in dataGridViewResults.Rows)
                                {
                                    newRow = new string[] { JSON_Firebase[key][key2]["Description"], JSON_Firebase[key][key2]["Quantity"], JSON_Firebase[key][key2]["Box"], JSON_Firebase[key][key2]["Drawer"] };

                                    if (row.Cells[0].Value != JSON_Firebase[key][key2]["Description"])
                                    {
                                        dataGridViewResults.Rows.Add(newRow);
                                        numberResults++;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                //labelNumberResults.Text = "0" + " results found";
                            }
                        }
                    }
                }
                else
                {
                    Send_UART("0");
                    Highlight_Selected_Drawer("0", SEARCH, Color.WhiteSmoke);
                    Highlight_Selected_Drawer("0", REGISTER, Color.WhiteSmoke);
                    labelNumberResults.Text = "0" + " results found";
                }
            }
            dataGridViewResults.AllowUserToAddRows = false;
            labelNumberResults.Text = numberResults.ToString() + " results found";
        }

        void Fill_Boxes_Datagrid()
        {
            string[] newRow;
            string value = string.Empty;

            dataGridViewBoxes.Rows.Clear();
            dataGridViewBoxes.AllowUserToAddRows = true;

            foreach (var key in JSON_Firebase.Keys)
            {
                if (key != "void")
                {
                    foreach (var key2 in JSON_Firebase[key].Keys)
                    {
                        if (int.Parse(JSON_Firebase[key][key2]["Box"]) <= 9)
                            value = "0" + JSON_Firebase[key][key2]["Box"];
                        else
                            value = JSON_Firebase[key][key2]["Box"].toString();

                        newRow = new string[] { "BOX " + value };

                        foreach (DataGridViewRow existingRow in dataGridViewBoxes.Rows) {
                            if (newRow != existingRow.Cells[0].Value)
                            {
                                dataGridViewBoxes.Rows.Add(newRow);
                                break;
                            }
                        
                            
                    }
                    }
                }
            }
            
            dataGridViewBoxes.Sort(dataGridViewBoxes.Columns[0], ListSortDirection.Ascending);
            dataGridViewBoxes.AllowUserToAddRows = false;
        }
        void Fill_Parts_Datagrid()
        {

        }




        void Fill_All_Fields_With_Firebase_Data()
        {
            //string[] newRow;
            //int numberResults = 0;

            Fill_Boxes_Datagrid();
            Fill_Parts_Datagrid();

            /*
            string y = dataGridViewBoxes.SelectedCells[0].Value.ToString();
            string Current_Selected_Box = y.Substring(y.IndexOf(" ") + 1);

            if (Current_Selected_Registered_Box != Last_Selected_Registered_Box)
                Last_Selected_Registered_Box = dataGridViewBoxes.SelectedRows[0].Index;

            dataGridViewBoxes.AllowUserToAddRows = true;
            dataGridViewCurrentParts.AllowUserToAddRows = true;

            dataGridViewBoxes.Rows.Clear();
            dataGridViewCurrentParts.Rows.Clear();

            Clear_Highlight_All_Boxes();

            foreach (var key in JSON_Firebase.Keys)
            {
                if (key != "void")
                {
                    foreach (var key2 in JSON_Firebase[key].Keys)
                    {
                        if (JSON_Firebase[key][key2]["Box"] == Current_Selected_Box)
                        {
                            newRow = new string[] { JSON_Firebase[key][key2]["Description"], JSON_Firebase[key][key2]["Quantity"] };
                            dataGridViewCurrentParts.Rows.Add(newRow);
                            numberResults++;

                            // Highlight_Selected_Drawer(JSON_Firebase[key][key2]["Drawer"], REGISTER);
                        }
                    }
                }
                else
                {
                    Send_UART("0");
                    Highlight_Selected_Drawer("0", SEARCH, Color.WhiteSmoke);
                    Highlight_Selected_Drawer("0", REGISTER, Color.WhiteSmoke);
                    labelNumberResults.Text = "0" + " results found";
                }
            }

            if (numberResults == 1)
            {
                Last_Draw_Highlight = String.Empty;
            }

            dataGridViewCurrentParts.AllowUserToAddRows = false;
            labelNumberResults.Text = numberResults.ToString() + " results found";

            Last_Selected_Registered_Box = dataGridViewBoxes.SelectedRows[0].Index;
            */
        }

       


        void Highlight_Drawer_From_Box_Selection()
        {
            string Current_Selected_Box="0";//////////////////////////////////////////////////////////////////////////REMOVE
            foreach (var key in JSON_Firebase.Keys)
            {
                foreach (var key2 in JSON_Firebase[key].Keys)
                {
                    if (JSON_Firebase[key][key2]["Box"] == Current_Selected_Box)
                    {
                        switch (JSON_Firebase[key][key2]["Drawer"])
                        {
                            case "1": if (btnSelected_Drawer_1.BackColor != Color.LightGreen) btnSelected_Drawer_1.BackColor = Color.LemonChiffon; break;
                            case "2": if (btnSelected_Drawer_2.BackColor != Color.LightGreen) btnSelected_Drawer_2.BackColor = Color.LemonChiffon; break;
                            case "3": if (btnSelected_Drawer_3.BackColor != Color.LightGreen) btnSelected_Drawer_3.BackColor = Color.LemonChiffon; break;
                            case "4": if (btnSelected_Drawer_4.BackColor != Color.LightGreen) btnSelected_Drawer_4.BackColor = Color.LemonChiffon; break;
                            case "5": if (btnSelected_Drawer_5.BackColor != Color.LightGreen) btnSelected_Drawer_5.BackColor = Color.LemonChiffon; break;
                            case "6": if (btnSelected_Drawer_6.BackColor != Color.LightGreen) btnSelected_Drawer_6.BackColor = Color.LemonChiffon; break;
                            case "7": if (btnSelected_Drawer_7.BackColor != Color.LightGreen) btnSelected_Drawer_7.BackColor = Color.LemonChiffon; break;
                            case "8": if (btnSelected_Drawer_8.BackColor != Color.LightGreen) btnSelected_Drawer_8.BackColor = Color.LemonChiffon; break;
                            case "9": if (btnSelected_Drawer_9.BackColor != Color.LightGreen) btnSelected_Drawer_9.BackColor = Color.LemonChiffon; break;
                            case "10": if (btnSelected_Drawer_10.BackColor != Color.LightGreen) btnSelected_Drawer_10.BackColor = Color.LemonChiffon; break;
                            case "11": if (btnSelected_Drawer_11.BackColor != Color.LightGreen) btnSelected_Drawer_11.BackColor = Color.LemonChiffon; break;
                            case "12": if (btnSelected_Drawer_12.BackColor != Color.LightGreen) btnSelected_Drawer_12.BackColor = Color.LemonChiffon; break;
                            case "13": if (btnSelected_Drawer_13.BackColor != Color.LightGreen) btnSelected_Drawer_13.BackColor = Color.LemonChiffon; break;
                            case "14": if (btnSelected_Drawer_14.BackColor != Color.LightGreen) btnSelected_Drawer_14.BackColor = Color.LemonChiffon; break;
                            case "15": if (btnSelected_Drawer_15.BackColor != Color.LightGreen) btnSelected_Drawer_15.BackColor = Color.LemonChiffon; break;
                            case "16": if (btnSelected_Drawer_16.BackColor != Color.LightGreen) btnSelected_Drawer_16.BackColor = Color.LemonChiffon; break;
                            case "17": if (btnSelected_Drawer_17.BackColor != Color.LightGreen) btnSelected_Drawer_17.BackColor = Color.LemonChiffon; break;
                            case "18": if (btnSelected_Drawer_18.BackColor != Color.LightGreen) btnSelected_Drawer_18.BackColor = Color.LemonChiffon; break;
                            case "19": if (btnSelected_Drawer_19.BackColor != Color.LightGreen) btnSelected_Drawer_19.BackColor = Color.LemonChiffon; break;
                            case "20": if (btnSelected_Drawer_20.BackColor != Color.LightGreen) btnSelected_Drawer_20.BackColor = Color.LemonChiffon; break;
                            case "21": if (btnSelected_Drawer_21.BackColor != Color.LightGreen) btnSelected_Drawer_21.BackColor = Color.LemonChiffon; break;
                            case "22": if (btnSelected_Drawer_22.BackColor != Color.LightGreen) btnSelected_Drawer_22.BackColor = Color.LemonChiffon; break;
                            case "23": if (btnSelected_Drawer_23.BackColor != Color.LightGreen) btnSelected_Drawer_23.BackColor = Color.LemonChiffon; break;
                            case "24": if (btnSelected_Drawer_24.BackColor != Color.LightGreen) btnSelected_Drawer_24.BackColor = Color.LemonChiffon; break;
                        }

                    }
                }
            }
        }
        void Highlight_Drawer_From_Parts_Selection()
        {
            string Current_Selected_Component = String.Empty;

            if (dataGridViewCurrentParts.SelectedCells.Count > 0)
            {
                Current_Selected_Component = dataGridViewCurrentParts.SelectedCells[0].Value.ToString();


                if (Last_Selected_Registered_Box != dataGridViewBoxes.SelectedRows[0].Index)
                    Last_Draw_Highlight = String.Empty;

            }

            foreach (var key in JSON_Firebase.Keys)
            {
                if (key != "void")
                {
                    foreach (var key2 in JSON_Firebase[key].Keys)
                    {
                        if (JSON_Firebase[key][key2]["Description"] == Current_Selected_Component)
                        {

                            switch (Last_Draw_Highlight)
                            {
                                case "1": btnSelected_Drawer_1.BackColor = Color.LemonChiffon; break;
                                case "2": btnSelected_Drawer_2.BackColor = Color.LemonChiffon; break;
                                case "3": btnSelected_Drawer_3.BackColor = Color.LemonChiffon; break;
                                case "4": btnSelected_Drawer_4.BackColor = Color.LemonChiffon; break;
                                case "5": btnSelected_Drawer_5.BackColor = Color.LemonChiffon; break;
                                case "6": btnSelected_Drawer_6.BackColor = Color.LemonChiffon; break;
                                case "7": btnSelected_Drawer_7.BackColor = Color.LemonChiffon; break;
                                case "8": btnSelected_Drawer_8.BackColor = Color.LemonChiffon; break;
                                case "9": btnSelected_Drawer_9.BackColor = Color.LemonChiffon; break;
                                case "10": btnSelected_Drawer_10.BackColor = Color.LemonChiffon; break;
                                case "11": btnSelected_Drawer_11.BackColor = Color.LemonChiffon; break;
                                case "12": btnSelected_Drawer_12.BackColor = Color.LemonChiffon; break;
                                case "13": btnSelected_Drawer_13.BackColor = Color.LemonChiffon; break;
                                case "14": btnSelected_Drawer_14.BackColor = Color.LemonChiffon; break;
                                case "15": btnSelected_Drawer_15.BackColor = Color.LemonChiffon; break;
                                case "16": btnSelected_Drawer_16.BackColor = Color.LemonChiffon; break;
                                case "17": btnSelected_Drawer_17.BackColor = Color.LemonChiffon; break;
                                case "18": btnSelected_Drawer_18.BackColor = Color.LemonChiffon; break;
                                case "19": btnSelected_Drawer_19.BackColor = Color.LemonChiffon; break;
                                case "20": btnSelected_Drawer_20.BackColor = Color.LemonChiffon; break;
                                case "21": btnSelected_Drawer_21.BackColor = Color.LemonChiffon; break;
                                case "22": btnSelected_Drawer_22.BackColor = Color.LemonChiffon; break;
                                case "23": btnSelected_Drawer_23.BackColor = Color.LemonChiffon; break;
                                case "24": btnSelected_Drawer_24.BackColor = Color.LemonChiffon; break;
                            }

                            var _t = JSON_Firebase[key][key2]["Drawer"];

                            Highlight_Selected_Drawer(JSON_Firebase[key][key2]["Drawer"], REGISTER, Color.LightGreen);
                            Last_Draw_Highlight = JSON_Firebase[key][key2]["Drawer"];



                        }
                    }
                }
            }
        }     
        void Clear_Highlight_All_Boxes()
        {
            btnSelected_Drawer_1.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_2.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_3.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_4.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_5.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_6.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_7.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_8.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_9.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_10.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_11.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_12.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_13.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_14.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_15.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_16.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_17.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_18.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_19.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_20.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_21.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_22.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_23.BackColor = Color.WhiteSmoke;
            btnSelected_Drawer_24.BackColor = Color.WhiteSmoke;
        }


        private void dataGridViewBoxes_SelectionChanged(object sender, EventArgs e)
        {
            Highlight_Drawer_From_Box_Selection();
        }
        private void dataGridViewCurrentContent_SelectionChanged(object sender, EventArgs e)
        {
            Highlight_Drawer_From_Parts_Selection();
        }

        private void Get_Button_Click(object sender, EventArgs e)
        {
           
            
            if (Last_Button_Properties[0] != (sender as Button).Text && Last_Button_Properties[0] != String.Empty)
                Highlight_Selected_Drawer(Last_Button_Properties[0], tabControl1.SelectedIndex, Last_Button_Properties[1]);
            Last_Button_Properties[1] = (sender as Button).BackColor;

            Highlight_Selected_Drawer((sender as Button).Text, tabControl1.SelectedIndex, Color.LightCoral);
            
          

            Last_Button_Properties[0] = (sender as Button).Text;
        }

        private void buttonNewBox_Click(object sender, EventArgs e)
        {
            string[] newRow;
            
            dataGridViewBoxes.AllowUserToAddRows = true;

            int newBox = dataGridViewBoxes.RowCount;
          
            newRow = new string[] { "BOX " + newBox };

            dataGridViewBoxes.Rows.Add(newRow);
           
            dataGridViewBoxes.AllowUserToAddRows = false;

        }

        private void comboBoxCategory_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxCategory.Text) || comboBoxCategory.Text == comboBoxCategory.Items[0].ToString())
            {               
                validatedCategory = false;
                errorProvider1.SetError(comboBoxCategory, "should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                validatedCategory = true;
                errorProvider1.SetError(comboBoxCategory, "");
            }
        }

        private void textBoxDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDescription.Text))
            {              
                validatedDescription = false;
                errorProvider1.SetError(textBoxDescription, "should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                validatedDescription = true;
                errorProvider1.SetError(textBoxDescription, "");
            }
        }

        private void textBoxQuantity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxQuantity.Text))
            {              
                validatedQuantity = false;
                errorProvider1.SetError(textBoxQuantity, "should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                validatedQuantity = true;
                errorProvider1.SetError(textBoxQuantity, "");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (validatedCategory && validatedDescription && validatedQuantity)
            {
                int index = dataGridViewBoxes.SelectedCells[0].RowIndex;
                
                string drawer = Last_Button_Properties[0];                
                string box = dataGridViewBoxes.Rows[index].Cells[0].Value.ToString();
                
                string category = comboBoxCategory.Text.ToUpper();
                string description = textBoxDescription.Text.ToUpper();
                string quantity = textBoxQuantity.Text.ToUpper();
                drawer = drawer.ToUpper();
                box = box.ToUpper();

                Push_New_Component(category, description, quantity, box, drawer);                
            }
            else
                MessageBox.Show("Fill all fields");
        }

      
    }
}
