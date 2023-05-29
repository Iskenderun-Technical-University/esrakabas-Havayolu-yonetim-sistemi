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
    public partial class iptal_etme : Form
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();


        public iptal_etme()
        {
            InitializeComponent();
            con.ConnectionString = @"Data Source=DESKTOP-MDN807P;Initial Catalog=havayolu;Integrated Security=True";
        }
        private void ucuslar()

        {
            con.Open();
            String Query = "select * from  iptaltbl ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            iptalDGR.DataSource = ds.Tables[0];
            con.Close();
        }

        private void uçuşdoldur()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select biletnumarasi from bilettbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("biletnumarasi", typeof(string));
            dt.Load(rdr);
            biletnumara.ValueMember = "biletnumarasi";
            biletnumara.DataSource = dt;
            con.Close();

        }
        private void uçuşgotur()
        {

            con.Open();
            String Query = "select * from bilettbl where biletnumarasi = '" + biletnumara.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {

                uçuşnu.Text = dr["uçuşkodu"].ToString();
            

            }

            con.Close();

        }


        private void iptal_etme_Load(object sender, EventArgs e)
        {

            ucuslar();
            uçuşdoldur();

        }
        private void biletnumara_SelectionChangeCommitted(object sender, EventArgs e)
        {
            uçuşgotur();
        }

        private void biletnumara_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


