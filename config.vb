Public Class config
<<<<<<< HEAD
    Public inCoin As New eth
    Public outCoin As New usd

    Public Class usd
        Public Const symbol = "$"
        Public Const tSymbol = "USD"
    End Class
    Public Class btc
        Private cc As New coinchecker
        Public symbol = "BTC"
        Public tSymbol = "BTC"
        Public price = cc.buyPrice("BTC")

        'TBD:
        ' potential buy/sell teller and autobot?
    End Class
    Public Class eth ' default coin.
        Public cc As New coinchecker
        Public symbol = "Ξ"
        Public tSymbol = "ETH"
        Public price = cc.buyPrice("ETH")
    End Class
=======
    Public Const EndCurrency As String = "USD"
>>>>>>> master

End Class
