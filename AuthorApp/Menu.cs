﻿using AuthorData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorApp
{
    public class Menu
    {
        public Menu() { }

        public void StartMenu()
        {
            Console.WriteLine("---Welcome to AuthorDB. Choose your action below---\n" +
                              "1. View database\n" +
                              "2. Add author\n" +
                              "3. Add book\n" +
                              "4. Search data\n" +
                              "5. Exit");
            Console.Write(">");
        }
        //public void AuthorTable ()
        //{
        //    string s = String.Format("|{0,5}|{1,5}|{2,5}|{3,5}|", "AuthorID", "Firstname", "Lastname", "Birthdate");
        //    Console.WriteLine(s);
        //}
    }
}
