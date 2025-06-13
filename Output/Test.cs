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
}
