Imports Windows.UI.Popups

'The 'Vars.vb' file contains the public variables use in the app

Module Vars

    'The following public variables will be documented soon.

    Public AccessWhat As String = "their Amazon account"
    Public AppName As String = Package.Current.DisplayName
    Public Company As String = "Amazon, Inc."
    Public CountryName As String() = {"United Kingdom", "United States", "Australia", "Brazil", "Canada", "China", "France", "Germany", "India", "Italy", "Japan", "Mexico", "Netherlands", "Spain"}
    Public CountryURL As String() = {"co.uk", "com", "com.au", "com.br", "ca", "cn", "fr", "de", "in", "it", "co.jp", "com.mx", "nl", "es"}
    Public CountryValue As String
    Public CurrentHeight As Double
    Public CurrentWidth As Double
    Public localSettings As Windows.Storage.ApplicationDataContainer = Windows.Storage.ApplicationData.Current.LocalSettings
    Public PrivacyInfo As String = AppName & " Privacy" & vbCrLf & vbCrLf & "----------" & vbCrLf & vbCrLf & "No personal, or private, information of either you, or your device, is collected by this app." & vbCrLf & vbCrLf & "Neither is ANY information transmitted by this app."
    Public AboutInfo As String = AppName & " is a UWP app for Windows 10 Mobile to allow the user to access " & AccessWhat & " from a single portal." & vbCrLf & vbCrLf & "Small memory footprint, open source, and forever free." & vbCrLf & vbCrLf & "This app is NOT associated in ANY way with " & Company
    Public Stored_ID As Object = localSettings.Values("STORED_COUNTRY")
    Public SetFullScreen As Object = localSettings.Values("FULLSCREEN")
    Public StoredCountry As String
    Public URLBuilder As String
    Public view = ApplicationView.GetForCurrentView()

    'LoadCountries loads the list of countries into the lstCountry listbox.
    Public Function LoadCountries()
        Return CountryName
    End Function

End Module