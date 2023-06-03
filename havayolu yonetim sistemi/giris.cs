using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Policy;

namespace havayolu_yonetim_sistemi
{
    public partial class giris : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();


        public giris()
        {  
            //veritabanina bağlama
            InitializeComponent();
            con.ConnectionString = @"Data Source=DESKTOP-MDN807P;Initial Catalog=havayolu;Integrated Security=True";
        }

        public anasayfa anasayfa
        {
            get => default;
            set
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                    con.Open();

                    cmd.Connection = con;
            //veritani üzerinde sorgulama kodu

            cmd.CommandText = "select * from kullanici";


            // kullanici tablodan veri okumak için kodu
            SqlDataReader rd = cmd.ExecuteReader();
            if(rd.Read())
            {
                if (textBox1.Text.Equals(rd["kullaniciad"].ToString() ) &&  textBox2.Text.Equals(rd["sifre"].ToString()))
                {
                    MessageBox.Show(" başarıyla giriş yaptınız");

                }
                else
                {
                    MessageBox.Show("kullanıcı adı veya sifre hatalı !!!");
                }
            }
            anasayfa an = new anasayfa();
            an.Show();
            this.Hide();

            con.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked )
            {
                textBox2.UseSystemPasswordChar = true;
                checkBox1.Text = "Gizle";
            }
            else if(checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox2.UseSystemPasswordChar = false;
                checkBox1.Text = "Göster";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
           if(  MessageBox.Show("çıkış yapmak istediğinizde emin misiniz?", "çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
