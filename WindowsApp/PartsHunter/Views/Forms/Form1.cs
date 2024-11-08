using PartsHunter.Data;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using PartsHunter.Data.Entities;


namespace PartsHunter
{
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
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            // Collect form input
            string category = cmbCategory.Text;
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
            cmbCategory.SelectedIndex = -1;
            txtSlotID.Clear();
        }


        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}