VERSION 5.00
Begin VB.Form frmHelpView 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "How To ..."
   ClientHeight    =   6630
   ClientLeft      =   3120
   ClientTop       =   3060
   ClientWidth     =   10140
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   6630
   ScaleWidth      =   10140
   Begin VB.TextBox txtDisplay 
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   6375
      Left            =   120
      Locked          =   -1  'True
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   0
      Top             =   120
      Width           =   9855
   End
End
Attribute VB_Name = "frmHelpView"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Paint()
On Error GoTo ErrHandler
    Dim strHelpPath As String
    Dim strContent As String
    Dim strLine As String
    
    strHelpPath = App.Path
    strContent = ""
    
    If HelpType = 1 Then
        strHelpPath = strHelpPath & "\HowToPlay8Puzzle.txt"
    ElseIf HelpType = 2 Then
        strHelpPath = strHelpPath & "\HowToUseAStar.txt"
    Else
        MsgBox "Help Not Available"
        Unload frmHelpView
        Exit Sub
    End If
    
    Open strHelpPath For Input As #1
    While Not EOF(1)
        Line Input #1, strLine
        strContent = strContent & strLine & vbCrLf
    Wend
    txtDisplay.Text = strContent
    Close #1
    Exit Sub
ErrHandler:
    MsgBox "Help File " & strHelpPath & " not present. Hence Cannot display help.", vbCritical, App.Title
End Sub

