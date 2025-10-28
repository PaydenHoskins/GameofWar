Public Class CardClass
    Private _suit As String
    Public Property suit() As String
        Get
            Return _suit
        End Get
        Set(ByVal value As String)
            _suit = value
        End Set
    End Property

    Private _rank As String
    Public Property rank() As String
        Get
            Return _rank
        End Get
        Set(ByVal value As String)
            _rank = value
        End Set
    End Property

    Private _frontImage As Image
    Public Property frontImage() As Image
        Get
            Return _frontImage
        End Get
        Set(ByVal value As Image)
            _frontImage = value
        End Set
    End Property

    Private _backImage As Image
    Public Property backImage() As Image
        Get
            Return _backImage
        End Get
        Set(ByVal value As Image)
            _backImage = value
        End Set
    End Property

    Sub New(rank As String, suit As String)

        Me.suit = suit.ToUpper
        Me.rank = rank.ToUpper
        Me.frontImage = My.Resources.ResourceManager.GetObject($"{Me.rank}{Me.suit}")
        If Me.frontImage Is Nothing Then
            Me.frontImage = My.Resources.ResourceManager.GetObject($"_{Me.rank}{Me.suit}")
        End If
        If Me.frontImage Is Nothing Then
            Me.frontImage = My.Resources.aces
        End If

        Me.backImage = My.Resources.CardBack

    End Sub
End Class
