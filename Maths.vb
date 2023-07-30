Imports System.Drawing

Namespace MATH_EXTENSIONS

    Namespace MathsExt


        Namespace Cypher

            ''' <summary>
            ''' Caesar cipher, both encoding And decoding.
            ''' The key Is an Integer from 1 To 25.
            ''' This cipher rotates (either towards left Or right) the letters Of the alphabet (A To Z).
            ''' The encoding replaces Each letter With the 1St To 25th Next letter In the alphabet (wrapping Z To A).
            ''' So key 2 encrypts "HI" To "JK", but key 20 encrypts "HI" To "BC".
            ''' </summary>
            Public Class Caesarcipher

                Public Function Encrypt(ch As Char, code As Integer) As Char
                    If Not Char.IsLetter(ch) Then
                        Return ch
                    End If

                    Dim offset = AscW(If(Char.IsUpper(ch), "A"c, "a"c))
                    Dim test = (AscW(ch) + code - offset) Mod 26 + offset
                    Return ChrW(test)
                End Function

                Public Function Encrypt(input As String, code As Integer) As String
                    Return New String(input.Select(Function(ch) Encrypt(ch, code)).ToArray())
                End Function

                Public Function Decrypt(input As String, code As Integer) As String
                    Return Encrypt(input, 26 - code)
                End Function

            End Class

        End Namespace



        <ComClass(MathFunctions.ClassId, MathFunctions.InterfaceId, MathFunctions.EventsId)>
        Public Class MathFunctions

            '
            Public Const ClassId As String = "2822E490-7703-401C-BAB3-38FF97BC1AC9"

            Public Const EventsId As String = "CDB54207-F55E-401A-AC6D-3CF8086FD6F1"
            Public Const InterfaceId As String = "8B3325F8-5D13-4059-829B-B531310144B5"

            ''' <summary>
            ''' Re-maps a number from one range to another. In the example above,
            ''' </summary>
            ''' <param name="value"> the incoming value to be converted </param>
            ''' <param name="start1"> lower bound of the value's current range </param>
            ''' <param name="stop1"> upper bound of the value's current range </param>
            ''' <param name="start2"> lower bound of the value's target range </param>
            ''' <param name="stop2"> upper bound of the value's target range </param>
            Public Shared Function Map(ByVal value As Single, ByVal start1 As Single, ByVal stop1 As Single, ByVal start2 As Single, ByVal stop2 As Single) As Single
                Dim Output As Single = start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1))
                Dim errMessage As String = Nothing

                If Output <> Output Then
                    errMessage = "NaN (not a number)"
                    Throw New Exception(errMessage)
                ElseIf Output = Single.NegativeInfinity OrElse Output = Single.PositiveInfinity Then
                    errMessage = "infinity"
                    Throw New Exception(errMessage)
                End If
                Return Output
            End Function

            ''' <summary>
            ''' Normalizes a number from another range into a value between 0 and 1.
            ''' Identical to map(value, low, high, 0, 1);
            ''' Numbers outside the range are not clamped to 0 and 1, because
            ''' out-of-range values are often intentional and useful.
            ''' </summary>
            ''' <param name="value"> the incoming value to be converted </param>
            ''' <param name="start"> lower bound of the value's current range </param>
            ''' <param name="stop"> upper bound of the value's current range </param>
            Public Shared Function Norm(ByVal value As Single, ByVal start As Single, ByVal [stop] As Single) As Single
                Return (value - start) / ([stop] - start)
            End Function

            ''' <summary>
            ''' Calculates a number between two numbers at a specific increment.
            ''' Amount parameter is the amount to interpolate between the two values
            ''' </summary>
            ''' <param name="Start"> first value </param>
            ''' <param name="[Stop]"> second value </param>
            ''' <param name="InterpAmount"> float between 0.0 and 1.0 </param>
            Public Shared Function Lerp(ByVal Start As Single, ByVal [Stop] As Single, ByVal InterpAmount As Single) As Single
                Return Start + ([Stop] - Start) * InterpAmount
            End Function

            ''' <summary>
            ''' Constrains value between min and max values
            '''   if less than min, return min
            '''   more than max, return max
            '''   otherwise return same value
            ''' </summary>
            ''' <param name="Value"></param>
            ''' <param name="min"></param>
            ''' <param name="max"></param>
            ''' <returns></returns>
            Public Function Constraint(Value As Single, min As Single, max As Single) As Single
                If Value <= min Then
                    Return min
                ElseIf Value >= max Then
                    Return max
                End If
                Return Value
            End Function

            ''' <summary>
            ''' Generates 8 bit array of an integer, value from 0 to 255
            ''' </summary>
            ''' <param name="Value"></param>
            ''' <returns></returns>
            Public Function GetBitArray(Value As Integer) As Integer()
                Dim Result(7) As Integer
                Dim sValue As String
                Dim cValue() As Char

                Value = Constraint(Value, 0, 255)
                sValue = Convert.ToString(Value, 2).PadLeft(8, "0"c)
                cValue = sValue.ToArray
                For i As Integer = 0 To cValue.Count - 1
                    If cValue(i) = "1"c Then
                        Result(i) = 1
                    Else
                        Result(i) = 0
                    End If
                Next
                Return Result
            End Function

            ''' <summary>
            ''' Generates 8 bit array of an integer, value from 0 to 255
            ''' </summary>
            ''' <param name="Value"></param>
            ''' <returns></returns>
            Public Function GetBits(Value As Integer) As Integer()
                Dim _Arr As BitArray
                Dim Result() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}

                _Arr = New BitArray(New Integer() {Value})
                _Arr.CopyTo(Result, 0)
                Return Result
            End Function

            Public Function GetBitsString(Value As Integer) As String
                Dim _Array() As Integer = GetBitArray(Value)
                Dim Result As String = ""

                For I As Integer = 0 To _Array.Length - 1
                    Result += _Array(I).ToString
                Next
                Return Result
            End Function

        End Class

        ''' <summary>
        ''' RandomFactory class generates different random numbers, characters, colors, etc..
        ''' </summary>
        <ComClass(RandomFactory.ClassId, RandomFactory.InterfaceId, RandomFactory.EventsId)>
        Public Class RandomFactory
            Public Const ClassId As String = "2828E190-7703-401C-BAB3-38FF97BC1AC9"
            Public Const EventsId As String = "CDB51307-F55E-401A-AC6D-3CF8086FD6F1"
            Public Const InterfaceId As String = "8B3341F8-5D13-4059-829B-B531310144B5"
            Private _Gen As System.Random

            ''' <summary>
            ''' Initializes Random generator variable
            ''' </summary>
            Public Sub New()
                _Gen = New System.Random()
            End Sub

            ''' <summary>
            ''' Generates random integer
            ''' </summary>
            ''' <returns></returns>
            Public Function GetRandomInt() As Integer
                Randomize()
                Return _Gen.Next()
            End Function

            ''' <summary>
            ''' Generates random integer less than Max
            ''' </summary>
            ''' <param name="max"></param>
            ''' <returns></returns>
            Public Function GetRandomInt(max As Integer) As Integer
                Randomize()
                If max < 1 Then max = 1
                Return _Gen.Next(max * 100) / 100
            End Function

            ''' <summary>
            ''' Generates Integer random between min and max
            ''' </summary>
            ''' <param name="min"></param>
            ''' <param name="max"></param>
            ''' <returns></returns>
            Public Function GetRandomInt(min As Integer, max As Integer) As Integer
                Randomize()
                Return _Gen.Next(min * 100, max * 100) / 100
            End Function

            ''' <summary>
            ''' Generates next double random between 0 and 1
            ''' </summary>
            ''' <returns></returns>
            Public Function GetRandomDbl() As Double
                Randomize()
                Return _Gen.NextDouble
            End Function

            ''' <summary>
            ''' Generates next double random between min and max
            ''' </summary>
            ''' <param name="min"></param>
            ''' <param name="max"></param>
            ''' <returns></returns>
            Public Function GetRandomDbl(min As Double, max As Double) As Double
                Randomize()
                Return CDbl(MathFunctions.Map(_Gen.NextDouble(), 0, 1, min, max))
            End Function

            ''' <summary>
            ''' Generates next single random between min and max
            ''' </summary>
            ''' <param name="min"></param>
            ''' <param name="max"></param>
            ''' <returns></returns>
            Public Function GetRandomSngl(min As Double, max As Double) As Double
                Randomize()

                Return MathFunctions.Map(CSng(_Gen.NextDouble()), 0, 1, min, max)
            End Function

            ''' <summary>
            ''' Generates next random color by generating 4 random integers Alpha, red, green and blue
            ''' </summary>
            ''' <returns></returns>
            Public Function GetRandomColor() As Color
                Dim MyAlpha As Integer
                Dim MyRed As Integer
                Dim MyGreen As Integer
                Dim MyBlue As Integer
                ' Initialize the random-number generator.
                Randomize()
                ' Generate random value between 1 and 6.
                MyAlpha = CInt(Int((254 * Rnd()) + 0))
                ' Initialize the random-number generator.
                Randomize()
                ' Generate random value between 1 and 6.
                MyRed = CInt(Int((254 * Rnd()) + 0))
                ' Initialize the random-number generator.
                Randomize()
                ' Generate random value between 1 and 6.
                MyGreen = CInt(Int((254 * Rnd()) + 0))
                ' Initialize the random-number generator.
                Randomize()
                ' Generate random value between 1 and 6.
                MyBlue = CInt(Int((254 * Rnd()) + 0))

                Return Color.FromArgb(MyAlpha, MyRed, MyGreen, MyBlue)
            End Function

            ''' <summary>
            ''' Generates next random character as per ASCII codes, from 32 to 122
            ''' </summary>
            ''' <returns></returns>
            Public Function GetRandomChar() As Char
                Randomize()
                Return GetRandomChar(32, 122)
            End Function

            ''' <summary>
            ''' Generates next random char as per ASCII between min to max
            ''' </summary>
            ''' <param name="min"></param>
            ''' <param name="max"></param>
            ''' <returns></returns>
            Public Function GetRandomChar(min As Integer, max As Integer) As Char
                'Return ChrW(GetRandomInt(min, max))
                Randomize()

                ' Store the numbers 1 to 6 in a list '
                Dim allNumbers As New List(Of Integer)(Enumerable.Range(min, max - min + 1))
                ' Store the randomly selected numbers in this list: '
                Dim selectedNumbers As New List(Of Integer)
                For i As Integer = 0 To allNumbers.Count - 1
                    ' A random index in numbers '
                    Dim index As Integer = _Gen.Next(0, allNumbers.Count)
                    ' Copy the item at index from allNumbers. '
                    Dim selectedNumber As Integer = allNumbers(index)
                    ' And store it in our list of picked numbers. '
                    selectedNumbers.Add(selectedNumber)
                    ' Remove the item from the list so that it cannot be picked again. '
                    allNumbers.RemoveAt(index)
                Next
                Return ChrW(selectedNumbers(0))
            End Function

            ''' <summary>
            '''   Equally likely to return true or false
            ''' </summary>
            ''' <returns></returns>
            Public Function NextBoolean() As Boolean
                Return _Gen.Next(2) > 0
            End Function

            ''' <summary>
            '''   Generates normally distributed numbers using Box-Muller transform by generating 2 random doubles
            '''   Gaussian noise is statistical noise having a probability density function (PDF) equal to that of the normal distribution,
            '''   which is also known as the Gaussian distribution.
            '''   In other words, the values that the noise can take on are Gaussian-distributed.
            ''' </summary>
            ''' <param name = "Mean">Mean of the distribution, default = 0</param>
            ''' <param name = "StdDeviation">Standard deviation, default = 1</param>
            ''' <returns></returns>
            Public Function NextGaussian(Optional ByVal Mean As Double = 0, Optional ByVal StdDeviation As Double = 1) As Double
                Dim X1 = _Gen.NextDouble()
                Dim X2 = _Gen.NextDouble()
                Dim StdDistribution = Math.Sqrt(-2.0 * Math.Log(X1)) * Math.Sin(2.0 * Math.PI * X2)
                Dim GaussianRnd = Mean + StdDeviation * StdDistribution

                Return GaussianRnd
            End Function

            ''' <summary>
            '''   Generates values from a triangular distribution
            '''   Triangular distribution is a continuous probability distribution with:
            '''       lower limit a
            '''       upper limit b
            '''       mode c
            '''   where a less than b
            '''   c is higher than or equal a but lessthan or equal b
            ''' </summary>
            ''' <param name = "min">Minimum</param>
            ''' <param name = "max">Maximum</param>
            ''' <param name = "mode">Mode (most frequent value)</param>
            ''' <returns></returns>
            Public Function NextTriangular(ByVal min As Double, ByVal max As Double, ByVal mode As Double) As Double
                Dim u = _Gen.NextDouble()

                If (u < (mode - min) / (max - min)) Then
                    Return min + Math.Sqrt(u * (max - min) * (mode - min))
                Else
                    Return max - Math.Sqrt((1 - u) * (max - min) * (max - mode))
                End If
            End Function

            ''' <summary>
            '''   Shuffles a list in O(n) time by using the Fisher-Yates/Knuth algorithm
            ''' </summary>
            ''' <param name = "list"></param>
            Public Sub Shuffle(ByVal list As IList)
                For i = 0 To list.Count - 1
                    Dim j = _Gen.Next(0, i + 1)

                    Dim temp = list(j)
                    list(j) = list(i)
                    list(i) = temp
                Next i
            End Sub

        End Class

        Namespace AdvancedMath
            Public Class Statistic
                Public Frequency As Integer
                Public ReadOnly RelativeFrequency As Integer = CalcRelativeFrequency()
                Public ReadOnly RelativeFrequencyPercentage As Integer = CalcRelativeFrequencyPercentage()
                Public Total_SetItems As Integer
                Public ItemName As String
                Public ItemData As Object

                ''' <summary>
                ''' IE: Frequency = 8 Total = 20 8/20= 0.4
                ''' </summary>
                ''' <param name="Frequency"></param>
                ''' <param name="Total"></param>
                ''' <returns></returns>
                Public Shared Function CalcRelativeFrequency(ByRef Frequency As Integer, ByRef Total As Integer) As Integer
                    'IE: Frequency = 8 Total = 20 8/20= 0.4
                    Return Frequency / Total
                End Function

                Private Function CalcRelativeFrequency() As Integer
                    'IE: Frequency = 8 Total = 20 8/20= 0.4
                    Return Me.Frequency / Me.Total_SetItems
                End Function

                ''' <summary>
                '''    IE: Frequency = 8 Total = 20 8/20= 0.4 * 100 = 40%
                ''' </summary>
                ''' <param name="Frequency"></param>
                ''' <param name="Total"></param>
                ''' <returns></returns>
                Public Function CalcRelativeFrequencyPercentage(ByRef Frequency As Integer, ByRef Total As Integer) As Integer
                    'IE: Frequency = 8 Total = 20 8/20= 0.4 * 100 = 40%
                    Return Frequency / Total * 100
                End Function

                Private Function CalcRelativeFrequencyPercentage() As Integer
                    'IE: Frequency = 8 Total = 20 8/20= 0.4 * 100 = 40%
                    Return Me.Frequency / Me.Total_SetItems * 100
                End Function

            End Class

        End Namespace

        Namespace Science
            Public Module Conversion_Extensions

                ':SHAPES/VOLUMES / Area:
                ''' <summary>
                ''' Comments : Returns the volume of a cone '
                ''' </summary>
                ''' <param name="dblHeight">dblHeight - height of cone</param>
                ''' <param name="dblRadius">radius of cone base</param>
                ''' <returns>volume</returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function VolOfCone(ByVal dblHeight As Double, ByVal dblRadius As Double) As Double
                    Const cdblPI As Double = 3.14159265358979
                    On Error GoTo PROC_ERR
                    VolOfCone = dblHeight * (dblRadius ^ 2) * cdblPI / 3
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(VolOfCone))
                    Resume PROC_EXIT
                End Function

                ''' <summary>
                ''' Comments : Returns the volume of a cylinder
                ''' </summary>
                ''' <param name="dblHeight">dblHeight - height of cylinder</param>
                ''' <param name="dblRadius">radius of cylinder</param>
                ''' <returns>volume</returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function VolOfCylinder(
            ByVal dblHeight As Double,
            ByVal dblRadius As Double) As Double
                    Const cdblPI As Double = 3.14159265358979
                    On Error GoTo PROC_ERR
                    VolOfCylinder = cdblPI * dblHeight * dblRadius ^ 2
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(VolOfCylinder))
                    Resume PROC_EXIT
                End Function

                ''' <summary>
                ''' Returns the volume of a pipe
                ''' </summary>
                ''' <param name="dblHeight">height of pipe</param>
                ''' <param name="dblOuterRadius">outer radius of pipe</param>
                ''' <param name="dblInnerRadius">inner radius of pipe</param>
                ''' <returns>volume</returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function VolOfPipe(
            ByVal dblHeight As Double,
            ByVal dblOuterRadius As Double,
            ByVal dblInnerRadius As Double) _
            As Double
                    On Error GoTo PROC_ERR
                    VolOfPipe = VolOfCylinder(dblHeight, dblOuterRadius) -
                VolOfCylinder(dblHeight, dblInnerRadius)
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(VolOfPipe))
                    Resume PROC_EXIT
                End Function

                ''' <summary>
                ''' Returns the volume of a pyramid or cone
                ''' </summary>
                ''' <param name="dblHeight">height of pyramid</param>
                ''' <param name="dblBaseArea">area of the base</param>
                ''' <returns>volume</returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function VolOfPyramid(
            ByVal dblHeight As Double,
            ByVal dblBaseArea As Double) As Double
                    On Error GoTo PROC_ERR
                    VolOfPyramid = dblHeight * dblBaseArea / 3
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(VolOfPyramid))
                    Resume PROC_EXIT
                End Function

                ''' <summary>
                ''' Returns the volume of a sphere
                ''' </summary>
                ''' <param name="dblRadius">dblRadius - radius of the sphere</param>
                ''' <returns>volume</returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function VolOfSphere(ByVal dblRadius As Double) As Double
                    Const cdblPI As Double = 3.14159265358979
                    On Error GoTo PROC_ERR
                    VolOfSphere = cdblPI * (dblRadius ^ 3) * 4 / 3
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(VolOfSphere))
                    Resume PROC_EXIT
                End Function

                ''' <summary>
                ''' Returns the volume of a truncated pyramid
                ''' </summary>
                ''' <param name="dblHeight">dblHeight - height of pyramid</param>
                ''' <param name="dblArea1">area of base</param>
                ''' <param name="dblArea2">area of top</param>
                ''' <returns>volume</returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function VolOfTruncPyramid(
            ByVal dblHeight As Double,
            ByVal dblArea1 As Double,
            ByVal dblArea2 As Double) _
            As Double
                    On Error GoTo PROC_ERR
                    VolOfTruncPyramid = dblHeight * (dblArea1 + dblArea2 + Math.Sqrt(dblArea1) *
                Math.Sqrt(dblArea2)) / 3
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(VolOfTruncPyramid))
                    Resume PROC_EXIT
                End Function

                <Runtime.CompilerServices.Extension()>
                Public Function VolumeOfElipse(ByRef Radius1 As Double, ByRef Radius2 As Double, ByRef Radius3 As Double) As Double
                    ' Case 2:

                    ' Find the volume of an ellipse with the given radii 3, 4, 5.
                    'Step 1:

                    ' Find the volume. Volume = (4/3)πr1r2r3= (4/3) * 3.14 * 3 * 4 * 5 = 1.33 * 188.4 = 251

                    VolumeOfElipse = ((4 / 3) * Math.PI) * Radius1 * Radius2 * Radius3

                End Function

                ''' <summary>
                ''' Comments : Returns the area of a circle
                ''' </summary>
                ''' <param name="dblRadius">dblRadius - radius of circle</param>
                ''' <returns>Returns : area (Double)</returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function AreaOfCircle(ByVal dblRadius As Double) As Double
                    Const PI = 3.14159265358979
                    On Error GoTo PROC_ERR
                    AreaOfCircle = PI * dblRadius ^ 2
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(AreaOfCircle))
                    Resume PROC_EXIT
                End Function

                <Runtime.CompilerServices.Extension()>
                Public Function AreaOfElipse(ByRef Radius1 As Double, ByRef Radius2 As Double) As Double
                    'Ellipse Formula :  Area of Ellipse = πr1r2
                    'Case 1:
                    'Find the area and perimeter of an ellipse with the given radii 3, 4.
                    'Step 1:
                    'Find the area.
                    'Area = πr1r2 = 3.14 * 3 * 4 = 37.68 .
                    AreaOfElipse = Math.PI * Radius1 * Radius2

                End Function

                ''' <summary>
                ''' Returns the area of a rectangle
                ''' </summary>
                ''' <param name="dblLength">dblLength - length of rectangle</param>
                ''' <param name="dblWidth">width of rectangle</param>
                ''' <returns></returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function AreaOfRectangle(
            ByVal dblLength As Double,
            ByVal dblWidth As Double) _
            As Double
                    On Error GoTo PROC_ERR
                    AreaOfRectangle = dblLength * dblWidth
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(AreaOfRectangle))
                    Resume PROC_EXIT
                End Function

                <Runtime.CompilerServices.Extension()>
                Public Function AreaOFRhombusMethod1(ByRef base As Double, ByRef height As Double) As Double

                    'Case 1:
                    'Find the area of a rhombus with the given base 3 and height 4 using Base Times Height Method.
                    'Step 1:
                    'Find the area.
                    'Area = b * h = 3 * 4 = 12.
                    AreaOFRhombusMethod1 = base * height
                End Function

                <Runtime.CompilerServices.Extension()>
                Public Function AreaOFRhombusMethod2(ByRef Diagonal1 As Double, ByRef Diagonal2 As Double) As Double
                    'Case 2:

                    'Find the area of a rhombus with the given diagonals 2, 4 using Diagonal Method.
                    'Step 1:

                    'Find the area.
                    ' Area = ½ * d1 * d2 = 0.5 * 2 * 4 = 4.

                    AreaOFRhombusMethod2 = 0.5 * Diagonal1 * Diagonal2
                End Function

                <Runtime.CompilerServices.Extension()>
                Public Function AreaOFRhombusMethod3(ByRef Side As Double) As Double
                    'Case 3:

                    'Find the area of a rhombus with the given side 2 using Trigonometry Method.
                    'Step 1:

                    'Find the area.
                    'Area = a² * SinA = 2² * Sin(33) = 4 * 1 = 4.

                    AreaOFRhombusMethod3 = (Side * Side) * Math.Sin(33)
                End Function

                ''' <summary>
                ''' Returns the area of a ring
                ''' </summary>
                ''' <param name="dblInnerRadius">dblInnerRadius - inner radius of the ring</param>
                ''' <param name="dblOuterRadius">outer radius of the ring</param>
                ''' <returns>area</returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function AreaOfRing(
            ByVal dblInnerRadius As Double,
            ByVal dblOuterRadius As Double) _
            As Double
                    On Error GoTo PROC_ERR

                    AreaOfRing = AreaOfCircle(dblOuterRadius) -
                AreaOfCircle(dblInnerRadius)
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(AreaOfRing))
                    Resume PROC_EXIT
                End Function

                ''' <summary>
                ''' Returns the area of a sphere
                ''' </summary>
                ''' <param name="dblRadius">dblRadius - radius of the sphere</param>
                ''' <returns>area</returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function AreaOfSphere(ByVal dblRadius As Double) As Double
                    Const cdblPI As Double = 3.14159265358979
                    On Error GoTo PROC_ERR
                    AreaOfSphere = 4 * cdblPI * dblRadius ^ 2
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(AreaOfSphere))
                    Resume PROC_EXIT
                End Function

                ''' <summary>
                ''' Returns the area of a square
                ''' </summary>
                ''' <param name="dblSide">dblSide - length of a side of the square</param>
                ''' <returns>area</returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function AreaOfSquare(ByVal dblSide As Double) As Double
                    On Error GoTo PROC_ERR
                    AreaOfSquare = dblSide ^ 2
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(AreaOfSquare))
                    Resume PROC_EXIT
                End Function

                ''' <summary>
                ''' Returns the area of a square
                ''' </summary>
                ''' <param name="dblDiag">dblDiag - length of the square's diagonal</param>
                ''' <returns>area</returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function AreaOfSquareDiag(ByVal dblDiag As Double) As Double
                    On Error GoTo PROC_ERR
                    AreaOfSquareDiag = (dblDiag ^ 2) / 2
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(AreaOfSquareDiag))
                    Resume PROC_EXIT
                End Function

                ''' <summary>
                ''' Returns the area of a trapezoid
                ''' </summary>
                ''' <param name="dblHeight">dblHeight - height</param>
                ''' <param name="dblLength1">length of first side</param>
                ''' <param name="dblLength2">length of second side</param>
                ''' <returns>area</returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function AreaOfTrapezoid(
            ByVal dblHeight As Double,
            ByVal dblLength1 As Double,
            ByVal dblLength2 As Double) _
            As Double
                    On Error GoTo PROC_ERR
                    AreaOfTrapezoid = dblHeight * (dblLength1 + dblLength2) / 2
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(AreaOfTrapezoid))
                    Resume PROC_EXIT
                End Function

                ''' <summary>
                ''' returns the area of a triangle
                ''' </summary>
                ''' <param name="dblLength">dblLength - length of a side</param>
                ''' <param name="dblHeight">perpendicular height</param>
                ''' <returns></returns>
                ''' <remarks>area</remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function AreaOfTriangle(
            ByVal dblLength As Double,
            ByVal dblHeight As Double) _
            As Double
                    On Error GoTo PROC_ERR
                    AreaOfTriangle = dblLength * dblHeight / 2
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(AreaOfTriangle))
                    Resume PROC_EXIT
                End Function

                ''' <summary>
                ''' </summary>
                ''' <param name="dblSideA">dblSideA - length of first side</param>
                ''' <param name="dblSideB">dblSideB - length of second side</param>
                ''' <param name="dblSideC">dblSideC - length of third side</param>
                ''' <returns>the area of a triangle</returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function AreaOfTriangle2(
            ByVal dblSideA As Double,
            ByVal dblSideB As Double,
            ByVal dblSideC As Double) As Double
                    Dim dblCosine As Double
                    On Error GoTo PROC_ERR
                    dblCosine = (dblSideA + dblSideB + dblSideC) / 2
                    AreaOfTriangle2 = Math.Sqrt(dblCosine * (dblCosine - dblSideA) *
                (dblCosine - dblSideB) *
                (dblCosine - dblSideC))
PROC_EXIT:
                    Exit Function
PROC_ERR:
                    MsgBox("Error: " & Err.Number & ". " & Err.Description, ,
                NameOf(AreaOfTriangle2))
                    Resume PROC_EXIT
                End Function

                ''' <summary>
                ''' Perimeter = 2πSqrt((r1² + r2² / 2)
                ''' = 2 * 3.14 * Sqrt((3² + 4²) / 2)
                ''' = 6.28 * Sqrt((9 + 16) / 2) = 6.28 * Sqrt(25 / 2)
                ''' = 6.28 * Sqrt(12.5) = 6.28 * 3.53 = 22.2. Area = πr1r2 = 3.14 * 3 * 4 = 37.68 .
                ''' </summary>
                ''' <param name="Radius1"></param>
                ''' <param name="Radius2"></param>
                ''' <returns></returns>
                <Runtime.CompilerServices.Extension()>
                Public Function PerimeterOfElipse(ByRef Radius1 As Double, ByRef Radius2 As Double) As Double
                    'Perimeter	= 2πSqrt((r1² + r2² / 2)
                    '= 2 * 3.14 * Sqrt((3² + 4²) / 2)
                    '= 6.28 * Sqrt((9 + 16) / 2) = 6.28 * Sqrt(25 / 2)
                    '= 6.28 * Sqrt(12.5) = 6.28 * 3.53 = 22.2.
                    'Area = πr1r2 = 3.14 * 3 * 4 = 37.68 .
                    PerimeterOfElipse = (2 * Math.PI) * Math.Sqrt(((Radius1 * Radius1) + (Radius2 * Radius2) / 2))

                End Function

                ' ***************************** '
                ' **     SPYDAZ AI MATRIX    ** '
                ' ***************************** '
                ':FLIUD VOL:
                <Runtime.CompilerServices.Extension()>
                Public Sub CnvGallonToALL(ByRef GALLON As Integer, ByRef LITRE As Integer, ByRef PINT As Integer)
                    LITRE = Val(GALLON * 3.79)
                    PINT = Val(GALLON * 8)
                End Sub

                ':WEIGHT:
                <Runtime.CompilerServices.Extension()>
                Public Sub CnvGramsTOALL(ByRef GRAM As Integer, ByRef KILO As Integer, ByRef OUNCE As Integer, ByRef POUNDS As Integer)
                    KILO = Val(GRAM * 0.001)
                    OUNCE = Val(GRAM * 0.03527337)
                    POUNDS = Val(GRAM * 0.002204634)
                End Sub

                <Runtime.CompilerServices.Extension()>
                Public Sub CnvkilosTOALL(ByRef KILO As Integer, ByRef GRAM As Integer, ByRef OUNCE As Integer, ByRef POUNDS As Integer)
                    GRAM = Val(KILO * 1000)
                    OUNCE = Val(KILO * 35.27337)
                    POUNDS = Val(KILO * 2.204634141)
                End Sub

                <Runtime.CompilerServices.Extension()>
                Public Sub CnvLitreToALL(ByRef LITRE As Integer, ByRef PINT As Integer, ByRef GALLON As Integer)
                    PINT = Val(LITRE * 2.113427663)
                    GALLON = Val(LITRE * 0.263852243)
                End Sub

                <Runtime.CompilerServices.Extension()>
                Public Sub CnvOunceToALL(ByRef OUNCE As Integer, ByRef GRAM As Integer, ByRef KILO As Integer, ByRef POUNDS As Integer)
                    GRAM = Val(OUNCE * 28.349)
                    KILO = Val(OUNCE * 0.028349)
                    POUNDS = Val(OUNCE * 0.0625)
                End Sub

                <Runtime.CompilerServices.Extension()>
                Public Sub CnvPintToALL(ByRef PINT As Integer, ByRef GALLON As Integer, ByRef LITRE As Integer)
                    LITRE = Val(PINT * 0.473165)
                    GALLON = Val(PINT * 0.1248455)
                End Sub

                'Morse Code
                Public MorseCode() As String = {".", "-"}

                ''' <summary>
                ''' converts charactert to Morse code
                ''' </summary>
                ''' <param name="Ch"></param>
                ''' <returns></returns>
                <Runtime.CompilerServices.Extension()>
                Public Function CharToMorse(ByRef Ch As String) As String
                    Select Case Ch
                        Case "A", "a"
                            CharToMorse = ".-"
                        Case "B", "b"
                            CharToMorse = "-..."
                        Case "C", "c"
                            CharToMorse = "-.-."
                        Case "D", "d"
                            CharToMorse = "-.."
                        Case "E", "e"
                            CharToMorse = "."
                        Case "F", "f"
                            CharToMorse = "..-."
                        Case "G", "g"
                            CharToMorse = "--."
                        Case "H", "h"
                            CharToMorse = "...."
                        Case "I", "i"
                            CharToMorse = ".."
                        Case "J", "j"
                            CharToMorse = ".---"
                        Case "K", "k"
                            CharToMorse = "-.-"
                        Case "L", "l"
                            CharToMorse = ".-.."
                        Case "M", "m"
                            CharToMorse = "--"
                        Case "N", "n"
                            CharToMorse = "-."
                        Case "O", "o"
                            CharToMorse = "---"
                        Case "P", "p"
                            CharToMorse = ".--."
                        Case "Q", "q"
                            CharToMorse = "--.-"
                        Case "R", "r"
                            CharToMorse = ".-."
                        Case "S", "s"
                            CharToMorse = "..."
                        Case "T", "t"
                            CharToMorse = "-"
                        Case "U", "u"
                            CharToMorse = "..-"
                        Case "V", "v"
                            CharToMorse = "...-"
                        Case "W", "w"
                            CharToMorse = ".--"
                        Case "X", "x"
                            CharToMorse = "-..-"
                        Case "Y", "y"
                            CharToMorse = "-.--"
                        Case "Z", "z"
                            CharToMorse = "--.."
                        Case "1"
                            CharToMorse = ".----"
                        Case "2"
                            CharToMorse = "..---"
                        Case "3"
                            CharToMorse = "...--"
                        Case "4"
                            CharToMorse = "....-"
                        Case "5"
                            CharToMorse = "....."
                        Case "6"
                            CharToMorse = "-...."
                        Case "7"
                            CharToMorse = "--..."
                        Case "8"
                            CharToMorse = "---.."
                        Case "9"
                            CharToMorse = "----."
                        Case "0"
                            CharToMorse = "-----"
                        Case " "
                            CharToMorse = "   "
                        Case "."
                            CharToMorse = "^"
                        Case "-"
                            CharToMorse = "~"
                        Case Else
                            CharToMorse = Ch
                    End Select
                End Function

                ''' <summary>
                ''' Converts Morse code Character to Alphabet
                ''' </summary>
                ''' <param name="Ch"></param>
                ''' <returns></returns>
                <Runtime.CompilerServices.Extension()>
                Public Function MorseToChar(ByRef Ch As String) As String
                    Select Case Ch
                        Case ".-"
                            MorseToChar = "a"
                        Case "-..."
                            MorseToChar = "b"
                        Case "-.-."
                            MorseToChar = "c"
                        Case "-.."
                            MorseToChar = "d"
                        Case "."
                            MorseToChar = "e"
                        Case "..-."
                            MorseToChar = "f"
                        Case "--."
                            MorseToChar = "g"
                        Case "...."
                            MorseToChar = "h"
                        Case ".."
                            MorseToChar = "i"
                        Case ".---"
                            MorseToChar = "j"
                        Case "-.-"
                            MorseToChar = "k"
                        Case ".-.."
                            MorseToChar = "l"
                        Case "--"
                            MorseToChar = "m"
                        Case "-."
                            MorseToChar = "n"
                        Case "---"
                            MorseToChar = "o"
                        Case ".--."
                            MorseToChar = "p"
                        Case "--.-"
                            MorseToChar = "q"
                        Case ".-."
                            MorseToChar = "r"
                        Case "..."
                            MorseToChar = "s"
                        Case "-"
                            MorseToChar = "t"
                        Case "..-"
                            MorseToChar = "u"
                        Case "...-"
                            MorseToChar = "v"
                        Case ".--"
                            MorseToChar = "w"
                        Case "-..-"
                            MorseToChar = "x"
                        Case "-.--"
                            MorseToChar = "y"
                        Case "--.."
                            MorseToChar = "z"
                        Case ".----"
                            MorseToChar = "1"
                        Case "..---"
                            MorseToChar = "2"
                        Case "...--"
                            MorseToChar = "3"
                        Case "....-"
                            MorseToChar = "4"
                        Case "....."
                            MorseToChar = "5"
                        Case "-...."
                            MorseToChar = "6"
                        Case "--..."
                            MorseToChar = "7"
                        Case "---.."
                            MorseToChar = "8"
                        Case "----."
                            MorseToChar = "9"
                        Case "-----"
                            MorseToChar = "0"
                        Case "   "
                            MorseToChar = " "
                        Case "^"
                            MorseToChar = "."
                        Case "~"
                            MorseToChar = "-"
                        Case Else
                            MorseToChar = Ch
                    End Select
                End Function

                'Phonetics
                ''' <summary>
                ''' returns phonetic character for Letter
                ''' </summary>
                ''' <param name="InputStr"></param>
                ''' <returns></returns>
                <Runtime.CompilerServices.Extension()>
                Public Function Phonetic(ByRef InputStr As String) As String
                    Phonetic = ""
                    If UCase(InputStr) = "A" Then
                        Phonetic = "Alpha"
                    End If
                    If UCase(InputStr) = "B" Then
                        Phonetic = "Bravo"
                    End If
                    If UCase(InputStr) = "C" Then
                        Phonetic = "Charlie"
                    End If
                    If UCase(InputStr) = "D" Then
                        Phonetic = "Delta"
                    End If
                    If UCase(InputStr) = "E" Then
                        Phonetic = "Echo"
                    End If
                    If UCase(InputStr) = "F" Then
                        Phonetic = "Foxtrot"
                    End If
                    If UCase(InputStr) = "G" Then
                        Phonetic = "Golf"
                    End If
                    If UCase(InputStr) = "H" Then
                        Phonetic = "Hotel"
                    End If
                    If UCase(InputStr) = "I" Then
                        Phonetic = "India"
                    End If
                    If UCase(InputStr) = "J" Then
                        Phonetic = "Juliet"
                    End If
                    If UCase(InputStr) = "K" Then
                        Phonetic = "Kilo"
                    End If
                    If UCase(InputStr) = "L" Then
                        Phonetic = "Lima"
                    End If
                    If UCase(InputStr) = "M" Then
                        Phonetic = "Mike"
                    End If
                    If UCase(InputStr) = "N" Then
                        Phonetic = "November"
                    End If
                    If UCase(InputStr) = "O" Then
                        Phonetic = "Oscar"
                    End If
                    If UCase(InputStr) = "P" Then
                        Phonetic = "Papa"
                    End If
                    If UCase(InputStr) = "Q" Then
                        Phonetic = "Quebec"
                    End If
                    If UCase(InputStr) = "R" Then
                        Phonetic = "Romeo"
                    End If
                    If UCase(InputStr) = "S" Then
                        Phonetic = "Sierra"
                    End If
                    If UCase(InputStr) = "T" Then
                        Phonetic = "Tango"
                    End If
                    If UCase(InputStr) = "U" Then
                        Phonetic = "Uniform"
                    End If
                    If UCase(InputStr) = "V" Then
                        Phonetic = "Victor"
                    End If
                    If UCase(InputStr) = "W" Then
                        Phonetic = "Whiskey"
                    End If
                    If UCase(InputStr) = "X" Then
                        Phonetic = "X-Ray"
                    End If
                    If UCase(InputStr) = "Y" Then
                        Phonetic = "Yankee"
                    End If
                    If UCase(InputStr) = "Z" Then
                        Phonetic = "Zulu"
                    End If
                End Function

                'Temperture

                ''' <summary>
                ''' FUNCTION: CELSIUSTOFAHRENHEIT '
                ''' DESCRIPTION: CONVERTS CELSIUS DEGREES TO FAHRENHEIT DEGREES ' WHERE TO PLACE CODE:
                '''              MODULE '
                ''' NOTES: THE LARGEST NUMBER CELSIUSTOFAHRENHEIT WILL CONVERT IS 32,767
                ''' </summary>
                ''' <param name="intCelsius"></param>
                ''' <returns></returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function CnvCelsiusToFahrenheit(intCelsius As Integer) As Integer
                    CnvCelsiusToFahrenheit = (9 / 5) * intCelsius + 32
                End Function

                ''' <summary>
                ''' FUNCTION: FAHRENHEITTOCELSIUS '
                ''' DESCRIPTION: CONVERTS FAHRENHEIT DEGREES TO CELSIUS DEGREES '
                ''' NOTES: THE LARGEST NUMBER FAHRENHEITTOCELSIUS WILL CONVERT IS 32,767 '
                ''' </summary>
                ''' <param name="intFahrenheit"></param>
                ''' <returns></returns>
                ''' <remarks></remarks>
                <Runtime.CompilerServices.Extension()>
                Public Function CnvFahrenheitToCelsius(intFahrenheit As Integer) As Integer
                    CnvFahrenheitToCelsius = (5 / 9) * (intFahrenheit - 32)
                End Function

            End Module

            ''' <summary>
            ''' Given a molecule's chemical formula, calculate the   molar mass.
            '''In chemistry, the molar mass of a chemical compound Is defined as the mass of a sample of that compound divided by the amount of substance in that sample, measured in moles.
            '''[1] The molar mass Is a bulk, Not molecular, property of a substance.
            '''The molar mass Is an average of many instances of the compound, which often vary in mass due to the presence of isotopes.
            '''Most commonly, the molar mass Is computed from the standard atomic weights And Is thus a terrestrial average And a function of the relative abundance of the isotopes of the constituent atoms on Earth.
            '''The molar mass Is appropriate for converting between the mass of a substance And the amount of a substance for bulk quantities.
            '''The molecular weight Is very commonly used As a synonym Of molar mass, particularly For molecular compounds; however, the most authoritative sources define it differently (see molecular mass).
            '''The formula weight Is a synonym Of molar mass that Is frequently used For non-molecular compounds, such As ionic salts.
            ''' </summary>
            Public Class ChemicalMass

                ' Given a molecule's chemical formula, calculate the   molar mass.
                'In chemistry, the molar mass of a chemical compound Is defined as the mass of a sample of that compound divided by the amount of substance in that sample, measured in moles.[1] The molar mass Is a bulk, Not molecular, property of a substance. The molar mass Is an average of many instances of the compound, which often vary in mass due to the presence of isotopes. Most commonly, the molar mass Is computed from the standard atomic weights And Is thus a terrestrial average And a function of the relative abundance of the isotopes of the constituent atoms on Earth. The molar mass Is appropriate for converting between the mass of a substance And the amount of a substance for bulk quantities.
                'The molecular weight Is very commonly used As a synonym Of molar mass, particularly For molecular compounds; however, the most authoritative sources define it differently (see molecular mass).
                'The formula weight Is a synonym Of molar mass that Is frequently used For non-molecular compounds, such As ionic salts.
                Dim atomicMass As New Dictionary(Of String, Double) From {
            {"H", 1.008},
            {"He", 4.002602},
            {"Li", 6.94},
            {"Be", 9.0121831},
            {"B", 10.81},
            {"C", 12.011},
            {"N", 14.007},
            {"O", 15.999},
            {"F", 18.998403163},
            {"Ne", 20.1797},
            {"Na", 22.98976928},
            {"Mg", 24.305},
            {"Al", 26.9815385},
            {"Si", 28.085},
            {"P", 30.973761998},
            {"S", 32.06},
            {"Cl", 35.45},
            {"Ar", 39.948},
            {"K", 39.0983},
            {"Ca", 40.078},
            {"Sc", 44.955908},
            {"Ti", 47.867},
            {"V", 50.9415},
            {"Cr", 51.9961},
            {"Mn", 54.938044},
            {"Fe", 55.845},
            {"Co", 58.933194},
            {"Ni", 58.6934},
            {"Cu", 63.546},
            {"Zn", 65.38},
            {"Ga", 69.723},
            {"Ge", 72.63},
            {"As", 74.921595},
            {"Se", 78.971},
            {"Br", 79.904},
            {"Kr", 83.798},
            {"Rb", 85.4678},
            {"Sr", 87.62},
            {"Y", 88.90584},
            {"Zr", 91.224},
            {"Nb", 92.90637},
            {"Mo", 95.95},
            {"Ru", 101.07},
            {"Rh", 102.9055},
            {"Pd", 106.42},
            {"Ag", 107.8682},
            {"Cd", 112.414},
            {"In", 114.818},
            {"Sn", 118.71},
            {"Sb", 121.76},
            {"Te", 127.6},
            {"I", 126.90447},
            {"Xe", 131.293},
            {"Cs", 132.90545196},
            {"Ba", 137.327},
            {"La", 138.90547},
            {"Ce", 140.116},
            {"Pr", 140.90766},
            {"Nd", 144.242},
            {"Pm", 145},
            {"Sm", 150.36},
            {"Eu", 151.964},
            {"Gd", 157.25},
            {"Tb", 158.92535},
            {"Dy", 162.5},
            {"Ho", 164.93033},
            {"Er", 167.259},
            {"Tm", 168.93422},
            {"Yb", 173.054},
            {"Lu", 174.9668},
            {"Hf", 178.49},
            {"Ta", 180.94788},
            {"W", 183.84},
            {"Re", 186.207},
            {"Os", 190.23},
            {"Ir", 192.217},
            {"Pt", 195.084},
            {"Au", 196.966569},
            {"Hg", 200.592},
            {"Tl", 204.38},
            {"Pb", 207.2},
            {"Bi", 208.9804},
            {"Po", 209},
            {"At", 210},
            {"Rn", 222},
            {"Fr", 223},
            {"Ra", 226},
            {"Ac", 227},
            {"Th", 232.0377},
            {"Pa", 231.03588},
            {"U", 238.02891},
            {"Np", 237},
            {"Pu", 244},
            {"Am", 243},
            {"Cm", 247},
            {"Bk", 247},
            {"Cf", 251},
            {"Es", 252},
            {"Fm", 257},
            {"Uue", 315},
            {"Ubn", 299}
        }

                Function Evaluate(s As String) As Double
                    s += "["
                    Dim sum = 0.0
                    Dim symbol = ""
                    Dim number = ""
                    For i = 1 To s.Length
                        Dim c = s(i - 1)
                        If "@" <= c AndAlso c <= "[" Then
                            ' @,A-Z
                            Dim n = 1
                            If number <> "" Then
                                n = Integer.Parse(number)
                            End If
                            If symbol <> "" Then
                                sum += atomicMass(symbol) * n
                            End If
                            If c = "[" Then
                                Exit For
                            End If
                            symbol = c.ToString
                            number = ""
                        ElseIf "a" <= c AndAlso c <= "z" Then
                            symbol += c
                        ElseIf "0" <= c AndAlso c <= "9" Then
                            number += c
                        Else
                            Throw New Exception(String.Format("Unexpected symbol {0} in molecule", c))
                        End If
                    Next
                    Return sum
                End Function

                Function ReplaceFirst(text As String, search As String, replace As String) As String
                    Dim pos = text.IndexOf(search)
                    If pos < 0 Then
                        Return text
                    Else
                        Return text.Substring(0, pos) + replace + text.Substring(pos + search.Length)
                    End If
                End Function

                Function ReplaceParens(s As String) As String
                    Dim letter = "s"c
                    While True
                        Dim start = s.IndexOf("(")
                        If start = -1 Then
                            Exit While
                        End If

                        For i = start + 1 To s.Length - 1
                            If s(i) = ")" Then
                                Dim expr = s.Substring(start + 1, i - start - 1)
                                Dim symbol = String.Format("@{0}", letter)
                                s = ReplaceFirst(s, s.Substring(start, i + 1 - start), symbol)
                                atomicMass(symbol) = Evaluate(expr)
                                letter = Chr(Asc(letter) + 1)
                                Exit For
                            End If
                            If s(i) = "(" Then
                                start = i
                                Continue For
                            End If
                        Next
                    End While
                    Return s
                End Function

                Sub Main()
                    Dim molecules() As String = {
                "H", "H2", "H2O", "H2O2", "(HO)2", "Na2SO4", "C6H12",
                "COOH(C(CH3)2)3CH3", "C6H4O2(OH)4", "C27H46O", "Uue"
            }
                    For Each molecule In molecules
                        Dim mass = Evaluate(ReplaceParens(molecule))
                        Console.WriteLine("{0,17} -> {1,7:0.000}", molecule, mass)
                    Next
                End Sub

            End Class

        End Namespace




        Namespace Risk

            ''' <summary>
            ''' used to generate a payoff table and provide a set of outcomes (needs to edit inherit leaf
            ''' node as outcome)
            ''' </summary>
            Public Class PayOffTable

                'Decision matrix;

                'Risk and uncertainty,
                'Risk is where there are a number of possible outcomes and the probability of each outcome is known.
                'For example, based on past experience of digging for oil in a particular area,
                'an oil company may estimate that they have a 60% chance Of finding oil And a 40% chance Of Not finding oil.

                'Uncertainty
                'Uncertainty occurs when there are a number of possible outcomes but the probability of each outcome is not known.
                'For example, the same oil company may dig for oil in a previously unexplored area.
                'The company knows that it Is possible For them To either find Or Not find oil,
                'but it does Not know the probabilities Of Each Of these outcomes.

                'Once we know the different possible outcomes.
                'we can identify which decision Is best For a particular decision based On their risk aversion.

                'Decision Alternatives : Bonds, Stocks, Mutual Funds
                'States of nature : Growing, Stable, Declining

                Private mMaxiMaxDecision As New Outcome

                Private mMaxiMinDecision As New Outcome

                Private mMinMaxDecision As New Outcome

                Private mPayoffTable As New List(Of DecisionOption)

                ''' <summary>
                ''' Creates and empty class ready for manual population and interrogation
                ''' </summary>
                Public Sub New()

                End Sub

                ''' <summary>
                ''' Generates a Set of decisions (outcomes) as well as updating the payoff table supplied
                ''' with a regret table
                ''' </summary>
                ''' <param name="PayoffTable">a populated payoff table</param>
                Public Sub New(ByRef PayoffTable As List(Of DecisionOption))
                    mMinMaxDecision = MinMax(PayoffTable)
                    mMaxiMaxDecision = MaxiMax(PayoffTable)
                    mMaxiMinDecision = MaxiMin(PayoffTable)
                    mPayoffTable = DecisionOption.GenerateRegretTable(PayoffTable)
                End Sub

                ''' <summary>
                ''' maximax criterion (the optimistic (aggressive)) Select the course Of action with the
                ''' best return (maximum)
                ''' </summary>
                ''' <returns></returns>
                Public ReadOnly Property MaxiMaxDecision As Outcome
                    Get
                        Return mMaxiMaxDecision
                    End Get
                End Property

                ''' <summary>
                ''' maximin criterion (the pessimistic(conservative)) Select the course Of action whose
                ''' worst (maximum) loss Is better than the least (minimum) loss Of all other courses Of
                ''' action possible
                ''' </summary>
                ''' <returns></returns>
                Public ReadOnly Property MaxiMinDecision As Outcome
                    Get
                        Return mMaxiMinDecision
                    End Get
                End Property

                ''' <summary>
                ''' minimax regret criterion : Minimax (Opportunist) The minimization Of regret that Is
                ''' highest When one decision has been made instead Of another.
                ''' </summary>
                ''' <returns></returns>
                Public ReadOnly Property MinMaxDecision As Outcome
                    Get
                        Return mMinMaxDecision
                    End Get
                End Property

                ''' <summary>
                ''' Payoff table in the class
                ''' </summary>
                ''' <returns></returns>
                Public ReadOnly Property PayoffTable As List(Of DecisionOption)
                    Get
                        Return mPayoffTable
                    End Get

                End Property

                'maximax criterion (the optimistic (aggressive))
                'In decision theory, the optimistic (aggressive) decision making rule under conditions of uncertainty.
                'It states that the decision maker should Select the course Of action whose best (maximum)
                'gain Is better than the best gain Of all other courses Of action possible In given circumstances.
                ''' <summary>
                ''' The maximax payoff criterion: Is an optimistic payoff criterion. Using this criterion,
                ''' you Do the following
                ''' 1. Calculate the maximum payoff for each action.
                ''' 2. Choose the action that has the highest of these maximum payoffs.
                ''' </summary>
                ''' <param name="DecisionMatrix">
                ''' Payoff Table (list of decision options and thier potential outcomes)
                ''' </param>
                ''' <returns></returns>
                Public Function MaxiMax(ByRef DecisionMatrix As List(Of DecisionOption)) As Outcome
                    '1. Find the minimum payoff for each action.
                    Dim MaxOutcomes As New List(Of Outcome)
                    MaxOutcomes = DecisionOption.ReturnMaxOutcomes(DecisionMatrix)

                    '2. Choose the action that has the highest of these maximum payoffs.
                    Dim DeterminedOutcome As New Outcome
                    DeterminedOutcome = Outcome.SelectMaxPayoff(MaxOutcomes)

                    'Returns highest potential outcome of all options
                    Return DeterminedOutcome
                End Function

                'maximin criterion (the pessimistic(conservative))
                'In decision theory, the pessimistic (conservative) decision making rule under conditions of uncertainty.
                'It states that the decision maker should Select the course Of action whose worst (maximum)
                'loss Is better than the least (minimum) loss Of all other courses Of action possible In given circumstances
                ''' <summary>
                ''' The maximin payoff criterion: Is a pessimistic payoff criterion. Using this criterion,
                ''' you Do the following:
                ''' 1. Calculate the minimum payoff for each action.
                ''' 2. Choose the action that has the highest of these minimum payoffs.
                ''' </summary>
                ''' <param name="DecisionMatrix">
                ''' Payoff Table (list of decision options and thier potential outcomes)
                ''' </param>
                ''' <returns>highest minimum payoff</returns>
                Public Function MaxiMin(ByRef DecisionMatrix As List(Of DecisionOption)) As Outcome

                    '1. Find the minimum payoff for each action.
                    Dim MaxOutcomes As New List(Of Outcome)
                    MaxOutcomes = DecisionOption.ReturnMinOutcomes(DecisionMatrix)

                    '2. Choose the action that has the highest of these maximum payoffs.
                    Dim DeterminedOutcome As New Outcome
                    DeterminedOutcome = Outcome.SelectMaxPayoff(MaxOutcomes)

                    'Returns highest potential outcome of all options
                    Return DeterminedOutcome
                End Function

                'minimax regret criterion : Minimax (Opportunist)
                'In decision theory, (Opportunist) The minimization Of regret that Is highest When one decision has been made instead Of another.
                'In a situation In which a decision has been made that causes the expected payoff Of an Event To be less than expected,
                'this criterion encourages the avoidance Of regret. also called opportunity loss.
                ''' <summary>
                ''' minimax regret criterion : Minimax (Opportunist) The minimization Of regret that Is
                ''' highest When one decision has been made instead Of another. In a situation In which a
                ''' decision has been made that causes the expected payoff Of an Event To be less than
                ''' expected, this criterion encourages the avoidance Of regret. also called opportunity loss.
                ''' </summary>
                ''' <param name="DecisionMatrix"></param>
                ''' <returns></returns>
                Public Function MinMax(ByRef DecisionMatrix As List(Of DecisionOption)) As Outcome
                    Dim DeterminedOutcome As Outcome
                    'Generate regret table
                    Dim RegretMatrix As New List(Of DecisionOption)
                    RegretMatrix = DecisionOption.GenerateRegretTable(DecisionMatrix)
                    'Select MaxRegret
                    DeterminedOutcome = DecisionOption.SelectMaxRegret(RegretMatrix)
                    'Returns highest potential outcome of all options
                    Return DeterminedOutcome
                End Function

                ''' <summary>
                ''' Decision option and its list of potential outcomes and payoffs a list of these options
                ''' complete a payoff table
                ''' </summary>
                Public Structure DecisionOption

                    ''' <summary>
                    ''' Decision Alternative
                    ''' </summary>
                    Dim Name As String

                    ''' <summary>
                    ''' states of nature
                    ''' </summary>
                    Dim PotentialOutcomes As List(Of Outcome)

                    ''' <summary>
                    ''' Returns a Regret matrix (opportunity loss matrix)
                    ''' </summary>
                    ''' <param name="DecisionMatrix">Payoff table requiring Regret table</param>
                    ''' <returns>Regret Matrix / Opportunity loss payyoff table</returns>
                    Public Shared Function GenerateRegretTable(ByRef DecisionMatrix As List(Of DecisionOption)) As List(Of DecisionOption)
                        Dim Payoff As Integer = 0
                        Dim MaxPayoff As New Outcome
                        Dim Regret As Integer = 0

                        'Generate Regret Table
                        For Each decOption As DecisionOption In DecisionMatrix
                            'Find Max in row
                            MaxPayoff = Outcome.SelectMaxPayoff(decOption.PotentialOutcomes)
                            'Calculate regret for Row
                            For Each PotOutcome As Outcome In decOption.PotentialOutcomes
                                'Calc regret for outcome
                                Regret = MaxPayoff.Payoff - PotOutcome.Payoff
                                PotOutcome.Regret = Regret
                            Next
                        Next
                        'Return Regret table
                        Return DecisionMatrix
                    End Function

                    ''' <summary>
                    ''' Returns the highest payoffs for each row of table
                    ''' </summary>
                    ''' <param name="DecisionMatrix">Payoff table</param>
                    ''' <returns>Highest payoff outcomes for each row</returns>
                    Public Shared Function ReturnMaxOutcomes(ByRef DecisionMatrix As List(Of DecisionOption)) As List(Of Outcome)
                        Dim MaxOptionFound As New Outcome
                        Dim PotentialOutcomes As New List(Of Outcome)

                        'For each row
                        For Each DecOption As DecisionOption In DecisionMatrix
                            'select highest outcome in row
                            MaxOptionFound = Outcome.SelectMaxPayoff(DecOption.PotentialOutcomes)
                            'Add Row
                            PotentialOutcomes.Add(MaxOptionFound)
                        Next

                        'List of Highest Outcomes
                        Return PotentialOutcomes
                    End Function

                    ''' <summary>
                    ''' Returns the min outcomes for each Row
                    ''' </summary>
                    ''' <param name="DecisionMatrix">PayOff Table</param>
                    ''' <returns>List of lowest payoffs for each row</returns>
                    Public Shared Function ReturnMinOutcomes(ByRef DecisionMatrix As List(Of DecisionOption)) As List(Of Outcome)
                        Dim MinOptionFound As New Outcome
                        Dim PotentialOutcomes As New List(Of Outcome)

                        'For each row
                        For Each DecOption As DecisionOption In DecisionMatrix
                            'select Lowest outcome in row
                            MinOptionFound = Outcome.SelectMinPayoff(DecOption.PotentialOutcomes)
                            'Add Row
                            PotentialOutcomes.Add(MinOptionFound)
                        Next

                        'List of Lowest Outcomes
                        Return PotentialOutcomes
                    End Function

                    ''' <summary>
                    ''' Given a list of options Selects the outcome with the highest payoff Essentially a
                    ''' collection of rows
                    ''' </summary>
                    ''' <param name="DecisionMatrix">
                    ''' a list of decision options(rows), a decision is a row, each decision has a set of
                    ''' options, Each option has payoffs / Value
                    ''' </param>
                    ''' <returns>Single outcome (outcome with the highest payoff in the table of options</returns>
                    Public Shared Function SelectMaxPayoff(ByRef DecisionMatrix As List(Of DecisionOption)) As Outcome
                        'Temp outcome
                        Dim mDeterminedOutcome As New Outcome
                        'Highest outcome
                        Dim DeterminedOutcome As New Outcome
                        'highest payoff
                        Dim Payoff As Integer = 0

                        For Each DecOpt In DecisionMatrix
                            'Select Max payoff for Potential outcomes for option
                            mDeterminedOutcome = Outcome.SelectMaxPayoff(DecOpt.PotentialOutcomes)
                            'Check if maximum payoff is greater than existing payoff found
                            If mDeterminedOutcome.Payoff > Payoff = True Then
                                'Greater ?
                                DeterminedOutcome = mDeterminedOutcome
                            Else
                                'Must be lesser
                            End If
                            'Check next option
                        Next
                        'Returns highest potential outcome of all options
                        Return DeterminedOutcome
                    End Function

                    ''' <summary>
                    ''' Returns the Highest outcome in the regret table
                    ''' </summary>
                    ''' <param name="RegretMatrix"></param>
                    ''' <returns>single outcome (highest regret integer</returns>
                    Public Shared Function SelectMaxRegret(ByRef RegretMatrix As List(Of DecisionOption)) As Outcome
                        'Temp outcome
                        Dim mDeterminedOutcome As New Outcome
                        'Highest outcome
                        Dim DeterminedOutcome As New Outcome
                        'highest payoff
                        Dim Regret As Integer = 0

                        For Each DecOpt In RegretMatrix
                            'Select Max payoff for Potential outcomes for option
                            mDeterminedOutcome = Outcome.SelectMaxRegret(DecOpt.PotentialOutcomes)
                            'Check if maximum payoff is greater than existing payoff found
                            If mDeterminedOutcome.Regret > Regret = True Then
                                'Greater ?
                                DeterminedOutcome = mDeterminedOutcome
                            Else
                                'Must be lesser
                            End If
                            'Check next option
                        Next
                        'Returns highest potential outcome of all options
                        Return DeterminedOutcome
                    End Function

                    ''' <summary>
                    ''' Given a list of options Selects the outcome with the Lowest payoff Esentially a
                    ''' collection of rows
                    ''' </summary>
                    ''' <param name="DecisionMatrix">
                    ''' a list of decision options(rows), a decision is a row, each decision has a set of
                    ''' options, Each option has payoffs / Value
                    ''' </param>
                    ''' <returns>Single outcome (outcome with the Lowest payoff in the table of options</returns>
                    Public Shared Function SelectMinPayoff(ByRef DecisionMatrix As List(Of DecisionOption)) As Outcome
                        'Temp outcome
                        Dim mDeterminedOutcome As New Outcome
                        'Lowest outcome
                        Dim DeterminedOutcome As New Outcome
                        'highest payoff
                        Dim Payoff As Integer = 0

                        For Each DecOpt In DecisionMatrix
                            'Select Max payoff for Potential outcomes for option
                            mDeterminedOutcome = Outcome.SelectMinPayoff(DecOpt.PotentialOutcomes)
                            'Check if maximum payoff is greater than existing payoff found
                            If mDeterminedOutcome.Payoff < Payoff = True Then
                                'Greater ?
                                DeterminedOutcome = mDeterminedOutcome
                            Else
                                'Must be lesser
                            End If
                            'Check next option
                        Next
                        'Returns highest potential outcome of all options
                        Return DeterminedOutcome
                    End Function

                    ''' <summary>
                    ''' Adds Row to Payoff table supplied
                    ''' </summary>
                    ''' <param name="Name">Row name</param>
                    ''' <param name="DecisionOutcomes">Outcomes for row</param>
                    ''' <param name="PayoffTable">Table to be updated</param>
                    ''' <returns>updated payoff Table</returns>
                    Public Function AddRow(ByRef Name As String, ByRef DecisionOutcomes As List(Of Outcome), ByRef PayoffTable As List(Of DecisionOption)) As List(Of DecisionOption)
                        Dim NewDecisionOption As New DecisionOption
                        NewDecisionOption.Name = Name
                        NewDecisionOption.PotentialOutcomes = DecisionOutcomes
                        PayoffTable.Add(NewDecisionOption)

                        Return PayoffTable
                    End Function

                End Structure

                ''' <summary>
                ''' 'State of Nature(outcome) Outcome and its payoff. the amount (value of outcome) is used
                ''' to calculate the payoff
                ''' </summary>
                Public Structure Outcome

                    ''' <summary>
                    ''' Expected amount
                    ''' </summary>
                    Dim Amount As Integer

                    ''' <summary>
                    ''' State of Nature
                    ''' </summary>
                    Dim Name As String

                    ''' <summary>
                    ''' Expected PayOff
                    ''' </summary>
                    Dim Payoff As Integer

                    ''' <summary>
                    ''' Expected regret if chosen and other is more profitable
                    ''' </summary>
                    Dim Regret As Integer

                    ''' <summary>
                    ''' Given a list of potential outcomes select the outcome with the highest payoff
                    ''' Essentially a Single row in the table
                    ''' </summary>
                    ''' <param name="PotentialOutcomes">a list of outcomes</param>
                    ''' <returns>Single outcome (outcome with the highest payoff in the list of outcome</returns>
                    Public Shared Function SelectMaxPayoff(ByRef PotentialOutcomes As List(Of Outcome)) As Outcome
                        Dim DeterminedOutcome As New Outcome
                        Dim Payoff As Integer = 0

                        For Each PotOutcome In PotentialOutcomes

                            'Find Max Payoff
                            If Payoff < PotOutcome.Payoff = True Then
                                Payoff = PotOutcome.Payoff
                                'save payoff
                                DeterminedOutcome = PotOutcome
                            Else
                            End If

                        Next

                        Return DeterminedOutcome
                    End Function

                    Public Shared Function SelectMaxRegret(ByRef PotentialOutcomes As List(Of Outcome)) As Outcome
                        Dim DeterminedOutcome As New Outcome
                        Dim Regret As Integer = 0

                        For Each PotOutcome In PotentialOutcomes

                            'Find Max Regret
                            If Regret < PotOutcome.Regret = True Then
                                Regret = PotOutcome.Regret
                                'save payoff
                                DeterminedOutcome = PotOutcome
                            Else
                            End If

                        Next

                        Return DeterminedOutcome
                    End Function

                    ''' <summary>
                    ''' Given a list of potential outcomes select the outcome with the Lowest payoff
                    ''' Essentially a Single row in the table
                    ''' </summary>
                    ''' <param name="PotentialOutcomes">a list of outcomes</param>
                    ''' <returns>Single outcome (outcome with the Lowest payoff in the list of outcome</returns>
                    Public Shared Function SelectMinPayoff(ByRef PotentialOutcomes As List(Of Outcome)) As Outcome
                        Dim DeterminedOutcome As New Outcome
                        Dim Payoff As Integer = 0

                        For Each PotOutcome In PotentialOutcomes

                            'Find Min Payoff
                            If Payoff < PotOutcome.Payoff = True Then
                                Payoff = PotOutcome.Payoff
                                'save payoff
                                DeterminedOutcome = PotOutcome
                            Else
                            End If

                        Next

                        Return DeterminedOutcome
                    End Function

                    ''' <summary>
                    ''' Adds a new Outcome to the List of Outcomes supplied
                    ''' </summary>
                    ''' <param name="Name">Name of Outcome</param>
                    ''' <param name="PayOff">Payoff of O</param>
                    ''' <param name="DecisionOutcomes">List of Outcomes to have new Outcome added to</param>
                    ''' <returns>Updated List of Outcomes</returns>
                    Public Function AddOutcome(ByRef Name As String, ByRef PayOff As Integer, ByRef DecisionOutcomes As List(Of Outcome)) As List(Of Outcome)
                        Dim mOutcome = New Outcome
                        mOutcome.Name = Name
                        mOutcome.Payoff = PayOff
                        DecisionOutcomes.Add(mOutcome)
                        Return DecisionOutcomes
                    End Function

                End Structure

                'Payoff tables are a simple way of showing the different possible scenarios and their respective payoffs -
                'i.e. the profit or loss of each.
                'Maximax, maximin And minimax regret are different perspectives that can be applied to payoff tables.
            End Class

            ''' <summary>
            ''' Used To Hold Risk Evaluation Data
            ''' </summary>
            Public Structure RiskNode

                Private mCost As Integer

                Private mExpectedMonetaryValue As Integer

                Private mExpectedMonetaryValueWithOutPerfectInformation As Integer

                Private mExpectedMonetaryValueWithPerfectInformation As Integer

                Private mGain As Integer

                Private mProbability As Integer

                Private mRegret As Integer

                Public Property Cost As Integer
                    Get
                        Return mCost
                    End Get
                    Set(value As Integer)
                        mCost = value
                    End Set
                End Property

                Public Property ExpectedMonetaryValue As Integer
                    Get
                        Return mExpectedMonetaryValue
                    End Get
                    Set(value As Integer)
                        mExpectedMonetaryValue = value
                    End Set
                End Property

                Public Property ExpectedMonetaryValueWithOutPerfectInformation As Integer
                    Get
                        Return mExpectedMonetaryValueWithOutPerfectInformation
                    End Get
                    Set(value As Integer)
                        mExpectedMonetaryValueWithOutPerfectInformation = value
                    End Set
                End Property

                Public Property ExpectedMonetaryValueWithPerfectInformation As Integer
                    Get
                        Return mExpectedMonetaryValueWithPerfectInformation
                    End Get
                    Set(value As Integer)
                        mExpectedMonetaryValueWithPerfectInformation = value
                    End Set
                End Property

                Public Property Gain As Integer
                    Get
                        Return mGain
                    End Get
                    Set(value As Integer)
                        mGain = value
                    End Set
                End Property

                Public Property Probability As Integer
                    Get
                        Return mProbability
                    End Get
                    Set(value As Integer)
                        mProbability = value
                    End Set
                End Property

                Public Property Regret As Integer
                    Get
                        Return mRegret
                    End Get
                    Set(value As Integer)
                        mRegret = value
                    End Set
                End Property

            End Structure

        End Namespace



        Namespace Sets

            ''' <summary>
            ''' Venn Diagrams (Set theory)
            ''' </summary>
            Public Class Venn

                Public GroupSet As List(Of VennSet)

                'Three Rules
                Public Function AIntersectB(ByRef A_CircleSet As VennSet, ByRef B_CircleSet As VennSet) As VennSet
                    Dim UnionSet As New VennSet
                    UnionSet.Name = A_CircleSet.Name & "Intersect" & B_CircleSet.Name

                    For Each ItemA As VennSet.VennItem In A_CircleSet.Items
                        For Each ItemB As VennSet.VennItem In B_CircleSet.Items
                            If ItemB.ItemName = ItemA.ItemName = True Then
                                UnionSet.Items.Add(ItemB)
                            End If
                        Next
                    Next
                    Return UnionSet
                End Function

                Public Function ANotB(ByRef A_CircleSet As VennSet, ByRef B_CircleSet As VennSet) As VennSet
                    Dim UnionSet As New VennSet
                    UnionSet.Name = A_CircleSet.Name & "Not" & B_CircleSet.Name
                    Dim found As Boolean
                    For Each ItemA As VennSet.VennItem In A_CircleSet.Items
                        found = False
                        For Each ItemB As VennSet.VennItem In B_CircleSet.Items
                            If ItemB.ItemName = ItemA.ItemName = True Then
                                found = True
                            Else

                            End If
                        Next
                        If found = False Then UnionSet.Items.Add(ItemA)
                    Next
                    Return UnionSet
                End Function

                Public Function AUnionB(ByRef A_CircleSet As VennSet, ByRef B_CircleSet As VennSet) As VennSet
                    Dim UnionSet As New VennSet
                    UnionSet.Name = A_CircleSet.Name & "Union" & B_CircleSet.Name
                    For Each ItemA As VennSet.VennItem In A_CircleSet.Items
                        UnionSet.Items.Add(ItemA)
                    Next
                    For Each Itemb As VennSet.VennItem In B_CircleSet.Items
                        UnionSet.Items.Add(Itemb)
                    Next
                    Return UnionSet
                End Function

                'Probability

                Private Function CountItemsInGroupSet(ByRef mGroupSet As List(Of VennSet)) As Integer
                    Dim count As Integer = 0
                    For Each mCircleset As VennSet In mGroupSet
                        For Each item As VennSet.VennItem In mCircleset.Items
                            count += 1
                        Next
                    Next
                    Return count
                End Function

                Private Function CountItemsInSet(ByRef mCircleSet As VennSet) As Integer
                    Dim count As Integer = 0
                    For Each item As VennSet.VennItem In mCircleSet.Items
                        count += 1
                    Next
                    Return count
                End Function

                Public Structure VennSet

                    Public Items As List(Of VennItem)

                    Public Name As String

                    Public Probability As Integer

                    Public Structure VennItem

                        Public ItemBoolean As Boolean
                        Public ItemName As String
                        Public ItemValue As Integer

                    End Structure

                End Structure

            End Class

        End Namespace

    End Namespace
    Public Module Maths

        'Math Functions

        ''' <summary>
        ''' COMMENTS : RETURNS THE INVERSE COSECANT OF THE SUPPLIED NUMBER '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE ' RETURNS : INVERSE COSECANT AS A DOUBLE
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>DBLIN - VALUE TO CALCULATE ' RETURNS : INVERSE COSECANT AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function ARCCOSECANT(ByVal DBLIN As Double) As Double

            ' '
            Const CDBLPI As Double = 3.14159265358979

            On Error GoTo PROC_ERR

            ARCCOSECANT = Math.Atan(DBLIN / Math.Sqrt(DBLIN * DBLIN - 1)) +
                (Math.Sign(DBLIN) - 1) * CDBLPI / 2

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(ARCCOSECANT))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS: RETURNS THE ARC COSINE OF THE SUPPLIED NUMBER '
        ''' PARAMETERS: DBLIN -Number TO RUN ON ' RETURNS : ARC COSINE AS A DOUBLE
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>DBLIN -Number TO RUN ON ' RETURNS : ARC COSINE AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function ARCCOSINE(ByVal DBLIN As Double) As Double

            Const CDBLPI As Double = 3.14159265358979

            On Error GoTo PROC_ERR

            Select Case DBLIN
                Case 1
                    ARCCOSINE = 0

                Case -1
                    ARCCOSINE = -CDBLPI

                Case Else
                    ARCCOSINE = Math.Atan(DBLIN / Math.Sqrt(-DBLIN * DBLIN + 1)) + CDBLPI / 2

            End Select

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(ARCCOSINE))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS: RETURNS THE INVERSE COTANGENT Of THE SUPPLIED NUMBER '
        ''' PARAMETERS: DBLIN -VALUE TO CALCULATE ' RETURNS : INVERSE COTANGENT AS A DOUBLE
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>INVERSE COTANGENT AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function ARCCOTANGENT(ByVal DBLIN As Double) As Double

            Const CDBLPI As Double = 3.14159265358979

            On Error GoTo PROC_ERR

            ARCCOTANGENT = Math.Atan(DBLIN) + CDBLPI / 2

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(ARCCOTANGENT))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE INVERSE SECANT OF THE SUPPLIED NUMBER '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE ' RETURNS : INVERSE SECANT AS A DOUBLE ' '
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>DBLIN - VALUE TO CALCULATE ' RETURNS : INVERSE SECANT AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function ARCSECANT(ByVal DBLIN As Double) As Double

            Const CDBLPI As Double = 3.14159265358979

            On Error GoTo PROC_ERR

            ARCSECANT = Math.Atan(DBLIN / Math.Sqrt(DBLIN * DBLIN - 1)) +
                Math.Sign(Math.Sign(DBLIN) - 1) * CDBLPI / 2

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(ARCSECANT))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE INVERSE SINE OF THE SUPPLIED NUMBER '
        ''' PARAMETERS:  ' '
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>DBLIN - VALUE TO CALCULATE ' RETURNS : INVERSE SINE AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function ARCSINE(ByVal DBLIN As Double) As Double

            Const CDBLPI As Double = 3.14159265358979

            On Error GoTo PROC_ERR

            Select Case DBLIN

                Case 1
                    ARCSINE = CDBLPI / 2

                Case -1
                    ARCSINE = -CDBLPI / 2

                Case Else
                    ARCSINE = Math.Atan(DBLIN / Math.Sqrt(-DBLIN ^ 2 + 1))

            End Select

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(ARCSINE))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE INVERSE TANGENT OF THE SUPPLIED NUMBERS. ' NOTE THAT BOTH VALUES
        ''' CANNOT BE ZERO. '
        ''' PARAMETERS: DBLIN - FIRST VALUE ' DBLIN2 - SECOND VALUE ' RETURNS : INVERSE TANGENT AS A
        '''             DOUBLE ' '
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <param name="DBLIN2"></param>
        ''' <returns>RETURNS : INVERSE TANGENT AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function ARCTANGENT(ByVal DBLIN As Double, ByVal DBLIN2 As Double) As Double

            Const CDBLPI As Double = 3.14159265358979

            On Error GoTo PROC_ERR

            Select Case DBLIN

                Case 0

                    Select Case DBLIN2
                        Case 0
                            ' UNDEFINED '
                            ARCTANGENT = 0
                        Case Is > 0
                            ARCTANGENT = CDBLPI / 2
                        Case Else
                            ARCTANGENT = -CDBLPI / 2
                    End Select

                Case Is > 0
                    ARCTANGENT = If(DBLIN2 = 0, 0, Math.Atan(DBLIN2 / DBLIN))
                Case Else
                    ARCTANGENT = If(DBLIN2 = 0, CDBLPI, (CDBLPI - Math.Atan(Math.Abs(DBLIN2 / DBLIN))) * Math.Sign(DBLIN2))
            End Select

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(ARCTANGENT))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE COSECANT OF THE SUPPLIED NUMBER. ' NOTE THAT SIN(DBLIN) CANNOT
        ''' EQUAL ZERO. THIS CAN ' HAPPEN IF DBLIN IS A MULTIPLE OF CDBLPI. '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE ' RETURNS : COSECANT AS A DOUBLE ' '
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>DBLIN - VALUE TO CALCULATE ' RETURNS : COSECANT AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function COSECANT(ByVal DBLIN As Double) As Double

            On Error GoTo PROC_ERR

            COSECANT = If(Math.Sin(DBLIN) = 0, 0, 1 / Math.Sin(DBLIN))

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(COSECANT))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE COTANGENT OF THE SUPPLIED NUMBER ' FUNCTION IS UNDEFINED IF INPUT
        ''' VALUE IS A MULTIPLE OF CDBLPI. '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE ' RETURNS : COTANGENT AS A DOUBLE
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>COTANGENT AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function COTANGENT(ByVal DBLIN As Double) As Double

            On Error GoTo PROC_ERR

            COTANGENT = If(Math.Tan(DBLIN) = 0, 0, 1 / Math.Tan(DBLIN))

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(COTANGENT))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE INVERSE HYPERBOLIC COSECANT OF THE ' SUPPLIED NUMBER '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE ' RETURNS : HYPERBOLIC INVERSE COSECANT AS A DOUBLE
        ''' </summary>
        ''' <param name="DBLIN">- VALUE TO CALCULATE</param>
        ''' <returns>HYPERBOLIC INVERSE COSECANT AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function HYPERBOLICARCCOSECANT(ByVal DBLIN As Double) As Double

            On Error GoTo PROC_ERR

            HYPERBOLICARCCOSECANT = Math.Log((Math.Sign(DBLIN) *
                Math.Sqrt(DBLIN * DBLIN + 1) + 1) / DBLIN)

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(HYPERBOLICARCCOSECANT))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE INVERSE HYPERBOLIC COSINE OF THE ' SUPPLIED NUMBER '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>RETURNS : INVERSE HYPERBOLIC COSINE AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function HYPERBOLICARCCOSINE(ByVal DBLIN As Double) As Double

            On Error GoTo PROC_ERR

            HYPERBOLICARCCOSINE = Math.Log(DBLIN + Math.Sqrt(DBLIN * DBLIN - 1))

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(HYPERBOLICARCCOSINE))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE INVERSE HYPERBOLIC TANGENT OF THE ' SUPPLIED NUMBER. UNDEFINED IF
        ''' DBLIN IS 1 '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>INVERSE HYPERBOLIC TANGENT AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function HYPERBOLICARCCOTANGENT(ByVal DBLIN As Double) As Double

            On Error GoTo PROC_ERR

            HYPERBOLICARCCOTANGENT = Math.Log((DBLIN + 1) / (DBLIN - 1)) / 2

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(HYPERBOLICARCCOTANGENT))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE INVERSE HYPERBOLIC SECANT OF THE ' SUPPLIED NUMBER '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>RETURNS : INVERSE HYPERBOLIC SECANT AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function HYPERBOLICARCSECANT(ByVal DBLIN As Double) As Double

            On Error GoTo PROC_ERR

            HYPERBOLICARCSECANT = Math.Log((Math.Sqrt(-DBLIN ^ 2 + 1) + 1) / DBLIN)

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(HYPERBOLICARCSECANT))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE INVERSE HYPERBOLIC SINE OF THE SUPPLIED NUMBER '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE ' RETURNS : INVERSE HYPERBOLIC SINE AS A DOUBLE
        ''' </summary>
        ''' <param name="DBLIN">VALUE TO CALCULATE</param>
        ''' <returns>INVERSE HYPERBOLIC SINE AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function HYPERBOLICARCSINE(ByVal DBLIN As Double) As Double

            On Error GoTo PROC_ERR

            HYPERBOLICARCSINE = Math.Log(DBLIN + Math.Sqrt(DBLIN ^ 2 + 1))

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(HYPERBOLICARCSINE))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE INVERSE HYPERBOLIC TANGENT OF THE ' SUPPLIED NUMBER. THE RETURN
        ''' VALUE IS UNDEFINED IF ' INPUT VALUE IS 1. '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE ' RETURNS : INVERSE HYPERBOLIC TANGENT AS A
        '''             DOUBLE '
        ''' </summary>
        ''' <param name="DBLIN">VALUE TO CALCULATE</param>
        ''' <returns>
        ''' DBLIN - VALUE TO CALCULATE ' RETURNS : INVERSE HYPERBOLIC TANGENT AS A DOUBLE '
        ''' </returns>
        <Runtime.CompilerServices.Extension()>
        Public Function HYPERBOLICARCTAN(ByVal DBLIN As Double) As Double

            HYPERBOLICARCTAN = Math.Log((1 + DBLIN) / (1 - DBLIN)) / 2

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(HYPERBOLICARCTAN))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE HYPERBOLIC COSECANT OF THE SUPPLIED NUMBER '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE ' RETURNS : HYPERBOLIC COSECANT AS A DOUBLE ' '
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>RETURNS : HYPERBOLIC COSECANT AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function HYPERBOLICCOSECANT(ByVal DBLIN As Double) As Double

            On Error GoTo PROC_ERR

            HYPERBOLICCOSECANT = 2 / (Math.Exp(DBLIN) - Math.Exp(-DBLIN))

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(HYPERBOLICCOSECANT))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE HYPERBOLIC COSINE OF THE SUPPLIED NUMBER '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE ' RETURNS : HYPERBOLIC COSINE AS A DOUBLE ' '
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>RETURNS : HYPERBOLIC COSINE AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function HYPERBOLICCOSINE(ByVal DBLIN As Double) As Double

            On Error GoTo PROC_ERR

            HYPERBOLICCOSINE = (Math.Exp(DBLIN) + Math.Exp(-DBLIN)) / 2

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(HYPERBOLICCOSINE))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE HYPERBOLIC COTANGENT OF THE SUPPLIED NUMBER '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE ' RETURNS : HYPERBOLIC COTANGENT AS A DOUBLE
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>DBLIN - VALUE TO CALCULATE ' RETURNS : HYPERBOLIC COTANGENT AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function HYPERBOLICCOTANGENT(ByVal DBLIN As Double) As Double

            On Error GoTo PROC_ERR

            HYPERBOLICCOTANGENT = (Math.Exp(DBLIN) + Math.Exp(-DBLIN)) /
                (Math.Exp(DBLIN) - Math.Exp(-DBLIN))

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(HYPERBOLICCOTANGENT))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE HYPERBOLIC SECANT OF THE SUPPLIED NUMBER '
        ''' PARAMETERS: DBLIN - VALUE TO CALCULATE ' RETURNS : HYPERBOLIC SECANT AS A DOUBLE
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>DBLIN - VALUE TO CALCULATE ' RETURNS : HYPERBOLIC SECANT AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function HYPERBOLICSECANT(ByVal DBLIN As Double) As Double

            ' COMMENTS : RETURNS THE HYPERBOLIC SECANT OF THE SUPPLIED NUMBER '
            ' PARAMETERS: DBLIN - VALUE TO CALCULATE ' RETURNS : HYPERBOLIC SECANT AS A DOUBLE ' '
            On Error GoTo PROC_ERR

            HYPERBOLICSECANT = 2 / (Math.Exp(DBLIN) + Math.Exp(-DBLIN))

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(HYPERBOLICSECANT))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS THE HYPERBOLIC SINE OF THE SUPPLIED NUMBER
        ''' </summary>
        ''' <param name="DBLIN"></param>
        ''' <returns>DBLIN - VALUE TO CALCULATE ' RETURNS : HYPERBOLIC SINE AS A DOUBLE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function HYPERBOLICSINE(ByVal DBLIN As Double) As Double

            On Error GoTo PROC_ERR

            HYPERBOLICSINE = (Math.Exp(DBLIN) - Math.Exp(-DBLIN)) / 2

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(HYPERBOLICSINE))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS LOG BASE 10. THE POWER 10 MUST BE RAISED ' TO EQUAL A GIVEN NUMBER.
        ''' LOG BASE 10 IS DEFINED AS THIS: ' X = LOG(Y) WHERE Y = 10 ^ X '
        ''' PARAMETERS: DBLDECIMAL - VALUE TO CALCULATE (Y) ' RETURNS : LOG BASE 10 OF THE GIVEN VALUE
        ''' ' '
        ''' </summary>
        ''' <param name="DBLDECIMAL"></param>
        ''' <returns>
        ''' DBLDECIMAL - VALUE TO CALCULATE (Y) ' RETURNS : LOG BASE 10 OF THE GIVEN VALUE
        ''' </returns>
        <Runtime.CompilerServices.Extension()>
        Public Function LOG10(ByVal DBLDECIMAL As Double) As Double

            On Error GoTo PROC_ERR

            LOG10 = Math.Log(DBLDECIMAL) / Math.Log(10)

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(LOG10))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS LOG BASE 2. THE POWER 2 MUST BE RAISED TO EQUAL ' A GIVEN NUMBER. '
        ''' LOG BASE 2 IS DEFINED AS THIS: ' X = LOG(Y) WHERE Y = 2 ^ X '
        ''' PARAMETERS: DBLDECIMAL - VALUE TO CALCULATE (Y) ' RETURNS : LOG BASE 2 OF A GIVEN NUMBER
        '''             ' '
        ''' </summary>
        ''' <param name="DBLDECIMAL"></param>
        ''' <returns>DBLDECIMAL - VALUE TO CALCULATE (Y) ' RETURNS : LOG BASE 2 OF A GIVEN NUMBER</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function LOG2(ByVal DBLDECIMAL As Double) As Double

            On Error GoTo PROC_ERR

            LOG2 = Math.Log(DBLDECIMAL) / Math.Log(2)

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(LOG2))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' COMMENTS : RETURNS LOG BASE N. THE POWER N MUST BE RAISED TO EQUAL ' A GIVEN NUMBER. '
        ''' LOG BASE N IS DEFINED AS THIS: ' X = LOG(Y) WHERE Y = N ^ X ' PARAMETERS:
        ''' </summary>
        ''' <param name="DBLDECIMAL"></param>
        ''' <param name="DBLBASEN"></param>
        ''' <returns>DBLDECIMAL - VALUE TO CALCULATE (Y) ' DBLBASEN - BASE ' RETURNS : LOG BASE</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function LOGN(ByVal DBLDECIMAL As Double, ByVal DBLBASEN As Double) As Double

            ' N OF A GIVEN NUMBER '

            On Error GoTo PROC_ERR

            LOGN = Math.Log(DBLDECIMAL) / Math.Log(DBLBASEN)

PROC_EXIT:
            Exit Function

PROC_ERR:
            MsgBox("ERROR: " & Err.Number & ". " & Err.Description, ,
                NameOf(LOGN))
            Resume PROC_EXIT

        End Function

        ''' <summary>
        ''' the log-sigmoid function constrains results to the range (0,1), the function is
        ''' sometimes said to be a squashing function in neural network literature. It is the
        ''' non-linear characteristics of the log-sigmoid function (and other similar activation
        ''' functions) that allow neural networks to model complex data.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <returns></returns>
        ''' <remarks>1 / (1 + Math.Exp(-Value))</remarks>
        <Runtime.CompilerServices.Extension()>
        Public Function Sigmoid(ByRef Value As Integer) As Double
            'z = Bias + (Input*Weight)
            'Output = 1/1+e**z
            Return 1 / (1 + Math.Exp(-Value))
        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function SigmoidDerivitive(ByRef Value As Integer) As Double
            Return Sigmoid(Value) * (1 - Sigmoid(Value))
        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function Signum(ByRef Value As Integer) As Double
            'z = Bias + (Input*Weight)
            'Output = 1/1+e**z
            Return Math.Sign(Value)
        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function Logistic(ByRef Value As Double) As Double
            'z = bias + (sum of all inputs ) * (input*weight)
            'output = Sigmoid(z)
            'derivative input = z/weight
            'derivative Weight = z/input
            'Derivative output = output*(1-Output)
            'learning rule = Sum of total training error* derivative input * derivative output * rootmeansquare of errors

            Return 1 / 1 + Math.Exp(-Value)
        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function LogisticDerivative(ByRef Value As Double) As Double
            'z = bias + (sum of all inputs ) * (input*weight)
            'output = Sigmoid(z)
            'derivative input = z/weight
            'derivative Weight = z/input
            'Derivative output = output*(1-Output)
            'learning rule = Sum of total training error* derivative input * derivative output * rootmeansquare of errors

            Return Logistic(Value) * (1 - Logistic(Value))
        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function Gaussian(ByRef x As Double) As Double
            Gaussian = Math.Exp((-x * -x) / 2)
        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function GaussianDerivative(ByRef x As Double) As Double
            GaussianDerivative = Gaussian(x) * (-x / (-x * -x))
        End Function

        'Numerical
        <Runtime.CompilerServices.Extension()>
        Public Function ArithmeticMean(ByRef Elements() As Integer) As Double
            Dim NumberofElements As Integer = 0
            Dim sum As Integer = 0

            'Formula:
            'Mean = sum of elements / number of elements = a1+a2+a3+.....+an/n
            For Each value As Integer In Elements
                NumberofElements = NumberofElements + 1
                sum = value + value
            Next
            ArithmeticMean = sum / NumberofElements
        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function ArithmeticMedian(ByRef Elements() As Integer) As Double
            Dim NumberofElements As Integer = 0
            Dim Position As Integer = 0
            Dim P1 As Integer = 0
            Dim P2 As Integer = 0

            'Count the total numbers given.
            NumberofElements = Elements.Length
            'Arrange the numbers in ascending order.
            Array.Sort(Elements)

            'Formula:Calculate Middle Position

            'Check Odd Even
            If NumberofElements Mod 2 = 0 Then

                'Even:
                'For even average of number at P1 = n/2 and P2= (n/2)+1
                'Then: (P1+P2) / 2
                P1 = NumberofElements / 2
                P2 = (NumberofElements / 2) + 1
                ArithmeticMedian = (Elements(P1) + Elements(P2)) / 2
            Else

                'Odd:
                'For odd (NumberofElements+1)/2
                Position = (NumberofElements + 1) / 2
                ArithmeticMedian = Elements(Position)
            End If

        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function IsSquareRoot(ByVal number As Integer) As Boolean
            Dim numberSquareRooted As Double = Math.Sqrt(number)
            Return If(CInt(numberSquareRooted) ^ 2 = number, True, False)
        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function IsCubeRoot(ByVal number As Integer) As Boolean
            Dim numberCubeRooted As Double = number ^ (1 / 3)
            Return If(CInt(numberCubeRooted) ^ 3 = number, True, False)
        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function IsRoot(ByVal number As Integer, power As Integer) As Boolean
            Dim numberNRooted As Double = number ^ (1 / power)
            Return If(CInt(numberNRooted) ^ power = number, True, False)
        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function Average(ByVal x As List(Of Double)) As Double

            'Takes an average in absolute terms

            Dim result As Double

            For i = 0 To x.Count - 1
                result += x(i)
            Next

            Return result / x.Count

        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function StandardDeviationofSeries(ByVal x As List(Of Double)) As Double

            Dim result As Double
            Dim avg As Double = Average(x)

            For i = 0 To x.Count - 1
                result += Math.Pow((x(i) - avg), 2)
            Next

            result /= x.Count

            Return result

        End Function

        'Statistics
        ''' <summary>
        ''' The average of the squared differences from the Mean.
        ''' </summary>
        ''' <param name="Series"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function Variance(ByRef Series As List(Of Double)) As Double
            Dim TheMean As Double = Mean(Series)

            Dim NewSeries As List(Of Double) = SquaredDifferences(Series)

            'Variance = Average Of the Squared Differences
            Variance = Mean(NewSeries)
        End Function

        ''' <summary>
        ''' squared differences from the Mean.
        ''' </summary>
        ''' <param name="Series"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function SquaredDifferences(ByRef Series As List(Of Double)) As List(Of Double)
            'Results
            Dim NewSeries As New List(Of Double)
            Dim TheMean As Double = Mean(Series)
            For Each item In Series
                'Results
                Dim Difference As Double = 0.0
                Dim NewSum As Double = 0.0
                'For each item Subtract the mean (variance)
                Difference += item - TheMean
                'Square the difference
                NewSum = Square(Difference)
                'Create new series (Squared differences)
                NewSeries.Add(NewSum)
            Next
            Return NewSeries
        End Function

        ''' <summary>
        ''' The Sum of the squared differences from the Mean.
        ''' </summary>
        ''' <param name="Series"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function SumOfSquaredDifferences(ByRef Series As List(Of Double)) As Double
            Dim sum As Double = 0.0
            For Each item In SquaredDifferences(Series)
                sum += item
            Next
            Return sum
        End Function

        ''' <summary>
        ''' Number multiplied by itself
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function Square(ByRef Value As Double) As Double
            Return Value * Value
        End Function

        ''' <summary>
        ''' The avarage of a Series
        ''' </summary>
        ''' <param name="Series"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function Mean(ByRef Series As List(Of Double)) As Double
            Dim Count = Series.Count
            Dim Sum As Double = 0.0
            For Each item In Series

                Sum += item

            Next
            Mean = Sum / Count
        End Function

        ''' <summary>
        ''' The Standard Deviation is a measure of how spread out numbers are.
        ''' </summary>
        ''' <param name="Series"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function StandardDeviation(ByRef Series As List(Of Double)) As Double
            'The Square Root of the variance
            Return Math.Sqrt(Variance(Series))
        End Function

        ''' <summary>
        ''' Returns the Difference Form the Mean
        ''' </summary>
        ''' <param name="Series"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function Difference(ByRef Series As List(Of Double)) As List(Of Double)
            Dim TheMean As Double = Mean(Series)
            Dim NewSeries As New List(Of Double)
            For Each item In Series
                NewSeries.Add(item - TheMean)
            Next
            Return NewSeries
        End Function

        ''' <summary>
        ''' When two sets of data are strongly linked together we say they have a High Correlation.
        ''' Correlation is Positive when the values increase together, and Correlation is Negative
        ''' when one value decreases as the other increases 1 is a perfect positive correlation 0 Is
        ''' no correlation (the values don't seem linked at all)
        ''' -1 Is a perfect negative correlation
        ''' </summary>
        ''' <param name="X_Series"></param>
        ''' <param name="Y_Series"></param>
        <Runtime.CompilerServices.Extension()>
        Public Function Correlation(ByRef X_Series As List(Of Double), ByRef Y_Series As List(Of Double)) As Double

            'Step 1 Find the mean Of x, And the mean of y
            'Step 2: Subtract the mean of x from every x value (call them "a"), do the same for y	(call them "b")
            'Results
            Dim DifferenceX As List(Of Double) = Difference(X_Series)
            Dim DifferenceY As List(Of Double) = Difference(Y_Series)

            'Step 3: Calculate : a*b, XSqu And YSqu for every value
            'Step 4: Sum up ab, sum up a2 And sum up b2
            'Results
            Dim SumXSqu As Double = Sum(Square(DifferenceX))
            Dim SumYSqu As Double = Sum(Square(DifferenceY))
            Dim SumX_Y As Double = Sum(Multiply(X_Series, Y_Series))

            'Step 5: Divide the sum of a*b by the square root of [(SumXSqu) × (SumYSqu)]
            'Results
            Dim Answer As Double = SumX_Y / Math.Sqrt(SumXSqu * SumYSqu)
            Return Answer
        End Function

        Enum CorrelationResult
            Positive = 1
            PositiveHigh = 0.9
            PositiveLow = 0.5
            None = 0
            NegativeLow = -0.5
            NegativeHigh = -0.9
            Negative = -1
        End Enum

        ''' <summary>
        ''' Returns interpretation of Corelation results
        ''' </summary>
        ''' <param name="Correlation"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function InterpretCorrelationResult(ByRef Correlation As Double) As CorrelationResult
            InterpretCorrelationResult = CorrelationResult.None
            If Correlation >= 1 Then
                InterpretCorrelationResult = CorrelationResult.Positive

            End If
            If Correlation > 0.5 And Correlation <= 0.9 Then
                InterpretCorrelationResult = CorrelationResult.PositiveHigh
            End If
            If Correlation > 0 And Correlation <= 0.5 Then
                InterpretCorrelationResult = CorrelationResult.PositiveLow
            End If
            If Correlation = 0 Then InterpretCorrelationResult = CorrelationResult.None
            If Correlation > -0.5 And Correlation <= 0 Then
                InterpretCorrelationResult = CorrelationResult.NegativeLow
            End If
            If Correlation > -0.9 And Correlation <= -0.5 Then
                InterpretCorrelationResult = CorrelationResult.NegativeHigh
            End If
            If Correlation >= -1 Then
                InterpretCorrelationResult = CorrelationResult.Negative
            End If
        End Function

        ''' <summary>
        ''' Sum Series of Values
        ''' </summary>
        ''' <param name="X_Series"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function Sum(ByRef X_Series As List(Of Double)) As Double
            Dim Count As Integer = X_Series.Count
            Dim Ans As Double = 0.0
            For Each i In X_Series
                Ans = +i
            Next
            Return Ans
        End Function

        ''' <summary>
        ''' Multiplys X series by Y series
        ''' </summary>
        ''' <param name="X_Series"></param>
        ''' <param name="Y_Series"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function Multiply(ByRef X_Series As List(Of Double), ByRef Y_Series As List(Of Double)) As List(Of Double)
            Dim Count As Integer = X_Series.Count
            Dim Series As New List(Of Double)
            For i = 1 To Count
                Series.Add(X_Series(i) * Y_Series(i))
            Next
            Return Series
        End Function

        ''' <summary>
        ''' Square Each value in the series
        ''' </summary>
        ''' <param name="Series"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function Square(ByRef Series As List(Of Double)) As List(Of Double)
            Dim NewSeries As New List(Of Double)
            For Each item In Series
                NewSeries.Add(Square(item))
            Next
            Return NewSeries
        End Function

        'Growth

        ''' <summary>
        ''' Basic Growth
        ''' </summary>
        ''' <param name="Past"></param>
        ''' <param name="Present"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function Growth(ByRef Past As Double, ByRef Present As Double) As Double
            Growth = (Present - Past) / Past
        End Function

        ''' <summary>
        ''' Calculating Average Growth Rate Over Regular Time Intervals
        ''' </summary>
        ''' <param name="Series"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function AverageGrowth(ByRef Series As List(Of Double)) As Double
            'GrowthRate = Present / Past / Past
            ' formula: (present) = (past) * (1 + growth rate)n where n = number of time periods.

            'The Average Annual Growth Rate over a number Of years
            'means the average Of the annual growth rates over that number Of years.
            'For example, assume that In 2005, the price has increased over 2004 by 10%, 2004 over 2003 by 15%, And 2003 over 2002 by 5%,
            'then the average annual growth rate from 2002 To 2005 Is (10% + 15% + 5%) / 3 = 10%
            Dim NewSeries As New List(Of Double)
            For i = 1 To Series.Count
                'Calc Each Growth rate
                NewSeries.Add(Growth(Series(i - 1), Series(i)))
            Next
            Return Mean(NewSeries)
        End Function

        ''' <summary>
        ''' Given a series of values Predict Value for interval provided based on AverageGrowth
        ''' </summary>
        ''' <param name="Series"></param>
        ''' <param name="Interval"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function PredictGrowth(ByRef Series As List(Of Double), ByRef Interval As Integer) As Double

            Dim GrowthRate As Double = AverageGrowth(Series)
            Dim Past As Double = Series.Last
            Dim Present As Double = Past
            For i = 1 To Interval
                Past = Present
                Present = Past * GrowthRate
            Next
            Return Present
        End Function

    End Module
End Namespace