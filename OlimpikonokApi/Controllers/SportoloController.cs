using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlimpikonokApi.DTOs;
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

        //egy példa arra ha nem a serviceben hanem a controllerben készítjük el a DTO-t
        [HttpGet("GetAllSportoloDTO")]
        public IActionResult GetAllSportoloDTO()
        {
            try
            {
                using (var context = new OlimpikonokContext())
                {
                    List<SportoloDTO> sportoloDTOk = context.Sportolos.Include(s => s.Sportag).Include(s => s.Orszag)
                        .Select(s => new SportoloDTO
                        {
                            Id = s.Id,
                            Nev = s.Nev,
                            SportagNev = s.Sportag.Megnevezes,
                            Ermek = s.Ermek,
                            OrszagNev = s.Orszag.Nev
                        }).ToList();
                    return Ok(sportoloDTOk);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Hiba történt a sportolók DTO lekérdezése során: " + ex.Message);
            }
        }
        [HttpGet("GetSportoloDTOById/{id}")]
        public IActionResult GetSportoloDTOById(int id)
        {
            try
            {
                using (var context = new OlimpikonokContext())
                {
                    List<SportoloDTO> sportoloDTOk = context.Sportolos.Include(s => s.Sportag).Include(s => s.Orszag).Where(s => s.Id == id)
                    .Select(s => new SportoloDTO
                    {
                        Id= s.Id,
                        Nev = s.Nev,
                        SportagNev = s.Sportag.Megnevezes,
                        Ermek = s.Ermek,
                        OrszagNev = s.Orszag.Nev
                    }).ToList();
                    return Ok(sportoloDTOk);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Hiba történt a sportoló DTO lekérdezése során: " + ex.Message);
            }
        }
    }
}
