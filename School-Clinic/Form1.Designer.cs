namespace School_Clinic
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(40, 142, 88);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 9F);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(126, 291);
            textBox1.MaxLength = 32600;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(203, 16);
            textBox1.TabIndex = 1;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(40, 142, 88);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 9F);
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(126, 349);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(203, 16);
            textBox2.TabIndex = 2;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(51, 111, 63);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(157, 403);
            button1.Name = "button1";
            button1.Size = new Size(125, 41);
            button1.TabIndex = 3;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackgroundImage = Properties.Resources.DMC_CLINIC_2;
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(811, 571);
            panel1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 572);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGIN";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Panel panel1;
    }
}
