Attribute VB_Name = "PublicVariables"
'Game Settings
Public SetType As Integer
Public HelpType As Integer
Public NumberOfSteps As Integer
Public bClose As Boolean

'Tree Handling Variables
Public TreeRoot As EightPuzzleTree
Public strStart As String
Public SolutionMatrix(2, 2) As String
Public strGoal As String
Public GoalMatrix(2, 2) As String
Public PTree As EightPuzzleTree
Public UpLinks As Variant
Public DownLinks As Variant
Public LeftLinks As Variant
Public RightLinks As Variant

'LinkedList Handling Variables
Public OpenNode As LinkedList
Public CloseNode As LinkedList
Public PList As LinkedList

