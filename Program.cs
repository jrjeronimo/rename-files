Console.WriteLine("Root path to rename files and subfolders");
var rootPath = Console.ReadLine();

Console.WriteLine("Text to replace");
var textToReplace = Console.ReadLine();

Console.WriteLine("Replacement text");
var replacement = Console.ReadLine();

if (string.IsNullOrWhiteSpace(replacement)
    || string.IsNullOrWhiteSpace(rootPath)
    || string.IsNullOrWhiteSpace(textToReplace))
{
    Console.WriteLine("No files modified");
    Console.ReadKey();
    return;
}

var files = Directory.GetFiles(rootPath, $"*{textToReplace}*", SearchOption.AllDirectories);

foreach (var filePath in files)
{
    File.Move(filePath, filePath.Replace(textToReplace, replacement));
}
