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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
