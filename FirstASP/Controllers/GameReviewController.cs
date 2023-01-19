using Microsoft.AspNetCore.Mvc;
using FirstASP.Models;

namespace FirstASP.Controllers
{
    public class GameReviewController : Controller
    {
        
        public IActionResult Index()
        {
            return Content("Welcome to Controller");
        }

        public IActionResult Show(int id)
        {

            //given an ID, I would normally search into a database for the right info
            // but we don't have a database
            Games st = new Games();
            if (id == 1)
            {
                st.GameName = "Tomb Raider";
                st.ReleaseDate = DateTime.Parse("03/05/2013");
                st.Recommended = true;
                st.Rating = 9/10;
                st.Genre = Genre.FPS;
            }

            else
            {
                st.GameName = "Rust";
                st.ReleaseDate = DateTime.Parse("03/05/2013");
                st.Recommended = true;
                st.Rating = 8 / 10;
                st.Genre = Genre.MULTIPLAYER;
            }

            ViewBag.GamingUser = st;
            return View();
        }
    }
}