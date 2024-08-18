using System;

namespace Program
{
    class MatrixNonConformableException : Exception
    {
        public MatrixNonConformableException(string operation) : base($"{operation} cannot be performed on these matricies")
        {

        }
    }
    class MatrixNonSquareException : Exception
    {
        public MatrixNonSquareException(string operation) : base($"{operation} cannot be performed on this matrix")
        {

        }
    }
}
