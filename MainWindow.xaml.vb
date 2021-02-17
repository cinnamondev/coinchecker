Class MainWindow
    Private Sub App_Startup()
        Debug.Write("a")
    End Sub

    Private Async Sub Window_Loaded(sender As Object, e As RoutedEventArgs) ' On window load we need to set the pricing.
        Dim config As New config
        Dim cc As New coinchecker


        coinprice.Text = $"{config.inCoin.symbol}1 = {config.outCoin.symbol}{Await config.inCoin.price}"
    End Sub
End Class
