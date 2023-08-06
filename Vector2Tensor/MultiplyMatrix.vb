Module MultiplyMatrix
    Public Function MatrixMultiply(matrixA As Integer(,), matrixB As Integer(,))
        Dim numRowsA As Integer = matrixA.GetLength(0)
        Dim numColsA As Integer = matrixA.GetLength(1)
        Dim numRowsB As Integer = matrixB.GetLength(0)
        Dim numColsB As Integer = matrixB.GetLength(1)


        Dim resultMatrix(numRowsA - 1, numColsB - 1) As Integer

        For i As Integer = 0 To numRowsA - 1
            For j As Integer = 0 To numColsB - 1
                Dim sum As Integer = 0
                For k As Integer = 0 To numColsA - 1
                    sum += matrixA(i, k) * matrixB(k, j)
                Next
                resultMatrix(i, j) = sum
            Next
        Next
        Return resultMatrix
    End Function
    Public Sub PrintMatrix(matrixA As Integer(,))
        Dim numRowsA As Integer = matrixA.GetLength(0)
        Dim numColsA As Integer = matrixA.GetLength(1)
        ' Print the resulting matrix
        For i As Integer = 0 To numRowsA - 1
            For j As Integer = 0 To numColsA - 1
                Console.Write(matrixA(i, j) & " ")
            Next
            Console.WriteLine()
        Next
    End Sub
    Public Function MatrixMultiply(matrixA As List(Of List(Of Integer)), matrixB As List(Of List(Of Integer))) As List(Of List(Of Integer))
        Dim numRowsA As Integer = matrixA.Count
        Dim numColsA As Integer = matrixA(0).Count
        Dim numRowsB As Integer = matrixB.Count
        Dim numColsB As Integer = matrixB(0).Count

        Dim resultMatrix As New List(Of List(Of Integer))

        For i As Integer = 0 To numRowsA - 1
            Dim newRow As New List(Of Integer)
            For j As Integer = 0 To numColsB - 1
                Dim sum As Integer = 0
                For k As Integer = 0 To numColsA - 1
                    sum += matrixA(i)(k) * matrixB(k)(j)
                Next
                newRow.Add(sum)
            Next
            resultMatrix.Add(newRow)
        Next

        Return resultMatrix
    End Function
    Public Sub PrintMatrix(matrix As List(Of List(Of Integer)))
        For Each row As List(Of Integer) In matrix
            For Each element As Integer In row
                Console.Write(element & " ")
            Next
            Console.WriteLine()
        Next
    End Sub
    Public Function MatrixMultiply(matrixA As List(Of List(Of Double)), matrixB As List(Of List(Of Double))) As List(Of List(Of Double))
        Dim numRowsA As Integer = matrixA.Count
        Dim numColsA As Integer = matrixA(0).Count
        Dim numRowsB As Integer = matrixB.Count
        Dim numColsB As Integer = matrixB(0).Count

        Dim resultMatrix As New List(Of List(Of Double))

        For i As Integer = 0 To numRowsA - 1
            Dim newRow As New List(Of Double)
            For j As Integer = 0 To numColsB - 1
                Dim sum As Double = 0
                For k As Integer = 0 To numColsA - 1
                    sum += matrixA(i)(k) * matrixB(k)(j)
                Next
                newRow.Add(sum)
            Next
            resultMatrix.Add(newRow)
        Next

        Return resultMatrix
    End Function
    Public Sub PrintMatrix(matrix As List(Of List(Of Double)))
        For Each row As List(Of Double) In matrix
            For Each element As Double In row
                Console.Write(element & " ")
            Next
            Console.WriteLine()
        Next
    End Sub
End Module
