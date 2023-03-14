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
    public partial class Sifre_Değiştirme : Form
    {
        public Sifre_Değiştirme()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=DESKTOP-FLBNHN2; initial catalog= bankamatik; integrated security= sspi");

        private void Sifre_Değiştirme_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtYeni.Text=="" || txtEski.Text == "")
            {
                MessageBox.Show("Lütfen Eski veya Yeni Şifrenizi Giriniz..", "Şifre Değiştirme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (txtYeni.Text.Length < 5)
            {
                MessageBox.Show("Yeni Şifreniz 5 karakterden kısa olamaz", "Şifre Değiştirme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand komut = new SqlCommand("update musteriler set sifre=@p1 where ID=@p2", con);
                komut.Parameters.AddWithValue("@p1", txtYeni.Text);
                komut.Parameters.AddWithValue("@p2", Form1.mID);
                con.Open();

                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("Şifre Değiştirme İşlemi Başarılı", "Şifre Değiştirme İşlemi", MessageBoxButtons.OK);
                    HareketD.kaydet(Form1.mID, "Şifre Değiştirildi");

                }
                else
                {
                    MessageBox.Show("Şifre Değiştirme İşlemi Başarısız", "Şifre Değiştirme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                }
                con.Close();
                txtEski.Text = "";
                txtYeni.Text = "";


            } 
            






        }
    }
}
