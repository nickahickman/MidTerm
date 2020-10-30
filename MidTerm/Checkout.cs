﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MidTerm
{
    class Checkout
    {
        public static List<Albums> albums = new List<Albums>() 
        { 
            new Albums("Album 1", Genre.Pop, "Band 1", "9/10", 14.50),
            new Albums("Album 2", Genre.Rock, "Band 2", "8/10", 10.00),
            new Albums("Album 3", Genre.Jazz, "Band 3", "7/10", 13.75),
        };

        public static List<ItemOrder> ShoppingBag = new List<ItemOrder>();
        public static void Start()
        { 
            while (true)
            {
                UILibs.ConsoleLibrary.DrawTitle("Welcome to GC Records");

                PrintCatalogue(albums);

                int selection = UILibs.UserInputLibrary.GetMenuSelection("Which item would you like to buy? ", albums);
                AddItemToShoppingCart(selection);

                Console.WriteLine("Here's your current order");
                PrintShoppingCart();

                if (!UILibs.UserInputLibrary.UserWantsToContinue("Would you like anything else? We have lots of great stuff", "Invalid entry"))
                {
                    Console.WriteLine("Ok, let's ring you up!");
                    GetPaymentMethod();
                }
                else 
                {
                    Console.Clear();
                    continue;
                }
            }
        }

        public static void PrintCatalogue(List<Albums> catalogue)
        {
            UILibs.ConsoleLibrary.DrawTitle("Current Catalogue");

            for (int i = 0; i < catalogue.Count; i++)
            {
                Console.WriteLine($"{i + 1} {GetRecordInfo(catalogue[i])}");
            }
            Console.WriteLine();
        }

        public static string GetRecordInfo(Albums record)
        {
            return $"{record.Title} by {record.Description}. Price: {record.Price}";
        }

        public static void AddItemToShoppingCart(int selection)
        {
            Console.WriteLine($"You have selected: {GetRecordInfo(albums[selection])}");

            int quantity = UILibs.UserInputLibrary.GetIntegerResponse("How many would you like? ", 10);
            double totalForSelection = albums[selection].Price * quantity;

            Console.WriteLine($"{quantity} copies of {albums[selection].Title}, That'll be {totalForSelection}");

            if (UILibs.UserInputLibrary.GetYesOrNoInput("Are you sure? "))
            {
                ShoppingBag.Add(new ItemOrder(albums[selection].Title, quantity, albums[selection].Price));
                Console.WriteLine("Great, I've added that to your bag!");
            }
            else 
            {
                Console.WriteLine("Not a problem, let us know if you change your mind.");
            }
        }

        public static void PrintShoppingCart()
        {
            foreach (ItemOrder order in ShoppingBag)
            {
                Console.WriteLine(order.GetOrderInfo());
            }
        }

        public static void GetPaymentMethod()
        {
            List<string> options = new List<string> { "Cash", "Credit", "Check" };

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {options[i]}");
            }

            int selection = UILibs.UserInputLibrary.GetMenuSelection("How will you be paying today? ", options);

            Console.WriteLine($"Great, you'll be paying with {options[selection]}");
        }

        public static void PayWithCheck()
        { 
            
        }

        public static void PayWithCash()
        { 
        
        }

        public static void PayWithCredit()
        { 
        
        }
    }
}
