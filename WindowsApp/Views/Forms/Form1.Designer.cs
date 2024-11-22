
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
            button1 = new Button();
            groupBox3 = new GroupBox();
            dgvBillOfMaterials = new DataGridView();
            Item = new DataGridViewTextBoxColumn();
            SlotID = new DataGridViewTextBoxColumn();
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
            cmbCategorySearch = new ComboBox();
            label1 = new Label();
            labelResults = new Label();
            buttonSearch = new Button();
            label2 = new Label();
            txtSearch = new TextBox();
            groupBox6 = new GroupBox();
            dgvDataSet = new DataGridView();
            tabPage2 = new TabPage();
            groupBox2 = new GroupBox();
            picHelp = new PictureBox();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            buttonSaveFromFile = new Button();
            buttonGetFileAddress = new Button();
            textBoxFileLocation = new TextBox();
            label8 = new Label();
            groupBox1 = new GroupBox();
            buttonRegister = new Button();
            cmbCategoryRegister = new ComboBox();
            label3 = new Label();
            txtDescription = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtSlotID = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            colorDialog1 = new ColorDialog();
            openFileDialog1 = new OpenFileDialog();
            toolTip1 = new ToolTip(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillOfMaterials).BeginInit();
            groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarBright).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTime).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDataSet).BeginInit();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHelp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 14);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(836, 813);
            tabControl1.TabIndex = 35;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(buttonDelete);
            tabPage1.Controls.Add(buttonClear);
            tabPage1.Controls.Add(buttonEdit);
            tabPage1.Controls.Add(groupBoxSettings);
            tabPage1.Controls.Add(buttonSettings);
            tabPage1.Controls.Add(buttonListAll);
            tabPage1.Controls.Add(cmbCategorySearch);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(labelResults);
            tabPage1.Controls.Add(buttonSearch);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(txtSearch);
            tabPage1.Controls.Add(groupBox6);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 3, 4, 3);
            tabPage1.Size = new Size(828, 785);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Search";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(20, 660);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(204, 27);
            button1.TabIndex = 74;
            button1.Text = "SHOW ALL";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvBillOfMaterials);
            groupBox3.Location = new Point(16, 117);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(212, 537);
            groupBox3.TabIndex = 73;
            groupBox3.TabStop = false;
            groupBox3.Text = "Bill of Materials";
            // 
            // dgvBillOfMaterials
            // 
            dgvBillOfMaterials.AllowUserToResizeRows = false;
            dgvBillOfMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBillOfMaterials.BackgroundColor = SystemColors.ControlLightLight;
            dgvBillOfMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillOfMaterials.Columns.AddRange(new DataGridViewColumn[] { Item, SlotID });
            dgvBillOfMaterials.Dock = DockStyle.Fill;
            dgvBillOfMaterials.Location = new Point(4, 19);
            dgvBillOfMaterials.Margin = new Padding(4, 3, 4, 3);
            dgvBillOfMaterials.MultiSelect = false;
            dgvBillOfMaterials.Name = "dgvBillOfMaterials";
            dgvBillOfMaterials.ReadOnly = true;
            dgvBillOfMaterials.RowHeadersVisible = false;
            dgvBillOfMaterials.RowHeadersWidth = 51;
            dgvBillOfMaterials.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillOfMaterials.Size = new Size(204, 515);
            dgvBillOfMaterials.TabIndex = 0;
            dgvBillOfMaterials.CellDoubleClick += dgvBillOfMaterials_CellDoubleClick;
            // 
            // Item
            // 
            Item.HeaderText = "Item";
            Item.Name = "Item";
            Item.ReadOnly = true;
            // 
            // SlotID
            // 
            SlotID.HeaderText = "SlotID";
            SlotID.Name = "SlotID";
            SlotID.ReadOnly = true;
            // 
            // buttonDelete
            // 
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Location = new Point(681, 710);
            buttonDelete.Margin = new Padding(4, 3, 4, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(134, 27);
            buttonDelete.TabIndex = 72;
            buttonDelete.Text = "DELETE";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonClear
            // 
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.Location = new Point(681, 744);
            buttonClear.Margin = new Padding(4, 3, 4, 3);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(134, 27);
            buttonClear.TabIndex = 56;
            buttonClear.Text = "Clear All";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Location = new Point(540, 710);
            buttonEdit.Margin = new Padding(4, 3, 4, 3);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(134, 27);
            buttonEdit.TabIndex = 71;
            buttonEdit.Text = "EDIT";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
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
            trackBarBright.Minimum = 10;
            trackBarBright.Name = "trackBarBright";
            trackBarBright.Size = new Size(117, 29);
            trackBarBright.TabIndex = 59;
            trackBarBright.TickStyle = TickStyle.None;
            trackBarBright.Value = 10;
            trackBarBright.ValueChanged += trackBarBright_ValueChanged;
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
            trackBarTime.LargeChange = 100;
            trackBarTime.Location = new Point(117, 28);
            trackBarTime.Margin = new Padding(4, 3, 4, 3);
            trackBarTime.Maximum = 1000;
            trackBarTime.Name = "trackBarTime";
            trackBarTime.Size = new Size(117, 29);
            trackBarTime.SmallChange = 50;
            trackBarTime.TabIndex = 57;
            trackBarTime.TickFrequency = 50;
            trackBarTime.TickStyle = TickStyle.None;
            trackBarTime.ValueChanged += trackBarTime_ValueChanged;
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
            buttonColor.Click += buttonColor_Click;
            // 
            // buttonSettings
            // 
            buttonSettings.FlatStyle = FlatStyle.Flat;
            buttonSettings.Location = new Point(540, 744);
            buttonSettings.Margin = new Padding(4, 3, 4, 3);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(134, 27);
            buttonSettings.TabIndex = 69;
            buttonSettings.Text = "Config Highlight";
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // buttonListAll
            // 
            buttonListAll.FlatStyle = FlatStyle.System;
            buttonListAll.Location = new Point(695, 15);
            buttonListAll.Margin = new Padding(4, 3, 4, 3);
            buttonListAll.Name = "buttonListAll";
            buttonListAll.Size = new Size(124, 27);
            buttonListAll.TabIndex = 68;
            buttonListAll.Text = "Show";
            buttonListAll.UseVisualStyleBackColor = true;
            buttonListAll.Click += buttonListAll_Click;
            // 
            // cmbCategorySearch
            // 
            cmbCategorySearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategorySearch.Items.AddRange(new object[] { "<Select One>" });
            cmbCategorySearch.Location = new Point(84, 17);
            cmbCategorySearch.Margin = new Padding(4, 3, 4, 3);
            cmbCategorySearch.Name = "cmbCategorySearch";
            cmbCategorySearch.Size = new Size(602, 23);
            cmbCategorySearch.TabIndex = 67;
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
            // labelResults
            // 
            labelResults.AutoSize = true;
            labelResults.ForeColor = Color.Red;
            labelResults.Location = new Point(84, 77);
            labelResults.Margin = new Padding(4, 0, 4, 0);
            labelResults.Name = "labelResults";
            labelResults.Size = new Size(147, 15);
            labelResults.TabIndex = 59;
            labelResults.Text = "<Number's results found>";
            labelResults.Visible = false;
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
            buttonSearch.Click += buttonSearch_Click;
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
            // txtSearch
            // 
            txtSearch.Location = new Point(84, 51);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(602, 23);
            txtSearch.TabIndex = 56;
            txtSearch.KeyDown += buttonSearch_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(dgvDataSet);
            groupBox6.Location = new Point(236, 117);
            groupBox6.Margin = new Padding(4, 3, 4, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(4, 3, 4, 3);
            groupBox6.Size = new Size(583, 570);
            groupBox6.TabIndex = 44;
            groupBox6.TabStop = false;
            groupBox6.Text = "Stock";
            // 
            // dgvDataSet
            // 
            dgvDataSet.AllowUserToResizeRows = false;
            dgvDataSet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDataSet.BackgroundColor = SystemColors.ControlLightLight;
            dgvDataSet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDataSet.Dock = DockStyle.Fill;
            dgvDataSet.Location = new Point(4, 19);
            dgvDataSet.Margin = new Padding(4, 3, 4, 3);
            dgvDataSet.MultiSelect = false;
            dgvDataSet.Name = "dgvDataSet";
            dgvDataSet.ReadOnly = true;
            dgvDataSet.RowHeadersVisible = false;
            dgvDataSet.RowHeadersWidth = 51;
            dgvDataSet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDataSet.Size = new Size(575, 548);
            dgvDataSet.TabIndex = 0;
            dgvDataSet.CellDoubleClick += dgvDataSet_CellDoubleClick;
            dgvDataSet.SelectionChanged += dataGridView_SelectionChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(4, 3, 4, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 3, 4, 3);
            tabPage2.Size = new Size(828, 785);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Register";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(picHelp);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Controls.Add(progressBar1);
            groupBox2.Controls.Add(buttonSaveFromFile);
            groupBox2.Controls.Add(buttonGetFileAddress);
            groupBox2.Controls.Add(textBoxFileLocation);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(9, 184);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(432, 349);
            groupBox2.TabIndex = 72;
            groupBox2.TabStop = false;
            groupBox2.Text = "Batch";
            // 
            // picHelp
            // 
            picHelp.Cursor = Cursors.Help;
            picHelp.Image = (Image)resources.GetObject("picHelp.Image");
            picHelp.Location = new Point(389, 26);
            picHelp.Margin = new Padding(2);
            picHelp.Name = "picHelp";
            picHelp.Size = new Size(24, 24);
            picHelp.SizeMode = PictureBoxSizeMode.StretchImage;
            picHelp.TabIndex = 77;
            picHelp.TabStop = false;
            toolTip1.SetToolTip(picHelp, "- The file name can be anything.\r\n\r\n- Content is not case-sensitive.\r\n\r\n- List components one per line.\r\n\r\n- Use commas without spaces to separate category, description, and slot ID.");
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(9, 120);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(412, 220);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 75;
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(88, 86);
            progressBar1.Margin = new Padding(2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(325, 10);
            progressBar1.TabIndex = 74;
            progressBar1.Visible = false;
            // 
            // buttonSaveFromFile
            // 
            buttonSaveFromFile.BackColor = Color.LightSkyBlue;
            buttonSaveFromFile.FlatStyle = FlatStyle.Flat;
            buttonSaveFromFile.Font = new Font("Fira Code", 9.75F);
            buttonSaveFromFile.Location = new Point(88, 56);
            buttonSaveFromFile.Margin = new Padding(4, 3, 4, 3);
            buttonSaveFromFile.Name = "buttonSaveFromFile";
            buttonSaveFromFile.Size = new Size(325, 25);
            buttonSaveFromFile.TabIndex = 72;
            buttonSaveFromFile.Text = "LOAD";
            buttonSaveFromFile.UseVisualStyleBackColor = false;
            // 
            // buttonGetFileAddress
            // 
            buttonGetFileAddress.Location = new Point(356, 27);
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
            textBoxFileLocation.Size = new Size(262, 23);
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
            groupBox1.Controls.Add(buttonRegister);
            groupBox1.Controls.Add(cmbCategoryRegister);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtSlotID);
            groupBox1.Location = new Point(9, 7);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(432, 144);
            groupBox1.TabIndex = 67;
            groupBox1.TabStop = false;
            groupBox1.Text = "Single";
            // 
            // buttonRegister
            // 
            buttonRegister.BackColor = Color.PaleTurquoise;
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.Font = new Font("Fira Code", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonRegister.Location = new Point(88, 110);
            buttonRegister.Margin = new Padding(4, 3, 4, 3);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(325, 25);
            buttonRegister.TabIndex = 71;
            buttonRegister.Text = "INSERT";
            buttonRegister.UseVisualStyleBackColor = false;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // cmbCategoryRegister
            // 
            cmbCategoryRegister.FormattingEnabled = true;
            cmbCategoryRegister.Location = new Point(88, 23);
            cmbCategoryRegister.Margin = new Padding(4, 3, 4, 3);
            cmbCategoryRegister.Name = "cmbCategoryRegister";
            cmbCategoryRegister.Size = new Size(325, 23);
            cmbCategoryRegister.TabIndex = 0;
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
            // txtDescription
            // 
            txtDescription.Location = new Point(88, 52);
            txtDescription.Margin = new Padding(4, 3, 4, 3);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(325, 23);
            txtDescription.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 56);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 58;
            label4.Text = "Description:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 85);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 60;
            label5.Text = "Drawer N°:";
            // 
            // txtSlotID
            // 
            txtSlotID.Location = new Point(88, 81);
            txtSlotID.Margin = new Padding(4, 3, 4, 3);
            txtSlotID.Name = "txtSlotID";
            txtSlotID.Size = new Size(325, 23);
            txtSlotID.TabIndex = 3;
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
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
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
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBillOfMaterials).EndInit();
            groupBoxSettings.ResumeLayout(false);
            groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarBright).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTime).EndInit();
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDataSet).EndInit();
            tabPage2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHelp).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label labelResults;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSlotID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategoryRegister;
        private System.Windows.Forms.Button buttonListAll;
        private System.Windows.Forms.ComboBox cmbCategorySearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label labelBright;
        private System.Windows.Forms.TrackBar trackBarBright;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TrackBar trackBarTime;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSaveFromFile;
        private System.Windows.Forms.Button buttonGetFileAddress;
        private System.Windows.Forms.TextBox textBoxFileLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DataGridView dgvDataSet;
        private PictureBox picHelp;
        private ToolTip toolTip1;
        private GroupBox groupBox3;
        private DataGridView dgvBillOfMaterials;
        private Button button1;
        private DataGridViewTextBoxColumn Item;
        private DataGridViewTextBoxColumn SlotID;
    }
}

