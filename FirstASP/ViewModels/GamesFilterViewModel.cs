using FirstASP.Models;
namespace FirstASP.ViewModels
{
    public class GamesFilterViewModel
    {
        public string Filter { get; set; }
        public IEnumerable<Games> GamesList { get; set; }
    }
}
