Friend Class ValidationCounter
    Const FailedValidationsCountKey As String = "FailedValidationsCountKey"

    Public Shared Function GetFailedValidationsCount() As Integer

        Dim count As Integer = 0
        Dim saved As Object = HttpContext.Current.Session(FailedValidationsCountKey)
        If (Not (saved Is Nothing)) Then

            Try

                count = DirectCast(saved, Integer)

            Catch ex As InvalidCastException

                ' ignore cast errors
                count = 0
            End Try
        End If
        Return count

    End Function
    Public Shared Sub IncrementFailedValidationsCount()

        Dim count As Integer = GetFailedValidationsCount()
        count += 1
        HttpContext.Current.Session(FailedValidationsCountKey) = count
    End Sub

    Public Shared Sub ResetFailedValidationsCount()

        HttpContext.Current.Session.Remove(FailedValidationsCountKey)
    End Sub
End Class
