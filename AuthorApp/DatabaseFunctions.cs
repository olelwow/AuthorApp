using AuthConsole;
using AuthorData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace AuthorApp
{
    public class DatabaseFunctions
    {
        public DatabaseFunctions() { }

        public void ShowAllAuthors ()
        {
            using AuthContext context = new AuthContext();
            var authors = context.Authors.ToList();
            // Tar allt som finns i tabellen Authors och sparar i variabel
            var books = context.Books.ToList();

            
            
            
            foreach (var author in authors)
            {
                var table = new ConsoleTable(["AuthorID", "Firstname", "Lastname", "Birthdate"]);
                var bookTable = new ConsoleTable(["Book Title", "AuthorID"]);
                table.AddRow(author.AuthorId, author.FirstName, author.LastName, author.BirthDate);
                

                foreach (var book in books)
                {
                    if (book.Author.AuthorId == author.AuthorId)
                    {
                        bookTable.AddRow(book.Title, book.Author.AuthorId);
                    }
                    
                    
                }
                Console.WriteLine(table);
                Console.WriteLine(bookTable);
                
            }
        }
        public void AddAuthor (string firstName, string lastName, DateOnly date)
        {
            using AuthContext context = new AuthContext();

            Console.WriteLine("Firstname?");
            firstName = Console.ReadLine();
            Console.WriteLine("Lastname?");
            lastName = Console.ReadLine();
            Console.WriteLine("Birthdate? YYYY/MM/DD");
            date = DateOnly.Parse(Console.ReadLine());
            // tar in inputs

            
            var author = context.Authors.Add(new Author { FirstName = firstName, LastName = lastName, BirthDate = date });
            context.SaveChanges();
            // Lägger till ny författare, SAVE CHANGES!!
        }
        public void AddBook (string title, string name)
        {
            using AuthContext context = new AuthContext();
            Console.WriteLine("Who wrote this book?");
            name = Console.ReadLine();
            string[] authorName = name.Split(" ");
            // Delar upp namnet i för och efternamn.

            var existingAuthor = context.Authors.FirstOrDefault(a => a.FirstName == authorName[0] && a.LastName == authorName[1]);
            // hittar författare för att kunna lägga till bok på denna person.
            
            if (existingAuthor != null)
            {
                Console.WriteLine("Title?");
                title = Console.ReadLine();
                existingAuthor.Books.Add(new Book() { Title = title });
                // Ny bok som kopplas med författaren vars namn man angett. 
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Do you want to add this author?");
                string input = Console.ReadLine().ToLower();
                if (input.Equals("yes"))
                {
                    Console.WriteLine("When was this author born?");
                    DateOnly date = DateOnly.Parse(Console.ReadLine());

                    var author = context.Authors.Add(new Author { FirstName = authorName[0], LastName = authorName[1], BirthDate = date });

                    Console.WriteLine("What is the title of the book?");
                    title = Console.ReadLine();

                    var newAuthor = context.Authors.FirstOrDefault(a => a.FirstName == authorName[0] && a.LastName == authorName[1]);
                    context.SaveChanges();
                    if (newAuthor != null)
                    {
                        newAuthor.Books.Add(new Book() { Title = title });
                        context.SaveChanges();
                    }
                    
                }
            }

        }
        public void SearchData ()
        {
            using AuthContext context = new AuthContext();
            Console.WriteLine("What is the first name of the author?");
            string firstInput = Console.ReadLine();
            string secondInput = "";

            var author = context.Authors.Count(a => a.FirstName == firstInput);
            if (author > 1)
            {
                Console.WriteLine($"There are multiple authors named {firstInput}. What is the authors last name?");
                secondInput = Console.ReadLine();
                var correctAuthor = context.Authors.FirstOrDefault(a => a.FirstName == firstInput && a.LastName == secondInput);
            }
            else
            {
                Console.WriteLine("Wack");
            }
        }
    }
}
