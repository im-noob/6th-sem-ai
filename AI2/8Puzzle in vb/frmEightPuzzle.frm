VERSION 5.00
Begin VB.Form frmEightPuzzle 
   Appearance      =   0  'Flat
   BackColor       =   &H00004080&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "8 Puzzle Solver"
   ClientHeight    =   4890
   ClientLeft      =   4140
   ClientTop       =   3675
   ClientWidth     =   8220
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   4890
   ScaleWidth      =   8220
   Begin VB.CommandButton cmdSolve8Puzzle 
      Appearance      =   0  'Flat
      Caption         =   "&Solve Game"
      Height          =   375
      Left            =   3120
      TabIndex        =   21
      Top             =   4320
      Width           =   1695
   End
   Begin VB.TextBox txtBoard 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial Black"
         Size            =   27.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Index           =   8
      Left            =   2520
      MaxLength       =   1
      TabIndex        =   9
      Text            =   "_"
      Top             =   2760
      Width           =   975
   End
   Begin VB.TextBox txtBoard 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial Black"
         Size            =   27.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Index           =   7
      Left            =   1560
      MaxLength       =   1
      TabIndex        =   8
      Text            =   "8"
      Top             =   2760
      Width           =   975
   End
   Begin VB.TextBox txtBoard 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial Black"
         Size            =   27.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Index           =   6
      Left            =   600
      MaxLength       =   1
      TabIndex        =   7
      Text            =   "7"
      Top             =   2760
      Width           =   975
   End
   Begin VB.TextBox txtBoard 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial Black"
         Size            =   27.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Index           =   5
      Left            =   2520
      MaxLength       =   1
      TabIndex        =   6
      Text            =   "6"
      Top             =   1800
      Width           =   975
   End
   Begin VB.TextBox txtBoard 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial Black"
         Size            =   27.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Index           =   4
      Left            =   1560
      MaxLength       =   1
      TabIndex        =   5
      Text            =   "5"
      Top             =   1800
      Width           =   975
   End
   Begin VB.TextBox txtBoard 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial Black"
         Size            =   27.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Index           =   3
      Left            =   600
      MaxLength       =   1
      TabIndex        =   4
      Text            =   "4"
      Top             =   1800
      Width           =   975
   End
   Begin VB.TextBox txtBoard 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial Black"
         Size            =   27.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Index           =   2
      Left            =   2520
      MaxLength       =   1
      TabIndex        =   3
      Text            =   "3"
      Top             =   840
      Width           =   975
   End
   Begin VB.TextBox txtBoard 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial Black"
         Size            =   27.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Index           =   1
      Left            =   1560
      MaxLength       =   1
      TabIndex        =   2
      Text            =   "2"
      Top             =   840
      Width           =   975
   End
   Begin VB.Frame Frame8Puzzle 
      Caption         =   "Solution Window"
      Height          =   3975
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   7935
      Begin VB.TextBox txtBoard 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial Black"
            Size            =   27.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   975
         Index           =   0
         Left            =   480
         MaxLength       =   1
         TabIndex        =   1
         Text            =   "1"
         Top             =   720
         Width           =   975
      End
      Begin VB.Label Label8 
         Appearance      =   0  'Flat
         BackColor       =   &H00FFC0FF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "START"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   13.5
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   375
         Left            =   1440
         TabIndex        =   20
         Top             =   360
         Width           =   975
      End
      Begin VB.Label Label7 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FFFFC0&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "GOAL"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   24
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   615
         Left            =   5040
         TabIndex        =   19
         Top             =   720
         Width           =   1575
      End
      Begin VB.Label lblGoal 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H008080FF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "_"
         BeginProperty Font 
            Name            =   "Arial Black"
            Size            =   18
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   615
         Index           =   8
         Left            =   6120
         TabIndex        =   18
         Top             =   2520
         Width           =   735
      End
      Begin VB.Label lblGoal 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H008080FF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "8"
         BeginProperty Font 
            Name            =   "Arial Black"
            Size            =   18
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   615
         Index           =   7
         Left            =   5400
         TabIndex        =   17
         Top             =   2520
         Width           =   735
      End
      Begin VB.Label lblGoal 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H008080FF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "7"
         BeginProperty Font 
            Name            =   "Arial Black"
            Size            =   18
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   615
         Index           =   6
         Left            =   4680
         TabIndex        =   16
         Top             =   2520
         Width           =   735
      End
      Begin VB.Label lblGoal 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H008080FF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "6"
         BeginProperty Font 
            Name            =   "Arial Black"
            Size            =   18
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   615
         Index           =   5
         Left            =   6120
         TabIndex        =   15
         Top             =   1920
         Width           =   735
      End
      Begin VB.Label lblGoal 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H008080FF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "5"
         BeginProperty Font 
            Name            =   "Arial Black"
            Size            =   18
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   615
         Index           =   4
         Left            =   5400
         TabIndex        =   14
         Top             =   1920
         Width           =   735
      End
      Begin VB.Label lblGoal 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H008080FF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "4"
         BeginProperty Font 
            Name            =   "Arial Black"
            Size            =   18
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   615
         Index           =   3
         Left            =   4680
         TabIndex        =   13
         Top             =   1920
         Width           =   735
      End
      Begin VB.Label lblGoal 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H008080FF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "3"
         BeginProperty Font 
            Name            =   "Arial Black"
            Size            =   18
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   615
         Index           =   2
         Left            =   6120
         TabIndex        =   12
         Top             =   1320
         Width           =   735
      End
      Begin VB.Label lblGoal 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H008080FF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "2"
         BeginProperty Font 
            Name            =   "Arial Black"
            Size            =   18
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   615
         Index           =   1
         Left            =   5400
         TabIndex        =   11
         Top             =   1320
         Width           =   735
      End
      Begin VB.Label lblGoal 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H008080FF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "1"
         BeginProperty Font 
            Name            =   "Arial Black"
            Size            =   18
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   615
         Index           =   0
         Left            =   4680
         TabIndex        =   10
         Top             =   1320
         Width           =   735
      End
   End
End
Attribute VB_Name = "frmEightPuzzle"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim intIndex As Integer
Dim MyPrevPlace As Integer

Dim NodeParent As EightPuzzleTree

Private Sub cmdSolve8Puzzle_Click()
On Error GoTo ErrHandler
    Dim i As Integer
    Dim boolSolve As Boolean
    
    boolSolve = True
    If SetType = 2 Then
        boolSolve = CheckBoard()
        If Not boolSolve Then
            MsgBox "Error in Input. " & vbCrLf _
            & "Please Distinct Characters '1','2','3','4','5','6','7','8' or '_' only.", _
            vbCritical, App.Title
            Exit Sub
        End If
    End If
    strStart = ""
    For i = 0 To 8
        strStart = strStart & txtBoard(i).Text & " "
        GoalMatrix(Fix(i / 3), i Mod 3) = lblGoal(i).Caption
        txtBoard(i).Locked = True
    Next i
    strStart = Trim(strStart)
    Init strStart
    intIndex = intIndex + 1
    
    MousePointer = vbHourglass
    NumberOfSteps = 0
    Solve "Puzzle"
    MousePointer = vbNormal
    Exit Sub
ErrHandler:
    MsgBox "Unexpected Error. Please contact the Author"
End Sub

Private Sub Form_Load()
    intIndex = 0
    strGoal = "1 2 3 4 5 6 7 8 _"
    MyPrevPlace = 8
End Sub

Public Sub DisplayBoard(strSolution As String)
On Error GoTo ErrHandler
    Dim i As Integer
    Dim TempArr As Variant
    
    TempArr = Split(strSolution, " ", , vbTextCompare)
    For i = 0 To 8
        txtBoard(i).Text = TempArr(i)
    Next i
    Pause (0.8)
    Exit Sub
ErrHandler:
    MsgBox "Unexpected Error. Please contact the Author"
End Sub

Sub Pause(ByVal nSecond As Single)
   'nSeconds should be the number of seconds you want the Pause to last
   '(may be a decimal fraction .5)
   Dim StartTime As Single
   StartTime = Timer
   Do While Timer - StartTime < nSecond
    DoEvents 'Allows you to continue interacting with the rest of your program
    ' if we cross midnight, back up one day
    If Timer < StartTime Then
    ' separating the numbers stops a nasty overflow error
        StartTime = StartTime - 24 * 60 * 60
    End If
   Loop
End Sub

Private Sub Form_Activate()
    Dim i As Integer
    Dim MyValue As Integer
    
    bClose = False
    MyValue = 4
    Randomize MyValue
    If SetType <> 2 And frm8PuzzleMDIForm.mnuAutomaticShuffling.Checked Then
        For i = 0 To 8
            txtBoard(i).Locked = True
        Next i
        If SetType = 0 Then
            MousePointer = vbArrowHourglass
            For i = 1 To 100
                MyValue = Int((4 * Rnd(MyValue)) + 1)
                Select Case MyValue
                    Case 1: 'Up
                            If MyPrevPlace >= 3 Then
                                MoveUp
                            End If
                    Case 2: 'Down
                            If MyPrevPlace <= 5 Then
                                MoveDown
                            End If
                    Case 3: 'Left
                            If MyPrevPlace = 0 Or MyPrevPlace Mod 2 <> 0 Then
                                MoveRight
                            End If
                    Case 4: 'Right
                            If MyPrevPlace Mod 3 <> 0 Then
                                MoveLeft
                            End If
                End Select
                Pause 0.1
            Next i
            MousePointer = vbNormal
        End If
    End If
End Sub

Private Sub MoveUp()
    Dim TempStr As String
    TempStr = txtBoard(MyPrevPlace).Text
    txtBoard(MyPrevPlace).Text = txtBoard(MyPrevPlace - 3).Text
    txtBoard(MyPrevPlace - 3).Text = TempStr
    MyPrevPlace = MyPrevPlace - 3
End Sub

Private Sub MoveDown()
    Dim TempStr As String
    TempStr = txtBoard(MyPrevPlace).Text
    txtBoard(MyPrevPlace).Text = txtBoard(MyPrevPlace + 3).Text
    txtBoard(MyPrevPlace + 3).Text = TempStr
    MyPrevPlace = MyPrevPlace + 3
End Sub

Private Sub MoveLeft()
    Dim TempStr As String
    TempStr = txtBoard(MyPrevPlace).Text
    txtBoard(MyPrevPlace).Text = txtBoard(MyPrevPlace - 1).Text
    txtBoard(MyPrevPlace - 1).Text = TempStr
    MyPrevPlace = MyPrevPlace - 1
End Sub

Private Sub MoveRight()
    Dim TempStr As String
    TempStr = txtBoard(MyPrevPlace).Text
    txtBoard(MyPrevPlace).Text = txtBoard(MyPrevPlace + 1).Text
    txtBoard(MyPrevPlace + 1).Text = TempStr
    MyPrevPlace = MyPrevPlace + 1
End Sub

Private Function CheckBoard() As Boolean
    Dim i As Integer
    Dim j As Integer
    CheckBoard = True
    
    For i = 0 To 8
        If InStr(1, "12345678_", txtBoard(i).Text, vbTextCompare) = 0 Then
             CheckBoard = False
             Exit Function
        End If
        For j = 0 To 8
            If j <> i Then
                If txtBoard(j).Text = txtBoard(i).Text Then
                    CheckBoard = False
                    Exit Function
                End If
            End If
        Next j
    Next i
    
End Function

Private Sub Form_Terminate()
    bClose = True
End Sub

Private Sub Form_Unload(Cancel As Integer)
    bClose = True
End Sub

Private Sub txtBoard_Click(Index As Integer)
    If SetType = 0 Or SetType = 1 Then
        Select Case Index
            Case MyPrevPlace - 3:
                                MoveUp
            Case MyPrevPlace + 3:
                                MoveDown
            Case MyPrevPlace - 1:
                                MoveLeft
            Case MyPrevPlace + 1:
                                MoveRight
        End Select
    End If
End Sub

Private Sub txtBoard_GotFocus(Index As Integer)
    If SetType = 0 Or SetType = 1 Then
        cmdSolve8Puzzle.SetFocus
    End If
End Sub
