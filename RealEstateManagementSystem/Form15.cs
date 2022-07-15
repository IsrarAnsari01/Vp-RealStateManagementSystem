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
    public partial class Form15 : Form
    {
        public Form15()
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
                var respose_02 = client.Get("Owners/" + row.Cells[9].Value);
                Owner owner = respose_02.ResultAs<Owner>();
                if (row.Cells[10].Value != null && row.Cells[10].Value != "")
                {
                    var respose_03 = client.Get("Clients/" + row.Cells[10].Value);
                    Client iClient = respose_03.ResultAs<Client>();
                    MessageBox.Show("Property Detail Information \n City " + row.Cells[1].Value + "\n State " + row.Cells[2].Value + "\n Property Type " + row.Cells[4].Value + "\n Property Location " + row.Cells[8].Value + " \n \n Owner Information \n  \n Name " + owner.name + "\n Email " + owner.email + "Phone number " + owner.phoneNumber + "\n \n Client Information \n \n Name " + iClient.name + "\n  CNIC / NIC " + iClient.cnic + "\n Gender " + iClient.gender + " \n Phone Number" + iClient.phoneNumber, "Property Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Property Detail Information \n City " + row.Cells[1].Value + "\n State " + row.Cells[2].Value + "\n Property Type " + row.Cells[4].Value + "\n Property Location " + row.Cells[8].Value + " \n \n  Owner Information \n \n Name " + owner.name + "\n Email " + owner.email + "Phone number " + owner.phoneNumber, "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                }
                return;
            }
        }

        void renderLists(Dictionary<string, EstateProperty> EstateProperty)
        {
            var view = new DataGridViewButtonColumn();
            view.Name = "dataGridViewDeleteButton";
            view.HeaderText = "View";
            view.Text = "View";
            view.UseColumnTextForButtonValue = true;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("city", "City");
            dataGridView1.Columns.Add("state", "State");
            dataGridView1.Columns.Add("zipCode", "Zip Code");
            dataGridView1.Columns.Add("propertyType", "Property Type");
            dataGridView1.Columns.Add("view", "View");
            dataGridView1.Columns.Add("size", "Property Size");
            dataGridView1.Columns.Add("price", "Property Price");
            dataGridView1.Columns.Add("address", "Full Address");
            dataGridView1.Columns.Add("owner", "Owner Id");
            dataGridView1.Columns.Add("client", "Client Id");
            dataGridView1.Columns.Add(view);
            if (EstateProperty != null)
            {
                foreach (var items in EstateProperty)
                {
                    if (items.Value.owner != null)
                    {
                        dataGridView1.Rows.Add(items.Value.Id, items.Value.city, items.Value.state, items.Value.zipCode, items.Value.propertyType, items.Value.view, items.Value.size, items.Value.price, items.Value.address, items.Value.owner, items.Value.client);
                    }
                }
            }
        }



        private void Form15_Load(object sender, EventArgs e)
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
    }
}

