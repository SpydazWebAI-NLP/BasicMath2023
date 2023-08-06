Public Class Matrix(Of T)
    Inherits Tensor(Of T)

    Public Sub New(rows As Integer, columns As Integer)
        MyBase.New(rows, columns)
    End Sub
    Public Overloads Function Transpose() As Matrix(Of T)
        Dim result As New Matrix(Of T)(DataArray.GetLength(1), DataArray.GetLength(0))
        For i As Integer = 0 To DataArray.GetLength(0) - 1
            For j As Integer = 0 To DataArray.GetLength(1) - 1
                result.SetItem(j, i, DataArray(i, j))
            Next
        Next
        Return result
    End Function

    ' Function for Matrix Multiplication (dot product)
    Public Overloads Function Multiply(other As Matrix(Of T)) As Matrix(Of T)
        Dim rowsA As Integer = DataArray.GetLength(0)
        Dim columnsA As Integer = DataArray.GetLength(1)
        Dim rowsB As Integer = other.DataArray.GetLength(0)
        Dim columnsB As Integer = other.DataArray.GetLength(1)

        If columnsA <> rowsB Then
            Throw New ArgumentException("Invalid matrix sizes for multiplication.")
        End If

        Dim result As New Matrix(Of T)(rowsA, columnsB)
        For i As Integer = 0 To rowsA - 1
            For j As Integer = 0 To columnsB - 1
                Dim sum As INumeric(Of T) = CType(Convert.ChangeType(0, GetType(T)), T)
                For k As Integer = 0 To columnsA - 1
                    sum.Add(DataArray(i, k).Multiply(other.DataArray(k, j)))
                Next
                result.SetItem(i, j, sum)
            Next
        Next
        Return result
    End Function

    Public Function Determinant() As Double
        If DataArray.GetLength(0) <> DataArray.GetLength(1) Then
            Throw New InvalidOperationException("Determinant can only be calculated for square matrices.")
        End If

        ' Implement the determinant calculation here (e.g., using LU decomposition or other methods)
        ' For demonstration purposes, we'll use a simple method for a 2x2 matrix:
        If DataArray.GetLength(0) = 2 Then
            Return Convert.ToDouble(DataArray(0, 0)) * Convert.ToDouble(DataArray(1, 1)) -
                       Convert.ToDouble(DataArray(0, 1)) * Convert.ToDouble(DataArray(1, 0))
        End If

        Throw New NotImplementedException("Determinant calculation not implemented for larger matrices.")
    End Function
End Class
