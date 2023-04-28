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
            // DGV veritabanina baglama kodu

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
            //sifirlama botunu kodu

            textBox1.Text = " ";
            textBox2.Text = " ";
            comboBox1.SelectedItem = " ";
            comboBox2.SelectedItem = " ";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //sil botunu kodlandi
            //ilk önce veritabanina bagladik ve silme kodu yazıldı

            if (textBox2.Text == "")
            {
                MessageBox.Show("silmek için uçuş kodu girin");

            }
            else
            {
                try
                {
                    con.Open();
                    String Query = "delete from uçuşlar where ucuskodu ='" + textBox2.Text + "';";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("uçuş başarıyla silindi !!!");

                    con.Close();
                    ucuslar();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        

        }
    }
}
