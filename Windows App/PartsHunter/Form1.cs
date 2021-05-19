using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using PartsHunter.Business.Interfaces;
using PartsHunter.Models;
using PartsHunter.Repositories.Interfaces;
using PartsHunter.Services;

namespace PartsHunter
{
    public partial class Form1 : Form
    {
        private const int SEARCH = 0;
        private const int REGISTER = 1;
        private const int CLEAR_ALL = 0;
        private const int CLEAR_KEEPING_FILLED_DRAWERS = 1;

        // TODO: tornar dispensável construindo um método
        private bool Pre_Load_Done = false;

        // TODO: transformar em Model
        private readonly string Current_Button_Click = String.Empty;
        private readonly string Last_Button_Click = String.Empty;

        private readonly static Led Led = new Led();

        private bool validatedCategory;
        private bool validatedDescription;
        private bool validatedDrawer;

        private readonly string Current_Selected_Box = String.Empty;

        private string BatcFileLocation;

        // TODO: tornar dispensável, impementar em cada método
        private readonly CultureInfo culture = new CultureInfo("es-ES", false);

        private readonly string Current_Category = String.Empty;

        private readonly NameValueCollection configuration = ConfigurationManager.AppSettings;

        // TODO: tornar dispensável, impementar em cada método
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        // TODO: mover para a classe correta
        private readonly Server server = new Server();

        private readonly IFirebaseRepositorie _firebaseRepositorie;
        private readonly ILocalRepositorie _localRepositorie;
        private readonly IAuthenticationBusiness _authenticationBusiness;

        public Form1(IAuthenticationBusiness authenticationBusiness, IFirebaseRepositorie firebaseRepositorie, ILocalRepositorie localRepositorie)
        {
            InitializeComponent();

            _authenticationBusiness = authenticationBusiness;
            _firebaseRepositorie = firebaseRepositorie;
            _localRepositorie = localRepositorie;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _firebaseRepositorie.SetHardwareDevice("-1,0,0,0,0,0");
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
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
                //if (String.IsNullOrEmpty(Firebase_Database_KEY) && String.IsNullOrEmpty(Firebase_Database_URL))
                //{
                buttonShow.Visible = false;
                //}
                //else
                //{
                //    buttonShow.Visible = true;
                //}
            }

        }

        private void CustomizeLed(Led led)
        {
            buttonColor.BackColor = led.Color;

            trackBarTime.Value = led.Time;
            if (led.Time < 1000)
            {
                labelTime.Text = led.Time < 100 ? "always on" : led.Time + "ms blinky";
            }

            else
            {
                labelTime.Text = "1s blinky";
            }

            trackBarBright.Value = led.Brightness;
            int x = (led.Brightness * 100) / 255;
            labelBright.Text = x + "% brightness";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Led led = _localRepositorie.LoadData();
            CustomizeLed(led);

            dataGridViewSearch.Columns[0].Width = (int)(dataGridViewSearch.Width * 0.3);
            dataGridViewSearch.Columns[1].Width = (int)(dataGridViewSearch.Width * 0.6);
            dataGridViewSearch.Columns[2].Width = (int)(dataGridViewSearch.Width * 0.1);

            labelNumberResults.Visible = false;
            comboBoxCategories_SearchTab.Text = comboBoxCategories_SearchTab.Items[0].ToString();
            comboBoxCategories_RegisterTab.Text = comboBoxCategories_RegisterTab.Items[0].ToString();

            textBoxFirebase_URL.Text = _firebaseRepositorie.BasePath;
            textBoxFirebase_Key.Text = _firebaseRepositorie.AuthSecret;

            _authenticationBusiness.LoadSecrets();
            _firebaseRepositorie.Load_Firebase_Database();
            Pre_Load_Done = true;

            FIll_ComboBox_Category();
            _firebaseRepositorie.SetHardwareDevice("-1,0,0,0,0,0");

            if (_firebaseRepositorie.AuthSecret == null && _firebaseRepositorie.BasePath == null)
            {
                buttonSearch.Enabled = false;
                buttonListAll.Enabled = false;
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
                buttonClear.Enabled = false;
                buttonSave.Enabled = false;
            }
        }

        private void FIll_ComboBox_Category()
        {
            comboBoxCategories_RegisterTab.Items.Clear();
            comboBoxCategories_RegisterTab.Items.Add("<Select one or type a new one>");

            int items = comboBoxCategories_RegisterTab.Items.Count;
            int items2 = comboBoxCategories_SearchTab.Items.Count;

            string value = String.Empty;

            if (_firebaseRepositorie.JSON_Firebase != null)
            {
                foreach (dynamic key in _firebaseRepositorie.JSON_Firebase.Keys)
                {
                    bool ignore = false;
                    bool ignore2 = false;
                    for (int i = 0; i < items; i++)
                    {
                        value = comboBoxCategories_RegisterTab.Items[i].ToString();

                        if (key == value || key == "HardwareDevice")
                        {
                            ignore = true;
                        }
                    }
                    if (ignore == false)
                    {
                        comboBoxCategories_RegisterTab.Items.Add(key);
                    }

                    for (int i = 0; i < items2; i++)
                    {


                        string value2 = comboBoxCategories_SearchTab.Items[i].ToString();

                        if (key == value || key == "HardwareDevice" || key == value2)
                        {
                            ignore2 = true;
                        }
                    }
                    if (ignore2 == false)
                    {
                        comboBoxCategories_SearchTab.Items.Add(key);
                    }
                }
            }

            comboBoxCategories_RegisterTab.Text = comboBoxCategories_RegisterTab.Items[0].ToString();
        }

        private async Task SearchByCategory()
        {
            string[] newRow;
            dynamic component = await _firebaseRepositorie.GetComponent(comboBoxCategories_SearchTab.Text);
            dataGridViewSearch.AllowUserToAddRows = true;
            dataGridViewSearch.Rows.Clear();

            foreach (dynamic key in component.Keys)
            {
                if (key != "void" && key != "HardwareDevice")
                {
                    int numberResults = component.Keys.Count;
                    labelNumberResults.Text = numberResults.ToString() + " results found";

                    foreach (DataGridViewRow row in dataGridViewSearch.Rows)
                    {
                        newRow = new string[] { comboBoxCategories_SearchTab.Text, component[key]["Description"], _firebaseRepositorie.JSON_Firebase[key]["Drawer"] };

                        if (row.Cells[0].Value != component[key]["Description"])
                        {
                            dataGridViewSearch.Rows.Add(newRow);
                            break;
                        }
                    }
                }
                else
                {
                    _firebaseRepositorie.SetHardwareDevice("-1,0,0,0,0,0");
                    labelNumberResults.Text = "0" + " results found";
                }
            }
            dataGridViewSearch.AllowUserToAddRows = false;
        }

        private void SearchByDescription(string input)
        {
            string[] newRow;
            int numberResults = 0;
            _firebaseRepositorie.Load_Firebase_Database();

            dataGridViewSearch.AllowUserToAddRows = true;

            dataGridViewSearch.Rows.Clear();

            if (_firebaseRepositorie.JSON_Firebase != null)
            {
                foreach (dynamic key in _firebaseRepositorie.JSON_Firebase.Keys)
                {
                    if (key != "void" && key != "HardwareDevice")
                    {
                        foreach (dynamic key2 in _firebaseRepositorie.JSON_Firebase[key].Keys)
                        {
                            string s = _firebaseRepositorie.JSON_Firebase[key][key2]["Description"].ToString();

                            string[] words = input.Split(' ');



                            foreach (string w in words)
                            {

                                if (culture.CompareInfo.IndexOf(s, w, CompareOptions.IgnoreCase) >= 0)
                                {
                                    foreach (DataGridViewRow row in dataGridViewSearch.Rows)
                                    {
                                        newRow = new string[] { key, _firebaseRepositorie.JSON_Firebase[key][key2]["Description"], _firebaseRepositorie.JSON_Firebase[key][key2]["Drawer"] };

                                        if (row.Cells[0].Value != _firebaseRepositorie.JSON_Firebase[key][key2]["Description"])
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

                        _firebaseRepositorie.SetHardwareDevice("-1,0,0,0,0,0");
                        labelNumberResults.Text = "0" + " results found";
                    }
                }
            }

            dataGridViewSearch.AllowUserToAddRows = false;
            labelNumberResults.Text = numberResults.ToString() + " results found";
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {

            SearchByDescription(textBoxSearch.Text);
            Pre_Load_Done = false;
            labelNumberResults.Visible = true;

        }

        private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                SearchByDescription(textBoxSearch.Text);
                labelNumberResults.Visible = true;
            }

        }

        private void Highligth_From_Results()
        {

            try
            {
                int x = dataGridViewSearch.SelectedCells[0].RowIndex;


                string drawer = dataGridViewSearch[2, x].Value.ToString();


                string command = drawer + ',' + Led.Color.R + ',' + Led.Color.G + ',' + Led.Color.B + ',' + Led.Brightness + ',' + Led.Time;

                _firebaseRepositorie.SetHardwareDevice(command);


            }
            catch
            {

            }
        }

        private void DataGridViewResults_SelectionChanged(object sender, EventArgs e)
        {
            Highligth_From_Results();

        }

        private async void ButtonListAll_Click(object sender, EventArgs e)
        {

            if (comboBoxCategories_SearchTab.SelectedIndex != 0)
            {
                await SearchByCategory();
                Pre_Load_Done = false;
                labelNumberResults.Visible = true;
            }
            else
            {
                MessageBox.Show("Select a category");
            }
        }

        private void ComboBoxCategory_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(comboBoxCategories_RegisterTab.Text) || comboBoxCategories_RegisterTab.Text == comboBoxCategories_RegisterTab.Items[0].ToString())
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

        private void TextBoxDescription_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxDescription.Text))
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

        private void TextBoxQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxDrawer.Text))
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

        private void ReLoad_Fields()
        {
            comboBoxCategories_RegisterTab.Text = comboBoxCategories_RegisterTab.Items[0].ToString();
            textBoxDescription.Text = String.Empty;
            textBoxDrawer.Text = String.Empty;

            _firebaseRepositorie.Load_Firebase_Database();

            FIll_ComboBox_Category();

            SearchByDescription(textBoxSearch.Text);
        }

        private void Highlight_Drawer_From_Box_Selection()
        {
            foreach (dynamic key in _firebaseRepositorie.JSON_Firebase.Keys)
            {
                foreach (dynamic key2 in _firebaseRepositorie.JSON_Firebase[key].Keys)
                {
                    if (_firebaseRepositorie.JSON_Firebase[key][key2]["Box"] == Current_Selected_Box)
                    {
                        switch (_firebaseRepositorie.JSON_Firebase[key][key2]["Drawer"])
                        {

                        }

                    }
                }
            }
        }

        private void ButtonSave_Click_1(object sender, EventArgs e)
        {


            if (validatedCategory && validatedDescription && validatedDrawer)
            {
                string category = comboBoxCategories_RegisterTab.Text.ToUpper();
                string description = textBoxDescription.Text;
                string drawer = textBoxDrawer.Text;
                _firebaseRepositorie.Push_New_Component(category, description, drawer);
                ReLoad_Fields();
                Pre_Load_Done = false;
            }
            else
            {
                MessageBox.Show("Fill all fields!");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
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
                _localRepositorie.SaveData(new Led() {

                    Color = buttonColor.BackColor,
                    Time = trackBarTime.Value,
                    Brightness = trackBarBright.Value
                });
            }
        }

        private void ButtonColor_Click(object sender, EventArgs e)
        {

            colorDialog1.AllowFullOpen = false;
            colorDialog1.ShowHelp = true;
            colorDialog1.Color = buttonSettings.ForeColor;




            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Led.Color = colorDialog1.Color;
                buttonColor.BackColor = Led.Color;
            }
        }

        private void TrackBarTime_Scroll(object sender, EventArgs e)
        {
            Led.Time = trackBarTime.Value;

            if (trackBarTime.Value < 1000)
            {
                labelTime.Text = trackBarTime.Value < 100 ? "always on" : trackBarTime.Value + "ms blinky";
            }

            else
            {
                labelTime.Text = "1s blinky";
            }
        }

        private void TrackBarBright_Scroll(object sender, EventArgs e)
        {
            Led.Brightness = trackBarBright.Value;

            int x = (trackBarBright.Value * 100) / 255;
            labelBright.Text = x + "% brightness";
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string category = "";
                if (dataGridViewSearch.SelectedCells.Count > 0)
                {
                    category = dataGridViewSearch.SelectedCells[0].Value.ToString();
                }

                string drawer = "";
                if (dataGridViewSearch.SelectedCells.Count > 0)
                {
                    drawer = dataGridViewSearch.SelectedCells[2].Value.ToString();
                }

                string description = "";
                if (dataGridViewSearch.SelectedCells.Count > 0)
                {
                    description = dataGridViewSearch.SelectedCells[1].Value.ToString();
                }

                Form2 f2 = new Form2();
                DialogResult result = f2.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string _category = f2.Category;
                    string _drawer = f2.Drawer;
                    string _description = f2.Description;

                    if (category != _category || drawer != _drawer)
                    {
                        _firebaseRepositorie.DeleteComponent(drawer);
                        _firebaseRepositorie.Push_New_Component(_category, _description, _drawer);
                    }
                    else
                    {
                        _firebaseRepositorie.UpdateComponent(_drawer, _description);
                    }

                    Pre_Load_Done = false;
                    ReLoad_Fields();
                }
            }
            catch
            {

            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewSearch.SelectedCells.Count > 0)
            {
                string drawer = dataGridViewSearch.SelectedCells[2].Value.ToString();
                _firebaseRepositorie.DeleteComponent(drawer);
                ReLoad_Fields();
            }

            Pre_Load_Done = false;
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            _firebaseRepositorie.SetHardwareDevice("-1,0,0,0,0,0");
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
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
                _localRepositorie.SaveData(new Led() {

                    Color = buttonColor.BackColor,
                    Time = trackBarTime.Value,
                    Brightness = trackBarBright.Value
                });
            }

            Highligth_From_Results();
        }

        private void ButtonColor_Click_1(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = false;
            colorDialog1.ShowHelp = true;
            colorDialog1.Color = buttonSettings.ForeColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Led.Color = colorDialog1.Color;
                buttonColor.BackColor = Led.Color;
            }
        }

        private void TrackBarTime_Scroll_1(object sender, EventArgs e)
        {
            Led.Time = trackBarTime.Value;

            if (trackBarTime.Value < 1000)
            {
                labelTime.Text = trackBarTime.Value < 100 ? "always on" : trackBarTime.Value + "ms blinky";
            }

            else
            {
                labelTime.Text = "1s blinky";
            }
        }

        private void TrackBarBright_Scroll_1(object sender, EventArgs e)
        {
            Led.Brightness = trackBarBright.Value;

            int x = (trackBarBright.Value * 100) / 255;
            if (x <= 0)
            {
                x = 1;
            }

            if (Led.Brightness <= 0)
            {
                Led.Brightness = 1;
            }

            labelBright.Text = x + "% brightness";
        }

        private void ButtonClear_Click_1(object sender, EventArgs e)
        {
            _firebaseRepositorie.SetHardwareDevice("-1,0,0,0,0,0");
            dataGridViewSearch.Rows.Clear();
            labelNumberResults.Visible = false;
        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void ButtonShow_Click_1(object sender, EventArgs e)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server.Send(client, "This is a test<EOF>");
        }

        private void ButtonFirebase_Save_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxFirebase_URL.Text) && !String.IsNullOrEmpty(textBoxFirebase_Key.Text))
            {
                _authenticationBusiness.SaveSecrets(textBoxFirebase_URL.Text, textBoxFirebase_Key.Text);
            }
        }

        private void ButtonShow_Click_2(object sender, EventArgs e)
        {
            if (buttonShow.Text == "Show")
            {
                textBoxFirebase_Key.Text = ""; //Firebase_Database_KEY;
                textBoxFirebase_Key.PasswordChar = '\0';
                buttonShow.Text = "Hide";
            }
            else
            {
                textBoxFirebase_Key.PasswordChar = '*';
                buttonShow.Text = "Show";
            }
        }

        private void ButtonGetFileAddress_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFileLocation.Text = openFileDialog1.FileName;
                BatcFileLocation = openFileDialog1.FileName;
            }
        }

        private void ButtonSaveFromFile_Click(object sender, EventArgs e)
        {
            _ = System.IO.File.ReadAllText(@BatcFileLocation);
            string[] lines = System.IO.File.ReadAllLines(@BatcFileLocation);

            string category = String.Empty;
            string description = String.Empty;
            string drawer = String.Empty;
            int totalParts = 0;

            progressBar1.Visible = true;
            progressBar1.Maximum = lines.Length;

            try
            {
                foreach (string l in lines)
                {
                    string[] words = l.Split(',');

                    int index = 0;
                    foreach (string w in words)
                    {
                        switch (index++)
                        {
                            case 0: category = w; break;
                            case 1: description = w; break;
                            case 2: drawer = w; break;
                        }
                    }
                    _firebaseRepositorie.Push_New_Component(category.ToUpper(), description, drawer);
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
