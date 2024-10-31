
// BaseFunctionalities();

TestIOHelper();


void BaseFunctionalities()
{
    // Creating an instance of DirectoryInfo,
    // which does not mean that the folder actually exists,
    // neither does it get created automatically
    DirectoryInfo folder = new(@"D:\Backup\Bananas");
    DirectoryInfo folder2 = new(@"D:\Minions");

    Console.WriteLine("---");
    Console.WriteLine($"The fully qualified name of the folder: {folder.FullName}");
    Console.WriteLine($"The fully qualified name of the folder: {folder}");
    Console.WriteLine($"The name of just the folder: {folder.Name}");
    Console.WriteLine($"The name of the parent folder of the folder: {folder.Parent}");
    Console.WriteLine($"The name of the root of the folder: {folder.Root}");

    Console.WriteLine("---");
    Console.WriteLine($"Checks if the folder actually exist: {folder.Exists}");
    // Actually creating the folder
    try
    {
        folder.Create();
        folder2.Create();
        Console.WriteLine($"Folder {folder} created!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Could not create folder. Exception: {ex.Message}");
    }
    // Refresh the information about the folder
    folder.Refresh();
    Console.WriteLine($"Checks if the folder actually exist: {folder.Exists}");

    Console.WriteLine("---");
    Console.WriteLine($"The creation time of the folder: {folder.CreationTime}.");
    folder.CreationTime = new DateTime(1981, 02, 11);
    Console.WriteLine($"The changed creation time of the folder: {folder.CreationTime}.");
    Console.WriteLine($"The lastAccessTime of the folder: {folder.LastAccessTime}.");
    folder.LastAccessTime = new DateTime(1981, 02, 11);
    Console.WriteLine($"The changed lastAccessTime of the folder: {folder.LastAccessTime}.");
    // analog for LastWriteTime

    Console.WriteLine("---");
    Console.WriteLine($"The folders attributes: {folder.Attributes}");
    // bitwise OR Operation with the .Hidden enum value
    Console.WriteLine($"Setting the folder attribute to hidden: {folder.Attributes |= FileAttributes.Hidden}");
    Console.WriteLine($"The folder attributes: {folder.Attributes}");
    // bitwise AND Operation with the .Hidden enum value
    Console.WriteLine($"Checks if the folder is hidden: {(folder.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden}");
    Console.WriteLine($"Unhides the folder: {folder.Attributes &= ~FileAttributes.Hidden}");
    Console.WriteLine($"Checks if the folder is hidden: {(folder.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden}");
    // analog for other attributs like ReadOnly, ...

    Console.WriteLine("---");
    foreach (DirectoryInfo subDirectory in folder.Parent.GetDirectories())
    {
        Console.WriteLine($"This is a folder from the ARRAY of subdirectories {subDirectory}.");
    }
    foreach (DirectoryInfo subDirectory in folder.Parent.EnumerateDirectories())
    {
        Console.WriteLine($"This is a folder is from the ENUMERATION of subdirectories {subDirectory}.");
    }

    Console.WriteLine("---");
    // Move a folder
    // MoveTo needs the full path of the destination folder including its own name, not only its parents path
    // Syntax variants to get the full destination path
    string syntaxVariant1 = $@"D:\{folder2.Name}\{folder.Name}";
    string syntaxVariant2 = $@"{folder2.FullName}\{folder.Name}";
    string syntaxVariant3 = Path.Combine(folder2.Parent.FullName, folder.Name);
    Console.WriteLine(syntaxVariant1);
    Console.WriteLine(syntaxVariant2);
    Console.WriteLine(syntaxVariant3);
    try
    {
        folder.MoveTo(syntaxVariant1);
        Console.WriteLine($@"Moved folder \{folder.Name} to {folder2}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Could not move folder {folder}: {ex.Message}");
    }

    Console.WriteLine("---");
    // Delete a folder, if not empty, otherwise exception after 1 secs
    try
    {
        //folder.Delete();
        //Console.WriteLine($@"Folder: \{folder.Name} deleted!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Could not delete folder {folder}. Folder is not empty: {ex.Message}");
    }
    Console.WriteLine($"Checks if the folder actually exist: {folder.Exists}");

    Console.WriteLine("---");
    Console.WriteLine($"Do you want to delete all created folders? Y/n ?\n");
    string deleteChoice = Console.ReadLine();

    if (deleteChoice == "Y")
    {
        try
        {
            folder.Parent.Delete();
            folder2.Delete();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not delete folder(s). Exception: {ex.Message}");
        }
    }

    // Delete a folder recursively, even if not empty!
    // Be very careful with this and implement user-interaction for safety
    /*
    try
    {
        // folder.Delete(true);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Could not delete folder { folder }. Exception: { ex.Message }");
    }
    Console.WriteLine($"Checks if the folder actually exist: {folder.Exists}");
    */
}

void TestIOHelper()
{
    // Testing the IOHelper class
    DirectoryInfo testDirectory = new($@"D:\Test");
    FolderHelper.TryExecute(() => testDirectory.Create());

    IEnumerable<DirectoryInfo> testABC = FolderHelper.TryExecute<IEnumerable<DirectoryInfo>>(() => testDirectory.GetDirectories());

    UIHelper.UserConfirmFolderDeletion(testDirectory);
}
