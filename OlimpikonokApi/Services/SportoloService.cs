using OlimpikonokApi.Models;

namespace OlimpikonokApi.Services
{
    public class SportoloService
    {
        public List<Sportolo> GetAllSportolo()
        {
            try
            {
                using (var context = new OlimpikonokContext())
                {
                    return context.Sportolos.ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Hiba történt a sportolók lekérdezése során" + ex.Message);
            }
        }
        public Sportolo? GetSportoloById(int id)
        {
            try
            {
                var context = new OlimpikonokContext();
                return context.Sportolos.FirstOrDefault(s => s.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba történt a sportoló lekérdezése során" + ex.Message);
            }
        }
    }
}
