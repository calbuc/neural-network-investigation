using System;

namespace Program
{
    class Matrix
    {
        public int rows;
        public int columns;
        double[,] data;
        static Random rnd = new Random();

        public Matrix(double[,] data)
        {
            rows = data.GetLength(0);
            columns = data.GetLength(1);
            this.data = data;
        }
        public Matrix(double[,] data, bool fill)
        {
            rows = data.GetLength(0);
            columns = data.GetLength(1);
            this.data = data;
            if (fill)
            {
                this.FillRandom();
            }
        }

        public void Print()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{this[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public double this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.rows != b.rows || a.columns != b.columns)
            {
                throw new MatrixNonConformableException("Addition");
            }
            double[,] result = new double[a.rows, a.columns];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return new Matrix(result);
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.rows != b.rows || a.columns != b.columns)
            {
                throw new MatrixNonConformableException("Subtraction");
            }
            double[,] result = new double[a.rows, a.columns];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return new Matrix(result);
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.columns != b.rows)
            {
                throw new MatrixNonConformableException("Multiplication");
            }
            double[,] result = new double[a.rows, b.columns];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    for (int k = 0; k < a.columns; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return new Matrix(result);
        }
        public static Matrix operator *(double a, Matrix b)
        {
            for (int i = 0; i < b.rows; i++)
            {
                for (int j = 0; j < b.columns; j++)
                {
                    b[i, j] = a * b[i, j];
                }
            }
            return b;
        }
        public static Matrix operator *(Matrix b, double a)
        {
            for (int i = 0; i < b.rows; i++)
            {
                for (int j = 0; j < b.columns; j++)
                {
                    b[i, j] = a * b[i, j];
                }
            }
            return b;
        }
        public static Matrix operator ~(Matrix a)
        {
            double[,] result = new double[a.columns, a.rows];
            for (int i = 0; i < result.GetLength(1); i++)
            {
                for (int j = 0; j < result.GetLength(0); j++)
                {
                    result[j, i] = a[i, j];
                }
            }
            return new Matrix(result);
        }

        public static double Det(Matrix a)
        {
            if (a.columns != a.rows)
            {
                throw new MatrixNonSquareException("Determinant");
            }
            if (a.rows == 1)
            {
                return a[0, 0];
            }
            else
            {
                double det = 0;
                for (int i = 0; i < a.rows; i++)
                {
                    double[,] b = new double[a.rows - 1, a.columns - 1];
                    int count = 0;
                    for (int j = 0; j < a.rows; j++)
                    {
                        if (i != j)
                        {
                            for (int k = 1; k < a.rows; k++)
                            {
                                b[count, k - 1] = a[j, k];
                            }
                            count++;
                        }
                    }
                    if (i % 2 == 1)
                    {
                        det += -a[i, 0] * Det(new Matrix(b));
                    }
                    else
                    {
                        det += +a[i, 0] * Det(new Matrix(b));

                    }
                }
                return det;
            }
        }

        public static Matrix Sigmoid(Matrix a)
        {
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                {
                    a[i, j] = 1 / (1 + Math.Exp(-a[i, j]));
                }
            }
            return a;
        }
        public static Matrix Tanh(Matrix a)
        {
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                {
                    a[i, j] = Math.Tanh(a[i, j]);
                }
            }
            return a;
        }
        public static Matrix ReLU(Matrix a)
        {
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                {
                    a[i, j] = Math.Max(0, a[i, j]);
                }
            }
            return a;
        }

        public void FillRandom()
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    this[i, j] = (2 * rnd.NextDouble()) - 1;
                }
            }
        }
    }
}
