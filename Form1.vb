Public Class Form1
    Dim file As System.IO.StreamWriter
    Dim taetigkeit As String
    Dim Zeit As String
    Dim row As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Form2.TopMost = True
        Form2.Location = New Point(945, 718)
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        file = My.Computer.FileSystem.OpenTextFileWriter("H:\Rapport.txt", True)
        file.WriteLine("Rapport " & DateTime.Now.ToString("dd/MM/yyyy") & vbCrLf & "==================" & vbCrLf &
                       "Arbeitszeit: " & "(" & lbl_arbeitszeit.Text & ") " & vbCrLf & lbl_checkintime.Text & " - " & lbl_mittagtime.Text & "   " & lbl_nachmittagtime.Text & " - " & lbl_checkouttime.Text & vbCrLf & vbCrLf &
                       "Taetigkeiten: " & vbCrLf & Global_variable.list)
        file.Close()
        Me.Close()
    End Sub
End Class