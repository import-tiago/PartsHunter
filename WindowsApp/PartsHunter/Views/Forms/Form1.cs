using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using PartsHunter.Data.Entities;
using PartsHunter.Data.Repositories;


namespace PartsHunter {
    public partial class Form1 : Form {

        private readonly ComponentRepository _repository;
        public Form1() {
            InitializeComponent();
            _repository = new ComponentRepository();
            LoadComponents();
        }

        private void LoadComponents() {
            var components = _repository.GetAllComponents();
            dataGridView.DataSource = components; // Assuming you have a DataGridView named dataGridView                                                  
            dataGridView.Columns["Category"].DisplayIndex = 0;
            dataGridView.Columns["Id"].Visible = false;
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
            LoadComponents();
        }


        private void Form1_Load(object sender, EventArgs e) {
            // Get unique categories from the database
            var categories = _repository.GetUniqueCategories();

            // Insert "ALL" as the first item in the list
            categories.Insert(0, "ALL");

            // Bind the categories to the ComboBox
            cmbCategorySearch.DataSource = categories;
        }

        private void buttonSearch_Click(object sender, EventArgs e) {

            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm)) {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            string category = cmbCategorySearch.Text;
            if (category != "ALL") {
                // Search for components by description and category
                var results = _repository.SearchComponentsByDescriptionAndCategory(searchTerm, category);

                if (results.Any()) {
                    // Display results, for example, in a DataGridView
                    dataGridView.DataSource = results;
                }
                else {
                    MessageBox.Show("No components found matching the search criteria.");
                }
            }
            else {
                // Search for components by description
                var results = _repository.SearchComponentsByDescription(searchTerm);

                if (results.Any()) {
                    // Display results, for example, in a DataGridView
                    dataGridView.DataSource = results;
                }
                else {
                    MessageBox.Show("No components found matching the search term.");
                }
            }



        }

        private void buttonListAll_Click(object sender, EventArgs e) {
            LoadComponents();
            // Get unique categories from the database
            var categories = _repository.GetUniqueCategories();

            // Insert "ALL" as the first item in the list
            categories.Insert(0, "ALL");

            // Bind the categories to the ComboBox
            cmbCategorySearch.DataSource = categories;
        }

        private void tabPage2_Click(object sender, EventArgs e) {

        }
    }
}