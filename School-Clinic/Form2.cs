using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School_Clinic
{
    public partial class MainDashboard : MaterialForm
    {
        private Form1 _loginForm;
        public MainDashboard(Form1 callingForm)
        {
            InitializeComponent();
            _loginForm = callingForm;
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.LightGreen800, Primary.LightGreen900, Primary.LightGreen500, Accent.Green700, TextShade.WHITE);

            materialTabSelector1.BaseTabControl = materialTabControl1;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //DrawerTabControl = materialTabControl1;
            //DrawerIsOpen = true;
            //DrawerShowIconsWhenHidden = true;
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            _loginForm.Show();
            this.Close();
        }



        private void materialButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        
    }
}
