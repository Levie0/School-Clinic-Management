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
    public partial class mianDashBoard : MaterialForm
    {
        public mianDashBoard(Form1 callingForm)
        {
            InitializeComponent();

            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.LightGreen800, Primary.LightGreen900, Primary.LightGreen500, Accent.Green700, TextShade.WHITE);
        }
    }
}
