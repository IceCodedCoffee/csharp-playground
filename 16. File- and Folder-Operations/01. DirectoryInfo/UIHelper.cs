public static class UIHelper
{
    public static void UserConfirmFolderDeletion(DirectoryInfo folder)
    {
        Console.WriteLine($"Do you want to delete the test folder? Y/n ?\n");
        string deleteChoice = Console.ReadLine();

        if (deleteChoice == "Y")
        {
            FolderHelper.TryExecute(() => folder.Delete());
        }
    }
}

