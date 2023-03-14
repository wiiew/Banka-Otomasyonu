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
    public partial class HavaleEFT : Form
    {
        public HavaleEFT()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=DESKTOP-FLBNHN2; initial catalog= bankamatik; integrated security= sspi");

        private void HavaleEFT_Load(object sender, EventArgs e)
        {

        }
        public void tlHavale()
        {
            if (txtNo.Text == "")
            {
                MessageBox.Show("Lütfen Önce Havale Edilecek Numarayı giriniz");
            }
            else
            {
                float sayi = float.Parse(txtMiktar.Text);
                if (sayi > Form1.mBakiye)
                {
                    MessageBox.Show("Yetersiz Bakiye", "Havale İşlemi");

                }
                else
                {
                    SqlCommand komut = new SqlCommand("update musteriler set bakiye =bakiye - @p1 where ID=@p2", con);
                    komut.Parameters.AddWithValue("@p1", sayi);
                    komut.Parameters.AddWithValue("@p2", Form1.mID);

                    SqlCommand komut2 = new SqlCommand("update musteriler set bakiye = bakiye + @p3 where ID=@p4", con);
                    komut2.Parameters.AddWithValue("@p3", txtMiktar.Text);
                    komut2.Parameters.AddWithValue("@p4", txtNo.Text);
                    if (Form1.mID == int.Parse(txtNo.Text))
                    {
                        MessageBox.Show("Kendi Hesabınıza Havale  yapamazsınız", "Havale/EFT İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (sayi <= 10)
                    {
                        MessageBox.Show("Lütfen en az 10 TL ve üzeri  Giriniz", "Havale/EFT İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        con.Open();
                        int sonuc1 = komut2.ExecuteNonQuery();
                        con.Close();
                        if (sonuc1 == 1)
                        {
                            con.Open();
                            komut.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Havale /EFT işlemi gerçekleştirildi", "Havale /EFT işlemi", MessageBoxButtons.OK);
                            Form1.mBakiye -= sayi;
                            HareketD.kaydet(Form1.mID, (sayi + " TL Para Havale Edildi"));
                            HareketD.kaydet(int.Parse(txtNo.Text), (sayi + " TL  Havale Alındı"));


                        }
                        else
                        {
                            MessageBox.Show("Alıcı Hesap No Hatalı", "TL Havale /EFT işlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }



                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtNo.Text!="" && txtDolar.Text==""&&txtEuro.Text==""&& txtMiktar.Text == "")
            {
                MessageBox.Show("Lütfen Miktarı veya tl tutarını girinizz..");
            }



            if (txtNo.Text == "")
            {
                MessageBox.Show("Lütfen Önce Havale Edilecek Numarayı giriniz");
                txtNo.Text = "";
                txtDolar.Text = "";
                txtEuro.Text = "";
            }

            else
            {



                if (txtMiktar.Text != ""&& txtNo.Text!="")
                {
                    tlHavale();
                }
                if (txtEuro.Text != "" && txtNo.Text!="")
                {
                    float sayiEuro = float.Parse(txtEuro.Text);

                    if (sayiEuro >= BORSA_İŞLEM.euroMiktar)
                    {
                        MessageBox.Show("Yetersiz Euro Miktarı", "Havale İşlemi");

                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("update musteriler set euro =euro - @p1 where ID=@p2", con);
                        komut.Parameters.AddWithValue("@p1", sayiEuro);
                        komut.Parameters.AddWithValue("@p2", Form1.mID);

                        SqlCommand komut2 = new SqlCommand("update musteriler set  euro = euro + @p3 where ID=@p4", con);
                        komut2.Parameters.AddWithValue("@p3", txtEuro.Text);
                        komut2.Parameters.AddWithValue("@p4", txtNo.Text);
                        if (Form1.mID == int.Parse(txtNo.Text)) {
                            MessageBox.Show("Kendi Hesabınıza Havale  yapamazsınız", "Havale/EFT İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (sayiEuro <= 10)
                        {
                            MessageBox.Show("Lütfen en az 10 Euro ve üzeri  Giriniz", "Havale/EFT İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            con.Open();
                            int sonuc1 = komut2.ExecuteNonQuery();
                            con.Close();
                            if (sonuc1 == 1)
                            {
                                con.Open();
                                komut.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show(" Euro Havale /EFT işlemi gerçekleştirildi", "Havale /EFT işlemi", MessageBoxButtons.OK);
                                BORSA_İŞLEM.euroMiktar -= sayiEuro;
                                HareketD.kaydet(Form1.mID, (sayiEuro + " Euro  Havale Edildi"));
                                HareketD.kaydet(int.Parse(txtNo.Text), (sayiEuro + " Euro Havale Alındı"));


                            }
                            else
                            {
                                MessageBox.Show("Alıcı Hesap No Hatalı", "Havale /EFT işlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }

                    }

                }
                if (txtDolar.Text != "" && txtNo.Text != "")
                {
                    float sayiDolar = float.Parse(txtDolar.Text);

                    if (sayiDolar >= BORSA_İŞLEM.dolarMiktar)
                    {
                        MessageBox.Show("Yetersiz Dolar Miktari", "Havale İşlemi");

                    }

                    else
                    {
                        SqlCommand komut = new SqlCommand("update musteriler set dolar=dolar - @p1 where ID=@p2", con);
                        komut.Parameters.AddWithValue("@p1", sayiDolar);
                        komut.Parameters.AddWithValue("@p2", Form1.mID);

                        SqlCommand komut2 = new SqlCommand("update musteriler set dolar = dolar + @p3 where ID=@p4", con);
                        komut2.Parameters.AddWithValue("@p3", txtDolar.Text);
                        komut2.Parameters.AddWithValue("@p4", txtNo.Text);
                        if (Form1.mID == int.Parse(txtNo.Text))
                        {
                            MessageBox.Show("Kendi Hesabınıza Havale  yapamazsınız", "Havale/EFT İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (sayiDolar <= 10)
                        {
                            MessageBox.Show("Lütfen en az 10 Dolar ve üzeri  Giriniz", "Havale/EFT İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                        }
                        else
                        {
                            con.Open();
                            int sonuc1 = komut2.ExecuteNonQuery();
                            con.Close();
                            if (sonuc1 == 1)
                            {
                                con.Open();
                                komut.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show(" Dolar Havale /EFT işlemi gerçekleştirildi", "Havale /EFT işlemi", MessageBoxButtons.OK);
                                BORSA_İŞLEM.dolarMiktar -= sayiDolar;
                                HareketD.kaydet(Form1.mID, (sayiDolar + " Dolar Havale Edildi"));
                                HareketD.kaydet(int.Parse(txtNo.Text), (sayiDolar + " Dolar Havale Alındı"));


                            }
                            else
                            {
                                MessageBox.Show("Alıcı Hesap No Hatalı", "Havale /EFT işlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                        txtNo.Text = "";
                        txtDolar.Text = "";
                        txtEuro.Text = "";
                    }
                }
            }
        }

        private void txtNo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
