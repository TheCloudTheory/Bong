namespace Bong.Routing
{
    public sealed class RouteDescription
    {
        public string Name { get; }
        public string Template { get; }
        public object Defaults { get; }

        public RouteDescription(string name, string template, object defaults)
        {
            Name = name;
            Template = template;
            Defaults = defaults;
        }
    }
}