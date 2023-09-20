using Newtonsoft.Json;
using TypeWriter.QuoteGenerator;
using TypeWriter.Services;

namespace TypeWriter;

internal class Menu
{
    RandomQuoteGenerator r1 = new RandomQuoteGenerator();
    TypeWriterEffect t1 = new TypeWriterEffect();
    public async Task MainMenu()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press any key to get a random quote");
        Console.WriteLine("Press Q to quit");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Q)
        {
            Environment.Exit(0);
        }
        else
        {
            await GetQuote();
        }

    }
    private async Task GetQuote()
    {

        try
        {
            var randomQuote = await RandomQuoteGenerator.GetRandomQuote();
            Console.Clear();

            if (randomQuote != null)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine($"Author:\n {randomQuote.originator.name}");
                Console.WriteLine("--------------------");
                Console.WriteLine($"URL:\n {randomQuote.originator.url}");
                Console.WriteLine("--------------------");
                if(!string.IsNullOrWhiteSpace(randomQuote.originator.description))
                { 
                    Console.WriteLine($"Description:\n {randomQuote.originator.description}");
                    Console.WriteLine("--------------------");
                }
               
                
                Console.Write("\n\n");
                t1.WriteMessage(randomQuote.content);
                Console.WriteLine("\n\n");
                
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
