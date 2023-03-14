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
    public partial class Para_Yatır : Form
    {
        public Para_Yatır()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=DESKTOP-FLBNHN2; initial catalog= bankamatik; integrated security= sspi");

        private void Para_Yatır_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            float sayi = float.Parse(maskedTextBox1.Text);

            if (int.Parse(maskedTextBox1.Text) <= 10)
            {
                MessageBox.Show("Lütfen En Az 10 TL Yatiriniz", "Para Yatırma İşlemi");
            }
            else
            {
                SqlCommand komut = new SqlCommand("update musteriler set bakiye += @p1 where ID=@p2", con);
                komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@p2", Form1.mID);

                con.Open();

                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("Para Yatırma Başarılı ", "Para Yatırma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Form1.mBakiye += sayi;
                    HareketD.kaydet(Form1.mID, (sayi + "TL Para Yatırılıdı"));
                }
                else
                {
                    MessageBox.Show("Para Yatırma Başarısız ", "Para Yatırma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                maskedTextBox1.Text = "";
                con.Close();

            }
            maskedTextBox1.Text = "";
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
