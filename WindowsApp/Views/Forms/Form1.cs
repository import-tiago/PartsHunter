using System;
using System.Globalization;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using PartsHunter.Data.Entities;
using PartsHunter.Services.DataService;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Net;
using PartsHunter.Data;
using System.Text.RegularExpressions;

namespace PartsHunter {
    public partial class Form1 : Form {

        const String DEFAULT_SEARCH_CATEGORY_ITEM = "SHOW ALL";
        const String DEFAULT_REGISTER_CATEGORY_ITEM = "< Select one or type a new one>";
        const String NOTHING_FOUND = "nothing found";
        private static readonly HttpClient httpClient = new HttpClient();


        private readonly ComponentService _componentService;
        public Form1() {
            InitializeComponent();
            _componentService = new ComponentService();
            fill_data_grid();
            fill_categories();
        }

        private void clear_register_form_inputs() {
            txtDescription.Clear();
            cmbCategoryRegister.SelectedIndex = 0;
            txtSlotID.Clear();
        }
        private void clear_search_form_inputs() {
            txtSearch.Clear();
        }

        private bool ValidateSlotId(out int slotID) {
            if (int.TryParse(txtSlotID.Text, out slotID)) return true;

            MessageBox.Show("Please enter a valid number for Slot ID.");
            slotID = 0;
            return false;
        }

        private int fill_data_grid() {
            var results = _componentService.GetAllComponents();
            dgvStock.DataSource = results;
            dgvStock.Columns["Category"].DisplayIndex = 0;
            dgvStock.Columns["Id"].Visible = false;
            return results.Count;
        }

        void fill_categories() {

            List<string> categories = _componentService.GetUniqueCategories();

            List<string> search = new(categories);
            List<string> register = new(categories);

            search.Insert(0, DEFAULT_SEARCH_CATEGORY_ITEM);
            cmbCategorySearch.DataSource = search;

            register.Insert(0, DEFAULT_REGISTER_CATEGORY_ITEM);
            cmbCategoryRegister.DataSource = register;
        }

        void display_search_results(int result_count) {

            if (result_count < 0) {
                labelResults.Visible = false;
                return;
            }
            else
                labelResults.Visible = true;

            labelResults.ForeColor = result_count > 0 ? Color.ForestGreen : Color.Red;
            labelResults.Text = result_count switch {
                0 => NOTHING_FOUND,
                1 => "1 item found",
                _ => $"{result_count} items found"
            };
        }
        private void buttonRegister_Click(object sender, EventArgs e) {

            if (!ValidateSlotId(out int slotID)) return;

            var newComponent = new Component {
                Description = txtDescription.Text.Trim(),
                Category = cmbCategoryRegister.Text.Trim().ToUpper(),
                SlotID = slotID
            };

            _componentService.AddComponent(newComponent);

            MessageBox.Show("Component saved successfully.");
            clear_register_form_inputs();
            fill_data_grid();
            fill_categories();
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
                ? _componentService.SearchComponentsByDescription(searchTerm)
                : _componentService.SearchComponentsByDescriptionAndCategory(searchTerm, selectedCategory);

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
                var results = _componentService.GetComponentsByCategory(selectedCategory);
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
                    var endpoint = $"http://{web_server_ip}/color?r={r}&g={g}&b={b}";
                    var responseColor = await httpClient.PostAsync(endpoint, null);

                    endpoint = $"http://{web_server_ip}/blink?interval={trackBarTime.Value}";
                    var responseBlink = await httpClient.PostAsync(endpoint, null);

                    endpoint = $"http://{web_server_ip}/brightness?level={trackBarBright.Value}";
                    var responseBrightness = await httpClient.PostAsync(endpoint, null);
                }
                catch (Exception ex) {
                    Debug.WriteLine($"Error in POST requests: {ex.Message}");
                }

                buttonSettings.Text = "Config Highlight";
                buttonSettings.BackColor = Color.Transparent;
            }
        }

        int r, g, b;
        private void buttonColor_Click(object sender, EventArgs e) {
            using (var colorDialog = new ColorDialog()) {
                if (colorDialog.ShowDialog() == DialogResult.OK) {
                    r = colorDialog.Color.R;
                    g = colorDialog.Color.G;
                    b = colorDialog.Color.B;
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

        async void clear_pixels() {
            try {
                var endpoint = $"http://{web_server_ip}/clear";
                var response = await httpClient.PostAsync(endpoint, null);
            }
            catch (HttpRequestException httpEx) {

            }
            catch (Exception ex) {

            }
        }

        private void buttonClear_Click(object sender, EventArgs e) {

            clear_pixels();

        }

        int selected_component_id;
        private async void dataGridView_SelectionChanged(object sender, EventArgs e) {

            if (dgvStock.SelectedRows.Count > 0) {
                DataGridViewRow selectedRow = dgvStock.SelectedRows[0];
                var idValue = selectedRow.Cells["Id"].Value;
                selected_component_id = Convert.ToInt32(idValue);
                int slotId = Convert.ToInt32(dgvStock.SelectedRows[0].Cells["SlotID"].Value) - 1;
                try {
                    var endpoint = $"http://{web_server_ip}/slot?id={slotId}";
                    var response = await httpClient.PostAsync(endpoint, null);
                }
                catch (HttpRequestException httpEx) {

                }
                catch (Exception ex) {

                }
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e) {

            var result = MessageBox.Show("Are you sure you want to delete this component?", "Delete Component", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) {
                _componentService.DeleteComponent(selected_component_id);
                fill_data_grid();
                fill_categories();
            }
            else
                return;
        }
        private void buttonEdit_Click(object sender, EventArgs e) {

            using (Form2 form2 = new Form2(_componentService)) {

                form2.selected_component_id = selected_component_id;

                var result = form2.ShowDialog();

                if (result == DialogResult.OK) {

                    fill_data_grid();
                    fill_categories();

                }
            }
        }

        private void dgvDataSet_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                // Get the selected row from dgvDataSet
                DataGridViewRow selectedRow = dgvStock.Rows[e.RowIndex];

                // Get the SlotID value from the selected row
                int selectedSlotId = Convert.ToInt32(selectedRow.Cells["SlotID"].Value);

                // Check if the SlotID already exists in dgvBillOfMaterials
                bool slotIdExists = false;
                foreach (DataGridViewRow row in dgvBillOfMaterials.Rows) {
                    if (row.Cells["SlotID"].Value != null && Convert.ToInt32(row.Cells["SlotID"].Value) == selectedSlotId) {
                        slotIdExists = true;
                        break;
                    }
                }

                // If SlotID does not exist, add the row to dgvBillOfMaterials
                if (!slotIdExists) {
                    int newRowIndex = dgvBillOfMaterials.Rows.Add();
                    string concatenatedValue = selectedRow.Cells["Category"].Value.ToString() + " - " + selectedRow.Cells["Description"].Value.ToString();
                    dgvBillOfMaterials.Rows[newRowIndex].Cells["Item"].Value = concatenatedValue;
                    dgvBillOfMaterials.Rows[newRowIndex].Cells["SlotID"].Value = selectedRow.Cells["SlotID"].Value;
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e) {
            try {
                var endpoint = $"http://{web_server_ip}/clear";
                var response = await httpClient.PostAsync(endpoint, null);


                List<int> slotIds = new List<int>();

                foreach (DataGridViewRow row in dgvBillOfMaterials.Rows) {
                    if (row.Cells["SlotID"].Value != null) {
                        int slotId = Convert.ToInt32(row.Cells["SlotID"].Value);
                        slotIds.Add(slotId);
                    }
                }
                string slotIdList = string.Join(",", slotIds);
                endpoint = $"http://{web_server_ip}/slot?id={slotIdList}";
                using (HttpClient httpClient = new HttpClient()) {
                    response = await httpClient.PostAsync(endpoint, null);
                }
            }
            catch (HttpRequestException httpEx) {

            }
            catch (Exception ex) {

            }
        }

        string? web_server_ip = string.Empty;
        private void Form1_Load(object sender, EventArgs e) {
            dgvBillOfMaterials.Columns.Add("Item", "Item");
            dgvBillOfMaterials.Columns.Add("SlotID", "SlotID");
            dgvBillOfMaterials.Columns["SlotID"].Visible = false;
            dgvStock.Columns["SlotID"].Width = 30;
            dgvStock.Columns["Category"].Width = 150;
            dgvStock.Columns["SlotID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStock.EnableHeadersVisualStyles = false;
            dgvStock.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvStock.ColumnHeadersDefaultCellStyle.BackColor;
            dgvBillOfMaterials.EnableHeadersVisualStyles = false;
            dgvBillOfMaterials.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvStock.ColumnHeadersDefaultCellStyle.BackColor;


            var service = new HardwareDeviceService();
            web_server_ip = service.GetIPAddress(1);
            if (web_server_ip != null) {
                tbIP.Enabled = false;
                tbIP.Text = web_server_ip;
                clear_pixels();
            }
            else {
                tbIP.Enabled = true;
                tbIP.Text = string.Empty;
            }


        }

        private void dgvBillOfMaterials_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && !dgvBillOfMaterials.Rows[e.RowIndex].IsNewRow) {
                dgvBillOfMaterials.Rows.RemoveAt(e.RowIndex);

                if (dgvBillOfMaterials.Rows.Count == 1 && dgvBillOfMaterials.Rows[0].IsNewRow) {
                    // Clear all rows if only the new row is left
                    dgvBillOfMaterials.Rows.Clear();
                    dgvBillOfMaterials.Refresh();
                    clear_pixels();
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

                            var newComponent = new Component {
                                Description = description,
                                Category = category,
                                SlotID = slotID
                            };

                            _componentService.AddComponent(newComponent);
                            clear_register_form_inputs();
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
            if (textBoxFileLocation.Text.Contains(".txt"))
                ProcessFile(textBoxFileLocation.Text);
            else
                MessageBox.Show("Please specify a valid .txt file.");
        }

        public bool is_ip_valid(string ip_addr) {
            // Regular expression to match IPv4 addresses
            string pattern = @"^((25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)$";

            // Use Regex to match the input string
            return Regex.IsMatch(ip_addr, pattern);
        }
        private void pictureBox2_Click(object sender, EventArgs e) {

            string ip_addr = tbIP.Text;

            if (is_ip_valid(ip_addr)) {

                var service = new HardwareDeviceService();
                if (service.AddIPAddress(1, ip_addr)) {
                    MessageBox.Show("Saved successfully!");
                    tbIP.Enabled = false;
                }
            }
            else
                MessageBox.Show("Invalid IP address!");
        }

        bool edit_ip = false;
        private void pictureBoxEditIP_Click(object sender, EventArgs e) {
            edit_ip = !edit_ip;
            tbIP.Enabled = edit_ip;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            clear_pixels();
        }
    }
}