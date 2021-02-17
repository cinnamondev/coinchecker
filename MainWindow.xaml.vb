Class MainWindow
    Private Sub App_Startup()
        Debug.Write("a")
    End Sub

    Private Async Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim btc As New coinchecker.btc
        coinprice.Text = Await btc.price
    End Sub
End Class
