namespace StringParser.Core
{
    public class TextFile : BaseType
    {
        public string Content { get; private set; }

        public TextFile(string type, string name, string extension, string size, string content) 
            : base(type, name, extension, size)
        {
            this.Content = content;
        }
    }
}
