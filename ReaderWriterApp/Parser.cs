namespace ReaderWriterApp;

// Parses input line arguments and stores the results in the Config object.
static class Parser
{
    // Parses a single flag and its value (e.g. "--mode read").
    // Throws an exception if the flag is not recognized.
    private static void ParseFlag(string flag, string value, Config config)
    {
        switch (flag)
        {
            case "--mode":
                config.SetMode(value);
                break;
            case "--path":
                config.SetFile(value);
                break;
            case "--flushMode":
                config.SetFlushMode(value);
                break;
            default:
                throw new ArgumentException($"Invalid flag {flag}");
        }
    }
    
    // Parses the entire command line and updates the Config object.
    // Expects exactly two flag-value pairs:
    //   --mode <read|write> --path <file>
    // Throws an exception if the number of arguments is invalid. 
    public static void Parse(string line, Config config)
    {
        string[] args = line.Split(' ');

        switch (args.Length)
        {
            case 4:
            case 6:
                ParseFlag(args[0], args[1], config);
                ParseFlag(args[2], args[3], config);
                ParseFlag(args[4], args[5], config);
                break;
            default:
                throw new ArgumentException($"Invalid number of arguments {args.Length}");
        }
    }
}