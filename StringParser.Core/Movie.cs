namespace StringParser.Core
{
    public class Movie : BaseType
    {
        public string Resolution { get; private set; }
        public string Length { get; private set; }

        public Movie(string type, string name, string extension, string size, string resolution, string length) 
            : base(type, name, extension, size)
        {
            this.Resolution = resolution;
            this.Length = length;
        }
    }
}
