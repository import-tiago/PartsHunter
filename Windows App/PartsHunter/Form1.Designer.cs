
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.labelBright = new System.Windows.Forms.Label();
            this.trackBarBright = new System.Windows.Forms.TrackBar();
            this.labelTime = new System.Windows.Forms.Label();
            this.trackBarTime = new System.Windows.Forms.TrackBar();
            this.buttonColor = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonListAll = new System.Windows.Forms.Button();
            this.comboBoxCategories_SearchTab = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNumberResults = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSearch = new System.Windows.Forms.DataGridView();
            this._Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drawer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxCategories_RegisterTab = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDrawer = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxFirebase_URL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonFirebase_Save = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFirebase_Key = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxFileLocation = new System.Windows.Forms.TextBox();
            this.buttonGetFileAddress = new System.Windows.Forms.Button();
            this.buttonSaveFromFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearch)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(955, 849);
            this.tabControl1.TabIndex = 35;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonDelete);
            this.tabPage1.Controls.Add(this.buttonClear);
            this.tabPage1.Controls.Add(this.buttonEdit);
            this.tabPage1.Controls.Add(this.groupBoxSettings);
            this.tabPage1.Controls.Add(this.buttonSettings);
            this.tabPage1.Controls.Add(this.buttonListAll);
            this.tabPage1.Controls.Add(this.comboBoxCategories_SearchTab);
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
            this.tabPage1.Size = new System.Drawing.Size(947, 820);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Search";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Location = new System.Drawing.Point(772, 743);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(153, 28);
            this.buttonDelete.TabIndex = 72;
            this.buttonDelete.Text = "DELETE";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(772, 780);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(153, 28);
            this.buttonClear.TabIndex = 56;
            this.buttonClear.Text = "Clear All";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click_1);
            // 
            // buttonEdit
            // 
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Location = new System.Drawing.Point(620, 743);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(153, 28);
            this.buttonEdit.TabIndex = 71;
            this.buttonEdit.Text = "EDIT";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
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
            this.groupBoxSettings.Size = new System.Drawing.Size(597, 72);
            this.groupBoxSettings.TabIndex = 70;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            this.groupBoxSettings.Visible = false;
            // 
            // labelBright
            // 
            this.labelBright.AutoSize = true;
            this.labelBright.Location = new System.Drawing.Point(498, 33);
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
            this.trackBarBright.Location = new System.Drawing.Point(357, 30);
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
            this.labelTime.Location = new System.Drawing.Point(280, 33);
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
            this.trackBarTime.Location = new System.Drawing.Point(133, 30);
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
            this.buttonColor.Location = new System.Drawing.Point(8, 30);
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
            this.buttonSettings.Location = new System.Drawing.Point(620, 780);
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
            this.buttonListAll.Location = new System.Drawing.Point(794, 16);
            this.buttonListAll.Margin = new System.Windows.Forms.Padding(4);
            this.buttonListAll.Name = "buttonListAll";
            this.buttonListAll.Size = new System.Drawing.Size(141, 28);
            this.buttonListAll.TabIndex = 68;
            this.buttonListAll.Text = "List All";
            this.buttonListAll.UseVisualStyleBackColor = true;
            this.buttonListAll.Click += new System.EventHandler(this.buttonListAll_Click);
            // 
            // comboBoxCategories_SearchTab
            // 
            this.comboBoxCategories_SearchTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategories_SearchTab.Items.AddRange(new object[] {
            "<Select One>"});
            this.comboBoxCategories_SearchTab.Location = new System.Drawing.Point(96, 18);
            this.comboBoxCategories_SearchTab.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCategories_SearchTab.Name = "comboBoxCategories_SearchTab";
            this.comboBoxCategories_SearchTab.Size = new System.Drawing.Size(688, 24);
            this.comboBoxCategories_SearchTab.TabIndex = 67;
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
            this.buttonSearch.Location = new System.Drawing.Point(794, 52);
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
            this.textBoxSearch.Size = new System.Drawing.Size(688, 22);
            this.textBoxSearch.TabIndex = 56;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridViewSearch);
            this.groupBox6.Location = new System.Drawing.Point(10, 124);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(925, 608);
            this.groupBox6.TabIndex = 44;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "RESULTS";
            // 
            // dataGridViewSearch
            // 
            this.dataGridViewSearch.AllowUserToResizeRows = false;
            this.dataGridViewSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSearch.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Category,
            this.Description,
            this.Drawer});
            this.dataGridViewSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSearch.Location = new System.Drawing.Point(4, 19);
            this.dataGridViewSearch.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewSearch.MultiSelect = false;
            this.dataGridViewSearch.Name = "dataGridViewSearch";
            this.dataGridViewSearch.ReadOnly = true;
            this.dataGridViewSearch.RowHeadersVisible = false;
            this.dataGridViewSearch.RowHeadersWidth = 51;
            this.dataGridViewSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSearch.Size = new System.Drawing.Size(917, 585);
            this.dataGridViewSearch.TabIndex = 0;
            this.dataGridViewSearch.SelectionChanged += new System.EventHandler(this.dataGridViewResults_SelectionChanged);
            // 
            // _Category
            // 
            this._Category.HeaderText = "Category";
            this._Category.MinimumWidth = 6;
            this._Category.Name = "_Category";
            this._Category.ReadOnly = true;
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
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(947, 820);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Register";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.comboBoxCategories_RegisterTab);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxDrawer);
            this.groupBox1.Location = new System.Drawing.Point(10, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(925, 220);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PART INFORMATION";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(100, 164);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(111, 33);
            this.buttonSave.TabIndex = 71;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            // 
            // comboBoxCategories_RegisterTab
            // 
            this.comboBoxCategories_RegisterTab.FormattingEnabled = true;
            this.comboBoxCategories_RegisterTab.Items.AddRange(new object[] {
            "<Select one or type a new one>"});
            this.comboBoxCategories_RegisterTab.Location = new System.Drawing.Point(100, 25);
            this.comboBoxCategories_RegisterTab.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCategories_RegisterTab.Name = "comboBoxCategories_RegisterTab";
            this.comboBoxCategories_RegisterTab.Size = new System.Drawing.Size(817, 24);
            this.comboBoxCategories_RegisterTab.TabIndex = 0;
            this.comboBoxCategories_RegisterTab.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxCategory_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 28);
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
            this.textBoxDescription.Size = new System.Drawing.Size(817, 22);
            this.textBoxDescription.TabIndex = 1;
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
            this.label5.Location = new System.Drawing.Point(8, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 60;
            this.label5.Text = "Drawer N°:";
            // 
            // textBoxDrawer
            // 
            this.textBoxDrawer.Location = new System.Drawing.Point(100, 121);
            this.textBoxDrawer.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDrawer.Name = "textBoxDrawer";
            this.textBoxDrawer.Size = new System.Drawing.Size(817, 22);
            this.textBoxDrawer.TabIndex = 3;
            this.textBoxDrawer.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxQuantity_Validating);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.textBoxFirebase_URL);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.buttonFirebase_Save);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.textBoxFirebase_Key);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(947, 820);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Firebase Config";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(789, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 72;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // textBoxFirebase_URL
            // 
            this.textBoxFirebase_URL.Location = new System.Drawing.Point(122, 21);
            this.textBoxFirebase_URL.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFirebase_URL.Name = "textBoxFirebase_URL";
            this.textBoxFirebase_URL.Size = new System.Drawing.Size(660, 22);
            this.textBoxFirebase_URL.TabIndex = 71;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 70;
            this.label6.Text = "Database URL:";
            // 
            // buttonFirebase_Save
            // 
            this.buttonFirebase_Save.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonFirebase_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFirebase_Save.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFirebase_Save.Location = new System.Drawing.Point(641, 86);
            this.buttonFirebase_Save.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFirebase_Save.Name = "buttonFirebase_Save";
            this.buttonFirebase_Save.Size = new System.Drawing.Size(141, 28);
            this.buttonFirebase_Save.TabIndex = 69;
            this.buttonFirebase_Save.Text = "SAVE";
            this.buttonFirebase_Save.UseVisualStyleBackColor = false;
            this.buttonFirebase_Save.Click += new System.EventHandler(this.buttonFirebase_Save_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 17);
            this.label7.TabIndex = 68;
            this.label7.Text = "Database Key:";
            // 
            // textBoxFirebase_Key
            // 
            this.textBoxFirebase_Key.Location = new System.Drawing.Point(122, 56);
            this.textBoxFirebase_Key.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFirebase_Key.Name = "textBoxFirebase_Key";
            this.textBoxFirebase_Key.PasswordChar = '*';
            this.textBoxFirebase_Key.Size = new System.Drawing.Size(660, 22);
            this.textBoxFirebase_Key.TabIndex = 67;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.buttonSaveFromFile);
            this.groupBox2.Controls.Add(this.buttonGetFileAddress);
            this.groupBox2.Controls.Add(this.textBoxFileLocation);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(10, 275);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(925, 432);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BATCH REGISTRATION";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 54;
            this.label8.Text = "File Location:";
            // 
            // textBoxFileLocation
            // 
            this.textBoxFileLocation.Location = new System.Drawing.Point(100, 28);
            this.textBoxFileLocation.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFileLocation.Name = "textBoxFileLocation";
            this.textBoxFileLocation.Size = new System.Drawing.Size(777, 22);
            this.textBoxFileLocation.TabIndex = 72;
            // 
            // buttonGetFileAddress
            // 
            this.buttonGetFileAddress.Location = new System.Drawing.Point(884, 28);
            this.buttonGetFileAddress.Name = "buttonGetFileAddress";
            this.buttonGetFileAddress.Size = new System.Drawing.Size(33, 23);
            this.buttonGetFileAddress.TabIndex = 73;
            this.buttonGetFileAddress.Text = "...";
            this.buttonGetFileAddress.UseVisualStyleBackColor = true;
            this.buttonGetFileAddress.Click += new System.EventHandler(this.buttonGetFileAddress_Click);
            // 
            // buttonSaveFromFile
            // 
            this.buttonSaveFromFile.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonSaveFromFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveFromFile.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveFromFile.Location = new System.Drawing.Point(100, 74);
            this.buttonSaveFromFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveFromFile.Name = "buttonSaveFromFile";
            this.buttonSaveFromFile.Size = new System.Drawing.Size(111, 33);
            this.buttonSaveFromFile.TabIndex = 72;
            this.buttonSaveFromFile.Text = "SAVE";
            this.buttonSaveFromFile.UseVisualStyleBackColor = false;
            this.buttonSaveFromFile.Click += new System.EventHandler(this.buttonSaveFromFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(100, 57);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(777, 10);
            this.progressBar1.TabIndex = 74;
            this.progressBar1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PartsHunter.Properties.Resources.BatchFileExample;
            this.pictureBox1.Location = new System.Drawing.Point(11, 153);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(531, 260);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 133);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 76;
            this.label9.Text = "Example:";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(549, 153);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(403, 202);
            this.label10.TabIndex = 77;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 862);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearch)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button button1;
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

