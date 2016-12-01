Public Class Form2
    Private stopwatch As New Stopwatch
    Private stopwatch1 As New Stopwatch
    Private Sub tmr_time_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_time.Tick
        Dim elapsed As TimeSpan = Me.stopwatch.Elapsed
        lbl_zeit.Text = String.Format("{0:00}:{1:00}:{2:00}", Math.Floor(elapsed.TotalHours), elapsed.Minutes, elapsed.Seconds)
    End Sub
    Private Sub tmr_time2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_time2.Tick
        Dim elapsed As TimeSpan = Me.stopwatch1.Elapsed
        Form1.lbl_arbeitszeit.Text = String.Format("{0:00}:{1:00}", Math.Floor(elapsed.TotalHours), elapsed.Minutes)
    End Sub
    Private Sub txt_box_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_box.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call btn_rapportieren_Click(sender, e)
        End If
    End Sub
    Private Sub btn_checkin_Click(sender As Object, e As EventArgs) Handles btn_checkin.Click
        If btn_checkin.Text = "Check in" Then
            tmr_time2.Start()
            Me.stopwatch1.Start()
            Form1.lbl_checkintime.Text = TimeOfDay.ToString("hh:mm")
            btn_checkin.Text = "Mittag"
        ElseIf btn_checkin.Text = "Mittag" Then
            tmr_time2.Stop()
            Me.stopwatch1.Stop()
            btn_checkin.Text = "Nachmittag"
            Form1.lbl_mittagtime.Text = TimeOfDay.ToString("hh:mm")
        ElseIf btn_checkin.Text = "Nachmittag" Then
            tmr_time2.Start()
            Me.stopwatch1.Start()
            btn_checkin.Text = "Check out"
            Form1.lbl_nachmittagtime.Text = TimeOfDay.ToString("hh:mm")
        ElseIf btn_checkin.Text = "Check out" Then
            tmr_time2.Stop()
            Me.stopwatch1.Stop()
            btn_checkin.Text = "Auswerten"
            Form1.lbl_checkouttime.Text = TimeOfDay.ToString("hh:mm")
        ElseIf btn_checkin.Text = "Auswerten" Then
            Me.Close()
            Form1.Show()
            Form1.Button2.Enabled = True
            Form1.Button1.Enabled = False
        End If
    End Sub
    Private Sub btn_rapportieren_Click(sender As Object, e As EventArgs) Handles btn_rapportieren.Click
        Me.stopwatch.Reset()
        Form1.txt_history.Text &= txt_box.Text & vbCrLf
        Form1.txt_historytime.Text &= lbl_zeit.Text & vbCrLf
        Global_variable.list &= lbl_zeit.Text & " | " & txt_box.Text & vbCrLf
        btn_rapportieren.Enabled = False
        txt_box.Text = ""
        lbl_zeit.BorderStyle = BorderStyle.None
    End Sub
    Private Sub lbl_zeit_Click(sender As Object, e As EventArgs) Handles lbl_zeit.Click
        If lbl_zeit.Tag = "Off" Then
            tmr_time.Start()
            Me.stopwatch.Start()
            lbl_zeit.BorderStyle = BorderStyle.Fixed3D
            lbl_zeit.Tag = "On"
        ElseIf lbl_zeit.Tag = "On" Then
            tmr_time.Stop()
            Me.stopwatch.Stop()
            lbl_zeit.BorderStyle = BorderStyle.None
            lbl_zeit.Tag = "Off"
        End If
    End Sub
    Private Sub txt_box_TextChanged(sender As Object, e As EventArgs) Handles txt_box.TextChanged
        If txt_box.Text <> "" Then
            lbl_zeit.BorderStyle = BorderStyle.Fixed3D
            btn_rapportieren.Enabled = True
            tmr_time.Start()
            Me.stopwatch.Start()
        End If
    End Sub
    Private Sub btn_help_Click(sender As Object, e As EventArgs) Handles btn_help.Click
        MessageBox.Show("Geben Sie Ihre Tärigkeit ein und die Zeit startet automatisch. Die Zeit kann durch klicken pausiert und wieder gestarten werden.

<Rapportieren>   -   Klicken Sie auf Rapportieren um die Tätigkeit zu bestätigen
<Check in>       -   Klicken Sie auf Check in um Ein/Auszustempeln
<Auswerten>      -   Sobald Sie auf Auswerten klicken, wird Ihnen alle Tätigkeiten aufgelistet", "Help",
          MessageBoxButtons.OKCancel)
    End Sub
End Class