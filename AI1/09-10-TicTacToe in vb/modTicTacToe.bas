Attribute VB_Name = "modTicTacToe"
Option Explicit

Public gstrPlayerLetter      As String * 1
Public gstrComputerLetter    As String * 1

'------------------------------------------------------------------------
 Public Sub CenterForm(objForm As Form)
'------------------------------------------------------------------------

    With objForm
        .Top = (Screen.Height - .Height) / 2
        .Left = (Screen.Width - .Width) / 2
    End With

  End Sub


