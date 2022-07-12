using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstateManagementSystem
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        string randomID;
        string[] countries = { "Pakistan" };
        string[] citiesInPak = { "Karachi", "Lahore", "Islamabad", "KPK", "Faisalabad", "Multan", "Peshawar", "Sialkot", "Quetta", "Hydrabad"};

        private void Form5_Load(object sender, EventArgs e)
        {
            foreach(string country in countries)
            {
                comboBox1.Items.Add(country);
            }
        }
        public void clearFields()
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.radioButton3.Checked = false;
            this.richTextBox1.Text = "";
            foreach(string city in citiesInPak)
            {
                comboBox2.Items.Remove(city);
            }
            foreach (string country in countries)
            {
                comboBox1.Items.Remove(country);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string country = comboBox1.Text;
            if(country == "Pakistan")
            {
                foreach(string city in citiesInPak)
                {
                    comboBox2.Items.Add(city);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.clearFields();
        }
        
        public void randID()
        {
            Random num = new Random();
            int number = num.Next();
            randomID = Convert.ToString(number);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            string cnic = textBox3.Text;
            string phoneNumber = textBox5.Text;
            string gender = "";    
            if(radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            } else if (radioButton2.Checked == true)
            {
                gender = radioButton2.Text;
            } else
            {
                gender = radioButton3.Text;
            }
            string country = comboBox1.Text;
            string city = comboBox2.Text;
            string state = textBox4.Text;
            string address = richTextBox1.Text;

            if(name.Trim().Length > 0 && email.Trim().Length > 0 && cnic.Trim().Length > 0 && phoneNumber.Trim().Length > 0 && gender.Trim().Length > 0 && country.Trim().Length > 0 && city.Trim().Length > 0 && state.Trim().Length > 0 && address.Trim().Length > 0)
            {

            } else
            {
                MessageBox.Show("All are required Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
}