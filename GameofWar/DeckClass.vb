Public Class DeckClass
    Public _deck As New Stack(Of CardClass)
    Public tracker As New List(Of String)
    Public _tracker(51) As String
    Private Function GetRandomInRange(max As Integer, Optional min As Integer = 1)
        Randomize()
        Return CInt(System.Math.Floor(Rnd() * max) + min)
    End Function

    Function DealCard() As CardClass
        Try
            Return _deck.Pop()
        Catch ex As Exception
            MsgBox("Out of cards!!")
            tracker.Clear()
            _deck.Clear()
            Do Until CardsRemaining() >= 52
                Shuffle()
            Loop
            Return _deck.Pop()
        End Try
    End Function

    Function CardsRemaining() As Integer
        Return _deck.Count
    End Function

    Sub Shuffle()
        Dim _suit$, _rank$
        Dim counter%

        _suit = GetSuit(GetRandomInRange(4))
        _rank = GetRank(GetRandomInRange(13))
        _rank = GetRank(GetRandomInRange(13))
        _suit = GetSuit(GetRandomInRange(4))

        If Not (tracker.Contains(_rank & _suit)) Then
            Dim newCard As New CardClass(_rank, _suit)
            Me._deck.Push(newCard)
            tracker.Add(_rank & _suit)
            _tracker(counter) = $"({_rank}, {_suit})"
            counter += 1
        End If

    End Sub
    Private Function GetSuit(suit As Integer) As String
        Dim _suit$
        Select Case suit
            Case 1
                _suit = "s"
            Case 2
                _suit = "h"
            Case 3
                _suit = "c"
            Case 4
                _suit = "d"
            Case Else
                _suit = "x"
        End Select
        Return _suit
    End Function

    Private Function GetRank(rank As Integer) As String
        Dim _rank$
        Select Case rank
            Case 1
                _rank = "a"
            Case 2 To 10
                _rank = rank.ToString
            Case 11
                _rank = "j"
            Case 12
                _rank = "q"
            Case 13
                _rank = "k"
        End Select

        Return _rank
    End Function

    Sub New()
        Do Until Me.CardsRemaining >= 52
            Shuffle()
        Loop
    End Sub
End Class
