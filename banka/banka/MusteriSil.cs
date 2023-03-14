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
    public partial class MusteriSil : Form
    {
        public MusteriSil()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("server=DESKTOP-FLBNHN2; initial catalog= bankamatik; integrated security= sspi");


        private void MusteriSil_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update   musteriler set durum=@p1  where  ID =@p4 or tcNo=@p5", con);
            komut.Parameters.AddWithValue("@p4", txtAra.Text);
            komut.Parameters.AddWithValue("@p5", txtAra.Text);
            komut.Parameters.AddWithValue("@p1", 0);    
            

            con.Open();

            int sonuc = komut.ExecuteNonQuery();
            if (sonuc == 1)
            {
                MessageBox.Show(txtID.Text + "Silme İşlemi Yapıldı ", "Silme İşlemi");
            }
            else
            {
                MessageBox.Show(txtID.Text + "Silme Yapılamadı ", "Silme  İşlemi");
                txtID.Text = "";
                txtAdres.Text = "";
                txtadSoyad.Text = "";
                txtAra.Text = "";
                txtBakiye.Text = "";
                txtTc.Text = "";
                txtTel.Text = "";
            }
            con.Close();
        }

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
                txtTc.Text = dr["tcNo"].ToString();
                txtadSoyad.Text = dr["adSoyad"].ToString();
                txtAdres.Text = dr["adres"].ToString();
                txtTel.Text = dr["telefon"].ToString();
                txtBakiye.Text = dr["bakiye"].ToString();
            }
            else
            {
                MessageBox.Show(txtAra.Text + "Numaralı Kayıt Bulunamadı!", "Kayıt Arama");
                txtID.Text = "";
                txtAdres.Text = "";
                txtadSoyad.Text = "";
                txtAra.Text = "";
                txtBakiye.Text = "";
                txtTc.Text = "";
                txtTel.Text = "";
            }


            con.Close();
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
