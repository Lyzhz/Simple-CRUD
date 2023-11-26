using System.ComponentModel.DataAnnotations;

namespace Wingslompson.Models
{
    public class CreateTodoViewModel
    {
        [Required]
                    public string? Title { get; set; }
    }
}
