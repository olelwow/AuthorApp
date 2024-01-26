
using AuthConsole;
using AuthorApp;
using AuthorData;
using ConsoleTables;

using (AuthContext context = new())
{
    context.Database.EnsureCreated();
    // Ska vara med första gången programmet körs, kollar om databas finns annars skapas ny.
}

using AuthContext _context = new();
// Global variabel för context.

bool isRunning = true;
bool successfulInput = false;
Menu menu = new Menu();
DatabaseFunctions func = new DatabaseFunctions();

while (isRunning)
{
    string firstName = "";
    string lastName = "";
    DateOnly date = new DateOnly();

    string title = "";
    string name = "";

    menu.StartMenu();

    successfulInput = int.TryParse(Console.ReadLine(), out int choice);

    switch (choice)
    {
        case 1:
            Console.Clear();
            func.ShowAllAuthors();
            Console.WriteLine("Press '1' to go back to main menu");
            Console.Write(">");

            successfulInput = int.TryParse(Console.ReadLine(), out choice);
            if (successfulInput && choice == 1)
            {
                Console.Clear();
                break;
            }
            break;
        case 2:
            func.AddAuthor(firstName, lastName, date);
            break;
        case 3:
            func.AddBook(title, name);
            break;
        case 4:
            break;
        case 5:
            Console.WriteLine("Shutting down. See ya!");
            isRunning = false; 
            Environment.Exit(0);
            break;
    }


}

