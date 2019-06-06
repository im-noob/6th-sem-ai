VERSION 5.00
Begin VB.Form frmTTTWelcome 
   BackColor       =   &H0000FFFF&
   BorderStyle     =   0  'None
   Caption         =   "Form2"
   ClientHeight    =   3690
   ClientLeft      =   2610
   ClientTop       =   2190
   ClientWidth     =   5100
   LinkTopic       =   "Form2"
   ScaleHeight     =   3690
   ScaleWidth      =   5100
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame1 
      BackColor       =   &H0000FFFF&
      Caption         =   "Select 'X' or 'O' and click OK"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FF0000&
      Height          =   1095
      Left            =   480
      TabIndex        =   2
      Top             =   960
      Width           =   4095
      Begin VB.OptionButton optXorO 
         BackColor       =   &H0000FFFF&
         Caption         =   "X"
         BeginProperty Font 
            Name            =   "Comic Sans MS"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   495
         Index           =   0
         Left            =   960
         TabIndex        =   4
         Top             =   360
         Value           =   -1  'True
         Width           =   1215
      End
      Begin VB.OptionButton optXorO 
         BackColor       =   &H0000FFFF&
         Caption         =   "O"
         BeginProperty Font 
            Name            =   "Comic Sans MS"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   495
         Index           =   1
         Left            =   2160
         TabIndex        =   3
         Top             =   360
         Width           =   1215
      End
   End
   Begin VB.CommandButton cmdOK 
      BackColor       =   &H0000FF00&
      Caption         =   "OK"
      Default         =   -1  'True
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   14.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   1440
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   2520
      Width           =   2055
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "Welcome to Tic-Tac-Toe!"
      BeginProperty Font 
         Name            =   "Comic Sans MS"
         Size            =   14.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FF0000&
      Height          =   555
      Left            =   120
      TabIndex        =   0
      Top             =   180
      Width           =   4815
   End
End
Attribute VB_Name = "frmTTTWelcome"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

' Start-up form for Tic-Tac-Toe game. The user chooses whether he or she
' wants to be "X" or "O" (by selecting the appropriate option button)
' and then clicks OK.

Private Sub Form_Load()
    CenterForm Me
End Sub


Private Sub cmdOK_Click()

    ' Set the global variables for the player's letter and the
    ' computer's letter, show the main form, and unload this one.
    
    gstrPlayerLetter = IIf(optXorO(0).Value, "X", "O")
    gstrComputerLetter = IIf(gstrPlayerLetter = "X", "O", "X")
    frmTicTacToe.Show
    Unload Me

End Sub
