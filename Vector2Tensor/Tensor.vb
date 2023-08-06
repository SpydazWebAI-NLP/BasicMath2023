Namespace MATH_EXTENSIONS

    Namespace MathsExt

        Namespace LocationalSpace
            <ComClass(Tensor.ClassId, Tensor.InterfaceId, Tensor.EventsId)>
            Public Class Tensor
                Public Const ClassId As String = "2338B490-7103-401C-BAB3-38FF97BC1AC9"
                Public Const EventsId As String = "C33B4307-F15E-401A-AC6D-3CF8086FD6F1"
                Public Const InterfaceId As String = "833345F8-5113-4059-829B-B531310144B5"

                Public Matrices As New List(Of Matrix)



                ''' <summary>
                ''' Adds two tensors and returns the result as a new tensor.
                ''' </summary>
                ''' <param name="tensor">The tensor to be added.</param>
                ''' <returns>A new tensor containing the result of the addition.</returns>
                Public Function Add(ByVal tensor As Tensor) As Tensor
                    If tensor Is Nothing Then
                        Throw New ArgumentNullException("Tensor cannot be null.")
                    End If

                    If GetDimensionCount() <> tensor.GetDimensionCount() Then
                        Throw New ArgumentException("Tensors must have the same number of dimensions for addition operation.")
                    End If

                    Dim result As New Tensor()

                    For i = 0 To GetDimensionCount() - 1
                        result.AddMatrix(Matrices(i).Add(tensor.Matrices(i)))
                    Next

                    Return result
                End Function

                ''' <summary>
                ''' Adds a new matrix to the tensor.
                ''' </summary>
                ''' <param name="matrix">The matrix to be added.</param>
                Public Sub AddMatrix(ByVal matrix As Matrix)
                    If matrix IsNot Nothing Then
                        Matrices.Add(matrix)
                    End If
                End Sub

                Public Sub DisplayTensor()
                    For Each matrix In Matrices
                        matrix.Display()
                        Console.WriteLine("----")
                    Next
                End Sub

                ''' <summary>
                ''' Returns the number of columns in the tensor.
                ''' </summary>
                ''' <returns>The number of columns in the tensor.</returns>
                Public Function GetColumnCount() As Integer
                    If Matrices.Count > 0 Then
                        Return Matrices(0).GetColumnCount()
                    End If
                    Return 0
                End Function

                ''' <summary>
                ''' Returns the number of dimensions in the tensor.
                ''' </summary>
                ''' <returns>The number of dimensions in the tensor.</returns>
                Public Function GetDimensionCount() As Integer
                    Return Matrices.Count
                End Function

                ''' <summary>
                ''' Returns the number of matrices in the tensor.
                ''' </summary>
                ''' <returns>The number of matrices in the tensor.</returns>
                Public Function GetMatrixCount() As Integer
                    Return Matrices.Count
                End Function

                ''' <summary>
                ''' Returns the number of rows in the tensor.
                ''' </summary>
                ''' <returns>The number of rows in the tensor.</returns>
                Public Function GetRowCount() As Integer
                    If Matrices.Count > 0 Then
                        Return Matrices(0).GetRowCount()
                    End If
                    Return 0
                End Function

                ''' <summary>
                ''' Multiplies two tensors and returns the result as a new tensor.
                ''' </summary>
                ''' <param name="tensor">The tensor to be multiplied.</param>
                ''' <returns>A new tensor containing the result of the multiplication.</returns>
                Public Function Multiply(ByVal tensor As Tensor) As Tensor
                    If tensor Is Nothing Then
                        Throw New ArgumentNullException("Tensor cannot be null.")
                    End If

                    ' Perform tensor multiplication based on the operation rules.
                    ' For example, for element-wise multiplication, you need to
                    ' multiply corresponding elements in each matrix.

                    ' This is just a placeholder. You need to implement the actual
                    ' tensor multiplication logic based on your specific use case.

                    ' Return a new tensor representing the result of multiplication.
                    Dim result As New Tensor()

                    For i = 0 To GetDimensionCount() - 1
                        result.AddMatrix(Matrices(i).Multiply(tensor.Matrices(i)))
                    Next

                    Return result
                End Function
                ' You can add more methods for tensor operations such as tensor addition,
                ' tensor multiplication, tensor transpose, etc.

            End Class
        End Namespace

    End Namespace
End Namespace