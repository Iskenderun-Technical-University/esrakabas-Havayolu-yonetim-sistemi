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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace havayolu_yonetim_sistemi
{
    public partial class yolculargoster : Form
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();



        public yolculargoster()
        {
            InitializeComponent();
            con.ConnectionString = @"Data Source=DESKTOP-MDN807P;Initial Catalog=havayolu;Integrated Security=True";
        }

        private void ucuslar()

        {
            con.Open();
            String Query = "select * from yolcutable ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }



        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kimlikno.Text == " " || yolcuadı.Text == " " || pasaportno.Text == " " || uyruk.SelectedItem.ToString() == " "||cinsiyet.SelectedItem.ToString()== " "||telno.Text==" ")  
            {
                MessageBox.Show(" kaybolan veri!!!");
            }
            else
            {
                try
                {
                    con.Open();
                    String Query = "update yolcutable set yolcuad='" + yolcuadı.Text + "',pasaportno='" + pasaportno.Text+ "',uyruk ='" + uyruk.SelectedItem.ToString() + "',cinsiyet ='" + cinsiyet.SelectedItem.ToString() + "',telno ='" + telno.Text + "'where kimlikno ='" + kimlikno.Text + "';";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("başarıyla güncellendi");
                    con.Close();
                    ucuslar();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // DGV veritabanina baglama kodu

            kimlikno.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            yolcuadı.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            pasaportno.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            uyruk.SelectedItem = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            cinsiyet.SelectedItem = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            telno.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void yolculargoster_Load(object sender, EventArgs e)
        {
            ucuslar();
        }
    }
}
