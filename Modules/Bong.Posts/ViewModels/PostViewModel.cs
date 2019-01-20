using System.ComponentModel.DataAnnotations;
using Bong.Posts.Models;

namespace Bong.Posts.ViewModels
{
    public class PostViewModel
    {
        public PostViewModel()
        {
        }

        public PostViewModel(PostEntity post)
        {
            Title = post.Title;
            Url = post.Url;
            Body = post.Body;
        }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Body { get; set; }
    }
}