namespace ReaderWriterApp;

// Available values for the --mode flag
enum ExecutionMode
{
    Read,
    Write
}

// Available values for the --flushMode flag
enum FlushMode
{
    Auto,
    Manual
}

// Stores the application's configuration.
// variable File: the file opened or created using the value of the --path flag.
// variable Mode: the value specified by the --mode flag.
//
// Implements IDisposable to ensure the FileStream is properly closed,
// even if an exception occurs.
class Config: IDisposable
{
    public FileStream? File { get; private set; }
    public ExecutionMode Mode { get; private set; }
    public FlushMode FlushMode { get; private set; }
    
    // Sets execution mode from input value.
    public void SetMode(string mode)
    {
        switch (mode)
        {
            case "read":
                Mode = ExecutionMode.Read;
                break;
            case "write":
                Mode = ExecutionMode.Write;
                break;
            default:
                throw new ArgumentException($"Invalid mode {mode}");
        }
    }
    
    // Opens or creates a file.
    public void SetFile(string filePath)
    {
        Dispose();
        File = new FileStream(filePath, FileMode.OpenOrCreate);
    }
    
    // Sets flush mode from input value.
    public void SetFlushMode(string mode)
    {
        switch (mode)
        {
            case "auto":
                FlushMode = FlushMode.Auto;
                break;
            case "manual":
                FlushMode = FlushMode.Manual;
                break;
            default:
                throw new ArgumentException($"Invalid mode {mode}");
        }
    }
    
    // Closes the file stream.
    public void Dispose()
    {
        File?.Dispose();
    }
}