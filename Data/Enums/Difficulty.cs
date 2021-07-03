using System.ComponentModel.DataAnnotations;

namespace Twenty.Data.Enums
{
    public enum Difficulty
    {
        [Display(Name = "Beginner")]
        Beginner, 
        [Display(Name = "Intermediate")]
        Intermediate, 
        [Display(Name = "Advanced")]
        Advanced
    }
}
