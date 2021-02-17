Class MainWindow
    Private Sub App_Startup()
        Debug.Write("a")
    End Sub

    Private Async Sub Window_Loaded(sender As Object, e As RoutedEventArgs) ' On window load we need to set the pricing.
        Dim config As New config
        Dim cc As New coinchecker


        coinprice.Text = $"{config.inCoin.symbol}1 = {config.outCoin.symbol}{Await config.inCoin.price}"
    End Sub

    Private Sub ConfigButton_Click(sender As Object, e As RoutedEventArgs) ' open the config window to mess with config.vb!
        Dim configWindow As New configWindow

        configWindow.Show()
    End Sub
End Class
