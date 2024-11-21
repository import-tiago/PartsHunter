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
            dataGridView.DataSource = results;
            dataGridView.Columns["Category"].DisplayIndex = 0;
            dataGridView.Columns["Id"].Visible = false;
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
                Category = cmbCategoryRegister.Text.Trim(),
                SlotID = slotID
            };

            _componentService.AddComponent(newComponent);

            MessageBox.Show("Component saved successfully.");
            clear_register_form_inputs();
            fill_data_grid();
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

            dataGridView.DataSource = results;
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
                dataGridView.DataSource = results;
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
                    var endpoint = $"http://192.168.31.100/color?r={r}&g={g}&b={b}";
                    var responseColor = await httpClient.PostAsync(endpoint, null);

                    endpoint = $"http://192.168.31.100/blink?interval={trackBarTime.Value}";
                    var responseBlink = await httpClient.PostAsync(endpoint, null);

                    endpoint = $"http://192.168.31.100/brightness?level={trackBarBright.Value}";
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

        private async void buttonClear_Click(object sender, EventArgs e) {
            var endpoint = "http://192.168.31.100/clear";
            var response = await httpClient.PostAsync(endpoint, null);
        }

        int selected_component_id;
        private void dataGridView_SelectionChanged(object sender, EventArgs e) {

            if (dataGridView.SelectedRows.Count > 0) {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                var idValue = selectedRow.Cells["Id"].Value;
                selected_component_id = Convert.ToInt32(idValue);
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
    }
}