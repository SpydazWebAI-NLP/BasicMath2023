Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Public Class Tensor(Of T)
    Private data As INumeric(Of T)(,)

    Public Sub New(rows As Integer, columns As Integer)
        data = New T(rows, columns) {}
    End Sub

    Public Function GetItem(row As Integer, column As Integer) As T
        Return data(row, column)
    End Function

    Public Sub SetItem(row As Integer, column As Integer, value As T)
        Dim dynamicValue As Object = Convert.ChangeType(value, GetType(Object))
        data(row, column) = CType(dynamicValue, T)
    End Sub

    ' Element-wise math operations

    Public Function Add(other As Tensor(Of T)) As Tensor(Of T)
        Dim result As New Tensor(Of T)(data.GetLength(0), data.GetLength(1))
        For i As Integer = 0 To data.GetLength(0) - 1
            For j As Integer = 0 To data.GetLength(1) - 1
                ' Perform element-wise addition
                Dim value As Double = Convert.ToDouble(data(i, j))
                Dim otherValue As Double = Convert.ToDouble(other.GetItem(i, j))
                result.SetItem(i, j, CType(Convert.ChangeType(value + otherValue, GetType(T)), T))
            Next
        Next
        Return result
    End Function

    Public Function Subtract(other As Tensor(Of T)) As Tensor(Of T)
        Dim result As New Tensor(Of T)(data.GetLength(0), data.GetLength(1))
        For i As Integer = 0 To data.GetLength(0) - 1


            For j As Integer = 0 To data.GetLength(1) - 1
                ' Perform element-wise addition
                Dim value As Double = Convert.ToDouble(data(i, j))
                Dim otherValue As Double = Convert.ToDouble(other.GetItem(i, j))
                result.SetItem(i, j, CType(Convert.ChangeType(value - otherValue, GetType(T)), T))
            Next
        Next
        Return result
    End Function
    ' Element-wise math operations continued
    Public Function Multiply(other As Tensor(Of T)) As Tensor(Of T)
        Dim result As New Tensor(Of T)(data.GetLength(0), data.GetLength(1))
        For i As Integer = 0 To data.GetLength(0) - 1
            For j As Integer = 0 To data.GetLength(1) - 1
                ' Perform element-wise addition
                Dim value As Double = Convert.ToDouble(data(i, j))
                Dim otherValue As Double = Convert.ToDouble(other.GetItem(i, j))
                result.SetItem(i, j, CType(Convert.ChangeType(value * otherValue, GetType(T)), T))
            Next
        Next
        Return result
    End Function

    Public Function Divide(other As Tensor(Of T)) As Tensor(Of T)
        Dim result As New Tensor(Of T)(data.GetLength(0), data.GetLength(1))
        For i As Integer = 0 To data.GetLength(0) - 1
            For j As Integer = 0 To data.GetLength(1) - 1
                ' Perform element-wise addition
                Dim value As Double = Convert.ToDouble(data(i, j))
                Dim otherValue As Double = Convert.ToDouble(other.GetItem(i, j))
                result.SetItem(i, j, CType(Convert.ChangeType(value / otherValue, GetType(T)), T))
            Next
        Next
        Return result
    End Function




    ' Transfer functions
    Public Function Sigmoid() As Tensor(Of T)
        Dim result As New Tensor(Of T)(data.GetLength(0), data.GetLength(1))
        For i As Integer = 0 To data.GetLength(0) - 1
            For j As Integer = 0 To data.GetLength(1) - 1
                ' Perform sigmoid transfer function
                ' Replace this with the appropriate sigmoid implementation for the specific type T
                result.SetItem(i, j, SigmoidFunction(data(i, j)))
            Next
        Next
        Return result
    End Function
    ' Define the sigmoid function for the specific type T
    Private Function SigmoidFunction(value As T) As T
        ' Implement the sigmoid function here based on the specific type T
        ' For example, for Double:
        ' Return 1 / (1 + Math.Exp(-value))
    End Function
    ' More transfer functions
    Public Function ReLU() As Tensor(Of T)
        Dim result As New Tensor(Of T)(data.GetLength(0), data.GetLength(1))
        For i As Integer = 0 To data.GetLength(0) - 1
            For j As Integer = 0 To data.GetLength(1) - 1
                ' Perform ReLU transfer function
                ' Replace this with the appropriate ReLU implementation for the specific type T
                result.SetItem(i, j, ReLUFunction(data(i, j)))
            Next
        Next
        Return result
    End Function

    ' Mask function continued
    Public Function ApplyMaskWithReplacement(mask As Tensor(Of Boolean), replacement As T) As Tensor(Of T)
        Dim result As New Tensor(Of T)(data.GetLength(0), data.GetLength(1))
        For i As Integer = 0 To data.GetLength(0) - 1
            For j As Integer = 0 To data.GetLength(1) - 1
                If mask.GetItem(i, j) Then
                    ' Apply mask, replace the value with the provided replacement
                    result.SetItem(i, j, replacement)
                Else
                    result.SetItem(i, j, data(i, j))
                End If
            Next
        Next
        Return result
    End Function

    ' Define the ReLU function for the specific type T
    Private Function ReLUFunction(value As T) As T
        ' Implement the ReLU function here based on the specific type T
        ' For example, for Double:
        'Return Math.Max(0, value)
    End Function
    ' Masking functions
    Public Sub ApplyMask(mask As Tensor(Of Boolean))
        For i As Integer = 0 To data.GetLength(0) - 1
            For j As Integer = 0 To data.GetLength(1) - 1
                If Not mask.GetItem(i, j) Then
                    ' Apply mask, replace the value with the default value for the type T
                    data(i, j) = Nothing ' Replace this with the appropriate default value for type T
                End If
            Next
        Next
    End Sub

    ' Transpose function
    Public Function Transpose() As Tensor(Of T)
        Dim result As New Tensor(Of T)(data.GetLength(1), data.GetLength(0))
        For i As Integer = 0 To data.GetLength(0) - 1
            For j As Integer = 0 To data.GetLength(1) - 1
                result.SetItem(j, i, data(i, j))
            Next
        Next
        Return result
    End Function

    ' Rotate 90 degrees function
    Public Function Rotate90Degrees() As Tensor(Of T)
        Dim result As New Tensor(Of T)(data.GetLength(1), data.GetLength(0))
        For i As Integer = 0 To data.GetLength(0) - 1
            For j As Integer = 0 To data.GetLength(1) - 1
                result.SetItem(data.GetLength(1) - 1 - j, i, data(i, j))
            Next
        Next
        Return result
    End Function

    ' Mask function continued
    Public Function ApplyMaskWithZero(mask As Tensor(Of Boolean)) As Tensor(Of T)
        Dim result As New Tensor(Of T)(data.GetLength(0), data.GetLength(1))
        For i As Integer = 0 To data.GetLength(0) - 1
            For j As Integer = 0 To data.GetLength(1) - 1
                If mask.GetItem(i, j) Then
                    ' Apply mask, set the value to zero
                    ' For numerical types (e.g., Integer, Double), you can set it to zero
                    ' For other types, you might need to use the default value or handle differently
                    result.SetItem(i, j, CType(Convert.ChangeType(0, GetType(T)), T))
                Else
                    result.SetItem(i, j, data(i, j))
                End If
            Next
        Next
        Return result
    End Function

    ' Function to display the tensor's content
    Public Sub Print()
        For i As Integer = 0 To data.GetLength(0) - 1
            For j As Integer = 0 To data.GetLength(1) - 1
                Console.Write(data(i, j))
            Next
            Console.WriteLine()
        Next
    End Sub
    Public ReadOnly Property DataArray() As INumeric(Of T)(,)
        Get
            Return data
        End Get
    End Property

    Public Function ToStringRepresentation() As String
        Dim rows As Integer = data.GetLength(0)
        Dim columns As Integer = data.GetLength(1)
        Dim stringBuilder As New StringBuilder()

        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To columns - 1
                stringBuilder.Append(data(i, j).ToString()).Append(" ")
            Next
            stringBuilder.AppendLine()
        Next

        Return stringBuilder.ToString()
    End Function
    Private Sub DisplayTensorInDataGridView(tensor As Tensor(Of Double))
        Dim rows As Integer = tensor.DataArray.GetLength(0)
        Dim columns As Integer = tensor.DataArray.GetLength(1)

        Dim dataGridView As New DataGridView()
        dataGridView.RowCount = rows
        dataGridView.ColumnCount = columns

        ' Set the data from the tensor to the DataGridView
        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To columns - 1
                dataGridView.Rows(i).Cells(j).Value = tensor.DataArray(i, j)
            Next
        Next

        ' Add DataGridView to the Form
        Dim form As New Form()
        form.Text = "Tensor Display"
        form.Controls.Add(dataGridView)
        form.ShowDialog()
    End Sub


    Public Function DotProduct(other As Tensor(Of T)) As Tensor(Of T)
        Dim rowsA As Integer = data.GetLength(0)
        Dim columnsA As Integer = data.GetLength(1)
        Dim rowsB As Integer = other.DataArray.GetLength(0)
        Dim columnsB As Integer = other.DataArray.GetLength(1)

        If columnsA <> rowsB Then
            Throw New ArgumentException("Invalid matrix sizes for dot product.")
        End If

        Dim result As New Tensor(Of T)(rowsA, columnsB)
        For i As Integer = 0 To rowsA - 1
            For j As Integer = 0 To columnsB - 1
                Dim sum As INumeric(Of T) = CType(Convert.ChangeType(0, GetType(T)), INumeric(Of T))
                For k As Integer = 0 To columnsA - 1
                    Dim valueA As INumeric(Of T) = CType(data(i, k), INumeric(Of T))
                    Dim valueB As INumeric(Of T) = CType(other.DataArray(k, j), INumeric(Of T))
                    sum = sum.Add(valueA.Multiply(valueB))
                Next
                result.SetItem(i, j, CType(sum, T))
            Next
        Next
        Return result
    End Function


    ' Function for Convolution
    Public Function Convolution(kernel As Tensor(Of T)) As Tensor(Of T)
        ' Implement convolution here
        ' The kernel tensor should be smaller than the current tensor
        ' Convolution involves sliding the kernel over the tensor and performing element-wise multiplication and sum
        ' It is a common operation used in image processing and convolutional neural networks
    End Function

    ' Function for 2D Pooling (Max Pooling)
    Public Function MaxPooling(poolSize As Integer) As Tensor(Of T)
        ' Implement max pooling here
        ' Max pooling involves dividing the tensor into non-overlapping pool regions and selecting the maximum value from each pool
        ' It is a common operation used in convolutional neural networks for down-sampling
    End Function

    ' Function for Min-Max Scaling
    Public Interface IArithmetic(Of T)
        Function Add(ByVal other As T) As T
        Function Subtract(ByVal other As T) As T
        Function Multiply(ByVal other As T) As T
        Function Divide(ByVal other As T) As T
    End Interface

    Public Interface INumeric(Of T)
        Inherits IArithmetic(Of T)
        Function CompareTo(ByVal other As T) As Integer
    End Interface

    ' Method to get the number of rows and columns
    Public Function GetShape() As (rows As Integer, columns As Integer)
        Return (data.GetLength(0), data.GetLength(1))
    End Function

    ' Operator overloads for math operations
    Public Shared Operator +(tensor1 As Tensor(Of T), tensor2 As Tensor(Of T)) As Tensor(Of T)
        Return tensor1.Add(tensor2)
    End Operator

    Public Shared Operator -(tensor1 As Tensor(Of T), tensor2 As Tensor(Of T)) As Tensor(Of T)
        Return tensor1.Subtract(tensor2)
    End Operator

    Public Shared Operator *(tensor1 As Tensor(Of T), tensor2 As Tensor(Of T)) As Tensor(Of T)
        Return tensor1.Multiply(tensor2)
    End Operator

    Public Shared Operator /(tensor1 As Tensor(Of T), tensor2 As Tensor(Of T)) As Tensor(Of T)
        Return tensor1.Divide(tensor2)
    End Operator
    ' Helper method to create a tensor filled with a specific value
    Public Shared Function Fill(value As T, rows As Integer, columns As Integer) As Tensor(Of T)
        Dim tensor As New Tensor(Of T)(rows, columns)
        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To columns - 1
                tensor.SetItem(i, j, value)
            Next
        Next
        Return tensor
    End Function
    ' Helper method to create a tensor from nested lists
    Public Shared Function FromLists(dataLists As List(Of List(Of T))) As Tensor(Of T)
        Dim rows As Integer = dataLists.Count
        Dim columns As Integer = dataLists(0).Count
        Dim tensor As New Tensor(Of T)(rows, columns)
        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To columns - 1
                tensor.SetItem(i, j, dataLists(i)(j))
            Next
        Next
        Return tensor
    End Function
    ' Method to get the sum, mean, and standard deviation of the tensor
    Public Function Statistics() As (sum As T, mean As Double, stdDev As Double)
        Dim sum As T = CType(Convert.ChangeType(0, GetType(T)), T)
        Dim count As Integer = 0

        For i As Integer = 0 To data.GetLength(0) - 1
            For j As Integer = 0 To data.GetLength(1) - 1
                ' Use Operators.Add to perform addition for generic type T
                sum = Operators.AddObject(sum, data(i, j))
                count += 1
            Next
        Next

        Dim mean As Double = Convert.ToDouble(sum) / count

        Dim squaredSum As Double = 0
        For i As Integer = 0 To data.GetLength(0) - 1
            For j As Integer = 0 To data.GetLength(1) - 1
                Dim value As Double = Convert.ToDouble(data(i, j))
                squaredSum += (value - mean) * (value - mean)
            Next
        Next

        Dim stdDev As Double = Math.Sqrt(squaredSum / count)

        Return (sum, mean, stdDev)
    End Function
End Class
Public Module TensorExtensions

    <Extension()>
    Public Function Multiply(ByVal tensor As Tensor(Of Double), ByVal scalar As Double) As Tensor(Of Double)
        ' Perform element-wise multiplication with a scalar value
        Dim result As New Tensor(Of Double)(tensor.GetShape().rows, tensor.GetShape().columns)
        For i As Integer = 0 To tensor.GetShape().rows - 1
            For j As Integer = 0 To tensor.GetShape().columns - 1
                result.SetItem(i, j, tensor.GetItem(i, j) * scalar)
            Next
        Next
        Return result
    End Function

    <Extension()>
    Public Function Divide(ByVal tensor As Tensor(Of Double), ByVal scalar As Double) As Tensor(Of Double)
        ' Perform element-wise division by a scalar value
        Dim result As New Tensor(Of Double)(tensor.GetShape().rows, tensor.GetShape().columns)
        For i As Integer = 0 To tensor.GetShape().rows - 1
            For j As Integer = 0 To tensor.GetShape().columns - 1
                result.SetItem(i, j, tensor.GetItem(i, j) / scalar)
            Next
        Next
        Return result
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function Norm(Of T)(ByVal vector As Vector(Of T)) As Double
        ' Compute the L2 norm of the vector
        Dim sumSquared As Double = 0
        For i As Integer = 0 To vector.GetShape().columns - 1
            Dim value As Double = Convert.ToDouble(vector.GetItem(0, i))
            sumSquared += value * value
        Next
        Return Math.Sqrt(sumSquared)
    End Function
    <Extension()>
    Public Function Statistics(Of T)(ByVal tensor As Tensor(Of T)) As (sum As T, mean As Double, stdDev As Double)
        Return tensor.Statistics()
    End Function

    <Extension()>
    Public Function GetItem(Of T)(ByVal tensor As Tensor(Of T), ByVal row As Integer, ByVal column As Integer) As T
        Return tensor.GetItem(row, column)
    End Function

    <Extension()>
    Public Sub SetItem(Of T)(ByVal tensor As Tensor(Of T), ByVal row As Integer, ByVal column As Integer, ByVal value As T)
        tensor.SetItem(row, column, value)
    End Sub
    <System.Runtime.CompilerServices.Extension()>
    Public Function Transpose(Of T)(ByVal matrix As Matrix(Of T)) As Matrix(Of T)
        ' Compute the matrix transpose
        Dim result As New Matrix(Of T)(matrix.GetShape().columns, matrix.GetShape().rows)
        For i As Integer = 0 To matrix.GetShape().rows - 1
            For j As Integer = 0 To matrix.GetShape().columns - 1
                result.SetItem(j, i, matrix.GetItem(i, j))
            Next
        Next
        Return result
    End Function
    <System.Runtime.CompilerServices.Extension()>
    Public Function [And](ByVal tensor1 As Tensor(Of Boolean), ByVal tensor2 As Tensor(Of Boolean)) As Tensor(Of Boolean)
        ' Perform element-wise logical AND operation
        Dim result As New Tensor(Of Boolean)(tensor1.GetShape().rows, tensor1.GetShape().columns)
        For i As Integer = 0 To tensor1.GetShape().rows - 1
            For j As Integer = 0 To tensor1.GetShape().columns - 1
                result.SetItem(i, j, tensor1.GetItem(i, j) AndAlso tensor2.GetItem(i, j))
            Next
        Next
        Return result
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function [Or](ByVal tensor1 As Tensor(Of Boolean), ByVal tensor2 As Tensor(Of Boolean)) As Tensor(Of Boolean)
        ' Perform element-wise logical OR operation
        Dim result As New Tensor(Of Boolean)(tensor1.GetShape().rows, tensor1.GetShape().columns)
        For i As Integer = 0 To tensor1.GetShape().rows - 1
            For j As Integer = 0 To tensor1.GetShape().columns - 1
                result.SetItem(i, j, tensor1.GetItem(i, j) OrElse tensor2.GetItem(i, j))
            Next
        Next
        Return result
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function [Not](ByVal tensor As Tensor(Of Boolean)) As Tensor(Of Boolean)
        ' Perform element-wise logical NOT operation
        Dim result As New Tensor(Of Boolean)(tensor.GetShape().rows, tensor.GetShape().columns)
        For i As Integer = 0 To tensor.GetShape().rows - 1
            For j As Integer = 0 To tensor.GetShape().columns - 1
                result.SetItem(i, j, Not tensor.GetItem(i, j))
            Next
        Next
        Return result
    End Function

    <Extension()>
    Public Sub Print(Of T)(ByVal tensor As Tensor(Of T))
        ' Print the tensor to the console
        For i As Integer = 0 To tensor.GetShape().rows - 1
            For j As Integer = 0 To tensor.GetShape().columns - 1
                Console.Write(tensor.GetItem(i, j))
            Next
            Console.WriteLine()
        Next
    End Sub

    <Extension()>
    Public Function Zip(Of T, U)(ByVal tensor1 As Tensor(Of T), ByVal tensor2 As Tensor(Of U)) As Tensor(Of (T, U))
        ' Zip two tensors together into a new tensor of tuples
        Dim rows As Integer = Math.Min(tensor1.GetShape().rows, tensor2.GetShape().rows)
        Dim columns As Integer = Math.Min(tensor1.GetShape().columns, tensor2.GetShape().columns)
        Dim result As New Tensor(Of (T, U))(rows, columns)
        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To columns - 1
                Dim item1 As T = tensor1.GetItem(i, j)
                Dim item2 As U = tensor2.GetItem(i, j)
                result.SetItem(i, j, (item1, item2))
            Next
        Next
        Return result
    End Function

    <Extension()>
    Public Function ToDataFrame(Of T)(ByVal tensor As Tensor(Of T)) As DataTable
        Dim rows As Integer = tensor.GetShape().rows
        Dim columns As Integer = tensor.GetShape().columns
        Dim dataTable As New DataTable()

        For j As Integer = 0 To columns - 1
            dataTable.Columns.Add("Column" & j)
        Next

        For i As Integer = 0 To rows - 1
            Dim rowValues(columns - 1) As Object
            For j As Integer = 0 To columns - 1
                rowValues(j) = tensor.GetItem(i, j)
            Next
            dataTable.Rows.Add(rowValues)
        Next

        Return dataTable
    End Function


End Module