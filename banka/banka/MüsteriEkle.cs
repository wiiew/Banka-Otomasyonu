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
using System.Data.SqlClient;

namespace banka
{
    public partial class MüsteriEkle : Form
    {
        public MüsteriEkle()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("server=DESKTOP-FLBNHN2; initial catalog= bankamatik; integrated security= sspi");


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into musteriler (tcNo,adSoyad,adres,telefon,sifre,bakiye,durum,dolar,euro) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", con);
            komut.Parameters.AddWithValue("@p1", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p2", txtadSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtAdres.Text);
            komut.Parameters.AddWithValue("@p4", txtTel.Text);
            komut.Parameters.AddWithValue("@p5", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p6", txtBakiye.Text);
            komut.Parameters.AddWithValue("@p7", 1);
            komut.Parameters.AddWithValue("@p8", 0.00);
            komut.Parameters.AddWithValue("@p9", 0.00);

            if (maskedTextBox2.TextLength != 11)
            {

                if (maskedTextBox2.Text == "" || txtTel.Text == "" || txtBakiye.Text == "" || txtadSoyad.Text == "" || txtAdres.Text == "")
                {
                    MessageBox.Show("Tüm alanları eksiksiz giriniz..", "Müşteri Kayıt hatası");


                }
                else
                {

                    con.Open();
                    int sonuc = komut.ExecuteNonQuery();
                    con.Close();
                    if (sonuc == 1)

                        MessageBox.Show("Yeni Müşteri Kaydı Başarılı", "Yeni Müşteri Kaydı");

                    else
                    {

                        MessageBox.Show("Yeni Kayıt Yapılamadı !", "Müşteri Kayıt Hatası");
                    }

                }

                maskedTextBox2.Text = "";
                txtadSoyad.Text = "";
                txtAdres.Text = "";
                txtBakiye.Text = "";
                txtTel.Text = "";



            }
            else
            {
                MessageBox.Show("11 Haneli GİRİNİZ....!");

            }









        }

        private void MüsteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtadSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtadSoyad_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

