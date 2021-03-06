﻿using StringParser.Core;
using System;

namespace StringParser.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string initialStringToParse =
                @"Text: file.txt(6B); Some string content
                    Image: img.bmp(19MB); 1920x1080
                    Text:data.txt(12B); Another string
                    Text:data1.txt(7B); Yet another string
                    Movie:logan.2017.mkv(19GB); 1920x1080; 2h12m";

            Parser parser = new Parser(initialStringToParse);
            parser.ParseString();
            parser.Print();

            Console.ReadLine();
        }
    }
}
