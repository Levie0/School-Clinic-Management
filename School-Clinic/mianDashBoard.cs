using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;

namespace School_Clinic
{
    public partial class mianDashBoard : MaterialForm
    {
        private BindingList<Records> _records = new BindingList<Records>();
        private readonly string _filePath = "School-Clinic_thisjson.json";

        private BindingList<MedicineItem> _inventory = new BindingList<MedicineItem>();
        private readonly string _inventoryFilePath = "Inventory_Data.json";

        private MedicineItem _selectedMedicine = null;
        private Panel _selectedPanel = null;

        private const int LOW_STOCK_THRESHOLD = 3;

        public mianDashBoard(Form1 callingForm)
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.LightGreen800, Primary.LightGreen900, Primary.LightGreen500, Accent.Green700, TextShade.WHITE);
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {
            // You can leave it empty, it's fine
        }




        private void materialCard2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void materialCard4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            List<string> medList = new List<string>();

            foreach (ListViewItem item in listView1.Items)
            {
                // item.Text is the Name, item.SubItems[1].Text is the Quantity
                string medInfo = $"{item.Text} ({item.SubItems[1].Text})";
                medList.Add(medInfo);
            }

            // Join them with a comma and space
            string medicationString = string.Join(", ", medList);


            // 2. CREATE THE RECORD object
            var records = new Records
            {
                thisName = textBox1.Text,
                thisAge = textBox2.Text,
                thisCourse = comboBox1.SelectedItem?.ToString(),
                thisBirth = dateTimePicker3.Text,
                thisParent = textBox6.Text,
                thisContact = textBox4.Text,
                thisAllergies = textBox3.Text,
                thisDate = dateTimePicker4.Text,
                thisTime = textBox5.Text,
                thisComplaint = textBox8.Text,
                thisAssesment = textBox14.Text,
                thisAction = textBox15.Text,

                // NEW: Save the combined string we created above
                thisMedication = medicationString
            };

            // 3. ADD TO LIST AND SAVE
            _records.Add(records);
            SaveData();

            MessageBox.Show("Information has been saved successfully!");

            // 4. CLEAR ALL CONTROLS (Reset the form)
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            textBox6.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox8.Clear();
            textBox14.Clear();
            textBox15.Clear();

            // NEW: Clear the ListView so it is empty for the next student
            listView1.Items.Clear();
            listView1.Items.Clear();
        }

        //Tig load sa na save nga Data(Ayaw Hilabti)
        private void mianDashBoard_Load(object sender, EventArgs e)
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                var list = JsonSerializer.Deserialize<List<Records>>(json) ?? new List<Records>();
                _records = new BindingList<Records>(list);
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _records;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            if (System.IO.File.Exists(_inventoryFilePath))
            {
                string json = System.IO.File.ReadAllText(_inventoryFilePath);
                _inventory = JsonSerializer.Deserialize<BindingList<MedicineItem>>(json) ?? new BindingList<MedicineItem>();
            }

            // 2. Display the loaded items visually
            foreach (var item in _inventory)
            {
                AddItemToVisualList(item);
            }

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            // Add columns if they are missing (prevents duplication if you reload)
            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("Medicine Name", 200);
                listView1.Columns.Add("Qty", 50);
            }

            // 3. Update the stock numbers immediately
            UpdateDashboardStats();
        }

        //Tig Save ni nga function(Ayaw Hilabti Nigga!)
        private void SaveData()
        {

            string json = JsonSerializer.Serialize(_records.ToList(), new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var records = dataGridView1.CurrentRow.DataBoundItem as Records;
            if (records != null)
            {
                textBox7.Text = records.thisName;
                textBox9.Text = records.thisAge;
                comboBox2.SelectedItem = records.thisCourse;
                textBox12.Text = records.thisParent;
                textBox11.Text = records.thisContact;
                textBox13.Text = records.thisAllergies;
                textBox17.Text = records.thisTime;
                textBox18.Text = records.thisComplaint;
                textBox19.Text = records.thisAssesment;
                textBox20.Text = records.thisAction;
                dateTimePicker3.Text = records.thisBirth;
                dateTimePicker4.Text = records.thisDate;


            }
        }

        private void saveEditBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var records = dataGridView1.CurrentRow.DataBoundItem as Records;
            if (records != null)
            {
                records.thisName = textBox7.Text;
                records.thisAge = textBox9.Text;
                records.thisCourse = comboBox2.SelectedItem?.ToString();
                records.thisParent = textBox12.Text;
                records.thisContact = textBox11.Text;
                records.thisAllergies = textBox13.Text;
                records.thisTime = textBox17.Text;
                records.thisComplaint = textBox18.Text;
                records.thisAssesment = textBox19.Text;
                records.thisAction = textBox20.Text;
                records.thisBirth = dateTimePicker3.Text;
                records.thisDate = dateTimePicker4.Text;

                dataGridView1.Refresh();
                SaveData();

                panel1.Visible = false;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox9.Clear();
            comboBox2.SelectedIndex = -1;
            textBox12.Clear();
            textBox11.Clear();
            textBox13.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();

            panel1.Visible = false;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow == null) return;

            var records = dataGridView1.CurrentRow.DataBoundItem as Records;
            if (records != null)
            {
                DialogResult result = MessageBox.Show(
               "Are you sure you want to delete this data?",
               "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
        );
                if (result == DialogResult.Yes)
                {
                    _records.Remove(records);
                    SaveData();

                    textBox7.Clear();
                    textBox9.Clear();
                    comboBox2.SelectedIndex = -1;
                    textBox12.Clear();
                    textBox11.Clear();
                    textBox13.Clear();
                    textBox17.Clear();
                    textBox18.Clear();
                    textBox19.Clear();
                    textBox20.Clear();
                }
            }
        }
        //lklklk

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            //gubaon kaau ang material skin
        }

        private void materialCard3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialCard9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchbar1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchbar1.Text.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dataGridView1.DataSource = _records;
                return;
            }

            var filteredList = _records.Where(r =>
            r.thisName != null && r.thisName.ToLower().Contains(searchTerm)
            ).ToList();

            dataGridView1.DataSource = filteredList;
        }

        private void addmedic_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel5.BringToFront();
            panel5.BackColor = Color.DarkGreen;
            label18.BackColor = Color.DarkGreen;
            label26.BackColor = Color.DarkGreen;
            label18.ForeColor = Color.White;
            label26.ForeColor = Color.White;
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            MedicineItem newItem = new MedicineItem
            {
                Name = textBox10.Text,
                Quantity = int.Parse(textBox16.Text)
            };


            _inventory.Add(newItem);


            SaveInventory();


            AddItemToVisualList(newItem);


            UpdateDashboardStats();


            textBox10.Clear();
            textBox16.Clear();
            panel5.Visible = false;
        }

        private void AddItemToVisualList(MedicineItem item)
        {

            Panel rowPanel = new Panel();
            rowPanel.Size = new Size(405, 50);
            rowPanel.BackColor = Color.White;
            rowPanel.Margin = new Padding(5);
            rowPanel.BorderStyle = BorderStyle.FixedSingle;


            Label nameLbl = new Label();
            nameLbl.Text = item.Name;
            nameLbl.Location = new Point(10, 15);
            nameLbl.AutoSize = true;
            nameLbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);


            Label qtyLbl = new Label();
            qtyLbl.Text = item.Quantity.ToString();
            qtyLbl.Location = new Point(340, 15);
            qtyLbl.AutoSize = true;
            qtyLbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);


            EventHandler selectAction = (s, e) =>
            {

                if (_selectedPanel != null)
                {
                    _selectedPanel.BackColor = Color.White;
                }


                _selectedMedicine = item;
                _selectedPanel = rowPanel;
                _selectedPanel.BackColor = Color.LightGreen;
            };


            rowPanel.Click += selectAction;
            nameLbl.Click += selectAction;
            qtyLbl.Click += selectAction;



            Button btnMinus = new Button();
            btnMinus.Text = "-";
            btnMinus.Size = new Size(30, 30);
            btnMinus.Location = new Point(300, 10);
            btnMinus.Click += (s, e) =>
            {
                if (item.Quantity > 0)
                {
                    item.Quantity--;
                    qtyLbl.Text = item.Quantity.ToString();
                    UpdateDashboardStats();
                    SaveInventory();
                }
            };


            Button btnPlus = new Button();
            btnPlus.Text = "+";
            btnPlus.Size = new Size(30, 30);
            btnPlus.Location = new Point(370, 10);
            btnPlus.Click += (s, e) =>
            {
                item.Quantity++;
                qtyLbl.Text = item.Quantity.ToString();
                UpdateDashboardStats();
                SaveInventory();
            };


            rowPanel.Controls.Add(nameLbl);
            rowPanel.Controls.Add(btnMinus);
            rowPanel.Controls.Add(qtyLbl);
            rowPanel.Controls.Add(btnPlus);


            pnlInventoryList.Controls.Add(rowPanel);
        }

        private void UpdateDashboardStats()
        {

            int totalStock = _inventory.Sum(x => x.Quantity);
            allstockNumber.Text = totalStock.ToString();


            int lowStockCount = _inventory.Count(x => x.Quantity > 0 && x.Quantity <= LOW_STOCK_THRESHOLD);
            LowstockNumber.Text = lowStockCount.ToString();


            int outStockCount = _inventory.Count(x => x.Quantity == 0);
            outofstockNumber.Text = outStockCount.ToString();
        }

        private void SaveInventory()
        {
            string json = JsonSerializer.Serialize(_inventory);
            System.IO.File.WriteAllText(_inventoryFilePath, json);
        }

        private void removeMedicBtn_Click(object sender, EventArgs e)
        {
            if (_selectedMedicine == null)
            {
                MessageBox.Show("Please select a medicine to remove first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var result = MessageBox.Show($"Are you sure you want to remove '{_selectedMedicine.Name}'?",
                                         "Confirm Delete",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                _inventory.Remove(_selectedMedicine);


                if (_selectedPanel != null)
                {
                    pnlInventoryList.Controls.Remove(_selectedPanel);
                    _selectedPanel.Dispose();
                }


                SaveInventory();
                UpdateDashboardStats();


                _selectedMedicine = null;
                _selectedPanel = null;
            }

            //pp 
            //this comment is para kay kyle para ma update sa github 
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.BringToFront();

            // Clear previous selection
            materialComboBox1.Items.Clear();
            materialMaskedTextBox1.Clear();

            // Load ONLY available medicines
            foreach (var item in _inventory)
            {
                if (item.Quantity > 0)
                {
                    materialComboBox1.Items.Add(item.Name);
                }
            }

            if (materialComboBox1.Items.Count == 0)
            {
                MessageBox.Show("No medicines available in stock!", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cancelSelectMedic_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void RefreshInventoryUI()
        {
            // 1. Clear the current visual list
            pnlInventoryList.Controls.Clear();

            // 2. Re-add items from the updated list
            foreach (var item in _inventory)
            {
                AddItemToVisualList(item);
            }

            // 3. Update the stats numbers (Low stock, etc.)
            UpdateDashboardStats();
        }

        private void addSelectedMedic_Click(object sender, EventArgs e)
        {
            if (materialComboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a medicine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. VALIDATION: Check if quantity is valid
            int qtyNeeded;
            if (!int.TryParse(materialMaskedTextBox1.Text, out qtyNeeded) || qtyNeeded <= 0)
            {
                MessageBox.Show("Please enter a valid quantity (greater than 0).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. FIND THE MEDICINE
            string selectedName = materialComboBox1.SelectedItem.ToString();
            var item = _inventory.FirstOrDefault(x => x.Name == selectedName);

            if (item != null)
            {
                // 4. CHECK STOCK
                if (item.Quantity < qtyNeeded)
                {
                    MessageBox.Show($"Not enough stock! Only {item.Quantity} left.", "Stock Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 5. DEDUCT STOCK
                item.Quantity -= qtyNeeded;

                // 6. ADD TO LISTVIEW (The visual list below the button)
                ListViewItem lvi = new ListViewItem(item.Name);
                lvi.SubItems.Add(qtyNeeded.ToString());
                listView1.Items.Add(lvi);

                // 7. SAVE AND REFRESH UI
                SaveInventory();       // Save changes to JSON file
                RefreshInventoryUI();  // Update the Inventory Tab immediately
                UpdateDashboardStats();// Update the Home Tab counters

                // 8. CLOSE POPUP
                panel2.Visible = false;

                MessageBox.Show("Medicine added and stock updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void closeBtnforPaneladd_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }
    }
}
