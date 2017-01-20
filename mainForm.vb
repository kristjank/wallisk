﻿Imports System.Net
Imports System.Text
Imports System.IO

Imports Newtonsoft.Json.Linq
Imports System.Security.Cryptography.X509Certificates
Imports System.Text.RegularExpressions
Imports Microsoft.Win32
Imports System.ComponentModel


Public Class Lisk
    Dim senderId As Object = Nothing
    'Dim val As Object
    Dim votepools As String
    Dim pubkeyx As String
    Dim seedx As String
    Dim seed2x As String



    Public Shared Function ValidateRemoteCertificate(ByVal sender As Object, ByVal certificate As X509Certificate, ByVal chain As X509Chain, ByVal sslPolicyErrors As Security.SslPolicyErrors) As Boolean
        Return True
    End Function


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        On Error Resume Next
        request = DirectCast(WebRequest.Create("http://liskworld.info:8000/api/loader/status/sync"), HttpWebRequest)

        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()
        MsgBox(rawresp)



        Dim jResults As Object = JObject.Parse(rawresp)
        TextBox1.Text = If(jResults("height") Is Nothing, "", jResults("height").ToString())
        TextBox2.Text = If(jResults("syncing") Is Nothing, "", jResults("syncing").ToString())

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        On Error Resume Next
        Label17.Text = "or if you prefer you can both vote for wallet manteniers"

        Label18.Text = "and STAKE your lisk voting too for some lisk pools"
        RadioButton1.PerformClick()
        Button5.Text = ""
        Label1.Text = ""
        Label4.Text = ""

        Dim dataDirectory As String = String.Format("{0}\Data\", Environment.CurrentDirectory)



        My.Computer.FileSystem.WriteAllBytes("Newtonsoft.Json.dll", My.Resources.Newtonsoft_Json, False)

        Dim pRegKey As RegistryKey = Registry.CurrentUser
        pRegKey = pRegKey.OpenSubKey("SOFTWARE\wallisk")
        senderId = pRegKey.GetValue("address")
        ' MsgBox(val)
        ' carica()
        BackgroundWorker10.RunWorkerAsync()
        BackgroundWorker1.RunWorkerAsync()
        BackgroundWorker2.RunWorkerAsync()
        BackgroundWorker3.RunWorkerAsync()
        BackgroundWorker4.RunWorkerAsync()
        BackgroundWorker5.RunWorkerAsync()
        BackgroundWorker6.RunWorkerAsync()
        BackgroundWorker7.RunWorkerAsync()
        BackgroundWorker8.RunWorkerAsync()
        BackgroundWorker9.RunWorkerAsync()




    End Sub

    Private Sub carica()
        Dim defaultResponse As String = String.Empty
        Dim title As String = String.Empty
        Dim request As HttpWebRequest

        Dim response As HttpWebResponse = Nothing

        Dim reader As StreamReader
        On Error Resume Next
        request = DirectCast(WebRequest.Create("https://login.lisk.io/api/accounts?address=" & senderId), HttpWebRequest)
        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()

        Dim jResults As Object = JObject.Parse(rawresp)
        Dim testo As String = If(jResults("account") Is Nothing, "", jResults("account").ToString())
        Dim jResults2 As Object = JObject.Parse(testo)
        Dim testo2 As String = If(jResults2("balance") Is Nothing, "", jResults2("balance").ToString())

        Dim testo4 As String
        testo4 = testo2 / 100000000
        Label1.Text = "Address " & senderId
        Label4.Text = testo4 & " LISK"

        Button5.Enabled = True
        Button5.Text = "update balance"
        Button4.Text = "change address"
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        'Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)


        If Not (BackgroundWorker1.IsBusy) Then
            BackgroundWorker1.RunWorkerAsync()
        End If


        Timer1.Start()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If Not (BackgroundWorker2.IsBusy) Then
            BackgroundWorker2.RunWorkerAsync()
        End If

        Timer2.Start()
    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick

        If Not (BackgroundWorker3.IsBusy) Then
            BackgroundWorker3.RunWorkerAsync()
        End If

        Timer3.Start()
    End Sub

    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        If Not (BackgroundWorker4.IsBusy) Then
            BackgroundWorker4.RunWorkerAsync()
        End If
        Timer4.Start()

    End Sub

    Private Sub Timer5_Tick(sender As System.Object, e As System.EventArgs) Handles Timer5.Tick
        If Not (BackgroundWorker5.IsBusy) Then
            BackgroundWorker5.RunWorkerAsync()
        End If
        Timer5.Start()

    End Sub

    Private Sub TextBox4_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TextBox5_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub



    Private Sub Label8_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Timer6_Tick(sender As System.Object, e As System.EventArgs) Handles Timer6.Tick
        If Not (BackgroundWorker6.IsBusy) Then
            BackgroundWorker6.RunWorkerAsync()
        End If
        Timer6.Start()

    End Sub

    Private Sub Timer7_Tick(sender As System.Object, e As System.EventArgs) Handles Timer7.Tick

        If Not (BackgroundWorker7.IsBusy) Then
            BackgroundWorker7.RunWorkerAsync()
        End If

        Timer7.Start()

    End Sub

    Private Sub Timer8_Tick(sender As System.Object, e As System.EventArgs) Handles Timer8.Tick
        If Not (BackgroundWorker8.IsBusy) Then
            BackgroundWorker8.RunWorkerAsync()
        End If
       
        Timer8.Start()


    End Sub






    Private Sub Button2_Click_2(sender As System.Object, e As System.EventArgs) Handles Button2.Click


        Dim url As String = "https://login.lisk.io/api/transactions"

        If RadioButton1.Checked = True Then
            url = "https://login.lisk.io/api/transactions"


        End If
        If RadioButton2.Checked = True Then
            url = "https://liskworld.info/api/transactions"

        End If
        If RadioButton3.Checked = True Then
            url = "https://lisk.liskwallet.io/api/transactions"

        End If
        If RadioButton4.Checked = True Then
            url = "https://liskwallet.punkrock.me/api/transactions"

        End If
        If RadioButton5.Checked = True Then
            url = "https://lisk-login.vipertkd.com/api/transactions"

        End If
        If RadioButton6.Checked = True Then
            url = "https://lisk.delegates.site/api/transactions"

        End If
        If RadioButton7.Checked = True Then
            url = "https://wallet.lisknode.io/api/transactions"

        End If
        If RadioButton8.Checked = True Then
            url = "https://wallet.mylisk.com/api/transactions"

        End If



        'http://stackoverflow.com/questions/812711/how-do-you-do-an-http-put

        Dim title As String = String.Empty
        Dim defaultResponse As String = String.Empty
        Dim prompt As String = String.Empty


        Dim post As String
        Dim original As String
        prompt = "How many LISK to send?"
        original = InputBox(prompt, title, defaultResponse)
        If original Is "" Then GoTo fooerror
        '  https://www.dotnetperls.com/string-length-vbnet
        Dim length As Integer

        Try

            Try
                Dim cut_at As String = ","

                Dim stringSeparators() As String = {cut_at}
                Dim split = original.Split(stringSeparators, 2, StringSplitOptions.RemoveEmptyEntries)

                Dim string_before = split(0)
                Dim string_after = split(1)
                original = string_before
                post = string_after
                ' Dim post2 As String = string_after
                length = post.Length
                '  MsgBox(length)

            Catch

            End Try

            Try
                Dim cut_at As String = "."

                Dim stringSeparators() As String = {cut_at}
                Dim split = original.Split(stringSeparators, 2, StringSplitOptions.RemoveEmptyEntries)

                Dim string_before = split(0)
                Dim string_after = split(1)
                original = string_before
                post = string_after
                length = post.Length
                ' post3 = post2
                ' MsgBox(length)




            Catch

            End Try

            If Regex.IsMatch(original, "^[0-9 ]+$") Then
                If post = "" Then

                    MsgBox(original & ",00" & " LISK will be sent")

                Else

                    MsgBox(original & "," & post & " LISK will be sent")

                End If



            Else
                MsgBox("kindly enter only numbers")
                GoTo FooError


            End If



        Catch

        End Try






        Dim decimali As String

        If length = 0 Then
            decimali = post & "00000000"
        End If

        If length = 1 Then
            decimali = post & "0000000"
        End If
        If length = 2 Then
            decimali = post & "000000"
        End If

        If length = 3 Then
            decimali = post & "00000"
        End If

        If length = 4 Then
            decimali = post & "0000"
        End If

        If length = 5 Then
            decimali = post & "000"
        End If

        If length = 6 Then
            decimali = post & "00"
        End If

        If length = 7 Then
            decimali = post & "0"
        End If

        If length = 8 Then
            decimali = post & ""
        End If

        If length > 8 Then
            MsgBox("kindly enter correct values")
            GoTo FooError
        End If





        Dim recipientId As Object
        prompt = "To which address?"
        recipientId = InputBox(prompt, title, defaultResponse)
        If recipientId Is "" Then GoTo fooerror

        Dim seed As Object
        prompt = "Hello there. What's your seed?"
        seed = InputBox(prompt, title, defaultResponse)
        If seed Is "" Then GoTo fooerror




        ' Dim xml As String = "{" & Chr(34) & "secret" & Chr(34) & ":" & Chr(34) & seed & Chr(34) & "," & Chr(34) & "amount" & Chr(34) & ":" & original & "00000000" & "," & Chr(34) & "recipientId" & Chr(34) & ":" & Chr(34) & recipientId & Chr(34) & "}"
        Dim xml As String = "{" & Chr(34) & "secret" & Chr(34) & ":" & Chr(34) & seed & Chr(34) & "," & Chr(34) & "amount" & Chr(34) & ":" & original & decimali & "," & Chr(34) & "recipientId" & Chr(34) & ":" & Chr(34) & recipientId & Chr(34) & "}"

        MsgBox("DO NOT SHARE THIS SCREEN. IT CONTAINS YOUR SEED" & vbCrLf & vbCrLf & xml & " will be sent to " & url)

        Dim arr As Byte() = System.Text.Encoding.UTF8.GetBytes(xml)
        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
        request.Method = "PUT"
        request.ContentType = "application/json"
        request.ContentLength = arr.Length
        ServicePointManager.ServerCertificateValidationCallback = AddressOf ValidateRemoteCertificate
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(arr, 0, arr.Length)
        dataStream.Close()
        Try
            Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
            Dim returnString As String = response.StatusCode.ToString()
            Dim returnString2 As String = response.ToString()
            MsgBox(returnString)


            '' https://developer.yahoo.com/dotnet/howto-xml_vb.html

            Dim reader As StreamReader
            Dim result As String

            Try
                response = DirectCast(request.GetResponse(), HttpWebResponse)

                reader = New StreamReader(response.GetResponseStream())

                result = reader.ReadToEnd()
            Finally
                If Not response Is Nothing Then response.Close()
            End Try

            MsgBox(result)

            '' prova

        Catch
            MsgBox("tx failed")
        End Try



        seed = ""

FooError:

    End Sub







    Private Sub Button5_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button6_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button7_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs)
        Dim dynamicLinkLabel As New LinkLabel
        dynamicLinkLabel.BackColor = Color.Red
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(LinkLabel1.Text)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start(LinkLabel2.Text)
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start(LinkLabel3.Text)
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Process.Start(LinkLabel4.Text)
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Process.Start(LinkLabel5.Text)
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Process.Start(LinkLabel6.Text)
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Process.Start(LinkLabel7.Text)
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Process.Start(LinkLabel8.Text)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        '    If MsgBox("Prompt", MsgBoxStyle.OkCancel, "Title") = MsgBoxResult.Ok Then
        Dim defaultResponse As String = String.Empty
        Dim title As String = String.Empty

        If senderId Is Nothing Or senderId Is "" Then
            Dim prompt As String = String.Empty
            prompt = "What is your address?"
            senderId = InputBox(prompt, title, defaultResponse)
            If senderId Is "" Then GoTo fooerror
        Else
            MsgBox("using your address " & senderId)
        End If


        '  If senderId IsNot "" Or senderId IsNot Nothing Then
        'MsgBox("using your address " & senderId)
        '   Else
        '   Dim prompt As String = String.Empty
        '   prompt = "What is your address?"
        '   senderId = InputBox(prompt, title, defaultResponse)
        '  If senderId Is "" Then GoTo fooerror
        '  End If




        Dim request As HttpWebRequest

        Dim response As HttpWebResponse = Nothing

        Dim reader As StreamReader

        On Error Resume Next
        request = DirectCast(WebRequest.Create("https://login.lisk.io/api/accounts?address=" & senderId), HttpWebRequest)
        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()
        MsgBox(rawresp)


        Dim jResults As Object = JObject.Parse(rawresp)
        Dim testo As String = If(jResults("account") Is Nothing, "", jResults("account").ToString())
        Dim jResults2 As Object = JObject.Parse(testo)
        Dim testo2 As String = If(jResults2("secondSignature") Is Nothing, "", jResults2("secondSignature").ToString())
        If testo2 = 0 Then
            Me.Button2.PerformClick()

        Else
            Me.Button3.PerformClick()

        End If
fooerror:
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click


        Dim url As String = "https://login.lisk.io/api/transactions"

        If RadioButton1.Checked = True Then
            url = "https://login.lisk.io/api/transactions"


        End If
        If RadioButton2.Checked = True Then
            url = "https://liskworld.info/api/transactions"

        End If
        If RadioButton3.Checked = True Then
            url = "https://lisk.liskwallet.io/api/transactions"

        End If
        If RadioButton4.Checked = True Then
            url = "https://liskwallet.punkrock.me/api/transactions"

        End If
        If RadioButton5.Checked = True Then
            url = "https://lisk-login.vipertkd.com/api/transactions"

        End If
        If RadioButton6.Checked = True Then
            url = "https://lisk.delegates.site/api/transactions"

        End If
        If RadioButton7.Checked = True Then
            url = "https://wallet.lisknode.io/api/transactions"

        End If
        If RadioButton8.Checked = True Then
            url = "https://wallet.mylisk.com/api/transactions"

        End If

        If RadioButton8.Checked = True Then
            url = "https://lisknodes.tech/api/transactions"

        End If




        'http://stackoverflow.com/questions/812711/how-do-you-do-an-http-put

        Dim title As String = String.Empty
        Dim defaultResponse As String = String.Empty
        Dim prompt As String = String.Empty

        Dim post As String
        Dim original As String
        prompt = "How many LISK to send?"
        original = InputBox(prompt, title, defaultResponse)
        If original Is "" Then GoTo fooerror
        '  https://www.dotnetperls.com/string-length-vbnet
        Dim length As Integer

        Try

            Try
                Dim cut_at As String = ","

                Dim stringSeparators() As String = {cut_at}
                Dim split = original.Split(stringSeparators, 2, StringSplitOptions.RemoveEmptyEntries)

                Dim string_before = split(0)
                Dim string_after = split(1)
                original = string_before
                post = string_after
                ' Dim post2 As String = string_after
                length = post.Length
                '  MsgBox(length)

            Catch

            End Try

            Try
                Dim cut_at As String = "."

                Dim stringSeparators() As String = {cut_at}
                Dim split = original.Split(stringSeparators, 2, StringSplitOptions.RemoveEmptyEntries)

                Dim string_before = split(0)
                Dim string_after = split(1)
                original = string_before
                post = string_after
                length = post.Length
                ' post3 = post2
                ' MsgBox(length)




            Catch

            End Try

            If Regex.IsMatch(original, "^[0-9 ]+$") Then
                If post = "" Then

                    MsgBox(original & ",00" & " LISK will be sent")

                Else

                    MsgBox(original & "," & post & " LISK will be sent")

                End If



            Else
                MsgBox("kindly enter only numbers")
                GoTo FooError


            End If



        Catch

        End Try






        Dim decimali As String

        If length = 0 Then
            decimali = post & "00000000"
        End If

        If length = 1 Then
            decimali = post & "0000000"
        End If
        If length = 2 Then
            decimali = post & "000000"
        End If

        If length = 3 Then
            decimali = post & "00000"
        End If

        If length = 4 Then
            decimali = post & "0000"
        End If

        If length = 5 Then
            decimali = post & "000"
        End If

        If length = 6 Then
            decimali = post & "00"
        End If

        If length = 7 Then
            decimali = post & "0"
        End If

        If length = 8 Then
            decimali = post & ""
        End If

        If length > 8 Then
            MsgBox("kindly enter correct values")
            GoTo FooError
        End If



        Dim recipientId As Object
        prompt = "To which address?"
        recipientId = InputBox(prompt, title, defaultResponse)
        If recipientId Is "" Then GoTo fooerror

        Dim seed As Object
        prompt = "What's your seed?"
        seed = InputBox(prompt, title, defaultResponse)
        If seed Is "" Then GoTo fooerror

        Dim seed2 As Object
        prompt = "What's your second signature?"
        seed2 = InputBox(prompt, title, defaultResponse)
        If seed2 Is "" Then GoTo fooerror


        ' Dim xml As String = "{" & Chr(34) & "secret" & Chr(34) & ":" & Chr(34) & seed & Chr(34) & "," & Chr(34) & "secondSecret" & Chr(34) & ":" & Chr(34) & seed2 & Chr(34) & "," & Chr(34) & "amount" & Chr(34) & ":" & original & "00000000" & "," & Chr(34) & "recipientId" & Chr(34) & ":" & Chr(34) & recipientId & Chr(34) & "}"
        Dim xml As String = "{" & Chr(34) & "secret" & Chr(34) & ":" & Chr(34) & seed & Chr(34) & "," & Chr(34) & "secondSecret" & Chr(34) & ":" & Chr(34) & seed2 & Chr(34) & "," & Chr(34) & "amount" & Chr(34) & ":" & original & decimali & "," & Chr(34) & "recipientId" & Chr(34) & ":" & Chr(34) & recipientId & Chr(34) & "}"

        MsgBox("DO NOT SHARE THIS SCREEN. IT CONTAINS YOUR SEED" & vbCrLf & vbCrLf & xml & " will be sent to " & url)

        Dim arr As Byte() = System.Text.Encoding.UTF8.GetBytes(xml)
        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
        request.Method = "PUT"
        request.ContentType = "application/json"
        request.ContentLength = arr.Length
        ServicePointManager.ServerCertificateValidationCallback = AddressOf ValidateRemoteCertificate
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(arr, 0, arr.Length)
        dataStream.Close()
        Try
            Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
            Dim returnString As String = response.StatusCode.ToString()
            Dim returnString2 As String = response.ToString()
            MsgBox(returnString)
            '' https://developer.yahoo.com/dotnet/howto-xml_vb.html
            Dim reader As StreamReader
            Dim result As String

            Try
                response = DirectCast(request.GetResponse(), HttpWebResponse)

                reader = New StreamReader(response.GetResponseStream())

                result = reader.ReadToEnd()
            Finally
                If Not response Is Nothing Then response.Close()
            End Try

            MsgBox(result)


        Catch
            MsgBox("tx fallita")
        End Try
        seed = ""
        seed2 = ""
FooError:
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        Dim defaultResponse As String = String.Empty
        Dim title As String = String.Empty
        Dim request As HttpWebRequest

        Dim response As HttpWebResponse = Nothing

        Dim reader As StreamReader
        Dim prompt As String = String.Empty
        Dim senderidtemp As String
        prompt = "What is your address?"
        senderidtemp = InputBox(prompt, title, defaultResponse)
        If senderidtemp Is "" Then
            GoTo fooerror
        Else
            senderId = senderidtemp
        End If



        'http://www.dotnetheaven.com/article/windows-registry-in-vb.net
        'https://msdn.microsoft.com/it-it/library/xz88758e.aspx
        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)
        Dim newkey As RegistryKey = key.CreateSubKey("wallisk")
        newkey.SetValue("address", senderId)




        On Error Resume Next
        request = DirectCast(WebRequest.Create("https://login.lisk.io/api/accounts?address=" & senderId), HttpWebRequest)
        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()

        Dim jResults As Object = JObject.Parse(rawresp)
        Dim testo As String = If(jResults("account") Is Nothing, "", jResults("account").ToString())
        Dim jResults2 As Object = JObject.Parse(testo)
        Dim testo2 As String = If(jResults2("balance") Is Nothing, "", jResults2("balance").ToString())

        Dim testo4 As String
        testo4 = testo2 / 100000000
        Label1.Text = "Address " & senderId
        Label4.Text = testo4 & " LISK"

        Button5.Enabled = True
        Button5.Text = "update"

fooerror:

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click

        Dim defaultResponse As String = String.Empty
        Dim title As String = String.Empty
        Dim request As HttpWebRequest

        Dim response As HttpWebResponse = Nothing

        Dim reader As StreamReader
        Dim prompt As String = String.Empty

        On Error Resume Next
        request = DirectCast(WebRequest.Create("https://login.lisk.io/api/accounts?address=" & senderId), HttpWebRequest)
        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()

        Dim jResults As Object = JObject.Parse(rawresp)
        Dim testo As String = If(jResults("account") Is Nothing, "", jResults("account").ToString())
        Dim jResults2 As Object = JObject.Parse(testo)
        Dim testo2 As String = If(jResults2("balance") Is Nothing, "", jResults2("balance").ToString())

        Dim testo4 As String
        testo4 = testo2 / 100000000
        Label1.Text = "Address " & senderId
        Label4.Text = testo4 & " LISK"
        Button5.Enabled = True
        Button5.Text = "update balance"

    End Sub

    Private Sub Timer9_Tick(sender As System.Object, e As System.EventArgs) Handles Timer9.Tick
        If Not (BackgroundWorker9.IsBusy) Then
            BackgroundWorker9.RunWorkerAsync()
        End If
        Timer9.Start()
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Process.Start(LinkLabel9.Text)
    End Sub

    Private Sub Label6_Click(sender As System.Object, e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        votepools = "no"
        If MsgBox("Completing this procedure will cost you 1 LISK and you will vote all public wallet delegates: corsaro, phoenix1969, vipertdk, punkrock, hagie, gr33ndragon, bioly and gregorst, so to support this software", MsgBoxStyle.OkCancel, "Title") = MsgBoxResult.Ok Then



            ' MsgBox("Completing this procedure will cost you 1 LISK and you will vote all public wallet delegates: corsaro, phoenix1969, vipertdk, punkrock, hagie, gr33ndragon, bioly and gregorst, so to support this software")

            Dim defaultResponse As String = String.Empty
            Dim title As String = String.Empty

            If senderId IsNot Nothing Then
                MsgBox("using your address " & senderId)
            Else
                Dim prompt As String = String.Empty
                prompt = "What is your address?"
                senderId = InputBox(prompt, title, defaultResponse)
            End If




            Dim request As HttpWebRequest

            Dim response As HttpWebResponse = Nothing

            Dim reader As StreamReader

            On Error Resume Next
            request = DirectCast(WebRequest.Create("https://login.lisk.io/api/accounts?address=" & senderId), HttpWebRequest)
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())

            Dim rawresp As String
            rawresp = reader.ReadToEnd()
            '    MsgBox(rawresp)


            Dim jResults As Object = JObject.Parse(rawresp)
            Dim testoerr As String = If(jResults("error") Is Nothing, "", jResults("error").ToString())
            '    MsgBox(testoerr)
            If testoerr = "Account not found" Then
                '  Me.Button8.PerformClick()
                MsgBox(rawresp)
                GoTo fooerror
            Else

            End If


            Dim jResults2 As Object = JObject.Parse(testoerr)

            Dim testo As String = If(jResults2("account") Is Nothing, "", jResults2("account").ToString())

            Dim jResults3 As Object = JObject.Parse(testo)
            Dim testo2 As String = If(jResults3("secondSignature") Is Nothing, "", jResults3("secondSignature").ToString())
            If testo2 = 0 Then
                Me.Button8.PerformClick()

            Else
                Me.Button7.PerformClick()
                ' MsgBox("xxx")

            End If

        End If
fooerror:
    End Sub
    Private Sub stopping()

    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click

        Dim url As String = "https://login.lisk.io/api/accounts/delegates"

        If RadioButton1.Checked = True Then
            url = "https://login.lisk.io/api/accounts/delegates"


        End If
        If RadioButton2.Checked = True Then
            url = "https://liskworld.info/api/accounts/delegates"

        End If
        If RadioButton3.Checked = True Then
            url = "https://lisk.liskwallet.io/api/accounts/delegates"

        End If
        If RadioButton4.Checked = True Then
            url = "https://liskwallet.punkrock.me/api/accounts/delegates"

        End If
        If RadioButton5.Checked = True Then
            url = "https://lisk-login.vipertkd.com/api/accounts/delegates"

        End If
        If RadioButton6.Checked = True Then
            url = "https://lisk.delegates.site/api/accounts/delegates"

        End If
        If RadioButton7.Checked = True Then
            url = "https://wallet.lisknode.io/api/accounts/delegates"

        End If
        If RadioButton8.Checked = True Then
            url = "https://wallet.mylisk.com/api/accounts/delegates"

        End If

        If RadioButton8.Checked = True Then
            url = "https://lisknodes.tech/api/accounts/delegates"

        End If




        'http://stackoverflow.com/questions/812711/how-do-you-do-an-http-put

        Dim title As String = String.Empty
        Dim defaultResponse As String = String.Empty
        Dim prompt As String = String.Empty

        Dim rawresp As String


        Dim request As HttpWebRequest

        Dim response As HttpWebResponse = Nothing

        Dim reader As StreamReader

        request = DirectCast(WebRequest.Create("https://login.lisk.io/api/accounts?address=" & senderId), HttpWebRequest)
        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())




        rawresp = reader.ReadToEnd()


        ' Dim jResults As Object = JObject.Parse(rawresp)
        '   Dim testo As String = If(jResults("account") Is Nothing, "", jResults("account").ToString())
        '  Dim jResults2 As Object = JObject.Parse(testo)
        ' Dim testo2 As String = If(jResults2("publicKey") Is Nothing, "", jResults2("publicKey").ToString())
        '   MsgBox("your pubKey is " & testo2) ' mia pubkey

        ' If jResults2("publicKey") Is Nothing Then MsgBox("xxx")

        pubkey()

        '   Dim seed As Object
        '  prompt = "What's your seed?"
        '  seed = InputBox(prompt, title, defaultResponse)
        '  If seed Is "" Then GoTo fooerror2

        request = DirectCast(WebRequest.Create("https://login.lisk.io/api/accounts/delegates/?address=" & senderId), HttpWebRequest)
        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        rawresp = reader.ReadToEnd()


        Dim jResultsb As Object = JObject.Parse(rawresp)
        Dim testob As String = If(jResultsb("delegates") Is Nothing, "", jResultsb("delegates").ToString())

        Dim myAL As New ArrayList

        Dim pubkey1 As String = "ac09bc40c889f688f9158cca1fcfcdf6320f501242e0f7088d52a5077084ccba" ' corsaro
        Dim pubkey2 As String = "ab086300d5d1e366d56ff2b4919ee718d3d6b72a862bafec0f1d42c9812af30b"
        Dim pubkey3 As String = "45ab8f54edff6b802335dc3ea5cd5bc5324e4031c0598a2cdcae79402e4941f8"
        Dim pubkey4 As String = "677c79b243ed96a8439e8bd193d6ab966ce43c9aa18830d2b9eb8974455d79f8"
        Dim pubkey5 As String = "27f7950c552f9ffa8c871940167e92257cf90625443a0183aa3f7e05e1f6cb21"
        Dim pubkey6 As String = "ad936990fb57f7e686763c293e9ca773d1d921888f5235189945a10029cd95b0"
        Dim pubkey7 As String = "1681920f9cb83ff2590a8e5c502a7015d4834f5365cf5ed17392c9c78147f94d"
        Dim pubkey8 As String = "ec151a510d095dc2c19a87a3b54549cfe1c30e703d5216197b4c879ff08bc3ed"

        Dim pubkey9 As String = "eddeb37070a19e1277db5ec34ea12225e84ccece9e6b2bb1bb27c3ba3999dac7" 'phinx
        Dim pubkey10 As String = "253e674789632f72c98d47a650f1ca5ece0dbb82f591080471129d57ed88fb8a" 'shinekami
        Dim pubkey11 As String = "b002f58531c074c7190714523eec08c48db8c7cfc0c943097db1a2e82ed87f84" 'thepool
        Dim pubkey12 As String = "ec111c8ad482445cfe83d811a7edd1f1d2765079c99d7d958cca1354740b7614" 'thepool_com_01
        Dim pubkey13 As String = "32f20bee855238630b0f791560c02cf93014977b4b25c19ef93cd92220390276" 'robinhood
        Dim pubkey14 As String = "b3953cb16e2457b9be78ad8c8a2985435dedaed5f0dd63443bdfbccc92d09f2d" 'rooney
        Dim pubkey15 As String = "25e961fa459d202816776c8736560d493a94fdd7381971f63fb9b70479487598" 'badman0316





        If votepools = "no" Then


            If testob.Contains(pubkey1) = False Then
                myAL.Add(Chr(34) & "+" & pubkey1 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey2) = False Then
                myAL.Add(Chr(34) & "+" & pubkey2 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey3) = False Then
                myAL.Add(Chr(34) & "+" & pubkey3 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey4) = False Then
                myAL.Add(Chr(34) & "+" & pubkey4 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey5) = False Then
                myAL.Add(Chr(34) & "+" & pubkey5 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey6) = False Then
                myAL.Add(Chr(34) & "+" & pubkey6 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey7) = False Then
                myAL.Add(Chr(34) & "+" & pubkey7 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey8) = False Then
                myAL.Add(Chr(34) & "+" & pubkey8 & Chr(34))
            Else

            End If

        Else

            If testob.Contains(pubkey1) = False Then
                myAL.Add(Chr(34) & "+" & pubkey1 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey2) = False Then
                myAL.Add(Chr(34) & "+" & pubkey2 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey3) = False Then
                myAL.Add(Chr(34) & "+" & pubkey3 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey4) = False Then
                myAL.Add(Chr(34) & "+" & pubkey4 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey5) = False Then
                myAL.Add(Chr(34) & "+" & pubkey5 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey6) = False Then
                myAL.Add(Chr(34) & "+" & pubkey6 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey7) = False Then
                myAL.Add(Chr(34) & "+" & pubkey7 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey8) = False Then
                myAL.Add(Chr(34) & "+" & pubkey8 & Chr(34))
            Else

            End If


            If testob.Contains(pubkey9) = False Then
                myAL.Add(Chr(34) & "+" & pubkey9 & Chr(34))
            Else
            End If

            If testob.Contains(pubkey10) = False Then
                myAL.Add(Chr(34) & "+" & pubkey10 & Chr(34))
            Else
            End If

            If testob.Contains(pubkey11) = False Then
                myAL.Add(Chr(34) & "+" & pubkey11 & Chr(34))
            Else
            End If

            If testob.Contains(pubkey12) = False Then
                myAL.Add(Chr(34) & "+" & pubkey12 & Chr(34))
            Else
            End If

            If testob.Contains(pubkey13) = False Then
                myAL.Add(Chr(34) & "+" & pubkey13 & Chr(34))
            Else
            End If


            If testob.Contains(pubkey14) = False Then
                myAL.Add(Chr(34) & "+" & pubkey14 & Chr(34))
            Else
            End If

            If testob.Contains(pubkey15) = False Then
                myAL.Add(Chr(34) & "+" & pubkey15 & Chr(34))
            Else
            End If



        End If






        Dim LineOfText As String

        LineOfText = String.Join(",", CType(myAL.ToArray(Type.GetType("System.String")), String()))
        '   MsgBox(LineOfText)

        '    ":[" & Chr(34) & "+" & pubkey1 & Chr(34)& "," & Chr(34) & "+" & pubkey2 & Chr(34)& "," & Chr(34) & "+" & pubkey3 & Chr(34)& "," & Chr(34) & "+" & pubkey4 & Chr(34)& "," & Chr(34) & "+" & pubkey5 & Chr(34)& "," & Chr(34) & "+" & pubkey6 & Chr(34)& "," & Chr(34) & "+" & pubkey7 & Chr(34)& "," & Chr(34) & "+" & pubkey8 & Chr(34) & "]"
        If LineOfText = "" Then
            MsgBox("you have already voted all selected delegates")
            GoTo Fooerror2
        End If

        Dim votelist As String = "all delegates here"

        Dim xml As String = "{" & Chr(34) & "secret" & Chr(34) & ":" & Chr(34) & seedx & Chr(34) & "," & Chr(34) & "publicKey" & Chr(34) & ":" & Chr(34) & pubkeyx & Chr(34) & "," & Chr(34) & "delegates" & Chr(34) & ":[" & LineOfText & "]" & "}"

        '  Dim xml As String = "{" & Chr(34) & "secret" & Chr(34) & ":" & Chr(34) & seed & Chr(34) & "," & Chr(34) & "publicKey" & Chr(34) & ":" & Chr(34) & testo2 & Chr(34) & "," & Chr(34) & "delegates" & Chr(34) & ":[" & Chr(34) & "+" & pubkey1 & Chr(34) & "," & Chr(34) & "+" & pubkey2 & Chr(34) & "," & Chr(34) & "+" & pubkey3 & Chr(34) & "," & Chr(34) & "+" & pubkey4 & Chr(34) & "," & Chr(34) & "+" & pubkey5 & Chr(34) & "," & Chr(34) & "+" & pubkey6 & Chr(34) & "," & Chr(34) & "+" & pubkey7 & Chr(34) & "," & Chr(34) & "+" & pubkey8 & Chr(34) & "]" & "}"

        MsgBox("DO NOT SHARE THIS SCREEN. IT CONTAINS YOUR SEED" & vbCrLf & vbCrLf & xml & " will be sent to " & url)

        Dim arr As Byte() = System.Text.Encoding.UTF8.GetBytes(xml)
        request = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
        request.Method = "PUT"
        request.ContentType = "application/json"
        request.ContentLength = arr.Length
        ServicePointManager.ServerCertificateValidationCallback = AddressOf ValidateRemoteCertificate
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(arr, 0, arr.Length)
        dataStream.Close()
        Try
            ' Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
            Dim returnString As String = response.StatusCode.ToString()
            Dim returnString2 As String = response.ToString()
            MsgBox(returnString)
            '   MsgBox(returnString2)


            '' prova
            '' https://developer.yahoo.com/dotnet/howto-xml_vb.html
            '  Dim requestxx As HttpWebRequest
            '  Dim responsexx As HttpWebResponse = Nothing
            '  Dim reader As StreamReader
            Dim result As String

            Try
                ' Create the web request  
                '   request = DirectCast(WebRequest.Create(address), HttpWebRequest)

                ' Get response  
                response = DirectCast(request.GetResponse(), HttpWebResponse)

                ' Get the response stream into a reader  
                reader = New StreamReader(response.GetResponseStream())

                ' Read the whole contents and return as a string  
                result = reader.ReadToEnd()
            Finally
                If Not response Is Nothing Then response.Close()
            End Try

            MsgBox(result)

            '' prova

        Catch
            MsgBox("tx fallita")
        End Try
        seedx = ""
        '  seed2 = ""
Fooerror2:

    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        '/api/accounts?address=3026381832248350807L

        'voto

        Dim url As String = "https://login.lisk.io/api/accounts/delegates"

        If RadioButton1.Checked = True Then
            url = "https://login.lisk.io/api/accounts/delegates"


        End If
        If RadioButton2.Checked = True Then
            url = "https://liskworld.info/api/accounts/delegates"

        End If
        If RadioButton3.Checked = True Then
            url = "https://lisk.liskwallet.io/api/accounts/delegates"

        End If
        If RadioButton4.Checked = True Then
            url = "https://liskwallet.punkrock.me/api/accounts/delegates"

        End If
        If RadioButton5.Checked = True Then
            url = "https://lisk-login.vipertkd.com/api/accounts/delegates"

        End If
        If RadioButton6.Checked = True Then
            url = "https://lisk.delegates.site/api/accounts/delegates"

        End If
        If RadioButton7.Checked = True Then
            url = "https://wallet.lisknode.io/api/accounts/delegates"

        End If
        If RadioButton8.Checked = True Then
            url = "https://wallet.mylisk.com/api/accounts/delegates"

        End If

        If RadioButton8.Checked = True Then
            url = "https://lisknodes.tech/api/accounts/delegates"

        End If




        ' Dim original As String = "100.333"
        'http://stackoverflow.com/questions/812711/how-do-you-do-an-http-put

        Dim title As String = String.Empty
        Dim defaultResponse As String = String.Empty
        Dim prompt As String = String.Empty




        Dim request As HttpWebRequest

        Dim response As HttpWebResponse = Nothing

        Dim reader As StreamReader

        request = DirectCast(WebRequest.Create("https://login.lisk.io/api/accounts?address=" & senderId), HttpWebRequest)
        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()
        Dim jResults As Object = JObject.Parse(rawresp)
        Dim testo As String = If(jResults("account") Is Nothing, "", jResults("account").ToString())
        Dim jResults2 As Object = JObject.Parse(testo)
        Dim testo2 As String = If(jResults2("publicKey") Is Nothing, "", jResults2("publicKey").ToString())
        ' MsgBox("your pubKey is " & testo2) ' mia pubkey

        pubkey()

        '   Dim seed As Object
        '  prompt = "What's your seed?"
        '  seed = InputBox(prompt, title, defaultResponse)
        '  If seed Is "" Then GoTo fooerror

        Dim seed2 As Object
        prompt = "What's your second signature?"
        seed2 = InputBox(prompt, title, defaultResponse)
        If seed2 Is "" Then GoTo fooerror

        '' inizio




        request = DirectCast(WebRequest.Create("https://login.lisk.io/api/accounts/delegates/?address=" & senderId), HttpWebRequest)
        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        rawresp = reader.ReadToEnd()

        Dim jResultsb As Object = JObject.Parse(rawresp)
        Dim testob As String = If(jResultsb("delegates") Is Nothing, "", jResultsb("delegates").ToString())
        Dim myAL As New ArrayList

        Dim pubkey1 As String = "ac09bc40c889f688f9158cca1fcfcdf6320f501242e0f7088d52a5077084ccba" ' corsaro
        Dim pubkey2 As String = "ab086300d5d1e366d56ff2b4919ee718d3d6b72a862bafec0f1d42c9812af30b"
        Dim pubkey3 As String = "45ab8f54edff6b802335dc3ea5cd5bc5324e4031c0598a2cdcae79402e4941f8"
        Dim pubkey4 As String = "677c79b243ed96a8439e8bd193d6ab966ce43c9aa18830d2b9eb8974455d79f8"
        Dim pubkey5 As String = "27f7950c552f9ffa8c871940167e92257cf90625443a0183aa3f7e05e1f6cb21"
        Dim pubkey6 As String = "ad936990fb57f7e686763c293e9ca773d1d921888f5235189945a10029cd95b0"
        Dim pubkey7 As String = "1681920f9cb83ff2590a8e5c502a7015d4834f5365cf5ed17392c9c78147f94d"
        Dim pubkey8 As String = "ec151a510d095dc2c19a87a3b54549cfe1c30e703d5216197b4c879ff08bc3ed"

        Dim pubkey9 As String = "eddeb37070a19e1277db5ec34ea12225e84ccece9e6b2bb1bb27c3ba3999dac7" 'phinx
        Dim pubkey10 As String = "253e674789632f72c98d47a650f1ca5ece0dbb82f591080471129d57ed88fb8a" 'shinekami
        Dim pubkey11 As String = "b002f58531c074c7190714523eec08c48db8c7cfc0c943097db1a2e82ed87f84" 'thepool
        Dim pubkey12 As String = "ec111c8ad482445cfe83d811a7edd1f1d2765079c99d7d958cca1354740b7614" 'thepool_com_01
        Dim pubkey13 As String = "32f20bee855238630b0f791560c02cf93014977b4b25c19ef93cd92220390276" 'robinhood
        Dim pubkey14 As String = "b3953cb16e2457b9be78ad8c8a2985435dedaed5f0dd63443bdfbccc92d09f2d" 'rooney
        Dim pubkey15 As String = "25e961fa459d202816776c8736560d493a94fdd7381971f63fb9b70479487598" 'badman0316




        If votepools = "no" Then


            If testob.Contains(pubkey1) = False Then
                myAL.Add(Chr(34) & "+" & pubkey1 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey2) = False Then
                myAL.Add(Chr(34) & "+" & pubkey2 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey3) = False Then
                myAL.Add(Chr(34) & "+" & pubkey3 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey4) = False Then
                myAL.Add(Chr(34) & "+" & pubkey4 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey5) = False Then
                myAL.Add(Chr(34) & "+" & pubkey5 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey6) = False Then
                myAL.Add(Chr(34) & "+" & pubkey6 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey7) = False Then
                myAL.Add(Chr(34) & "+" & pubkey7 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey8) = False Then
                myAL.Add(Chr(34) & "+" & pubkey8 & Chr(34))
            Else

            End If

        Else

            If testob.Contains(pubkey1) = False Then
                myAL.Add(Chr(34) & "+" & pubkey1 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey2) = False Then
                myAL.Add(Chr(34) & "+" & pubkey2 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey3) = False Then
                myAL.Add(Chr(34) & "+" & pubkey3 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey4) = False Then
                myAL.Add(Chr(34) & "+" & pubkey4 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey5) = False Then
                myAL.Add(Chr(34) & "+" & pubkey5 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey6) = False Then
                myAL.Add(Chr(34) & "+" & pubkey6 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey7) = False Then
                myAL.Add(Chr(34) & "+" & pubkey7 & Chr(34))
            Else

            End If

            If testob.Contains(pubkey8) = False Then
                myAL.Add(Chr(34) & "+" & pubkey8 & Chr(34))
            Else

            End If


            If testob.Contains(pubkey9) = False Then
                myAL.Add(Chr(34) & "+" & pubkey9 & Chr(34))
            Else
            End If

            If testob.Contains(pubkey10) = False Then
                myAL.Add(Chr(34) & "+" & pubkey10 & Chr(34))
            Else
            End If

            If testob.Contains(pubkey11) = False Then
                myAL.Add(Chr(34) & "+" & pubkey11 & Chr(34))
            Else
            End If

            If testob.Contains(pubkey12) = False Then
                myAL.Add(Chr(34) & "+" & pubkey12 & Chr(34))
            Else
            End If

            If testob.Contains(pubkey13) = False Then
                myAL.Add(Chr(34) & "+" & pubkey13 & Chr(34))
            Else
            End If


            If testob.Contains(pubkey14) = False Then
                myAL.Add(Chr(34) & "+" & pubkey14 & Chr(34))
            Else
            End If

            If testob.Contains(pubkey15) = False Then
                myAL.Add(Chr(34) & "+" & pubkey15 & Chr(34))
            Else
            End If



        End If






        Dim LineOfText As String

        LineOfText = String.Join(",", CType(myAL.ToArray(Type.GetType("System.String")), String()))


        If LineOfText = "" Then
            MsgBox("you have already voted all selected delegates")
            GoTo Fooerror
        End If
        Dim votelist As String = "all delegates here"



        Dim xml As String = "{" & Chr(34) & "secret" & Chr(34) & ":" & Chr(34) & seedx & Chr(34) & "," & Chr(34) & "secondSecret" & Chr(34) & ":" & Chr(34) & seed2 & Chr(34) & "," & Chr(34) & "publicKey" & Chr(34) & ":" & Chr(34) & testo2 & Chr(34) & "," & Chr(34) & "delegates" & Chr(34) & ":[" & LineOfText & "]" & "}"

        MsgBox("DO NOT SHARE THIS SCREEN. IT CONTAINS YOUR SEED" & vbCrLf & vbCrLf & xml & " will be sent to " & url)

        Dim arr As Byte() = System.Text.Encoding.UTF8.GetBytes(xml)
        request = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
        request.Method = "PUT"
        request.ContentType = "application/json"
        request.ContentLength = arr.Length
        ServicePointManager.ServerCertificateValidationCallback = AddressOf ValidateRemoteCertificate
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(arr, 0, arr.Length)
        dataStream.Close()
        Try
            Dim returnString As String = response.StatusCode.ToString()
            Dim returnString2 As String = response.ToString()
            MsgBox(returnString)


            '' https://developer.yahoo.com/dotnet/howto-xml_vb.html
            Dim result As String

            Try
                response = DirectCast(request.GetResponse(), HttpWebResponse)

                reader = New StreamReader(response.GetResponseStream())

                result = reader.ReadToEnd()
            Finally
                If Not response Is Nothing Then response.Close()
            End Try

            MsgBox(result)


        Catch
            MsgBox("tx fallita")
        End Try
        seedx = ""
        seed2 = ""
FooError:
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click


    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click

    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click

    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click




        Dim pRegKey As RegistryKey = Registry.CurrentUser
        pRegKey = pRegKey.OpenSubKey("SOFTWARE\wallisk")
        Dim val As Object = pRegKey.GetValue("address")
        MsgBox(val)



    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click

        If MsgBox("Completing this procedure will cost you 1 LISK and you will vote all public wallet delegates: corsaro, phoenix1969, vipertdk, punkrock, hagie, gr33ndragon, bioly and gregorst, so to support this software and besides you will stake your lisk on some of the main Lisk pools:" & vbCrLf & vbCrLf & "phinx" & vbCrLf & "shinekami" & vbCrLf & "thepool" & vbCrLf & "liskpool_com_01" & vbCrLf & "robinhood" & vbCrLf & "rooney" & vbCrLf & "badman0316", MsgBoxStyle.OkCancel, "Title") = MsgBoxResult.Ok Then


            'MsgBox("Completing this procedure will cost you 1 LISK and you will vote all public wallet delegates: corsaro, phoenix1969, vipertdk, punkrock, hagie, gr33ndragon, bioly and gregorst, so to support this software and besides you will stake your lisk on some of the main Lisk pools:" & vbCrLf & vbCrLf & "phinx" & vbCrLf & "shinekami" & vbCrLf & "thepool" & vbCrLf & "liskpool_com_01" & vbCrLf & "robinhood" & vbCrLf & "rooney" & vbCrLf & "badman0316" & vbCrLf & "lisk.pool.sexy")

            votepools = "yes"

            ' & vbCrLf & "phinx" & vbCrLf "shinekami" & vbCrLf "thepool" & vbCrLf "liskpool_com_01" & vbCrLf "robinhood" & vbCrLf "rooney" & vbCrLf "badman0316" & vbCrLf "lisk.pool.sexy"


            Dim defaultResponse As String = String.Empty
            Dim title As String = String.Empty

            If senderId IsNot Nothing Then
                MsgBox("using your address " & senderId)
            Else
                Dim prompt As String = String.Empty
                prompt = "What is your address?"
                senderId = InputBox(prompt, title, defaultResponse)
            End If




            Dim request As HttpWebRequest

            Dim response As HttpWebResponse = Nothing

            Dim reader As StreamReader

            On Error Resume Next
            request = DirectCast(WebRequest.Create("https://login.lisk.io/api/accounts?address=" & senderId), HttpWebRequest)
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())

            Dim rawresp As String
            rawresp = reader.ReadToEnd()
            '    MsgBox(rawresp)


            Dim jResults As Object = JObject.Parse(rawresp)
            Dim testoerr As String = If(jResults("error") Is Nothing, "", jResults("error").ToString())
            '    MsgBox(testoerr)
            If testoerr = "Account not found" Then
                MsgBox(rawresp)
                GoTo fooerror
            Else

            End If


            Dim jResults2 As Object = JObject.Parse(testoerr)

            Dim testo As String = If(jResults2("account") Is Nothing, "", jResults2("account").ToString())

            Dim jResults3 As Object = JObject.Parse(testo)
            Dim testo2 As String = If(jResults3("secondSignature") Is Nothing, "", jResults3("secondSignature").ToString())
            If testo2 = 0 Then
                Me.Button8.PerformClick()

            Else
                Me.Button7.PerformClick()
                ' MsgBox("xxx")

            End If
        End If
fooerror:
    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        If MsgBox("Prompt", MsgBoxStyle.OkCancel, "Title") = MsgBoxResult.Ok Then
            ' execute command
        End If
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click

        Dim title As String = String.Empty
        Dim defaultResponse As String = String.Empty
        Dim prompt As String = String.Empty

        Dim url As String = "https://login.lisk.io/api/accounts/generatePublicKey"


        Dim request As HttpWebRequest

        Dim responsex As HttpWebResponse = Nothing

        ' Dim readerx As StreamReader

        ' request = DirectCast(WebRequest.Create("https://login.lisk.io/api/accounts?address=" & senderId), HttpWebRequest)
        '   responsex = DirectCast(request.GetResponse(), HttpWebResponse)
        '  readerx = New StreamReader(responsex.GetResponseStream())
        '  Try
        'Dim rawresp As String
        '  rawresp = readerx.ReadToEnd()
        '  Dim jResults As Object = JObject.Parse(rawresp)
        '  Dim testo As String = If(jResults("account") Is Nothing, "", jResults("account").ToString())
        '  Dim jResults2 As Object = JObject.Parse(testo)
        '  Dim testo2 As String = If(jResults2("publicKey") Is Nothing, "", jResults2("publicKey").ToString())
        ' MsgBox("your pubKey is " & testo2) ' mia pubkey
        '  Catch

        Dim seed As Object
        prompt = "Hello there. What's your seed?"
        seed = InputBox(prompt, title, defaultResponse)
        If seed Is "" Then GoTo fooerror

        Dim xml As String = "{" & Chr(34) & "secret" & Chr(34) & ":" & Chr(34) & seed & Chr(34) & "}"

        '  MsgBox("DO NOT SHARE THIS SCREEN. IT CONTAINS YOUR SEED" & vbCrLf & vbCrLf & xml & " will be sent to " & url)

        Dim arr As Byte() = System.Text.Encoding.UTF8.GetBytes(xml)
        request = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.ContentLength = arr.Length
        ServicePointManager.ServerCertificateValidationCallback = AddressOf ValidateRemoteCertificate
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(arr, 0, arr.Length)
        dataStream.Close()

        Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
        Try

            '' https://developer.yahoo.com/dotnet/howto-xml_vb.html

            Dim reader As StreamReader
            Dim result As String

            response = DirectCast(request.GetResponse(), HttpWebResponse)

            reader = New StreamReader(response.GetResponseStream())

            result = reader.ReadToEnd()

            Dim jResults2 As Object = JObject.Parse(result)
            Dim testo2 As String = If(jResults2("publicKey") Is Nothing, "", jResults2("publicKey").ToString())
            MsgBox("your pubKey is " & testo2) ' mia pubkey
            response.Close()
            '
        Finally
            If Not response Is Nothing Then response.Close()


            '   MsgBox(result)

        End Try



fooerror:

    End Sub



    Private Sub pubkey()
        Dim title As String = String.Empty
        Dim defaultResponse As String = String.Empty
        Dim prompt As String = String.Empty

        Dim url As String = "https://login.lisk.io/api/accounts/generatePublicKey"


        Dim request As HttpWebRequest

        Dim responsex As HttpWebResponse = Nothing

        '    Dim readerx As StreamReader

        '  request = DirectCast(WebRequest.Create("https://login.lisk.io/api/accounts?address=" & senderId), HttpWebRequest)
        '   responsex = DirectCast(request.GetResponse(), HttpWebResponse)
        '  readerx = New StreamReader(responsex.GetResponseStream())
        '  Try
        'Dim rawresp As String
        '  rawresp = readerx.ReadToEnd()
        '  Dim jResults As Object = JObject.Parse(rawresp)
        '  Dim testo As String = If(jResults("account") Is Nothing, "", jResults("account").ToString())
        '  Dim jResults2 As Object = JObject.Parse(testo)
        '  Dim testo2 As String = If(jResults2("publicKey") Is Nothing, "", jResults2("publicKey").ToString())
        ' MsgBox("your pubKey is " & testo2) ' mia pubkey
        '  Catch

        Dim seed As Object
        prompt = "Hello there. What's your seed?"
        seed = InputBox(prompt, title, defaultResponse)
        If seed Is "" Then GoTo fooerror
        seedx = seed
        Dim xml As String = "{" & Chr(34) & "secret" & Chr(34) & ":" & Chr(34) & seed & Chr(34) & "}"

        '  MsgBox("DO NOT SHARE THIS SCREEN. IT CONTAINS YOUR SEED" & vbCrLf & vbCrLf & xml & " will be sent to " & url)

        Dim arr As Byte() = System.Text.Encoding.UTF8.GetBytes(xml)
        request = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.ContentLength = arr.Length
        ServicePointManager.ServerCertificateValidationCallback = AddressOf ValidateRemoteCertificate
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(arr, 0, arr.Length)
        dataStream.Close()

        Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)


        '' https://developer.yahoo.com/dotnet/howto-xml_vb.html

        Dim reader As StreamReader
        Dim result As String

        response = DirectCast(request.GetResponse(), HttpWebResponse)

        reader = New StreamReader(response.GetResponseStream())

        result = reader.ReadToEnd()

        Dim jResults2 As Object = JObject.Parse(result)
        Dim testo2 As String = If(jResults2("publicKey") Is Nothing, "", jResults2("publicKey").ToString())
        MsgBox("your pubKey is " & testo2) ' mia pubkey
        If Not response Is Nothing Then response.Close()
        pubkeyx = testo2

        '   MsgBox(result)

        '   End Try



fooerror:

    End Sub


    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs)
        Timer1.Start()
    End Sub

    Private Sub BackgroundWorker1_DoWork_1(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        '  MsgBox("xxx")
        Dim request As HttpWebRequest

        Dim response As HttpWebResponse = Nothing

        Dim reader As StreamReader

        On Error Resume Next

        request = DirectCast(WebRequest.Create("https://login.lisk.io/api/loader/status/sync"), HttpWebRequest)

        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()


        Dim jResults As Object = JObject.Parse(rawresp)


        TextBox1.Text = If(jResults("height") Is Nothing, "", jResults("height").ToString())
        BackgroundWorker1.CancelAsync()
        BackgroundWorker1.Dispose()
    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Dim request As HttpWebRequest

        Dim response As HttpWebResponse = Nothing

        Dim reader As StreamReader

        On Error Resume Next
        request = DirectCast(WebRequest.Create("http://liskworld.info:8000/api/loader/status/sync"), HttpWebRequest)
        'request = DirectCast(WebRequest.Create("https://login.lisk.io/api/loader/status/sync"), HttpWebRequest)

        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()


        Dim jResults As Object = JObject.Parse(rawresp)
        TextBox2.Text = If(jResults("height") Is Nothing, "", jResults("height").ToString())
        BackgroundWorker2.CancelAsync()
        BackgroundWorker2.Dispose()
    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        Dim request3 As HttpWebRequest

        Dim response3 As HttpWebResponse = Nothing

        Dim reader3 As StreamReader

        On Error Resume Next
        'request3 = DirectCast(WebRequest.Create("http://liskworld.info:8000/api/loader/status/sync"), HttpWebRequest)
        request3 = DirectCast(WebRequest.Create("https://lisk.liskwallet.io/api/loader/status/sync"), HttpWebRequest)

        response3 = DirectCast(request3.GetResponse(), HttpWebResponse)
        reader3 = New StreamReader(response3.GetResponseStream())

        Dim rawresp3 As String
        rawresp3 = reader3.ReadToEnd()


        Dim jResults As Object = JObject.Parse(rawresp3)
        TextBox3.Text = If(jResults("height") Is Nothing, "", jResults("height").ToString())
        BackgroundWorker3.CancelAsync()
        BackgroundWorker3.Dispose()
    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork
        Dim request4 As HttpWebRequest

        Dim response4 As HttpWebResponse = Nothing

        Dim reader4 As StreamReader
        On Error Resume Next

        'request3 = DirectCast(WebRequest.Create("http://liskworld.info:8000/api/loader/status/sync"), HttpWebRequest)
        request4 = DirectCast(WebRequest.Create("https://lisk-login.vipertkd.com/api/loader/status/sync"), HttpWebRequest)

        response4 = DirectCast(request4.GetResponse(), HttpWebResponse)
        reader4 = New StreamReader(response4.GetResponseStream())

        Dim rawresp4 As String
        rawresp4 = reader4.ReadToEnd()


        Dim jResults As Object = JObject.Parse(rawresp4)
        TextBox4.Text = If(jResults("height") Is Nothing, "", jResults("height").ToString())
        '   TextBox2.Text = If(jResults("syncing") Is Nothing, "", jResults("syncing").ToString())
        BackgroundWorker4.CancelAsync()
        BackgroundWorker4.Dispose()
    End Sub

    Private Sub BackgroundWorker5_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker5.DoWork
        Dim request5 As HttpWebRequest

        Dim response5 As HttpWebResponse = Nothing

        Dim reader5 As StreamReader
        On Error Resume Next


        request5 = DirectCast(WebRequest.Create("https://liskwallet.punkrock.me/api/loader/status/sync"), HttpWebRequest)

        response5 = DirectCast(request5.GetResponse(), HttpWebResponse)
        reader5 = New StreamReader(response5.GetResponseStream())

        Dim rawresp5 As String
        rawresp5 = reader5.ReadToEnd()


        Dim jResults As Object = JObject.Parse(rawresp5)
        TextBox5.Text = If(jResults("height") Is Nothing, "", jResults("height").ToString())
        '   TextBox2.Text = If(jResults("syncing") Is Nothing, "", jResults("syncing").ToString())
        BackgroundWorker5.CancelAsync()
        BackgroundWorker5.Dispose()
    End Sub

    Private Sub BackgroundWorker6_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker6.DoWork
        Dim request6 As HttpWebRequest

        Dim response6 As HttpWebResponse = Nothing

        Dim reader6 As StreamReader
        On Error Resume Next


        request6 = DirectCast(WebRequest.Create("https://lisk.delegates.site/api/loader/status/sync"), HttpWebRequest)

        response6 = DirectCast(request6.GetResponse(), HttpWebResponse)
        reader6 = New StreamReader(response6.GetResponseStream())

        Dim rawresp6 As String
        rawresp6 = reader6.ReadToEnd()


        Dim jResults As Object = JObject.Parse(rawresp6)
        TextBox6.Text = If(jResults("height") Is Nothing, "", jResults("height").ToString())
        '   TextBox2.Text = If(jResults("syncing") Is Nothing, "", jResults("syncing").ToString())
        BackgroundWorker6.CancelAsync()
        BackgroundWorker6.Dispose()
    End Sub

    Private Sub BackgroundWorker7_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker7.DoWork
        Dim request7 As HttpWebRequest

        Dim response7 As HttpWebResponse = Nothing

        Dim reader7 As StreamReader
        On Error Resume Next


        request7 = DirectCast(WebRequest.Create(" http://wallet.lisknode.io:8000/api/loader/status/sync"), HttpWebRequest)

        response7 = DirectCast(request7.GetResponse(), HttpWebResponse)
        reader7 = New StreamReader(response7.GetResponseStream())

        Dim rawresp7 As String
        rawresp7 = reader7.ReadToEnd()


        Dim jResults As Object = JObject.Parse(rawresp7)
        TextBox7.Text = If(jResults("height") Is Nothing, "", jResults("height").ToString())
        BackgroundWorker7.CancelAsync()
        BackgroundWorker7.Dispose()
    End Sub

    Private Sub BackgroundWorker8_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker8.DoWork
        Dim request8 As HttpWebRequest

        Dim response8 As HttpWebResponse = Nothing

        Dim reader8 As StreamReader
        On Error Resume Next

        request8 = DirectCast(WebRequest.Create("https://wallet.mylisk.com/api/loader/status/sync"), HttpWebRequest)

        response8 = DirectCast(request8.GetResponse(), HttpWebResponse)
        reader8 = New StreamReader(response8.GetResponseStream())

        Dim rawresp8 As String
        rawresp8 = reader8.ReadToEnd()

        Dim jResults As Object = JObject.Parse(rawresp8)
        TextBox8.Text = If(jResults("height") Is Nothing, "", jResults("height").ToString())
        BackgroundWorker8.CancelAsync()
        BackgroundWorker8.Dispose()
    End Sub

    Private Sub BackgroundWorker9_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker9.DoWork
        Dim request9 As HttpWebRequest

        Dim response9 As HttpWebResponse = Nothing

        Dim reader9 As StreamReader
        On Error Resume Next

        request9 = DirectCast(WebRequest.Create("https://lisknodes.tech/api/loader/status/sync"), HttpWebRequest)

        response9 = DirectCast(request9.GetResponse(), HttpWebResponse)
        reader9 = New StreamReader(response9.GetResponseStream())

        Dim rawresp9 As String
        rawresp9 = reader9.ReadToEnd()

        Dim jResults As Object = JObject.Parse(rawresp9)
        TextBox9.Text = If(jResults("height") Is Nothing, "", jResults("height").ToString())
        BackgroundWorker9.CancelAsync()
        BackgroundWorker9.Dispose()
    End Sub

    Private Sub BackgroundWorker10_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker10.DoWork
        Dim defaultResponse As String = String.Empty
        Dim title As String = String.Empty
        Dim request As HttpWebRequest

        Dim response As HttpWebResponse = Nothing

        Dim reader As StreamReader
        On Error Resume Next
        request = DirectCast(WebRequest.Create("https://login.lisk.io/api/accounts?address=" & senderId), HttpWebRequest)
        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()

        Dim jResults As Object = JObject.Parse(rawresp)
        Dim testo As String = If(jResults("account") Is Nothing, "", jResults("account").ToString())
        Dim jResults2 As Object = JObject.Parse(testo)
        Dim testo2 As String = If(jResults2("balance") Is Nothing, "", jResults2("balance").ToString())

        Dim testo4 As String
        testo4 = testo2 / 100000000
        Label1.Text = "Address " & senderId
        Label4.Text = testo4 & " LISK"

        Button5.Enabled = True
        Button5.Text = "update balance"
        Button4.Text = "change address"
        BackgroundWorker10.CancelAsync()
        BackgroundWorker10.Dispose()
    End Sub
End Class