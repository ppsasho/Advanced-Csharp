namespace DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label5.Hide();
            label6.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //if (!int.TryParse(textBox2.Text, out int firstNum))
            //{
            //    label5.Show();
            //    return;
            //}
            //if (!int.TryParse(textBox3.Text, out int secondNum))
            //{
            //    label6.Show();
            //    return;
            //}
            //int result = firstNum + secondNum;
            //textBox4.Text = result.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text, out int firstNum))
            {
                label5.Show();
                return;
            }
            if (!int.TryParse(textBox3.Text, out int secondNum))
            {
                label6.Show();
                return;
            }
            int result = firstNum + secondNum;
            textBox4.Text = result.ToString();
        }
    }
}
