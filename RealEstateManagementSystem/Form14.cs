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
    public partial class Form14 : Form
    {
        public Form14()
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
            string propertyID = textBox1.Text;
            if (propertyID != null)
            {
                try
                {
                    client = new FireSharp.FirebaseClient(config);
                    var res = client.Get("Properties/" + propertyID);
                    PropertyType property = res.ResultAs<PropertyType>();
                    if (property != null)
                    {
                        Form12 f12 = new Form12();
                        f12.propertyID = propertyID;
                        f12.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Type Not Found", "Missing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please Enter Type ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
