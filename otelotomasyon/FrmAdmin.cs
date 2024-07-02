using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otelotomasyon
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            label13.Text = DateTime.Now.ToLongTimeString();// sistem saatini uzun biçimde alır
            label12.Text = DateTime.Now.ToLongDateString();// sistem tarihini uzun biçimde alır
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Substring(1) + textBox3.Text.Substring(0, 1);
            label13.Text = DateTime.Now.ToLongTimeString();
            label12.Text = DateTime.Now.ToLongDateString();
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="admin" && textBox2.Text=="12345")
            {
                FrmKayıtForm fr = new FrmKayıtForm();
                fr.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Hatalı giriş yaptınız.Lütfen tekrar deneyiniz.");
                
                textBox2.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
