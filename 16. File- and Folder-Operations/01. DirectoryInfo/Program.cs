
// Creating an instance of DirectoryInfo, which does not mean that the folder actually exists, neither does it get created automatically
using System.Diagnostics;

DirectoryInfo folder = new(@"D:\Backup\Bananas");


// Getting the fully qualified path of a directory
string pathToFolder = folder.FullName;

Debug.WriteLine(pathToFolder + "\n");
//alternative:
Debug.WriteLine($"{folder}");


// Getting the name of a directory
string nameOfFolder = folder.Name;

Debug.WriteLine(nameOfFolder + "\n");


// Creating a folder
try
{
    folder.Create();
}
catch (Exception ex)
{
    Debug.WriteLine($"Could not create folder. Exception: {ex.Message}");
}


// Getting the attributes of a folder, if folder/file not exists -1
// if only "Directory" it has no other attributes
FileAttributes attributesOfFolder = folder.Attributes;

Debug.WriteLine(attributesOfFolder + "\n");


// Setting the attribute to hidden
attributesOfFolder = folder.Attributes |= FileAttributes.Hidden;

Debug.WriteLine(attributesOfFolder + "\n");


// Check if a folder is hidden
// bitwise AND Operation with the .Hidden enum value
if ((folder.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
{
    Debug.WriteLine($"The folder {folder.Name} is hidden.");
}


// Unhide a folder
folder.Attributes &= ~FileAttributes.Hidden;

if ((folder.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
{
    Debug.WriteLine($"The folder {folder.Name} is not hidden.");
}


// analogues for other attributs like ReadOnly, ...


// Check if a folder exists
string value = folder.Exists ? "does" : "does not";

Debug.WriteLine($"The folder {value} exist.");


// Delete a folder, if not empty, otherwise exception after 1 secs
try
{
    folder.Delete();
}
catch (Exception ex)
{
    Debug.WriteLine($"Could not delete folder {folder.FullName}. Folder is not empty: {ex.Message}");
}
// Check again if a folder exists
value = folder.Exists ? "does" : "does not";

Debug.WriteLine($"The folder {value} exist.");


// Delete a folder recursively, even if not empty!
// Be very careful with this, and implement user-interaction for safety
DirectoryInfo newFolder = new($@"D:\Backup2\Bananas2\Minions2");
newFolder.Create();

try
{
    newFolder.Parent.Delete(true);
}
catch (Exception ex)
{
    Debug.WriteLine($"Could not delete folder {folder.FullName}. Exception: {ex.Message}");
}

value = newFolder.Exists ? "does" : "does not";

Debug.WriteLine($"The folder {newFolder} exist.");


// Get the parent folder of the folder
folder.Create();

DirectoryInfo? parentFolder = folder.Parent;

Debug.WriteLine($"This is the parent folder of the folder: {parentFolder}.");


// Get the root part of the folder path
DirectoryInfo rootPart = folder.Root;

Debug.WriteLine($"This is the root part of the folder: {rootPart}.");


// Get / Set the creation time of the folder
DateTime creationTime = folder.CreationTime;

Debug.WriteLine($"The creation time of the folder is: {creationTime}.");

folder.CreationTime = new DateTime(1981, 02, 11);

creationTime = folder.CreationTime;

Debug.WriteLine($"The NEW creation time of the folder is: {creationTime}.");


// Get / Set the last access time of the folder
// accesstime only changes when there are really accesses happening to the folder
DateTime lastAccessTime = folder.LastAccessTime;

Debug.WriteLine($"The lastAccessTime of the folder is: {lastAccessTime}.");

folder.LastAccessTime = new DateTime(1981, 02, 11);

lastAccessTime = folder.LastAccessTime;

Debug.WriteLine($"The NEW lastAccessTime of the folder is: {lastAccessTime}.");


// analogous for LastWriteTime


// Get the array of subdirectories if present
DirectoryInfo newSubDirectory = new(@"D:\Backup\Bananas\Minions");
newSubDirectory.Create();

DirectoryInfo[] subDirectories = folder.GetDirectories();

foreach (DirectoryInfo subDirectory in subDirectories)
{
    Debug.WriteLine($"This is a subdirectory {subDirectory}.");
}


// Move a folder, do only with try-catch
// MoveTo needs the full path of the destination folder including its own name, not only its parents path
// Syntax variants to get the full destination path
string oldPath = $@"D:\{folder.Name}\{newSubDirectory.Name}";

string test1 = $@"D:\{folder.Parent.Name}\{newSubDirectory.Name}";
string test2 = $@"{folder.Parent.FullName}\{newSubDirectory.Name}";
string test3 = Path.Combine(folder.Parent.FullName, newSubDirectory.Name);
Debug.WriteLine(test1);
Debug.WriteLine(test2);
Debug.WriteLine(test3);
try
{
    newSubDirectory.MoveTo(test1);
    Debug.WriteLine($"Folder '{newSubDirectory.Name}' moved from '{oldPath}' to '{newSubDirectory.Parent.FullName}'");
}
catch (Exception ex)
{
    Debug.WriteLine($"Could not move folder {test1}: {ex.Message}");
}


// Get all subdirectories as enumerable
IEnumerable<DirectoryInfo> subdirectories = folder.Parent.EnumerateDirectories();

foreach (DirectoryInfo subDirectory in subdirectories)
{
    Debug.WriteLine($"This is the subdirectory {subDirectory.Name} of: {folder.Parent}");
}


// Refreshing the state of the folder objects information
folder.Refresh();


// Clean up after testing
Debug.WriteLine($"Do you want to delete all created folders recursivly? Y/n ?\n");
string deleteChoice = Console.ReadLine();

if (deleteChoice == "Y")
{
    try
    {
        folder.Parent.Delete(true);
        newFolder.Parent.Parent.Delete(true);
    }
    catch (Exception ex)
    {
        Debug.WriteLine($"Could not delete folder. Exception: {ex.Message}");
    }
}
else
{
    return;
}
