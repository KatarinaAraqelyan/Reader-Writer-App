namespace ReaderWriterApp
{
    internal static class Reader
    {
        public static void Read(Config config)
        {
            if (config.File == null)
            {
                Console.WriteLine("File is not found.");
                return;
            }
            using StreamReader reader = new StreamReader(config.File!);

            while (true)
            {
                if (config.File!.Position < config.File!.Length)
                {
                    config.File!.Seek(config.File!.Position, SeekOrigin.Begin);

                    string? line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);

                        if (line == "/end")
                        {
                            Console.WriteLine("Reader stopped.");
                            return;
                        }
                    }
                }

                Thread.Sleep(100);
            }
        }
    }
}