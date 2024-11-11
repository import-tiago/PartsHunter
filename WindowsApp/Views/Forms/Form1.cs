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
            trackBarBright.ValueChanged += async (sender, e) => await AdjustBrightnessAsync(trackBarBright.Value);
        }

        private async Task AdjustBrightnessAsync(int level) {
            try {
                var endpoint = $"http://192.168.31.100/brightness?level={level}";
                var response = await httpClient.PostAsync(endpoint, null);
                
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine($"Brightness adjusted to {level}.");
                else
                    Debug.WriteLine($"Failed to adjust brightness. Status Code: {response.StatusCode}");
            }
            catch (Exception ex) {
                Debug.WriteLine($"Error adjusting brightness: {ex.Message}");
            }
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

        private void buttonSettings_Click(object sender, EventArgs e) {
            groupBoxSettings.Visible = !groupBoxSettings.Visible;
        }
    }
}