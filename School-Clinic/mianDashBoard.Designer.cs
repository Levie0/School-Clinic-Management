namespace School_Clinic
{
    partial class mianDashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mianDashBoard));
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            tabPage2 = new TabPage();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            tabPage3 = new TabPage();
            materialCard3 = new MaterialSkin.Controls.MaterialCard();
            imageList1 = new ImageList(components);
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
            materialTabControl1.Size = new Size(1439, 727);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(materialCard1);
            tabPage1.ImageKey = "home.png";
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1431, 699);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "HOME";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(10, 14);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(200, 100);
            materialCard1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(materialCard2);
            tabPage2.ImageKey = "history.png";
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1431, 699);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "RECENT VISITS";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialCard2
            // 
            materialCard2.Anchor = AnchorStyles.Top;
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(602, 17);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(200, 100);
            materialCard2.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(materialCard3);
            tabPage3.ImageKey = "medical-records.png";
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1431, 699);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "DEMICATIONS";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // materialCard3
            // 
            materialCard3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            materialCard3.BackColor = Color.FromArgb(255, 255, 255);
            materialCard3.Depth = 0;
            materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard3.Location = new Point(1217, 14);
            materialCard3.Margin = new Padding(14);
            materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard3.Name = "materialCard3";
            materialCard3.Padding = new Padding(14);
            materialCard3.Size = new Size(200, 100);
            materialCard3.TabIndex = 0;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "393626841_867175984654899_336107502310071441_n.png");
            imageList1.Images.SetKeyName(1, "590136278_1175111911497662_2432221814990234730_n (1).png");
            imageList1.Images.SetKeyName(2, "412900829_677452377926930_1930880079451953146_n.png");
            imageList1.Images.SetKeyName(3, "medical-records.png");
            imageList1.Images.SetKeyName(4, "history.png");
            imageList1.Images.SetKeyName(5, "home.png");
            // 
            // mianDashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1445, 794);
            Controls.Add(materialTabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            Name = "mianDashBoard";
            Text = "DMC clinic managent";
            WindowState = FormWindowState.Maximized;
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private ImageList imageList1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialCard materialCard3;
    }
}