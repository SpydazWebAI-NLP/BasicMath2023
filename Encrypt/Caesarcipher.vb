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

    End Namespace
End Namespace