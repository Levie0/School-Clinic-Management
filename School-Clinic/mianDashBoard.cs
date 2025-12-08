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

        private void materialButton2_Click(object sender, EventArgs e)
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
                thisAction = textBox15.Text
            };

            _records.Add(records);
            SaveData();

            MessageBox.Show("Information has been saved successfully!");

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
    }
}
