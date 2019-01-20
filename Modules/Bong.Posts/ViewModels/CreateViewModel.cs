using System.ComponentModel.DataAnnotations;

namespace Bong.Posts.ViewModels
{
    public class CreateViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Body { get; set; }
    }
}