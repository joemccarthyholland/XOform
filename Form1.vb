Public Class Form1
    Dim squares(3, 3) As Button
    Private Property CurrentPlayer As Player
    Dim p1 As Player
    Dim p2 As AIPlayer
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For x = 1 To 3
            For y = 1 To 3
                squares(x, y) = New Button
                With squares(x, y)
                    .Top = (100 + 100 * (x - 1))
                    .Left = (100 + 100 * (y - 1))
                    .Width = 100
                    .Height = 100
                    .Text = " "
                    .Name = "Sqr" & x & y

                    AddHandler squares(x, y).Click, AddressOf Square_click
                End With
                Me.Controls.Add(squares(x, y))
            Next
        Next
        p1 = New Player
        p2 = New AIPlayer
        CurrentPlayer = p1
    End Sub
    Sub Square_click(sender As Object, e As EventArgs)
        CurrentPlayer = p1
        sender.text = "X"
        If ThreeinaRow() Then
            MsgBox(CurrentPlayer.getname & " wins")
        End If
        CurrentPlayer = p2
        AImove()
        If ThreeinaRow() Then
            MsgBox(CurrentPlayer.getname & " wins")
        End If
    End Sub
    Sub AImove()
        Dim coOrd As New Random
        Dim x, y As Integer
        Do
            x = coOrd.Next(1, 4) ' you need to go 1 higher then the numbers :(
            y = coOrd.Next(1, 4)
        Loop Until squares(x, y).Text = " "
        squares(x, y).Text = "O"
    End Sub
    Function ThreeinaRow()
        For x = 1 To 3 'check vertical 
            If squares(x, 1).Text = squares(x, 2).Text And
               squares(x, 2).Text = squares(x, 3).Text And
               squares(x, 2).Text <> " " Then
                Return True
            End If
        Next
        For y = 1 To 3 'check Horizontal 
            If squares(1, y).Text = squares(2, y).Text And
               squares(2, y).Text = squares(3, y).Text And
               squares(2, y).Text <> " " Then
                Return True
            End If
        Next
        If squares(1, 1).Text = squares(2, 2).Text And ' diag1
           squares(2, 2).Text = squares(3, 3).Text And
           squares(2, 2).Text <> " " Then
            Return True
        End If
        If squares(1, 3).Text = squares(2, 2).Text And ' diag1
           squares(2, 2).Text = squares(3, 1).Text And
           squares(2, 2).Text <> " " Then
            Return True
        End If
        Return False
    End Function
End Class

Class Player
    Protected Property PlayerName As String
    Sub New()
        PlayerName = "player1"
    End Sub
    Function getname() As String
        Return PLayerName
    End Function
End Class
Class AIPlayer
    Inherits Player
    Sub New()
        MyBase.New()
        PlayerName = "player2"
    End Sub

End Class


