namespace Bong.Menu
{
    public class MenuItem
    {
        public string Name { get; }
        public string Text { get; }
        public string Url { get; }
        public UrlKind Kind { get; }

        public MenuItem(string name, string text, string url, UrlKind kind)
        {
            Name = name;
            Text = text;
            Url = url;
            Kind = kind;
        }
    }
}