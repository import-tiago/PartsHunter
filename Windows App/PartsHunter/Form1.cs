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
using System.Configuration;
using System.Collections.Specialized;
using System.ComponentModel;

using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Globalization;
using System.Threading;
using SimpleWifi;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PartsHunter
{
    public partial class Form1 : Form
    {
        private bool Form_Closing = false;
        private string Selected_Drawer = "0";
        private const int SEARCH = 0;
        private const int REGISTER = 1;
        private const int CLEAR_ALL = 0;
        private const int CLEAR_KEEPING_FILLED_DRAWERS = 1;
        private dynamic JSON_Firebase;
        private dynamic JSON_UART;
        private string String_UART;
        private bool Get_Number_Boxes_Okay = false;
        private int Number_Boxes = 0;
        private int Last_Selected_Registered_Box = 0;        
        private bool Pre_Load_Done = false;
        private string Last_Draw_Highlight = "0";
        private string Current_Button_Click = String.Empty;
        private string Last_Button_Click = String.Empty;
        private dynamic[] Last_Button_Properties = { "", Color.Transparent };
        private bool validatedCategory;
        private bool validatedDescription;
        private bool validatedDrawer;
        private string Current_Selected_Box = string.Empty;
        private bool Manually_Manipulating_Datagrid = false;
        private Color LED_Highlight_Color;
        private int LED_Highlight_Time;
        private int LED_Highlight_Brightness;
        private CultureInfo culture = new CultureInfo("es-ES", false);
        private string Current_Category = String.Empty;

        private readonly NameValueCollection configuration = ConfigurationManager.AppSettings;
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();
        private readonly IFirebaseConfig Config = new FirebaseConfig();
        private readonly IFirebaseClient Client;
        private Wifi wifi;
        private List<AccessPoint> aps;

        private static ManualResetEvent sendDone =        new ManualResetEvent(false);

        ApplicationMethods _extern = new ApplicationMethods();

        public Form1()
        {
            InitializeComponent();

            Config.BasePath = configuration.Get("firebase_base");
            Config.AuthSecret = configuration.Get("firebase_auth");

            Client = new FireSharp.FirebaseClient(Config);
            if (Client == null)
            {
                MessageBox.Show("Error Connection");
            }

            timerCOM.Enabled = true;
        }

        private void timerCOM_Tick_1(object sender, EventArgs e)
        {
            Update_COM_List();
        }

        private void Update_COM_List()
        {
            int i;
            bool quantDiferente;

            i = 0;
            quantDiferente = false;
            
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
            
            if (quantDiferente == false)
            {
                return;
            }

            
            comboBox1.Items.Clear();
            
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }            
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
                    try
                    {
                        SerialPort.Open();
                    }
                    catch { MessageBox.Show("Error to open SerialPort"); }

                   // Get_Number_Registered_Box();
                }
                catch
                {
                    return;

                }
                if (SerialPort.IsOpen)
                {
                    Send_UART("-1");
                    btCOMConnect.BackColor = Color.LightCoral;
                    btCOMConnect.Text = "Disconnect";
                    comboBox1.Enabled = false;                   
                    buttonClear.Enabled = true;
                }
            }
            else
            {

                try
                {
                    Send_UART("-1");
                    //Highlight_Selected_Drawer("0", SEARCH, Color.WhiteSmoke);
                    //Highlight_Selected_Drawer("0", REGISTER, Color.WhiteSmoke);
                    SerialPort.Close();
                    comboBox1.Enabled = true;
                    btCOMConnect.BackColor = Color.LemonChiffon;
                    btCOMConnect.Text = "Connect";                   
                    buttonClear.Enabled = false;
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

            Send_UART("-1");
        

            if (SerialPort.IsOpen == true)
                SerialPort.Close();
        }

        private bool Send_UART(string command)
        {
            string UART_command = String.Empty;
            bool cancel = false;

            
            bool r = false;
            if (cancel == false)
            {
                
                if (SerialPort.IsOpen == true)
                {
                    //if (tabControl1.SelectedIndex == 1)
                       SerialPort.Write(command);
   

                    // else
                    //  SerialPort.Write(UART_command);

                    r = true;
                }
                else
                {
                    if (Form_Closing == false)
                        MessageBox.Show("Connect first...");
                    r = false;
                }
            }

            return r;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SerialPort.IsOpen)
            {
                if (Pre_Load_Done == false)
                {
                    Pre_Load_Done = true;
                    GetFirebase(String.Empty);


                    
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    Fill_All_Fields_With_Firebase_Data();
                }

                
                if (tabControl1.SelectedIndex == 0 && dataGridViewResults.CurrentRow == null)
                    Send_UART("-1");
                else if (tabControl1.SelectedIndex == 0 && dataGridViewResults.CurrentRow != null)
                {
                    Highligth_From_Results();
                }
            }
            else
            {
                if (tabControl1.SelectedIndex > 0)
                    MessageBox.Show("Connect first...");

                tabControl1.SelectedIndex = 0;
                tabControl1.TabIndex = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wifi = new Wifi();

            aps = wifi.GetAccessPoints();
            int milliseconds = 1000;
            Thread.Sleep(milliseconds);

            foreach (AccessPoint ap in aps)
            {
                comboBoxSSID.Items.Add(ap.Name.ToString());
            }

            LoadData();
            dataGridViewResults.Columns[0].Width = 280;
            dataGridViewRegisteredParts.Columns[0].Width = 470;
            dataGridViewCurrentParts.Columns[0].Width = 190;



            labelNumberResults.Visible = false;
            comboBoxSearchCategory.Text = comboBoxSearchCategory.Items[0].ToString();
            comboBoxCategory.Text = comboBoxCategory.Items[0].ToString();
            
            /*
            SerialPort.PortName = "COM5";
            try
            {
                SerialPort.Open();
                Send_UART("-1");
            }
            catch { MessageBox.Show("Error to open SerialPort"); }

            btCOMConnect.BackColor = Color.LightGreen;
            btCOMConnect.Text = "Disconnect";
            comboBox1.Enabled = false;
            */

            //Get_Number_Registered_Box();
            
            
            GetFirebase(String.Empty); 
            Pre_Load_Done = true;

            Full_ComboBox_Category();
        }

        void Full_ComboBox_Category()
        {
            comboBoxCategory.Items.Clear();
            comboBoxCategory.Items.Add("<Select one or type a new one>");
            int items = comboBoxCategory.Items.Count;
            string value = string.Empty;
            bool AlreadyExist = false;

            

            foreach (var key in JSON_Firebase.Keys)
            {
                for(int i = 0; i < items; i++) {
                    
                    value = comboBoxCategory.Items[i].ToString();

                    if (key == value)                    
                        AlreadyExist = true;                    
                }
                if (AlreadyExist == false)
                {
                    comboBoxCategory.Items.Add(key);
                    comboBoxSearchCategory.Items.Add(key);
                }
            }
            comboBoxCategory.Text = comboBoxCategory.Items[0].ToString();
        }

        void Push_New_Component(string category, string description, string drawer)
        {
            try
            {
                var todo = new
                {
                    Description = description,                  
                    Drawer = drawer
                };

                PushResponse response = Client.Push(category, todo);

                string retorno = JsonConvert.SerializeObject(response).ToString();
            }
            catch
            {

            }
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
            GetFirebase(comboBoxSearchCategory.Text);
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
                        newRow = new string[] { JSON_Firebase[key]["Description"], JSON_Firebase[key]["Drawer"] };

                        if (row.Cells[0].Value != JSON_Firebase[key]["Description"])
                        {
                            dataGridViewResults.Rows.Add(newRow);
                            break;
                        }
                    }
                }
                else
                {
                    Send_UART("-1");
                    //Highlight_Selected_Drawer("0", SEARCH, Color.WhiteSmoke);
                    //Highlight_Selected_Drawer("0", REGISTER, Color.WhiteSmoke);
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

                            //if (String.Compare(s, w, StringComparison.OrdinalIgnoreCase) == 0)
                            if(culture.CompareInfo.IndexOf(s, w, CompareOptions.IgnoreCase) >= 0)
                            {
                                foreach (DataGridViewRow row in dataGridViewResults.Rows)
                                {
                                    newRow = new string[] { JSON_Firebase[key][key2]["Description"], JSON_Firebase[key][key2]["Drawer"] };

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
                    Send_UART("-1");
                    //Highlight_Selected_Drawer("0", SEARCH, Color.WhiteSmoke);
                    //ighlight_Selected_Drawer("0", REGISTER, Color.WhiteSmoke);
                    labelNumberResults.Text = "0" + " results found";
                }
            }
            dataGridViewResults.AllowUserToAddRows = false;
            labelNumberResults.Text = numberResults.ToString() + " results found";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (SerialPort.IsOpen)
            {
                SearchByDescription(textBoxSearch.Text);
                Pre_Load_Done = false;
                labelNumberResults.Visible = true;
            }
            else
            {
                MessageBox.Show("Connect first...");
            }            
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (SerialPort.IsOpen)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchByDescription(textBoxSearch.Text);
                    labelNumberResults.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Connect first...");
            }
        }

        void Highligth_From_Results()
        {
            try
            {
                int x = dataGridViewResults.SelectedCells[0].RowIndex;

         
                var drawer = dataGridViewResults[1, x].Value.ToString();

                string UART_command = drawer + ',' + LED_Highlight_Color.R + ',' + LED_Highlight_Color.G + ',' + LED_Highlight_Color.B + ',' + LED_Highlight_Brightness + ',' + LED_Highlight_Time + '\n';


                Send_UART(UART_command);
                //if ()
                //Highlight_Selected_Drawer(drawer.ToString(), tabControl1.SelectedIndex, Color.LemonChiffon);
            }
            catch
            {

            }
        }


        private void dataGridViewResults_SelectionChanged(object sender, EventArgs e)
        {
            Highligth_From_Results();
            
        }

        private void buttonListAll_Click(object sender, EventArgs e)
        {

            if (comboBoxSearchCategory.SelectedIndex != 0)
            {
                SearchByCategory();
                Pre_Load_Done = false;
                labelNumberResults.Visible = true;
            }
            else
            {
                MessageBox.Show("Select a category");
            }
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
                stringJson = stringJson.Substring(0, stringJson.IndexOf("}") + 1);
                JSON_UART = serializer.DeserializeObject(stringJson);
                //s = JSON_UART["Number Boxes"];

                //if (int.Parse(s) > 0)
                //{ 
/*
                    Number_Boxes = int.Parse(s);
                    Send_UART("OK\r\n");
                    Send_UART("OK\r\n");
                    Send_UART("OK\r\n");
                    Send_UART("OK\r\n");
                    Send_UART("OK\r\n");
                    Send_UART("OK\r\n");
                    Get_Number_Boxes_Okay = true;
                */
                //}
                //else
                //{
                  //  if (Get_Number_Boxes_Okay == false)
                    //    Get_Number_Registered_Box();
                //}
            }
            catch
            {
            }


        }

        /*
        void Get_Number_Registered_Box()
        {
            Send_UART("BOX?\r\n");
        }
        */

        void FindRegisteredComponent(string input)
        {
            string[] newRow;
            int numberResults = 0;

            dataGridViewRegisteredParts.AllowUserToAddRows = true;

            dataGridViewRegisteredParts.Rows.Clear();

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

                            //if (String.Compare(s, w, StringComparison.OrdinalIgnoreCase) == 0)
                            if (culture.CompareInfo.IndexOf(s, w, CompareOptions.IgnoreCase) >= 0)
                            {
                                foreach (DataGridViewRow row in dataGridViewRegisteredParts.Rows)
                                {
                                    newRow = new string[] { JSON_Firebase[key][key2]["Description"], JSON_Firebase[key][key2]["Drawer"] };

                                    if (row.Cells[0].Value != JSON_Firebase[key][key2]["Description"])
                                    {
                                        dataGridViewRegisteredParts.Rows.Add(newRow);
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
                    Send_UART("-1");
                    //Highlight_Selected_Drawer("0", SEARCH, Color.WhiteSmoke);
                    //Highlight_Selected_Drawer("0", REGISTER, Color.WhiteSmoke);
                    labelNumberResults2.Text = "0" + " results found";
                }
            }
            dataGridViewRegisteredParts.AllowUserToAddRows = false;
            labelNumberResults2.Text = numberResults.ToString() + " results found";
            
            if(numberResults == 1)
                Show_Location_Registered_Part(0);
            else if (numberResults == 0)
                groupBoxCurrentLocation.Visible = false;

        }

        private void Get_Button_Click(object sender, EventArgs e)
        {
            labelNumberResults2.Visible = false;
            if (Last_Button_Properties[0] != (sender as Button).Text)
            {
                //firstClick = true;

                //if (Last_Button_Properties[0] != (sender as Button).Text && Last_Button_Properties[0] != String.Empty)
                 //   Highlight_Selected_Drawer(Last_Button_Properties[0], tabControl1.SelectedIndex, Last_Button_Properties[1]);

                Last_Button_Properties[1] = (sender as Button).BackColor;

                //Highlight_Selected_Drawer((sender as Button).Text, tabControl1.SelectedIndex, Color.LightGreen);

                Last_Button_Properties[0] = (sender as Button).Text;

               // firstClick = false;
            }
        }

        private void buttonNewBox_Click(object sender, EventArgs e)
        {
            Manually_Manipulating_Datagrid = true;
            labelNumberResults2.Visible = false;
            groupBoxCurrentLocation.Visible = false;
            string[] newRow;
           // int newBox = dataGridViewBoxes.RowCount;
            int index = 0;
            bool get_small = false;
            comboBoxCategory.Text = comboBoxCategory.Items[0].ToString();
         //   dataGridViewBoxes.AllowUserToAddRows = true;            
                        
            //Checks the smallest non-existent box's number
        /*
         * for (int i = 0; i < newBox; i++)
            {
                int box = int.Parse(dataGridViewBoxes.Rows[i].Cells[0].Value.ToString().Substring(dataGridViewBoxes.Rows[dataGridViewBoxes.SelectedCells[0].RowIndex].Cells[0].Value.ToString().IndexOf(" ") + 1));

                if (box > i + 1)
                {
                    newBox = i + 1;
                    get_small = true;
                    break;
                }
            }
            */


            /*
            if (get_small == false)
                newBox += 1;

            index = newBox - 1;

            if (newBox <= 9)
                newRow = new string[] { "BOX 0" + newBox };
            else
                newRow = new string[] { "BOX " + newBox };

            dataGridViewBoxes.Rows.Add(newRow);

            var test = dataGridViewBoxes.RowCount - 1;
            dataGridViewBoxes.Rows[test].Selected = true;

            dataGridViewBoxes.AllowUserToAddRows = false;
            
            dataGridViewBoxes.Sort(dataGridViewBoxes.Columns[0], ListSortDirection.Ascending);
            dataGridViewBoxes.Rows[index].Selected = true;
            */
            //Current_Selected_Box = index;


            /*
            Current_Selected_Box = dataGridViewBoxes.Rows[index].Cells[0].Value.ToString();            
            Current_Selected_Box = int.Parse(Current_Selected_Box.Substring(Current_Selected_Box.IndexOf(" ") + 1)).ToString();
            */

            Manually_Manipulating_Datagrid = false;
            /*
            if (Fill_Parts_Datagrid() == 0)
                Clear_Highlight_All_Boxes(CLEAR_ALL);
            else
                Clear_Highlight_All_Boxes(CLEAR_KEEPING_FILLED_DRAWERS);
            */
            /*
            if(dataGridViewBoxes.RowCount>1)
                Highlight_Drawer_From_Box_Selection();
            */
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
            if (string.IsNullOrWhiteSpace(textBoxDrawer.Text))
            {
                validatedDrawer = false;
                errorProvider1.SetError(textBoxDrawer, "should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                validatedDrawer = true;
                errorProvider1.SetError(textBoxDrawer, "");
            }
        }

        void ReLoad_Fields()
        {
            string lastDrawer = Last_Button_Properties[0].ToString();//////////////////////                       

            comboBoxCategory.Text = comboBoxCategory.Items[0].ToString();
            textBoxDescription.Text = string.Empty;
            textBoxDrawer.Text = string.Empty;     
            
            GetFirebase(String.Empty);
         
            Fill_All_Fields_With_Firebase_Data();
            
            //Set_BackColor_to_Button(lastDrawer, Color.Linen);

            //Highlight_Selected_Drawer(lastDrawer, REGISTER, Color.Linen);
            //Last_Draw_Highlight = lastDrawer;

            Last_Button_Properties[0] = lastDrawer;
            Last_Button_Properties[1] = Color.Linen;
        }

        void Fill_All_Fields_With_Firebase_Data()
        {
            Fill_Boxes_Datagrid();
            Fill_Parts_Datagrid();
            Full_ComboBox_Category();
        }

        void Fill_Boxes_Datagrid()
        {
            string[] newRow;
            string value = string.Empty;

           // dataGridViewBoxes.Rows.Clear();
            //dataGridViewBoxes.AllowUserToAddRows = true;

            foreach (var key in JSON_Firebase.Keys)
            {
                if (key != "void")
                {
                    foreach (var key2 in JSON_Firebase[key].Keys)
                    {
                        /*
                        if (int.Parse(JSON_Firebase[key][key2]["Box"]) <= 9)
                            value = "0" + JSON_Firebase[key][key2]["Box"];
                        else
                            value = JSON_Firebase[key][key2]["Box"].toString();

                        newRow = new string[] { "BOX " + value };

                        int totalRows = 0;
                        */
                        int rowCheck = 0;

                        /*
                        foreach (DataGridViewRow existingRow in dataGridViewBoxes.Rows)
                        {
                            if (dataGridViewBoxes.Rows.Count > 1)
                            {
                                totalRows = dataGridViewBoxes.Rows.Count;

                                string s1 = newRow[0].ToString();
                                string s2 = "";
                                if (existingRow.Cells[0].Value != null)
                                    s2 = existingRow.Cells[0].Value.ToString();

                                if (s1 != s2)
                                    rowCheck++;
                            }
                            else
                            {
                                dataGridViewBoxes.Rows.Add(newRow);
                                break;
                            }
                        }
                        if ((totalRows == rowCheck) && (totalRows != 0))
                            dataGridViewBoxes.Rows.Add(newRow);
                        */
                    }
                }
            }

            //dataGridViewBoxes.Sort(dataGridViewBoxes.Columns[0], ListSortDirection.Ascending);
            //dataGridViewBoxes.AllowUserToAddRows = false;
        }
        
        int Fill_Parts_Datagrid()
        {
            string[] newRow;
            string value = string.Empty;
            int results = 0;

            dataGridViewCurrentParts.Rows.Clear();
            dataGridViewCurrentParts.AllowUserToAddRows = true;

            foreach (var key in JSON_Firebase.Keys)
            {
                if (key != "void")
                {
                    foreach (var key2 in JSON_Firebase[key].Keys)
                    {

                        //var category = JSON_Firebase[key][];

                            newRow = new string[] { key, JSON_Firebase[key][key2]["Description"], JSON_Firebase[key][key2]["Drawer"] };
                         
                            dataGridViewCurrentParts.Rows.Add(newRow);

                            results++;

                    }
                }
            }

            dataGridViewCurrentParts.AllowUserToAddRows = false;

            return results;
        }
        
        void Highlight_Drawer_From_Box_Selection()
        {            
            foreach (var key in JSON_Firebase.Keys)
            {
                foreach (var key2 in JSON_Firebase[key].Keys)
                {
                    if (JSON_Firebase[key][key2]["Box"] == Current_Selected_Box)
                    {
                        switch (JSON_Firebase[key][key2]["Drawer"])
                        {
                            /*
                            case "1":  if (btnSelected_Drawer_1.BackColor  != Color.LemonChiffon) btnSelected_Drawer_1.BackColor  = Color.Linen; break;
                            case "2":  if (btnSelected_Drawer_2.BackColor  != Color.LemonChiffon) btnSelected_Drawer_2.BackColor  = Color.Linen; break;
                            case "3":  if (btnSelected_Drawer_3.BackColor  != Color.LemonChiffon) btnSelected_Drawer_3.BackColor  = Color.Linen; break;
                            case "4":  if (btnSelected_Drawer_4.BackColor  != Color.LemonChiffon) btnSelected_Drawer_4.BackColor  = Color.Linen; break;
                            case "5":  if (btnSelected_Drawer_5.BackColor  != Color.LemonChiffon) btnSelected_Drawer_5.BackColor  = Color.Linen; break;
                            case "6":  if (btnSelected_Drawer_6.BackColor  != Color.LemonChiffon) btnSelected_Drawer_6.BackColor  = Color.Linen; break;
                            case "7":  if (btnSelected_Drawer_7.BackColor  != Color.LemonChiffon) btnSelected_Drawer_7.BackColor  = Color.Linen; break;
                            case "8":  if (btnSelected_Drawer_8.BackColor  != Color.LemonChiffon) btnSelected_Drawer_8.BackColor  = Color.Linen; break;
                            case "9":  if (btnSelected_Drawer_9.BackColor  != Color.LemonChiffon) btnSelected_Drawer_9.BackColor  = Color.Linen; break;
                            case "10": if (btnSelected_Drawer_10.BackColor != Color.LemonChiffon) btnSelected_Drawer_10.BackColor = Color.Linen; break;
                            case "11": if (btnSelected_Drawer_11.BackColor != Color.LemonChiffon) btnSelected_Drawer_11.BackColor = Color.Linen; break;
                            case "12": if (btnSelected_Drawer_12.BackColor != Color.LemonChiffon) btnSelected_Drawer_12.BackColor = Color.Linen; break;
                            case "13": if (btnSelected_Drawer_13.BackColor != Color.LemonChiffon) btnSelected_Drawer_13.BackColor = Color.Linen; break;
                            case "14": if (btnSelected_Drawer_14.BackColor != Color.LemonChiffon) btnSelected_Drawer_14.BackColor = Color.Linen; break;
                            case "15": if (btnSelected_Drawer_15.BackColor != Color.LemonChiffon) btnSelected_Drawer_15.BackColor = Color.Linen; break;
                            case "16": if (btnSelected_Drawer_16.BackColor != Color.LemonChiffon) btnSelected_Drawer_16.BackColor = Color.Linen; break;
                            case "17": if (btnSelected_Drawer_17.BackColor != Color.LemonChiffon) btnSelected_Drawer_17.BackColor = Color.Linen; break;
                            case "18": if (btnSelected_Drawer_18.BackColor != Color.LemonChiffon) btnSelected_Drawer_18.BackColor = Color.Linen; break;
                            case "19": if (btnSelected_Drawer_19.BackColor != Color.LemonChiffon) btnSelected_Drawer_19.BackColor = Color.Linen; break;
                            case "20": if (btnSelected_Drawer_20.BackColor != Color.LemonChiffon) btnSelected_Drawer_20.BackColor = Color.Linen; break;
                            case "21": if (btnSelected_Drawer_21.BackColor != Color.LemonChiffon) btnSelected_Drawer_21.BackColor = Color.Linen; break;
                            case "22": if (btnSelected_Drawer_22.BackColor != Color.LemonChiffon) btnSelected_Drawer_22.BackColor = Color.Linen; break;
                            case "23": if (btnSelected_Drawer_23.BackColor != Color.LemonChiffon) btnSelected_Drawer_23.BackColor = Color.Linen; break;
                            case "24": if (btnSelected_Drawer_24.BackColor != Color.LemonChiffon) btnSelected_Drawer_24.BackColor = Color.Linen; break;
                                */
                        }

                    }
                }
            }
        }
       
        void Highlight_Drawer_From_Parts_Selection()
        {

            try
            {
                int x = dataGridViewCurrentParts.SelectedCells[0].RowIndex;


                var drawer = dataGridViewCurrentParts[2, x].Value.ToString();

                string UART_command = drawer + ',' + LED_Highlight_Color.R + ',' + LED_Highlight_Color.G + ',' + LED_Highlight_Color.B + ',' + LED_Highlight_Brightness + ',' + LED_Highlight_Time + '\n';


                Send_UART(UART_command);
                //if ()
                //Highlight_Selected_Drawer(drawer.ToString(), tabControl1.SelectedIndex, Color.LemonChiffon);
            }
            catch
            {

            }


        }     
        
        /*
        void Clear_Highlight_All_Boxes(int clear_level)
        {
            switch (clear_level)
            {
                case CLEAR_ALL:
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
                    break;
            
                case CLEAR_KEEPING_FILLED_DRAWERS:
                    if (btnSelected_Drawer_1.BackColor  != Color.LemonChiffon) btnSelected_Drawer_1.BackColor  = Color.WhiteSmoke;
                    if (btnSelected_Drawer_2.BackColor  != Color.LemonChiffon) btnSelected_Drawer_2.BackColor  = Color.WhiteSmoke;
                    if (btnSelected_Drawer_3.BackColor  != Color.LemonChiffon) btnSelected_Drawer_3.BackColor  = Color.WhiteSmoke;
                    if (btnSelected_Drawer_4.BackColor  != Color.LemonChiffon) btnSelected_Drawer_4.BackColor  = Color.WhiteSmoke;
                    if (btnSelected_Drawer_5.BackColor  != Color.LemonChiffon) btnSelected_Drawer_5.BackColor  = Color.WhiteSmoke;
                    if (btnSelected_Drawer_6.BackColor  != Color.LemonChiffon) btnSelected_Drawer_6.BackColor  = Color.WhiteSmoke;
                    if (btnSelected_Drawer_7.BackColor  != Color.LemonChiffon) btnSelected_Drawer_7.BackColor  = Color.WhiteSmoke;
                    if (btnSelected_Drawer_8.BackColor  != Color.LemonChiffon) btnSelected_Drawer_8.BackColor  = Color.WhiteSmoke;
                    if (btnSelected_Drawer_9.BackColor  != Color.LemonChiffon) btnSelected_Drawer_9.BackColor  = Color.WhiteSmoke;
                    if (btnSelected_Drawer_10.BackColor != Color.LemonChiffon) btnSelected_Drawer_10.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_11.BackColor != Color.LemonChiffon) btnSelected_Drawer_11.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_12.BackColor != Color.LemonChiffon) btnSelected_Drawer_12.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_13.BackColor != Color.LemonChiffon) btnSelected_Drawer_13.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_14.BackColor != Color.LemonChiffon) btnSelected_Drawer_14.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_15.BackColor != Color.LemonChiffon) btnSelected_Drawer_15.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_16.BackColor != Color.LemonChiffon) btnSelected_Drawer_16.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_17.BackColor != Color.LemonChiffon) btnSelected_Drawer_17.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_18.BackColor != Color.LemonChiffon) btnSelected_Drawer_18.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_19.BackColor != Color.LemonChiffon) btnSelected_Drawer_19.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_20.BackColor != Color.LemonChiffon) btnSelected_Drawer_20.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_21.BackColor != Color.LemonChiffon) btnSelected_Drawer_21.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_22.BackColor != Color.LemonChiffon) btnSelected_Drawer_22.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_23.BackColor != Color.LemonChiffon) btnSelected_Drawer_23.BackColor = Color.WhiteSmoke;
                    if (btnSelected_Drawer_24.BackColor != Color.LemonChiffon) btnSelected_Drawer_24.BackColor = Color.WhiteSmoke;
                    break;
            }

        }
       */
        
        
        /*
        private void dataGridViewBoxes_SelectionChanged(object sender, EventArgs e)
        {
            string y = string.Empty;

            if (Manually_Manipulating_Datagrid == false)
            {
                if (dataGridViewBoxes.SelectedCells.Count > 0)
                {
                    y = dataGridViewBoxes.SelectedCells[0].Value.ToString();

                    Current_Selected_Box = y.Substring(y.IndexOf(" ") + 1);
                    int boxNumber = int.Parse(Current_Selected_Box);
                    Current_Selected_Box = boxNumber.ToString();

                    int n = Fill_Parts_Datagrid();
                    if (n == 0)
                    {
                        Clear_Highlight_All_Boxes(CLEAR_ALL);
                        comboBoxCategory.Text = comboBoxCategory.Items[0].ToString();
                    }
                    //else if(n==1){
                    //    Send_UART("1");
                    //    Clear_Highlight_All_Boxes(CLEAR_KEEPING_FILLED_DRAWERS);
                    //}
                    else
                        Clear_Highlight_All_Boxes(CLEAR_KEEPING_FILLED_DRAWERS);

                    Highlight_Drawer_From_Box_Selection();
                }
            }
            else
                return;
        }  
        */

        private void dataGridViewCurrentParts_SelectionChanged(object sender, EventArgs e)
        {
            Highlight_Drawer_From_Parts_Selection();

            int x = JSON_Firebase.Count;
            if (dataGridViewCurrentParts.Rows.Count == x+1)
                Send_UART("1");
        }

        private void buttonFindCurrentLocation_Click(object sender, EventArgs e)
        {
            
            groupBoxCurrentLocation.Visible = true;
            labelNumberResults2.Visible = true;
            FindRegisteredComponent(textBoxDescription.Text);
        }

        private void dataGridViewRegisteredParts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Show_Location_Registered_Part(e.RowIndex); 
        }

        void Show_Location_Registered_Part(int clickIndex) {
            int clicked_index = clickIndex;
            
            int drawer_index = 0;
            
            string drawer = dataGridViewRegisteredParts.Rows[clicked_index].Cells[1].Value.ToString();

            try
            {
                string UART_command = drawer + ',' + LED_Highlight_Color.R + ',' + LED_Highlight_Color.G + ',' + LED_Highlight_Color.B + ',' + LED_Highlight_Brightness + ',' + LED_Highlight_Time + '\n';
                Send_UART(UART_command);
                int milliseconds = 1000;
                Thread.Sleep(milliseconds);
                
            }
            catch
            {

            }


           // Fill_Parts_Datagrid();

            foreach (DataGridViewRow rowDrawer in dataGridViewCurrentParts.Rows)
            {
                if ((rowDrawer.Cells[2].Value.ToString() == drawer))
                {
                    drawer_index = rowDrawer.Index;
                    break;
                }
            }

            dataGridViewCurrentParts.Rows[drawer_index].Selected = true;

            //Highlight_Drawer_From_Parts_Selection();

            /*
            if (Last_Button_Properties[0] != drawer && Last_Button_Properties[0] != String.Empty)
                Highlight_Selected_Drawer(Last_Button_Properties[0], tabControl1.SelectedIndex, Last_Button_Properties[1]);
            */
          //  Last_Button_Properties[1] = Get_BackColor_From_Button(drawer);

           // Highlight_Selected_Drawer(drawer, tabControl1.SelectedIndex, Color.LightGreen);

            Last_Button_Properties[0] = drawer;

            groupBoxCurrentLocation.Visible = false;

            textBoxDescription.Text = dataGridViewRegisteredParts.Rows[clicked_index].Cells[0].Value.ToString();
        }

        private void textBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                groupBoxCurrentLocation.Visible = true;
                labelNumberResults2.Visible = true;
                FindRegisteredComponent(textBoxDescription.Text); 
            }
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            groupBoxCurrentLocation.Visible = false;
            labelNumberResults2.Visible = false;

            if (validatedCategory && validatedDescription && validatedDrawer)
            {                
                    string category = comboBoxCategory.Text;
                    string description = textBoxDescription.Text;                  
                    string drawer = textBoxDrawer.Text;
                    Push_New_Component(category, description, drawer);
                ReLoad_Fields();                
            }
            else
                MessageBox.Show("Fill all fields!");
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonSettings.Text == "Config Highlight")
            {
                groupBoxSettings.Visible = true;
                buttonSettings.Text = "Save";

            }
            else if (buttonSettings.Text == "Save")
            {
                buttonSettings.Text = "Config Highlight";
                groupBoxSettings.Visible = false;
                SaveData();
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            
            colorDialog1.AllowFullOpen = false;            
            colorDialog1.ShowHelp = true;            
            colorDialog1.Color = buttonSettings.ForeColor;

          


            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                LED_Highlight_Color = colorDialog1.Color;
                buttonColor.BackColor = LED_Highlight_Color;
            }
        }

        private void trackBarTime_Scroll(object sender, EventArgs e)
        {
            LED_Highlight_Time = trackBarTime.Value;

            if (trackBarTime.Value < 1000)
            {
                if (trackBarTime.Value < 100)
                    labelTime.Text = "always on";
                else
                    labelTime.Text = trackBarTime.Value + "ms blinky";
            }

            else
                labelTime.Text = "1s blinky";
            
        }

        private void trackBarBright_Scroll(object sender, EventArgs e)
        {
            LED_Highlight_Brightness = trackBarBright.Value;

            int x = (trackBarBright.Value * 100) / 255;
            labelBright.Text = x + "% brightness";
        }

        void SaveData()
        {            
            Hashtable variables = new Hashtable();

            variables.Add("Color", LED_Highlight_Color);
            variables.Add("Time", LED_Highlight_Time);
            variables.Add("Brightness", LED_Highlight_Brightness);

            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

            
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(fs, variables);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }


        void LoadData()
        {            
            Hashtable variables = null;

            FileStream fs = new FileStream("DataFile.dat", FileMode.OpenOrCreate);
            
            try
            {

                BinaryFormatter formatter = new BinaryFormatter();
                variables = (Hashtable)formatter.Deserialize(fs);
                LED_Highlight_Color = (Color)variables["Color"];
                LED_Highlight_Time = (int)variables["Time"];
                LED_Highlight_Brightness = (int)variables["Brightness"];


                buttonColor.BackColor = LED_Highlight_Color;

                trackBarTime.Value = LED_Highlight_Time;
                if (LED_Highlight_Time < 1000)
                {
                    if (LED_Highlight_Time < 100)
                        labelTime.Text = "always on";
                    else
                        labelTime.Text = LED_Highlight_Time + "ms blinky";
                }

                else
                    labelTime.Text = "1s blinky";

                trackBarBright.Value = LED_Highlight_Brightness;
                int x = (LED_Highlight_Brightness * 100) / 255;
                labelBright.Text = x + "% brightness";


            }
            catch (SerializationException e)
            {
             
            }
            finally
            {
                fs.Close();
            }           
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string category = string.Empty;
           // string box = string.Empty;
            string drawer = string.Empty;
            string description = string.Empty;
            //string qty = string.Empty;

            try
            {
                labelNumberResults2.Visible = false;


                category = "";
                if (dataGridViewCurrentParts.SelectedCells.Count > 0)
                    category = dataGridViewCurrentParts.SelectedCells[0].Value.ToString();

                drawer = "";
                if (dataGridViewCurrentParts.SelectedCells.Count > 0)
                    drawer = dataGridViewCurrentParts.SelectedCells[2].Value.ToString();

                 description = "";
                if (dataGridViewCurrentParts.SelectedCells.Count > 0)
                    description = dataGridViewCurrentParts.SelectedCells[1].Value.ToString();

       

                

                Form2 f2 = new Form2(category, drawer, description);
                //Form2 f2 = new Form2( drawer, description);
                var result = f2.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string _category = f2.category;                    
                    string _drawer = f2.drawer;
                    string _description = f2.description;
                   

                    if(category != _category || drawer != _drawer)
                    {
                        Delete_Firebase( drawer);
                        Push_New_Component(_category, _description, _drawer);
                    }
                    else
                        Update_Firebase(_drawer, _description);
                    
                    ReLoad_Fields();
                }
            }
            catch
            {

            }
        }


        void Update_Firebase(string drawer, string description )
        {
            string address = Get_Firebase_Address(drawer);

            var todo = new
            {
                Description = description,              
                Drawer = drawer
            };


            FirebaseResponse response = Client.Update(address, todo);

            string retorno = JsonConvert.SerializeObject(response).ToString();
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                labelNumberResults2.Visible = false;
               // string box = int.Parse(dataGridViewBoxes.Rows[dataGridViewBoxes.SelectedCells[0].RowIndex].Cells[0].Value.ToString().Substring(dataGridViewBoxes.Rows[dataGridViewBoxes.SelectedCells[0].RowIndex].Cells[0].Value.ToString().IndexOf(" ") + 1)).ToString();

                string drawer = "";
                if (dataGridViewCurrentParts.SelectedCells.Count > 0)
                    drawer = dataGridViewCurrentParts.SelectedCells[2].Value.ToString();

                Delete_Firebase(drawer);
                ReLoad_Fields();
                /*
                if (dataGridViewBoxes.RowCount == 0)
                {
                    Clear_Highlight_All_Boxes(CLEAR_ALL);
                    Last_Button_Properties[1] = Color.WhiteSmoke;
                }
                */
            }
            catch
            {

            }

        }

        void Delete_Firebase( string drawer)
        {
            String todo = String.Empty;


            foreach (var key in JSON_Firebase.Keys)
            {
                if (key != "void")
                {
                    foreach (var key2 in JSON_Firebase[key].Keys)
                    {
                        if (JSON_Firebase[key][key2]["Drawer"] == drawer)
                        {
                            todo = key + "/" + key2;
                        }
                    }
                }
            }
                       

           var response = Client.Delete(todo);

           string retorno = JsonConvert.SerializeObject(response).ToString();
        }

        string Get_Firebase_Address(string drawer)
        {
            string r = string.Empty;

            foreach (var key in JSON_Firebase.Keys)
            {
                if (key != "void")
                {
                    foreach (var key2 in JSON_Firebase[key].Keys)
                    {
                        if (JSON_Firebase[key][key2]["Drawer"] == drawer)
                        {
                           r = key + "/" + key2;
                        }
                    }
                }
            }

            return r;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Send_UART("-1");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (buttonSettings.Text == "Config Highlight")
            {
                groupBoxSettings.Visible = true;
                buttonSettings.Text = "Save";

            }
            else if (buttonSettings.Text == "Save")
            {
                buttonSettings.Text = "Config Highlight";
                groupBoxSettings.Visible = false;
                SaveData();
            }
        }

        private void buttonColor_Click_1(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = false;
            colorDialog1.ShowHelp = true;
            colorDialog1.Color = buttonSettings.ForeColor;




            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                LED_Highlight_Color = colorDialog1.Color;
                buttonColor.BackColor = LED_Highlight_Color;
            }
        }

        private void trackBarTime_Scroll_1(object sender, EventArgs e)
        {
            LED_Highlight_Time = trackBarTime.Value;

            if (trackBarTime.Value < 1000)
            {
                if (trackBarTime.Value < 100)
                    labelTime.Text = "always on";
                else
                    labelTime.Text = trackBarTime.Value + "ms blinky";
            }

            else
                labelTime.Text = "1s blinky";
        }

        private void trackBarBright_Scroll_1(object sender, EventArgs e)
        {
            LED_Highlight_Brightness = trackBarBright.Value;

            int x = (trackBarBright.Value * 100) / 255;
            labelBright.Text = x + "% brightness";
        }

        private void buttonClear_Click_1(object sender, EventArgs e)
        {
            Send_UART("-1");
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void buttonConnectWiFi_Click(object sender, EventArgs e)
        {
            if (buttonConnectWiFi.Text == "Connect")
            {
                string ssid = comboBoxSSID.SelectedItem.ToString();
                AccessPoint SelectedAP;



                foreach (AccessPoint ap in aps)
                {
                    if(ap.Name == ssid)
                    {
                        

                        if (Connect_WiFi(ap, textBoxPassword.Text))
                        {
                            Send_UART("-1");
                            buttonConnectWiFi.BackColor = Color.LightCoral;
                            buttonConnectWiFi.Text = "Disconnect";
                            comboBox1.Enabled = false;
                            buttonClear.Enabled = true;
                            TCP_Connect("192.168.1.111", 80);



                            break;
                        }
                    }
                }

                
            }
            else
            {
                Send_UART("-1");                
                SerialPort.Close();
                comboBox1.Enabled = true;
                buttonConnectWiFi.BackColor = Color.LemonChiffon;
                buttonConnectWiFi.Text = "Connect";
                buttonClear.Enabled = false;
            }
        }

        private bool Connect_WiFi(AccessPoint ap, string password)
        {
            AuthRequest authRequest = new AuthRequest(ap)
            {
                Password = password
            };

            return ap.Connect(authRequest);
        }


        public static void TCP_Connect(string host, int port)
        {
            IPAddress[] IPs = Dns.GetHostAddresses(host);

            Socket client  = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Establishing Connection to {0}", host);
            client.Connect(IPs[0], port);

            Send(client, "This is a test<EOF>");
            Console.WriteLine("Connection established");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Send(client, "This is a test<EOF>");
        }


        private static void Send(Socket client, String data)
        {
            try
            {
                // Convert the string data to byte data using ASCII encoding.  
                byte[] byteData = Encoding.ASCII.GetBytes(data);

                // Begin sending the data to the remote device.  
                client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
            }
            catch
            {

            }
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }



















































        }
}
