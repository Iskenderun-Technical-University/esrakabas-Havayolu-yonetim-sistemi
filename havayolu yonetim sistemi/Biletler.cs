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
            yolcuad.ValueMember = "kimlikno";
            yolcuad.DataSource = dt;
            con.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void uyruk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Biletler_Load(object sender, EventArgs e)
        {
            yolcudoldur();
        }
    }
}
