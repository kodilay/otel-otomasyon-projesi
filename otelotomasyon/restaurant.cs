using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace otelotomasyon
{
    public partial class restaurant : Form
    {
        public string musteriid;
        public restaurant()
        {
            InitializeComponent();
        }


        private void verilerigöster()
        {
            listView1.Columns[0].Width = 40; // Kolon Genişliğini ayarladık.
            listView1.Columns[1].Width = 90; //Kolon isimleride kullanılabilir.
            listView1.Columns[2].Width = 50;

            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM fiyatlar";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["ürünler"].ToString());
                ekle.SubItems.Add(oku["fiyatlar"].ToString());


                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\müsteriler.mdb");
        OleDbCommand komut = new OleDbCommand();

        private void restaurant_Load(object sender, EventArgs e)
        {

        }
        
        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double toplam = 0;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (listView2.Items[i].Text != "")
                {
                    toplam = toplam + Convert.ToDouble(listView2.Items[i].Text);
                }
                
            } 

            label6.Text = toplam.ToString();

            string db = "update müsteriler set hesap = hesap + " + label6.Text + " where id = " + musteriid + "";
            OleDbCommand guncelle = new OleDbCommand(db, baglanti);
            baglanti.Open();
            guncelle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fiyatguncelle fr = new fiyatguncelle();
            fr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmKayıtForm fr = new FrmKayıtForm();
            fr.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int id = 0;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView2.Items.Add(textBox3.Text.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
        }

    }
}

