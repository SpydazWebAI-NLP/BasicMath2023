Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Windows.Forms
Imports System.Xml.Serialization

Namespace MATH_EXTENSIONS

    Namespace MathsExt

        Namespace LocationalSpace

            <ComClass(Vector.ClassId, Vector.InterfaceId, Vector.EventsId)>
            Public Class Vector
                Public Const ClassId As String = "2828B490-7103-401C-BAB3-38FF97BC1AC9"
                Public Const EventsId As String = "CDBB4307-F15E-401A-AC6D-3CF8086FD6F1"
                Public Const InterfaceId As String = "8BB345F8-5113-4059-829B-B531310144B5"
                Public Values As New List(Of Double)
                Public Function ApplyMaskToVector(ByVal vector As Vector, ByVal mask As Vector) As Vector
                    If vector Is Nothing OrElse mask Is Nothing Then
                        Throw New ArgumentNullException("Vector and mask cannot be null.")
                    End If

                    If vector.Values.Count <> mask.Values.Count Then
                        Throw New ArgumentException("Vector and mask must have the same size.")
                    End If

                    Dim resultVector As New Vector()

                    For i = 0 To vector.Values.Count - 1
                        If mask.Values(i) = 1 Then
                            resultVector.Values.Add(vector.Values(i))
                        Else
                            resultVector.Values.Add(0)
                        End If
                    Next

                    Return resultVector
                End Function

                Public Sub Display()
                    For Each value In Values
                        Console.Write(value & " ")
                    Next
                    Console.WriteLine()
                End Sub

                Public Function ConcatenateVectors(ByVal vector1 As Vector, ByVal vector2 As Vector) As Vector
                    If vector1 Is Nothing OrElse vector2 Is Nothing Then
                        Throw New ArgumentNullException("Vectors cannot be null.")
                    End If

                    Dim resultVector As New Vector()
                    resultVector.Values.AddRange(vector1.Values)
                    resultVector.Values.AddRange(vector2.Values)

                    Return resultVector
                End Function

                ''' <summary>
                ''' Adds Two vectors together
                ''' </summary>
                ''' <param name="nVector"></param>
                ''' <returns></returns>
                Public Shared Function AddVectors(ByRef vect As Vector, ByRef nVector As Vector) As Vector
                    Dim Answer As New Vector

                    If nVector.Values.Count > vect.Values.Count Then

                        For i = 0 To vect.Values.Count
                            Answer.Values.Add(nVector.Values(i) + vect.Values(i))
                        Next
                        'Add Excess values
                        For i = vect.Values.Count To nVector.Values.Count
                            Answer.Values.Add(nVector.Values(i))
                        Next
                    Else
                        '
                        For i = 0 To nVector.Values.Count
                            Answer.Values.Add(nVector.Values(i) + vect.Values(i))
                        Next
                        'Add Excess values
                        For i = nVector.Values.Count To vect.Values.Count
                            Answer.Values.Add(nVector.Values(i))
                        Next
                    End If

                    Return Answer
                End Function

                ''' <summary>
                ''' Returns the dot product of two vectors.
                ''' </summary>
                ''' <param name="vect">The first vector.</param>
                ''' <param name="newVect">The second vector.</param>
                ''' <returns>The dot product of the input vectors.</returns>
                Public Shared Function CalculateDotProduct(ByVal vect As Vector, ByVal newVect As Vector) As Double
                    If vect Is Nothing Or newVect Is Nothing Then
                        Throw New ArgumentNullException("Vectors cannot be null.")
                    End If

                    If vect.Values.Count <> newVect.Values.Count Then
                        Throw New ArgumentException("Vectors must have the same size for dot product operation.")
                    End If

                    CalculateDotProduct = 0

                    For i = 0 To vect.Values.Count - 1
                        CalculateDotProduct += vect.Values(i) * newVect.Values(i)
                    Next

                    Return CalculateDotProduct
                End Function


                ''' <summary>
                ''' deserialize object from Json
                ''' </summary>
                ''' <param name="Str">json</param>
                ''' <returns></returns>
                Public Shared Function FromJson(ByRef Str As String) As Vector
                    Try
                        Dim Converter As New JavaScriptSerializer
                        Dim diag As Vector = Converter.Deserialize(Of Vector)(Str)
                        Return diag
                    Catch ex As Exception
                        Dim Buttons As MessageBoxButtons = MessageBoxButtons.OK
                        MessageBox.Show(ex.Message, "ERROR", Buttons)
                    End Try
                    Return Nothing
                End Function

                ''' <summary>
                ''' Multiplies two vectors; if vectors are not matching size, excess values will be 0.
                ''' </summary>
                ''' <param name="vect">The first vector.</param>
                ''' <param name="nVector">The second vector.</param>
                ''' <returns>A new vector containing the result of the multiplication.</returns>
                Public Shared Function MultiplyVectors(ByVal vect As Vector, ByVal nVector As Vector) As Vector
                    If vect Is Nothing Or nVector Is Nothing Then
                        Throw New ArgumentNullException("Vectors cannot be null.")
                    End If

                    Dim maxLength As Integer = Math.Max(vect.Values.Count, nVector.Values.Count)
                    Dim minLength As Integer = Math.Min(vect.Values.Count, nVector.Values.Count)

                    Dim answer As New Vector

                    For i = 0 To minLength - 1
                        answer.Values.Add(vect.Values(i) * nVector.Values(i))
                    Next

                    ' Add excess values for the longer vector
                    If vect.Values.Count > nVector.Values.Count Then
                        For i = minLength To maxLength - 1
                            answer.Values.Add(vect.Values(i) * 0)
                        Next
                    ElseIf vect.Values.Count < nVector.Values.Count Then
                        For i = minLength To maxLength - 1
                            answer.Values.Add(nVector.Values(i) * 0)
                        Next
                    End If

                    Return answer
                End Function


                ''' <summary>
                ''' Multiplies the vector by a scalar.
                ''' </summary>
                ''' <param name="vect">The vector to be multiplied.</param>
                ''' <param name="scalar">The scalar value.</param>
                ''' <returns>A new vector containing the result of the multiplication.</returns>
                Public Shared Function MultiplyVectorByScalar(ByVal vect As Vector, ByVal scalar As Integer) As Vector
                    If vect Is Nothing Then
                        Throw New ArgumentNullException("Vector cannot be null.")
                    End If

                    Dim answer As New Vector

                    For Each value As Double In vect.Values
                        answer.Values.Add(scalar * value)
                    Next

                    Return answer
                End Function


                ''' <summary>
                ''' Square each value of the vector.
                ''' </summary>
                ''' <param name="vect">The vector to be squared.</param>
                ''' <returns>A new vector containing squared values.</returns>
                Public Shared Function SquareEachValue(ByVal vect As Vector) As Vector
                    If vect Is Nothing Then
                        Throw New ArgumentNullException("Vector cannot be null.")
                    End If

                    Dim squaredValues As List(Of Double) = vect.Values.Select(Function(value) value * value).ToList()

                    Return New Vector With {.Values = squaredValues}
                End Function


                ''' <summary>
                ''' Returns the sum of squares of the values in the vector.
                ''' </summary>
                ''' <param name="vect">The vector whose sum of squares is to be calculated.</param>
                ''' <returns>The sum of squares of the vector values.</returns>
                Public Shared Function SumOfSquares(ByVal vect As Vector) As Double
                    If vect Is Nothing Then
                        Throw New ArgumentNullException("Vector cannot be null.")
                    End If

                    SumOfSquares = 0

                    For Each value As Double In vect.Values
                        sumOfSquares += value * value
                    Next

                    Return SumOfSquares
                End Function


                ''' <summary>
                ''' Subtracts one vector from another.
                ''' </summary>
                ''' <param name="vect">The vector from which to subtract.</param>
                ''' <param name="newVect">The vector to be subtracted.</param>
                ''' <returns>A new vector containing the result of the subtraction.</returns>
                Public Shared Function SubtractVectors(ByVal vect As Vector, ByVal newVect As Vector) As Vector
                    If vect Is Nothing Or newVect Is Nothing Then
                        Throw New ArgumentNullException("Vectors cannot be null.")
                    End If

                    If vect.Values.Count <> newVect.Values.Count Then
                        Throw New ArgumentException("Vectors must have the same size for subtraction operation.")
                    End If

                    Dim resultValues As List(Of Double) = vect.Values.Zip(newVect.Values, Function(v1, v2) v1 - v2).ToList()

                    Return New Vector With {.Values = resultValues}
                End Function


                ''' <summary>
                ''' Adds another vector to this vector.
                ''' </summary>
                ''' <param name="nVector">The vector to be added.</param>
                ''' <returns>A new vector containing the result of the addition.</returns>
                Public Function AddToVector(ByVal nVector As Vector) As Vector
                    If nVector Is Nothing Then
                        Throw New ArgumentNullException("Vector cannot be null.")
                    End If

                    Dim maxLength As Integer = Math.Max(Values.Count, nVector.Values.Count)
                    Dim minLength As Integer = Math.Min(Values.Count, nVector.Values.Count)

                    Dim answerValues As List(Of Double) = Values.Take(minLength).Zip(nVector.Values.Take(minLength), Function(v1, v2) v1 + v2).ToList()

                    If Values.Count > nVector.Values.Count Then
                        answerValues.AddRange(Values.Skip(minLength))
                    ElseIf Values.Count < nVector.Values.Count Then
                        answerValues.AddRange(nVector.Values.Skip(minLength))
                    End If

                    Return New Vector With {.Values = answerValues}
                End Function

                ''' <summary>
                ''' Returns the dot product of this vector with another vector.
                ''' </summary>
                ''' <param name="vect">The vector to calculate the dot product with.</param>
                ''' <returns>The dot product of the two vectors.</returns>
                Public Function CalculateDotProductWithVector(ByVal vect As Vector) As Double
                    If vect Is Nothing Then
                        Throw New ArgumentNullException("Vector cannot be null.")
                    End If

                    CalculateDotProductWithVector = 0

                    For i = 0 To Math.Min(Values.Count, vect.Values.Count) - 1
                        CalculateDotProductWithVector += Values(i) * vect.Values(i)
                    Next

                    Return CalculateDotProductWithVector
                End Function


                ''' <summary>
                ''' Multiplies this vector with another vector.
                ''' </summary>
                ''' <param name="nVector">The vector to be multiplied.</param>
                ''' <returns>A new vector containing the result of the multiplication.</returns>
                Public Function MultiplyWithVector(ByVal nVector As Vector) As Vector
                    If nVector Is Nothing Then
                        Throw New ArgumentNullException("Vector cannot be null.")
                    End If

                    Dim maxLength As Integer = Math.Max(Values.Count, nVector.Values.Count)
                    Dim minLength As Integer = Math.Min(Values.Count, nVector.Values.Count)

                    Dim answerValues As List(Of Double) = Values.Take(minLength).Zip(nVector.Values.Take(minLength), Function(v1, v2) v1 * v2).ToList()

                    If Values.Count > nVector.Values.Count Then
                        answerValues.AddRange(nVector.Values.Skip(minLength))
                    ElseIf Values.Count < nVector.Values.Count Then
                        answerValues.AddRange(Enumerable.Repeat(0.0, nVector.Values.Count - Values.Count))
                    End If

                    Return New Vector With {.Values = answerValues}
                End Function


                ''' <summary>
                ''' Multiplies this vector by a scalar.
                ''' </summary>
                ''' <param name="scalar">The scalar value.</param>
                ''' <returns>A new vector containing the result of the multiplication.</returns>
                Public Function MultiplyByScalar(ByVal scalar As Integer) As Vector
                    Dim answerValues As List(Of Double) = Values.Select(Function(value) scalar * value).ToList()
                    Return New Vector With {.Values = answerValues}
                End Function

                ''' <summary>
                ''' Sums all numbers in the vector.
                ''' </summary>
                ''' <returns>The sum of all values in the vector.</returns>
                Public Function CalculateScalarSum() As Double
                    Return Values.Sum()
                End Function


                ''' <summary>
                ''' Multiply each value in the vector together to produce a final value.
                ''' a * b * c * d ... = final value
                ''' </summary>
                ''' <returns>The result of multiplying all values in the vector together.</returns>
                Public Function CalculateScalarProduct() As Double
                    Dim total As Double = 1
                    For Each item In Values
                        total *= item
                    Next
                    Return total
                End Function


                ''' <summary>
                ''' Square each value in the vector.
                ''' </summary>
                ''' <returns>A new vector containing the squared values.</returns>
                Public Function SquareVector() As Vector
                    Dim squaredValues As List(Of Double) = Values.Select(Function(value) value * value).ToList()
                    Return New Vector With {.Values = squaredValues}
                End Function


                ''' <summary>
                ''' Returns the sum of squares of the values in the vector.
                ''' </summary>
                ''' <returns>The sum of squares of the vector values.</returns>
                Public Function CalculateSumOfSquares() As Double
                    Dim sumOfSquares As Double = 0

                    For Each value As Double In Values
                        sumOfSquares += value * value
                    Next

                    Return sumOfSquares
                End Function


                ''' <summary>
                ''' Subtracts the values of another vector from this vector.
                ''' </summary>
                ''' <param name="newVect">The vector to subtract.</param>
                Public Sub SubtractVector(ByVal newVect As Vector)
                    If newVect Is Nothing Then
                        Throw New ArgumentNullException("Vector cannot be null.")
                    End If

                    If Values.Count <> newVect.Values.Count Then
                        Throw New ArgumentException("Vectors must have the same size for subtraction operation.")
                    End If

                    For i = 0 To Values.Count - 1
                        Values(i) -= newVect.Values(i)
                    Next
                End Sub


                ''' <summary>
                ''' Sums all values in the vector.
                ''' </summary>
                ''' <returns>The sum of all values in the vector.</returns>
                Public Function CalculateSum() As Double
                    Return Values.Sum()
                End Function

                ''' <summary>
                ''' Serializes object to json
                ''' </summary>
                ''' <returns> </returns>
                Public Function ToJson() As String
                    Dim Converter As New JavaScriptSerializer
                    Return Converter.Serialize(Me)
                End Function

                ''' <summary>
                ''' Serializes Object to XML
                ''' </summary>
                ''' <param name="FileName"></param>
                Public Sub ToXML(ByRef FileName As String)
                    Dim serialWriter As StreamWriter
                    serialWriter = New StreamWriter(FileName)
                    Dim xmlWriter As New XmlSerializer(Me.GetType())
                    xmlWriter.Serialize(serialWriter, Me)
                    serialWriter.Close()
                End Sub

            End Class
            <ComClass(Matrix.ClassId, Matrix.InterfaceId, Matrix.EventsId)>
            Public Class Matrix
                Public Vectors As New List(Of Vector)
                Public Const ClassId As String = "2118B490-7103-401C-BAB3-38FF97BC1AC9"
                Public Const EventsId As String = "C11B4307-F15E-401A-AC6D-3CF8086FD6F1"
                Public Const InterfaceId As String = "811345F8-5113-4059-829B-B531310144B5"

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
                Public Sub Display()
                    For Each vector In Vectors
                        For Each value In vector.Values
                            Console.Write(value & " ")
                        Next
                        Console.WriteLine()
                    Next
                End Sub

                ''' <summary>
                ''' Adds a new row to the matrix.
                ''' </summary>
                ''' <param name="vector">The vector representing the new row.</param>
                Public Sub AddRow(ByVal vector As Vector)
                    If vector IsNot Nothing Then
                        Vectors.Add(vector)
                    End If
                End Sub

                ''' <summary>
                ''' Returns the number of rows in the matrix.
                ''' </summary>
                ''' <returns>The number of rows in the matrix.</returns>
                Public Function GetRowCount() As Integer
                    Return Vectors.Count
                End Function

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

                ''' <summary>
                ''' Adds a new matrix to the tensor.
                ''' </summary>
                ''' <param name="matrix">The matrix to be added.</param>
                Public Sub AddMatrix(ByVal matrix As Matrix)
                    If matrix IsNot Nothing Then
                        Matrices.Add(matrix)
                    End If
                End Sub

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
                ''' Returns the number of columns in the tensor.
                ''' </summary>
                ''' <returns>The number of columns in the tensor.</returns>
                Public Function GetColumnCount() As Integer
                    If Matrices.Count > 0 Then
                        Return Matrices(0).GetColumnCount()
                    End If
                    Return 0
                End Function


                Public Sub DisplayTensor()
                    For Each matrix In Matrices
                        matrix.Display()
                        Console.WriteLine("----")
                    Next
                End Sub

                ''' <summary>
                ''' Returns the number of dimensions in the tensor.
                ''' </summary>
                ''' <returns>The number of dimensions in the tensor.</returns>
                Public Function GetDimensionCount() As Integer
                    Return Matrices.Count
                End Function

                ' You can add more methods for tensor operations such as tensor addition,
                ' tensor multiplication, tensor transpose, etc.

            End Class

        End Namespace

    End Namespace
End Namespace