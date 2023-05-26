using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace havayolu_yonetim_sistemi
{
    public partial class Biletler : Form
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public Biletler()
        {
            InitializeComponent();
            con.ConnectionString = @"Data Source=DESKTOP-MDN807P;Initial Catalog=havayolu;Integrated Security=True";

        }

        private void yolcudoldur()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select kimlikno from yolcutable", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("kimlikno", typeof(int));
            dt.Load(rdr);
            yolcutc.ValueMember = "kimlikno";
            yolcutc.DataSource = dt;
            con.Close();

        }


        private void uçuşdoldur()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select ucuskodu from uçuşlar", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("ucuskodu", typeof(string));
            dt.Load(rdr);
            uçuşnu.ValueMember = "ucuskodu";
            uçuşnu.DataSource = dt;
            con.Close();

        }

        private void yolcugotur()
        {

            con.Open();
            String Query = "select * from yolcutable where kimlikno = '"+yolcutc.SelectedValue.ToString()+"'";
            SqlCommand cmd = new SqlCommand(Query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            
            foreach (DataRow dr  in dt.Rows)
            {
              
                yolcuad.Text = dr["yolcuad"].ToString();
                pasaportno.Text = dr["pasaportno"].ToString();
                yolcuuyruk.Text = dr["uyruk"].ToString();
                
            }
            
            con.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Biletler_Load(object sender, EventArgs e)
        {
            yolcudoldur();
            uçuşdoldur();
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void yolcutc_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void yolcutc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            yolcugotur();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            yolculargoster gos = new yolculargoster();
            gos.Show();
            this.Hide();
        }
    }
}
