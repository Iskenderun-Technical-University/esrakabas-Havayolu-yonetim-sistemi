using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace havayolu_yonetim_sistemi
{
    public partial class uçuşları_göster : Form
    {


        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();


        public uçuşları_göster()
        {
            InitializeComponent();
            con.ConnectionString = @"Data Source=DESKTOP-MDN807P;Initial Catalog=havayolu;Integrated Security=True";

        }
        private void ucuslar()

        {
            con.Open();
            String Query = "select * from uçuşlar ";
            SqlDataAdapter sda = new SqlDataAdapter(Query,con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.SelectedItem = dataGridView1.SelectedRows[0].Cells[2].Value.ToString(); 
            
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            
        }

        private void uçuşları_göster_Load(object sender, EventArgs e)
        {
            ucuslar();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            uçuşlar ucu = new uçuşlar();
            ucu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            comboBox1.SelectedItem = " ";
            comboBox2.SelectedItem = " ";

        }
    }
}
