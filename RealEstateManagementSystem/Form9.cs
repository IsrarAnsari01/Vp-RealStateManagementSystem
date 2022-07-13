using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace RealEstateManagementSystem
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "SA6c9TeKNfpRkSOEXbXnu16mooMaqNickhkxurM1",
            BasePath = "https://winformcrudopr-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        string randomID;
        public string userId;
        private void label6_Click(object sender, EventArgs e)
        {
         
        }
        public void clearFields()
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.radioButton3.Checked = false;

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (userId != null)
                {
                    var res = client.Get("Clients/" + userId);
                    Client user = res.ResultAs<Client>();
                    textBox1.Text = user.name;
                    textBox2.Text = user.email;
                    textBox3.Text = user.cnic;
                    textBox4.Text = user.phoneNumber;
                    if (user.gender == "Male")
                    {
                        radioButton1.Checked = true;
                    }
                    else if (user.gender == "Female")
                    {
                        radioButton2.Checked = true;
                    }
                    else
                    {
                        radioButton3.Checked = true;
                    }
                    button1.Text = "Update";
                }
            }
            catch
            {
                MessageBox.Show("Error In Connection to DB", "Error In Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void randID()
        {
            Random num = new Random();
            int number = num.Next();
            randomID = Convert.ToString(number);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            string cnic = textBox3.Text;
            string phoneNumber = textBox4.Text;
            string gender = "";
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                gender = radioButton2.Text;
            }
            else
            {
                gender = radioButton3.Text;
            }
            
            randID();
            if (name.Trim().Length > 0 && email.Trim().Length > 0 && cnic.Trim().Length > 0 && phoneNumber.Trim().Length > 0 && gender.Trim().Length > 0)
            {
                Client Client = new Client()
                {
                    Id = this.userId != null ? this.userId : randomID,
                    name = name,
                    email = email,
                    cnic = cnic,
                    phoneNumber = phoneNumber,
                    gender = gender,
                };
                if (this.userId != null)
                {
                    var updateUser = client.Update("Clients/" + userId, Client);
                    MessageBox.Show("Client Updated with id " + userId + " Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    var saveUser = client.Set("Clients/" + randomID, Client);
                    MessageBox.Show("Client Added with id " + randomID + " Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                clearFields();
            }
            else
            {
                MessageBox.Show("All are required Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
