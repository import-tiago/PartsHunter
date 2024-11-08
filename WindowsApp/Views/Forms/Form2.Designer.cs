
namespace PartsHunter
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            button1 = new Button();
            _Category = new DataGridViewTextBoxColumn();
            dataGridView = new DataGridView();
            Category2 = new DataGridViewTextBoxColumn();
            Drawer2 = new DataGridViewTextBoxColumn();
            Description2 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientInactiveCaption;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(0, 51);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(934, 26);
            button1.TabIndex = 73;
            button1.Text = "Save Changes";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // _Category
            // 
            _Category.HeaderText = "Category";
            _Category.MinimumWidth = 6;
            _Category.Name = "_Category";
            _Category.Width = 125;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { Category2, Drawer2, Description2 });
            dataGridView.Dock = DockStyle.Top;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Margin = new Padding(4);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.Size = new Size(934, 52);
            dataGridView.TabIndex = 74;
            // 
            // Category2
            // 
            Category2.HeaderText = "Category";
            Category2.MinimumWidth = 6;
            Category2.Name = "Category2";
            Category2.ReadOnly = true;
            // 
            // Drawer2
            // 
            Drawer2.HeaderText = "Drawer";
            Drawer2.MinimumWidth = 6;
            Drawer2.Name = "Drawer2";
            Drawer2.ReadOnly = true;
            // 
            // Description2
            // 
            Description2.HeaderText = "Description";
            Description2.MinimumWidth = 6;
            Description2.Name = "Description2";
            Description2.ReadOnly = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 77);
            Controls.Add(button1);
            Controls.Add(dataGridView);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Component";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Category;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drawer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description2;
    }
}