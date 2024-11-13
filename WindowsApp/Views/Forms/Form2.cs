using PartsHunter.Services.DataService;
using System;
using System.Windows.Forms;
using PartsHunter.Data.Entities;
using PartsHunter.Services;
using System.ComponentModel;
using Component = PartsHunter.Data.Entities.Component;

namespace PartsHunter {
    public partial class Form2 : Form {
        private readonly ComponentService _componentService;
        public int selected_component_id { get; set; }
        private Component component;

        public Form2() {
            InitializeComponent();
            _componentService = new ComponentService();
        }

        private void Form2_Load(object sender, EventArgs e) {

            if (selected_component_id > 0) {

                component = _componentService.GetComponentById(selected_component_id);

                if (component != null) {
                    dataGridView.DataSource = new List<Component> { component };
                    dataGridView.Columns["Category"].DisplayIndex = 0;
                    dataGridView.Columns["Id"].Visible = false;
                }
                else
                    MessageBox.Show("Component not found.");
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e) {

            if (component != null) {

                component.Description = dataGridView.Rows[0].Cells["Description"].Value.ToString();
                component.Category = dataGridView.Rows[0].Cells["Category"].Value.ToString();
                component.SlotID = int.Parse(dataGridView.Rows[0].Cells["SlotID"].Value.ToString());
                component.Id = selected_component_id;

                _componentService.UpdateComponent(component);

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
