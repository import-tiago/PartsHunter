using PartsHunter.Services.DataService;
using System;
using System.Windows.Forms;
using PartsHunter.Data.Entities;
using PartsHunter.Services;
using System.ComponentModel;
using Component = PartsHunter.Data.Entities.Component;

namespace PartsHunter {
    public partial class Form2 : Form {

        private readonly ComponentService? _componentService;
        public int selected_component_id { get; set; }
        private Component component = new Component();

        public Form2(ComponentService componentService) {
            InitializeComponent();
            _componentService = componentService ?? throw new ArgumentNullException(nameof(componentService));
        }

        private void Form2_Load(object sender, EventArgs e) {
            if (selected_component_id > 0) {
                // Check if _componentService is null before calling its method
                if (_componentService != null) {
                    component = _componentService.GetComponentById(selected_component_id);

                    // Check if component is null after calling the service
                    if (component != null) {
                        dataGridView.DataSource = new List<Component> { component };
                        dataGridView.Columns["Category"].DisplayIndex = 0;
                        dataGridView.Columns["Id"].Visible = false;
                    }
                    else {
                        MessageBox.Show("Component not found.");
                    }
                }
                else {
                    MessageBox.Show("Component service is not initialized.");
                }
            }
        }





        private void buttonSaveChanges_Click(object sender, EventArgs e) {
            if (component != null) {
                component.Description = dataGridView.Rows[0].Cells["Description"].Value.ToString();
                component.Category = dataGridView.Rows[0].Cells["Category"].Value.ToString();

                var slotIdValue = dataGridView.Rows[0].Cells["SlotID"].Value.ToString();
                if (int.TryParse(slotIdValue, out int slotId)) {
                    component.SlotID = slotId;
                }
                else {
                    MessageBox.Show("Invalid SlotID value.");
                    return;
                }

                component.Id = selected_component_id;

                // Check if _componentService is not null before calling UpdateComponent
                if (_componentService != null) {
                    _componentService.UpdateComponent(component);
                }
                else {
                    MessageBox.Show("Component service is not available.");
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }


    }
}
