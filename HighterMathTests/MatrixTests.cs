using Microsoft.VisualStudio.TestTools.UnitTesting;
using HighterMath;

namespace HighterMathTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void MatrixIdentificator()
        {
            Matrix matrix = new(3, 4, new int[,] { { 2, 3, 6, 7 }, { 5, 4, 9, 0 }, { 1, 10, 8, -1 } });
            int expectedValue = 9;

            Assert.AreEqual(expectedValue, matrix[1, 2]);
        }

        [TestMethod]
        public void MatrixEquality()
        {
            Matrix matrix1 = new(2, 3, new int[,] { { 2, 3, 6 }, { 5, 4, 9 } });
            Matrix matrix2 = new(2, 3, new int[,] { { 2, 3, 6 }, { 5, 4, 9 } });

            Assert.IsTrue(matrix1 == matrix2);
        }

        [TestMethod]
        public void MatrixInequality()
        {
            Matrix matrix1 = new(2, 3, new int[,] { { 2, 3, 6 }, { 5, 4, 9 } });
            Matrix matrix2 = new(2, 3, new int[,] { { 2, 3, 6 }, { 5, -4, 9 } });

            Assert.IsTrue(matrix1 != matrix2);
        }

        [TestMethod]
        public void MatrixSumm()
        {
            Matrix matrix1 = new(2, 3, new int[,] { { 2, 3, 6 }, { 5, 4, 9 } });
            Matrix matrix2 = new(2, 3, new int[,] { { -2, -3, -6 }, { -5, -4, -9 } });
            Matrix expected = new(2, 3, new int[2, 3]);

            Matrix sum = matrix1 + matrix2;

            Assert.IsTrue(sum == expected);
        }

        [TestMethod]
        public void MatrixDiff()
        {
            Matrix matrix1 = new(2, 3, new int[,] { { 2, 3, 6 }, { 5, 4, 9 } });
            Matrix matrix2 = new(2, 3, new int[,] { { -2, -3, -6 }, { -5, -4, -9 } });
            Matrix expected = new(2, 3, new int[,] { { 4, 6, 12 }, { 10, 8, 18 } });

            Matrix diff = matrix1 - matrix2;

            Assert.IsTrue(diff == expected);
        }

        [TestMethod]
        public void MatrixMult()
        {
            Matrix matrix1 = new(2, 3, new int[,] { { 2, 3, 6 }, { 5, 4, 9 } });
            Matrix matrix2 = new(3, 2, new int[,] { { 4, 3 }, { 6, 2 }, { 0, 1 } });
            Matrix expected = new(2, 2, new int[,] { { 26, 18 }, { 44, 32 } });

            Matrix mult = matrix1 * matrix2;

            if (mult != expected) mult.Show();
            Assert.IsTrue(mult == expected);
        }

        [TestMethod]
        public void EMatrix()
        {
            Matrix matrix = new(3, 3, new int[,] { { 2, 3, 6 }, { 5, 4, 9 }, { 1, 10, 8 } });
            Matrix expected = new(3, 3, new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });

            Assert.IsTrue(matrix.Identity == expected);
        }

        [TestMethod]
        public void TransposedMatrix()
        {
            Matrix matrix = new(2, 3, new int[,] { { 2, 3, 6 }, { 5, 4, 9 } });
            Matrix expected = new(3, 2, new int[,] { { 2, 5 }, { 3, 4 }, { 6, 9 } });

            Assert.IsTrue(matrix.Transposed == expected);
        }

        [TestMethod]
        public void MatrixElementSum()
        {
            Matrix matrix = new(2, 3, new int[,] { { 2, 3, 6 }, { 5, 4, 9 } });
            double expected = 2 + 3 + 6 + 5 + 4 + 9;

            Assert.IsTrue(matrix.GetSumOfElements() == expected);
        }
    }
}
