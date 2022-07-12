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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "SA6c9TeKNfpRkSOEXbXnu16mooMaqNickhkxurM1",
            BasePath = "https://winformcrudopr-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {         
            if (e.ColumnIndex == dataGridView1.Columns["dataGridViewDeleteButton"].Index)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                var deleteUser = client.Delete("Owners/" + row.Cells[0].Value);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                MessageBox.Show("Owner  id " + row.Cells[0].Value + " Deleted Successfully");
            }
        }

        void renderLists(Dictionary<string, Owner> Owner)
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
            dataGridView1.Columns.Add("name", "Name");
            dataGridView1.Columns.Add("email", "Name");
            dataGridView1.Columns.Add("phoneNumber", "Phone Number");
            dataGridView1.Columns.Add("gender", "Gender");
            dataGridView1.Columns.Add("country", "Country");
            dataGridView1.Columns.Add("city", "City");
            dataGridView1.Columns.Add("state", "State");
            dataGridView1.Columns.Add("address", "Address");
            dataGridView1.Columns.Add(deleteButton);
            foreach (var items in Owner)
            {
                dataGridView1.Rows.Add(items.Value.Id, items.Value.name, items.Value.email, items.Value.phoneNumber, items.Value.gender, items.Value.country, items.Value.city, items.Value.state, items.Value.address);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse res = client.Get(@"Owners");
                Dictionary<string, Owner> data = JsonConvert.DeserializeObject<Dictionary<string, Owner>>(res.Body.ToString());
                renderLists(data);
            }
            catch
            {
                MessageBox.Show("Error In Connection to DB", "Error In Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
