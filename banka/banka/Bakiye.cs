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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace banka
{
    public partial class Bakiye : Form
    {
        public Bakiye()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=DESKTOP-FLBNHN2; initial catalog= bankamatik; integrated security= sspi");
        private void Bakiye_Load(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("select* from musteriler where ID=@p1", con);
            komut2.Parameters.AddWithValue("@p1", Form1.mID);
            con.Open();

            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
               
               BORSA_İŞLEM.dolarMiktar = float.Parse(dr["dolar"].ToString());
               BORSA_İŞLEM.euroMiktar = float.Parse(dr["euro"].ToString());
               lblBakiye.Text = Form1.mBakiye.ToString() + " TL";

            }
            con.Close();

            label4.Text = BORSA_İŞLEM.dolarMiktar.ToString() + " Dolar";
            label6.Text = BORSA_İŞLEM.euroMiktar.ToString() + " Euro";
            HareketD.kaydet(Form1.mID, "Bakiye Sorgulandı");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            

        }

        private void lblBakiye_Click(object sender, EventArgs e)
        {

        }
    }
}
