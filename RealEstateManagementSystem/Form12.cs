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
using FireSharp.Response;
using Newtonsoft.Json;

namespace RealEstateManagementSystem
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        
        string[] citiesInPak = { "Karachi", "Lahore", "Islamabad", "KPK", "Faisalabad", "Multan", "Peshawar", "Sialkot", "Quetta", "Hydrabad" };
        string[] propertyTypes = { "Vacant Land", "Residential Properties", "Commercial Properties", "Industrial Properties", "Agricultural Properties", "Mixed-Use Properties", "State-Owned or Special Purpose Properties"};
        public string propertyID;
        public string clientId;
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "SA6c9TeKNfpRkSOEXbXnu16mooMaqNickhkxurM1",
            BasePath = "https://winformcrudopr-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
       
        string randomID;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form12_Load(object sender, EventArgs e)
        {
            this.label10.Hide();
            this.comboBox4.Hide();
            foreach(string city in citiesInPak)
            {
                comboBox1.Items.Add(city);
            }
            foreach(string ptype in propertyTypes)
            {
                comboBox2.Items.Add(ptype); 
            }
            
            try
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse respose = client.Get(@"Owners");
                Dictionary<string, Owner> data = JsonConvert.DeserializeObject<Dictionary<string, Owner>>(respose.Body.ToString());
                if(data != null)
                {
                    var comboSource = new Dictionary<string , string>();
                    comboSource.Add("", "");
                    foreach (var owner in data)
                    {
                        comboSource.Add(owner.Value.Id, owner.Value.name);
                    }
                    comboBox3.DataSource = new BindingSource(comboSource, null);
                    comboBox3.DisplayMember = "Value";
                    comboBox3.ValueMember = "Key";
                }
                if (propertyID != null)
                {
                    this.label10.Show();
                    this.comboBox4.Show();
                    FirebaseResponse response = client.Get(@"Clients");
                    Dictionary<string, Client> data02 = JsonConvert.DeserializeObject<Dictionary<string, Client>>(response.Body.ToString());
                    if (data02 != null)
                    {
                        var comboSource02 = new Dictionary<string, string>();
                        comboSource02.Add("", "");
                        foreach (var client in data02)
                        {
                            comboSource02.Add(client.Value.Id, client.Value.name);
                        }
                        comboBox4.DataSource = new BindingSource(comboSource02, null);
                        comboBox4.DisplayMember = "Value";
                        comboBox4.ValueMember = "Key";
                    }

                    var res = client.Get("Properties/" + propertyID);
                    EstateProperty property = res.ResultAs<EstateProperty>();
                    var respose_02 = client.Get("Owners/"+ property.owner);
                    Owner owner = respose_02.ResultAs<Owner>();
                    comboBox1.Text = property.city;
                    textBox1.Text = property.state;
                    textBox2.Text = property.zipCode;
                    comboBox2.Text = property.propertyType;
                    textBox3.Text = property.size;
                    if(property.view == "East Open")
                    {
                        checkBox1.Checked = true;
                    } else if (property.view == "West Open")
                    {
                        checkBox2.Checked = true;
                    } else
                    {
                        checkBox3.Checked = true;
                    }
                    richTextBox1.Text = property.address;
                    comboBox3.Text = owner.name;
                    button1.Text = "Update";
                }
            }
            catch
            {
                MessageBox.Show("Error In Connection to DB", "Error In Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        public void clearFields()
        {
            this.textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            richTextBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            comboBox4.Text = "";

        }
        public void randID()
        {
            Random num = new Random();
            int number = num.Next();
            randomID = Convert.ToString(number);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string city = comboBox1.Text;
            string state = textBox1.Text;
            string zipcode = textBox2.Text;
            string propertyType = comboBox2.Text;
            string size = textBox3.Text;
            string view;
            if(checkBox1.Checked == true)
            {
                view = checkBox1.Text;
            } else if (checkBox2.Checked == true)
            {
                view = checkBox2.Text;
            } else
            {
                view = checkBox3.Text;
            }
            string address = richTextBox1.Text;
            string ownerId = ((KeyValuePair<string, string>)comboBox3.SelectedItem).Key;
            if(propertyID != null)
            {
                clientId  = ((KeyValuePair<string, string>)comboBox4.SelectedItem).Key;
            }
            if (city.Trim().Length > 0 && state.Trim().Length > 0 && zipcode.Trim().Length > 0 && propertyType.Trim().Length > 0 && size.Trim().Length > 0 && view.Trim().Length > 0 && address.Trim().Length > 0 && ownerId.Trim().Length > 0)
            {
                randID();
                EstateProperty property = new EstateProperty()
                {
                    Id = propertyID != null ? propertyID : randomID,
                    city = city,
                    state = state,
                    zipCode = zipcode,
                    propertyType = propertyType,
                    size = size,
                    view = view,
                    address = address,
                    owner = ownerId,
                    client = clientId != null ? clientId : "",
                };
                if (propertyID != null)
                {
                    var propertyUpdate = client.Update("Properties/" + propertyID, property);
                    MessageBox.Show("Property Updated with id " + propertyID + " Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    var saveProperty = client.Set("Properties/" + randomID, property);
                    MessageBox.Show("Property Added with id " + randomID + " Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                clearFields();
            } else
            {
                MessageBox.Show("All are required Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
