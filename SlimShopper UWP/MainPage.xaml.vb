' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports Windows.Phone.UI.Input

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Public AppName As String = Package.Current.DisplayName
    Public view = ApplicationView.GetForCurrentView()

    Async Sub BackPressed(sender As Object, e As BackPressedEventArgs)
        'Handles any Back button presses.
        e.Handled = True
        If wv.CanGoBack Then
            wv.GoBack()
        Else
            Await displayMessageAsync(AppName, "Are you sure you want to exit the app?", "")
        End If
    End Sub

    Private Sub About_Click(sender As Object, e As RoutedEventArgs) Handles About.Click
        CloseMenu()
        ShowSettings()
    End Sub

    Private Async Sub BFS_Click(sender As Object, e As RoutedEventArgs) Handles BFS.Click
        If wv.CanGoBack Then
            wv.GoBack()
        Else
            Await displayMessageAsync(AppName, "Are you sure you want to exit the app?", "")
        End If
    End Sub

    Private Sub CloseGrid_Click(sender As Object, e As RoutedEventArgs) Handles CloseGrid.Click
        Info.Visibility = Visibility.Collapsed
    End Sub

    Private Sub CloseMenu()
        Menu.Visibility = Visibility.Collapsed
    End Sub

    Private Sub CloseSettings_Click(sender As Object, e As RoutedEventArgs) Handles CloseSettings.Click
        CountryChoice.Visibility = Visibility.Collapsed
    End Sub

    Private Sub CM_Click(sender As Object, e As RoutedEventArgs) Handles CM.Click
        Menu.Visibility = Visibility.Collapsed
    End Sub

    Private Sub lstCountry_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles lstCountry.SelectionChanged
        Dim selectedindex As Integer
        Dim selectedValue As Integer
        selectedindex = lstCountry.SelectedIndex
        If selectedindex > -1 Then
            CountryChoice.Visibility = Visibility.Collapsed
            Dim value As Object = localSettings.Values("STORED_COUNTRY")
            localSettings.Values("STORED_ID") = selectedindex
            selectedValue = localSettings.Values("STORED_COUNTRY")
            wv.Source = New Uri("https://www.amazon." & CountryURL(selectedValue) & "/")
        End If
    End Sub

    Private Async Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Menu.Visibility = Visibility.Collapsed
        Info.Visibility = Visibility.Collapsed
        Me.InitializeComponent()
        Dim statusbar = "Windows.UI.ViewManagement.StatusBar"
        If Windows.Foundation.Metadata.ApiInformation.IsTypePresent(statusbar) Then
            Await Windows.UI.ViewManagement.StatusBar.GetForCurrentView().HideAsync
        End If
        lstCountry.ItemsSource = LoadCountries()
        AddHandler HardwareButtons.BackPressed, AddressOf BackPressed
        If Stored_ID Is Nothing Then
            'localSettings.Values("STORED_ID") = "0"
            CountryChoice.Visibility = Visibility.Visible
        Else
            CountryValue = Stored_ID
        End If
        Dim value As Object = localSettings.Values("STORED_COUNTRY")
        URLBuilder = "www.amazon." & CountryURL(value)
        wv.Source = New Uri("https://www.amazon." & CountryURL(value) & "/")
        Prog_Ring.IsActive = True
    End Sub

    Private Sub More_Click(sender As Object, e As RoutedEventArgs) Handles More.Click
        If Menu.Visibility = Visibility.Collapsed Then
            Menu.Visibility = Visibility.Visible
        Else
            Menu.Visibility = Visibility.Collapsed
        End If
    End Sub

    Private Sub MyAccount_Click(sender As Object, e As RoutedEventArgs) Handles MyAccount.Click
        CloseMenu()
        Dim selectedValue As Integer
        selectedValue = localSettings.Values("STORED_ID")
        wv.Source = New Uri("https://www.amazon." & CountryURL(selectedValue) & "/gp/css/homepage.html/ref=nav_youraccount_ya")
    End Sub

    Private Sub MyOrders_Click(sender As Object, e As RoutedEventArgs) Handles MyOrders.Click
        CloseMenu()
        Dim selectedValue As Integer
        selectedValue = localSettings.Values("STORED_ID")
        wv.Source = New Uri("https://www.amazon." & CountryURL(selectedValue) & "/gp/css/order-history/ref=nav_youraccount_order")
    End Sub

    Private Sub Settings_Click(sender As Object, e As RoutedEventArgs) Handles Settings.Click
        CloseMenu()
        CountryChoice.Visibility = Visibility.Visible
    End Sub

    Private Sub ShowSettings()
        PivotSettingsAbout.SelectedIndex = 0
        Dim number As PackageVersion = Package.Current.Id.Version
        version.Text = String.Format(" {0}.{1}.{2}" & vbCrLf, number.Major, number.Minor, number.Build)
        abouttext.Text = AboutInfo
        privacy.Text = PrivacyInfo
        ScrollViewAbout.ChangeView(Nothing, 0, Nothing, True)
        ScrollViewPrivacy.ChangeView(Nothing, 0, Nothing, True)
        Info.Visibility = Visibility.Visible
    End Sub

    Private Async Sub TFS_Click(sender As Object, e As RoutedEventArgs) Handles TFS.Click
        Dim ScrollToTopString = "var int = setInterval(function(){window.scrollBy(0, -36); if( window.pageYOffset === 0 ) clearInterval(int); }, 0.0);"
        Await wv.InvokeScriptAsync("eval", New String() {ScrollToTopString})
    End Sub

    Private Sub wv_LoadCompleted(sender As Object, e As NavigationEventArgs) Handles wv.LoadCompleted
        Prog_Ring.IsActive = False
        If wv.CanGoBack Then
            XFS.Visibility = Visibility.Collapsed
            BFS.Visibility = Visibility.Visible
        Else
            XFS.Visibility = Visibility.Visible
            BFS.Visibility = Visibility.Collapsed
        End If
    End Sub

    Private Async Sub XFS_Click(sender As Object, e As RoutedEventArgs) Handles XFS.Click
        Await displayMessageAsync(AppName, "Are you sure you want to exit the app?", "")
    End Sub

End Class