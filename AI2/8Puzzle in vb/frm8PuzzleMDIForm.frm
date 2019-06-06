VERSION 5.00
Begin VB.MDIForm frm8PuzzleMDIForm 
   BackColor       =   &H80000015&
   Caption         =   "8 Puzzle Solver"
   ClientHeight    =   3195
   ClientLeft      =   6615
   ClientTop       =   5235
   ClientWidth     =   4680
   LinkTopic       =   "MDIForm1"
   WindowState     =   2  'Maximized
   Begin VB.Menu mnuNewGame 
      Caption         =   "&New Game"
      Begin VB.Menu mnu8PuzzleGame 
         Caption         =   "8 Puzzle Game"
      End
      Begin VB.Menu mnuAStarAlgorithm 
         Caption         =   "A* Tree"
      End
      Begin VB.Menu mnu 
         Caption         =   "-"
      End
      Begin VB.Menu mnuClose 
         Caption         =   "Close"
      End
   End
   Begin VB.Menu mnuSeetings 
      Caption         =   "&Settings"
      Begin VB.Menu mnuAutomaticShuffling 
         Caption         =   "&Automatic Shuffling"
      End
      Begin VB.Menu mnuManual 
         Caption         =   "&Manual"
         Begin VB.Menu mnuManualShuffle 
            Caption         =   "&Shuffling"
            Checked         =   -1  'True
         End
         Begin VB.Menu mnuManualEntry 
            Caption         =   "&Entry"
         End
      End
   End
   Begin VB.Menu mnuHelp 
      Caption         =   "&Help"
      Begin VB.Menu mnuHowToPlay 
         Caption         =   "&How to Play"
         Begin VB.Menu mnu8Puzzle 
            Caption         =   "&8 Puzzle"
         End
         Begin VB.Menu mnuAStar 
            Caption         =   "&A* Tree"
         End
      End
      Begin VB.Menu mnu1 
         Caption         =   "-"
      End
      Begin VB.Menu mnuAbout 
         Caption         =   "A&bout"
      End
   End
End
Attribute VB_Name = "frm8PuzzleMDIForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub MDIForm_Load()
    SetType = 0
    HelpType = 0
End Sub

Private Sub mnu8Puzzle_Click()
    HelpType = 1
    frmHelpView.Show
End Sub

Private Sub mnu8PuzzleGame_Click()
    If mnuAutomaticShuffling.Checked Then MsgBox "Please Click OK to Perform Automatic Shuffling "
    If mnuManualShuffle.Checked Then MsgBox "Please Click on any block near the empty cell to shuffle the two"
    If mnuManualEntry.Checked Then MsgBox "Please type your start state with unique number between 1 to 9 in each block " & vbCrLf & _
    " and '_' for empty cell"
    bClose = True
    frmEightPuzzle.Show
End Sub

Private Sub mnuAbout_Click()
    frmAbout.Show
End Sub

Private Sub mnuAStar_Click()
    HelpType = 2
    frmHelpView.Show
End Sub

Private Sub mnuAStarAlgorithm_Click()
    frmAStarTree.Show
End Sub

Private Sub mnuAutomaticShuffling_Click()
    With mnuAutomaticShuffling
        .Checked = True
        If .Checked Then
            mnuManualEntry.Checked = False
            mnuManualShuffle.Checked = False
            SetType = 0
        End If
    End With
End Sub

Private Sub mnuClose_Click()
    Unload Me
End Sub

Private Sub mnuManualEntry_Click()
    With mnuManualEntry
        .Checked = True
        If .Checked Then
            mnuAutomaticShuffling.Checked = False
            mnuManualShuffle.Checked = False
            SetType = 2
        End If
    End With
End Sub

Private Sub mnuManualShuffle_Click()
    With mnuManualShuffle
        .Checked = True
        If .Checked Then
            mnuAutomaticShuffling.Checked = False
            mnuManualEntry.Checked = False
            SetType = 1
        End If
    End With
End Sub

