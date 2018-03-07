using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringParser.Core
{
    public class Parser
    {
        private List<string> parsedInputString;
        private string regExprTextFile = @"Text:.*";
        private string regExprMovie = @"Movie:.*";
        private string regExprImage = @"Image:.*";
        private List<TextFile> listTextFiles = new List<TextFile>();
        private List<Image> listImages = new List<Image>();
        private List<Movie> listMovies = new List<Movie>();

        public Parser(string inputString)
        {
            this.parsedInputString = inputString.Replace("\n", "").Split('\r').ToList<string>();
        }

        public void ParseString()
        {
            GetTextFiles();
            GetMovies();
            GetImages();
        }

        private void GetTextFiles()
        {
            Regex rgxText = new Regex(regExprTextFile);

            for (int i = 0; i < parsedInputString.Count; i++)
            {
                if (rgxText.IsMatch(parsedInputString[i]))
                {
                    string[] parsed = parsedInputString[i].Split(':');
                    listTextFiles.Add(new TextFile(GetType(parsed), GetName(parsed), GetExtension(parsed), GetSize(parsed), GetTextContent(parsed)));
                }
            }

            listTextFiles.Sort();
        }

        private void GetMovies()
        {
            Regex rgxMovie = new Regex(regExprMovie);

            for (int i = 0; i < parsedInputString.Count; i++)
            {
                if (rgxMovie.IsMatch(parsedInputString[i]))
                {
                    var parsed = parsedInputString[i].Split(':');
                    listMovies.Add(new Movie(GetType(parsed), GetName(parsed), GetExtension(parsed), GetSize(parsed), GetResolution(parsed), GetMovieLength(parsed)));
                }
            }

            listMovies.Sort();
        }

        private void GetImages()
        {
            Regex rgxImage = new Regex(regExprImage);

            for (int i = 0; i < parsedInputString.Count; i++)
            {
                if (rgxImage.IsMatch(parsedInputString[i]))
                {
                    var parsed = parsedInputString[i].Split(':');
                    listImages.Add(new Image(GetType(parsed), GetName(parsed), GetExtension(parsed), GetSize(parsed), GetResolution(parsed)));
                }
            }

            listImages.Sort();
        }

        public void Print()
        {

            Console.WriteLine("Text files:");

            for (int i = 0; i < listTextFiles.Count; i++)
            {
                Console.WriteLine($"\t{listTextFiles[i].Name}");
                Console.WriteLine($"\t\tExtension: {listTextFiles[i].Extension}");
                Console.WriteLine($"\t\tSize: {listTextFiles[i].Size}");
                Console.WriteLine($"\t\tContent: {listTextFiles[i].Content}");
            }

            Console.WriteLine("Movies:");

            for (int i = 0; i < listMovies.Count; i++)
            {
                Console.WriteLine($"\t{listMovies[i].Name}");
                Console.WriteLine($"\t\tExtension: {listMovies[i].Extension}");
                Console.WriteLine($"\t\tSize: {listMovies[i].Size}");
                Console.WriteLine($"\t\tResolution: {listMovies[i].Resolution}");
                Console.WriteLine($"\t\tLength: {listMovies[i].Length}");
            }

            Console.WriteLine("Images:");

            for (int i = 0; i < listImages.Count; i++)
            {
                Console.WriteLine($"\t{listImages[i].Name}");
                Console.WriteLine($"\t\tExtension: {listImages[i].Extension}");
                Console.WriteLine($"\t\tSize: {listImages[i].Size}");
                Console.WriteLine($"\t\tResolution: {listImages[i].Resolution}");
            }
        }

        private string GetType(string[] parsed)
            => parsed[0].Trim();

        private string GetName(string[] parsed)
            => parsed[1].Split(';')[0].Split('(')[0].Trim();

        private string GetExtension(string[] parsed)
            => parsed[1].Split(';')[0].Split('(')[0].Split('.').Last().Trim();

        private string GetSize(string[] parsed)
            => parsed[1].Split(';')[0].Split('(')[1].Replace(")", "").Trim();

        private string GetTextContent(string[] parsed)
            => parsed[1].Split(';').Last().Trim();

        private string GetResolution(string[] parsed)
            => parsed[1].Split(';')[1].Trim();

        private string GetMovieLength(string[] parsed)
            => parsed[1].Split(';').Last().Trim();

    }
}
