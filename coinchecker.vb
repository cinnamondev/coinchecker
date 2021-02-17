Imports System.Net.Http
Imports System.Text.Json
Public Class coinchecker
    Private Async Function FetchJSON(url As String) As Task(Of String) ' fetch us json content from coinbase. we make this private so we cant accidentally call something bad
        Using client As HttpClient = New HttpClient() ' using will help us avoid la garbage . we are making a new temp httpclient for this instance
            Using response As HttpResponseMessage = Await client.GetAsync(url) ' we will send a GET request asynchronously to the API asynchronously
                Using content As HttpContent = response.Content ' http response 

                    Return Await content.ReadAsStringAsync() ' read the content from the http response and return it (end)
                End Using
            End Using
        End Using
    End Function
<<<<<<< HEAD


    Public Async Function buyPrice(base As String, Optional resultCurrency As String = "USD") As Task(Of String) ' sanitized fetchJSON, still private but will construct uri
        ' having resultCurrency be optional allows us to use this function for all supported 
        Dim uri = New Uri($"https://api.coinbase.com/v2/prices/{base}-{resultCurrency}/buy") ' make a new relative uri, pretty sure dont actually need this but wheres the harm
        Dim json As String = Await FetchJSON(uri.AbsoluteUri) ' pull our json response
#If DEBUG Then
        Debug.Write(json) 'if we are in debug mode i wanna see what this has to say!
#End If

=======
    Public Async Function buyPrice(base As String, Optional resultCurrency As String = config.EndCurrency) As Task(Of String) ' sanitized fetchJSON, still private but will construct uri
        ' having resultCurrency be optional allows us to use this function for all supported 
        Dim uri = New Uri($"https://api.coinbase.com/v2/prices/{base}-{config.EndCurrency}/buy") ' build our url based on thing

        Dim json As String = Await FetchJSON(uri.AbsoluteUri) ' pull our json response
>>>>>>> master
        Dim jsobj As JsonElement = (JsonSerializer.Deserialize(Of Object)(json)).GetProperty("data") ' do the funky System.Text.Json
        Dim amount = jsobj.GetProperty("amount").ToString

        Return amount

    End Function
<<<<<<< HEAD





=======
    Public Class btc
        Private cc As New coinchecker

        Public price = cc.buyPrice("BTC")
    End Class
    Public Class eth
        Public cc As New coinchecker
        Public price = cc.buyPrice("ETH")
    End Class
>>>>>>> master

End Class
