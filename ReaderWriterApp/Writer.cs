namespace ReaderWriterApp;

internal static class Writer
{
    public static void Write(Config config)
    {
        while (true)
        {
            using StreamWriter writer = new StreamWriter(config.File!, leaveOpen: true);
            while (true)
            {
                string? input = Console.ReadLine();
                Console.WriteLine(input?.ToLower());
    
                if (input?.ToLower() == "/end")
                {
                    break;
                }

                if (config.FlushMode == FlushMode.Auto)
                {
                    writer.Flush(); 
                }
            }
            break;
        }
    }
}