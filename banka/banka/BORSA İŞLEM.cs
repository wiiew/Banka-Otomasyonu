using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace banka
{
    public partial class BORSA_İŞLEM : Form
    {
        public BORSA_İŞLEM()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=DESKTOP-FLBNHN2; initial catalog= bankamatik; integrated security= sspi");
        double kur, miktar, tutar;
        public static double euroMiktar, dolarMiktar;

       
       



        private void BORSA_İŞLEM_Load(object sender, EventArgs e)
        {
            
            SqlCommand komut2 = new SqlCommand("select* from musteriler where ID=@p1", con);
            komut2.Parameters.AddWithValue("@p1", Form1.mID);
            con.Open();
            
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr["dolar"].ToString();
                textBox2.Text = dr["euro"].ToString();
                dolarMiktar = float.Parse(dr["dolar"].ToString());
                euroMiktar = float.Parse(dr["euro"].ToString());


            }
            con.Close();

            txtBakiye.Text = Form1.mBakiye.ToString() + "TL";
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);


            string dolarAlis = xmldosya.SelectSingleNode("Tarih_Date /Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            dolarAlısText.Text = dolarAlis;

            string dolarSatis = xmldosya.SelectSingleNode("Tarih_Date /Currency[@Kod='USD']/BanknoteSelling").InnerXml;
             dolarSatisText.Text= dolarSatis;

            string euroAlis = xmldosya.SelectSingleNode("Tarih_Date /Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            euroAlisText.Text = euroAlis;

            string euroSatis = xmldosya.SelectSingleNode("Tarih_Date /Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            euroSatisText.Text = euroSatis;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtKur.Text = dolarAlısText.Text;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button1.Visible = true;
           
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            txtKur.Text = dolarSatisText.Text;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtKur.Text = euroAlisText.Text;
            button1.Visible = false;
            button4.Visible = false;
            button3.Visible = false;
            button2.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtKur.Text = euroSatisText.Text;
            button1.Visible = false;
            button4.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
        }

        private void bthesapla_Click(object sender, EventArgs e)
        {
            
            kur = Convert.ToDouble(txtKur.Text);
            miktar = Convert.ToDouble(txtMiktar.Text);
            tutar = miktar * kur;
            txtTutar.Text = tutar.ToString();
            
        }

        private void dolarAlısText_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Form1.mBakiye < double.Parse(txtTutar.Text))
            {
                MessageBox.Show("Bakiyeniz Yetersiz");
            }

            else
            {


                kur = Convert.ToDouble(txtKur.Text);
                int miktar = Convert.ToInt32(txtMiktar.Text);
                float tutar = (float)(miktar * kur);
                tutar = (float)Convert.ToDouble(txtTutar.Text);

                txtTutar.Text = tutar.ToString();

                SqlCommand komut = new SqlCommand("update musteriler set euro +=@p1 where ID=@p2", con);
                komut.Parameters.AddWithValue("@p1", txtMiktar.Text);
                komut.Parameters.AddWithValue("@p2", Form1.mID);
                con.Open();

                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("Döviz Alım Başarılı ", "Borsa İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Form1.mBakiye -= tutar;
                    HareketD.kaydet(Form1.mID, (tutar + "TL Euro Alındı"));
                    SqlCommand komut2 = new SqlCommand("select* from musteriler where ID=@p1", con);
                    komut2.Parameters.AddWithValue("@p1", Form1.mID);
                    

                    SqlDataReader dr = komut2.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox1.Text = dr["dolar"].ToString();
                        textBox2.Text = dr["euro"].ToString();
                        dolarMiktar = float.Parse(dr["dolar"].ToString());
                        euroMiktar = float.Parse(dr["euro"].ToString());


                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Para Yatırma Başarısız ", "Para Yatırma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                con.Close();
                txtBakiye.Text = Form1.mBakiye.ToString() + "TL";



            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dolarMiktar < double.Parse(txtMiktar.Text))
            {
                MessageBox.Show("Yetersiz Dolar Miktari");
            }

            else
            {


                kur = Convert.ToDouble(txtKur.Text);
                int miktar = Convert.ToInt32(txtMiktar.Text);
                float tutar = (float)(miktar * kur);
                tutar = (float)Convert.ToDouble(txtTutar.Text);

                txtTutar.Text = tutar.ToString();

                SqlCommand komut = new SqlCommand("update musteriler set dolar -=@p1, bakiye +=@p3 where ID=@p2", con);
               
                komut.Parameters.AddWithValue("@p1", txtMiktar.Text);
                komut.Parameters.AddWithValue("@p2", Form1.mID);
                komut.Parameters.AddWithValue("@p3", tutar);
               

                  con.Open();
                  int sonuc= komut.ExecuteNonQuery();
  
                if (sonuc == 1)
                {
  
                    MessageBox.Show("Döviz Satım Başarılı ", "Borsa İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Form1.mBakiye += (float)tutar;
                    HareketD.kaydet(Form1.mID, (tutar + "TL Bozduruldu"));
                    SqlCommand komut2 = new SqlCommand("select* from musteriler where ID=@p1", con);
                    komut2.Parameters.AddWithValue("@p1", Form1.mID);
                    

                    SqlDataReader dr = komut2.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox1.Text = dr["dolar"].ToString();
                        textBox2.Text = dr["euro"].ToString();
                        dolarMiktar = float.Parse(dr["dolar"].ToString());
                        euroMiktar = float.Parse(dr["euro"].ToString());


                    }
                    con.Close();


                }
                else
                {
                    MessageBox.Show("Para Yatırma Başarısız ", "Para Yatırma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                
                txtBakiye.Text = Form1.mBakiye.ToString() + "TL";
                con.Close();

            } 
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (euroMiktar < double.Parse(txtMiktar.Text))
            {
                MessageBox.Show("Yetersiz Euro  Miktarı.");
            }

            else
            {


                kur = Convert.ToDouble(txtKur.Text);
                int miktar = Convert.ToInt32(txtMiktar.Text);
                float tutar = (float)(miktar * kur);
                tutar = (float)Convert.ToDouble(txtTutar.Text);

                txtTutar.Text = tutar.ToString();

                SqlCommand komut = new SqlCommand("update musteriler set euro -=@p1, bakiye +=@p3 where ID=@p2", con);

                komut.Parameters.AddWithValue("@p1", txtMiktar.Text);
                komut.Parameters.AddWithValue("@p2", Form1.mID);
                komut.Parameters.AddWithValue("@p3", tutar);


                con.Open();
                int sonuc = komut.ExecuteNonQuery();

                if (sonuc == 1)
                {

                    MessageBox.Show("Döviz Satım Başarılı ", "Borsa İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Form1.mBakiye += (float)tutar;
                    HareketD.kaydet(Form1.mID, (tutar + "TL Bozduruldu"));
                    SqlCommand komut2 = new SqlCommand("select* from musteriler where ID=@p1", con);
                    komut2.Parameters.AddWithValue("@p1", Form1.mID);
                   

                    SqlDataReader dr = komut2.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox1.Text = dr["dolar"].ToString();
                        textBox2.Text = dr["euro"].ToString();
                        dolarMiktar = float.Parse(dr["dolar"].ToString());
                        euroMiktar = float.Parse(dr["euro"].ToString());


                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Para Yatırma Başarısız ", "Para Yatırma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


                txtBakiye.Text = Form1.mBakiye.ToString() + "TL";
                con.Close();

            }




        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMiktar_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtKur_TextChanged(object sender, EventArgs e)
        {
            txtKur.Text=txtKur.Text.Replace("." , ",");
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (Form1.mBakiye < double.Parse(txtTutar.Text))
            {
                MessageBox.Show("Bakiyeniz Yetersiz");
            }

            else
            {

                

                kur = Convert.ToDouble(txtKur.Text);
                int miktar = Convert.ToInt32(txtMiktar.Text);
                float tutar = (float)(miktar * kur);
                tutar = (float)Convert.ToDouble(txtTutar.Text);
                txtTutar.Text = tutar.ToString();

                SqlCommand komut = new SqlCommand("update musteriler set dolar +=@p1 where ID=@p2", con);
                komut.Parameters.AddWithValue("@p1", txtMiktar.Text);
                komut.Parameters.AddWithValue("@p2", Form1.mID);
                con.Open();
               
                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("Döviz Alım Başarılı ", "Borsa İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Form1.mBakiye -= tutar;
                    HareketD.kaydet(Form1.mID, (tutar + "TL Dolar Alındı "));
                    SqlCommand komut2 = new SqlCommand("select* from musteriler where ID=@p1", con);
                    komut2.Parameters.AddWithValue("@p1", Form1.mID);
                   

                    SqlDataReader dr = komut2.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox1.Text = dr["dolar"].ToString();
                        textBox2.Text = dr["euro"].ToString();
                        dolarMiktar = float.Parse(dr["dolar"].ToString());
                        euroMiktar = float.Parse(dr["euro"].ToString());


                    }
                    con.Close();

                }
                else
                {
                    MessageBox.Show("Para Yatırma Başarısız ", "Para Yatırma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
               
                con.Close();
                txtBakiye.Text = Form1.mBakiye.ToString() + "TL";

            }


        }
    }
}
