using System;
using System.Globalization;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using PartsHunter.Data.Entities;
using PartsHunter.Services.DataService;


namespace PartsHunter {
    public partial class Form1 : Form {

        const String DEFAULT_CMB_SEARCH_ITEM = "SHOW ALL";
        const String DEFAULT_CMB_REGISTER_ITEM = "< Select one or type a new one>";
        const String NOTHING_FOUND = "nothing found";

        private readonly ComponentService _repository;
        public Form1() {
            InitializeComponent();
            _repository = new ComponentService();
            fill_data_grid();
            fill_categories();
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            // Collect form input
            string category = cmbCategoryRegister.Text;
            string description = txtDescription.Text;

            // Validate SlotID as integer
            if (!int.TryParse(txtSlotID.Text, out int slotID)) {
                MessageBox.Show("Please enter a valid number for Slot ID.");
                return;
            }

            // Create and save new component
            var newComponent = new Component {
                Description = description,
                Category = category,
                SlotID = slotID
            };

            _repository.AddComponent(newComponent);

            // Optionally, show a confirmation and clear inputs
            MessageBox.Show("Component saved successfully.");
            txtDescription.Clear();
            cmbCategoryRegister.SelectedIndex = -1;
            txtSlotID.Clear();
            fill_data_grid();
        }

        private void fill_data_grid() {
            var components = _repository.GetAllComponents();
            dataGridView.DataSource = components;
            dataGridView.Columns["Category"].DisplayIndex = 0;
            dataGridView.Columns["Id"].Visible = false;
        }

        void fill_categories() {

            List<string> categories = _repository.GetUniqueCategories();

            List<string> search = new List<string>(categories);
            List<string> register = new List<string>(categories);

            search.Insert(0, DEFAULT_CMB_SEARCH_ITEM);
            cmbCategorySearch.DataSource = search;

            register.Insert(0, DEFAULT_CMB_REGISTER_ITEM);
            cmbCategoryRegister.DataSource = register;
        }

        void search_results(int qty) {
            if (qty == 0) {
                labelResults.ForeColor = Color.Red;
                labelResults.Text = NOTHING_FOUND;
            }
            else if (qty == 1) {
                labelResults.ForeColor = Color.ForestGreen;
                labelResults.Text = $"{qty} item found";
            }
            else {
                labelResults.ForeColor = Color.ForestGreen;
                labelResults.Text = $"{qty} items found";
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e) {

            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm)) {
                MessageBox.Show("Enter a search term.");
                return;
            }

            string selected_category = cmbCategorySearch.Text;
            if (selected_category != DEFAULT_CMB_SEARCH_ITEM) {

                var results = _repository.SearchComponentsByDescriptionAndCategory(searchTerm, selected_category);

                if (results.Any()) {
                    search_results(results.Count);
                    dataGridView.DataSource = results;
                }
                else {
                    search_results(0);
                }
            }
            else {
                
                var results = _repository.SearchComponentsByDescription(searchTerm);

                if (results.Any()) {
                    search_results(results.Count);
                    dataGridView.DataSource = results;
                }
                else {
                    search_results(0);
                }
            }
        }

        private void buttonListAll_Click(object sender, EventArgs e) {
            fill_data_grid();
            fill_categories();
        }
    }
}