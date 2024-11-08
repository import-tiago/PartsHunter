
namespace PartsHunter
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            buttonDelete = new Button();
            buttonClear = new Button();
            buttonEdit = new Button();
            groupBoxSettings = new GroupBox();
            labelBright = new Label();
            trackBarBright = new TrackBar();
            labelTime = new Label();
            trackBarTime = new TrackBar();
            buttonColor = new Button();
            buttonSettings = new Button();
            buttonListAll = new Button();
            comboBoxCategories_SearchTab = new ComboBox();
            label1 = new Label();
            labelNumberResults = new Label();
            buttonSearch = new Button();
            label2 = new Label();
            textBoxSearch = new TextBox();
            groupBox6 = new GroupBox();
            dataGridViewSearch = new DataGridView();
            _Category = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Drawer = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            groupBox2 = new GroupBox();
            label10 = new Label();
            label9 = new Label();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            buttonSaveFromFile = new Button();
            buttonGetFileAddress = new Button();
            textBoxFileLocation = new TextBox();
            label8 = new Label();
            groupBox1 = new GroupBox();
            buttonSave = new Button();
            comboBoxCategories_RegisterTab = new ComboBox();
            label3 = new Label();
            textBoxDescription = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBoxDrawer = new TextBox();
            tabPage3 = new TabPage();
            buttonShow = new Button();
            textBoxFirebase_URL = new TextBox();
            label6 = new Label();
            buttonFirebase_Save = new Button();
            label7 = new Label();
            textBoxFirebase_Key = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            colorDialog1 = new ColorDialog();
            openFileDialog1 = new OpenFileDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarBright).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTime).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSearch).BeginInit();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 14);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(835, 813);
            tabControl1.TabIndex = 35;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(buttonDelete);
            tabPage1.Controls.Add(buttonClear);
            tabPage1.Controls.Add(buttonEdit);
            tabPage1.Controls.Add(groupBoxSettings);
            tabPage1.Controls.Add(buttonSettings);
            tabPage1.Controls.Add(buttonListAll);
            tabPage1.Controls.Add(comboBoxCategories_SearchTab);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(labelNumberResults);
            tabPage1.Controls.Add(buttonSearch);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(textBoxSearch);
            tabPage1.Controls.Add(groupBox6);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 3, 4, 3);
            tabPage1.Size = new Size(827, 785);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Search";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Location = new Point(676, 710);
            buttonDelete.Margin = new Padding(4, 3, 4, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(134, 27);
            buttonDelete.TabIndex = 72;
            buttonDelete.Text = "DELETE";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.Location = new Point(676, 744);
            buttonClear.Margin = new Padding(4, 3, 4, 3);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(134, 27);
            buttonClear.TabIndex = 56;
            buttonClear.Text = "Clear All";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Location = new Point(542, 710);
            buttonEdit.Margin = new Padding(4, 3, 4, 3);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(134, 27);
            buttonEdit.TabIndex = 71;
            buttonEdit.Text = "EDIT";
            buttonEdit.UseVisualStyleBackColor = true;
            // 
            // groupBoxSettings
            // 
            groupBoxSettings.Controls.Add(labelBright);
            groupBoxSettings.Controls.Add(trackBarBright);
            groupBoxSettings.Controls.Add(labelTime);
            groupBoxSettings.Controls.Add(trackBarTime);
            groupBoxSettings.Controls.Add(buttonColor);
            groupBoxSettings.Location = new Point(9, 704);
            groupBoxSettings.Margin = new Padding(4, 3, 4, 3);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Padding = new Padding(4, 3, 4, 3);
            groupBoxSettings.Size = new Size(523, 67);
            groupBoxSettings.TabIndex = 70;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Settings";
            groupBoxSettings.Visible = false;
            // 
            // labelBright
            // 
            labelBright.AutoSize = true;
            labelBright.Location = new Point(436, 31);
            labelBright.Margin = new Padding(4, 0, 4, 0);
            labelBright.Name = "labelBright";
            labelBright.Size = new Size(75, 15);
            labelBright.TabIndex = 60;
            labelBright.Text = "% brightness";
            // 
            // trackBarBright
            // 
            trackBarBright.AutoSize = false;
            trackBarBright.BackColor = SystemColors.Window;
            trackBarBright.Location = new Point(313, 28);
            trackBarBright.Margin = new Padding(4, 3, 4, 3);
            trackBarBright.Maximum = 255;
            trackBarBright.Name = "trackBarBright";
            trackBarBright.Size = new Size(117, 29);
            trackBarBright.TabIndex = 59;
            trackBarBright.TickStyle = TickStyle.None;
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Location = new Point(245, 31);
            labelTime.Margin = new Padding(4, 0, 4, 0);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(58, 15);
            labelTime.TabIndex = 58;
            labelTime.Text = "ms blinky";
            // 
            // trackBarTime
            // 
            trackBarTime.AutoSize = false;
            trackBarTime.BackColor = SystemColors.Window;
            trackBarTime.LargeChange = 50;
            trackBarTime.Location = new Point(117, 28);
            trackBarTime.Margin = new Padding(4, 3, 4, 3);
            trackBarTime.Maximum = 1000;
            trackBarTime.Name = "trackBarTime";
            trackBarTime.Size = new Size(117, 29);
            trackBarTime.SmallChange = 50;
            trackBarTime.TabIndex = 57;
            trackBarTime.TickStyle = TickStyle.None;
            // 
            // buttonColor
            // 
            buttonColor.FlatStyle = FlatStyle.Flat;
            buttonColor.Location = new Point(7, 28);
            buttonColor.Margin = new Padding(4, 3, 4, 3);
            buttonColor.Name = "buttonColor";
            buttonColor.Size = new Size(106, 27);
            buttonColor.TabIndex = 55;
            buttonColor.Text = "COLOR";
            buttonColor.UseVisualStyleBackColor = true;
            // 
            // buttonSettings
            // 
            buttonSettings.FlatStyle = FlatStyle.Flat;
            buttonSettings.Location = new Point(542, 744);
            buttonSettings.Margin = new Padding(4, 3, 4, 3);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(134, 27);
            buttonSettings.TabIndex = 69;
            buttonSettings.Text = "Config Highlight";
            buttonSettings.UseVisualStyleBackColor = true;
            // 
            // buttonListAll
            // 
            buttonListAll.FlatStyle = FlatStyle.System;
            buttonListAll.Location = new Point(695, 15);
            buttonListAll.Margin = new Padding(4, 3, 4, 3);
            buttonListAll.Name = "buttonListAll";
            buttonListAll.Size = new Size(124, 27);
            buttonListAll.TabIndex = 68;
            buttonListAll.Text = "List All";
            buttonListAll.UseVisualStyleBackColor = true;
            // 
            // comboBoxCategories_SearchTab
            // 
            comboBoxCategories_SearchTab.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategories_SearchTab.Items.AddRange(new object[] { "<Select One>" });
            comboBoxCategories_SearchTab.Location = new Point(84, 17);
            comboBoxCategories_SearchTab.Margin = new Padding(4, 3, 4, 3);
            comboBoxCategories_SearchTab.Name = "comboBoxCategories_SearchTab";
            comboBoxCategories_SearchTab.Size = new Size(602, 23);
            comboBoxCategories_SearchTab.TabIndex = 67;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 21);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 66;
            label1.Text = "Category:";
            // 
            // labelNumberResults
            // 
            labelNumberResults.AutoSize = true;
            labelNumberResults.ForeColor = Color.Red;
            labelNumberResults.Location = new Point(80, 77);
            labelNumberResults.Margin = new Padding(4, 0, 4, 0);
            labelNumberResults.Name = "labelNumberResults";
            labelNumberResults.Size = new Size(147, 15);
            labelNumberResults.TabIndex = 59;
            labelNumberResults.Text = "<Number's results found>";
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.PaleTurquoise;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("Microsoft New Tai Lue", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSearch.Location = new Point(695, 48);
            buttonSearch.Margin = new Padding(4, 3, 4, 3);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(124, 27);
            buttonSearch.TabIndex = 58;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 54);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 57;
            label2.Text = "Description";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(84, 51);
            textBoxSearch.Margin = new Padding(4, 3, 4, 3);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(602, 23);
            textBoxSearch.TabIndex = 56;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(dataGridViewSearch);
            groupBox6.Location = new Point(9, 117);
            groupBox6.Margin = new Padding(4, 3, 4, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(4, 3, 4, 3);
            groupBox6.Size = new Size(810, 570);
            groupBox6.TabIndex = 44;
            groupBox6.TabStop = false;
            groupBox6.Text = "RESULTS";
            // 
            // dataGridViewSearch
            // 
            dataGridViewSearch.AllowUserToResizeRows = false;
            dataGridViewSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSearch.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSearch.Columns.AddRange(new DataGridViewColumn[] { _Category, Description, Drawer });
            dataGridViewSearch.Dock = DockStyle.Fill;
            dataGridViewSearch.Location = new Point(4, 19);
            dataGridViewSearch.Margin = new Padding(4, 3, 4, 3);
            dataGridViewSearch.MultiSelect = false;
            dataGridViewSearch.Name = "dataGridViewSearch";
            dataGridViewSearch.ReadOnly = true;
            dataGridViewSearch.RowHeadersVisible = false;
            dataGridViewSearch.RowHeadersWidth = 51;
            dataGridViewSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSearch.Size = new Size(802, 548);
            dataGridViewSearch.TabIndex = 0;
            // 
            // _Category
            // 
            _Category.HeaderText = "Category";
            _Category.MinimumWidth = 6;
            _Category.Name = "_Category";
            _Category.ReadOnly = true;
            // 
            // Description
            // 
            Description.HeaderText = "Description";
            Description.MinimumWidth = 6;
            Description.Name = "Description";
            Description.ReadOnly = true;
            // 
            // Drawer
            // 
            Drawer.HeaderText = "Drawer";
            Drawer.MinimumWidth = 6;
            Drawer.Name = "Drawer";
            Drawer.ReadOnly = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(4, 3, 4, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 3, 4, 3);
            tabPage2.Size = new Size(827, 785);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Register";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Controls.Add(progressBar1);
            groupBox2.Controls.Add(buttonSaveFromFile);
            groupBox2.Controls.Add(buttonGetFileAddress);
            groupBox2.Controls.Add(textBoxFileLocation);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(9, 257);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(810, 405);
            groupBox2.TabIndex = 72;
            groupBox2.TabStop = false;
            groupBox2.Text = "BATCH REGISTRATION";
            // 
            // label10
            // 
            label10.Location = new Point(481, 143);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(352, 189);
            label10.TabIndex = 77;
            label10.Text = resources.GetString("label10.Text");
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 125);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(54, 15);
            label9.TabIndex = 76;
            label9.Text = "Example:";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(9, 143);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(464, 243);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 75;
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(88, 53);
            progressBar1.Margin = new Padding(2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(680, 9);
            progressBar1.TabIndex = 74;
            progressBar1.Visible = false;
            // 
            // buttonSaveFromFile
            // 
            buttonSaveFromFile.BackColor = Color.LightSkyBlue;
            buttonSaveFromFile.FlatStyle = FlatStyle.Flat;
            buttonSaveFromFile.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSaveFromFile.Location = new Point(88, 69);
            buttonSaveFromFile.Margin = new Padding(4, 3, 4, 3);
            buttonSaveFromFile.Name = "buttonSaveFromFile";
            buttonSaveFromFile.Size = new Size(97, 31);
            buttonSaveFromFile.TabIndex = 72;
            buttonSaveFromFile.Text = "SAVE";
            buttonSaveFromFile.UseVisualStyleBackColor = false;
            // 
            // buttonGetFileAddress
            // 
            buttonGetFileAddress.Location = new Point(774, 27);
            buttonGetFileAddress.Margin = new Padding(2);
            buttonGetFileAddress.Name = "buttonGetFileAddress";
            buttonGetFileAddress.Size = new Size(29, 22);
            buttonGetFileAddress.TabIndex = 73;
            buttonGetFileAddress.Text = "...";
            buttonGetFileAddress.UseVisualStyleBackColor = true;
            // 
            // textBoxFileLocation
            // 
            textBoxFileLocation.Location = new Point(88, 27);
            textBoxFileLocation.Margin = new Padding(4, 3, 4, 3);
            textBoxFileLocation.Name = "textBoxFileLocation";
            textBoxFileLocation.Size = new Size(681, 23);
            textBoxFileLocation.TabIndex = 72;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 29);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(77, 15);
            label8.TabIndex = 54;
            label8.Text = "File Location:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonSave);
            groupBox1.Controls.Add(comboBoxCategories_RegisterTab);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxDescription);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(textBoxDrawer);
            groupBox1.Location = new Point(9, 7);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(810, 207);
            groupBox1.TabIndex = 67;
            groupBox1.TabStop = false;
            groupBox1.Text = "PART INFORMATION";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.PaleTurquoise;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSave.Location = new Point(88, 153);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(97, 31);
            buttonSave.TabIndex = 71;
            buttonSave.Text = "SAVE";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // comboBoxCategories_RegisterTab
            // 
            comboBoxCategories_RegisterTab.FormattingEnabled = true;
            comboBoxCategories_RegisterTab.Items.AddRange(new object[] { "<Select one or type a new one>" });
            comboBoxCategories_RegisterTab.Location = new Point(88, 23);
            comboBoxCategories_RegisterTab.Margin = new Padding(4, 3, 4, 3);
            comboBoxCategories_RegisterTab.Name = "comboBoxCategories_RegisterTab";
            comboBoxCategories_RegisterTab.Size = new Size(716, 23);
            comboBoxCategories_RegisterTab.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 27);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 54;
            label3.Text = "Category:";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(88, 68);
            textBoxDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(716, 23);
            textBoxDescription.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 72);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 58;
            label4.Text = "Description:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 117);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 60;
            label5.Text = "Drawer N°:";
            // 
            // textBoxDrawer
            // 
            textBoxDrawer.Location = new Point(88, 113);
            textBoxDrawer.Margin = new Padding(4, 3, 4, 3);
            textBoxDrawer.Name = "textBoxDrawer";
            textBoxDrawer.Size = new Size(716, 23);
            textBoxDrawer.TabIndex = 3;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(buttonShow);
            tabPage3.Controls.Add(textBoxFirebase_URL);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(buttonFirebase_Save);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(textBoxFirebase_Key);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(2);
            tabPage3.Size = new Size(827, 785);
            tabPage3.TabIndex = 3;
            tabPage3.Text = "Firebase Config";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonShow
            // 
            buttonShow.Location = new Point(691, 53);
            buttonShow.Margin = new Padding(2);
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new Size(65, 22);
            buttonShow.TabIndex = 72;
            buttonShow.Text = "Show";
            buttonShow.UseVisualStyleBackColor = true;
            // 
            // textBoxFirebase_URL
            // 
            textBoxFirebase_URL.Location = new Point(107, 20);
            textBoxFirebase_URL.Margin = new Padding(4, 3, 4, 3);
            textBoxFirebase_URL.Name = "textBoxFirebase_URL";
            textBoxFirebase_URL.Size = new Size(578, 23);
            textBoxFirebase_URL.TabIndex = 71;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 23);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(82, 15);
            label6.TabIndex = 70;
            label6.Text = "Database URL:";
            // 
            // buttonFirebase_Save
            // 
            buttonFirebase_Save.BackColor = Color.PaleTurquoise;
            buttonFirebase_Save.FlatStyle = FlatStyle.Flat;
            buttonFirebase_Save.Font = new Font("Microsoft New Tai Lue", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonFirebase_Save.Location = new Point(561, 81);
            buttonFirebase_Save.Margin = new Padding(4, 3, 4, 3);
            buttonFirebase_Save.Name = "buttonFirebase_Save";
            buttonFirebase_Save.Size = new Size(124, 27);
            buttonFirebase_Save.TabIndex = 69;
            buttonFirebase_Save.Text = "SAVE";
            buttonFirebase_Save.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 55);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(80, 15);
            label7.TabIndex = 68;
            label7.Text = "Database Key:";
            // 
            // textBoxFirebase_Key
            // 
            textBoxFirebase_Key.Location = new Point(107, 53);
            textBoxFirebase_Key.Margin = new Padding(4, 3, 4, 3);
            textBoxFirebase_Key.Name = "textBoxFirebase_Key";
            textBoxFirebase_Key.PasswordChar = '*';
            textBoxFirebase_Key.Size = new Size(578, 23);
            textBoxFirebase_Key.TabIndex = 67;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 830);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PartsHunter";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBoxSettings.ResumeLayout(false);
            groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarBright).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTime).EndInit();
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSearch).EndInit();
            tabPage2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label labelNumberResults;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDrawer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCategories_RegisterTab;
        private System.Windows.Forms.DataGridView dataGridViewSearch;
        private System.Windows.Forms.Button buttonListAll;
        private System.Windows.Forms.ComboBox comboBoxCategories_SearchTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label labelBright;
        private System.Windows.Forms.TrackBar trackBarBright;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TrackBar trackBarTime;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drawer;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBoxFirebase_URL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonFirebase_Save;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxFirebase_Key;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSaveFromFile;
        private System.Windows.Forms.Button buttonGetFileAddress;
        private System.Windows.Forms.TextBox textBoxFileLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}

