Imports System.Net.Http

Public NotInheritable Class MainServer
    Private ReadOnly _client As New HttpClient
    Public Const BaseAddress = "http://localhost:9000/"
    Private Shared ReadOnly _instance As New Lazy(Of MainServer)(Function() New MainServer(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication)

    Private Sub New()

    End Sub

    Public Shared ReadOnly Property Instance() As MainServer
        Get
            Return _instance.Value
        End Get
    End Property

    Public ReadOnly Property Client() As HttpClient
        Get
            Return _client
        End Get
    End Property

End Class
