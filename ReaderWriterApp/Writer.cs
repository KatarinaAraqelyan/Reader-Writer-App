namespace ReaderWriterApp;

// Handles writing user input.
internal static class Writer
{
    public static void Write(Config config)
    {
        using StreamWriter writer = new StreamWriter(config.File!);
        
        while (true) 
        { 
            string? input = Console.ReadLine();
            
            // Manually writes buffered data to the file.
            if (input?.ToLower().Trim() == "/flush")
            {
                writer.Flush();
                continue;
            }
            
            writer.WriteLine(input);
            
            // Stops writing when the end command is entered.
            if (input?.ToLower().Trim() == "/end")
            { 
                break;
            }
            // Automatically flushes data after each write.
            if (config.FlushMode == FlushMode.Auto) 
                    writer.Flush();
        }
    }
}