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
                        SumOfSquares += value * value
                    Next

                    Return SumOfSquares
                End Function

                Public Function AddScaler(ByVal newVect As Vector, ByRef Scaler As Integer) As Vector
                    If newVect Is Nothing Then
                        Throw New ArgumentNullException("Vector cannot be null.")
                    End If
                    For Each item In newVect.Values
                        item = item + Scaler
                    Next
                    Return newVect
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
                ''' Sums all numbers in the vector.
                ''' </summary>
                ''' <returns>The sum of all values in the vector.</returns>
                Public Function CalculateScalarSum() As Double
                    Return Values.Sum()
                End Function

                ''' <summary>
                ''' Sums all values in the vector.
                ''' </summary>
                ''' <returns>The sum of all values in the vector.</returns>
                Public Function CalculateSum() As Double
                    Return Values.Sum()
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

                Public Function ConcatenateVectors(ByVal vector1 As Vector, ByVal vector2 As Vector) As Vector
                    If vector1 Is Nothing OrElse vector2 Is Nothing Then
                        Throw New ArgumentNullException("Vectors cannot be null.")
                    End If

                    Dim resultVector As New Vector()
                    resultVector.Values.AddRange(vector1.Values)
                    resultVector.Values.AddRange(vector2.Values)

                    Return resultVector
                End Function

                Public Sub Display()
                    For Each value In Values
                        Console.Write(value & " ")
                    Next
                    Console.WriteLine()
                End Sub

                Public Function DivideScaler(ByVal newVect As Vector, ByRef Scaler As Integer) As Vector
                    If newVect Is Nothing Then
                        Throw New ArgumentNullException("Vector cannot be null.")
                    End If
                    For Each item In newVect.Values
                        item = item / Scaler
                    Next
                    Return newVect
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

                Public Function MultiplyScaler(ByVal newVect As Vector, ByRef Scaler As Integer)
                    If newVect Is Nothing Then
                        Throw New ArgumentNullException("Vector cannot be null.")
                    End If
                    For Each item In newVect.Values
                        item = item * Scaler
                    Next
                    Return newVect
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
                ''' Square each value in the vector.
                ''' </summary>
                ''' <returns>A new vector containing the squared values.</returns>
                Public Function SquareVector() As Vector
                    Dim squaredValues As List(Of Double) = Values.Select(Function(value) value * value).ToList()
                    Return New Vector With {.Values = squaredValues}
                End Function

                Public Function SubtractScaler(ByVal newVect As Vector, ByRef Scaler As Integer) As Vector
                    If newVect Is Nothing Then
                        Throw New ArgumentNullException("Vector cannot be null.")
                    End If
                    For Each item In newVect.Values
                        item = item - Scaler
                    Next
                    Return newVect
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
        End Namespace

    End Namespace
End Namespace