VERSION 5.00
Begin VB.Form frmTicTacToe 
   BackColor       =   &H00C00000&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Tic Tac Toe"
   ClientHeight    =   6495
   ClientLeft      =   1620
   ClientTop       =   1440
   ClientWidth     =   8250
   Icon            =   "frmTicTacToe.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6495
   ScaleWidth      =   8250
   Begin VB.CommandButton cmdQuit 
      BackColor       =   &H0000FFFF&
      Caption         =   "&Quit"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   555
      Left            =   5940
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   5640
      Width           =   1755
   End
   Begin VB.CommandButton cmdPlayAgain 
      BackColor       =   &H0000FFFF&
      Caption         =   "&Play Again"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   555
      Left            =   4080
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   5640
      Width           =   1755
   End
   Begin VB.Timer tmrFlash 
      Enabled         =   0   'False
      Interval        =   500
      Left            =   5760
      Top             =   240
   End
   Begin VB.Label lblGamesTied 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      ForeColor       =   &H0000FFFF&
      Height          =   255
      Left            =   3420
      TabIndex        =   20
      Top             =   5940
      Width           =   555
   End
   Begin VB.Label lblGamesLost 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      ForeColor       =   &H0000FFFF&
      Height          =   255
      Left            =   3420
      TabIndex        =   19
      Top             =   5640
      Width           =   555
   End
   Begin VB.Label lblGamesWon 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      ForeColor       =   &H0000FFFF&
      Height          =   255
      Left            =   1800
      TabIndex        =   18
      Top             =   5940
      Width           =   555
   End
   Begin VB.Label lblGamesPlayed 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      ForeColor       =   &H0000FFFF&
      Height          =   255
      Left            =   1800
      TabIndex        =   17
      Top             =   5640
      Width           =   555
   End
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "Games Tied:"
      ForeColor       =   &H0000FFFF&
      Height          =   255
      Left            =   2400
      TabIndex        =   16
      Top             =   5940
      Width           =   975
   End
   Begin VB.Label Label4 
      BackStyle       =   0  'Transparent
      Caption         =   "Games Lost:"
      ForeColor       =   &H0000FFFF&
      Height          =   255
      Left            =   2400
      TabIndex        =   15
      Top             =   5640
      Width           =   975
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "Games Won:"
      ForeColor       =   &H0000FFFF&
      Height          =   255
      Left            =   600
      TabIndex        =   14
      Top             =   5940
      Width           =   1155
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   "Games Played:"
      ForeColor       =   &H0000FFFF&
      Height          =   255
      Left            =   600
      TabIndex        =   13
      Top             =   5640
      Width           =   1155
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "Tic Tac Toe"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   18
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   495
      Left            =   60
      TabIndex        =   12
      Top             =   180
      Width           =   8175
   End
   Begin VB.Label lblWins 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "YOU WIN!!!"
      BeginProperty Font 
         Name            =   "Arial Black"
         Size            =   27.75
         Charset         =   0
         Weight          =   900
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   855
      Left            =   60
      TabIndex        =   0
      Top             =   2700
      Visible         =   0   'False
      Width           =   8055
   End
   Begin VB.Line linWin 
      BorderColor     =   &H0000FFFF&
      BorderWidth     =   2
      Index           =   7
      Visible         =   0   'False
      X1              =   7860
      X2              =   420
      Y1              =   4620
      Y2              =   4620
   End
   Begin VB.Line linWin 
      BorderColor     =   &H0000FFFF&
      BorderWidth     =   2
      Index           =   6
      Visible         =   0   'False
      X1              =   7800
      X2              =   360
      Y1              =   3120
      Y2              =   3120
   End
   Begin VB.Line linWin 
      BorderColor     =   &H0000FFFF&
      BorderWidth     =   2
      Index           =   5
      Visible         =   0   'False
      X1              =   7860
      X2              =   420
      Y1              =   840
      Y2              =   5400
   End
   Begin VB.Line linWin 
      BorderColor     =   &H0000FFFF&
      BorderWidth     =   2
      Index           =   4
      Visible         =   0   'False
      X1              =   6540
      X2              =   6540
      Y1              =   720
      Y2              =   5520
   End
   Begin VB.Line linWin 
      BorderColor     =   &H0000FFFF&
      BorderWidth     =   2
      Index           =   3
      Visible         =   0   'False
      X1              =   4140
      X2              =   4140
      Y1              =   5520
      Y2              =   780
   End
   Begin VB.Line linWin 
      BorderColor     =   &H0000FFFF&
      BorderWidth     =   2
      Index           =   2
      Visible         =   0   'False
      X1              =   1680
      X2              =   1680
      Y1              =   780
      Y2              =   5520
   End
   Begin VB.Line linWin 
      BorderColor     =   &H0000FFFF&
      BorderWidth     =   2
      Index           =   1
      Visible         =   0   'False
      X1              =   7740
      X2              =   480
      Y1              =   5400
      Y2              =   840
   End
   Begin VB.Line linWin 
      BorderColor     =   &H0000FFFF&
      BorderWidth     =   2
      Index           =   0
      Visible         =   0   'False
      X1              =   7800
      X2              =   420
      Y1              =   1680
      Y2              =   1680
   End
   Begin VB.Label lblBox 
      Alignment       =   2  'Center
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "X"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   48
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   1455
      Index           =   0
      Left            =   540
      TabIndex        =   11
      Top             =   900
      Width           =   2355
   End
   Begin VB.Label lblBox 
      Alignment       =   2  'Center
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "X"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   48
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   1455
      Index           =   1
      Left            =   2940
      TabIndex        =   10
      Top             =   900
      Width           =   2355
   End
   Begin VB.Label lblBox 
      Alignment       =   2  'Center
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "X"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   48
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   1455
      Index           =   2
      Left            =   5340
      TabIndex        =   9
      Top             =   900
      Width           =   2355
   End
   Begin VB.Label lblBox 
      Alignment       =   2  'Center
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "X"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   48
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   1455
      Index           =   3
      Left            =   540
      TabIndex        =   8
      Top             =   2400
      Width           =   2355
   End
   Begin VB.Label lblBox 
      Alignment       =   2  'Center
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "X"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   48
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   1455
      Index           =   4
      Left            =   2940
      TabIndex        =   7
      Top             =   2400
      Width           =   2355
   End
   Begin VB.Label lblBox 
      Alignment       =   2  'Center
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "X"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   48
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   1455
      Index           =   5
      Left            =   5340
      TabIndex        =   6
      Top             =   2400
      Width           =   2355
   End
   Begin VB.Label lblBox 
      Alignment       =   2  'Center
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "X"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   48
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   1455
      Index           =   6
      Left            =   540
      TabIndex        =   5
      Top             =   3900
      Width           =   2355
   End
   Begin VB.Label lblBox 
      Alignment       =   2  'Center
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "X"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   48
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   1455
      Index           =   7
      Left            =   2940
      TabIndex        =   4
      Top             =   3900
      Width           =   2355
   End
   Begin VB.Label lblBox 
      Alignment       =   2  'Center
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "X"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   48
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   1455
      Index           =   8
      Left            =   5340
      TabIndex        =   3
      Top             =   3900
      Width           =   2355
   End
End
Attribute VB_Name = "frmTicTacToe"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

'************************************************************************************
'*                   Module-Level Variable Declarations                             *
'************************************************************************************

Private mintGamesPlayed         As Integer
Private mintGamesWon            As Integer
Private mintGamesLost           As Integer
Private mintGamesTied           As Integer
Private mblnGameOver            As Boolean

Private mintGameOutcome         As Integer
Private Const mintTIE_GAME      As Integer = 0
Private Const mintCOMPUTER_WINS As Integer = 1
Private Const mintPLAYER_WINS   As Integer = 2


'************************************************************************************
'*                                    Form Events                                   *
'************************************************************************************

Private Sub Form_Load()

    CenterForm Me
    
    StartNewGame
    
End Sub


Private Sub Form_Unload(Cancel As Integer)

    If MsgBox("Are you sure you want to quit?", _
              vbYesNo + vbQuestion, _
              "Quit Tic Tac Toe") = vbNo Then
        Cancel = 1
    End If
    
End Sub


'************************************************************************************
'*                                    Label Events                                  *
'************************************************************************************

Private Sub lblBox_Click(Index As Integer)

    ' In this event, evaluate which square of the gameboard the user clicked on,
    ' and act accordingly. (A "square" in this case is one of the 9 labels in the
    ' lblBox control array, indexed 0 to 8.)

    ' If the user tries to click on a square after the game is over,
    ' ignore the click ...
    If mblnGameOver Then Exit Sub
    
    ' If the user tries to click on a square that is already populated with an "X"
    ' or "O", ignore the click ...
    If lblBox(Index).Caption <> "" Then Exit Sub
    
    ' The player clicked on an empty square, so populate it with the player's letter
    ' ("X" or "O" depending on what they chose when the app started) ...
    lblBox(Index).Caption = gstrPlayerLetter
    
    ' Check to see if the player won with this move by testing the 8 possible ways to win.
    ' If the player won, call the GameOver routine; otherwise, check to see if this move
    ' caused the game to end in a tie, and if not, have the computer take its turn ...
    Select Case True
        Case PlayerWins(0, 1, 2):   GameOver mintPLAYER_WINS, 0
        Case PlayerWins(0, 4, 8):   GameOver mintPLAYER_WINS, 1
        Case PlayerWins(0, 3, 6):   GameOver mintPLAYER_WINS, 2
        Case PlayerWins(1, 4, 7):   GameOver mintPLAYER_WINS, 3
        Case PlayerWins(2, 5, 8):   GameOver mintPLAYER_WINS, 4
        Case PlayerWins(2, 4, 6):   GameOver mintPLAYER_WINS, 5
        Case PlayerWins(3, 4, 5):   GameOver mintPLAYER_WINS, 6
        Case PlayerWins(6, 7, 8):   GameOver mintPLAYER_WINS, 7
        Case Else:                  If Not TieGame Then TakeComputerTurn
    End Select
    
End Sub


'************************************************************************************
'*                             Command Button Events                                *
'************************************************************************************

Private Sub cmdPlayAgain_Click()
    
    StartNewGame

End Sub


Private Sub cmdQuit_Click()
    
    Unload Me

End Sub


Private Sub lblWins_Click()

End Sub

'************************************************************************************
'*                                  Timer Event                                     *
'************************************************************************************

Private Sub tmrFlash_Timer()

    ' The timer is enabled when the game ends. On every timer interval, toggle the
    ' Visible property of the lblWins label, which reports the outcome of the
    ' game ("YOU WIN", "YOU LOSE", "IT'S A TIE"). Toggling the Visible property
    ' causes the blinking effect ...

    lblWins.Visible = Not lblWins.Visible

End Sub


'************************************************************************************
'*                                  Programmer-Defined                              *
'*                                   Subs & Functions                               *
'************************************************************************************

'------------------------------------------------------------------------------------
Private Sub StartNewGame()
'
'    This routine performs all the initialization tasks necessary for a new game...
'
'------------------------------------------------------------------------------------

    Dim intX            As Integer
    Dim intGoesFirst    As Integer
    
    ' Reset "game over" flag ...
    mblnGameOver = False
    
    ' Clear the 9 squares of the gameboard ...
    For intX = 0 To 8
        lblBox(intX).Caption = ""
    Next
    
    ' Make sure none of the 8 lines (one for each way to win) is visible ...
    For intX = 0 To 7
        linWin(intX).Visible = False
    Next
    
    ' Disable the timer and hide the flashing message; disable the "Play Again"
    ' button ...
    tmrFlash.Enabled = False
    lblWins.Visible = False
    cmdPlayAgain.Enabled = False
    
    ' Generate a random number (1 or 2) to see who goes first (1 = computer,
    ' 2 = player) ...
    Randomize
    intGoesFirst = Int(2 * Rnd + 1)

    ' Inform the user who is going first. If it's the computer, take the computer's
    ' turn ...
    If intGoesFirst = 1 Then
        MsgBox "I will go first this time.", , "New Game"
        TakeComputerTurn
    Else
        MsgBox "You go first this time.", , "New Game"
    End If

    
End Sub


'------------------------------------------------------------------------------------
Private Sub TakeComputerTurn()
'
'    This routine implements the computer's strategy to make a move ...
'
'------------------------------------------------------------------------------------

    Dim intX        As Integer
    Dim blnMoveMade As Boolean
    
    ' First, see if the computer can win with this move by placing its "X"
    ' or "O" within any of the 8 possible winning sequences. If so,
    ' announce it, and get out.
    If ComputerWins(0, 1, 2) Then GameOver mintCOMPUTER_WINS, 0: Exit Sub
    If ComputerWins(0, 4, 8) Then GameOver mintCOMPUTER_WINS, 1: Exit Sub
    If ComputerWins(0, 3, 6) Then GameOver mintCOMPUTER_WINS, 2: Exit Sub
    If ComputerWins(1, 4, 7) Then GameOver mintCOMPUTER_WINS, 3: Exit Sub
    If ComputerWins(2, 5, 8) Then GameOver mintCOMPUTER_WINS, 4: Exit Sub
    If ComputerWins(2, 4, 6) Then GameOver mintCOMPUTER_WINS, 5: Exit Sub
    If ComputerWins(3, 4, 5) Then GameOver mintCOMPUTER_WINS, 6: Exit Sub
    If ComputerWins(6, 7, 8) Then GameOver mintCOMPUTER_WINS, 7: Exit Sub
    
    ' If we couldn't win with this move, see if the player can win on his or
    ' her next move, and if so, block it, check to see if we have a tie, and
    ' get out ...
    If ComputerBlocks(0, 1, 2) Then TieGame: Exit Sub
    If ComputerBlocks(0, 4, 8) Then TieGame: Exit Sub
    If ComputerBlocks(0, 3, 6) Then TieGame: Exit Sub
    If ComputerBlocks(1, 4, 7) Then TieGame: Exit Sub
    If ComputerBlocks(2, 5, 8) Then TieGame: Exit Sub
    If ComputerBlocks(2, 4, 6) Then TieGame: Exit Sub
    If ComputerBlocks(3, 4, 5) Then TieGame: Exit Sub
    If ComputerBlocks(6, 7, 8) Then TieGame: Exit Sub

    ' If we get here, the computer could not win with this move and it is not
    ' necessary block. Therefore, choose a strategic location to place the
    ' computer's letter ...

    blnMoveMade = True
    
        ' First go for the middle square ...
    If lblBox(4).Caption = "" Then
        lblBox(4).Caption = gstrComputerLetter
        ' otherwise try the upper left-hand corner ...
    ElseIf lblBox(0).Caption = "" Then
        lblBox(0).Caption = gstrComputerLetter
        ' otherwise try the upper right-hand corner ...
    ElseIf lblBox(2).Caption = "" Then
        lblBox(2).Caption = gstrComputerLetter
        ' otherwise try the lower left-hand corner ...
    ElseIf lblBox(6).Caption = "" Then
        lblBox(6).Caption = gstrComputerLetter
        ' otherwise try the lower right-hand corner ...
    ElseIf lblBox(8).Caption = "" Then
        lblBox(8).Caption = gstrComputerLetter
        ' otherwise, if the computer's letter is occupying the middle
        ' square, go for the middle-left or middle-right square ...
    ElseIf lblBox(4).Caption = gstrComputerLetter Then
        If lblBox(3).Caption = "" Then
            lblBox(3).Caption = gstrComputerLetter
        ElseIf lblBox(5).Caption = "" Then
            lblBox(5).Caption = gstrComputerLetter
        Else
            blnMoveMade = False
        End If
    Else
        blnMoveMade = False
    End If
    
    ' If we could not make any of the moves above, simply use the next available
    ' square ...
    If Not blnMoveMade Then
        For intX = 0 To 8
            If lblBox(intX).Caption = "" Then
                lblBox(intX).Caption = gstrComputerLetter
                Exit For
            End If
        Next
    End If
    
    ' Check to see if the move that the computer just made caused the game
    ' to end with a tie ...
    TieGame
    
    
End Sub


'------------------------------------------------------------------------------------
Private Function PlayerWins(pintPos1 As Integer, _
                            pintPos2 As Integer, _
                            pintPos3 As Integer) _
As Boolean
'
'    This routine determines whether or not the player has just won by testing one
'    of the possible 8 ways to win ...
'
'------------------------------------------------------------------------------------

    ' If any square in the configuration being tested is blank, the player
    ' did not yet win ...
    If lblBox(pintPos1).Caption = "" _
    Or lblBox(pintPos2).Caption = "" _
    Or lblBox(pintPos3).Caption = "" Then
        PlayerWins = False
    Else
        ' If all three squares in the configuration being tested have the
        ' same value, then the player has won, otherwise game is still in
        ' progress ...
        If lblBox(pintPos1).Caption = lblBox(pintPos2).Caption _
        And lblBox(pintPos1).Caption = lblBox(pintPos3).Caption Then
            PlayerWins = True
        Else
            PlayerWins = False
        End If
    End If
    
End Function


'------------------------------------------------------------------------------------
Private Function ComputerWins(pintPos1 As Integer, _
                              pintPos2 As Integer, _
                              pintPos3 As Integer) _
As Boolean
'
'    This routine determines whether or not the computer can win on this move
'    by testing for an open spot within a sequence of one of the 8 possible
'    ways to win ...
'
'------------------------------------------------------------------------------------
    
    If lblBox(pintPos1).Caption = "" _
    And lblBox(pintPos2).Caption = gstrComputerLetter _
    And lblBox(pintPos3).Caption = gstrComputerLetter Then
    
        lblBox(pintPos1).Caption = gstrComputerLetter
        ComputerWins = True
        Exit Function
        
    End If
    
    
    If lblBox(pintPos1).Caption = gstrComputerLetter _
    And lblBox(pintPos2).Caption = "" _
    And lblBox(pintPos3).Caption = gstrComputerLetter Then
    
        lblBox(pintPos2).Caption = gstrComputerLetter
        ComputerWins = True
        Exit Function
        
    End If
    
    
    If lblBox(pintPos1).Caption = gstrComputerLetter _
    And lblBox(pintPos2).Caption = gstrComputerLetter _
    And lblBox(pintPos3).Caption = "" Then
    
        lblBox(pintPos3).Caption = gstrComputerLetter
        ComputerWins = True
        Exit Function
    
    End If
    
    
    ComputerWins = False
    
End Function


'------------------------------------------------------------------------------------
Private Function ComputerBlocks(pintPos1 As Integer, _
                                pintPos2 As Integer, _
                                pintPos3 As Integer) _
As Boolean
'
'    This routine determines whether or not the computer must block the player
'    to prevent the player from winning on his or her next move ...
'
'------------------------------------------------------------------------------------

    If lblBox(pintPos1).Caption = "" _
    And lblBox(pintPos2).Caption = gstrPlayerLetter _
    And lblBox(pintPos3).Caption = gstrPlayerLetter Then
    
        lblBox(pintPos1).Caption = gstrComputerLetter
        ComputerBlocks = True
        Exit Function
    
    End If
    
    
    If lblBox(pintPos1).Caption = gstrPlayerLetter _
    And lblBox(pintPos2).Caption = "" _
    And lblBox(pintPos3).Caption = gstrPlayerLetter Then
        
        lblBox(pintPos2).Caption = gstrComputerLetter
        ComputerBlocks = True
        Exit Function
    
    End If
    
    
    If lblBox(pintPos1).Caption = gstrPlayerLetter _
    And lblBox(pintPos2).Caption = gstrPlayerLetter _
    And lblBox(pintPos3).Caption = "" Then
        
        lblBox(pintPos3).Caption = gstrComputerLetter
        ComputerBlocks = True
        Exit Function
    
    End If
    
    ComputerBlocks = False
    
End Function


'------------------------------------------------------------------------------------
Private Function TieGame() As Boolean
'
'    This routine determines whether or not we have a tie game, by seeing whether
'    or not all the squares are populated. If they are, then it's a tie game,
'    because we would have determined that either the computer or the player
'    had won before getting here.
'
'------------------------------------------------------------------------------------

    Dim intX    As Integer
    
    For intX = 0 To 8
        If lblBox(intX).Caption = "" Then
            TieGame = False
            Exit Function
        End If
    Next
    
    TieGame = True
    
    GameOver mintTIE_GAME
    
End Function


'------------------------------------------------------------------------------------
Private Sub GameOver(pintGameOutcome As Integer, _
                     Optional pintLineIndex As Integer)
'
'    This routine displays a blinking message indicating which of the three ways the
'    game ended (the player either won, lost, or it was a tie). It also draws a line
'    through the winning combination, and updates the game stats.
'
'------------------------------------------------------------------------------------

    Dim strOutcomeMsg   As String
    
    If pintGameOutcome = mintTIE_GAME Then
        strOutcomeMsg = "IT'S A TIE !!!"
        mintGamesTied = mintGamesTied + 1
    Else
        linWin(pintLineIndex).Visible = True
        If pintGameOutcome = mintCOMPUTER_WINS Then
            strOutcomeMsg = "YOU LOSE !!!"
            mintGamesLost = mintGamesLost + 1
        Else
            strOutcomeMsg = "YOU WIN !!!"
            mintGamesWon = mintGamesWon + 1
        End If
    End If

    lblWins.Caption = strOutcomeMsg
    lblWins.Visible = True
    tmrFlash.Enabled = True

    cmdPlayAgain.Enabled = True

    ' Update the Stats ...
    mintGamesPlayed = mintGamesPlayed + 1
    lblGamesPlayed.Caption = CStr(mintGamesPlayed)
    lblGamesWon.Caption = CStr(mintGamesWon)
    lblGamesLost.Caption = CStr(mintGamesLost)
    lblGamesTied.Caption = CStr(mintGamesTied)

    mblnGameOver = True

End Sub
