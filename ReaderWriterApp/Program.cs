namespace ReaderWriterApp;

class Program
{
    static void Main(string[] args)
    {
        string? input;
        Config config = new Config();

        // Wait until the user enters a non-empty command.
        while (true)
        {
            Console.Write("Enter command line arguments (e.g. --mode read --path test.txt): ");
            input = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(input))
                break;
        }
        
        try
        {
            // For now, a hardcoded command is used for easier testing. 
            // In the final version, 'input' will be passed instead.
            Parser.Parse("--mode read --path test.txt", config);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            // Ensure the FileStream is closed even if an exception occurs.
            config.Dispose();
        }
    }
}