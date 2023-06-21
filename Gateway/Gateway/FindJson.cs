using System.IO;

namespace Gateway;

public class FindJson
{
    public static void FindJsonAll( ConfigurationManager configuration)
    {
        var rootPath = Directory.GetCurrentDirectory();
        var root = new DirectoryInfo(rootPath);
        var files = root.GetFiles();
        foreach (FileInfo file in files)
        {
            if (file.Extension.Replace(".", "") == "json" && file.FullName.Contains("ocelot"))
            {
                var fullName = file.FullName;
                configuration.AddJsonFile(fullName, false, true);
            }
        }
    }
}