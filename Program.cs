

Console.WriteLine("Root path to rename files and subfolders");
var rootPath = Console.ReadLine();

Console.WriteLine("Text to replace as PascalCase");
var textToReplace = Console.ReadLine();

Console.WriteLine("Replacement text as PascalCase");
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

var replacementCamelCase = char.ToLowerInvariant(replacement[0]) + replacement[1..];
foreach (var filePath in files)
{
    string text = File.ReadAllText(filePath);
    text = text.Replace(textToReplace, replacement)
               .Replace(textToReplace, replacementCamelCase, StringComparison.InvariantCultureIgnoreCase);
    File.WriteAllText(filePath.Replace(textToReplace, replacement), text);
    File.Delete(filePath);
}
