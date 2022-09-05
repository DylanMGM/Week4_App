Imports System.Windows.Threading
Class MainWindow

    Dim itemsList As New List(Of String)
    Dim health As Integer = 0
    Dim dtHealth As New DispatcherTimer

    Sub New()

        InitializeComponent()
        dtHealth.Interval = TimeSpan.FromTicks(1)
        AddHandler dtHealth.Tick, AddressOf GameLoop

    End Sub

    Private Sub GameLoop()

        pbHealth.Value += 0.01
        If pbHealth.Value > 100 Then
            pbHealth.Value = 100
            'dtHealth.Stop()
        End If

    End Sub

    Private Sub btnA_Click(sender As Object, e As RoutedEventArgs) Handles btnA.Click

        'health = 50
        AddItem("Use Health Pack")
        pbHealth.Value = health
        dtHealth.Start()

    End Sub

    Private Sub btnB_Click(sender As Object, e As RoutedEventArgs) Handles btnB.Click

        'health = 25
        RemoveItem("Discard Health Pack")

    End Sub

    Private Sub AddItem(itemToAdd As String)

        itemsList.Add(itemToAdd)
        lstItems.Items.Clear()

        For Each item In itemsList
            lstItems.Items.Add(item)
        Next

        lblMessage.Content = "You have used " + itemsList.Count.ToString + " health packs!"

    End Sub

    Private Sub RemoveItem(itemToRemove As String)

        itemsList.Remove(itemToRemove)

        For Each item In itemsList
            lstItems.Items.Remove(item)
        Next

        lblMessage.Content = "You have discarded " + itemsList.Count.ToString + " empty health packs!"

    End Sub

    Private Sub lstItems_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles lstItems.SelectionChanged

        Dim lbiContent As String = sender.SelectedItem

        lblMessage.Content = lbiContent

    End Sub

End Class
