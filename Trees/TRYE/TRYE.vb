﻿Imports System.Web.Script.Serialization
Imports System.Windows.Forms

Namespace MATH_EXTENSIONS

    Namespace MathsExt

        Namespace Trees
            Public Structure TRYE

#Region "Public Enums"

                ''' <summary>
                ''' Theses are essentailly the branches of the Tree....
                ''' if there are no children then the node is a leaf.
                ''' Denoted by the StopCharacter NodeID. or "StopChar" NodeData.
                ''' </summary>
                Public Children As List(Of TRYE)

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
                        Children = New List(Of TRYE)
                    Else
                    End If
                End Sub

                ''' <summary>
                ''' Each Set of Nodes has only 26 ID's ID 0 = stop
                ''' </summary>
                Enum CharID
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

#End Region

#Region "Public Methods"

                ''' <summary>
                ''' Add characters Iteratively
                ''' CAT
                ''' AT
                ''' T
                ''' </summary>
                ''' <param name="Word"></param>
                ''' <param name="TrieTree"></param>
                Public Shared Function AddItterativelyByCharacter(ByRef TrieTree As TRYE, ByRef Word As String) As TRYE
                    'AddWord
                    For i = 1 To Word.Length
                        TrieTree.InsertByCharacters(Word)
                        Word = Word.Remove(0, 1)
                    Next
                    Return TrieTree
                End Function

                ''' <summary>
                ''' Add by Sent Iteratively
                ''' The cat sat.
                ''' on the mat.
                ''' </summary>
                ''' <param name="Word"></param>
                ''' <param name="TrieTree"></param>
                Public Shared Function AddItterativelyBySent(ByRef TrieTree As TRYE, ByRef Word As String) As TRYE
                    'AddWord
                    Dim x = Word.Split(".")
                    For Each item As String In x
                        TrieTree.InsertBySent(Word)
                        If Word.Length > item.Length + 1 = True Then
                            Word = Word.Remove(0, item.Length + 1)
                        Else
                            Word = ""
                        End If
                    Next
                    Return TrieTree
                End Function

                ''' <summary>
                ''' Add characters Iteratively
                ''' CAT
                ''' AT
                ''' T
                ''' </summary>
                ''' <param name="Word"></param>
                ''' <param name="TrieTree"></param>
                Public Shared Function AddItterativelyByWord(ByRef TrieTree As TRYE, ByRef Word As String) As TRYE
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
                ''' Adds string to given trie
                ''' </summary>
                ''' <param name="Tree"></param>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Shared Function AddStringbyChars(ByRef Tree As TRYE, Str As String) As TRYE
                    Dim curr As TRYE = Tree
                    Dim Pos As Integer = 0
                    For Each chr As Char In Str
                        Pos += 1
                        curr = TRYE.AddStringToTrie(curr, chr, Pos)
                    Next
                    curr = TRYE.AddStringToTrie(curr, "StopChar", Pos + 1)
                    Return Tree
                End Function

                ''' <summary>
                ''' Adds string to given trie
                ''' </summary>
                ''' <param name="Tree"></param>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Shared Function AddStringbyWord(ByRef Tree As TRYE, Str As String) As TRYE
                    Dim curr As TRYE = Tree
                    Dim Pos As Integer = 0
                    For Each chr As String In Str.Split(" ")
                        Pos += 1
                        curr = TRYE.AddStringToTrie(curr, chr, Pos)
                    Next
                    curr = TRYE.AddStringToTrie(curr, "StopChar", Pos + 1)
                    Return Tree
                End Function

                ''' <summary>
                ''' checks if node exists in child nodes (used for trie trees (String added is the key and the data)
                ''' </summary>
                ''' <param name="Nodedata">Char string used as identifier</param>
                ''' <returns></returns>
                Public Shared Function CheckNodeExists(ByRef Children As List(Of TRYE),
                                                   ByRef Nodedata As String) As Boolean
                    'Check node does not exist
                    Dim found As Boolean = False
                    For Each mNode As TRYE In Children
                        If mNode.NodeData = Nodedata Then
                            found = True
                        Else
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
                Public Shared Function CheckWord(ByRef tree As TRYE, ByRef Str As String) As Boolean
                    Str = Str.ToUpper
                    Dim CurrentNode As TRYE = tree
                    Dim found As Boolean = False
                    'Position in Characterstr
                    'Check Chars
                    If TRYE.CheckNodeExists(CurrentNode.Children, Str) = True Then
                        ' CurrentNode = TRYE.GetNode(CurrentNode.Children, chrStr)
                        found = True
                    Else
                        'Terminated before end of Word
                        found = False
                    End If

                    'Check for end of word marker
                    Return found

                End Function

                Public Shared Function FIND(ByRef TryTree As TRYE, ByRef Txt As String) As Boolean
                    Dim Found As Boolean = False
                    If TryTree.FindWord(UCase(Txt)) = True Then

                        Return True
                    Else

                    End If
                    Return False
                End Function

                ''' <summary>
                ''' Returns Matched Node to sender (used to recures children)
                ''' </summary>
                ''' <param name="Tree"></param>
                ''' <param name="NodeData"></param>
                ''' <returns></returns>
                Public Shared Function GetNode(ByRef Tree As List(Of TRYE),
                                           ByRef NodeData As String) As TRYE
                    Dim Foundnode As New TRYE
                    For Each item In Tree
                        If item.NodeData = NodeData Then
                            Foundnode = item
                        Else
                        End If
                    Next
                    Return Foundnode
                End Function

                ''' <summary>
                ''' Creates a tree
                ''' </summary>
                ''' <param name="RootName">Name of Root node</param>
                ''' <returns></returns>
                Public Shared Function MakeTree(ByRef RootName As String) As TRYE
                    Dim tree As New TRYE(True)

                    tree.NodeData = RootName
                    tree.NodeID = CharID.StartChar
                    Return tree
                End Function

                ''' <summary>
                ''' Creates a Tree With an Empty Root node Called Root! Intializing the StartChar
                ''' </summary>
                ''' <returns></returns>
                Public Shared Function MakeTree() As TRYE
                    Dim tree As New TRYE(True)

                    tree.NodeData = "Root"
                    tree.NodeID = CharID.StartChar
                    Return tree
                End Function

                ''' <summary>
                ''' Returns a TreeViewControl with the Contents of the Trie:
                ''' </summary>
                Public Shared Function ToView(ByRef Node As TRYE) As System.Windows.Forms.TreeNode
                    Dim Nde As New System.Windows.Forms.TreeNode
                    Nde.Text = Node.NodeData.ToString.ToUpper &
                    "(" & Node.NodeLevel & ")" & vbNewLine

                    For Each child In Node.Children
                        Nde.Nodes.Add(child.ToView)

                    Next
                    Return Nde
                End Function

                ''' <summary>
                ''' AddIteratively characters
                ''' CAT
                ''' AT
                ''' T
                ''' </summary>
                ''' <param name="Word"></param>
                Public Function AddItterativelyByCharacter(ByRef Word As String) As TRYE
                    Return AddItterativelyByCharacter(Me, Word)
                End Function

                Public Function AddItterativelyBySent(ByRef Word As String) As TRYE
                    Return AddItterativelyByWord(Me, Word)
                End Function

                ''' <summary>
                ''' AddIteratively characters
                ''' CAT
                ''' AT
                ''' T
                ''' </summary>
                ''' <param name="Word"></param>
                Public Function AddItterativelyByWord(ByRef Word As String) As TRYE
                    Return AddItterativelyByWord(Me, Word)
                End Function

                ''' <summary>
                ''' Returns true if Word is found in trie
                ''' </summary>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Function CheckWord(ByRef Str As String) As Boolean
                    Str = Str.ToUpper
                    Dim found As Boolean = False
                    'Position in Characterstr

                    'Check Chars
                    If TRYE.CheckNodeExists(Me.Children, Str) = True Then
                        ' CurrentNode = TRYE.GetNode(CurrentNode.Children, chrStr)
                        found = True
                    Else
                        'Terminated before end of Word
                        found = False
                    End If

                    'Check for end of word marker
                    Return found

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

                ''' <summary>
                ''' Returns number of Nodes in tree (ie Words)
                ''' (Number of NodeID's Until StopChar is Found)
                ''' </summary>
                ''' <returns></returns>
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
                ''' Creates a Tree With an Empty Root node Called Root! Intializing the StartChar
                ''' </summary>
                ''' <returns></returns>
                Public Function Create() As TRYE
                    Return TRYE.MakeTree()
                End Function

                Public Function Create(ByRef NodeName As String) As TRYE
                    Return TRYE.MakeTree(NodeName)
                End Function

                ''' <summary>
                ''' Returns Depth of tree
                ''' </summary>
                ''' <returns></returns>
                Public Function Depth() As Integer
                    'Gets the level for node
                    Dim Level As Integer = Me.NodeLevel
                    'Recurses children
                    For Each child In Me.Children
                        If Level < child.Depth = True Then
                            Level = child.Depth
                        End If
                    Next
                    'The loop should finish at the lowest level
                    Return Level
                End Function

                Public Function FIND(ByRef Txt As String) As Boolean
                    Dim Found As Boolean = False

                    If Me.FindWord(UCase(Txt)) = True Then

                        Return True
                    Else

                    End If
                    Return False
                End Function

                ''' <summary>
                ''' Returns true if string is found as word in trie
                ''' </summary>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Function FindWord(ByRef Str As String) As Boolean
                    Return TRYE.CheckWord(Me, Str)
                End Function

                ''' <summary>
                ''' deserialize object from Json
                ''' </summary>
                ''' <param name="Str">json</param>
                ''' <returns></returns>
                Public Function FromJson(ByRef Str As String) As TRYE
                    Try
                        Dim Converter As New JavaScriptSerializer
                        Dim diag As TRYE = Converter.Deserialize(Of TRYE)(Str)
                        Return diag
                    Catch ex As Exception
                        Dim Buttons As MessageBoxButtons = MessageBoxButtons.OK
                        MessageBox.Show(ex.Message, "ERROR", Buttons)
                    End Try
                    Return Nothing
                End Function

                ''' <summary>
                ''' gets node if Word is found in trie
                ''' </summary>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Function GetNode(ByRef Str As String) As TRYE
                    Str = Str.ToUpper
                    Dim found As Boolean = False
                    'Position in Characterstr

                    'Check Chars
                    If TRYE.CheckNodeExists(Me.Children, Str) = True Then
                        Return TRYE.GetNode(Me.Children, Str)
                        found = True
                    Else
                        'Terminated before end of Word
                        found = False
                    End If

                    'Check for end of word marker
                    Return Nothing

                End Function

                ''' <summary>
                ''' Checks if current node Has children
                ''' </summary>
                ''' <returns></returns>
                Public Function HasChildren() As Boolean
                    Return If(Me.Children.Count > 0 = True, True, False)
                End Function

                ''' <summary>
                ''' Inserts a string into the trie
                ''' </summary>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Function InsertByCharacters(ByRef Str As String) As TRYE
                    Return TRYE.AddStringbyChars(Me, Str)
                End Function

                Public Function InsertBySent(ByRef Str As String) As TRYE
                    Return TRYE.AddItterativelyBySent(Me, Str)
                End Function

                ''' <summary>
                ''' Inserts a string into the trie
                ''' </summary>
                ''' <param name="Str"></param>
                ''' <returns></returns>
                Public Function InsertByWord(ByRef Str As String) As TRYE
                    Return TRYE.AddStringbyWord(Me, Str)
                End Function

                Public Function ToJson() As String
                    Dim Converter As New JavaScriptSerializer
                    Return Converter.Serialize(Me)
                End Function

#End Region

#Region "MakeTree"

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

                ''' <summary>
                ''' Adds char to Node(children) Returning the child
                ''' </summary>
                ''' <param name="CurrentNode">node containing children</param>
                ''' <param name="ChrStr">String to be added </param>
                ''' <param name="CharPos">this denotes the level of the node</param>
                ''' <returns></returns>
                Private Shared Function AddStringToTrie(ByRef CurrentNode As TRYE,
                                                    ByRef ChrStr As String, ByRef CharPos As Integer) As TRYE
                    'start of tree
                    Dim Text As String = ChrStr
                    Dim returnNode As New TRYE
                    Dim NewNode As New TRYE
                    'Goto first node
                    'does this node have siblings
                    If TRYE.HasChildren(CurrentNode) = True Then
                        'Check children
                        If TRYE.CheckNodeExists(CurrentNode.Children, ChrStr) = False Then
                            'create a new node for char
                            NewNode = TRYE.CreateNode(ChrStr, CurrentNode.NodeLevel + 1)
                            NewNode.NodeLevel = CharPos
                            'Add childnode
                            CurrentNode.Children.Add(NewNode)
                            returnNode = TRYE.GetNode(CurrentNode.Children, ChrStr)
                        Else
                            returnNode = TRYE.GetNode(CurrentNode.Children, ChrStr)
                        End If
                    Else
                        'If no silings then Create new node
                        'create a new node for char
                        NewNode = TRYE.CreateNode(ChrStr, CurrentNode.NodeLevel + 1)
                        NewNode.NodeLevel = CharPos
                        'Add childnode
                        CurrentNode.Children.Add(NewNode)
                        returnNode = TRYE.GetNode(CurrentNode.Children, ChrStr)
                    End If

                    Return returnNode
                End Function

                ''' <summary>
                ''' If node does not exist in child node set it is added
                ''' if node already exists then no node is added a node ID is generated
                ''' </summary>
                ''' <param name="NodeData">Character to be added</param>
                Private Shared Function CreateNode(ByRef NodeData As String, ByRef Level As Integer) As TRYE
                    'Create node - 2
                    Dim NewNode As New TRYE(True)
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
                    Dim newnode As TRYE
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

#End Region

#Region "Has_Children"

                ''' <summary>
                ''' Checks if given node has children
                ''' </summary>
                ''' <param name="Node"></param>
                ''' <returns></returns>
                Private Shared Function HasChildren(ByRef Node As TRYE) As Boolean
                    Return If(Node.Children.Count > 0 = True, True, False)
                End Function

#End Region

            End Structure

        End Namespace

    End Namespace
End Namespace