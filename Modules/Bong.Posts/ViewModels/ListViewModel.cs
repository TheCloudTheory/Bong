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
            public Post(PostEntity post)
            {
                Id = post.RowKey;
                Title = post.Title;
                Url = post.Url;
                DateCreated = post.DateCreated;
            }

            public string Id { get; }

            public DateTimeOffset DateCreated { get; }

            public string Url { get; }

            public string Title { get; }
        }
    }
}