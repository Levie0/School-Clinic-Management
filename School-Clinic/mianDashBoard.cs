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

        private const int LOW_STOCK_THRESHOLD = 10;

        private string _originalMedName;
        private int _originalQty;
        private string _originalDiagnosis; // To check for changes
        private string _originalDate;      // To check for changes
        private int _editingRowIndex = -1; // To know which row we are editing

        public mianDashBoard(Form1 callingForm)
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.Blue700, TextShade.WHITE);
            materialLabel1.UseAccent = true;
        }

        private ListBox _logBox; // The list that holds the text

        private void SetupLogFeature()
        {
            // 1. Initialize the ListBox
            _logBox = new ListBox();

            // 2. Add it to materialCard10 (The "Medicine Log Activity" card)
            materialCard10.Controls.Add(_logBox);

            // 3. Position it below the "Medicine Log Activity" label
            // label27 is the title, so we place the list below it.
            _logBox.Location = new Point(10, 50);
            _logBox.Size = new Size(materialCard10.Width - 20, materialCard10.Height - 60);

            // 4. Anchor it so it resizes if the window changes size
            _logBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // 5. Visual Styling (Optional: Remove border for cleaner look)
            _logBox.BorderStyle = BorderStyle.None;
            _logBox.Font = new Font("Segoe UI", 9);
        }

        private void LogActivity(string action, string medicineName)
        {
            if (_logBox == null) return;

            string timestamp = DateTime.Now.ToString("MMM dd - hh:mm tt");
            string logEntry = $"[{timestamp}] {action}: {medicineName}";

            // Add to top of list
            _logBox.Items.Insert(0, logEntry);
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



            SetupLogFeature();

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
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.");
                return;
            }

            _editingRowIndex = dataGridView1.SelectedRows[0].Index;
            var selectedRow = dataGridView1.Rows[_editingRowIndex];

            // --- 1. CRITICAL: PARSE THE "Biogesic(3)" STRING ---
            string combinedValue = selectedRow.Cells["Medication"].Value?.ToString() ?? "";

            // Reset values first
            _originalMedName = "";
            _originalQty = 0;

            if (combinedValue.Contains("(") && combinedValue.Contains(")"))
            {
                // Split "Biogesic(3)" -> Name: "Biogesic", Qty: "3"
                int openParenIndex = combinedValue.LastIndexOf('(');
                _originalMedName = combinedValue.Substring(0, openParenIndex).Trim();

                string qtyPart = combinedValue.Substring(openParenIndex + 1).Replace(")", "").Trim();
                int.TryParse(qtyPart, out _originalQty);
            }
            else
            {
                // If it's just "Biogesic" without a number
                _originalMedName = combinedValue.Trim();
                _originalQty = 0;
            }

            // --- 2. SETUP PANEL 1 ---
            panel1.Visible = true;
            panel1.BringToFront();

            comboBox3.Items.Clear();
            foreach (var item in _inventory)
            {
                // Load item if it has stock OR if it matches the current medicine
                if (item.Quantity > 0 || item.Name.Trim().ToLower() == _originalMedName.Trim().ToLower())
                {
                    comboBox3.Items.Add(item.Name);
                }
            }

            comboBox3.Text = _originalMedName;
            textBox21.Text = _originalQty.ToString();

            // --- 3. FILL OTHER TEXT BOXES ---
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //empty
        }

        private void saveEditBtn_Click(object sender, EventArgs e)
        {

            string newMedName = comboBox3.Text.Trim();
            int newQty = 0;
            int.TryParse(textBox21.Text, out newQty);

            // --- 2. FIND ITEMS IN INVENTORY ---
            // We clean the strings (Trim and ToLower) to ensure "Biogesic" matches "biogesic"
            var oldItem = _inventory.FirstOrDefault(x => x.Name.Trim().ToLower() == _originalMedName.Trim().ToLower());
            var newItem = _inventory.FirstOrDefault(x => x.Name.Trim().ToLower() == newMedName.Trim().ToLower());

            // --- DEBUGGING MESSAGE (Remove this later) ---
            string debugMsg = $"Original: {_originalMedName} (Qty: {_originalQty})\nNew: {newMedName} (Qty: {newQty})\n";
            if (oldItem != null) debugMsg += $"Found Old Item in Inv: {oldItem.Name} (Stock: {oldItem.Quantity})\n";
            else debugMsg += "WARNING: Old Item NOT found in Inventory!\n";
            if (newItem != null) debugMsg += $"Found New Item in Inv: {newItem.Name} (Stock: {newItem.Quantity})";
            else debugMsg += "WARNING: New Item NOT found in Inventory!";
            MessageBox.Show(debugMsg, "Debug Check");
            // ---------------------------------------------

            // --- 3. LOGIC: RETURN OLD STOCK ---
            if (oldItem != null)
            {
                oldItem.Quantity += _originalQty;
            }

            // --- 4. LOGIC: DEDUCT NEW STOCK ---
            if (newItem != null)
            {
                // Check if we have enough stock (considering we just added back the old stock if it was the same item)
                if (newItem.Quantity < newQty)
                {
                    MessageBox.Show($"Not enough stock! Available: {newItem.Quantity}", "Error");

                    // ROLLBACK: Remove the old stock again because we are cancelling
                    if (oldItem != null) oldItem.Quantity -= _originalQty;
                    return;
                }
                newItem.Quantity -= newQty;
            }
            else
            {
                MessageBox.Show($"Medicine '{newMedName}' not found in inventory. Cannot deduct stock.");
                // Rollback
                if (oldItem != null) oldItem.Quantity -= _originalQty;
                return;
            }

            // --- 5. UPDATE THE RECORD DISPLAY ---
            var currentRecord = _records[_editingRowIndex];

            currentRecord.thisName = textBox7.Text;
            currentRecord.thisAge = textBox9.Text;
            currentRecord.thisCourse = comboBox2.SelectedItem?.ToString();
            currentRecord.thisParent = textBox12.Text;
            currentRecord.thisContact = textBox11.Text;
            currentRecord.thisAllergies = textBox13.Text;
            currentRecord.thisTime = textBox17.Text;
            currentRecord.thisComplaint = textBox18.Text;
            currentRecord.thisAssesment = textBox19.Text;
            currentRecord.thisAction = textBox20.Text;
            currentRecord.thisBirth = dateTimePicker3.Text;
            currentRecord.thisDate = dateTimePicker4.Text;

            // Save the combined "Biogesic(4)" string
            currentRecord.thisMedication = $"{newMedName}({newQty})";

            // --- 6. SAVE AND REFRESH ---
            dataGridView1.Refresh();

            SaveInventory();
            SaveData();

            // CRITICAL: Force the Inventory UI to redraw
            RefreshInventoryUI();
            UpdateDashboardStats();

            MessageBox.Show("Success! Inventory and Record updated.");
            panel1.Visible = false;
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

            // --- LOGGING ---
            LogActivity("New Item Added", newItem.Name);

            textBox10.Clear();
            textBox16.Clear();
            panel5.Visible = false;
        }

        private void AddItemToVisualList(MedicineItem item)
        {

            Panel rowPanel = new Panel();
            rowPanel.Size = new Size(410, 50);
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

            // --- [UPDATED LOGIC: MINUS BUTTON] ---
            btnMinus.Click += (s, e) =>
            {
                if (item.Quantity > 0)
                {
                    item.Quantity--;
                    qtyLbl.Text = item.Quantity.ToString();
                    UpdateDashboardStats();
                    SaveInventory();

                    // LOG: Check for Out of Stock
                    if (item.Quantity == 0)
                    {
                        LogActivity("Out of Stock", item.Name);
                    }
                }
            };

            Button btnPlus = new Button();
            btnPlus.Text = "+";
            btnPlus.Size = new Size(30, 30);
            btnPlus.Location = new Point(370, 10);

            // --- [UPDATED LOGIC: PLUS BUTTON] ---
            btnPlus.Click += (s, e) =>
            {
                item.Quantity++;
                qtyLbl.Text = item.Quantity.ToString();
                UpdateDashboardStats();
                SaveInventory();

                // LOG: Restocked
                LogActivity("Restocked", item.Name);
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
                // --- LOGGING BEFORE REMOVE ---
                LogActivity("Item Removed", _selectedMedicine.Name);

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
        }

        //pp 
        //this comment is para kay kyle para ma update sa github 


        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void materialMaskedTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void materialCard8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void allstockNumber_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

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

        private void addMedicineBtn_Click(object sender, EventArgs e)
        {
            if (materialComboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a medicine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qtyNeeded;
            if (!int.TryParse(materialMaskedTextBox1.Text, out qtyNeeded) || qtyNeeded <= 0)
            {
                MessageBox.Show("Please enter a valid quantity (greater than 0).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedName = materialComboBox1.SelectedItem.ToString();
            var item = _inventory.FirstOrDefault(x => x.Name == selectedName);

            if (item != null)
            {
                if (item.Quantity < qtyNeeded)
                {
                    MessageBox.Show($"Not enough stock! Only {item.Quantity} left.", "Stock Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                item.Quantity -= qtyNeeded;

                // --- LOGGING ---
                if (item.Quantity == 0)
                {
                    LogActivity("Out of Stock", item.Name);
                }

                ListViewItem lvi = new ListViewItem(item.Name);
                lvi.SubItems.Add(qtyNeeded.ToString());
                listView1.Items.Add(lvi);

                SaveInventory();
                RefreshInventoryUI();
                UpdateDashboardStats();

                panel2.Visible = false;
                MessageBox.Show("Medicine added and stock updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void popupPanel_Click(object sender, EventArgs e)
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

        private void closePanelBtn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void closepopupPanel_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void materialCard1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }
    }
}
