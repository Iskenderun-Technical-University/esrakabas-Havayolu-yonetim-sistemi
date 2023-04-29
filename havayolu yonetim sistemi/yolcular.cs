using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace havayolu_yonetim_sistemi
{
    public partial class yolcular : Form
    {
        public yolcular()
        {
            InitializeComponent();
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
    }
}
