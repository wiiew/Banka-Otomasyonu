using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banka
{
    public partial class Musterİslem : Form
    {
        public Musterİslem()
        {
            InitializeComponent();
        }

        private void btnParaCek_Click(object sender, EventArgs e)
        {
            Form2 pc = new Form2();
            pc.Show();
            
        }

        private void btnCıkış_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void Musterİslem_Load(object sender, EventArgs e)
        {
            lbladSoyad.Text = Form1.adSoyad;
            lblHesapNo.Text = Form1.mID.ToString();


        }

        private void btnParaYatır_Click(object sender, EventArgs e)
        {
            Para_Yatır py = new Para_Yatır();
            py.Show(); 
        }

        private void btnBakiyeGoruntule_Click(object sender, EventArgs e)
        {
            Bakiye b = new Bakiye();
            b.Show();
        }

        private void btnHavale_Click(object sender, EventArgs e)
        {
            HavaleEFT eft = new HavaleEFT();
            eft.Show();
        }

        private void btnSifre_Click(object sender, EventArgs e)
        {
            Sifre_Değiştirme sf = new Sifre_Değiştirme();
            sf.Show();
        }

        private void btnHesapH_Click(object sender, EventArgs e)
        {
            HesapDokumu hd = new HesapDokumu();
            hd.Show();
        }

        private void btnBorsa_Click(object sender, EventArgs e)
        {
            BORSA_İŞLEM b = new BORSA_İŞLEM();
            b.Show();
        }
    }
    
}
