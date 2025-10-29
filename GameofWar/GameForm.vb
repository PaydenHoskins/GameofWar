Public Class GameForm
    Private _cards As New Stack(Of CardClass)
    Dim theDeck As New DeckClass()
    Private count As Integer
    Private Sub GameForm_Click(sender As Object, e As EventArgs) Handles Me.Click
        DisplayCards()
        DisplayCards()
        If Me.theDeck.CardsRemaining = 0 Then
            If MsgBox("Game over! Would you like to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.theDeck.tracker.Clear()
                Me.theDeck._deck.Clear()
                Do Until theDeck.CardsRemaining >= 52
                    theDeck.Shuffle()
                Loop
                DisplayCards()
                DisplayCards()
            ElseIf MsgBox("Game over! Would you like to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Me.Close()
            End If

        End If
    End Sub

    Private Sub RestartButton_Click(sender As Object, e As EventArgs) Handles RestartButton.Click

    End Sub
    Sub DisplayCards()

        Dim g As Graphics = Me.CreateGraphics
        Dim I As Graphics = Me.CreateGraphics
        Dim rectangle As New Rectangle(0, 0, 150, 250)
        Dim dealtCard As CardClass = theDeck.DealCard()
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
End Class
