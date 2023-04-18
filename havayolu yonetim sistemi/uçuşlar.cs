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
    public partial class uçuşlar : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public uçuşlar()
        {           
            //veritabanina bağlama

            InitializeComponent();
            con.ConnectionString = @"Data Source=DESKTOP-MDN807P;Initial Catalog=havayolu;Integrated Security=True";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            uçuşları_göster ucş = new uçuşları_göster();
            ucş.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (ukodu.Text == " " || comboBox1.Text == " " || comboBox2.Text == " " || dateTimePicker1.Text == " "||kolsay.Text=="")
            {
                MessageBox.Show("kaybolan veri !!!");
            }
            else
            {
                try
                {
                    con.Open();

                    String Query = "insert into uçuşlar  values('" + ukodu.Text+"','"+comboBox1.SelectedItem.ToString()+"','"+comboBox2.SelectedItem.ToString()+"','"+dateTimePicker1.Value.ToString()+"','"+kolsay.Text+"')";
                    
                    SqlCommand cmd = new SqlCommand(Query,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("uçuş başarıyla kaydeldi!!");
                    con.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ukodu.Text = " ";
            comboBox1.SelectedItem = " ";
            comboBox2.SelectedItem = " ";
            kolsay.Text = " ";
        }
    }
}
