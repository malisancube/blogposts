
Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Text

Public Class JsonConvert
    Public Shared Function Deserialize(Of T)(json As String) As T
        Dim _Bytes = Encoding.Unicode.GetBytes(json)
        Using _Stream As New MemoryStream(_Bytes)
            Dim _Serializer = New DataContractJsonSerializer(GetType(T))
            Return DirectCast(_Serializer.ReadObject(_Stream), T)
        End Using
    End Function

    Public Shared Function Serialize(instance As Object) As String
        Using _Stream As New MemoryStream()
            Dim _Serializer = New DataContractJsonSerializer(instance.[GetType]())
            _Serializer.WriteObject(_Stream, instance)
            _Stream.Position = 0
            Using _Reader As New StreamReader(_Stream)
                Return _Reader.ReadToEnd()
            End Using
        End Using
    End Function
End Class