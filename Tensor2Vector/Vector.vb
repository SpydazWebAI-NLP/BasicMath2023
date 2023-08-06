Public Class Vector(Of T)
    Inherits Tensor(Of T)

    Public Sub New(size As Integer)
        MyBase.New(1, size)
    End Sub
    Public Function Correlation(ByVal other As Vector(Of Double)) As Double
        Dim icorrelation As Double = 0
        Dim n As Integer = DataArray.GetLength(1)

        Dim sumX As Double = 0
        Dim sumY As Double = 0
        Dim sumX2 As Double = 0
        Dim sumY2 As Double = 0
        Dim sumXY As Double = 0

        For i As Integer = 0 To n - 1
            Dim x As Double = Convert.ToDouble(DataArray(0, i))
            Dim y As Double = Convert.ToDouble(other.DataArray(0, i))

            sumX += x
            sumY += y
            sumX2 += x * x
            sumY2 += y * y
            sumXY += x * y
        Next

        Dim numerator As Double = n * sumXY - sumX * sumY
        Dim denominator1 As Double = Math.Sqrt(n * sumX2 - sumX * sumX)
        Dim denominator2 As Double = Math.Sqrt(n * sumY2 - sumY * sumY)

        If denominator1 <> 0 AndAlso denominator2 <> 0 Then
            icorrelation = numerator / (denominator1 * denominator2)
        End If

        Return icorrelation
    End Function
    Public Function Norm() As Double
        Dim sumSquared As Double = 0
        For i As Integer = 0 To DataArray.GetLength(1) - 1
            Dim value As Double = Convert.ToDouble(DataArray(0, i))
            sumSquared += value * value
        Next
        Return Math.Sqrt(sumSquared)
    End Function
    ' Function to compute the dot product between two vectors
    Public Overloads Function DotProduct(other As Vector(Of T)) As T
        If DataArray.GetLength(1) <> other.DataArray.GetLength(1) Then
            Throw New ArgumentException("Vectors must have the same size for dot product.")
        End If

        Dim sum As INumeric(Of T) = CType(Convert.ChangeType(0, GetType(T)), T)
        For i As Integer = 0 To DataArray.GetLength(1) - 1
            sum.add(DataArray(0, i).Multiply(other.DataArray(0, i)))
        Next
        Return sum
    End Function

End Class
