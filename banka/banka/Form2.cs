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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=DESKTOP-FLBNHN2; initial catalog= bankamatik; integrated security= sspi");

        private void button1_Click(object sender, EventArgs e)
        {


            float sayi=float.Parse(maskedTextBox1.Text);
            if (sayi > Form1.mBakiye)
            {
                MessageBox.Show("Bakiyeniz Yetersiz", "Para Çekme İşlemi");
            }
            else
            {
                SqlCommand komut = new SqlCommand("update musteriler set bakiye -= @p1 where ID=@p2", con);
                komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@p2", Form1.mID);

                con.Open();

                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show( "Para Çekimi Başarılı ", "Para Çekme İş",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    Form1.mBakiye -= sayi;
                    HareketD.kaydet(Form1.mID, (sayi + "TL Para Çekildi"));
                }
                else
                {
                    MessageBox.Show("Para Çekimi Başarısız ", "Para Çekme İş", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                maskedTextBox1.Text = "";
                con.Close();



            }





        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
