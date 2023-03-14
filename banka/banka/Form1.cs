using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace banka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        SqlConnection con = new SqlConnection("server=DESKTOP-FLBNHN2; initial catalog= bankamatik; integrated security= sspi");
        public static string adSoyad = "";
        public static int mID=0;
        public static float mBakiye = 0.0f ;
        public static float dolarMiktar = 0.0f;
        public static float euroMiktar = 0.0f;



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string kAdi = textBox1.Text;
            string parola = textBox2.Text;
            bool sonuc = false;
            

            if (radioButton1.Checked)
            {
                if(kAdi=="admin" && parola == "123")
                {
                    Yetkiliislem y1 = new Yetkiliislem();
                    y1.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya parola", "Hatalı giriş denemesi");
                }

            }
            else
            {
                con.Open();
                SqlCommand komut = new SqlCommand("select* from musteriler where tcNo=@p1 and sifre=@p2 and durum=1", con);
                komut.Parameters.AddWithValue("@p1", kAdi);
                komut.Parameters.AddWithValue("@p2", parola);

                SqlDataReader dr = komut.ExecuteReader();
                while(dr.Read())
                {
                    adSoyad = dr["adSoyad"].ToString();
                    mID = int.Parse(dr["ID"].ToString());
                    mBakiye = float.Parse(dr["bakiye"].ToString());

                    sonuc = true;

                }
                con.Close();
            

                if (sonuc)
                {
                    sonuc = false;
                    Musterİslem mi = new Musterİslem();
                    mi.Show();
                    this.Hide();



                }
                else
                {
                    MessageBox.Show("Bilgiler Hatalı Lütfen Kontrol Ediniz Veya Şubenizle İletişime Geciniz","Hatalı giriş denemesi");
                }
                
            }
         textBox1.Text = "";
         textBox2.Text = "";
            





        }

        private void Login_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
