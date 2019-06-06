Attribute VB_Name = "LinkedListOperations"
Option Explicit

'Standard Initialisation of Start Node
Public Sub InitOpen(Val As String, Wgt As Integer, Lev As Integer)
On Error GoTo ErrHandler
    Set OpenNode = New LinkedList
    OpenNode.Value = Val
    OpenNode.Weight = Wgt
    OpenNode.Level = Lev
    Set OpenNode.NextPointer = Nothing
    Exit Sub
ErrHandler:
    MsgBox "Error in OPENING OPEN. Please contact vendor."
End Sub

Public Sub InitClosed(Val As String, Wgt As Integer, Lev As Integer)
On Error GoTo ErrHandler
    Set CloseNode = New LinkedList
    CloseNode.Value = Val
    CloseNode.Weight = Wgt
    CloseNode.Level = Lev
    Set CloseNode.NextPointer = Nothing
    Exit Sub
ErrHandler:
    MsgBox "Error in OPENING CLOSE. Please contact vendor."
End Sub

'Add in the tail of the Linked List OPEN
Public Sub AddInOpen(Val As String, Wgt As Integer, Lev As Integer)
On Error GoTo ErrHandler
    If OpenNode Is Nothing Then
        InitOpen Val, Wgt, Lev
        Exit Sub
    End If
    Set PList = New LinkedList
    Set PList = OpenNode
    
    While Not PList.NextPointer Is Nothing
        Set PList = PList.NextPointer
    Wend
    
    Dim Q As New LinkedList
    Q.Value = Val
    Q.Weight = Wgt
    Q.Level = Lev
    Set PList.NextPointer = Q
    Set Q.NextPointer = Nothing
    Exit Sub
ErrHandler:
    MsgBox "Error in Additon in OPEN. Please check the value or may be memory outbound."
End Sub

'Add in the tail of the Linked List CLOSED
Public Sub AddInClosed(Val As String, Wgt As Integer, Lev As Integer)
On Error GoTo ErrHandler
    If CloseNode Is Nothing Then
        InitClosed Val, Wgt, Lev
        Exit Sub
    End If
    Set PList = New LinkedList
    Set PList = CloseNode
    
    While Not PList.NextPointer Is Nothing
        Set PList = PList.NextPointer
    Wend
    
    Dim Q As New LinkedList
    Q.Value = Val
    Q.Weight = Wgt
    Q.Level = Lev
    Set PList.NextPointer = Q
    Set Q.NextPointer = Nothing
    Exit Sub
ErrHandler:
    MsgBox "Error in Additon in CLOSE. Please check the value or may be memory outbound."
End Sub

'Delete from the required position
Public Sub DeleteFromOPEN(Value As String)
On Error GoTo ErrHandler
    Dim Q As LinkedList
    Set PList = New LinkedList
    Set PList = OpenNode
    Set Q = PList.NextPointer
    If OpenNode.Value <> Value Then
        While (Not Q Is Nothing)
            If (Q.Value <> Value) Then
                Set PList = PList.NextPointer
                Set Q = Q.NextPointer
            Else
                Set PList.NextPointer = Q.NextPointer
                Set Q = PList.NextPointer
            End If
        Wend
        
        If Q Is Nothing Then
            Set PList = Nothing
        End If
    Else
        Set Q = PList.NextPointer
        If Not (Q Is Nothing) Then
            Set OpenNode = Q
            Set PList = OpenNode
        Else
            Set OpenNode = Nothing
        End If
    End If
    Exit Sub
ErrHandler:
    MsgBox "Error in Deletion from OPEN. Please check the position."
End Sub

Public Sub DeleteFromClosed(Value As String)
On Error GoTo ErrHandler
    Dim Q As LinkedList
    Set PList = New LinkedList
    Set PList = CloseNode
    Set Q = PList.NextPointer
    If CloseNode.Value <> Value Then
        While (Not Q Is Nothing)
            If (Q.Value <> Value) Then
                Set PList = PList.NextPointer
                Set Q = Q.NextPointer
            Else
                Set PList.NextPointer = Q.NextPointer
                Set Q = PList.NextPointer
            End If
        Wend
        
        If Q Is Nothing Then
            Set PList = Nothing
        End If
    Else
        Set Q = PList.NextPointer
        If Not (Q Is Nothing) Then
            Set CloseNode = Q
            Set PList = CloseNode
        Else
            Set CloseNode = Nothing
        End If
    End If
    Exit Sub
ErrHandler:
    MsgBox "Error in Deletion from CLOSED. Please check the position."
End Sub

'Search In Open
Public Function GetFromOPEN(Value As String) As LinkedList
On Error GoTo ErrHandler
    Set PList = New LinkedList
    Set PList = OpenNode
    While Not (PList Is Nothing)
        If (PList.Value <> Value) Then
            Set PList = PList.NextPointer
        Else
            Set GetFromOPEN = PList
            Exit Function
        End If
    Wend
    Set GetFromOPEN = PList
    Exit Function
ErrHandler:
    MsgBox "Error in get from OPEN. Please check the position."
End Function

'Search In Open
Public Function GetFromCLOSED(Value As String) As LinkedList
On Error GoTo ErrHandler
    Set PList = New LinkedList
    Set PList = CloseNode
    While Not (PList Is Nothing)
        If (PList.Value <> Value) Then
            Set PList = PList.NextPointer
        Else
            Set GetFromCLOSED = PList
            Exit Function
        End If
    Wend
    Set GetFromCLOSED = PList
    Exit Function
ErrHandler:
    MsgBox "Error in get from CLOSE. Please check the position."
End Function

Public Function GetLowValueOpen() As LinkedList
On Error GoTo ErrHandler
    Dim MinOpen As LinkedList
    Set PList = New LinkedList
    Set PList = OpenNode
    Set MinOpen = PList

    While Not (PList Is Nothing)
        If (MinOpen.Weight) > (PList.Weight) Then
            Set MinOpen = PList
        End If
        Set PList = PList.NextPointer
    Wend
    Set GetLowValueOpen = MinOpen
    Exit Function
ErrHandler:
    MsgBox "Error in get Low Value from Open. Please check the position."
End Function

Public Sub PrintClosed()
    Dim strPath As String
    Set PList = New LinkedList
    Set PList = CloseNode
    
    strPath = "Close List Is (With optimum Path Nodes in between)" & vbCrLf
    While Not (PList Is Nothing)
        strPath = strPath & "(" & PList.Value & " # Weight " & CInt(PList.Weight + PList.Level) & ")" & vbCrLf
        Set PList = PList.NextPointer
    Wend
    'MsgBox strPath
    frmAStarTree.txtOutput.Text = strPath
End Sub

Public Sub PrintOPEN()
    Dim strPath As String
    Set PList = New LinkedList
    Set PList = OpenNode
    
    strPath = "OPEN Path followed = "
    While Not (PList Is Nothing)
        strPath = strPath & "[" & PList.Value & "] # [" & PList.Weight + PList.Level & "]" & vbCrLf
        Set PList = PList.NextPointer
    Wend
    MsgBox strPath
    'Debug.Print strPath
End Sub

