namespace ReaderWriterApp
{
    // Handles reading and displaying file updates.
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
                // Checks if there is new content in the file.
                if (config.File!.Position < config.File!.Length)
                {
                    config.File!.Seek(config.File!.Position, SeekOrigin.Begin);

                    string? line;

                    // Reads and displays new lines.
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);

                        // Stops reading when the end command is found.
                        if (line == "/end")
                        {
                            Console.WriteLine("Reader stopped.");
                            return;
                        }
                    }
                }
                // Waits before checking for new file content again.
                Thread.Sleep(100);
            }
        }
    }
}