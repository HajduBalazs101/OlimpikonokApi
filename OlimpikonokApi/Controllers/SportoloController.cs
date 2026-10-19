using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlimpikonokApi.Models;
using OlimpikonokApi.Services;

namespace OlimpikonokApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportoloController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAllSportolo()
        {
            try
            {
                List<Sportolo> sportolok = new SportoloService().GetAllSportolo();
                return Ok(sportolok);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Hiba történt a sportolók lekérdezése során: " + ex.Message);
            }
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetSportoloById(int id)
        {
            try
            {
                Sportolo? sportolo = new SportoloService().GetSportoloById(id);
                if (sportolo == null)
                {
                    return NotFound("A keresett sportoló nem található.");
                }
                return Ok(sportolo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Hiba történt a sportoló lekérdezése során: " + ex.Message);
            }
        }
    }
}
