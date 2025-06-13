using System.Numerics;
namespace Ksnm.Units;
/// <summary>
/// 電圧
/// </summary>
public class ElectricPotential<T> : Quantity<T> where T : INumber<T>
{
    #region コンストラクタ
    public ElectricPotential() { }
    public ElectricPotential(T value) : base(value) { }
    #endregion コンストラクタ
    #region 演算子
    public static Ampere<T> operator *(T value, Ampere<T> quantity) => new(value * quantity.Value);
    public static Ampere<T> operator *(Ampere<T> quantity, T value) => new(quantity.Value * value);
    public static Power<T> operator *(ElectricPotential<T> param1, ElectricCurrent<T> param2) => new(param1.Value * param2.Value);
    public static ElectricalResistance<T> operator /(ElectricPotential<T> param1, ElectricCurrent<T> param2) => new(param1.Value / param2.Value);
    public static ElectricCurrent<T> operator /(ElectricPotential<T> param1, ElectricalResistance<T> param2) => new(param1.Value / param2.Value);
    #endregion 演算子
}
