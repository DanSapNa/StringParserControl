using System;

namespace StringParser.Core
{
    public abstract class BaseType : IComparable
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }

        public void Print() { }

        public BaseType(string type, string name, string extension, string size)
        {
            this.Type = type;
            this.Name = name;
            this.Extension = extension;
            this.Size = size;
        }

        public int CompareTo(object obj)
        {
            BaseType baseObject = obj as BaseType;
            if (baseObject != null)
                return Int32.Parse(this.Size.Replace("M", "").Replace("G", "").Replace("B", "")).CompareTo(Int32.Parse(baseObject.Size.Replace("M", "").Replace("G", "").Replace("B", "")));
            else
                throw new NotImplementedException("It's impossible to compare two objects");
        }
    }
}
