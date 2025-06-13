using MessagePack;

namespace UnitGenerator;

[MessagePackObject(true)]
public class OperatorInfo
{
    /// <summary>
    /// Param1UnitとParam2Unitを計算して得られる戻り値の単位。
    /// </summary>
    public string ReturnUnit { get; set; } = string.Empty;
    /// <summary>
    /// 演算子の文字列。例: "+", "-", "*", "/"
    /// </summary>
    public string Operator { get; set; } = string.Empty;
    public string Param1Unit { get; set; } = string.Empty;
    public string Param2Unit { get; set; } = string.Empty;
    public string Generate()
    {
        return $"    public static {ReturnUnit}<T> operator {Operator}({Param1Unit}<T> param1, {Param2Unit}<T> param2) => new(param1.Value {Operator} param2.Value);";
    }
}