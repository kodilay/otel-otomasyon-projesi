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
    public partial class FrmKayıtForm : Form
    {
        public FrmKayıtForm()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\müsteriler.mdb");
        OleDbCommand komut = new OleDbCommand();
        string baglanticum = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\müsteriler.mdb";

        

        private void verilerigöster()
            {
            listView1.Columns[0].Width = 50; // Kolon Genişliğini ayarladık.
            listView1.Columns[1].Width = 90; //Kolon isimleride kullanılabilir.
            listView1.Columns[2].Width = 90;
            listView1.Columns[3].Width = 50; // Kolon Genişliğini ayarladık.
            listView1.Columns[4].Width = 160; //Kolon isimleride kullanılabilir.
            listView1.Columns[5].Width = 100;
            listView1.Columns[6].Width = 50;
            listView1.Columns[7].Width = 160;

            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "Select * From müsteriler";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["GTarih"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());
                ekle.SubItems.Add(oku["CTarih"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into müsteriler(Ad,Soyad,OdaNo,GTarih,Telefon,Hesap,CTarih) values('" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + dateTimePicker2.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            komut.CommandText= "insert into doluoda(doluyerler)  VALUES ('" + comboBox1.Text + "') ";
            komut.ExecuteNonQuery();
            komut.CommandText=("Delete from bosoda where bosyeler=" + comboBox1.Text + "");
            komut.ExecuteNonQuery();

            baglanti.Close();
            verilerigöster();
            label14.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Text="";
            bos_odalari_listele();
            butonlari_duzenle();

        }
        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (label14.Text.Trim() == "")
            {
                MessageBox.Show("LÜTFEN ALANLARI KONTROL EDİNİZ..");
                return;
            }

            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("LÜTFEN ALANLARI KONTROL EDİNİZ..");
                return;
            }

            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("LÜTFEN ALANLARI KONTROL EDİNİZ..");
                return;
            }

            if (textBox5.Text.Trim() == "")
            {
                MessageBox.Show("LÜTFEN ALANLARI KONTROL EDİNİZ..");
                return;
            }

            if (textBox6.Text.Trim() == "")
            {
                MessageBox.Show("LÜTFEN ALANLARI KONTROL EDİNİZ..");
                return;
            }



            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from müsteriler where id="+label14.Text+"";
            komut.ExecuteNonQuery();
            komut.CommandText = "insert into bosoda(bosyeler)  VALUES (" + comboBox1.Text + ") ";
            komut.ExecuteNonQuery();
            komut.CommandText = ("Delete from doluoda where doluyerler=" + comboBox1.Text + "");
            komut.ExecuteNonQuery();

            baglanti.Close();
            verilerigöster();
            label14.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Text = "";

            bos_odalari_listele();
            butonlari_duzenle();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            label14.Text  = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[6].Text;
            dateTimePicker2.Text = listView1.SelectedItems[0].SubItems[7].Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(label14.Text.Trim() == "")
            {
                MessageBox.Show("LÜTFEN ALANLARI KONTROL EDİNİZ..");
                return;
            }

            if (textBox4.Text.Trim() == "")
            {
                MessageBox.Show("LÜTFEN ESKİ ODAYI GİRİNİZ..");
                return;
            }


            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from doluoda where doluyerler =" + textBox4.Text.Trim() + "";
            komut.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "insert into bosoda(bosyeler) values(" + textBox4.Text.Trim() + ")";
            komut.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "insert into doluoda(doluyerler) values(" + comboBox1.Text + ")";
            komut.ExecuteNonQuery();
            baglanti.Close();


            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from bosoda where bosyeler=" + comboBox1.Text + "";
            komut.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update müsteriler set Ad='" + textBox2.Text + "',Soyad='" + textBox3.Text + "',OdaNo='" + comboBox1.Text + "',GTarih='" + dateTimePicker1.Text + "',Telefon='" + textBox5.Text + "',Hesap='" + textBox6.Text + "',CTarih='" + dateTimePicker2.Text + "' where id=" + label14.Text  +"";
            

            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
            bos_odalari_listele();
            butonlari_duzenle();

            textBox2.Text="";
            textBox4.Text = "";
            textBox3.Text="";
            textBox5.Text="";
            textBox6.Text="";
            label14.Text="";

                            
        }



        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("SELECT *FROM müsteriler where Ad='" + textBox7.Text + "'", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["GTarih"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());
                ekle.SubItems.Add(oku["CTarih"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
            textBox7.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void FrmKayıtForm_Load_1(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today.AddDays(0);
            dateTimePicker2.Value = DateTime.Today.AddDays(+1);

            label13.Text = DateTime.Now.ToLongTimeString();// sistem saatini uzun biçimde alır
            label12.Text = DateTime.Now.ToLongDateString();// sistem tarihini uzun biçimde alır
            bos_odalari_listele();
            butonlari_duzenle();
            timer1.Start();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        void bos_odalari_listele()
        {
            OleDbConnection bag = new OleDbConnection(baglanticum);  // burada gerekli tanımlamaları yapıyorum
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM bosoda", baglanti);
            DataTable dt = new DataTable();
            baglanti.Open();
            da.Fill(dt);
            dt.DefaultView.Sort = "bosyeler asc";
            comboBox1.DataSource = dt;

            comboBox1.DisplayMember = "bosyeler"; // burada comboboxta gösterilcek olan veriyi veritabanındaki ilgili alanından almasını istedim.
            baglanti.Close();
        }
        void butonlari_duzenle()
        {
            baglanti.Open();
            OleDbCommand odalarisec = new OleDbCommand("Select bosyeler from bosoda", baglanti);
            OleDbDataReader oledr = odalarisec.ExecuteReader();
            while (oledr.Read())
            {
                string odaNo = oledr["bosyeler"].ToString();
                switch (odaNo)
                {
                    case "101":
                        button6.BackColor = Color.Green;
                        break;
                    case "102":
                        button7.BackColor = Color.Green;
                        break;
                    case "103":
                        button8.BackColor = Color.Green;
                        break;
                    case "104":
                        button9.BackColor = Color.Green;
                        break;
                    case "105":
                        button10.BackColor = Color.Green;
                        break;
                    case "106":
                        button15.BackColor = Color.Green;
                        break;
                    case "107":
                        button14.BackColor = Color.Green;
                        break;
                    case "108":
                        button13.BackColor = Color.Green;
                        break;
                    case "109":
                        button11.BackColor = Color.Green;
                        break;
                    case "110":
                        button12.BackColor = Color.Green;
                        break;
                    case "201":
                        button20.BackColor = Color.Green;
                        break;
                    case "202":
                        button19.BackColor = Color.Green;
                        break;
                    case "203":
                        button18.BackColor = Color.Green;
                        break;
                    case "204":
                        button17.BackColor = Color.Green;
                        break;
                    case "205":
                        button16.BackColor = Color.Green;
                        break;
                    case "206":
                        button21.BackColor = Color.Green;
                        break;
                    case "207":
                        button22.BackColor = Color.Green;
                        break;
                    case "208":
                        button23.BackColor = Color.Green;
                        break;
                    case "209":
                        button24.BackColor = Color.Green;
                        break;
                    case "210":
                        button25.BackColor = Color.Green;
                        break;
                    case "305":
                        button31.BackColor = Color.Green;
                        break;
                    case "306":
                        button30.BackColor = Color.Green;
                        break;
                    case "307":
                        button29.BackColor = Color.Green;
                        break;
                    case "308":
                        button28.BackColor = Color.Green;
                        break;
                    case "309":
                        button26.BackColor = Color.Green;
                        break;
                    case "310":
                        button27.BackColor = Color.Green;
                        break;

                }
            }
            baglanti.Close();

            baglanti.Open();
            OleDbCommand doluodalarisec = new OleDbCommand("Select doluyerler from doluoda", baglanti);
            OleDbDataReader doluoledr = doluodalarisec.ExecuteReader();
            while (doluoledr.Read())
            {
                string odaNo = doluoledr["doluyerler"].ToString();
                switch (odaNo)
                {
                    case "101":
                        button6.BackColor = Color.Red;
                        break;
                    case "102":
                        button7.BackColor = Color.Red;
                        break;
                    case "103":
                        button8.BackColor = Color.Red;
                        break;
                    case "104":
                        button9.BackColor = Color.Red;
                        break;
                    case "105":
                        button10.BackColor = Color.Red;
                        break;
                    case "106":
                        button15.BackColor = Color.Red;
                        break;
                    case "107":
                        button14.BackColor = Color.Red;
                        break;
                    case "108":
                        button13.BackColor = Color.Red;
                        break;
                    case "109":
                        button11.BackColor = Color.Red;
                        break;
                    case "110":
                        button12.BackColor = Color.Red;
                        break;
                    case "201":
                        button20.BackColor = Color.Red;
                        break;
                    case "202":
                        button19.BackColor = Color.Red;
                        break;
                    case "203":
                        button18.BackColor = Color.Red;
                        break;
                    case "204":
                        button17.BackColor = Color.Red;
                        break;
                    case "205":
                        button16.BackColor = Color.Red;
                        break;
                    case "206":
                        button21.BackColor = Color.Red;
                        break;
                    case "207":
                        button22.BackColor = Color.Red;
                        break;
                    case "208":
                        button23.BackColor = Color.Red;
                        break;
                    case "209":
                        button24.BackColor = Color.Red;
                        break;
                    case "210":
                        button25.BackColor = Color.Red;
                        break;
                    case "305":
                        button31.BackColor = Color.Red;
                        break;
                    case "306":
                        button30.BackColor = Color.Red;
                        break;
                    case "307":
                        button29.BackColor = Color.Red;
                        break;
                    case "308":
                        button28.BackColor = Color.Red;
                        break;
                    case "309":
                        button26.BackColor = Color.Red;
                        break;
                    case "310":
                        button27.BackColor = Color.Red;
                        break;

                }
            }
            baglanti.Close();
        }
        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (label14.Text.Trim() == "")
            {
                MessageBox.Show("Restaraunt a girmek için müşteri seçiniz.");
                return;
            }
            restaurant fr = new restaurant();
            fr.musteriid = label14.Text;
            fr.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        Font Baslik = new Font("Verdana", 12, FontStyle.Bold);
        Font govde = new Font("Verdana", 12);
        SolidBrush sb = new SolidBrush(Color.Black);

        private void button33_Click(object sender, EventArgs e)
        {
            ppdDiyalog.ShowDialog();
        }

        private void pdYazici_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat sFormat = new StringFormat();
            sFormat.Alignment = StringAlignment.Near;

            Image logo = Image.FromFile("dosya.jpg");
            Size boyut = new Size();
            boyut.Height = 250;
            boyut.Width = 250;
            logo = resizeImage(logo, boyut);
            e.Graphics.DrawImage(logo , new Point(100, 10));

            e.Graphics.DrawString("AD=" +textBox2.Text + "", Baslik, sb, 100, 250);
            e.Graphics.DrawString("SOYAD=" + textBox3.Text + "", Baslik, sb, 100, 270);
            e.Graphics.DrawString("ODA NO=" + comboBox1.Text + "", Baslik, sb, 100, 290);
            e.Graphics.DrawString("GİRİŞ TARİHİ=" + dateTimePicker1.Text + "", Baslik, sb, 100, 310);
            e.Graphics.DrawString("ÇIKIŞ TARİHİ=" + dateTimePicker2.Text + "", Baslik, sb, 100, 330);
            e.Graphics.DrawString("TELEFON=" + textBox5.Text + "", Baslik, sb, 100, 350);
            e.Graphics.DrawString("HESAP=" + textBox6.Text + "TL", Baslik, sb, 100, 370);
            Pen blackPen = new Pen(Color.Black, 3);
            e.Graphics.DrawRectangle(blackPen, 120, 200, 400, 200);
            e.Graphics.DrawLine(blackPen,50,0,1,5);
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label13.Text = DateTime.Now.ToLongTimeString();
            label12.Text = DateTime.Now.ToLongDateString();
        }
    }
}