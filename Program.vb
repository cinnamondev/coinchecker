Imports System
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json.Linq
Imports System.Net


' BTC-CHECK: GET COINDESK API JSON OUTPUT AND DISPLAY IT PARSED VERY COOL WOW

' Powered by CoinDesk
Module Program

    Public Class btcLatestOut ' class for construct vb object thingymajig
        Public timeStamp As DateTime
        Public USD As Decimal
        Public GBP As Decimal
        Public EUR As Decimal
    End Class
    Public Class btcAvg
        Public curDate As DateTime
        Public costUSD As Decimal
    End Class


    Sub Main(args As String())
        Console.WriteLine("Hello World!")
        getAvg()

        getLatestBpis()
        Threading.Thread.Sleep(5000)
    End Sub

    Public Sub getLatestBpis() ' gets currentprice.json from coindesk api
        'Lets do a web request
        Dim request As HttpWebRequest 'do some vars
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader

        request = DirectCast(WebRequest.Create("https://api.coindesk.com/v1/bpi/currentprice.json"), HttpWebRequest) ' lets get that stuff

        response = DirectCast(request.GetResponse(), HttpWebResponse) ' get my stuff from them (json response) then (nxt line) read result of such
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String = reader.ReadToEnd() 'raw response (string)

        'Lets begin handling the output of coindesk api
        Dim jsonRes As JObject = JObject.Parse(rawresp) 'Make our thing into the JObject type (from newtonsoft) 
        Dim resultObj As New btcLatestOut

        resultObj.timeStamp = Convert.ToDateTime(jsonRes.SelectToken("time").SelectToken("updatedISO").ToString()) 'convert the string type to the datetime type
        resultObj.USD = jsonRes.SelectToken("bpi.USD.rate_float") ' these do the thing
        resultObj.GBP = jsonRes.SelectToken("bpi.GBP.rate_float")
        resultObj.EUR = jsonRes.SelectToken("bpi.EUR.rate_float")
        Console.WriteLine($"1BTC=" & vbCrLf & "   USD " & resultObj.USD & vbCrLf & "   GBP " & resultObj.GBP & vbCrLf & "   EUR " & resultObj.EUR)
    End Sub
    Public Sub getAvg() ' get 3 day average
        'Lets do a web request
        Dim request As HttpWebRequest 'do some vars
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader

        request = DirectCast(WebRequest.Create("https://api.coindesk.com/v1/bpi/historical/close.json"), HttpWebRequest) ' lets get that stuff

        response = DirectCast(request.GetResponse(), HttpWebResponse) ' get my stuff from them (json response) then (nxt line) read result of such
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String = reader.ReadToEnd() 'raw response (string)

        'Lets begin handling the output of coindesk api
        Dim jsonRes As JObject = JObject.Parse(rawresp) 'Make our thing into the JObject type (from newtonsoft) 
        Dim resultObj As New btcAvg
        'resultObj.curDate = Convert.ToDateTime(jsonRes.SelectToken("bpi").ToString())
        Dim bpiAvgList As New List(Of Decimal)()
        For Each item As JProperty In jsonRes.Item("bpi")
            Dim itemObjects As JToken = item.Value
            Console.WriteLine(Convert.ToString(item.Name) & " = " & Convert.ToString(item.Value))
            bpiAvgList.Add(item.Value)
        Next
        Dim avg As Decimal = (bpiAvgList(0) + bpiAvgList(1) + bpiAvgList(2) + bpiAvgList(3)) / 4
        Console.WriteLine("4 day avg = {0}", avg)
    End Sub
End Module
