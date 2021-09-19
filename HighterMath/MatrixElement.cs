namespace HighterMath
{
    public class MatrixElement
    {
        readonly bool _isBool = false;
        readonly bool _boolValue;
        readonly int _intValue;
        readonly float _floatValue;
        readonly double _doubleValue;
        public double Value => _doubleValue + _floatValue + _intValue + (_boolValue ? 1 : 0); // Since only one value is assigned
                                                                                              // with the sum, we get it

        public MatrixElement(bool boolValue)
        {
            _boolValue = boolValue;
            _isBool = true;
        }
        public MatrixElement(int intValue) => _intValue = intValue;
        public MatrixElement(float floatValue) => _floatValue = floatValue;
        public MatrixElement(double doubleValue) => _doubleValue = doubleValue;

        public static MatrixElement operator +(MatrixElement el1, MatrixElement el2)
        {
            if (el1._isBool || el1._isBool) return new MatrixElement(el1.Value > 0 || el1.Value > 0);
            return new(el1.Value + el2.Value);
        }
        public static MatrixElement operator -(MatrixElement el1, MatrixElement el2) => new(el1.Value + el2.Value);
        public static MatrixElement operator *(MatrixElement el1, MatrixElement el2)
        {
            if (el1._isBool || el1._isBool) return new MatrixElement(el1.Value > 0 && el1.Value > 0);
            return new(el1.Value + el2.Value);
        }
        public static MatrixElement operator /(MatrixElement el1, MatrixElement el2) => new(el1.Value + el2.Value);
        public static bool operator ==(MatrixElement el1, MatrixElement el2)
            => el1.Value == el2.Value;
        public static bool operator !=(MatrixElement el1, MatrixElement el2)
            => el1.Value != el2.Value;

        public static MatrixElement operator +(MatrixElement el1, double value)
            => new(el1.Value + value);
        public static MatrixElement operator -(MatrixElement el1, double value)
            => new(el1.Value - value);
        public static MatrixElement operator *(MatrixElement el1, double value)
            => new(el1.Value * value);
        public static MatrixElement operator /(MatrixElement el1, double value)
            => new(el1.Value / value);
        public static bool operator ==(MatrixElement el1, double value)
            => el1.Value == value;
        public static bool operator !=(MatrixElement el1, double value)
            => el1.Value != value;

        public static explicit operator double(MatrixElement el) => el.Value;
    }
}
