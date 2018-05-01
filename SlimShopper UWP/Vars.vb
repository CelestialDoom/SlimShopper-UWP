Imports Windows.UI.Popups

'The 'Vars.vb' file contains the public variables use in the app

Module Vars
    Public AccessWhat As String = "their Amazon account"
    Public Company As String = "Amazon, Inc."

    Public AboutInfo As String = AppName & " is a UWP app for Windows 10 Mobile to allow the user to access " & AccessWhat & " from a single portal." & vbCrLf & vbCrLf & "Small memory footprint, open source, and forever free." & vbCrLf & vbCrLf & "This app is NOT associated in ANY way with " & Company
    Public AppName As String = Package.Current.DisplayName
    Public CountryName As String() = {"United Kingdom", "United States", "Australia", "Brazil", "Canada", "China", "France", "Germany", "India", "Italy", "Japan", "Mexico", "Netherlands", "Spain"}
    Public CountryURL As String() = {"co.uk", "com", "com.au", "com.br", "ca", "cn", "fr", "de", "in", "it", "co.jp", "com.mx", "nl", "es"}
    Public CountryValue As String
    Public CurrentHeight As Double
    Public CurrentWidth As Double
    Public localSettings As Windows.Storage.ApplicationDataContainer = Windows.Storage.ApplicationData.Current.LocalSettings
    Public PrivacyInfo As String = AppName & " Privacy" & vbCrLf & vbCrLf & "----------" & vbCrLf & vbCrLf & "No personal, or private, information of either you, or your device, is collected by this app." & vbCrLf & vbCrLf & "Neither is ANY information transmitted by this app."
    Public Stored_ID As Object = localSettings.Values("STORED_COUNTRY")
    Public StoredCountry As String
    Public URLBuilder As String
    Public view = ApplicationView.GetForCurrentView()

    Public Async Function displayMessageAsync(ByVal title As String, ByVal content As String, ByVal dialogType As String) As Task
        Dim messageDialog = New MessageDialog(content, title)
        If dialogType = "notification" Then
        Else
            messageDialog.Commands.Add(New UICommand("Yes", Nothing))
            messageDialog.Commands.Add(New UICommand("No", Nothing))
            messageDialog.DefaultCommandIndex = 0
        End If
        messageDialog.CancelCommandIndex = 1
        Dim cmdResult = Await messageDialog.ShowAsync()
        If cmdResult.Label = "Yes" Then
            Application.Current.Exit()
        End If
    End Function

    Public Function LoadCountries()
        Return CountryName
    End Function

    Public Async Sub SimpleMessageDialog(ByVal message As String, ByVal header As String)
        Dim dialog = New MessageDialog(header, message)
        Await dialog.ShowAsync()
    End Sub

End Module