Namespace MATH_EXTENSIONS

    Namespace MathsExt

        Namespace LocationalSpace
            <ComClass(Matrix.ClassId, Matrix.InterfaceId, Matrix.EventsId)>
            Public Class Matrix
                Public Const ClassId As String = "2118B490-7103-401C-BAB3-38FF97BC1AC9"
                Public Const EventsId As String = "C11B4307-F15E-401A-AC6D-3CF8086FD6F1"
                Public Const InterfaceId As String = "811345F8-5113-4059-829B-B531310144B5"
                Public Vectors As New List(Of Vector)
                ''' <summary>
                ''' Adds two matrices and returns the result as a new matrix.
                ''' </summary>
                ''' <param name="matrix">The matrix to be added.</param>
                ''' <returns>A new matrix containing the result of the addition.</returns>
                Public Function Add(ByVal matrix As Matrix) As Matrix
                    If matrix Is Nothing Then
                        Throw New ArgumentNullException("Matrix cannot be null.")
                    End If

                    If matrix.GetRowCount() <> GetRowCount() OrElse matrix.GetColumnCount() <> GetColumnCount() Then
                        Throw New ArgumentException("Matrices must have the same dimensions for addition operation.")
                    End If

                    Dim result As New Matrix()

                    For i = 0 To Vectors.Count - 1
                        Dim newRow As New Vector()
                        For j = 0 To Vectors(i).Values.Count - 1
                            newRow.Values.Add(Vectors(i).Values(j) + matrix.Vectors(i).Values(j))
                        Next
                        result.AddRow(newRow)
                    Next

                    Return result
                End Function

                ''' <summary>
                ''' Adds a new row to the matrix.
                ''' </summary>
                ''' <param name="vector">The vector representing the new row.</param>
                Public Sub AddRow(ByVal vector As Vector)
                    If vector IsNot Nothing Then
                        Vectors.Add(vector)
                    End If
                End Sub

                Public Function ApplyMaskToMatrix(ByVal matrix As Matrix, ByVal mask As Matrix) As Matrix
                    If matrix Is Nothing OrElse mask Is Nothing Then
                        Throw New ArgumentNullException("Matrix and mask cannot be null.")
                    End If

                    If matrix.GetRowCount() <> mask.GetRowCount() OrElse matrix.GetColumnCount() <> mask.GetColumnCount() Then
                        Throw New ArgumentException("Matrix and mask must have the same dimensions.")
                    End If

                    Dim resultMatrix As New Matrix()

                    For i = 0 To matrix.GetRowCount() - 1
                        Dim newRow As New Vector()
                        For j = 0 To matrix.GetColumnCount() - 1
                            If mask.Vectors(i).Values(j) = 1 Then
                                newRow.Values.Add(matrix.Vectors(i).Values(j))
                            Else
                                newRow.Values.Add(0)
                            End If
                        Next
                        resultMatrix.AddRow(newRow)
                    Next

                    Return resultMatrix
                End Function
                Public Function ConcatenateMatricesHorizontally(ByVal matrix1 As Matrix, ByVal matrix2 As Matrix) As Matrix
                    If matrix1 Is Nothing OrElse matrix2 Is Nothing Then
                        Throw New ArgumentNullException("Matrices cannot be null.")
                    End If

                    If matrix1.GetRowCount() <> matrix2.GetRowCount() Then
                        Throw New ArgumentException("Matrices must have the same number of rows for horizontal concatenation.")
                    End If

                    Dim resultMatrix As New Matrix()

                    For i = 0 To matrix1.GetRowCount() - 1
                        Dim newRow As New Vector()
                        newRow.Values.AddRange(matrix1.Vectors(i).Values)
                        newRow.Values.AddRange(matrix2.Vectors(i).Values)
                        resultMatrix.AddRow(newRow)
                    Next

                    Return resultMatrix
                End Function

                Public Function ConcatenateMatricesVertically(ByVal matrix1 As Matrix, ByVal matrix2 As Matrix) As Matrix
                    If matrix1 Is Nothing OrElse matrix2 Is Nothing Then
                        Throw New ArgumentNullException("Matrices cannot be null.")
                    End If

                    If matrix1.GetColumnCount() <> matrix2.GetColumnCount() Then
                        Throw New ArgumentException("Matrices must have the same number of columns for vertical concatenation.")
                    End If

                    Dim resultMatrix As New Matrix()

                    For Each vector In matrix1.Vectors
                        Dim newRow As New Vector()
                        newRow.Values.AddRange(vector.Values)
                        resultMatrix.AddRow(newRow)
                    Next

                    For Each vector In matrix2.Vectors
                        Dim newRow As New Vector()
                        newRow.Values.AddRange(vector.Values)
                        resultMatrix.AddRow(newRow)
                    Next

                    Return resultMatrix
                End Function
                Public Sub Display()
                    For Each vector In Vectors
                        For Each value In vector.Values
                            Console.Write(value & " ")
                        Next
                        Console.WriteLine()
                    Next
                End Sub
                ''' <summary>
                ''' Returns the number of columns in the matrix.
                ''' </summary>
                ''' <returns>The number of columns in the matrix.</returns>
                Public Function GetColumnCount() As Integer
                    If Vectors.Count > 0 Then
                        Return Vectors(0).Values.Count
                    End If
                    Return 0
                End Function

                ''' <summary>
                ''' Returns the number of rows in the matrix.
                ''' </summary>
                ''' <returns>The number of rows in the matrix.</returns>
                Public Function GetRowCount() As Integer
                    Return Vectors.Count
                End Function
                ''' <summary>
                ''' Multiplies two matrices and returns the result as a new matrix.
                ''' </summary>
                ''' <param name="matrix">The matrix to be multiplied.</param>
                ''' <returns>A new matrix containing the result of the multiplication.</returns>
                Public Function Multiply(ByVal matrix As Matrix) As Matrix
                    If matrix Is Nothing Then
                        Throw New ArgumentNullException("Matrix cannot be null.")
                    End If

                    If GetColumnCount() <> matrix.GetRowCount() Then
                        Throw New ArgumentException("Number of columns in the first matrix must be equal to the number of rows in the second matrix for multiplication.")
                    End If

                    Dim result As New Matrix()

                    For i = 0 To GetRowCount() - 1
                        Dim newRow As New Vector()
                        For j = 0 To matrix.GetColumnCount() - 1
                            Dim dotProduct As Double = 0
                            For k = 0 To Vectors(i).Values.Count - 1
                                dotProduct += Vectors(i).Values(k) * matrix.Vectors(k).Values(j)
                            Next
                            newRow.Values.Add(dotProduct)
                        Next
                        result.AddRow(newRow)
                    Next

                    Return result
                End Function

                ''' <summary>
                ''' Returns a new matrix that is the transpose of the original matrix.
                ''' </summary>
                ''' <returns>A new matrix representing the transpose of the original matrix.</returns>
                Public Function Transpose() As Matrix
                    Dim result As New Matrix()

                    For i = 0 To GetColumnCount() - 1
                        Dim newRow As New Vector()
                        For j = 0 To GetRowCount() - 1
                            newRow.Values.Add(Vectors(j).Values(i))
                        Next
                        result.AddRow(newRow)
                    Next

                    Return result
                End Function

                ' You can add more methods for matrix operations such as determinant calculation, inverse, etc.

            End Class
        End Namespace

    End Namespace
End Namespace