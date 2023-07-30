Namespace MATH_EXTENSIONS

    Namespace MathsExt

        Namespace Trees
            ''' <summary>
            ''' Extension methods for Tri Tree Structure
            ''' </summary>
            Public Module TrieTreeExtensions

                ''' <summary>
                ''' Returns true if string is contined in trie (prefix) not as Word
                ''' </summary>
                ''' <param name="tree"></param>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                <System.Runtime.CompilerServices.Extension()>
                Public Function CheckPrefix(ByRef tree As TrieTree, ByRef Str As String) As Boolean
                    Dim CurrentNode As TrieTree = tree
                    Dim found As Boolean = False

                    Dim Pos As Integer = 0
                    For Each chrStr As Char In Str
                        Pos += 1

                        'Check Chars
                        If TrieTree.CheckNodeExists(CurrentNode.Children, chrStr) = True Then
                            CurrentNode = TrieTree.GetNode(CurrentNode.Children, chrStr)
                            found = True
                        Else
                            found = False
                        End If
                    Next
                    Return found
                End Function

                ''' <summary>
                ''' Returns true if Word is found in trie
                ''' </summary>
                ''' <param name="tree"></param>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                <System.Runtime.CompilerServices.Extension()>
                Public Function CheckWord(ByRef tree As TrieTree, ByRef Str As String) As Boolean
                    Dim CurrentNode As TrieTree = tree
                    Dim found As Boolean = False
                    'Position in Characterstr
                    Dim Pos As Integer = 0
                    For Each chrStr As Char In Str
                        Pos += 1

                        'Check Chars
                        If TrieTree.CheckNodeExists(CurrentNode.Children, chrStr) = True Then
                            CurrentNode = TrieTree.GetNode(CurrentNode.Children, chrStr)
                            found = True
                        Else
                            'Terminated before end of Word
                            found = False
                        End If
                    Next

                    'Check for end of word marker
                    Return If(found = True, TrieTree.CheckNodeExists(CurrentNode.Children, "StopChar") = True, False)

                End Function

                ''' <summary>
                ''' Returns Number of Nodes
                ''' </summary>
                ''' <returns></returns>
                <System.Runtime.CompilerServices.Extension()>
                Public Function NumberOfNodes(ByRef Tree As TrieTree) As Integer
                    Dim Count As Integer = 0
                    For Each child In Tree.Children
                        Count += child.NumberOfNodes
                    Next
                    Return Count
                End Function

                ''' <summary>
                ''' Returns Matched Node in children to sender (used to recurse children)
                ''' </summary>
                ''' <param name="Tree"></param>
                ''' <param name="NodeData"></param>
                ''' <returns></returns>
                <System.Runtime.CompilerServices.Extension()>
                Public Function GetNode(ByRef Tree As List(Of TrieTree), ByRef NodeData As String) As TrieTree
                    Dim Foundnode As New TrieTree
                    For Each item In Tree
                        If item.NodeData = NodeData Then
                            Foundnode = item
                        Else
                        End If
                    Next
                    Return Foundnode
                End Function

            End Module

        End Namespace

    End Namespace
End Namespace