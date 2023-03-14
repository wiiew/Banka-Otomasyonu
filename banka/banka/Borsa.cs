using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;



namespace banka
{
    public partial class Borsa : Form
    {
        public Borsa()
        {
            InitializeComponent();
        }

        private void Borsa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            


        }

        private void Borsa_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string bugun = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(bugun);
            DateTime tarih = Convert.ToDateTime(xmldoc.SelectSingleNode("//Tarih_Date").Attributes["tarih"].Value);
            string USD = xmldoc.SelectSingleNode("Tarih_Date/Currency [@KOD='USD'/BanknotSelling").InnerXml;
            label5.Text=string.Format("Tarih{0} USD; {1}",tarih.ToShortDateString(),USD);

            

                





            
        }

    }
}

