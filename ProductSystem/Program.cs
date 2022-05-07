﻿using ProductSystem.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProductSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> prod = new List<Product>();
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Commmon. used or imported (c/u/i)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (ch =='i')
                {
                    Console.Write("Custom fee: ");
                    double fee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    prod.Add(new ImportedProduct(name, price, fee));
                }
                else if (ch == 'u')
                {
                    Console.Write("Manufature date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    prod.Add(new UsedProduct(name,price,date));
                }
                else
                {
                    prod.Add(new Product(name, price));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach (Product product in prod)
            {
                Console.WriteLine(product.PriceTag());
            }
        }
    }
}
