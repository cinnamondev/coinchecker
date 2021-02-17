Class MainWindow
    Private Sub App_Startup()
        Debug.Write("a")
    End Sub

<<<<<<< HEAD
    Private Async Sub Window_Loaded(sender As Object, e As RoutedEventArgs) ' On window load we need to set the pricing.
        Dim config As New config
        Dim cc As New coinchecker


        coinprice.Text = $"{config.inCoin.symbol}1 = {config.outCoin.symbol}{Await config.inCoin.price}"
    End Sub

    Private Sub ConfigButton_Click(sender As Object, e As RoutedEventArgs)
        Dim configWindow As New configWindow

        configWindow.Show()
=======
    Private Async Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim btc As New coinchecker.btc
        coinprice.Text = "1BTC = $"
        coinprice.Text += Await btc.price
>>>>>>> master
    End Sub
End Class
