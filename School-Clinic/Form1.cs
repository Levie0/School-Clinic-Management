

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


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "2024-0049" && textBox2.Text != "password")
            {
                MessageBox.Show("Incorrect UserID or Password");
            }
            else 
            {
                //MainDashboard nextPage = new MainDashboard(this);
                //nextPage.Show();
                //this.Hide();

                mianDashBoard nextPage = new mianDashBoard(this);
                nextPage.Show();
                this.Hide();
            }
        }
    }
}
