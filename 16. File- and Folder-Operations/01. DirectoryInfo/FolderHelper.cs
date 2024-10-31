public static class FolderHelper
{
    // For actions that return a value
    public static T TryExecute<T>(Func<T> func)
    {
        try
        {
            return func();
        }
        catch (IOException ex)
        {
            // Handle IO-specific exceptions here
            Console.WriteLine($"IOException occurred: {ex.Message}");
            return default;
        }
        catch (Exception ex)
        {
            // Handle general exceptions if necessary
            Console.WriteLine($"Exception occurred: {ex.Message}");
            return default;
        }
    }

    // For actions that do not return a value
    public static void TryExecute(Action action)
    {
        try
        {
            action();
        }
        catch (IOException ex)
        {
            // Handle IO-specific exceptions here
            Console.WriteLine($"IOException occurred: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle general exceptions if necessary
            Console.WriteLine($"Exception occurred: {ex.Message}");
        }
    }
}