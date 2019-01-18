using System;
using System.Collections.Generic;
using System.Linq;
using Bong.Posts.Models;

namespace Bong.Posts.ViewModels
{
    public class ListViewModel
    {
        public ListViewModel(IEnumerable<PostEntity> posts)
        {
            Posts = posts.Select(_ => new Post(_));
        }

        public IEnumerable<Post> Posts { get; }

        public class Post
        {
            public Post(PostEntity postEntity)
            {
                Title = postEntity.Title;
                Url = postEntity.Url;
                DateCreated = postEntity.DateCreated;
            }

            public DateTimeOffset DateCreated { get; }

            public string Url { get; }

            public string Title { get; }
        }
    }
}