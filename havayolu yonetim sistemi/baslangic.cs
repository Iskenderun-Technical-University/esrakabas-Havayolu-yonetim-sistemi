using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace havayolu_yonetim_sistemi
{
    public partial class baslangic : Form
    {
        public baslangic()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        //prograssbar aracı ve timer kullanildi eger 100e esitse timer duracak ve giris formuna gecilecek

        int basla = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            basla += 1;
            progressBar1.Value = basla;
            if(progressBar1.Value==100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                giris gr = new giris();
                gr.Show();
                this.Hide();
            }
        }
    }
}
