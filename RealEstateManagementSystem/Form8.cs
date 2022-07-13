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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "SA6c9TeKNfpRkSOEXbXnu16mooMaqNickhkxurM1",
            BasePath = "https://winformcrudopr-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["dataGridViewDeleteButton"].Index)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                var deleteUser = client.Delete("Clients/" + row.Cells[0].Value);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                MessageBox.Show("Client id " + row.Cells[0].Value + " Deleted Successfully");
            }
        }
        void renderLists(Dictionary<string, Client> Client)
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
            dataGridView1.Columns.Add("cnic", "NIC Number");
            dataGridView1.Columns.Add("phoneNumber", "Phone Number");
            dataGridView1.Columns.Add("gender", "Gender");
            dataGridView1.Columns.Add(deleteButton);
            if (Client != null)
            {
                foreach (var items in Client)
                {
                    dataGridView1.Rows.Add(items.Value.Id, items.Value.name, items.Value.email, items.Value.cnic, items.Value.phoneNumber, items.Value.gender);
                }
            }
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse res = client.Get(@"Clients");
                Dictionary<string, Client> data = JsonConvert.DeserializeObject<Dictionary<string, Client>>(res.Body.ToString());
                renderLists(data);

            }
            catch
            {
                MessageBox.Show("Error In Connection to DB", "Error In Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
        }
    }
}
