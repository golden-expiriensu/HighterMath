using System.Collections;
using System.Collections.Generic;

namespace HighterMath
{
    public class Matrix : IEnumerable<MatrixElement>
    {
        public Matrix(int lines, int colomns)
        {
            _elements = new MatrixElement[lines * colomns];
            _colomns = colomns;
            _lines = lines;
        }
        public Matrix(int lines, int colomns, int[,] values)
        {
            _elements = new MatrixElement[lines * colomns];
            _colomns = colomns;
            _lines = lines;
            InitializeMatrix(values);
        }
        public Matrix(int lines, int colomns, float[,] values)
        {
            _elements = new MatrixElement[lines * colomns];
            _colomns = colomns;
            _lines = lines;
            InitializeMatrix(values);
        }
        public Matrix(int lines, int colomns, double[,] values)
        {
            _elements = new MatrixElement[lines * colomns];
            _colomns = colomns;
            _lines = lines;
            InitializeMatrix(values);
        }


        public double this[int line, int colomn]
        {
            get => _elements[line * _colomns + colomn].Value;
            set => _elements[line * _colomns + colomn] = new MatrixElement(value);
        }


        public void InitializeMatrix(int[,] values)
        {
            for (int lin = 0; lin < _lines; lin++)
                for (int col = 0; col < _colomns; col++)
                    _elements[lin * _colomns + col] = new MatrixElement(values[lin, col]);
        }
        public void InitializeMatrix(float[,] values)
        {
            for (int i = 0; i < _elements.Count; i++)
                _elements[i] = new MatrixElement(values[_lines, _colomns]);
        }
        public void InitializeMatrix(double[,] values)
        {
            for (int i = 0; i < _elements.Count; i++)
                _elements[i] = new MatrixElement(values[_lines, _colomns]);
        }


        public IEnumerator<MatrixElement> GetEnumerator() => _elements.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _elements.GetEnumerator();


        public Matrix Transposed => GetTransposed();
        Matrix GetTransposed()
        {
            Matrix transposed = new(_colomns, _lines);

            for (int lin = 0; lin < _lines; lin++)
                for (int col = 0; col < _colomns; col++)
                    transposed[col, lin] = this[lin, col];

            return transposed;
        }
        public Matrix Identity => GetIdentityMatrix();
        Matrix GetIdentityMatrix()
        {
            if (!IsSquare)
                return null;

            Matrix e = new(_lines, _colomns);
            for (int lin = 0; lin < _lines; lin++)
                for (int col = 0; col < _colomns; col++)
                    e[lin, col] = lin == col ? 1 : 0;
            return e;
        }
        public bool IsSquare => _lines == _colomns;
        public double GetSumOfElements()
        {
            double sum = 0;
            foreach (double el in _elements)
                sum += el;
            return sum;
        }


        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if (m1._lines != m2._lines || m1._colomns != m2._colomns)
                return false;

            for (int i = 0; i < m1._elements.Count; i++)
                if (m1._elements[i] != m2._elements[i])
                    return false;

            return true;
        }
        public static bool operator !=(Matrix m1, Matrix m2)
        {
            if (m1._lines != m2._lines || m1._colomns != m2._colomns)
                return true;

            for (int i = 0; i < m1._elements.Count; i++)
                if (m1._elements[i] != m2._elements[i])
                    return true;

            return false;
        }
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1._lines != m2._lines || m1._colomns != m2._colomns)
                throw new System.IndexOutOfRangeException("Matrix dimentions do not match");

            Matrix mSum = new(m1._lines, m1._colomns);
            for (int lin = 0; lin < mSum._lines; lin++)
                for (int col = 0; col < mSum._colomns; col++)
                    mSum[lin, col] = m1[lin, col] + m2[lin, col];

            return mSum;
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1._lines != m2._lines || m1._colomns != m2._colomns)
                throw new System.IndexOutOfRangeException("Matrix dimentions do not match");

            Matrix mSum = new(m1._lines, m1._colomns);
            for (int lin = 0; lin < mSum._lines; lin++)
                for (int col = 0; col < mSum._colomns; col++)
                    mSum[lin, col] = m1[lin, col] - m2[lin, col];

            return mSum;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1._lines != m2._colomns || m1._colomns != m2._lines)
                throw new System.IndexOutOfRangeException("Matrix dimentions do not match");

            Matrix mult = new(m1._lines, m2._colomns);
            for (int lin = 0; lin < mult._lines; lin++)
                for (int col = 0; col < mult._colomns; col++)
                {
                    MatrixElement newME = new(0);
                    for (int firstFactorCol = 0; firstFactorCol < m1._colomns; firstFactorCol++)
                        newME += m1[lin, firstFactorCol] * m2[firstFactorCol, col];
                    mult[lin, col] = newME.Value;
                }

            return mult;
        }


        public void Show()
        {
            for (int lin = 0; lin < _lines; lin++)
            {
                for (int col = 0; col < _colomns; col++)
                    System.Console.Write(this[lin, col] + " ");
                System.Console.WriteLine();
            }
        }


        public override bool Equals(object obj)
        {
            if (obj is not Matrix)
                return false;
            return this == obj as Matrix;
        }
        public override int GetHashCode()
        {
            return (int)((GetSumOfElements() * _lines + _colomns) / (_lines - 0.1231));
        }



        IList<MatrixElement> _elements;
        readonly int _lines;
        readonly int _colomns;
    }
}
