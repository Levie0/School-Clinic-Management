namespace School_Clinic
{
    partial class MainDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboard));
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            tabPage2 = new TabPage();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            tabPage3 = new TabPage();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            imageList1 = new ImageList(components);
            imageList2 = new ImageList(components);
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Controls.Add(tabPage3);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ImageList = imageList1;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1140, 621);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(materialLabel1);
            tabPage1.ImageKey = "393626841_867175984654899_336107502310071441_n.png";
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1132, 593);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "HOME";
            tabPage1.Click += tabPage1_Click;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            materialLabel1.Location = new Point(26, 17);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(66, 29);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Home";
            materialLabel1.Click += materialLabel1_Click_1;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(materialLabel2);
            tabPage2.ImageKey = "590136278_1175111911497662_2432221814990234730_n (1).png";
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1132, 593);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "RECENT VISITS";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            materialLabel2.Location = new Point(28, 19);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(141, 29);
            materialLabel2.TabIndex = 1;
            materialLabel2.Text = "Recent Visits";
            materialLabel2.Click += materialLabel2_Click;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.White;
            tabPage3.Controls.Add(materialLabel3);
            tabPage3.ImageKey = "412900829_677452377926930_1930880079451953146_n.png";
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1132, 593);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "MEDICATION";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            materialLabel3.Location = new Point(25, 15);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(140, 29);
            materialLabel3.TabIndex = 1;
            materialLabel3.Text = "Medications ";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "393626841_867175984654899_336107502310071441_n.png");
            imageList1.Images.SetKeyName(1, "590136278_1175111911497662_2432221814990234730_n (1).png");
            imageList1.Images.SetKeyName(2, "412900829_677452377926930_1930880079451953146_n.png");
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth32Bit;
            imageList2.ImageSize = new Size(16, 16);
            imageList2.TransparentColor = Color.Transparent;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1146, 688);
            Controls.Add(materialTabControl1);
            DrawerIsOpen = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            Margin = new Padding(2);
            Name = "MainDashboard";
            Text = "DMC clinic";
            WindowState = FormWindowState.Maximized;
            Load += Form2_Load;
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private ImageList imageList1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private ImageList imageList2;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
    }
}