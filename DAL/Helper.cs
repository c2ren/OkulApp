using System;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL  //Data Access Layer
{
    public class Helper
    {
        SqlConnection baglanti;
        SqlCommand cmd;

        //SQL Baglanti stringini OkulApp projesindeki App.config dosyasi icine attik. Oradan getiriyoruz.
        string cstr = ConfigurationManager.ConnectionStrings["cstr"].ConnectionString;

        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p = null)
        {
            using (baglanti = new SqlConnection(cstr))
            {
                using (cmd = new SqlCommand(cmdtext,baglanti)) 
                {
                    if (p != null)
                    {
                        cmd.Parameters.AddRange(p);
                    }
                    baglanti.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            //DISPOSE islemi SQL OBJELERINI BELLEKTEN ATAR (normalde garbage collector isimli sistem oto yapar. ancak sql gibi islemleri yapmaz)
            //using kullandigimizda using in disina cikildiginda otomatik dispose eder bu sayede dispose kodu yazmamiza gerek kalmaz (dogal olarak baglantiyi da oto kapatir) 
        }
    }
}
