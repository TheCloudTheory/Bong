using System.Collections.Generic;

namespace Bong.Menu
{
    public interface IMenuCache
    {
        List<MenuItem> AdminItems { get; }
        List<MenuItem> Items { get; }
    }

    internal sealed class MenuCache : IMenuCache
    {
        public List<MenuItem> AdminItems { get; }
        public List<MenuItem> Items { get; }

        public MenuCache()
        {
            AdminItems = new List<MenuItem>();
            Items = new List<MenuItem>();
        }
    }
}