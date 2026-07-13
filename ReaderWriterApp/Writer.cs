namespace ReaderWriterApp;

internal static class Writer
{
    public static void Write(Config config)
    {
        using StreamWriter writer = new StreamWriter(config.File!);
        
        while (true) 
        { 
            string? input = Console.ReadLine();
            if (input?.ToLower().Trim() == "/end")
            { 
                break;
            }

            if (input?.ToLower().Trim() == "/flush")
            {
                writer.Flush();
                continue;
            }
            
            writer.WriteLine(input);
            
            if (config.FlushMode == FlushMode.Auto) 
                    writer.Flush();
        }
    }
}