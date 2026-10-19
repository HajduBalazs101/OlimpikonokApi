using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlimpikonokApi.Models;
using OlimpikonokApi.Services;

namespace OlimpikonokApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrszagController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAllOrszag()
        {
            try
            {
                List<Orszag> orszagok = new OrszagService().GetAllOrszag();
                return Ok(orszagok);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Hiba történt az országok lekérdezése során: " + ex.Message);
            }
        }

    [HttpGet("GetById/{id}")]
        public IActionResult GetOrszagById(int id)
        {
            try
            {
                Orszag? eredmeny = new OrszagService().GetOrszagById(id);
                if (eredmeny != null)
                {
                    return Ok(eredmeny);
                }
                else 
                {
                    return NotFound($"Nincs ilyen azonosítóval rendelkező ország: {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Hiba történt az ország lekérdezése során: " + ex.Message);
            }
        }
    }
}
