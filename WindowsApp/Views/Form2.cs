using PartsHunter.Services;
using ComponentEntity = PartsHunter.Data.Entities.ComponentEntity;

namespace PartsHunter {
    public partial class Form2 : Form {

        private readonly ComponentService? component;
        private ComponentEntity componentEntity = new ComponentEntity();
        public int selected_database_id { get; set; }

        public Form2(ComponentService componentService) {
            InitializeComponent();
            component = componentService ?? throw new ArgumentNullException(nameof(componentService));
        }
        private void Form2_Load(object sender, EventArgs e) {

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridView.ColumnHeadersDefaultCellStyle.BackColor;

            if (selected_database_id > 0) {

                if (component != null) {
                    componentEntity = component.GetComponentById(selected_database_id);

                    if (componentEntity != null) {
                        dataGridView.DataSource = new List<ComponentEntity> { componentEntity };
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
            if (componentEntity != null) {
                componentEntity.Description = dataGridView.Rows[0].Cells["Description"].Value.ToString();
                componentEntity.Category = dataGridView.Rows[0].Cells["Category"].Value.ToString();

                var slotIdValue = dataGridView.Rows[0].Cells["SlotID"].Value.ToString();
                if (int.TryParse(slotIdValue, out int slotId)) {
                    componentEntity.SlotID = slotId;
                }
                else {
                    MessageBox.Show("Invalid SlotID value.");
                    return;
                }

                componentEntity.Id = selected_database_id;

                if (component != null) {
                    component.UpdateComponent(componentEntity);
                }
                else {
                    MessageBox.Show("Component service is not available.");
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e) {

            dataGridView.BeginEdit(true);

            var editControl = dataGridView.EditingControl as TextBox;
            if (editControl != null) {

                editControl.SelectionStart = editControl.Text.Length;
                editControl.SelectionLength = 0;
            }
        }
    }
}
