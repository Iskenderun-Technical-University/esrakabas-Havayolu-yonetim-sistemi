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
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            uçuşka.DataSource = ds.Tables[0];
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // DGV veritabanina baglama kodu

            ukodu.Text = uçuşka.SelectedRows[0].Cells[0].Value.ToString();
            nereden.SelectedItem = uçuşka.SelectedRows[0].Cells[1].Value.ToString();
            nereye.SelectedItem = uçuşka.SelectedRows[0].Cells[2].Value.ToString();

            kolsay.Text = uçuşka.SelectedRows[0].Cells[4].Value.ToString();
            uçuşka.AlternatingRowsDefaultCellStyle.BackColor = Color.Sienna;
            uçuşka.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

        }

        private void uçuşları_göster_Load(object sender, EventArgs e)
        {
            ucuslar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ukodu.Text == " " || kolsay.Text == " " )
            {
                MessageBox.Show(" kaybolan veri!!!");
            }
            else
            {
                try
                {
                    con.Open();
                    String Query = "update uçuşlar set nereden='" + nereden.SelectedItem.ToString() + "',nereye='" + nereye.SelectedItem.ToString() + "',tarihbelirle='" + tarihbelirle.Value.Date.ToString() + "',koltuksayisi='" + kolsay.Text + "' where ucuskodu ='" + ukodu.Text + "';";
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

        private void button1_Click(object sender, EventArgs e)
        {
            uçuşlar ucu = new uçuşlar();
            ucu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sifirlama botunu kodu

            kolsay.Text = " ";
            ukodu.Text = " ";
            nereden.Text = " ";
            nereye.Text = " ";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //sil botunu kodlandi
            //ilk önce veritabanina bagladik ve silme kodu yazıldı

            if (ukodu.Text == "")
            {
                MessageBox.Show("silmek için uçuş kodu girin");

            }
            else
            {
                try
                {
                    con.Open();
                    String Query = "delete from uçuşlar where ucuskodu ='" + ukodu.Text + "';";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            if (MessageBox.Show("çıkış yapmak istediğinizde emin misiniz?", "çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
