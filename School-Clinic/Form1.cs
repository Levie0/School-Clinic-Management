namespace School_Clinic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.BackColor = Color.Transparent;
            button1.ForeColor = Color.Transparent;
            button1.Text = "";
            button1.Cursor = Cursors.Hand;

            this.AcceptButton = button1;


            StyleTextBox(textBox1, "Enter ID Number");
            StyleTextBox(textBox2, "Enter Password", true);


            this.Shown += (s, ev) =>
            {
                ApplyRoundedRegion(textBox1, 12);
                ApplyRoundedRegion(textBox2, 12);
            };
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Any(c => !char.IsDigit(c) && c != '-'))
            {
                MessageBox.Show("Please Input using your ID number");
                if (textBox1.Text.Length > 0)
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                    textBox1.SelectionStart = textBox1.Text.Length;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void StyleTextBox(TextBox tb, string placeholder, bool isPassword = false)
        {
            tb.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            tb.BorderStyle = BorderStyle.None;
            tb.BackColor = Color.FromArgb(230, 245, 250);
            tb.ForeColor = Color.Black;
            tb.Multiline = false;
            tb.PlaceholderText = placeholder;
            tb.UseSystemPasswordChar = isPassword;
            tb.Padding = new Padding(12);


            tb.Enter += (s, e) => tb.BackColor = Color.FromArgb(200, 235, 255);
            tb.Leave += (s, e) => tb.BackColor = Color.FromArgb(230, 245, 250);
        }


        private void ApplyRoundedRegion(Control c, int radius)
        {
            var rect = new Rectangle(0, 0, c.Width, c.Height);
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            c.Region = new Region(path);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.FromArgb(200, 235, 255);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.FromArgb(230, 245, 250);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "2024-0049" || textBox2.Text != "password")
            {
                MessageBox.Show("Incorrect UserID or Password");
            }
            else
            {
                mianDashBoard nextPage = new mianDashBoard(this);
                nextPage.Show();
                this.Hide();
            }
        }
    }
}
