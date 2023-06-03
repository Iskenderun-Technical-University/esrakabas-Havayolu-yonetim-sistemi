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
            yolcuka.DataSource = ds.Tables[0];
            con.Close();
        }



        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kimlikno.Text == " " || yolcuadı.Text == " " || pasaportno.Text == " " || telno.Text == " ")
            {
                MessageBox.Show(" kaybolan veri!!!");
            }
            else
            {
                try
                {
                    con.Open();
                    String Query = "update yolcutable set yolcuad='" + yolcuadı.Text + "',pasaportno='" + pasaportno.Text + "',uyruk ='" + uyruk.SelectedItem.ToString() + "',cinsiyet ='" + cinsiyet.SelectedItem.ToString() + "',telno ='" + telno.Text + "' where kimlikno ='" + kimlikno.Text + "';";
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

            kimlikno.Text = yolcuka.SelectedRows[0].Cells[0].Value.ToString();
            yolcuadı.Text = yolcuka.SelectedRows[0].Cells[1].Value.ToString();
            pasaportno.Text = yolcuka.SelectedRows[0].Cells[2].Value.ToString();

            uyruk.SelectedItem = yolcuka.SelectedRows[0].Cells[3].Value.ToString();
            cinsiyet.SelectedItem = yolcuka.SelectedRows[0].Cells[4].Value.ToString();
            telno.Text = yolcuka.SelectedRows[0].Cells[5].Value.ToString();
            yolcuka.AlternatingRowsDefaultCellStyle.BackColor = Color.Sienna;
            yolcuka.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        private void yolculargoster_Load(object sender, EventArgs e)
        {
            ucuslar();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (kimlikno.Text == "")
            {
                MessageBox.Show("silmek için kimlik numara girin");

            }
            else
            {
                try
                {
                    con.Open();
                    String Query = "delete from yolcutable where kimlikno ='" + kimlikno.Text + "';";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("yolcu başarıyla silindi !!!");

                    con.Close();
                    ucuslar();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kimlikno.Text = " ";
            yolcuadı.Text = " ";
            pasaportno.Text = " ";
            uyruk.Text = " ";
            cinsiyet.Text = " ";
            telno.Text = " ";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            if (MessageBox.Show("çıkış yapmak istediğinizde emin misiniz?", "çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yolcular yolcu = new yolcular();
            yolcu.Show();
            this.Hide();
        }
    }
}
