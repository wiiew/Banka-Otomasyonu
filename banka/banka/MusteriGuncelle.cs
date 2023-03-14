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


namespace banka
{
    public partial class MusteriGuncelle : Form
    {
        public MusteriGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=DESKTOP-FLBNHN2; initial catalog= bankamatik; integrated security= sspi");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from musteriler where   ID =@p4 or tcNo=@p5", con);
            komut.Parameters.AddWithValue("@p4", txtAra.Text);
            komut.Parameters.AddWithValue("@p5", txtAra.Text);


            con.Open();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {


                txtID.Text = dr["ID"].ToString();
                maskedTextBox1.Text = dr["tcNo"].ToString();
                txtadSoyad.Text = dr["adSoyad"].ToString();
                txtAdres.Text = dr["adres"].ToString();
                txtTel.Text = dr["telefon"].ToString();
                textBox1.Text = dr["bakiye"].ToString();
                txtDurum.Text = dr["durum"].ToString();
            }
            else
            {
                MessageBox.Show(txtAra.Text + "Numaralı Kayıt Bulunamadı!", "Kayıt Arama");
                txtID.Text = "";
                txtAdres.Text = "";
                txtadSoyad.Text = "";
                txtAra.Text = "";
                textBox1.Text = "";
                maskedTextBox1.Text = "";
                txtTel.Text = "";
            }


            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update musteriler set adSoyad=@p1,adres=@p2,telefon=@p3,durum=@p6,bakiye=@p7 where  ID =@p4 or tcNo=@p5", con);
            komut.Parameters.AddWithValue("@p4", txtAra.Text);
            komut.Parameters.AddWithValue("@p5", txtAra.Text);
            komut.Parameters.AddWithValue("@p1", txtadSoyad.Text);
            komut.Parameters.AddWithValue("@p2", txtAdres.Text);
            komut.Parameters.AddWithValue("@p3", txtTel.Text);
            komut.Parameters.AddWithValue("@p6", Convert.ToByte(txtDurum.Text));
            komut.Parameters.AddWithValue("@p7", textBox1.Text);

            con.Open();

            int sonuc = komut.ExecuteNonQuery();
            if (sonuc == 1)
            {
                MessageBox.Show(txtID.Text + "Güncelleme Yapıldı ", "Güncelleme İşlemi");
            }
            else
            {
                MessageBox.Show(txtID.Text + "Güncelleme Yapılamadı ", "Güncelleme İşlemi");
                txtID.Text = "";
                txtAdres.Text = "";
                txtadSoyad.Text = "";
                txtAra.Text = "";
                textBox1.Text = "";
                maskedTextBox1.Text = "";
                txtTel.Text = "";
            }
            con.Close();


        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {

        }

        private void MusteriGuncelle_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void MusteriGuncelle_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

           
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtadSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
             && !char.IsSeparator(e.KeyChar);
        }

        private void txtAdres_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtAdres_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void txtAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }

}
