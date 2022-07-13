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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "SA6c9TeKNfpRkSOEXbXnu16mooMaqNickhkxurM1",
            BasePath = "https://winformcrudopr-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        private void button1_Click(object sender, EventArgs e)
        {
            string userID = textBox1.Text;
            if (userID != null)
            {
                try
                {
                    client = new FireSharp.FirebaseClient(config);
                    var res = client.Get("Clients/" + userID);
                    Client user = res.ResultAs<Client>();
                    if (user != null)
                    {
                        Form9 f9 = new Form9();
                        f9.userId = userID;
                        f9.Show();
                        this.Close();
                    } else
                    {
                        MessageBox.Show("User Not Found", "Missing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please Enter User ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
