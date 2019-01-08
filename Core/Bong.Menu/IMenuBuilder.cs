using System.Collections.Generic;

namespace Bong.Menu
{
    public interface IMenuBuilder
    {
        IEnumerable<MenuItem> BuildMenu();
    }
}