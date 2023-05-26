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
    public partial class yolcular : Form
    {
        //veritabanina bağlama

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public yolcular()
        {
            InitializeComponent();
            con.ConnectionString = @"Data Source=DESKTOP-MDN807P;Initial Catalog=havayolu;Integrated Security=True";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //önceki sayfayı gösterme kodu

            uçuşları_göster ug = new uçuşları_göster();
            ug.Show();
            this.Hide();

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

        private void button3_Click(object sender, EventArgs e)
        {

            //kaydet botunu kodlamasi

            if (kimlikno.Text == " " || yolcuadı.Text == " " || pasaportno.Text == " " || uyruk.Text == " " ||cinsiyet.Text==" "|| telno.Text == "")
            {
                MessageBox.Show("kaybolan veri !!!");
            }
            else
            {
                try
                {
                    con.Open();
                    String Query = "insert into yolcutable  values('" + kimlikno.Text + "','" + yolcuadı.Text + "','" + pasaportno.Text + "','" + uyruk.SelectedItem.ToString() + "','" + cinsiyet.SelectedItem.ToString() + "','"+telno.Text+"')";

                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" başarıyla kaydeldi!!");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yolculargoster yolgo = new yolculargoster();
            yolgo.Show();
            this.Hide();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void yolcular_Load(object sender, EventArgs e)
        {

        }
    }
}
