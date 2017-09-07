Imports System.Net.Http
Imports Dinosaur.Model

Public Class FormPerson
    ReadOnly _client As HttpClient = MainServer.Instance.Client()
    ReadOnly _countries = _client.GetAsync(MainServer.BaseAddress + "api/country").Result()

    Private Sub FormPerson_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()
        cboCountry.DataSource = JsonConvert.Deserialize(Of List(Of Country))(_countries.Content.ReadAsStringAsync().Result)
        cboCountry.DisplayMember = "Name"
        cboCountry.ValueMember = "Id"
        cboCountry.SelectedIndex = -1
    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim person As New Person
            person.FirstName = txtFirstName.Text
            person.LastName = txtLastName.Text
            person.Country = cboCountry.SelectedItem
            Await _client.PostAsJsonAsync(MainServer.BaseAddress + "api/person", person).ContinueWith(Function(postTask) postTask.Result.EnsureSuccessStatusCode())
            RefreshGrid()

            txtFirstName.Clear()
            txtLastName.Clear()
            cboCountry.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        RefreshGrid()
    End Sub

    Private Sub RefreshGrid()
        Dim _ppl = _client.GetAsync(MainServer.BaseAddress + "api/person").Result()
        PersonBindingSource.DataSource = JsonConvert.Deserialize(Of List(Of Person))(_ppl.Content.ReadAsStringAsync().Result)
    End Sub
End Class
