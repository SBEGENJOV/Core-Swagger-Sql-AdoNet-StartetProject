using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using CrudAdoSwaggerApi.Model;

namespace CrudAdoSwaggerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusteriController : ControllerBase
    {
        db baglanti= new db();

        [HttpGet]
        public List<Musteri> Get()
        {
            return baglanti.MusteriList();
        }
        [HttpPost]
        public string Post(Musteri musteri)
        {
            return baglanti.MusteriCRUD(musteri);
        }
        [HttpPut("{id}")]
        public string Put(int id,Musteri musteri)
        {
            string islem = "";
            musteri.ID= id;
            islem = baglanti.MusteriCRUD(musteri);
            return islem;
        }
        [HttpDelete("{id}")]
        public string Delete(int id, Musteri musteri)
        {
            string islem = "";
            musteri.ID = id;
            musteri.type = "delete";
            islem = baglanti.MusteriCRUD(musteri);
            return islem;
        }
    }
}
