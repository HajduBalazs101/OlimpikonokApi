using OlimpikonokApi.Models;

namespace OlimpikonokApi.Services
{
    public class OrszagService
    {
        public List<Orszag> GetAllOrszag()
        {
            try
            {
                using (var context = new OlimpikonokContext())
                {
                    return context.Orszags.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba történt az országok lekérdezése során" + ex.Message);
            }
        }

        public Orszag? GetOrszagById(int id)
        {
            try
            {
                using (var context = new OlimpikonokContext())
                {
                    return context.Orszags.FirstOrDefault(o => o.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba történt az ország lekérdezése során" + ex.Message);
            }
        }
    }
}
