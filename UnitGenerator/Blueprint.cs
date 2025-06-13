using MessagePack;
using System.Text;

namespace UnitGenerator;

/// <summary>
/// 設計図
/// </summary>
[MessagePackObject(true)]
public class Blueprint
{
    // public Type Type { get; set; } = Type.Unit;
    public string Summary { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Base { get; set; } = string.Empty;

    public Blueprint() { }
    public static Blueprint? Load(string path)
    {
        var json = File.ReadAllText(path);
        return Deserialize(json);
    }
    public static void Save(string path, Blueprint blueprint)
    {
        var json = Serialize(blueprint);
        File.WriteAllText(path, json, Encoding.UTF8);
    }
    public static Blueprint? Deserialize(string json)
    {
        var bytes = MessagePackSerializer.ConvertFromJson(json);
        return MessagePackSerializer.Deserialize<Blueprint>(bytes);
    }
    public static string Serialize(Blueprint blueprint)
    {
        var bytes = MessagePackSerializer.Serialize(blueprint);
        return MessagePackSerializer.ConvertToJson(bytes);
    }
    /// <summary>
    /// 現在の設定でソースコード生成する。
    /// </summary>
    /// <returns></returns>
    public string Generate()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.AppendLine($"using System.Numerics;");
        stringBuilder.AppendLine(@"namespace Ksnm.Units;");
        stringBuilder.AppendLine(@"/// <summary>");
        stringBuilder.AppendLine($"/// {Summary}");
        stringBuilder.AppendLine(@"/// </summary>");
        stringBuilder.AppendLine($"public class {Name}<T> : {Base}<T> where T : INumber<T>");
        stringBuilder.AppendLine($"{{");
        stringBuilder.AppendLine($"    #region コンストラクタ");
        stringBuilder.AppendLine($"    public {Name}() {{ }}");
        stringBuilder.AppendLine($"    public {Name}(T value) : base(value) {{ }}");
        stringBuilder.AppendLine($"    #endregion コンストラクタ");
        stringBuilder.AppendLine($"}}");

        return stringBuilder.ToString();
    }
}