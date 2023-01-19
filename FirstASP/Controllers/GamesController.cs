using FirstASP.Data;
using FirstASP.Models;
using FirstASP.Services;
using Microsoft.AspNetCore.Mvc;
using FirstASP.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FirstASP.Controllers
{
    public class GamesController : Controller
    //Game Database, add more or remove to show in Index or ShowDetails
    {

        ////INJECT MY SERVICE:
        //IGameData _gameData;
        //public GamesController(IGameData theGameDataService)
        //{
        //    _gameData = theGameDataService;
        //}

        //we inject Dbcontext class here:
        private GamesDbContext _dbContext;
        public GamesController(GamesDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //actions
        public IActionResult Index(string GameNameSearched)
        {
            
            var vgames = from games in _dbContext.vgames
                         select games;/*Link*/

            if (GameNameSearched != null) //narrow down the results
            {
                vgames = vgames.Where(x => x.GameName.ToUpper().Contains(GameNameSearched.ToUpper()));
            }


            //view model
            GamesFilterViewModel vm = new GamesFilterViewModel();
            vm.Filter =GameNameSearched;
            vm.GamesList =vgames.ToList();

            return View(vm);
        }
        public IActionResult ShowAll()
        {
            return RedirectToAction("Index", _dbContext.vgames.ToList());
        }

        public IActionResult DisplayAll()
        {
            return View("Index", _dbContext.vgames.ToList());
        }
        public IActionResult ShowDetails(int id)
        {
            //searches into a database to find information 
            Games? games = _dbContext.vgames.FirstOrDefault(p => p.GameId == id);

            if (games == null && games.ImageDataForGame!=null)
            {
                string imageBase64Data = Convert.ToBase64String(games.ImageDataForGame);
                string imageDataURL = string.Format($"data:image/jpg;base64,{imageBase64Data}");
                ViewBag.ImageUrl = imageDataURL;    
            }
            //returns the game to the view
            return View(games);
        }
        [Authorize]
        public IActionResult Add() // get request will give you form
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(Games videogame)
        {
            if (!ModelState.IsValid)
                return View(videogame);

            foreach(var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                videogame.ImageDataForGame = ms.ToArray();
            }
            _dbContext.vgames.Add(videogame);
            _dbContext.SaveChanges(); //must be called to save changes 
            //_gameData.GamesList.Add(videogame);
            //return View("Index", _gameData.GamesList);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            //search in database for games with given ID 
            Games? foundGames =_dbContext.vgames.FirstOrDefault(p => p.GameId == id);
            return View(foundGames);
        }
        //saves changes for EDIT

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Games gamesChanges)
        {
            //IF INFORMATION IS NOT VALID AND DOES NOT FOLLOW GUIDELINES, RETURN TO VIEW
            if (!ModelState.IsValid)
                return View();
            //SEARCH FOR GAMES IN DATABASE WITH GIVEN ID
            Games? foundGames = _dbContext.vgames.FirstOrDefault(p => p.GameId == gamesChanges.GameId);
            //IF THE DATA IS FOUND, UPDATE THE INFORMATION TO MATCH INFO
            foundGames!.Genre = gamesChanges.Genre;
            foundGames!.Compatablity = gamesChanges.Compatablity;
            foundGames!.ReleaseDate = gamesChanges.ReleaseDate;
            foundGames!.Rating = gamesChanges.Rating;
            foundGames!.Review = gamesChanges.Review;
            foundGames!.Recommended = gamesChanges.Recommended;


            _dbContext.SaveChanges();
            return RedirectToAction("Index");
            //return View("Index", _gameData.GamesList);
        }

        //are you sure form (confirm, decline) 
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Games? foundGames = _dbContext.vgames.FirstOrDefault(p => p.GameId == id);
            if (foundGames != null)
            {
                return View(foundGames);
            }
            else
                return NotFound();
        }

        //if delete confirmed:
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Games? foundGames = _dbContext.vgames.FirstOrDefault(p => p.GameId == id);
            _dbContext.vgames.Remove(foundGames); // deletes game info
            _dbContext.SaveChanges();   
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Start()
        {
            return View();
        }
    }
}
