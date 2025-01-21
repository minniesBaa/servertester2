Imports System.Drawing
Imports System.Net.NetworkInformation
Imports System.Windows.Forms

Public Class tester

    Private Shared notifyIcon As NotifyIcon

    Public Shared Function IsServerOnline(ByVal serverName As String) As Boolean
        Dim arg As String
        arg = flag.getarg()
        Try
            Dim ping As New Ping
            Dim reply As PingReply = ping.Send(serverName)



            If reply.Status = IPStatus.Success Then
                If arg = "-showOn" Then
                    ShowToastNotification("Server Info", "The server is on.")
                End If

                Return True
            Else
                ShowToastNotification("Server Offline", "The server is offline.")
                Return False
            End If

        Catch ex As Exception
            ShowToastNotification("Server Error", "Error pinging server: " & ex.Message)
            Return False
        End Try
    End Function

    Public Shared Sub Main()

        notifyIcon = New NotifyIcon()
        notifyIcon.Icon = SystemIcons.Application
        notifyIcon.Visible = True



        Dim server As String = "server.ip.adress.here"
        IsServerOnline(server)



    End Sub

    Private Shared Sub ShowToastNotification(ByVal title As String, ByVal message As String)
        notifyIcon.BalloonTipTitle = title
        notifyIcon.BalloonTipText = message
        notifyIcon.ShowBalloonTip(5000) ' Show for 5 seconds
    End Sub
End Class