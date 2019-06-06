Attribute VB_Name = "TreeOperations"
Option Explicit

Dim boolFound As Boolean
Dim Node_Current As LinkedList
Dim NodeParent As EightPuzzleTree
Dim TempArr As Variant
Dim tempSolMatrix(2, 2) As String
Dim SpacePos As Integer
    
Public Sub Init(Value As String)
On Error GoTo ErrHandler
    Set TreeRoot = New EightPuzzleTree
    With TreeRoot
        .Value = Value
        .Weight = 100
        .Level = 0
        Set .ParentLink = Nothing
        Set .UpLink = Nothing
        Set .DownLink = Nothing
        Set .LeftLink = Nothing
        Set .RightLink = Nothing
    End With
    Exit Sub
ErrHandler:
    MsgBox "Unexpected Error. Please contact the Author"
End Sub

Public Sub AddNode(Value As String, Weight As Integer, Level As Integer, ByRef Parent As EightPuzzleTree, Direction As Integer)
On Error GoTo ErrHandler
    Set PTree = New EightPuzzleTree
    
    With PTree
        .Value = Value
        .Weight = Weight
        .Level = Level
        Set .ParentLink = Parent
        Set .UpLink = Nothing
        Set .DownLink = Nothing
        Set .LeftLink = Nothing
        Set .RightLink = Nothing
    End With
    
    With Parent
        Select Case Direction
            Case 0: Set .UpLink = PTree
            Case 1: Set .DownLink = PTree
            Case 2: Set .LeftLink = PTree
            Case 3: Set .RightLink = PTree
        End Select
    End With
    Exit Sub
ErrHandler:
    MsgBox "Unexpected Error. Please contact the Author"
End Sub

Public Function GetNode(TreeNode1 As EightPuzzleTree, Value As String) As EightPuzzleTree
On Error GoTo ErrHandler
    If Not TreeNode1 Is Nothing Then
        If TreeNode1.Value = Value Then
            Set GetNode = TreeNode1
        Else
            Dim Q As EightPuzzleTree
            Set Q = GetNode(TreeNode1.UpLink, Value)
            If Not Q Is Nothing Then
                Set GetNode = Q
                Exit Function
            End If
            Set Q = GetNode(TreeNode1.DownLink, Value)
            If Not Q Is Nothing Then
                Set GetNode = Q
                Exit Function
            End If
            Set Q = GetNode(TreeNode1.LeftLink, Value)
            If Not Q Is Nothing Then
                Set GetNode = Q
                Exit Function
            End If
            Set Q = GetNode(TreeNode1.RightLink, Value)
            If Not Q Is Nothing Then
                Set GetNode = Q
                Exit Function
            End If
        End If
    Else
        Set GetNode = Nothing
    End If
    Exit Function
ErrHandler:
    MsgBox "Unexpected Error. Please contact the Author"
End Function


'ACTUAL A* ALGORITHM HERE .............

Public Sub Solve(strPuzzleOrTree As String)
On Error GoTo ErrHandler
    Dim i As Integer
    Dim searchTemp As LinkedList
    Dim StartTime As Date
    
    If strPuzzleOrTree = "Puzzle" Then
        DownLinks = Array(0, 0, 0, 1, 1, 1, 1, 1, 1)
        UpLinks = Array(1, 1, 1, 1, 1, 1, 0, 0, 0)
        LeftLinks = Array(1, 1, 0, 1, 1, 0, 1, 1, 0)
        RightLinks = Array(0, 1, 1, 0, 1, 1, 0, 1, 1)
        
        TempArr = Split(TreeRoot.Value, " ", , vbTextCompare)
        For i = 0 To 8
            SolutionMatrix(Fix(i / 3), i Mod 3) = TempArr(i)
            tempSolMatrix(Fix(i / 3), i Mod 3) = TempArr(i)
            If TempArr(i) = "_" Then
                SpacePos = i
            End If
        Next i
        TreeRoot.Weight = Heuristic(tempSolMatrix)
    End If
    Set NodeParent = TreeRoot
    
    InitOpen TreeRoot.Value, TreeRoot.Weight, TreeRoot.Level
    InitClosed TreeRoot.Value, TreeRoot.Weight, TreeRoot.Level
    
    StartTime = Now
    While Not OpenNode Is Nothing
        If GetSecond(Now) - GetSecond(StartTime) > 10 Then
            If MsgBox("It Seems the Problem is unsolvable or the solution path is too deep. " & vbCrLf _
            & "Do You Really Want To Continue? ", vbYesNo, "Solution Too Deep") = vbNo Then
                Exit Sub
            Else
                StartTime = Now
            End If
        End If
        
        Set Node_Current = GetLowValueOpen
        
'DEBUG File Output ======================================================================
        
'
'            Dim strPath As String
'            Set PList = New LinkedList
'            Set PList = OpenNode
'
'            strPath = "OPEN Path followed = " & vbCrLf
'            While Not (PList Is Nothing)
'                strPath = strPath & "[" & PList.Value & "] # [" & PList.Weight & "]+[" & PList.Level & "]" & vbCrLf
'                Set PList = PList.NextPointer
'            Wend7
'            Print #1, vbCrLf & strPath & vbCrLf
'
'        Print #1, "Lowest Selected: " & vbCrLf
'        Print #1, Formatatted(Node_Current.Value)
'        Print #1, "=================" & vbCrLf
        
'DEBUG File Output End Here =============================================================
        
        DeleteFromOPEN Node_Current.Value
        Set NodeParent = GetNode(TreeRoot, Node_Current.Value)
        
        If strPuzzleOrTree = "Puzzle" Then
            If Node_Current.Value = strGoal Then
                AddInClosed Node_Current.Value, Node_Current.Weight, Node_Current.Level
                TraceSolution NodeParent
                MsgBox "Bingo! Solution achieved in " & (NumberOfSteps - 1) & " steps"
                Exit Sub
            End If
            If Not bClose Then
                Expand 'Expand NodeParent Children and Add them in solution Tree
            Else
                Exit Sub
            End If
        ElseIf strPuzzleOrTree = "Tree" Then
            If Node_Current.Value = strGoal Then
                AddInClosed Node_Current.Value, Node_Current.Weight, Node_Current.Level
                frmAStarTree.txtOutput.Text = "PATH TRAVERSED IS ..."
                TraceTree NodeParent
                Exit Sub
            End If
        End If
        
        For i = 1 To 4
            Select Case i
                Case 1:
                        If Not (NodeParent.UpLink Is Nothing) Then
' =========================================================================================================================
'                            Print #1, "Up Link : " & CInt(NodeParent.UpLink.Weight + NodeParent.UpLink.Level) & vbCrLf
'                            Print #1, Formatatted(NodeParent.UpLink.Value)
'                            Print #1, "-----------" & vbCrLf
' =========================================================================================================================
                            Set searchTemp = GetFromOPEN(NodeParent.UpLink.Value)
                            If Not searchTemp Is Nothing Then
                                If searchTemp.Value <> NodeParent.ParentLink.Value Then
                                    If searchTemp.Weight + searchTemp.Level < NodeParent.UpLink.Weight + NodeParent.UpLink.Level Then
                                        Set searchTemp = GetFromCLOSED(NodeParent.UpLink.Value)
                                        If searchTemp Is Nothing Then
                                            DeleteFromOPEN NodeParent.UpLink.Value
                                            AddInOpen NodeParent.UpLink.Value, NodeParent.UpLink.Weight, NodeParent.UpLink.Level
                                        End If
                                    End If
                                    'Set searchTemp = GetFromCLOSED(NodeParent.UpLink.Value)
                                    'If Not NodeParent.UpLink Is Nothing Then
                                    '   If searchTemp.Weight + searchTemp.Level > NodeParent.LeftLink.Weight + NodeParent.LeftLink.Level Then
                                    '       DeleteFromClosed NodeParent.UpLink.Value
                                    '       AddInClosed NodeParent.UpLink.Value, NodeParent.UpLink.Weight, NodeParent.UpLink.Level
                                    '   End If
                                    'End If
                                End If
                            ElseIf searchTemp Is Nothing Then
                                Set searchTemp = GetFromCLOSED(NodeParent.UpLink.Value)
                                If searchTemp Is Nothing Then AddInOpen NodeParent.UpLink.Value, NodeParent.UpLink.Weight, NodeParent.UpLink.Level
                            End If
                        End If
                Case 2:
                        If Not (NodeParent.DownLink Is Nothing) Then
                            Set searchTemp = GetFromOPEN(NodeParent.DownLink.Value)
' =========================================================================================================================
'                            Print #1, "Down Link : " & CInt(NodeParent.DownLink.Weight + NodeParent.DownLink.Level) & vbCrLf
'                            Print #1, Formatatted(NodeParent.DownLink.Value)
'                            Print #1, "-----------" & vbCrLf
' =========================================================================================================================
                            If Not searchTemp Is Nothing Then
                                If searchTemp.Value <> NodeParent.ParentLink.Value Then
                                    If searchTemp.Weight + searchTemp.Level < NodeParent.DownLink.Weight + NodeParent.DownLink.Level Then
                                        Set searchTemp = GetFromCLOSED(NodeParent.DownLink.Value)
                                        If searchTemp Is Nothing Then
                                            DeleteFromOPEN NodeParent.DownLink.Value
                                            AddInOpen NodeParent.DownLink.Value, NodeParent.DownLink.Weight, NodeParent.DownLink.Level
                                        End If
                                    End If
                                    'Set searchTemp = GetFromCLOSED(NodeParent.DownLink.Value)
                                    'If Not NodeParent.DownLink Is Nothing Then
                                    'If searchTemp.Weight + searchTemp.Level > NodeParent.LeftLink.Weight + NodeParent.LeftLink.Level Then
                                    '    DeleteFromClosed NodeParent.DownLink.Value
                                    '    AddInClosed NodeParent.DownLink.Value, NodeParent.DownLink.Weight, NodeParent.DownLink.Level
                                    'End If
                                End If
                            ElseIf searchTemp Is Nothing Then
                                Set searchTemp = GetFromCLOSED(NodeParent.DownLink.Value)
                                If searchTemp Is Nothing Then AddInOpen NodeParent.DownLink.Value, NodeParent.DownLink.Weight, NodeParent.DownLink.Level
                            End If
                        End If
                Case 3:
                        If Not (NodeParent.LeftLink Is Nothing) Then
' =========================================================================================================================
'                            Print #1, "Left Link : " & CInt(NodeParent.LeftLink.Weight + NodeParent.LeftLink.Level) & vbCrLf
'                            Print #1, Formatatted(NodeParent.LeftLink.Value)
'                            Print #1, "-----------" & vbCrLf
' =========================================================================================================================
                            Set searchTemp = GetFromOPEN(NodeParent.LeftLink.Value)
                            If Not searchTemp Is Nothing Then
                                If searchTemp.Value <> NodeParent.ParentLink.Value Then
                                    If searchTemp.Weight + searchTemp.Level < NodeParent.LeftLink.Weight + NodeParent.LeftLink.Level Then
                                        Set searchTemp = GetFromCLOSED(NodeParent.LeftLink.Value)
                                        If searchTemp Is Nothing Then
                                            DeleteFromOPEN NodeParent.LeftLink.Value
                                            AddInOpen NodeParent.LeftLink.Value, NodeParent.LeftLink.Weight, NodeParent.LeftLink.Level
                                        End If
                                    End If
                                    'End If
                                    'Set searchTemp = GetFromCLOSED(NodeParent.LeftLink.Value)
                                    'If Not NodeParent.LeftLink Is Nothing Then
                                    'If searchTemp.Weight + searchTemp.Level > NodeParent.LeftLink.Weight + NodeParent.LeftLink.Level Then
                                    '        DeleteFromClosed NodeParent.LeftLink.Value
                                    '        AddInClosed NodeParent.LeftLink.Value, NodeParent.LeftLink.Weight, NodeParent.LeftLink.Level
                                    'End If
                                End If
                            ElseIf searchTemp Is Nothing Then
                                Set searchTemp = GetFromCLOSED(NodeParent.LeftLink.Value)
                                If searchTemp Is Nothing Then AddInOpen NodeParent.LeftLink.Value, NodeParent.LeftLink.Weight, NodeParent.LeftLink.Level
                            End If
                        End If
                Case 4:
                        If Not (NodeParent.RightLink Is Nothing) Then
                            Set searchTemp = GetFromOPEN(NodeParent.RightLink.Value)
' =========================================================================================================================
'                            Print #1, "Right Link : " & CInt(NodeParent.RightLink.Weight + NodeParent.RightLink.Level) & vbCrLf
'                            Print #1, Formatatted(NodeParent.RightLink.Value)
'                            Print #1, "-----------" & vbCrLf
' =========================================================================================================================
                            If Not searchTemp Is Nothing Then
                                If searchTemp.Value <> NodeParent.ParentLink.Value Then
                                    If searchTemp.Weight + searchTemp.Level < NodeParent.RightLink.Weight + NodeParent.RightLink.Level Then
                                        Set searchTemp = GetFromCLOSED(NodeParent.RightLink.Value)
                                        If searchTemp Is Nothing Then
                                            DeleteFromOPEN NodeParent.RightLink.Value
                                            AddInOpen NodeParent.RightLink.Value, NodeParent.RightLink.Weight, NodeParent.RightLink.Level
                                        End If
                                    End If
                                    'Set searchTemp = GetFromCLOSED(NodeParent.RightLink.Value)
                                    'If Not NodeParent.RightLink Is Nothing Then
                                    '    if searchTemp.Weight + searchTemp.Level > NodeParent.RightLink.Weight + NodeParent.RightLink.Level Then
                                    '        DeleteFromClosed NodeParent.RightLink.Value
                                    '        AddInClosed NodeParent.RightLink.Value, NodeParent.RightLink.Weight, NodeParent.RightLink.Level
                                    '    End If
                                    'End If
                                End If
                            ElseIf searchTemp Is Nothing Then
                                Set searchTemp = GetFromCLOSED(NodeParent.RightLink.Value)
                                If searchTemp Is Nothing Then AddInOpen NodeParent.RightLink.Value, NodeParent.RightLink.Weight, NodeParent.RightLink.Level
                            End If
                        End If
            End Select
        Next i
        DeleteFromClosed NodeParent.Value
        AddInClosed NodeParent.Value, NodeParent.Weight, NodeParent.Level
    Wend
    Exit Sub
ErrHandler:
    MsgBox "Unexpected Error in A* Solving . Please contact the Author"
End Sub

Public Function Formatatted(Val As String) As String
    Dim i As Integer
    Dim Arr As Variant
    Dim strVal As String
    
    Arr = Split(Val, " ", , vbTextCompare)
    strVal = ""
    For i = 1 To 9
        If i Mod 3 = 0 Then
            strVal = strVal & Arr(i - 1) & vbCrLf
        Else
            strVal = strVal & Arr(i - 1) & " "
        End If
    Next i
    Formatatted = strVal
End Function

Public Function GetSecond(cTemp As Date) As Long
    Dim Hs As Long
    Dim Ms As Long
    Dim Sec As Long
    
    Sec = Second(cTemp)
    Ms = Minute(cTemp) * 60
    Hs = Hour(cTemp) * 60 * 60
    
    Sec = Sec + Ms + Hs
    
    GetSecond = Sec
End Function

Public Sub Expand()
On Error GoTo ErrHandler
    Dim i As Integer
    Dim temp As String
    Dim strValue As String
    Dim intWeight As Integer
    
    TempArr = Split(NodeParent.Value, " ", , vbTextCompare)
    For i = 0 To 8
        SolutionMatrix(Fix(i / 3), i Mod 3) = TempArr(i)
        tempSolMatrix(Fix(i / 3), i Mod 3) = TempArr(i)
        If TempArr(i) = "_" Then
            SpacePos = i
        End If
    Next i
    
    'Up Link Child
    If UpLinks(SpacePos) = 1 Then
        temp = tempSolMatrix(Fix(SpacePos / 3), SpacePos Mod 3)
        tempSolMatrix(Fix(SpacePos / 3), SpacePos Mod 3) = tempSolMatrix(Fix(SpacePos / 3) + 1, SpacePos Mod 3)
        tempSolMatrix(Fix(SpacePos / 3) + 1, SpacePos Mod 3) = temp
        
        strValue = GetString(tempSolMatrix)
        intWeight = Heuristic(tempSolMatrix)
        AddNode strValue, intWeight, NodeParent.Level + 1, NodeParent, 0
        
        For i = 0 To 8
            tempSolMatrix(Fix(i / 3), i Mod 3) = TempArr(i)
            If TempArr(i) = "_" Then
                SpacePos = i
            End If
        Next i
    End If
    
    'Down Link Child
    If DownLinks(SpacePos) = 1 Then
        temp = tempSolMatrix(Fix(SpacePos / 3), SpacePos Mod 3)
        tempSolMatrix(Fix(SpacePos / 3), SpacePos Mod 3) = tempSolMatrix(Fix(SpacePos / 3) - 1, SpacePos Mod 3)
        tempSolMatrix(Fix(SpacePos / 3) - 1, SpacePos Mod 3) = temp
        
        strValue = GetString(tempSolMatrix)
        intWeight = Heuristic(tempSolMatrix)
        AddNode strValue, intWeight, NodeParent.Level + 1, NodeParent, 1
        For i = 0 To 8
            tempSolMatrix(Fix(i / 3), i Mod 3) = TempArr(i)
            If TempArr(i) = "_" Then
                SpacePos = i
            End If
        Next i
    End If
    
    'Left Link Child
    If LeftLinks(SpacePos) = 1 Then
        temp = tempSolMatrix(Fix(SpacePos / 3), SpacePos Mod 3)
        tempSolMatrix(Fix(SpacePos / 3), SpacePos Mod 3) = tempSolMatrix(Fix(SpacePos / 3), (SpacePos Mod 3) + 1)
        tempSolMatrix(Fix(SpacePos / 3), (SpacePos Mod 3) + 1) = temp
        
        strValue = GetString(tempSolMatrix)
        intWeight = Heuristic(tempSolMatrix)
        AddNode strValue, intWeight, NodeParent.Level + 1, NodeParent, 2
        For i = 0 To 8
            tempSolMatrix(Fix(i / 3), i Mod 3) = TempArr(i)
            If TempArr(i) = "_" Then
                SpacePos = i
            End If
        Next i
    End If
    
    'Right Link Child
    If RightLinks(SpacePos) = 1 Then
        temp = tempSolMatrix(Fix(SpacePos / 3), SpacePos Mod 3)
        tempSolMatrix(Fix(SpacePos / 3), SpacePos Mod 3) = tempSolMatrix(Fix(SpacePos / 3), (SpacePos Mod 3) - 1)
        tempSolMatrix(Fix(SpacePos / 3), (SpacePos Mod 3) - 1) = temp
        
        strValue = GetString(tempSolMatrix)
        intWeight = Heuristic(tempSolMatrix)
        AddNode strValue, intWeight, NodeParent.Level + 1, NodeParent, 3
        For i = 0 To 8
            tempSolMatrix(Fix(i / 3), i Mod 3) = TempArr(i)
            If TempArr(i) = "_" Then
                SpacePos = i
            End If
        Next i
    End If
    Exit Sub
ErrHandler:
    MsgBox "Error in Expanding Node Children. Please Contact Author", vbCritical
    PrintOPEN
    PrintClosed
End Sub

Public Function GetString(MtrxSolution As Variant) As String
    Dim i As Integer
    Dim j As Integer
    Dim strValue As String
    strValue = ""
    For i = 0 To 2
        For j = 0 To 2
            strValue = strValue & MtrxSolution(i, j) & " "
        Next j
    Next i
    If Trim(strValue) = "1 2 3 4 5 6 7 8 _" Then
        i = 0
    End If
    GetString = Trim(strValue)
End Function

Public Function Heuristic(MtrxSolution As Variant) As Integer
    Dim i As Integer
    Dim j As Integer
    Dim S As Integer
    
    S = 0
    For i = 0 To 2
        For j = 0 To 2
            If (MtrxSolution(i, j) <> "_") And (MtrxSolution(i, j) <> GoalMatrix(i, j)) Then
                S = S + Abs(Fix((MtrxSolution(i, j) - 1) / 3) - i) + Abs((MtrxSolution(i, j) - 1) Mod 3 - j) + 1
            End If
        Next j
    Next i
    Heuristic = S + 1
End Function

Public Function TraceSolution(iNode As EightPuzzleTree)
    If Not bClose Then
        If Not (iNode Is Nothing) Then
            TraceSolution iNode.ParentLink
            NumberOfSteps = NumberOfSteps + 1
            frmEightPuzzle.DisplayBoard iNode.Value
        End If
    End If
End Function

Public Function TraceTree(iNode As EightPuzzleTree)
    If Not (iNode Is Nothing) Then
        TraceTree iNode.ParentLink
        frmAStarTree.txtOutput.Text = frmAStarTree.txtOutput.Text & vbCrLf & _
                                      "[" & iNode.Value & "] Weight [" & iNode.Weight & "]"
    End If
End Function


