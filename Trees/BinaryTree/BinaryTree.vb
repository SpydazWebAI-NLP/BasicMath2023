Imports System.Text

Namespace MATH_EXTENSIONS

    Namespace MathsExt

        Namespace Trees
            ''' <summary>
            ''' All nodes in a binary Tree have Left and Right nodes Nodes are added to the end of the tree
            ''' organized then the tree can be reorganized the rules are such that the lowest numbers are
            ''' always on the left and the highest numbers are on the right
            ''' </summary>
            Public Class BinaryTree

                Public Data As Integer
                Public Left As BinaryTree
                Public Right As BinaryTree

                Public Sub New(ByVal Data As Integer)
                    Me.Data = Data
                End Sub

                ' Add Duplicate Handling
                Public Sub Insert(ByVal NewData As Integer)
                    If NewData <= Data Then
                        If Left IsNot Nothing Then
                            Left.Insert(NewData)
                        Else
                            Left = New BinaryTree(NewData)
                        End If
                    Else
                        If Right IsNot Nothing Then
                            Right.Insert(NewData)
                        Else
                            Right = New BinaryTree(NewData)
                        End If
                    End If
                End Sub

                ' Remove Node with a Specific Value
                ' ...

                ' Remove Node with a Specific Value
                Public Function Remove(ByVal value As Integer) As BinaryTree
                    Dim parent As BinaryTree = Nothing
                    Dim current As BinaryTree = Me

                    ' Find the node to remove and its parent
                    While current IsNot Nothing AndAlso current.Data <> value
                        parent = current
                        If value < current.Data Then
                            current = current.Left
                        Else
                            current = current.Right
                        End If
                    End While

                    ' If the node was not found, return Nothing
                    If current Is Nothing Then
                        Return Nothing
                    End If

                    ' Case 1: Node has no children (leaf node)
                    If current.Left Is Nothing AndAlso current.Right Is Nothing Then
                        If parent Is Nothing Then

                        ElseIf parent.Left Is current Then
                            parent.Left = Nothing
                        Else
                            parent.Right = Nothing
                        End If
                    ElseIf current.Left IsNot Nothing AndAlso current.Right IsNot Nothing Then
                        ' Case 3: Node has two children
                        Dim inOrderSuccessor As BinaryTree = current.Right
                        Dim temp As Integer = inOrderSuccessor.Data
                        current.Data = temp
                        current.Right = current.Right.Remove(temp)
                    Else
                        ' Case 2: Node has one child
                        Dim child As BinaryTree = If(current.Left IsNot Nothing, current.Left, current.Right)
                        If parent Is Nothing Then

                        ElseIf parent.Left Is current Then
                            parent.Left = child
                        Else
                            parent.Right = child
                        End If
                    End If

                    Return Me
                End Function

                ' ...


                ' Find Minimum Value
                Public Function FindMin() As Integer
                    If Left Is Nothing Then
                        Return Data
                    Else
                        Return Left.FindMin()
                    End If
                End Function

                ' Find Maximum Value
                Public Function FindMax() As Integer
                    If Right Is Nothing Then
                        Return Data
                    Else
                        Return Right.FindMax()
                    End If
                End Function

                ' Count Total Number of Nodes
                Public Function CountNodes() As Integer
                    Dim count As Integer = 1
                    If Left IsNot Nothing Then
                        count += Left.CountNodes()
                    End If
                    If Right IsNot Nothing Then
                        count += Right.CountNodes()
                    End If
                    Return count
                End Function

                ' Get Depth (Height) of the Tree
                Public Function GetDepth() As Integer
                    Dim leftDepth As Integer = If(Left IsNot Nothing, Left.GetDepth(), 0)
                    Dim rightDepth As Integer = If(Right IsNot Nothing, Right.GetDepth(), 0)
                    Return 1 + Math.Max(leftDepth, rightDepth)
                End Function

                ' Pre-order Traversal to List
                Public Function PreOrderTraversalToList() As List(Of Integer)
                    Dim result As New List(Of Integer)
                    PreOrderTraversalToListRecursive(Me, result)
                    Return result
                End Function

                Private Sub PreOrderTraversalToListRecursive(ByVal node As BinaryTree, ByVal result As List(Of Integer))
                    If node IsNot Nothing Then
                        result.Add(node.Data)
                        PreOrderTraversalToListRecursive(node.Left, result)
                        PreOrderTraversalToListRecursive(node.Right, result)
                    End If
                End Sub

                ' Post-order Traversal to List
                Public Function PostOrderTraversalToList() As List(Of Integer)
                    Dim result As New List(Of Integer)
                    PostOrderTraversalToListRecursive(Me, result)
                    Return result
                End Function

                Private Sub PostOrderTraversalToListRecursive(ByVal node As BinaryTree, ByVal result As List(Of Integer))
                    If node IsNot Nothing Then
                        PostOrderTraversalToListRecursive(node.Left, result)
                        PostOrderTraversalToListRecursive(node.Right, result)
                        result.Add(node.Data)
                    End If
                End Sub

                ' Level-order Traversal to List
                Public Function LevelOrderTraversalToList() As List(Of Integer)
                    Dim result As New List(Of Integer)
                    If Me Is Nothing Then
                        Return result
                    End If

                    Dim queue As New Queue(Of BinaryTree)()
                    queue.Enqueue(Me)

                    While queue.Count > 0
                        Dim node As BinaryTree = queue.Dequeue()
                        result.Add(node.Data)
                        If node.Left IsNot Nothing Then
                            queue.Enqueue(node.Left)
                        End If
                        If node.Right IsNot Nothing Then
                            queue.Enqueue(node.Right)
                        End If
                    End While

                    Return result
                End Function


                Private Sub BalanceTreeRecursive(ByVal sortedList As List(Of Integer), ByVal start As Integer, ByVal [end] As Integer)
                    If start > [end] Then
                        Return
                    End If

                    Dim mid As Integer = (start + [end]) \ 2
                    Me.Insert(sortedList(mid))
                    BalanceTreeRecursive(sortedList, start, mid - 1)
                    BalanceTreeRecursive(sortedList, mid + 1, [end])
                End Sub

                ' Serialize the Tree to String
                Public Function Serialize() As String
                    Dim serializedTree As New StringBuilder()
                    SerializeRecursive(Me, serializedTree)
                    Return serializedTree.ToString()
                End Function

                Private Sub SerializeRecursive(ByVal node As BinaryTree, ByVal serializedTree As StringBuilder)
                    If node Is Nothing Then
                        serializedTree.Append("null").Append(",")
                    Else
                        serializedTree.Append(node.Data).Append(",")
                        SerializeRecursive(node.Left, serializedTree)
                        SerializeRecursive(node.Right, serializedTree)
                    End If
                End Sub

                ' Deserialize the Tree from String
                Public Shared Function Deserialize(ByVal data As String) As BinaryTree
                    Dim values As String() = data.Split(","c)
                    Dim index As Integer = 0
                    Return DeserializeRecursive(values, index)
                End Function

                Private Shared Function DeserializeRecursive(ByVal values As String(), ByRef index As Integer) As BinaryTree
                    If index >= values.Length OrElse values(index) = "null" Then
                        index += 1
                        Return Nothing
                    End If

                    Dim data As Integer = Integer.Parse(values(index))
                    index += 1
                    Dim newNode As New BinaryTree(data)
                    newNode.Left = DeserializeRecursive(values, index)
                    newNode.Right = DeserializeRecursive(values, index)
                    Return newNode
                End Function

                ' Clear the Tree
                Public Sub Clear()
                    Left = Nothing
                    Right = Nothing
                End Sub

            End Class

        End Namespace

    End Namespace
End Namespace