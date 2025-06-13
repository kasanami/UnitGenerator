using System.Numerics;
namespace Ksnm.Units;
/// <summary>
/// 電気抵抗
/// </summary>
public class ElectricalResistance<T> : Quantity<T> where T : INumber<T>
{
    #region コンストラクタ
    public ElectricalResistance() { }
    public ElectricalResistance(T value) : base(value) { }
    #endregion コンストラクタ
    #region 演算子
    public static Ampere<T> operator *(T value, Ampere<T> quantity) => new(value * quantity.Value);
    public static Ampere<T> operator *(Ampere<T> quantity, T value) => new(quantity.Value * value);
    public static ElectricPotential<T> operator *(ElectricalResistance<T> param1, ElectricCurrent<T> param2) => new(param1.Value * param2.Value);
    #endregion 演算子
}
