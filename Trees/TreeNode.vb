﻿Imports System.Web.Script.Serialization

Namespace MATH_EXTENSIONS

    Namespace MathsExt

        Namespace Trees
            'Tree Extensions
            ''' <summary>
            ''' A Tree is actually a List of Lists
            ''' Root with branches and leaves:
            ''' In this tree the children are the branches: Locations to hold data have been provided.
            ''' These ae not part of the Tree Structure:
            ''' When initializing the structure Its also prudent to Initialize the ChildList;
            ''' Reducing errors; Due to late initialization of the ChildList
            ''' Subsequentially : Lists used in this class are not initialized in this structure.
            ''' Strings inserted with the insert Cmd will be treated as a Trie Tree insert!
            ''' if this tree requires data to be stroed it needs to be stored inside the dataStorae locations
            ''' </summary>
            <ComClass(TreeNode.ClassId, TreeNode.InterfaceId, TreeNode.EventsId)>
            Public Class TreeNode
                Public Const ClassId As String = "2822B490-7703-401C-BAB3-38FF97BC1AC9"
                Public Const EventsId As String = "CDB5B207-F55E-401A-ABBD-3CF8086BB6F1"
                Public Const InterfaceId As String = "8B3325F8-5D13-4059-8B9B-B531310144B5"

                ''' <summary>
                ''' Each Set of Nodes has only 26 ID's ID 0 = stop
                ''' </summary>
                Public Enum CharID
                    StartChar = 0
                    a = 1
                    b = 2
                    c = 3
                    d = 4
                    e = 5
                    f = 6
                    g = 7
                    h = 8
                    i = 9
                    j = 10
                    k = 11
                    l = 12
                    m = 13
                    n = 14
                    o = 15
                    p = 16
                    q = 17
                    r = 18
                    s = 19
                    t = 20
                    u = 21
                    v = 22
                    w = 23
                    x = 24
                    y = 25
                    z = 26
                    StopChar = 27
                End Enum

                Public Function ToJson() As String
                    Dim Converter As New JavaScriptSerializer
                    Return Converter.Serialize(Me)

                End Function

#Region "Add"

                ''' <summary>
                ''' Adds string to given trie
                ''' </summary>
                ''' <param name="Tree"></param>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Shared Function AddStringbyChars(ByRef Tree As TreeNode, Str As String) As TreeNode
                    Dim curr As TreeNode = Tree
                    Dim Pos As Integer = 0
                    For Each chr As Char In Str
                        Pos += 1
                        curr = TreeNode.AddStringToTrie(curr, chr, Pos)
                    Next
                    curr = TreeNode.AddStringToTrie(curr, "StopChar", Pos + 1)
                    Return Tree
                End Function

                ''' <summary>
                ''' Adds string to given trie
                ''' </summary>
                ''' <param name="Tree"></param>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Shared Function AddStringbyWord(ByRef Tree As TreeNode, Str As String) As TreeNode
                    Dim curr As TreeNode = Tree
                    Dim Pos As Integer = 0
                    For Each chr As String In Str.Split(" ")
                        Pos += 1
                        curr = TreeNode.AddStringToTrie(curr, chr, Pos)
                    Next
                    curr = TreeNode.AddStringToTrie(curr, "StopChar", Pos + 1)
                    Return Tree
                End Function

                ''' <summary>
                ''' Insert String into trie
                ''' </summary>
                ''' <param name="tree"></param>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Shared Function InsertByCharacters(ByRef tree As TreeNode, ByRef Str As String) As TreeNode
                    Return TreeNode.AddStringbyChars(tree, Str)
                End Function

                ''' <summary>
                ''' Insert String into trie
                ''' </summary>
                ''' <param name="tree"></param>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Shared Function InsertByWord(ByRef tree As TreeNode, ByRef Str As String) As TreeNode
                    Return TreeNode.AddStringbyWord(tree, Str)
                End Function

                ''' <summary>
                ''' Add characters Iteratively
                ''' CAT
                ''' AT
                ''' T
                ''' </summary>
                ''' <param name="Word"></param>
                ''' <param name="TrieTree"></param>
                Public Function AddItterativelyByCharacter(ByRef TrieTree As TreeNode, ByRef Word As String) As TreeNode
                    'AddWord
                    For i = 1 To Word.Length
                        TrieTree.InsertByCharacters(Word)
                        Word = Word.Remove(0, 1)
                    Next
                    Return TrieTree
                End Function

                ''' <summary>
                ''' AddIteratively characters
                ''' CAT
                ''' AT
                ''' T
                ''' </summary>
                ''' <param name="Word"></param>
                Public Function AddItterativelyByCharacter(ByRef Word As String) As TreeNode
                    Return AddItterativelyByCharacter(Me, Word)
                End Function

                ''' <summary>
                ''' Add characters Iteratively
                ''' CAT
                ''' AT
                ''' T
                ''' </summary>
                ''' <param name="Word"></param>
                ''' <param name="TrieTree"></param>
                Public Function AddItterativelyByWord(ByRef TrieTree As TreeNode, ByRef Word As String) As TreeNode
                    'AddWord
                    Dim x = Word.Split(" ")
                    For Each item As String In x
                        TrieTree.InsertByWord(Word)
                        If Word.Length > item.Length + 1 = True Then
                            Word = Word.Remove(0, item.Length + 1)
                        Else
                            Word = ""
                        End If
                    Next
                    Return TrieTree
                End Function

                ''' <summary>
                ''' AddIteratively characters
                ''' CAT
                ''' AT
                ''' T
                ''' </summary>
                ''' <param name="Word"></param>
                Public Function AddItterativelyByWord(ByRef Word As String) As TreeNode
                    Return AddItterativelyByWord(Me, Word)
                End Function

                ''' <summary>
                ''' Inserts a string into the trie
                ''' </summary>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Function InsertByCharacters(ByRef Str As String) As TreeNode
                    Return TreeNode.AddStringbyChars(Me, Str)
                End Function

                ''' <summary>
                ''' Inserts a string into the trie
                ''' </summary>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Function InsertByWord(ByRef Str As String) As TreeNode
                    Return TreeNode.AddStringbyWord(Me, Str)
                End Function

                ''' <summary>
                ''' Adds char to Node(children) Returning the child
                ''' </summary>
                ''' <param name="CurrentNode">node containing children</param>
                ''' <param name="ChrStr">String to be added </param>
                ''' <param name="CharPos">this denotes the level of the node</param>
                ''' <returns></returns>
                Private Shared Function AddStringToTrie(ByRef CurrentNode As TreeNode, ByRef ChrStr As String, ByRef CharPos As Integer) As TreeNode
                    'start of tree
                    Dim Text As String = ChrStr
                    Dim returnNode As New TreeNode
                    Dim NewNode As New TreeNode
                    'Goto first node
                    'does this node have siblings
                    If TreeNode.HasChildren(CurrentNode) = True Then
                        'Check children
                        If TreeNode.CheckNodeExists(CurrentNode.Children, ChrStr) = False Then
                            'create a new node for char
                            NewNode = TreeNode.CreateNode(ChrStr, CurrentNode.NodeLevel + 1)
                            NewNode.NodeLevel = CharPos
                            'Add childnode
                            CurrentNode.Children.Add(NewNode)
                            returnNode = TreeNode.GetNode(CurrentNode.Children, ChrStr)
                        Else
                            returnNode = TreeNode.GetNode(CurrentNode.Children, ChrStr)
                        End If
                    Else
                        'If no silings then Create new node
                        'create a new node for char
                        NewNode = TreeNode.CreateNode(ChrStr, CurrentNode.NodeLevel + 1)
                        NewNode.NodeLevel = CharPos
                        'Add childnode
                        CurrentNode.Children.Add(NewNode)
                        returnNode = TreeNode.GetNode(CurrentNode.Children, ChrStr)
                    End If

                    Return returnNode
                End Function

#End Region

#Region "DATA"

                ''' <summary>
                ''' Theses are essentailly the branches of the Tree....
                ''' if there are no children then the node is a leaf.
                ''' Denoted by the StopCharacter NodeID. or "StopChar" NodeData.
                ''' </summary>
                Public Children As List(Of TreeNode)

                ''' <summary>
                ''' Available Variable Storage (boolean)
                ''' </summary>
                Public NodeBool As Boolean

                ''' <summary>
                ''' Available Variable Storage (list of Boolean)
                ''' </summary>
                Public NodeBoolList As List(Of Boolean)

                ''' <summary>
                ''' Used To hold CharacterStr (tries) Also Useful for Creating ID for node;
                ''' : (a String) can be used to store a specific Pathway :
                ''' </summary>
                Public NodeData As String

                ''' <summary>
                ''' Each NodeID: is specific to Its level this id is generated by the tree:
                ''' </summary>
                Public NodeID As CharID

                ''' <summary>
                ''' Available Variable Storage(int)
                ''' </summary>
                Public NodeInt As Integer

                ''' <summary>
                ''' Available Variable Storage (list of Int)
                ''' </summary>
                Public NodeIntList As List(Of Integer)

                ''' <summary>
                ''' the level denotes also how many vertices before returning to the root.
                ''' In a Trie Tree the first node is blank and not included therefore the Vertices are level-1
                ''' </summary>
                Public NodeLevel As Integer

                ''' <summary>
                ''' Available Variable Storage(string)
                ''' </summary>
                Public NodeStr As String

                ''' <summary>
                ''' Available Variable Storage(list of Strings)
                ''' </summary>
                Public NodeStrList As List(Of String)

                Public Sub New(ByRef IntializeChildren As Boolean)
                    If IntializeChildren = True Then
                        Children = New List(Of TreeNode)
                    Else
                    End If
                End Sub

                Public Sub New()

                End Sub

                ''' <summary>
                ''' Returns Number of Nodes
                ''' </summary>
                ''' <returns></returns>
                Public Shared Function NumberOfNodes(ByRef Tree As TreeNode) As Integer
                    Dim Count As Integer = 0
                    For Each child In Tree.Children
                        Count += child.NumberOfNodes
                    Next
                    Return Count
                End Function

                ''' <summary>
                ''' Returns number of Nodes in tree
                ''' </summary>
                ''' <returns></returns>
                Public Function CountNodes(ByRef CurrentCount As Integer) As Integer
                    Dim count As Integer = CurrentCount
                    For Each child In Me.Children
                        count += 1
                        count = child.CountNodes(count)
                    Next
                    Return count
                End Function

                Public Function CountWords(ByRef CurrentCount As Integer) As Integer
                    Dim count As Integer = CurrentCount
                    For Each child In Me.Children
                        If child.NodeID = CharID.StopChar = True Then
                            count += 1

                        End If
                        count = child.CountWords(count)
                    Next

                    Return count
                End Function

                ''' <summary>
                ''' Checks if current node Has children
                ''' </summary>
                ''' <returns></returns>
                Public Function HasChildren() As Boolean
                    Return If(Me.Children.Count > 0 = True, True, False)
                End Function

                ''' <summary>
                ''' Returns deepest level
                ''' </summary>
                ''' <returns></returns>
                Public Function LowestLevel() As Integer
                    'Gets the level for node
                    Dim Level As Integer = Me.NodeLevel

                    'Recurses children
                    For Each child In Me.Children
                        If Level < child.LowestLevel = True Then
                            Level = child.LowestLevel
                        End If
                    Next
                    'The loop should finish at the lowest level
                    Return Level
                End Function

                'Functions
                ''' <summary>
                ''' Returns Number of Nodes
                ''' </summary>
                ''' <returns></returns>
                Public Function NumberOfNodes() As Integer
                    Dim Count As Integer = 0
                    For Each child In Me.Children
                        Count += child.NumberOfNodes
                    Next
                    Return Count
                End Function

                ''' <summary>
                ''' Checks if given node has children
                ''' </summary>
                ''' <param name="Node"></param>
                ''' <returns></returns>
                Private Shared Function HasChildren(ByRef Node As TreeNode) As Boolean
                    Return If(Node.Children.Count > 0 = True, True, False)
                End Function

#End Region

#Region "Create"

                ''' <summary>
                ''' Creates a Tree With an Empty Root node Called Root! Intializing the StartChar
                ''' </summary>
                ''' <returns></returns>
                Public Function Create() As TreeNode
                    Return TreeNode.MakeTrieTree()
                End Function

                ''' <summary>
                ''' If node does not exist in child node set it is added
                ''' if node already exists then no node is added a node ID is generated
                ''' </summary>
                ''' <param name="NodeData">Character to be added</param>
                Private Shared Function CreateNode(ByRef NodeData As String, ByRef Level As Integer) As TreeNode
                    'Create node - 2
                    Dim NewNode As New TreeNode(True)
                    NewNode.NodeData = NodeData
                    'create id
                    NewNode.NodeID = GenerateNodeID(NodeData)
                    NewNode.NodeLevel = Level
                    Return NewNode
                End Function

                ''' <summary>
                ''' Generates an ID from NodeData
                ''' </summary>
                ''' <param name="Nodedata">Character string for node</param>
                ''' <returns></returns>
                Private Shared Function GenerateNodeID(ByRef Nodedata As String) As CharID
                    Dim newnode As New TreeNode
                    'SET ID for node
                    Select Case Nodedata.ToUpper
                        Case "STOPCHAR"
                            newnode.NodeID = CharID.StopChar
                        Case "A"
                            newnode.NodeID = CharID.a
                        Case "B"
                            newnode.NodeID = CharID.b
                        Case "C"
                            newnode.NodeID = CharID.c
                        Case "D"
                            newnode.NodeID = CharID.d
                        Case "E"
                            newnode.NodeID = CharID.e
                        Case "F"
                            newnode.NodeID = CharID.f
                        Case "G"
                            newnode.NodeID = CharID.g
                        Case "H"
                            newnode.NodeID = CharID.h
                        Case "I"
                            newnode.NodeID = CharID.i
                        Case "J"
                            newnode.NodeID = CharID.j
                        Case "K"
                            newnode.NodeID = CharID.k
                        Case "L"
                            newnode.NodeID = CharID.l
                        Case "M"
                            newnode.NodeID = CharID.m
                        Case "N"
                            newnode.NodeID = CharID.n
                        Case "O"
                            newnode.NodeID = CharID.o
                        Case "P"
                            newnode.NodeID = CharID.p
                        Case "Q"
                            newnode.NodeID = CharID.q
                        Case "R"
                            newnode.NodeID = CharID.r
                        Case "S"
                            newnode.NodeID = CharID.s
                        Case "T"
                            newnode.NodeID = CharID.t
                        Case "U"
                            newnode.NodeID = CharID.u
                        Case "V"
                            newnode.NodeID = CharID.v
                        Case "W"
                            newnode.NodeID = CharID.w
                        Case "X"
                            newnode.NodeID = CharID.x
                        Case "Y"
                            newnode.NodeID = CharID.y
                        Case "Z"
                            newnode.NodeID = CharID.z
                    End Select
                    Return newnode.NodeID
                End Function

                Private Shared Function MakeTrieTree() As TreeNode
                    Dim tree As New TreeNode(True)

                    tree.NodeData = "Root"
                    tree.NodeID = CharID.StartChar
                    Return tree
                End Function

#End Region

#Region "Display"

                ''' <summary>
                ''' Displays Contents of trie
                ''' </summary>
                ''' <returns></returns>
                Public Overrides Function ToString() As String

                    'TreeInfo
                    Dim Str As String = "NodeID " & Me.NodeID.ToString & vbNewLine &
            "Data: " & Me.NodeData & vbNewLine &
            "Node Level: " & NodeLevel.ToString & vbNewLine

                    'Data held
                    Dim mData As String = ": Data :" & vbNewLine &
               "Int: " & NodeInt & vbNewLine &
               "Str: " & NodeStr & vbNewLine &
               "Boolean: " & NodeBool & vbNewLine

                    'Lists
                    mData &= "StrLst: " & vbNewLine
                    For Each child In Me.NodeStrList
                        mData &= "Str: " & child.ToString() & vbNewLine
                    Next
                    mData &= "IntLst: " & vbNewLine
                    For Each child In Me.NodeIntList
                        mData &= "Str: " & child.ToString() & vbNewLine
                    Next
                    mData &= "BooleanList: " & vbNewLine
                    For Each child In Me.NodeBoolList
                        mData &= "Bool: " & child.ToString() & vbNewLine
                    Next

                    'Recurse Children
                    For Each child In Me.Children
                        Str &= "Child: " & child.ToString()
                    Next

                    Return Str
                End Function

                ''' <summary>
                ''' Returns a TreeViewControl with the Contents of the Trie:
                ''' </summary>
                Public Function ToView(ByRef Node As TreeNode) As System.Windows.Forms.TreeNode
                    Dim Nde As New System.Windows.Forms.TreeNode
                    Nde.Text = Node.NodeData.ToString.ToUpper &
                "(" & Node.NodeLevel & ")" & vbNewLine

                    For Each child In Me.Children
                        Nde.Nodes.Add(child.ToView)

                    Next
                    Return Nde
                End Function

                ''' <summary>
                ''' Returns a TreeViewControl with the Contents of the Trie:
                ''' </summary>
                ''' <returns></returns>
                Public Function ToView() As System.Windows.Forms.TreeNode
                    Dim nde As New System.Windows.Forms.TreeNode
                    nde.Text = Me.NodeData.ToString.ToUpper & vbNewLine &
                "(" & Me.NodeLevel & ")" & vbNewLine

                    For Each child In Me.Children
                        nde.Nodes.Add(child.ToView)

                    Next

                    Return nde

                End Function

#End Region

#Region "FIND"

                ''' <summary>
                ''' checks if node exists in child nodes (used for trie trees (String added is the key and the data)
                ''' </summary>
                ''' <param name="Nodedata">Char string used as identifier</param>
                ''' <returns></returns>
                Public Shared Function CheckNodeExists(ByRef Children As List(Of TreeNode), ByRef Nodedata As String) As Boolean
                    'Check node does not exist
                    Dim found As Boolean = False
                    For Each mNode As TreeNode In Children
                        If mNode.NodeData = Nodedata Then
                            found = True
                        Else
                        End If
                    Next
                    Return found
                End Function

                ''' <summary>
                ''' Returns true if string is contined in trie (prefix) not as Word
                ''' </summary>
                ''' <param name="tree"></param>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Shared Function CheckPrefix(ByRef tree As TreeNode, ByRef Str As String) As Boolean
                    Str = Str.ToUpper
                    Dim CurrentNode As TreeNode = tree
                    Dim found As Boolean = False

                    Dim Pos As Integer = 0
                    For Each chrStr As Char In Str
                        Pos += 1

                        'Check Chars
                        If TreeNode.CheckNodeExists(CurrentNode.Children, chrStr) = True Then
                            CurrentNode = TreeNode.GetNode(CurrentNode.Children, chrStr)
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
                Public Shared Function CheckSentence(ByRef tree As TreeNode, ByRef Str As String) As Boolean
                    Str = Str.ToUpper
                    Dim CurrentNode As TreeNode = tree
                    Dim found As Boolean = False
                    'Position in Characterstr
                    Dim Pos As Integer = 0
                    For Each chrStr As String In Str.Split(" ")
                        Pos += 1

                        'Check Chars
                        If TreeNode.CheckNodeExists(CurrentNode.Children, chrStr) = True Then
                            CurrentNode = TreeNode.GetNode(CurrentNode.Children, chrStr)
                            found = True
                        Else
                            'Terminated before end of Word
                            found = False
                        End If
                    Next

                    'Check for end of word marker
                    Return If(found = True, TreeNode.CheckNodeExists(CurrentNode.Children, "StopChar") = True, False)

                End Function

                ''' <summary>
                ''' Returns true if string is contined in trie (prefix) not as Word
                ''' </summary>
                ''' <param name="tree"></param>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Shared Function CheckSentPrefix(ByRef tree As TreeNode, ByRef Str As String) As Boolean
                    Dim CurrentNode As TreeNode = tree
                    Dim found As Boolean = False
                    Str = Str.ToUpper
                    Dim Pos As Integer = 0
                    For Each chrStr As String In Str.Split(" ")
                        Pos += 1

                        'Check Chars
                        If TreeNode.CheckNodeExists(CurrentNode.Children, chrStr) = True Then
                            CurrentNode = TreeNode.GetNode(CurrentNode.Children, chrStr)
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
                Public Shared Function CheckWord(ByRef tree As TreeNode, ByRef Str As String) As Boolean
                    Str = Str.ToUpper
                    Dim CurrentNode As TreeNode = tree
                    Dim found As Boolean = False
                    'Position in Characterstr
                    Dim Pos As Integer = 0
                    For Each chrStr As Char In Str
                        Pos += 1

                        'Check Chars
                        If TreeNode.CheckNodeExists(CurrentNode.Children, chrStr) = True Then
                            CurrentNode = TreeNode.GetNode(CurrentNode.Children, chrStr)
                            found = True
                        Else
                            'Terminated before end of Word
                            found = False
                        End If
                    Next

                    'Check for end of word marker
                    Return If(found = True, TreeNode.CheckNodeExists(CurrentNode.Children, "StopChar") = True, False)

                End Function

                ''' <summary>
                ''' Returns Matched Node to sender (used to recures children)
                ''' </summary>
                ''' <param name="Tree"></param>
                ''' <param name="NodeData"></param>
                ''' <returns></returns>
                Public Shared Function GetNode(ByRef Tree As List(Of TreeNode), ByRef NodeData As String) As TreeNode
                    Dim Foundnode As New TreeNode
                    For Each item In Tree
                        If item.NodeData = NodeData Then
                            Foundnode = item
                        Else
                        End If
                    Next
                    Return Foundnode
                End Function

                ''' <summary>
                ''' Returns true if String is found as a prefix in trie
                ''' </summary>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Function FindPrefix(ByRef Str As String) As Boolean
                    Return TreeNode.CheckPrefix(Me, Str)
                End Function

                ''' <summary>
                ''' Returns true if string is found as word in trie
                ''' </summary>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Function FindSentence(ByRef Str As String) As Boolean
                    Return TreeNode.CheckSentence(Me, Str)
                End Function

                ''' <summary>
                ''' Returns true if String is found as a prefix in trie
                ''' </summary>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Function FindSentPrefix(ByRef Str As String) As Boolean
                    Return TreeNode.CheckSentPrefix(Me, Str)
                End Function

                ''' <summary>
                ''' Returns true if string is found as word in trie
                ''' </summary>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Function FindWord(ByRef Str As String) As Boolean
                    Return TreeNode.CheckWord(Me, Str)
                End Function

#End Region

            End Class

        End Namespace

    End Namespace
End Namespace