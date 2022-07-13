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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "SA6c9TeKNfpRkSOEXbXnu16mooMaqNickhkxurM1",
            BasePath = "https://winformcrudopr-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userID = textBox1.Text;  
            if(userID != null)
            {
                try
                {
                    client = new FireSharp.FirebaseClient(config);
                    var res = client.Get("Owners/" + userID);
                    Owner user = res.ResultAs<Owner>();
                    if(user != null)
                    {
                    Form5 f5 = new Form5();
                    f5.userId = userID;
                    f5.Show();
                    this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("User Not Found", "Missing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            } else
            {
                MessageBox.Show("Please Enter User ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
