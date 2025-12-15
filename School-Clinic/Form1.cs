

namespace School_Clinic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox2.PasswordChar = '*';// charles
        }

        private void Form1_Load(object sender, EventArgs e) //charles (para ni invisible sa button)
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
        }

        private void textBox2_TextChanged(object sender, EventArgs e) //charles
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//charles
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

        private void button1_Click(object sender, EventArgs e)// charles
        {
            if (textBox1.Text != "2024-0049" || textBox2.Text != "password")
            {
                MessageBox.Show("Incorrect UserID or Password");
                return;
            }

            mianDashBoard nextPage = new mianDashBoard(this);
            nextPage.Show();
            this.Hide();
        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
