namespace HighterMath
{
    public class MatrixElement
    {
        readonly int _intValue;
        readonly float _floatValue;
        readonly double _doubleValue;
        public double Value => _doubleValue + _floatValue + _intValue; // Since only one value is assigned
                                                                       // with the sum, we get it

        public MatrixElement(int intValue) => _intValue = intValue;
        public MatrixElement(float floatValue) => _floatValue = floatValue;
        public MatrixElement(double doubleValue) => _doubleValue = doubleValue;

        public static MatrixElement operator +(MatrixElement el1, MatrixElement el2)
            => new(el1.Value + el2.Value);
        public static MatrixElement operator -(MatrixElement el1, MatrixElement el2)
            => new(el1.Value - el2.Value);
        public static MatrixElement operator *(MatrixElement el1, MatrixElement el2)
            => new(el1.Value * el2.Value);
        public static MatrixElement operator /(MatrixElement el1, MatrixElement el2)
            => new(el1.Value / el2.Value);
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
