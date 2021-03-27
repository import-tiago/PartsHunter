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
using System.Reflection;
using System.Deployment.Application;

namespace PartsHunter
{
    public partial class Form1 : Form
    {

        private const int SEARCH = 0;
        private const int REGISTER = 1;
        private const int CLEAR_ALL = 0;
        private const int CLEAR_KEEPING_FILLED_DRAWERS = 1;
        private dynamic JSON_Firebase;



        private bool Pre_Load_Done = false;

        private string Current_Button_Click = String.Empty;
        private string Last_Button_Click = String.Empty;

        private bool validatedCategory;
        private bool validatedDescription;
        private bool validatedDrawer;
        private string Current_Selected_Box = string.Empty;
        private Color LED_Highlight_Color;
        private int LED_Highlight_Time;
        private int LED_Highlight_Brightness;
        private string BatcFileLocation;
        private CultureInfo culture = new CultureInfo("es-ES", false);
        private string Current_Category = String.Empty;
        private string Firebase_Database_URL;
        private string Firebase_Database_KEY;
        private readonly NameValueCollection configuration = ConfigurationManager.AppSettings;
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();
        private readonly IFirebaseConfig Config = new FirebaseConfig();
        private readonly IFirebaseClient Client;
        private Wifi wifi;
        private List<AccessPoint> aps;

        private static ManualResetEvent sendDone = new ManualResetEvent(false);

        ApplicationMethods _extern = new ApplicationMethods();

        public Form1()
        {
            InitializeComponent();

            Load_Firebase_Secrets();

            Config.BasePath = Firebase_Database_URL;
            Config.AuthSecret = Firebase_Database_KEY;

            Client = new FireSharp.FirebaseClient(Config);
            if (Client == null)
            {
                MessageBox.Show("Error Connection");
            }


        }






        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {


            Set_Firebase_HardwareDevice("-1,0,0,0,0,0");



        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (tabControl1.SelectedIndex == 1 && Pre_Load_Done == false)
            {
                FIll_ComboBox_Category();
            }


            if (tabControl1.SelectedIndex == 0 && dataGridViewSearch.CurrentRow == null)
            {
            }

            else if (tabControl1.SelectedIndex == 0 && dataGridViewSearch.CurrentRow != null)
            {
                Highligth_From_Results();
            }

            if (tabControl1.SelectedIndex == 2)
            {
                if (Firebase_Database_KEY == "" && Firebase_Database_URL == "")
                {
                    button1.Visible = false;
                }
                else
                    button1.Visible = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Load_Local_File_Configs();



            dataGridViewSearch.Columns[0].Width = (int)(dataGridViewSearch.Width * 0.3);
            dataGridViewSearch.Columns[1].Width = (int)(dataGridViewSearch.Width * 0.6);
            dataGridViewSearch.Columns[2].Width = (int)(dataGridViewSearch.Width * 0.1);

            labelNumberResults.Visible = false;
            comboBoxCategories_SearchTab.Text = comboBoxCategories_SearchTab.Items[0].ToString();
            comboBoxCategories_RegisterTab.Text = comboBoxCategories_RegisterTab.Items[0].ToString();

            textBoxFirebase_URL.Text = Firebase_Database_URL;
            textBoxFirebase_Key.Text = Firebase_Database_KEY;

            Load_Firebase_Database();
            Pre_Load_Done = true;

            FIll_ComboBox_Category();
            Set_Firebase_HardwareDevice("-1,0,0,0,0,0");

            if (Firebase_Database_KEY == null && Firebase_Database_URL == null)
            {
                buttonSearch.Enabled = false;
                buttonListAll.Enabled = false;
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
                buttonClear.Enabled = false;
                buttonSave.Enabled = false;

            }
        }

        void Load_Firebase_Database()
        {
            Firebase_getString(String.Empty);
        }

        void FIll_ComboBox_Category()
        {
            comboBoxCategories_RegisterTab.Items.Clear();
            comboBoxCategories_RegisterTab.Items.Add("<Select one or type a new one>");

            int items = comboBoxCategories_RegisterTab.Items.Count;
            int items2 = comboBoxCategories_SearchTab.Items.Count;

            string value = string.Empty;
            string value2 = string.Empty;

            bool ignore = false;
            bool ignore2 = false;

            try
            {

                foreach (var key in JSON_Firebase.Keys)
                {
                    ignore = false;
                    ignore2 = false;




                    for (int i = 0; i < items; i++)
                    {
                        value = comboBoxCategories_RegisterTab.Items[i].ToString();

                        if (key == value || key == "HardwareDevice")
                            ignore = true;
                    }
                    if (ignore == false)
                    {
                        comboBoxCategories_RegisterTab.Items.Add(key);
                    }





                    for (int i = 0; i < items2; i++)
                    {


                        value2 = comboBoxCategories_SearchTab.Items[i].ToString();

                        if (key == value || key == "HardwareDevice" || key == value2)
                            ignore2 = true;
                    }
                    if (ignore2 == false)
                    {
                        comboBoxCategories_SearchTab.Items.Add(key);
                    }
                }
            }
            catch
            {

            }
            comboBoxCategories_RegisterTab.Text = comboBoxCategories_RegisterTab.Items[0].ToString();
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



        void Firebase_getString(string input)
        {
            try
            {
                FirebaseResponse response = Client.Get(input);

                string String_Firebase = response.Body;


                JSON_Firebase = serializer.DeserializeObject(String_Firebase);

                if (JSON_Firebase == null)
                    JSON_Firebase = JSON_Firebase = serializer.DeserializeObject("{void:0}");
            }
            catch
            {

            }
        }

        void SearchByCategory()
        {
            string[] newRow;
            Firebase_getString(comboBoxCategories_SearchTab.Text);
            dataGridViewSearch.AllowUserToAddRows = true;
            dataGridViewSearch.Rows.Clear();

            foreach (var key in JSON_Firebase.Keys)
            {
                if (key != "void" && key != "HardwareDevice")
                {
                    int numberResults = JSON_Firebase.Keys.Count;
                    labelNumberResults.Text = numberResults.ToString() + " results found";

                    foreach (DataGridViewRow row in dataGridViewSearch.Rows)
                    {
                        newRow = new string[] { comboBoxCategories_SearchTab.Text, JSON_Firebase[key]["Description"], JSON_Firebase[key]["Drawer"] };

                        if (row.Cells[0].Value != JSON_Firebase[key]["Description"])
                        {
                            dataGridViewSearch.Rows.Add(newRow);
                            break;
                        }
                    }
                }
                else
                {
                    Set_Firebase_HardwareDevice("-1,0,0,0,0,0");
                    labelNumberResults.Text = "0" + " results found";
                }
            }
            dataGridViewSearch.AllowUserToAddRows = false;
        }

        void SearchByDescription(string input)
        {
            string[] newRow;
            int numberResults = 0;
            Load_Firebase_Database();

            dataGridViewSearch.AllowUserToAddRows = true;

            dataGridViewSearch.Rows.Clear();

            foreach (var key in JSON_Firebase.Keys)
            {
                if (key != "void" && key != "HardwareDevice")
                {
                    foreach (var key2 in JSON_Firebase[key].Keys)
                    {
                        string s = JSON_Firebase[key][key2]["Description"].ToString();

                        string[] words = input.Split(' ');



                        foreach (var w in words)
                        {

                            if (culture.CompareInfo.IndexOf(s, w, CompareOptions.IgnoreCase) >= 0)
                            {
                                foreach (DataGridViewRow row in dataGridViewSearch.Rows)
                                {
                                    newRow = new string[] { key, JSON_Firebase[key][key2]["Description"], JSON_Firebase[key][key2]["Drawer"] };

                                    if (row.Cells[0].Value != JSON_Firebase[key][key2]["Description"])
                                    {
                                        dataGridViewSearch.Rows.Add(newRow);
                                        numberResults++;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                            }
                        }
                    }
                }
                else
                {

                    Set_Firebase_HardwareDevice("-1,0,0,0,0,0");
                    labelNumberResults.Text = "0" + " results found";
                }
            }
            dataGridViewSearch.AllowUserToAddRows = false;
            labelNumberResults.Text = numberResults.ToString() + " results found";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            SearchByDescription(textBoxSearch.Text);
            Pre_Load_Done = false;
            labelNumberResults.Visible = true;

        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                SearchByDescription(textBoxSearch.Text);
                labelNumberResults.Visible = true;
            }

        }

        void Highligth_From_Results()
        {

            try
            {
                int x = dataGridViewSearch.SelectedCells[0].RowIndex;


                var drawer = dataGridViewSearch[2, x].Value.ToString();


                string command = drawer + ',' + LED_Highlight_Color.R + ',' + LED_Highlight_Color.G + ',' + LED_Highlight_Color.B + ',' + LED_Highlight_Brightness + ',' + LED_Highlight_Time;

                Set_Firebase_HardwareDevice(command);


            }
            catch
            {

            }
        }



        void Set_Firebase_HardwareDevice(string command_setup)
        {
            try
            {
                string address = "/";

                var todo = new
                {
                    HardwareDevice = command_setup
                };


                FirebaseResponse response = Client.Update(address, todo);

                string retorno = JsonConvert.SerializeObject(response).ToString();
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

            if (comboBoxCategories_SearchTab.SelectedIndex != 0)
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



        private void comboBoxCategory_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxCategories_RegisterTab.Text) || comboBoxCategories_RegisterTab.Text == comboBoxCategories_RegisterTab.Items[0].ToString())
            {
                validatedCategory = false;
                errorProvider1.SetError(comboBoxCategories_RegisterTab, "should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                validatedCategory = true;
                errorProvider1.SetError(comboBoxCategories_RegisterTab, "");
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
            comboBoxCategories_RegisterTab.Text = comboBoxCategories_RegisterTab.Items[0].ToString();
            textBoxDescription.Text = string.Empty;
            textBoxDrawer.Text = string.Empty;

            Load_Firebase_Database();

            FIll_ComboBox_Category();

            SearchByDescription(textBoxSearch.Text);
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

                        }

                    }
                }
            }
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {


            if (validatedCategory && validatedDescription && validatedDrawer)
            {
                string category = comboBoxCategories_RegisterTab.Text.ToUpper();
                string description = textBoxDescription.Text;
                string drawer = textBoxDrawer.Text;
                Push_New_Component(category, description, drawer);
                ReLoad_Fields();
                Pre_Load_Done = false;
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

        void Save_Firebase_Secrets()
        {
            Hashtable variables = new Hashtable();

            variables.Add("URL", textBoxFirebase_URL.Text);
            variables.Add("KEY", textBoxFirebase_Key.Text);


            FileStream fs = new FileStream("Firebase_Secrets.dat", FileMode.Create);


            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(fs, variables);
                MessageBox.Show("This will cloase, reload the application!");
                this.Close();

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


        void Load_Firebase_Secrets()
        {
            Hashtable variables = null;

            FileStream fs = new FileStream("Firebase_Secrets.dat", FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                variables = (Hashtable)formatter.Deserialize(fs);

                Firebase_Database_URL = (string)variables["URL"];
                Firebase_Database_KEY = (string)variables["KEY"];
            }
            catch (SerializationException e)
            {

            }
            finally
            {
                fs.Close();
            }
        }



        void Load_Local_File_Configs()
        {
            Hashtable variables = null;

            if (File.Exists("DataFile.dat"))
            {
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
            else
            {
                LED_Highlight_Brightness = 128;
                LED_Highlight_Time = 100;
                LED_Highlight_Color = Color.FromArgb(0, 255, 0);
                SaveData();
                Load_Local_File_Configs();
            }


        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string category = string.Empty;
            string drawer = string.Empty;
            string description = string.Empty;

            try
            {


                category = "";
                if (dataGridViewSearch.SelectedCells.Count > 0)
                    category = dataGridViewSearch.SelectedCells[0].Value.ToString();

                drawer = "";
                if (dataGridViewSearch.SelectedCells.Count > 0)
                    drawer = dataGridViewSearch.SelectedCells[2].Value.ToString();

                description = "";
                if (dataGridViewSearch.SelectedCells.Count > 0)
                    description = dataGridViewSearch.SelectedCells[1].Value.ToString();

                Form2 f2 = new Form2(category, drawer, description);
                var result = f2.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string _category = f2.category;
                    string _drawer = f2.drawer;
                    string _description = f2.description;


                    if (category != _category || drawer != _drawer)
                    {
                        Delete_Firebase(drawer);
                        Push_New_Component(_category, _description, _drawer);
                    }
                    else
                        Update_Firebase(_drawer, _description);
                    Pre_Load_Done = false;
                    ReLoad_Fields();

                }
            }
            catch
            {

            }
        }


        void Update_Firebase(string drawer, string description)
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


                string drawer = "";
                if (dataGridViewSearch.SelectedCells.Count > 0)
                    drawer = dataGridViewSearch.SelectedCells[2].Value.ToString();

                Delete_Firebase(drawer);
                ReLoad_Fields();
                Pre_Load_Done = false;

            }
            catch
            {

            }

        }

        void Delete_Firebase(string drawer)
        {
            String todo = String.Empty;


            foreach (var key in JSON_Firebase.Keys)
            {
                if (key != "void" && key != "HardwareDevice")
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
                if (key != "void" && key != "HardwareDevice")
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

            Set_Firebase_HardwareDevice("-1,0,0,0,0,0");
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
                Highligth_From_Results();
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
            if (x <= 0)
                x = 1;

            if (LED_Highlight_Brightness <= 0)
                LED_Highlight_Brightness = 1;

            labelBright.Text = x + "% brightness";
        }

        private void buttonClear_Click_1(object sender, EventArgs e)
        {
            Set_Firebase_HardwareDevice("-1,0,0,0,0,0");
            dataGridViewSearch.Rows.Clear();
            labelNumberResults.Visible = false;
        }

        private void label9_Click(object sender, EventArgs e)
        {

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

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

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
                byte[] byteData = Encoding.ASCII.GetBytes(data);

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
                Socket client = (Socket)ar.AsyncState;

                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void buttonFirebase_Save_Click(object sender, EventArgs e)
        {
            Save_Firebase_Secrets();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (button1.Text == "Show")
            {
                textBoxFirebase_Key.Text = Firebase_Database_KEY;
                textBoxFirebase_Key.PasswordChar = '\0';
                button1.Text = "Hide";
            }
            else
            {
                textBoxFirebase_Key.PasswordChar = '*';
                button1.Text = "Show";
            }
        }

        private void buttonGetFileAddress_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFileLocation.Text = openFileDialog1.FileName;
                BatcFileLocation = openFileDialog1.FileName;
            }
        }

        private void buttonSaveFromFile_Click(object sender, EventArgs e)
        {            
            string text = System.IO.File.ReadAllText(@BatcFileLocation);
            string[] lines = System.IO.File.ReadAllLines(@BatcFileLocation);

            string category = string.Empty;
            string description = string.Empty;
            string drawer = string.Empty;

            int index = 0;
            int totalParts = 0;

            progressBar1.Visible = true;
            progressBar1.Maximum = lines.Length;

            try
            {
                foreach (string l in lines)
                {
                    string[] words = l.Split(',');

                    index = 0;
                    foreach (var w in words)
                    {
                        switch (index++)
                        {
                            case 0: category = w; break;
                            case 1: description = w; break;
                            case 2: drawer = w; break;
                        }                        
                    }
                    Push_New_Component(category.ToUpper(), description, drawer);
                    totalParts++;
                    progressBar1.Value++;
                }
                
                ReLoad_Fields();
                Pre_Load_Done = false;
                MessageBox.Show("Success! " + totalParts + " Parts added to cloud databese.");
            }
            catch
            {
                MessageBox.Show("Fail! Check the file and the text formatting rules.");
            }

            progressBar1.Visible = false;
        }
    }
}
