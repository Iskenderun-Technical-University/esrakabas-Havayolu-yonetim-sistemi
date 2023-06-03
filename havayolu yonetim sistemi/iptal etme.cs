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

        public object iptalnumara { get; private set; }

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

        private void button1_Click(object sender, EventArgs e)
        {
            anasayfa an = new anasayfa();
            an.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (iptalnu.Text == " " || uçuşnu.Text == "")
            {
                MessageBox.Show("kaybolan veri !!!");
            }
            else
            {
                try
                {
                    con.Open();
                    String Query = "insert into iptaltbl  values('" + iptalnu.Text + "','" + biletnumara.SelectedValue.ToString() + "','" + uçuşnu.Text + "','" + tarih.Value.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("iptal başarıyla kaydeldi!!");
                    con.Close();
                    ucuslar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iptalnu.Text = " ";
            biletnumara.Text = " ";
            uçuşnu.Text = " ";

        }

        private void iptalDGR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            iptalDGR.AlternatingRowsDefaultCellStyle.BackColor = Color.Sienna;
            iptalDGR.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
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


