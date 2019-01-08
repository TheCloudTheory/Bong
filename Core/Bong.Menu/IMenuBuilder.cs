using System.Collections.Generic;

namespace Bong.Menu
{
    public interface IMenuBuilder
    {
        void BuildMenu(IList<MenuItem> items);
    }
}