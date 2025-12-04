using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School_Clinic
{
    public partial class Form2 : Form
    {
        private Form1 _loginForm;
        public Form2(Form1 callingForm)
        {
            InitializeComponent();
            _loginForm = callingForm;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            _loginForm.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
