Namespace MATH_EXTENSIONS

    Namespace MathsExt

        Namespace LocationalSpace
            ''' <summary>
            ''' Cartesian Corordinate Functions
            ''' Vector of X,Y,Z
            ''' </summary>
            <ComClass(Cartesian.ClassId, Cartesian.InterfaceId, Cartesian.EventsId)>
            <Serializable>
            Public Class Cartesian

                Public Const ClassId As String = "2828B490-7103-401C-7AB3-38FF97BC1AC9"
                Public Const EventsId As String = "CDB74307-F15E-401A-AC6D-3CF8786FD6F1"
                Public Const InterfaceId As String = "8BB745F8-5113-4059-829B-B531310144B5"

                ''' <summary>
                ''' The x component of the Cartesian Co-ordinate
                ''' </summary>
                Public x As Single

                ''' <summary>
                ''' The y component of the Cartesian Co-ordinate
                ''' </summary>
                Public y As Single

                ''' <summary>
                ''' The z component of the Cartesian Co-ordinate
                ''' </summary>
                Public z As Single

                <NonSerialized>
                Private _RandGenerator As RandomFactory

                ''' <summary>
                ''' Constructor for an empty Cartesian: x, y, and z are set to 0.
                ''' </summary>
                Public Sub New()
                    x = 0
                    y = 0
                    z = 0
                    _RandGenerator = New RandomFactory
                End Sub

                ''' <summary>
                ''' Constructor for a 3D Cartesian.
                ''' </summary>
                ''' <param name="x"> the x coordinate. </param>
                ''' <param name="y"> the y coordinate. </param>
                ''' <param name="z"> the z coordinate. </param>
                Public Sub New(ByVal x As Single, ByVal y As Single, ByVal z As Single)
                    Me.New
                    Me.x = x
                    Me.y = y
                    Me.z = z
                End Sub

                ''' <summary>
                ''' Constructor for a 2D Cartesian: z coordinate is set to 0.
                ''' </summary>
                Public Sub New(ByVal x As Single, ByVal y As Single)
                    Me.New
                    Me.x = x
                    Me.y = y
                End Sub

                ''' <summary>
                ''' Subtract one Cartesian from another and store in another Cartesian </summary>
                Public Shared Function [Sub](ByVal v1 As Cartesian, ByVal v2 As Cartesian) As Cartesian
                    Dim target As New Cartesian

                    target.Set(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z)
                    Return target
                End Function

                ''' <summary>
                ''' Add two Cartesians into a target Cartesian </summary>
                Public Shared Function Add(ByVal v1 As Cartesian, ByVal v2 As Cartesian) As Cartesian
                    Dim target As New Cartesian()

                    target.Set(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z)
                    Return target
                End Function

                ''' <summary>
                ''' Calculates and returns the angle (in radians) between two Cartesians.
                ''' </summary>
                ''' <param name="v1"> 1st Cartesian Co-ordinate </param>
                ''' <param name="v2"> 2nd Cartesian Co-ordinate </param>
                Public Shared Function AngleBetween(ByVal v1 As Cartesian, ByVal v2 As Cartesian) As Single
                    Dim dot As Double = v1.x * v2.x + v1.y * v2.y + v1.z * v2.z
                    Dim V1Mag As Double = v1.Magnitude
                    Dim V2Mag As Double = v2.Magnitude
                    Dim Amount As Double = dot / (V1Mag * V2Mag)

                    If v1.x = 0 AndAlso v1.y = 0 AndAlso v1.z = 0 Then
                        Return 0.0F
                    End If
                    If v2.x = 0 AndAlso v2.y = 0 AndAlso v2.z = 0 Then
                        Return 0.0F
                    End If
                    If Amount <= -1 Then
                        Return Math.PI
                    ElseIf Amount >= 1 Then
                        Return 0
                    End If
                    Return CSng(Math.Acos(Amount))
                End Function

                ''' <param name="v1"> any variable of type Cartesian </param>
                ''' <param name="v2"> any variable of type Cartesian </param>
                Public Shared Function Cross(ByVal v1 As Cartesian, ByVal v2 As Cartesian) As Cartesian
                    Dim target As New Cartesian
                    Dim crossX As Single = v1.y * v2.z - v2.y * v1.z
                    Dim crossY As Single = v1.z * v2.x - v2.z * v1.x
                    Dim crossZ As Single = v1.x * v2.y - v2.x * v1.y

                    target.Set(crossX, crossY, crossZ)
                    Return target
                End Function

                ''' <param name="v1"> any variable of type Cartesian </param>
                ''' <param name="v2"> any variable of type Cartesian </param>
                ''' <returns> the Euclidean distance between v1 and v2 </returns>
                Public Shared Function Distance(ByVal v1 As Cartesian, ByVal v2 As Cartesian) As Single
                    Dim dx As Single = v1.x - v2.x
                    Dim dy As Single = v1.y - v2.y
                    Dim dz As Single = v1.z - v2.z
                    Return CSng(Math.Sqrt(dx * dx + dy * dy + dz * dz))
                End Function

                ''' <summary>
                ''' Divide a Cartesian by a scalar and store the result in another Cartesian. </summary>
                Public Shared Function Div(ByVal v As Cartesian, ByVal n As Single) As Cartesian
                    Dim target As New Cartesian

                    target.Set(v.x / n, v.y / n, v.z / n)

                    Return target
                End Function

                ''' <param name="v1"> any variable of type Cartesian </param>
                ''' <param name="v2"> any variable of type Cartesian </param>
                Public Shared Function Dot(ByVal v1 As Cartesian, ByVal v2 As Cartesian) As Single
                    Return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z
                End Function

                ''' <summary>
                ''' Linear interpolate between two Cartesians (returns a new Cartesian object) </summary>
                ''' <param name="v1"> the Cartesian to start from </param>
                ''' <param name="v2"> the Cartesian to lerp to </param>
                Public Shared Function Lerp(ByVal v1 As Cartesian, ByVal v2 As Cartesian, ByVal Amount As Single) As Cartesian
                    Dim v As Cartesian = v1.Copy()
                    v.Lerp(v2, Amount)
                    Return v
                End Function

                ''' <summary>
                ''' Multiply a Cartesian by a scalar, and write the result into a target Cartesian. </summary>
                Public Shared Function Mult(ByVal v As Cartesian, ByVal n As Single) As Cartesian
                    Dim target As New Cartesian

                    target.Set(v.x * n, v.y * n, v.z * n)
                    Return target
                End Function

                ''' <summary>
                ''' Sets the x, y, and z component of the Cartesian using two or three separate
                ''' variables, the data from a Cartesian, or the values from a float array.
                '''  </summary>
                ''' <param name="x"> the x component of the Cartesian Co-ordinate </param>
                ''' <param name="y"> the y component of the Cartesian Co-ordinate </param>
                ''' <param name="z"> the z component of the Cartesian Co-ordinate </param>
                Public Overridable Function [Set](ByVal x As Single, ByVal y As Single, ByVal z As Single) As Cartesian
                    Me.x = x
                    Me.y = y
                    Me.z = z
                    Return Me
                End Function

                ''' <summary>
                ''' Sets the x, y, and z component of the Cartesian using two or three separate
                ''' variables, the data from a Cartesian, or the values from a float array.
                '''  </summary>
                ''' <param name="x"> the x component of the Cartesian Co-ordinate </param>
                ''' <param name="y"> the y component of the Cartesian Co-ordinate </param>
                Public Overridable Function [Set](ByVal x As Single, ByVal y As Single) As Cartesian
                    Me.x = x
                    Me.y = y
                    Me.z = 0
                    Return Me
                End Function

                ''' <summary>
                ''' Sets the x, y, and z component of the Cartesian Co-ordinate from another Cartesian Co-ordinate
                '''  </summary>
                ''' <param name="v"> Cartesian Co-ordinate to copy from </param>
                Public Overridable Function [Set](ByVal v As Cartesian) As Cartesian
                    x = v.x
                    y = v.y
                    z = v.z
                    Return Me
                End Function

                ''' <summary>
                ''' Set the x, y (and maybe z) coordinates using a float[] array as the source. </summary>
                ''' <param name="source"> array to copy from </param>
                Public Overridable Function [Set](ByVal source() As Single) As Cartesian
                    If source.Length >= 2 Then
                        x = source(0)
                        y = source(1)
                    End If
                    If source.Length >= 3 Then
                        z = source(2)
                    Else
                        z = 0
                    End If
                    Return Me
                End Function

                ''' <summary>
                ''' Subtracts x, y, and z components from a Cartesian, subtracts one Cartesian
                ''' from another, or subtracts two independent Cartesians
                ''' </summary>
                ''' <param name="v"> any variable of type Cartesian </param>
                Public Overridable Function [Sub](ByVal v As Cartesian) As Cartesian
                    x -= v.x
                    y -= v.y
                    z -= v.z
                    Return Me
                End Function

                ''' <param name="x"> the x component of the Cartesian </param>
                ''' <param name="y"> the y component of the Cartesian </param>
                Public Overridable Function [Sub](ByVal x As Single, ByVal y As Single) As Cartesian
                    Me.x -= x
                    Me.y -= y
                    Return Me
                End Function

                ''' <param name="z"> the z component of the Cartesian </param>
                Public Overridable Function [Sub](ByVal x As Single, ByVal y As Single, ByVal z As Single) As Cartesian
                    Me.x -= x
                    Me.y -= y
                    Me.z -= z
                    Return Me
                End Function

                ''' <summary>
                ''' Adds x, y, and z components to a Cartesian, adds one Cartesian to another, or
                ''' adds two independent Cartesians together
                ''' </summary>
                ''' <param name="v"> the Cartesian to be added </param>
                Public Overridable Function Add(ByVal v As Cartesian) As Cartesian
                    x += v.x
                    y += v.y
                    z += v.z
                    Return Me
                End Function

                ''' <param name="x"> x component of the Cartesian </param>
                ''' <param name="y"> y component of the Cartesian </param>
                Public Overridable Function Add(ByVal x As Single, ByVal y As Single) As Cartesian
                    Me.x += x
                    Me.y += y
                    Return Me
                End Function

                ''' <param name="z"> z component of the Cartesian Co-ordinate </param>
                Public Overridable Function Add(ByVal x As Single, ByVal y As Single, ByVal z As Single) As Cartesian
                    Me.x += x
                    Me.y += y
                    Me.z += z
                    Return Me
                End Function

                ''' <summary>
                ''' Gets a copy of the Cartesian, returns a Cartesian object.
                ''' </summary>
                Public Overridable Function Copy() As Cartesian
                    Return New Cartesian(x, y, z)
                End Function

                ''' <summary>
                ''' Calculates and returns a Cartesian composed of the cross product between two Cartesians
                ''' </summary>
                ''' <param name="v"> 2nd Cartesian Cartesian </param>
                Public Overridable Function Cross(ByVal v As Cartesian) As Cartesian
                    Dim target As New Cartesian
                    Dim crossX As Single = y * v.z - v.y * z
                    Dim crossY As Single = z * v.x - v.z * x
                    Dim crossZ As Single = x * v.y - v.x * y

                    target.Set(crossX, crossY, crossZ)
                    Return target
                End Function

                ''' <summary>
                ''' Calculates the Euclidean distance between two Cartesians
                ''' </summary>
                ''' <param name="v"> the x, y, and z coordinates of a Cartesian</param>
                Public Overridable Function Distance(ByVal v As Cartesian) As Single
                    Dim dx As Single = x - v.x
                    Dim dy As Single = y - v.y
                    Dim dz As Single = z - v.z
                    Return CSng(Math.Sqrt(dx * dx + dy * dy + dz * dz))
                End Function

                ''' <summary>
                ''' Divides a Cartesian by a scalar or divides one Cartesian by another.
                ''' </summary>
                ''' <param name="n"> the number by which to divide the Cartesian </param>
                Public Overridable Function Div(ByVal n As Single) As Cartesian
                    x /= n
                    y /= n
                    z /= n
                    Return Me
                End Function

                ''' <summary>
                ''' Calculates the dot product of two Cartesians.
                ''' </summary>
                ''' <param name="v"> any variable of type Cartesian </param>
                ''' <returns> the dot product </returns>
                Public Overridable Function Dot(ByVal v As Cartesian) As Single
                    Return x * v.x + y * v.y + z * v.z
                End Function

                ''' <param name="x"> x component of the Cartesian </param>
                ''' <param name="y"> y component of the Cartesian </param>
                ''' <param name="z"> z component of the Cartesian </param>
                Public Overridable Function Dot(ByVal x As Single, ByVal y As Single, ByVal z As Single) As Single
                    Return Me.x * x + Me.y * y + Me.z * z
                End Function

                Public Overrides Function Equals(ByVal obj As Object) As Boolean
                    If Not (TypeOf obj Is Cartesian) Then
                        Return False
                    End If
                    Dim p As Cartesian = DirectCast(obj, Cartesian)
                    Return x = p.x AndAlso y = p.y AndAlso z = p.z
                End Function

                ''' <summary>
                ''' Make a new 2D unit Cartesian from an angle
                ''' </summary>
                ''' <param name="target"> the target Cartesian (if null, a new Cartesian will be created) </param>
                ''' <returns> the Cartesian </returns>
                Public Function FromAngle(ByVal angle As Single, ByVal target As Cartesian) As Cartesian
                    Dim Output As New Cartesian()

                    Output.Set(CSng(Math.Cos(angle)), CSng(Math.Sin(angle)), 0)
                    Return Output
                End Function

                ''' <summary>
                ''' Make a new 2D unit Cartesian Co-ordinate from an angle.
                ''' </summary>
                ''' <param name="angle"> the angle in radians </param>
                ''' <returns> the new unit Cartesian Co-ordinate </returns>
                Public Function FromAngle(ByVal angle As Single) As Cartesian
                    Return FromAngle(angle, Me)
                End Function

                ''' <summary>
                ''' Return Cartesian values as array
                ''' </summary>
                ''' <returns></returns>
                Public Overridable Function GetArray() As Single()
                    Dim Output(2) As Single

                    Output(0) = x
                    Output(1) = y
                    Output(2) = z

                    Return Output
                End Function

                Public Overrides Function GetHashCode() As Integer
                    Dim result As Integer = 1
                    result = 31 * result
                    result = 31 * result
                    result = 31 * result
                    Return result
                End Function

                ''' <summary>
                ''' Calculate the angle of rotation for this Cartesian (only 2D Cartesians)
                ''' </summary>
                ''' <returns> the angle of rotation </returns>
                Public Overridable Function Heading() As Single
                    Dim angle As Single = CSng(Math.Atan2(y, x))

                    Return angle
                End Function

                ''' <summary>
                ''' Linear interpolate the Cartesian to another Cartesian
                ''' </summary>
                ''' <param name="v"> the Cartesian to lerp to </param>
                ''' <param name="Amount">  The amount of interpolation; some value between 0.0 (old Cartesian) and 1.0 (new Cartesian). 0.1 is very near the old Cartesian; 0.5 is halfway in between. </param>
                Public Overridable Function Lerp(ByVal v As Cartesian, ByVal Amount As Single) As Cartesian
                    x = MathFunctions.Lerp(x, v.x, Amount)
                    y = MathFunctions.Lerp(y, v.y, Amount)
                    z = MathFunctions.Lerp(z, v.z, Amount)
                    Return Me
                End Function

                ''' <summary>
                ''' Linear interpolate the Cartesian Co-ordinate to x,y,z values </summary>
                ''' <param name="x"> the x component to lerp to </param>
                ''' <param name="y"> the y component to lerp to </param>
                ''' <param name="z"> the z component to lerp to </param>
                Public Overridable Function Lerp(ByVal x As Single, ByVal y As Single, ByVal z As Single, ByVal Amount As Single) As Cartesian
                    Me.x = MathFunctions.Lerp(Me.x, x, Amount)
                    Me.y = MathFunctions.Lerp(Me.y, y, Amount)
                    Me.z = MathFunctions.Lerp(Me.z, z, Amount)
                    Return Me
                End Function

                ''' <summary>
                ''' Limit the magnitude of this Cartesian to the value passed as max parameter
                ''' </summary>
                ''' <param name="max"> the maximum magnitude for the Cartesian </param>
                Public Overridable Function Limit(ByVal max As Single) As Cartesian
                    If MagSq() > max * max Then
                        Normalize()
                        Mult(max)
                    End If
                    Return Me
                End Function

                ''' <summary>
                ''' Calculates the magnitude (length) of the Cartesian Co-ordinate and returns the result
                ''' </summary>
                ''' <returns> magnitude (length) of the Cartesian Co-ordinate </returns>
                Public Overridable Function Magnitude() As Single
                    Return CSng(Math.Sqrt(x * x + y * y + z * z))
                End Function

                ''' <summary>
                ''' Calculates the squared magnitude of the Cartesian and returns the result
                ''' </summary>
                ''' <returns> squared magnitude of the Cartesian </returns>
                Public Overridable Function MagSq() As Single
                    Return (x * x + y * y + z * z)
                End Function

                ''' <summary>
                ''' Multiplies a Cartesian by a scalar or multiplies one Cartesian by another.
                ''' </summary>
                ''' <param name="n"> the number to multiply with the Cartesian </param>
                Public Overridable Function Mult(ByVal n As Single) As Cartesian
                    x *= n
                    y *= n
                    z *= n
                    Return Me
                End Function

                ''' <summary>
                ''' Normalize the Cartesian to length 1 (make it a unit Cartesian).
                ''' </summary>
                Public Overridable Function Normalize() As Cartesian
                    Dim m As Single = Magnitude()

                    If m <> 0 AndAlso m <> 1 Then
                        Div(m)
                    End If
                    Return Me
                End Function

                ''' <param name="target"> Set to null to create a new Cartesian </param>
                ''' <returns> a new Cartesian (if target was null), or target </returns>
                Public Overridable Function Normalize(ByVal target As Cartesian) As Cartesian
                    If target Is Nothing Then
                        target = New Cartesian()
                    End If
                    Dim m As Single = Magnitude()
                    If m > 0 Then
                        target.Set(x / m, y / m, z / m)
                    Else
                        target.Set(x, y, z)
                    End If
                    Return target
                End Function

                ''' <summary>
                ''' Randmize X, Y and Z components of Cartesian Co-ordinate between 0 and 1
                ''' </summary>
                Public Sub Randomize()
                    Me.x = _RandGenerator.GetRandomDbl
                    Me.y = _RandGenerator.GetRandomDbl
                    Me.z = _RandGenerator.GetRandomDbl
                End Sub

                ''' <summary>
                ''' Rotate the Cartesian by an angle (only 2D Cartesians), magnitude remains the same
                ''' </summary>
                ''' <param name="theta"> the angle of rotation </param>
                Public Overridable Function Rotate(ByVal theta As Single) As Cartesian
                    Dim temp As Single = x

                    x = x * Math.Cos(theta) - y * Math.Sin(theta)
                    y = temp * Math.Sin(theta) + y * Math.Cos(theta)
                    Return Me
                End Function

                ''' <summary>
                ''' Set the magnitude of this Cartesian to the value passed as len parameter
                ''' </summary>
                ''' <param name="len"> the new length for this Cartesian </param>
                Public Overridable Function SetMag(ByVal len As Single) As Cartesian
                    Normalize()
                    Mult(len)
                    Return Me
                End Function

                ''' <summary>
                ''' Sets the magnitude of this Cartesian, storing the result in another Cartesian. </summary>
                ''' <param name="target"> Set to null to create a new Cartesian </param>
                ''' <param name="len"> the new length for the new Cartesian </param>
                ''' <returns> a new Cartesian (if target was null), or target </returns>
                Public Overridable Function SetMag(ByVal target As Cartesian, ByVal len As Single) As Cartesian
                    target = Normalize(target)
                    target.Mult(len)
                    Return target
                End Function

                ''' <summary>
                ''' Returns coordinates of Cartesian [x,y,z]
                ''' </summary>
                ''' <returns></returns>
                Public Overrides Function ToString() As String
                    Return "[ " & x & ", " & y & ", " & z & " ]"
                End Function

            End Class

        End Namespace

    End Namespace
End Namespace