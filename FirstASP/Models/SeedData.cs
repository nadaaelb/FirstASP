using FirstASP.Data;

namespace FirstASP.Models
{
    public class SeedData
    {
        public static void SeedDatabase(GamesDbContext myDbContext)
        {
         
if (myDbContext.vgames.Count() == 0)
            {
                List<Games> GamesList = new List<Games>();
                GamesList.Add(new Games()
                {
                    GameId = 1,
                    GameName = "Tomb Raider",
                    Genre = Genre.FPS,
                    ReleaseDate = DateTime.Parse("03/05/2013"),
                    Rating = 10 / 10,
                    Compatablity = "PlayStation 3,Xbox 360,and Microsoft Windows",
                    Recommended = true
                });
                GamesList.Add(new Games()
                {
                    GameId = 2,
                    GameName = "Last of Us",
                    Genre = Genre.MULTIPLAYER,
                    ReleaseDate = DateTime.Parse("03/05/2013"),
                    Rating = 8 / 10,
                    Compatablity = "PlayStation 3; PlayStation 4",
                    Recommended = true
                });
                GamesList.Add(new Games()
                {
                    GameId = 3,
                    GameName = "Rust",
                    Genre = Genre.MULTIPLAYER,
                    ReleaseDate = DateTime.Parse("03/05/2013"),
                    Rating = 8.5 / 10,
                    Compatablity = "Windows; Console",
                    Recommended = true
                });
                GamesList.Add(new Games()
                {
                    GameId = 4,
                    GameName = "Lisa",
                    Genre = Genre.MULTIPLAYER,
                    ReleaseDate = DateTime.Parse("03/05/2013"),
                    Rating = 8 / 10,
                    Compatablity = "Windows, OS X, and Linux",
                    Recommended = true
                });
                GamesList.Add(new Games()
                {
                    GameId = 5,
                    GameName = "Valorant",
                    Genre = Genre.MULTIPLAYER,
                    ReleaseDate = DateTime.Parse("03/05/2013"),
                    Rating = 6 / 10,
                    Compatablity = "Microsoft Windows, PC",
                    Recommended = false
                });

                myDbContext.AddRange(GamesList);

                myDbContext.SaveChanges();
          
            }
            


        }
    }
}
