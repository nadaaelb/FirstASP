using System.ComponentModel.DataAnnotations;

namespace FirstASP.Models
{
    public enum Genre { HORROR, MULTIPLAYER, INDIE, FPS, SURVIVAL, PUZZLE, SINGLEPLAYER, MYSTERY, ACTION }
    public class Games
    {
        [Key]


       [Required(ErrorMessage="You need an ID")]
        [Display(Name="Game ID:")]
        public int GameId { get; set; }

        [Required(ErrorMessage ="Game name required!")]
        [StringLength(100)]
        [Display(Name = "Game Name:")]
        public string? GameName { get; set; }

        [Range(typeof(DateTime), "01/01/1900", "01,01,2023")]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date:")]
        public DateTime ReleaseDate { get; set; }

        //[Required(ErrorMessage = "Must add review!")]
        [Display(Name = "Review:")]
        public string? Review { get; set; }

        [Display(Name = "Compatable on the following devices:")]
        public string? Compatablity { get; set; }

        [Display(Name = "Is this game recommended?:")]
        public bool Recommended { get; set; }

        [Required(ErrorMessage = "Must add a rating")]
        [Display(Name = "Rating:")]
        public double Rating { get; set; }

        [Required(ErrorMessage = "Must select a genre!")]
        [Display(Name = "Genre:")]
        public Genre Genre { get; set; }

        [Display(Name = "Game photo:")]
        public byte[]? ImageDataForGame { get; set; }
    }
}