namespace ReaderWriterApp;

class Program
{
    static void Main(string[] args)
    {
        string infoFilePath = "info.txt";
        
        Config config = new Config();
        string? input = null;
        
        // Removes invalid or old saved configuration.
        if (File.Exists(infoFilePath))
        {
            int length = File.ReadLines(infoFilePath).FirstOrDefault()?.Split(' ').Length ?? 0;
            int lineCount = File.ReadAllLines(infoFilePath).Length;
            
            if (lineCount >= 2 || length < 6)
            {
                File.Delete(infoFilePath);
            }
        }
        
        // Gets command line arguments from the user if no saved configuration exists.
        if (!File.Exists(infoFilePath))
        {
            // Wait until the user enters a non-empty command.
            while (true)
            {
                Console.Write("Enter command line arguments (mode can be read/write, flushMode can be manual/auto; e.g. --mode read --path test.txt --flushMode manual): ");               
                input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    break;
            }
            
        }
        else
        {
            // Reads saved configuration and switches the application mode.
            using StreamReader reader = new StreamReader(infoFilePath);
            
            string? firstUserChoice = reader.ReadLine();
            if (firstUserChoice != null)
            {
                    string[] words = firstUserChoice.Split(' ');
                    
                    string secondUserMode = (words[1] == "read") ? "write" : "read";
                    
                    input = $"--mode {secondUserMode} {words[2]} {words[3]} {words[4]} {words[5]}";
            }
            
        }

        try
        {
            if (input != null)
            {
                // Parses arguments and configures the application.
                Parser.Parse(input, config);
                // Saves current configuration for the next run.
                File.AppendAllText(infoFilePath, input + '\n');


                string[] words = input.Split(' ');
                string mode = words[1];

                // Starts writer or reader depending on selected mode.
                if (mode == "write")
                {
                    Console.WriteLine($"Your mode is: {mode}. If you want to stop, write /end");
                    Writer.Write(config); 
                }
                else
                {
                    Console.WriteLine($"Your mode is: {mode}. If the writer will stop, he will write /end at the end");
                    Reader.Read(config);
                }
            }
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