using System.Text;
namespace UnitGenerator;

public class Program
{
    public static void Main(string[] args)
    {
        var files = Directory.GetFiles("D:/Develop/Projects/UnitGenerator/Input", "*.json");
        foreach (var file in files)
        {
            Blueprint? blueprint = Blueprint.Load(file);
            if (blueprint == null)
            {
                Console.WriteLine($"Blueprint could not be loaded from {file}.");
                continue;
            }
            var code = blueprint.Generate();
            var outputFileName = Path.Combine("D:/Develop/Projects/UnitGenerator/Output", $"{Path.GetFileNameWithoutExtension(file)}.cs");
            File.WriteAllText(outputFileName, code, Encoding.UTF8);
        }
    }
}
