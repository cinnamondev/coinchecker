Imports System.Net.Http
Class MainWindow
    Const CBURI = "https://api.coindesk.com/v1/bpi/currentprice.json"
    Private Async Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim btc As New coinchecker.btc
        Dim content = Await btc.price
        Debug.Write(content)
    End Sub
End Class



