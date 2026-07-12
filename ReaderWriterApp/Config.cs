namespace ReaderWriterApp;

// Available values for the --mode flag
enum ExecutionMode
{
    Read = 0,
    Write = 1
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
    
    public void SetFile(string filePath)
    {
        Dispose();
        File = new FileStream(filePath, FileMode.OpenOrCreate);
    }

    public void Dispose()
    {
        File?.Dispose();
    }
}