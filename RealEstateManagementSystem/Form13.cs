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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "SA6c9TeKNfpRkSOEXbXnu16mooMaqNickhkxurM1",
            BasePath = "https://winformcrudopr-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public string clientName;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["dataGridViewDeleteButton"].Index)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                var deleteUser = client.Delete("Properties/" + row.Cells[0].Value);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                MessageBox.Show("Property id " + row.Cells[0].Value + " Deleted Successfully");
            }
        }
        void renderLists(Dictionary<string, EstateProperty> EstateProperty)
        {
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "dataGridViewDeleteButton";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("city", "City");
            dataGridView1.Columns.Add("state", "State");
            dataGridView1.Columns.Add("zipCode", "Zip Code");
            dataGridView1.Columns.Add("propertyType", "Property Type");
            dataGridView1.Columns.Add("view", "View");
            dataGridView1.Columns.Add("address", "Full Address");
            dataGridView1.Columns.Add("owner", "Owner Name");
            dataGridView1.Columns.Add("client", "Client Name");
            dataGridView1.Columns.Add(deleteButton);
            if (EstateProperty != null)
            {
                foreach (var items in EstateProperty)
                {
                    if(items.Value.owner != null)
                    {
                        var respose_02 = client.Get("Owners/" + items.Value.owner);
                        Owner owner = respose_02.ResultAs<Owner>();
                        if(items.Value.client != null)
                        {
                        var respose_03 = client.Get("Clients/" + items.Value.client);
                        Client iClient = respose_03.ResultAs<Client>();
                        clientName = iClient.name;

                        }
                        string interestedclient = items.Value.client != null ? clientName : "";
                        dataGridView1.Rows.Add(items.Value.Id, items.Value.city, items.Value.state, items.Value.zipCode, items.Value.propertyType, items.Value.view, items.Value.address, owner.name, interestedclient);
                    }
                }
            }
        }
        private void Form13_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse res = client.Get(@"Properties");
                Dictionary<string, EstateProperty> data = JsonConvert.DeserializeObject<Dictionary<string, EstateProperty>>(res.Body.ToString());
                renderLists(data);

            }
            catch
            {
                MessageBox.Show("Error In Connection to DB", "Error In Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.Show();
        }
    }
}
