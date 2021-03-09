
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btCOMConnect = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.labelBright = new System.Windows.Forms.Label();
            this.trackBarBright = new System.Windows.Forms.TrackBar();
            this.labelTime = new System.Windows.Forms.Label();
            this.trackBarTime = new System.Windows.Forms.TrackBar();
            this.buttonColor = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonListAll = new System.Windows.Forms.Button();
            this.comboBoxSearchCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNumberResults = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drawer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxCurrentLocation = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewRegisteredParts = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelNumberResults2 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.buttonFindCurrentLocation = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDrawer = new System.Windows.Forms.TextBox();
            this.groupBoxParts = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.dataGridViewCurrentParts = new System.Windows.Forms.DataGridView();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Drawer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.timerCOM = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBoxCurrentLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegisteredParts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrentParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1480, 837);
            this.tabControl1.TabIndex = 35;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.buttonClear);
            this.tabPage1.Controls.Add(this.groupBoxSettings);
            this.tabPage1.Controls.Add(this.buttonSettings);
            this.tabPage1.Controls.Add(this.buttonListAll);
            this.tabPage1.Controls.Add(this.comboBoxSearchCategory);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.labelNumberResults);
            this.tabPage1.Controls.Add(this.buttonSearch);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBoxSearch);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1472, 808);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Search";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btCOMConnect);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(1142, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 72);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection";
            // 
            // btCOMConnect
            // 
            this.btCOMConnect.BackColor = System.Drawing.Color.LightGreen;
            this.btCOMConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCOMConnect.Location = new System.Drawing.Point(196, 22);
            this.btCOMConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btCOMConnect.Name = "btCOMConnect";
            this.btCOMConnect.Size = new System.Drawing.Size(107, 28);
            this.btCOMConnect.TabIndex = 55;
            this.btCOMConnect.Text = "Connect";
            this.btCOMConnect.UseVisualStyleBackColor = false;
            this.btCOMConnect.Click += new System.EventHandler(this.btConectar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(104, 24);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(84, 24);
            this.comboBox1.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 54;
            this.label6.Text = "Porta COM:";
            // 
            // buttonClear
            // 
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(1303, 745);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(153, 28);
            this.buttonClear.TabIndex = 56;
            this.buttonClear.Text = "Clear All";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click_1);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.labelBright);
            this.groupBoxSettings.Controls.Add(this.trackBarBright);
            this.groupBoxSettings.Controls.Add(this.labelTime);
            this.groupBoxSettings.Controls.Add(this.trackBarTime);
            this.groupBoxSettings.Controls.Add(this.buttonColor);
            this.groupBoxSettings.Location = new System.Drawing.Point(11, 737);
            this.groupBoxSettings.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxSettings.Size = new System.Drawing.Size(1123, 59);
            this.groupBoxSettings.TabIndex = 70;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            this.groupBoxSettings.Visible = false;
            // 
            // labelBright
            // 
            this.labelBright.AutoSize = true;
            this.labelBright.Location = new System.Drawing.Point(797, 23);
            this.labelBright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBright.Name = "labelBright";
            this.labelBright.Size = new System.Drawing.Size(90, 17);
            this.labelBright.TabIndex = 60;
            this.labelBright.Text = "% brightness";
            // 
            // trackBarBright
            // 
            this.trackBarBright.AutoSize = false;
            this.trackBarBright.BackColor = System.Drawing.SystemColors.Window;
            this.trackBarBright.Location = new System.Drawing.Point(656, 20);
            this.trackBarBright.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarBright.Maximum = 255;
            this.trackBarBright.Name = "trackBarBright";
            this.trackBarBright.Size = new System.Drawing.Size(133, 31);
            this.trackBarBright.TabIndex = 59;
            this.trackBarBright.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarBright.Scroll += new System.EventHandler(this.trackBarBright_Scroll_1);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(492, 23);
            this.labelTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(66, 17);
            this.labelTime.TabIndex = 58;
            this.labelTime.Text = "ms blinky";
            // 
            // trackBarTime
            // 
            this.trackBarTime.AutoSize = false;
            this.trackBarTime.BackColor = System.Drawing.SystemColors.Window;
            this.trackBarTime.LargeChange = 50;
            this.trackBarTime.Location = new System.Drawing.Point(345, 20);
            this.trackBarTime.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarTime.Maximum = 1000;
            this.trackBarTime.Name = "trackBarTime";
            this.trackBarTime.Size = new System.Drawing.Size(133, 31);
            this.trackBarTime.SmallChange = 50;
            this.trackBarTime.TabIndex = 57;
            this.trackBarTime.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarTime.Scroll += new System.EventHandler(this.trackBarTime_Scroll_1);
            // 
            // buttonColor
            // 
            this.buttonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColor.Location = new System.Drawing.Point(101, 20);
            this.buttonColor.Margin = new System.Windows.Forms.Padding(4);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(121, 28);
            this.buttonColor.TabIndex = 55;
            this.buttonColor.Text = "COLOR";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click_1);
            // 
            // buttonSettings
            // 
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Location = new System.Drawing.Point(1142, 745);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(153, 28);
            this.buttonSettings.TabIndex = 69;
            this.buttonSettings.Text = "Config Highlight";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonListAll
            // 
            this.buttonListAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonListAll.Location = new System.Drawing.Point(595, 16);
            this.buttonListAll.Margin = new System.Windows.Forms.Padding(4);
            this.buttonListAll.Name = "buttonListAll";
            this.buttonListAll.Size = new System.Drawing.Size(141, 28);
            this.buttonListAll.TabIndex = 68;
            this.buttonListAll.Text = "List All";
            this.buttonListAll.UseVisualStyleBackColor = true;
            this.buttonListAll.Click += new System.EventHandler(this.buttonListAll_Click);
            // 
            // comboBoxSearchCategory
            // 
            this.comboBoxSearchCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchCategory.Items.AddRange(new object[] {
            "<Select One>"});
            this.comboBoxSearchCategory.Location = new System.Drawing.Point(96, 18);
            this.comboBoxSearchCategory.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSearchCategory.Name = "comboBoxSearchCategory";
            this.comboBoxSearchCategory.Size = new System.Drawing.Size(489, 24);
            this.comboBoxSearchCategory.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 66;
            this.label1.Text = "Category:";
            // 
            // labelNumberResults
            // 
            this.labelNumberResults.AutoSize = true;
            this.labelNumberResults.ForeColor = System.Drawing.Color.Red;
            this.labelNumberResults.Location = new System.Drawing.Point(92, 82);
            this.labelNumberResults.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumberResults.Name = "labelNumberResults";
            this.labelNumberResults.Size = new System.Drawing.Size(170, 17);
            this.labelNumberResults.TabIndex = 59;
            this.labelNumberResults.Text = "<Number\'s results found>";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Location = new System.Drawing.Point(595, 51);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(141, 28);
            this.buttonSearch.TabIndex = 58;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 57;
            this.label2.Text = "Description";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(96, 54);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(489, 22);
            this.textBoxSearch.TabIndex = 56;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridViewResults);
            this.groupBox6.Location = new System.Drawing.Point(8, 124);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(1452, 608);
            this.groupBox6.TabIndex = 44;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "RESULTS";
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.AllowUserToResizeRows = false;
            this.dataGridViewResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewResults.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description,
            this.Drawer});
            this.dataGridViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewResults.Location = new System.Drawing.Point(4, 19);
            this.dataGridViewResults.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewResults.MultiSelect = false;
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.ReadOnly = true;
            this.dataGridViewResults.RowHeadersVisible = false;
            this.dataGridViewResults.RowHeadersWidth = 51;
            this.dataGridViewResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewResults.Size = new System.Drawing.Size(1444, 585);
            this.dataGridViewResults.TabIndex = 0;
            this.dataGridViewResults.SelectionChanged += new System.EventHandler(this.dataGridViewResults_SelectionChanged);
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Drawer
            // 
            this.Drawer.HeaderText = "Drawer";
            this.Drawer.MinimumWidth = 6;
            this.Drawer.Name = "Drawer";
            this.Drawer.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxCurrentLocation);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupBoxParts);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1472, 808);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Register";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxCurrentLocation
            // 
            this.groupBoxCurrentLocation.Controls.Add(this.label7);
            this.groupBoxCurrentLocation.Controls.Add(this.dataGridViewRegisteredParts);
            this.groupBoxCurrentLocation.Location = new System.Drawing.Point(687, 7);
            this.groupBoxCurrentLocation.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxCurrentLocation.Name = "groupBoxCurrentLocation";
            this.groupBoxCurrentLocation.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxCurrentLocation.Size = new System.Drawing.Size(764, 202);
            this.groupBoxCurrentLocation.TabIndex = 68;
            this.groupBoxCurrentLocation.TabStop = false;
            this.groupBoxCurrentLocation.Text = "CURRENT LOCATION";
            this.groupBoxCurrentLocation.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.ForestGreen;
            this.label7.Location = new System.Drawing.Point(275, 182);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(230, 17);
            this.label7.TabIndex = 62;
            this.label7.Text = "double-click on the item to highlight";
            // 
            // dataGridViewRegisteredParts
            // 
            this.dataGridViewRegisteredParts.AllowUserToResizeRows = false;
            this.dataGridViewRegisteredParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRegisteredParts.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewRegisteredParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegisteredParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn7});
            this.dataGridViewRegisteredParts.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewRegisteredParts.Location = new System.Drawing.Point(4, 19);
            this.dataGridViewRegisteredParts.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewRegisteredParts.MultiSelect = false;
            this.dataGridViewRegisteredParts.Name = "dataGridViewRegisteredParts";
            this.dataGridViewRegisteredParts.ReadOnly = true;
            this.dataGridViewRegisteredParts.RowHeadersVisible = false;
            this.dataGridViewRegisteredParts.RowHeadersWidth = 51;
            this.dataGridViewRegisteredParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRegisteredParts.Size = new System.Drawing.Size(756, 159);
            this.dataGridViewRegisteredParts.TabIndex = 0;
            this.dataGridViewRegisteredParts.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewRegisteredParts_CellMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Description";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Drawer";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.labelNumberResults2);
            this.groupBox1.Controls.Add(this.comboBoxCategory);
            this.groupBox1.Controls.Add(this.buttonFindCurrentLocation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxDrawer);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(667, 202);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PART INFORMATION";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(344, 154);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(111, 33);
            this.buttonSave.TabIndex = 71;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            // 
            // labelNumberResults2
            // 
            this.labelNumberResults2.AutoSize = true;
            this.labelNumberResults2.ForeColor = System.Drawing.Color.Red;
            this.labelNumberResults2.Location = new System.Drawing.Point(491, 102);
            this.labelNumberResults2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumberResults2.Name = "labelNumberResults2";
            this.labelNumberResults2.Size = new System.Drawing.Size(170, 17);
            this.labelNumberResults2.TabIndex = 61;
            this.labelNumberResults2.Text = "<Number\'s results found>";
            this.labelNumberResults2.Visible = false;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "<Select one or type a new one>"});
            this.comboBoxCategory.Location = new System.Drawing.Point(100, 25);
            this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(353, 24);
            this.comboBoxCategory.TabIndex = 0;
            this.comboBoxCategory.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxCategory_Validating);
            // 
            // buttonFindCurrentLocation
            // 
            this.buttonFindCurrentLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonFindCurrentLocation.Location = new System.Drawing.Point(491, 70);
            this.buttonFindCurrentLocation.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFindCurrentLocation.Name = "buttonFindCurrentLocation";
            this.buttonFindCurrentLocation.Size = new System.Drawing.Size(168, 28);
            this.buttonFindCurrentLocation.TabIndex = 4;
            this.buttonFindCurrentLocation.Text = "Find Current Location";
            this.buttonFindCurrentLocation.UseVisualStyleBackColor = true;
            this.buttonFindCurrentLocation.Click += new System.EventHandler(this.buttonFindCurrentLocation_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Category:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(100, 73);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(353, 22);
            this.textBoxDescription.TabIndex = 1;
            this.textBoxDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDescription_KeyDown);
            this.textBoxDescription.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDescription_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 58;
            this.label4.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 60;
            this.label5.Text = "Drawer N°:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBoxDrawer
            // 
            this.textBoxDrawer.Location = new System.Drawing.Point(100, 121);
            this.textBoxDrawer.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDrawer.Name = "textBoxDrawer";
            this.textBoxDrawer.Size = new System.Drawing.Size(353, 22);
            this.textBoxDrawer.TabIndex = 3;
            this.textBoxDrawer.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxQuantity_Validating);
            // 
            // groupBoxParts
            // 
            this.groupBoxParts.Controls.Add(this.buttonDelete);
            this.groupBoxParts.Controls.Add(this.buttonEdit);
            this.groupBoxParts.Controls.Add(this.dataGridViewCurrentParts);
            this.groupBoxParts.Location = new System.Drawing.Point(12, 217);
            this.groupBoxParts.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxParts.Name = "groupBoxParts";
            this.groupBoxParts.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxParts.Size = new System.Drawing.Size(1439, 568);
            this.groupBoxParts.TabIndex = 37;
            this.groupBoxParts.TabStop = false;
            this.groupBoxParts.Text = "CURRENT PARTS IN THE BOX";
            // 
            // buttonDelete
            // 
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Location = new System.Drawing.Point(197, 516);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(193, 31);
            this.buttonDelete.TabIndex = 69;
            this.buttonDelete.Text = "DELETE";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Location = new System.Drawing.Point(4, 516);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(195, 31);
            this.buttonEdit.TabIndex = 68;
            this.buttonEdit.Text = "EDIT";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // dataGridViewCurrentParts
            // 
            this.dataGridViewCurrentParts.AllowUserToResizeRows = false;
            this.dataGridViewCurrentParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCurrentParts.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewCurrentParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCurrentParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Category,
            this.dataGridViewTextBoxColumn1,
            this._Drawer});
            this.dataGridViewCurrentParts.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewCurrentParts.Location = new System.Drawing.Point(4, 19);
            this.dataGridViewCurrentParts.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewCurrentParts.MultiSelect = false;
            this.dataGridViewCurrentParts.Name = "dataGridViewCurrentParts";
            this.dataGridViewCurrentParts.ReadOnly = true;
            this.dataGridViewCurrentParts.RowHeadersVisible = false;
            this.dataGridViewCurrentParts.RowHeadersWidth = 51;
            this.dataGridViewCurrentParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCurrentParts.Size = new System.Drawing.Size(1431, 497);
            this.dataGridViewCurrentParts.TabIndex = 1;
            this.dataGridViewCurrentParts.SelectionChanged += new System.EventHandler(this.dataGridViewCurrentParts_SelectionChanged);
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // _Drawer
            // 
            this._Drawer.HeaderText = "Drawer";
            this._Drawer.MinimumWidth = 6;
            this._Drawer.Name = "_Drawer";
            this._Drawer.ReadOnly = true;
            // 
            // SerialPort
            // 
            this.SerialPort.BaudRate = 115200;
            this.SerialPort.PortName = "COM5";
            this.SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // timerCOM
            // 
            this.timerCOM.Interval = 1000;
            this.timerCOM.Tick += new System.EventHandler(this.timerCOM_Tick_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1477, 847);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PartsHunter";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBoxCurrentLocation.ResumeLayout(false);
            this.groupBoxCurrentLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegisteredParts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrentParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBoxParts;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btCOMConnect;
        private System.Windows.Forms.Timer timerCOM;
        private System.Windows.Forms.Label labelNumberResults;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDrawer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.Button buttonListAll;
        private System.Windows.Forms.ComboBox comboBoxSearchCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewCurrentParts;
        private System.Windows.Forms.Button buttonFindCurrentLocation;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxCurrentLocation;
        private System.Windows.Forms.DataGridView dataGridViewRegisteredParts;
        private System.Windows.Forms.Label labelNumberResults2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label labelBright;
        private System.Windows.Forms.TrackBar trackBarBright;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TrackBar trackBarTime;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drawer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Drawer;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

