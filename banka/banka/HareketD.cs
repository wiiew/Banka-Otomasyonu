﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banka
{
    internal class HareketD
    {
        static public void kaydet(int mID, string msj)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-FLBNHN2; initial catalog= bankamatik; integrated security= sspi");
            SqlCommand komut = new SqlCommand("insert into  hareketler (musteriID,islem,tarih) values (@p1,@p2,@p3)",con);
            komut.Parameters.AddWithValue("@p1", mID);
            komut.Parameters.AddWithValue("@p2", msj);
            komut.Parameters.AddWithValue("@p3", DateTime.Now);


            con.Open();
            komut.ExecuteNonQuery();
            con.Close();


        }






    }
}
