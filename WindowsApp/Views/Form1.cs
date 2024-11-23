using PartsHunter.Data.Entities;
using PartsHunter.Services;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PartsHunter {
    public partial class Form1 : Form {

        const String DEFAULT_SEARCH_CATEGORY_ITEM = "SHOW ALL";
        const String DEFAULT_REGISTER_CATEGORY_ITEM = "< Select one or type a new one>";
        const String NOTHING_FOUND = "nothing found";
        const String HARDWARE_DEVICE_READY = "Config Highlight";
        const String HARDWARE_DEVICE_NOT_READY = "Missing IP Addr";

        private readonly ComponentService component;
        private readonly HardwareDeviceService hardware_device;
        public Form1() {
            InitializeComponent();
            component = new ComponentService();
            hardware_device = new HardwareDeviceService();
            fill_data_grid();
            fill_categories();
        }
        private void Form1_Load(object sender, EventArgs e) {

            dgvBoM.EnableHeadersVisualStyles = false;
            dgvBoM.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvStock.ColumnHeadersDefaultCellStyle.BackColor;
            dgvBoM.Columns.Add("Item", "Item");
            dgvBoM.Columns.Add("SlotID", "SlotID");
            dgvBoM.Columns["SlotID"].Visible = false;

            dgvStock.EnableHeadersVisualStyles = false;
            dgvStock.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvStock.ColumnHeadersDefaultCellStyle.BackColor;

            resize_datagrid_columns_width();

            hardware_device.get_ip_addr(1);

            if (hardware_device.ip_addr != null && hardware_device.ip_addr != string.Empty) {
                tbIP.Enabled = false;
                tbIP.Text = hardware_device.ip_addr;
                hardware_device.clear_pixels();
                buttonSettings.Enabled = true;
                buttonSettings.Text = HARDWARE_DEVICE_READY;
                buttonSettings.BackColor = SystemColors.Control;
            }
            else {
                tbIP.Enabled = true;
                tbIP.Text = string.Empty;
                buttonSettings.Enabled = false;
                buttonSettings.Text = HARDWARE_DEVICE_NOT_READY;
                buttonSettings.BackColor = Color.MistyRose;
            }
        }
        private int fill_data_grid() {

            var results = component.GetAllComponents().OrderBy(c => c.SlotID).ToList();

            dgvStock.DataSource = null;
            dgvStock.DataSource = results;

            dgvStock.Columns["Category"].DisplayIndex = 0;
            dgvStock.Columns["Id"].Visible = false;

            return results.Count;
        }
        void fill_categories() {

            List<string> categories = component.GetUniqueCategories();
            List<string> search = new(categories);
            List<string> register = new(categories);

            search.Insert(0, DEFAULT_SEARCH_CATEGORY_ITEM);
            cmbCategorySearch.DataSource = search;

            register.Insert(0, DEFAULT_REGISTER_CATEGORY_ITEM);
            cmbCategoryRegister.DataSource = register;
        }
        private void clear_user_inputs() {
            txtDescription.Clear();
            cmbCategoryRegister.SelectedIndex = 0;
            txtSlotID.Clear();
        }
        private void clear_search_form_inputs() {
            txtSearch.Clear();
        }
        private bool ValidateSlotId(out int slotID) {
            if (int.TryParse(txtSlotID.Text, out slotID)) {
                return true;
            }

            MessageBox.Show("Slot ID must be a number");
            slotID = 0;
            return false;
        }
        void display_search_results(int result_count) {

            if (result_count < 0) {
                labelResults.Visible = false;
                return;
            }
            else {
                labelResults.Visible = true;
            }

            labelResults.ForeColor = result_count > 0 ? Color.ForestGreen : Color.Red;
            labelResults.Text = result_count switch {
                0 => NOTHING_FOUND,
                1 => "1 item found",
                _ => $"{result_count} items found"
            };
        }
        private void buttonRegister_Click(object sender, EventArgs e) {

            if (!ValidateSlotId(out int slotID)) {
                return;
            }

            var newComponent = new ComponentEntity {
                Description = txtDescription.Text.Trim(),
                Category = cmbCategoryRegister.Text.Trim().ToUpper(),
                SlotID = slotID
            };

            component.AddComponent(newComponent);

            MessageBox.Show("Component saved successfully.");

            clear_user_inputs();
            fill_data_grid();
            fill_categories();
            resize_datagrid_columns_width();
        }
        void resize_datagrid_columns_width() {
            dgvStock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStock.Columns["SlotID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStock.AutoResizeColumn(dgvStock.Columns["SlotID"].Index, DataGridViewAutoSizeColumnMode.AllCells);
            dgvStock.AutoResizeColumn(dgvStock.Columns["Category"].Index, DataGridViewAutoSizeColumnMode.AllCells);
        }
        private void buttonSearch_Click(object sender, EventArgs e) {

            var searchTerm = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm)) {
                fill_data_grid();
                fill_categories();
                display_search_results(-1);
                return;
            }

            var selectedCategory = cmbCategorySearch.Text;
            var results = selectedCategory == DEFAULT_SEARCH_CATEGORY_ITEM
                ? component.SearchComponentsByDescription(searchTerm)
                : component.SearchComponentsByDescriptionAndCategory(searchTerm, selectedCategory);

            dgvStock.DataSource = results;
            display_search_results(results.Count());
        }
        private void buttonListAll_Click(object sender, EventArgs e) {

            var selectedCategory = cmbCategorySearch.Text;

            if (selectedCategory == DEFAULT_SEARCH_CATEGORY_ITEM) {
                int results_count = fill_data_grid();
                fill_categories();
                clear_search_form_inputs();
                display_search_results(results_count);
            }
            else {
                var results = component.GetComponentsByCategory(selectedCategory);
                dgvStock.DataSource = results;
                display_search_results(results.Count());
            }
        }
        private async void buttonSettings_Click(object sender, EventArgs e) {
            groupBoxSettings.Visible = !groupBoxSettings.Visible;

            if (groupBoxSettings.Visible) {
                buttonSettings.Text = "SAVE";
                buttonSettings.BackColor = Color.LightGreen;
            }
            else {
                try {
                    hardware_device.set_pixel_color();
                    hardware_device.set_pixel_blinky(trackBarTime.Value);
                    hardware_device.set_pixel_brightness(trackBarBright.Value);
                }
                catch (Exception ex) {
                    Debug.WriteLine($"Error in POST requests: {ex.Message}");
                }

                buttonSettings.Text = "Config Highlight";
                buttonSettings.BackColor = Color.Transparent;
            }
        }
        private void buttonColor_Click(object sender, EventArgs e) {
            using (var colorDialog = new ColorDialog()) {
                if (colorDialog.ShowDialog() == DialogResult.OK) {
                    hardware_device.pixel_color = colorDialog.Color;
                    buttonColor.BackColor = colorDialog.Color;
                }
            }
        }
        private void trackBarTime_ValueChanged(object sender, EventArgs e) {
            labelTime.Text = trackBarTime.Value.ToString() + "ms";
        }
        private void trackBarBright_ValueChanged(object sender, EventArgs e) {
            int brightness = trackBarBright.Value;
            int percentage = (int)((brightness - (float)trackBarBright.Minimum) / (float)(trackBarBright.Maximum - trackBarBright.Minimum) * 100);
            labelBright.Text = percentage + "%";
        }
        private void buttonClear_Click(object sender, EventArgs e) {
            hardware_device.clear_pixels();
        }

        int selected_database_id;
        private void dgvStock_SelectionChanged(object sender, EventArgs e) {

            if (dgvStock.SelectedRows.Count > 0) {
                DataGridViewRow selectedRow = dgvStock.SelectedRows[0];

                if (selectedRow.Cells["Id"].Value is int database_id) {
                    selected_database_id = database_id;
                }

                if (selectedRow.Cells["SlotID"].Value is int id) {
                    int pixel = id - 1;
                    hardware_device.turn_on_pixel(pixel);
                }
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e) {

            if (dgvStock.SelectedRows.Count == 0) {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this component?", "Delete Component", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) {

                int currentIndex = dgvStock.SelectedRows[0].Index;

                int scrollPosition = dgvStock.FirstDisplayedScrollingRowIndex;

                component.DeleteComponent(selected_database_id);

                fill_data_grid();
                fill_categories();
                resize_datagrid_columns_width();

                if (scrollPosition >= 0 && scrollPosition < dgvStock.Rows.Count) {
                    dgvStock.FirstDisplayedScrollingRowIndex = scrollPosition;
                }

                if (currentIndex < dgvStock.Rows.Count) {
                    dgvStock.Rows[currentIndex].Selected = true;
                }
                else if (dgvStock.Rows.Count > 0) {
                    dgvStock.Rows[dgvStock.Rows.Count - 1].Selected = true;
                }
            }
        }
        private void buttonEdit_Click(object sender, EventArgs e) {

            using (Form2 form2 = new Form2(component)) {

                form2.selected_database_id = selected_database_id;

                var result = form2.ShowDialog();

                if (result == DialogResult.OK) {

                    fill_data_grid();
                    fill_categories();
                }
            }
        }
        private void dgvDataSet_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {

                DataGridViewRow selectedRow = dgvStock.Rows[e.RowIndex];

                int selectedSlotId = Convert.ToInt32(selectedRow.Cells["SlotID"].Value);

                bool slotIdExists = false;
                foreach (DataGridViewRow row in dgvBoM.Rows) {
                    if (row.Cells["SlotID"].Value != null && Convert.ToInt32(row.Cells["SlotID"].Value) == selectedSlotId) {
                        slotIdExists = true;
                        break;
                    }
                }

                if (!slotIdExists) {
                    int newRowIndex = dgvBoM.Rows.Add();
                    string concatenatedValue = selectedRow.Cells["Category"].Value.ToString() + " - " + selectedRow.Cells["Description"].Value.ToString();
                    dgvBoM.Rows[newRowIndex].Cells["Item"].Value = concatenatedValue;
                    dgvBoM.Rows[newRowIndex].Cells["SlotID"].Value = selectedRow.Cells["SlotID"].Value;
                }
            }
        }
        private async void btnShowAll_Click(object sender, EventArgs e) {
            try {
                hardware_device.clear_pixels();

                List<int> pixels = new List<int>();

                foreach (DataGridViewRow row in dgvBoM.Rows) {
                    if (row.Cells["SlotID"].Value != null) {
                        int slotId = Convert.ToInt32(row.Cells["SlotID"].Value);
                        pixels.Add(slotId);
                    }
                }
                hardware_device.turn_on_pixels(pixels);
            }
            catch (Exception) {

            }
        }
        private void dgvBillOfMaterials_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && !dgvBoM.Rows[e.RowIndex].IsNewRow) {
                dgvBoM.Rows.RemoveAt(e.RowIndex);

                if (dgvBoM.Rows.Count == 1 && dgvBoM.Rows[0].IsNewRow) {
                    dgvBoM.Rows.Clear();
                    dgvBoM.Refresh();
                    hardware_device.clear_pixels();
                }
            }
        }
        private void ProcessFile(string filePath) {
            try {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines) {

                    var parts = line.Split(',');

                    if (parts.Length == 3) {
                        string category = parts[0].Trim().ToUpper();
                        string description = parts[1].Trim();
                        if (int.TryParse(parts[2].Trim(), out int slotID)) {

                            var newComponent = new ComponentEntity {
                                Description = description,
                                Category = category,
                                SlotID = slotID
                            };

                            component.AddComponent(newComponent);
                            clear_user_inputs();
                            fill_data_grid();
                        }
                        else {
                            MessageBox.Show($"Invalid SlotID in line: {line}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else {
                        MessageBox.Show($"Invalid line format: {line}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show("File processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonGetFileAddress_Click(object sender, EventArgs e) {

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.Title = "Select a Text File";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    textBoxFileLocation.Text = openFileDialog.FileName;
                }
            }
        }
        private void buttonSaveFromFile_Click(object sender, EventArgs e) {
            if (textBoxFileLocation.Text.Contains(".txt")) {
                Cursor.Current = Cursors.WaitCursor;
                try {
                    ProcessFile(textBoxFileLocation.Text);
                }
                finally {
                    Cursor.Current = Cursors.Default;
                    clear_user_inputs();
                    fill_data_grid();
                    fill_categories();
                    resize_datagrid_columns_width();
                }
            }
            else {
                MessageBox.Show("Please specify a valid .txt file.");
            }
        }

        public bool is_ip_valid(string ip_addr) {
            string pattern = @"^((25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)$";
            return Regex.IsMatch(ip_addr, pattern);
        }
        private void pictureBox2_Click(object sender, EventArgs e) {

            string ip_addr = tbIP.Text;

            if (is_ip_valid(ip_addr)) {
                if (hardware_device.add_ip_addr(1, ip_addr)) {
                    MessageBox.Show("Saved successfully!");
                    tbIP.Enabled = false;
                    buttonSettings.Enabled = true;
                    buttonSettings.Text = HARDWARE_DEVICE_READY;
                    buttonSettings.BackColor = SystemColors.Control;
                }
            }
            else {
                MessageBox.Show("Invalid IP address!");
            }
        }
        bool edit_ip = false;
        private void pictureBoxEditIP_Click(object sender, EventArgs e) {
            edit_ip = !edit_ip;
            tbIP.Enabled = edit_ip;
        }
        private bool isClosingHandled = false; // Flag to prevent re-entry
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            
            if (isClosingHandled) {
                return; // Skip if already handled
            }

            e.Cancel = true; // Prevent immediate closing

            try {
                Debug.WriteLine("Attempting to clear pixels...");
                var success = await hardware_device.clear_pixels();

                if (success) {
                    Debug.WriteLine("Pixels cleared successfully.");
                    isClosingHandled = true; // Mark as handled
                    e.Cancel = false; // Allow closing
                    this.Close(); // Explicitly close the form
                }
                else {
                    Debug.WriteLine("Failed to clear pixels. Form will remain open.");
                }
            }
            catch (Exception ex) {
                Debug.WriteLine($"Exception during clear_pixels: {ex.Message}");
            }
        }
    }
}