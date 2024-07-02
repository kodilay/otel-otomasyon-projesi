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
    public partial class fiyatguncelle : Form
    {
        
        public fiyatguncelle()
        {
            InitializeComponent();
        }
        private void verilerigöster()
        {
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

        private void fiyatguncelle_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void listView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into fiyatlar (id,ürünler,fiyatlar) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        int id = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Delete From fiyatlar where id=(" + id + ")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update fiyatlar set id='" + textBox1.Text.ToString() + "',ürünler='" + textBox2.Text.ToString() + "',fiyatlar='" + textBox3.Text.ToString() + "'where id=" + id + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            restaurant fr = new restaurant();
            fr.Show();
            this.Hide();
        }
    }
}
