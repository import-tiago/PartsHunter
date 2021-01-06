
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
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this._Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Category2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Box2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drawer2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(800, 23);
            this.button1.TabIndex = 73;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // _Category
            // 
            this._Category.HeaderText = "Category";
            this._Category.Name = "_Category";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Category2,
            this.Box2,
            this.Drawer2,
            this.Description2,
            this.Qty});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(800, 45);
            this.dataGridView.TabIndex = 74;
            // 
            // Category2
            // 
            this.Category2.HeaderText = "Category";
            this.Category2.Name = "Category2";
            this.Category2.ReadOnly = true;
            // 
            // Box2
            // 
            this.Box2.HeaderText = "Box";
            this.Box2.Name = "Box2";
            this.Box2.ReadOnly = true;
            // 
            // Drawer2
            // 
            this.Drawer2.HeaderText = "Drawer";
            this.Drawer2.Name = "Drawer2";
            this.Drawer2.ReadOnly = true;
            // 
            // Description2
            // 
            this.Description2.HeaderText = "Description";
            this.Description2.Name = "Description2";
            this.Description2.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 67);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Component";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Category;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Box2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drawer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
    }
}