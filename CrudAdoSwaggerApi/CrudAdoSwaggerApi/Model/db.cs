using System.Data.SqlClient;
using System.Data;


namespace CrudAdoSwaggerApi.Model
{
    public class db
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-5K7HMBT\\SQLEXPRESS;Database=bauKolej;Integrated Security=true;");

        public string MusteriCRUD(Musteri musteri)
        {
            string islem = "";
            con.Open();
            using (SqlCommand cmd = new SqlCommand("mcrud", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", musteri.ID);
                cmd.Parameters.AddWithValue("@AdSoyad", musteri.AdSoyad);
                cmd.Parameters.AddWithValue("@Email", musteri.Email);
                cmd.Parameters.AddWithValue("@Meslek", musteri.Meslek);
                cmd.Parameters.AddWithValue("@type", musteri.type);
                cmd.ExecuteNonQuery();
                
            }
           con.Close();
            return islem;
        }
        public List<Musteri> MusteriList()
        {
            List<Musteri> mListe= new List<Musteri>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "mList";
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Musteri musteri = new Musteri();
                musteri.ID = Convert.ToInt32(dr["ID"]);
                musteri.AdSoyad = dr["AdSoyad"].ToString();
                musteri.Email = dr["Email"].ToString();
                musteri.Meslek = dr["Meslek"].ToString();
                mListe.Add(musteri);

            }
            con.Close();
            return mListe;
        }
    }
}
