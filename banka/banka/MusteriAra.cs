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
    public partial class MusteriAra : Form
    {
        public MusteriAra()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=DESKTOP-FLBNHN2; initial catalog= bankamatik; integrated security= sspi");


        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("select * from musteriler where   ID =@p1 or tcNo=@p2", con);
            komut.Parameters.AddWithValue("@p1", txtAra.Text);
            komut.Parameters.AddWithValue("@p2", txtAra.Text);


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

        private void MusteriAra_Load(object sender, EventArgs e)
        {

        }

        private void txtAra_TextChanged(object sender, EventArgs e)
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

        private void txtAdres_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtadSoyad_KeyPress(object sender, KeyPressEventArgs e)
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



