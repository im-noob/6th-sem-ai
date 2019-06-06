VERSION 5.00
Begin VB.Form frmAStarTree 
   Appearance      =   0  'Flat
   BackColor       =   &H00C0E0FF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "A* Tester"
   ClientHeight    =   5535
   ClientLeft      =   3525
   ClientTop       =   3465
   ClientWidth     =   8835
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   5535
   ScaleWidth      =   8835
   Begin VB.TextBox txtOutput 
      Appearance      =   0  'Flat
      BackColor       =   &H00C0FFFF&
      Height          =   2895
      Left            =   120
      Locked          =   -1  'True
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   21
      Text            =   "frmAStarTree.frx":0000
      Top             =   2520
      Width           =   8535
   End
   Begin VB.ListBox lstNodes 
      Appearance      =   0  'Flat
      Height          =   1980
      Left            =   240
      TabIndex        =   12
      Top             =   360
      Width           =   2415
   End
   Begin VB.TextBox txtUp 
      Appearance      =   0  'Flat
      Height          =   375
      Left            =   3720
      TabIndex        =   11
      Top             =   960
      Width           =   975
   End
   Begin VB.TextBox txtDown 
      Appearance      =   0  'Flat
      Height          =   375
      Left            =   3720
      TabIndex        =   10
      Top             =   1320
      Width           =   975
   End
   Begin VB.TextBox txtLeft 
      Appearance      =   0  'Flat
      Height          =   375
      Left            =   3720
      TabIndex        =   9
      Top             =   1680
      Width           =   975
   End
   Begin VB.TextBox txtRight 
      Appearance      =   0  'Flat
      Height          =   375
      Left            =   3720
      TabIndex        =   8
      Top             =   2040
      Width           =   975
   End
   Begin VB.CommandButton cmdSolve 
      Appearance      =   0  'Flat
      Caption         =   "&Solve"
      Height          =   375
      Left            =   6600
      TabIndex        =   7
      Top             =   1560
      Width           =   1095
   End
   Begin VB.TextBox txtStart 
      Appearance      =   0  'Flat
      Height          =   375
      Left            =   6120
      TabIndex        =   6
      Top             =   1080
      Width           =   1095
   End
   Begin VB.TextBox txtGoal 
      Appearance      =   0  'Flat
      Height          =   375
      Left            =   7200
      TabIndex        =   5
      Top             =   1080
      Width           =   1095
   End
   Begin VB.CommandButton cmdAdd 
      Appearance      =   0  'Flat
      Caption         =   "&Add"
      Height          =   375
      Left            =   6600
      TabIndex        =   4
      Top             =   360
      Width           =   1095
   End
   Begin VB.TextBox txtUpWeight 
      Appearance      =   0  'Flat
      Height          =   375
      Left            =   4680
      MaxLength       =   2
      TabIndex        =   3
      Top             =   960
      Width           =   975
   End
   Begin VB.TextBox txtDownWeight 
      Appearance      =   0  'Flat
      Height          =   375
      Left            =   4680
      MaxLength       =   2
      TabIndex        =   2
      Top             =   1320
      Width           =   975
   End
   Begin VB.TextBox txtLeftWeight 
      Appearance      =   0  'Flat
      Height          =   375
      Left            =   4680
      MaxLength       =   2
      TabIndex        =   1
      Top             =   1680
      Width           =   975
   End
   Begin VB.TextBox txtRightWeight 
      Appearance      =   0  'Flat
      Height          =   375
      Left            =   4680
      MaxLength       =   2
      TabIndex        =   0
      Top             =   2040
      Width           =   975
   End
   Begin VB.Label Label8 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "Weight"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   4680
      TabIndex        =   23
      Top             =   720
      Width           =   975
   End
   Begin VB.Label Label7 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "Name"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   3720
      TabIndex        =   22
      Top             =   720
      Width           =   975
   End
   Begin VB.Label lblEntry 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H80000001&
      BackStyle       =   0  'Transparent
      Caption         =   "Click a Parent && Enter Children Then Click Add"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C00000&
      Height          =   375
      Left            =   3240
      TabIndex        =   20
      Top             =   120
      Width           =   2775
   End
   Begin VB.Label lblSLogan 
      BackStyle       =   0  'Transparent
      Caption         =   "Node List"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   240
      TabIndex        =   19
      Top             =   120
      Width           =   1095
   End
   Begin VB.Label Label1 
      BackColor       =   &H00C0FFFF&
      Caption         =   "Up"
      Height          =   255
      Left            =   3120
      TabIndex        =   18
      Top             =   960
      Width           =   615
   End
   Begin VB.Label Label2 
      BackColor       =   &H00C0FFFF&
      Caption         =   "Down"
      Height          =   255
      Left            =   3120
      TabIndex        =   17
      Top             =   1320
      Width           =   615
   End
   Begin VB.Label Label3 
      BackColor       =   &H00C0FFFF&
      Caption         =   "Left"
      Height          =   255
      Left            =   3120
      TabIndex        =   16
      Top             =   1680
      Width           =   615
   End
   Begin VB.Label Label4 
      BackColor       =   &H00C0FFFF&
      Caption         =   "Right"
      Height          =   255
      Left            =   3120
      TabIndex        =   15
      Top             =   2040
      Width           =   615
   End
   Begin VB.Label Label5 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00FFC0C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Start State"
      ForeColor       =   &H80000008&
      Height          =   255
      Left            =   6120
      TabIndex        =   14
      Top             =   840
      Width           =   1095
   End
   Begin VB.Label Label6 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00C0C0FF&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Goal State"
      ForeColor       =   &H80000008&
      Height          =   255
      Left            =   7200
      TabIndex        =   13
      Top             =   840
      Width           =   1095
   End
End
Attribute VB_Name = "frmAStarTree"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim intIndex As Integer
Dim NodeParent As EightPuzzleTree

Dim tempSolMatrix(2, 2) As String

Private Sub cmdAdd_Click()
On Error GoTo Errhandler
    Set NodeParent = New EightPuzzleTree
    If lstNodes.ListCount = 0 Then
        strStart = txtStart.Text
        lstNodes.AddItem strStart, intIndex
        Init strStart
        intIndex = intIndex + 1
    Else
        Set NodeParent = GetNode(TreeRoot, lstNodes.Text)
        If txtUp.Text <> "" Then
            lstNodes.AddItem txtUp.Text, intIndex
            intIndex = intIndex + 1
            AddNode txtUp.Text, CInt(txtUpWeight.Text), NodeParent.Level + 1, NodeParent, 0
        End If
        If txtDown.Text <> "" Then
            lstNodes.AddItem txtDown.Text, intIndex
            intIndex = intIndex + 1
            AddNode txtDown.Text, CInt(txtDownWeight.Text), NodeParent.Level + 1, NodeParent, 1
        End If
        If txtLeft.Text <> "" Then
            lstNodes.AddItem txtLeft.Text, intIndex
            intIndex = intIndex + 1
            AddNode txtLeft.Text, CInt(txtLeftWeight.Text), NodeParent.Level + 1, NodeParent, 2
        End If
        If txtRight.Text <> "" Then
            lstNodes.AddItem txtRight.Text, intIndex
            intIndex = intIndex + 1
            AddNode txtRight.Text, CInt(txtRightWeight.Text), NodeParent.Level + 1, NodeParent, 3
        End If
    End If
    Exit Sub
Errhandler:
    MsgBox "Invalid Input or Tree out of memory.", vbCritical, App.Title
    txtUp.SetFocus
End Sub

Private Sub cmdSolve_Click()
On Error GoTo Errhandler
    strGoal = txtGoal.Text
    If strGoal = "" Then
        MsgBox "Please enter the Goal State Name"
    Else
        Solve "Tree"
    End If
    Exit Sub
Errhandler:
    MsgBox "Unexpected Error. Please contact the Author"
End Sub

Private Sub Form_Load()
    intIndex = 0
End Sub

Private Sub Form_Paint()
    txtStart.SetFocus
End Sub

Private Sub lstNodes_Click()
On Error GoTo Errhandler
    Set NodeParent = GetNode(TreeRoot, lstNodes.Text)
    
    txtUp.Text = ""
    txtUpWeight.Text = ""
    txtDown.Text = ""
    txtDownWeight.Text = ""
    txtLeft.Text = ""
    txtLeftWeight.Text = ""
    txtRight.Text = ""
    txtRightWeight.Text = ""
    
    If Not (NodeParent.UpLink Is TreeRoot Or NodeParent.UpLink Is Nothing) Then
        txtUp.Text = NodeParent.UpLink.Value
        txtUpWeight.Text = NodeParent.UpLink.Weight
    End If
    If Not (NodeParent.DownLink Is TreeRoot Or NodeParent.DownLink Is Nothing) Then
        txtDown.Text = NodeParent.DownLink.Value
        txtDownWeight.Text = NodeParent.DownLink.Weight
    End If
    If Not (NodeParent.LeftLink Is TreeRoot Or NodeParent.LeftLink Is Nothing) Then
        txtLeft.Text = NodeParent.LeftLink.Value
        txtLeftWeight.Text = NodeParent.LeftLink.Weight
    End If
    If Not (NodeParent.RightLink Is TreeRoot Or NodeParent.RightLink Is Nothing) Then
        txtRight.Text = NodeParent.RightLink.Value
        txtRightWeight.Text = NodeParent.RightLink.Weight
    End If
    txtUp.SetFocus
    Exit Sub
Errhandler:
    MsgBox "Unexpected Error. Please contact the Author"
End Sub

