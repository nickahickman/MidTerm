﻿using System;
using System.IO;
using System.Linq;

namespace MidTerm
{
    public class Albums
    {

        public string Title { get; set; }
        public string Category { get; set; }
        public string Artist { get; set; }
        public string Rating { get; set; }
        public string Price { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }

        StreamReader reader = new StreamReader(@"C:\\Users\Duncan\Documents\MidtermAlbums.txt");
        public Albums()
        { }

       
        public Albums(string Title, string Category, string Artist, string Rating, string Price, string Year, string Description)
        {
        
            this.Title = Title;
            this.Category = Category;
            this.Artist = Artist;
            this.Rating = Rating;
            this.Price = Price;
            this.Year = Year;
            this.Description = Description;
        }






        public static Albums FromCsv(string csvline)
        {

            string[] values = csvline.Split(',');

            Albums albums = new Albums();
            //  while (!Albums.EndOfStream)
            {
                for (int i = 0; i < values.Length - 1; i++)
                {


                    albums.Title = (values[0]);
                    albums.Category = (values[1]);
                    albums.Artist = (values[2]);
                    albums.Rating = (values[3]);
                    albums.Price = (values[4]);
                    albums.Year = (values[5]);
                    albums.Description = (values[6]);


                }

            }

            return albums;

        }




        public void PrintInfo()
        {
            Console.WriteLine();
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Artist: {Artist}");
            Console.WriteLine($"Review: { Rating}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine();

        }




        public virtual void Preview()
        {

        }




    }
}
