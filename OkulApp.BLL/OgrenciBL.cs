using System;
using System.Data.SqlClient;
using DAL;
using OkulApp.MODEL;

namespace OkulApp.BLL //Business Logic Layer
{
    public class OgrenciBL
    {
        public bool OgrenciEkle(Ogrenci ogr)
        {
            try
            {
                //cmd.Parameters.AddWithValue("@Ad", ogr.Ad);   Bu sekilde de olabilir. Range de gerek kalmaz
                SqlParameter[] p =
                {
                    new SqlParameter("@Ad", ogr.Ad),
                    new SqlParameter("@Soyad", ogr.Soyad),
                    new SqlParameter("@Numara", ogr.Numara)
                };

                var hlp = new Helper();
                return hlp.ExecuteNonQuery("Insert into tblOgrenci (Ad,Soyad,Numara) values (@Ad,@Soyad,@Numara)", p) > 0;
            }
            catch (SqlException )
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //if (baglanti != null && baglanti.State != ConnectionState.Closed)
                //{
                //    //baglanti.Close();
                //    baglanti.Dispose();   //SQL OBJELERINI BELLEKTEN ATAR (normalde garbage collector isimli sistem oto yapar. ancak sql islemlerini yapmaz)
                //    cmd.Dispose();
                //}
            }
        }
    }
}

//n KATMANLI MIMARI (3 katmanli proje)