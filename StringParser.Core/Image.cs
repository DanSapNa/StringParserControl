namespace StringParser.Core
{
    public class Image : BaseType
    {
        public string Resolution { get; private set; }

        public Image(string type, string name, string extension, string size, string resolution)
            : base(type, name, extension, size)
        {
            this.Resolution = resolution;
        }
    }
}
