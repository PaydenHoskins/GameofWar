'Payden Hoskins
'RCET 3371
'10/30/25
'GameOfWar
'https://github.com/PaydenHoskins/GameofWar.git


Public Class GameForm
    Private _cards As New Stack(Of CardClass)
    Dim theDeck As New DeckClass()
    Private count As Integer
    Private cardCompare(1) As String
    Public player1 As Integer
    Public player2 As Integer
    Public _player1%
    Public _player2%

    Private Sub GameForm_Click(sender As Object, e As EventArgs) Handles Me.Click

        Dim add As Integer = 0
        DisplayCards(cardCompare(0))
        DisplayCards(cardCompare(1))
        If cardCompare(0) = cardCompare(1) Then
            For i = 0 To 3
                DisplayCards(cardCompare(0))
                DisplayCards(cardCompare(1))
            Next

            weight1()
            weight2()

            add += 8
            If cardCompare(0) = cardCompare(1) Then
                For i = 0 To 3
                    DisplayCards(cardCompare(0))
                    DisplayCards(cardCompare(1))

                Next

                weight1()
                weight2()

                add += 8
                If cardCompare(0) = cardCompare(1) Then
                    Me.Close()
                ElseIf cardCompare(0) <> cardCompare(1) Then
                    If CInt(_player1) > CInt(_player2) Then
                        Me.player1 += add
                    ElseIf CInt(_player1) < CInt(_player2) Then
                        Me.player2 += add
                    End If
                End If
            ElseIf cardCompare(0) <> cardCompare(1) Then
                If CInt(_player1) > CInt(_player2) Then
                    Me.player1 += add
                ElseIf CInt(_player1) < CInt(_player2) Then
                    Me.player2 += add
                End If
            End If
        ElseIf cardCompare(0) <> cardCompare(1) Then
        End If
        If Me.theDeck.CardsRemaining = 0 Then
            If MsgBox($"Player1 wins. Game over! Would you like to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.theDeck.tracker.Clear()
                Me.theDeck._deck.Clear()
                Do Until theDeck.CardsRemaining >= 52
                    theDeck.Shuffle()
                Loop
                player1 = 0
                player2 = 0
                _player1 = 0
                _player2 = 0
                DisplayCards(cardCompare(0))
                DisplayCards(cardCompare(1))
            Else
                Me.theDeck.tracker.Clear()
                Me.theDeck._deck.Clear()
                Do Until theDeck.CardsRemaining >= 52
                    theDeck.Shuffle()
                Loop
                player1 = 0
                player2 = 0
                _player1 = 0
                _player2 = 0
            End If
        End If
    End Sub

    Private Sub RestartButton_Click(sender As Object, e As EventArgs) Handles RestartButton.Click
        Me.theDeck.tracker.Clear()
        Me.theDeck._deck.Clear()
        Do Until theDeck.CardsRemaining >= 52
            theDeck.Shuffle()
        Loop
        player1 = 0
        player2 = 0
        _player1 = 0
        _player2 = 0
    End Sub
    Sub DisplayCards(ByRef _drewCard As String)
        Dim g As Graphics = Me.CreateGraphics
        Dim I As Graphics = Me.CreateGraphics
        Dim rectangle As New Rectangle(0, 0, 150, 250)
        Dim dealtCard As CardClass = theDeck.DealCard()
        _drewCard = $"{dealtCard.rank}"
        Dim offset% = 525
        Dim offset2% = 600
        count += 1
        Try
            Select Case count
                Case 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39, 41, 43, 45, 47, 49, 51
                    g.Transform = New Drawing2D.Matrix()
                    g.TranslateTransform(offset - 50, 0)
                    g.DrawImage(dealtCard.backImage, rectangle)
                    g.Dispose()
                    I.TranslateTransform(offset, 50)
                    I.DrawImage(dealtCard.frontImage, rectangle)
                Case 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52
                    g.Transform = New Drawing2D.Matrix()
                    g.TranslateTransform(offset - 50, offset2 - 50)
                    g.DrawImage(dealtCard.backImage, rectangle)
                    g.Dispose()
                    I.TranslateTransform(offset, offset2)
                    I.DrawImage(dealtCard.frontImage, rectangle)
            End Select
            I.Dispose()
            If count >= 52 Then
                count = 0
            End If
        Catch ex As Exception

        End Try

        Me.Text = theDeck.CardsRemaining

    End Sub

    Sub weight1()
        Select Case cardCompare(0)
            Case "2"
                _player1 = 2
            Case "3"
                _player1 = 3
            Case "4"
                _player1 = 4
            Case "5"
                _player1 = 5
            Case "6"
                _player1 = 6
            Case "7"
                _player1 = 7
            Case "8"
                _player1 = 8
            Case "9"
                _player1 = 9
            Case "10"
                _player1 = 10
            Case "j"
                _player1 = 11
            Case "k"
                _player1 = 13
            Case "q"
                _player1 = 12
            Case "a"
                _player1 = 14
        End Select
    End Sub

    Sub weight2()
        Select Case cardCompare(0)
            Case "2"
                _player2 = 2
            Case "3"
                _player2 = 3
            Case "4"
                _player2 = 4
            Case "5"
                _player2 = 5
            Case "6"
                _player2 = 6
            Case "7"
                _player2 = 7
            Case "8"
                _player2 = 8
            Case "9"
                _player2 = 9
            Case "10"
                _player2 = 10
            Case "j"
                _player2 = 11
            Case "k"
                _player2 = 13
            Case "q"
                _player2 = 12
            Case "a"
                _player2 = 14
        End Select
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
End Class
