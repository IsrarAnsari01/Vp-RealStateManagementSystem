namespace RealEstateManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string username = "group8ia";
        string password = "group8ia";

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void cleanFields()
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string uName = textBox1.Text;
            string uPass = textBox2.Text;
            if((uName.Trim().Length > 0 && uPass.Trim().Length > 0) && (username == uName && password == uPass))
            {
                this.cleanFields();
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Wrong Credentials Please contect the app owner","Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}