
Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
            BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception
            MsgBox("There was a problem occured" & vbNewLine & "Details : " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        About.ShowDialog(Me)
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90)) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox2.Enabled = True
            GroupBox1.Enabled = True
        Else
            CheckBox2.Checked = False
            CheckBox2.Enabled = False
            GroupBox1.Enabled = False
        End If
    End Sub
    Dim processa As New Process()
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Button1.Enabled = False
            TextBox1.ReadOnly = True
            RichTextBox1.Text = ""
            processa = New Process
            processa.StartInfo.UseShellExecute = False
            processa.StartInfo.RedirectStandardOutput = True
            processa.StartInfo.RedirectStandardError = True
            processa.StartInfo.CreateNoWindow = True
            ProgressBar1.Value = 10

            If CheckBox1.Checked = True Then
                If TextBox1.Text <> "" Then
                    StopToolStripMenuItem.Enabled = True
                    processa.StartInfo.FileName = "CMD.exe"
                    processa.StartInfo.Arguments = "/C attrib -s -h -r /s /d " & TextBox1.Text & ":\*.*"
                    processa.Start()
                    StopToolStripMenuItem.Enabled = False
                    ProgressBar1.Value = 20
                    RichTextBox1.Text &= "Changing attributes ..." & vbNewLine
                    processa.WaitForExit()
                    processa.StartInfo.Arguments = "/C del " & TextBox1.Text & ":\*.vbs /f /q"
                    processa.Start()
                    ProgressBar1.Value = 30
                    RichTextBox1.Text &= "Deleting vbs files : " & processa.StandardError.ReadToEnd() & vbNewLine
                    processa.WaitForExit()
                    processa.StartInfo.Arguments = "/C del " & TextBox1.Text & ":\*.lnk /f /q"
                    processa.Start()
                    ProgressBar1.Value = 40
                    RichTextBox1.Text &= "Deleting lnk files : " & processa.StandardError.ReadToEnd() & vbNewLine
                    processa.WaitForExit()
                    If CheckBox2.Checked = True Then
                        GoTo B
                    End If
                Else
                    MsgBox("Please type the letter of your infected removable disk", MsgBoxStyle.Exclamation)
                    GoTo B
                End If
            End If

            processa.StartInfo.FileName = "taskkill.exe"
            processa.StartInfo.Arguments = "/F /IM wscript.exe"
            processa.Start()
            processa.StartInfo.FileName = "taskkill.exe"
            processa.StartInfo.Arguments = "/F /IM IEMonitor.exe"
            processa.Start()
            ProgressBar1.Value = 40
            RichTextBox1.Text &= "Wscript Tasking Kill : " & processa.StandardOutput.ReadToEnd() & vbNewLine & processa.StandardError.ReadToEnd() & vbNewLine
            processa.WaitForExit()
            processa.StartInfo.FileName = "reg"
            processa.StartInfo.Arguments = "delete hklm\software\microsoft\windows\currentversion\run /v ""Fantasy Premier League"" /f"
            processa.Start()
            ProgressBar1.Value = 45
            RichTextBox1.Text &= "Deleting from HKLM : " & processa.StandardOutput.ReadToEnd() & vbNewLine & processa.StandardError.ReadToEnd() & vbNewLine
            processa.StartInfo.Arguments = "delete hklm\software\microsoft\windows\currentversion\run /v ""tmxnftcqgr"" /f"
            processa.Start()
            ProgressBar1.Value = 50
            RichTextBox1.Text &= "Deleting from HKLM : " & processa.StandardOutput.ReadToEnd() & vbNewLine & processa.StandardError.ReadToEnd() & vbNewLine
            processa.WaitForExit()
            processa.StartInfo.Arguments = "delete hkcu\software\microsoft\windows\currentversion\run /v ""Fantasy Premier League"" /f"
            processa.Start()
            ProgressBar1.Value = 55
            RichTextBox1.Text &= "Deleting from HKLM : " & processa.StandardOutput.ReadToEnd() & vbNewLine & processa.StandardError.ReadToEnd() & vbNewLine
            processa.WaitForExit()
            processa.StartInfo.Arguments = "delete hkcu\software\microsoft\windows\currentversion\run /v ""IEMonitor.exe"" /f"
            processa.Start()
            ProgressBar1.Value = 60
            RichTextBox1.Text &= "Deleting from HKCU : " & processa.StandardOutput.ReadToEnd() & vbNewLine & processa.StandardError.ReadToEnd() & vbNewLine
            processa.WaitForExit()
            processa.StartInfo.Arguments = "delete hkcu\software\microsoft\windows\currentversion\run /v ""tmxnftcqgr"" /f"
            processa.Start()
            ProgressBar1.Value = 65
            RichTextBox1.Text &= "Deleting from HKCU : " & processa.StandardOutput.ReadToEnd() & vbNewLine & processa.StandardError.ReadToEnd() & vbNewLine
            processa.WaitForExit()
            processa.StartInfo.Arguments = "delete hkcu\software\microsoft\windows\currentversion\run /v ""IEMonitor.exe"" /f"
            processa.Start()
            ProgressBar1.Value = 70
            RichTextBox1.Text &= "Deleting from HKCU : " & processa.StandardOutput.ReadToEnd() & vbNewLine & processa.StandardError.ReadToEnd() & vbNewLine
            processa.WaitForExit()
            processa.StartInfo.FileName = "CMD.exe"
            processa.StartInfo.Arguments = "/C del """ & My.Computer.FileSystem.SpecialDirectories.Temp & "\*.vbs"" /f /q"
            processa.Start()
            ProgressBar1.Value = 75
            RichTextBox1.Text &= "Deleting from " & My.Computer.FileSystem.SpecialDirectories.Temp & " " & vbNewLine & processa.StandardError.ReadToEnd() & vbNewLine
            processa.WaitForExit()
            processa.StartInfo.Arguments = "/C del """ & Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\*.vbs"" /f /q"
            processa.Start()
            RichTextBox1.Text &= "Deleting from " & My.Computer.FileSystem.SpecialDirectories.Temp & " " & vbNewLine & processa.StandardError.ReadToEnd() & vbNewLine
            processa.WaitForExit()
            processa.StartInfo.Arguments = "/C del """ & Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\IEMonitor.exe"" /f /q"
            processa.Start()
            ProgressBar1.Value = 85
            RichTextBox1.Text &= "Deleting from " & Environment.GetFolderPath(Environment.SpecialFolder.Startup) & " " & vbNewLine & processa.StandardError.ReadToEnd() & vbNewLine
            processa.WaitForExit()
            processa.StartInfo.Arguments = "/C del """ & Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\*.vbs"" /f /q"
            processa.Start()
            RichTextBox1.Text &= "Deleting from " & Environment.GetFolderPath(Environment.SpecialFolder.Startup) & " " & vbNewLine & processa.StandardError.ReadToEnd() & vbNewLine
            processa.WaitForExit()
            processa.StartInfo.Arguments = "/C del """ & Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\IEMonitor.exe"" /f /q"
            processa.Start()
            ProgressBar1.Value = 90
            RichTextBox1.Text &= "Deleting from " & Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & " " & vbNewLine & processa.StandardError.ReadToEnd() & vbNewLine
            processa.WaitForExit()
B:
            ProgressBar1.Value = 100
            Button1.Enabled = True
            TextBox1.ReadOnly = False
            MsgBox("Erasing virus was successfully done, mentioning error doesn't mean that the virus hasn't been removed.", MsgBoxStyle.Information, "Done")
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = True

        Catch ex As Exception
            MsgBox("There was a problem occured" & vbNewLine & "Details : " & ex.Message, MsgBoxStyle.Critical)
            Button1.Enabled = True
            TextBox1.ReadOnly = False
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
            StopToolStripMenuItem.Enabled = False

        End Try
    End Sub

    Private Sub StopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem.Click
        Try
            BackgroundWorker1.CancelAsync()
            processa.Kill()
            processa.StartInfo.FileName = "taskkill.exe"
            processa.StartInfo.Arguments = "/F /IM attrib.exe"
            processa.Start()
            Button1.Enabled = True
            TextBox1.ReadOnly = False
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
            StopToolStripMenuItem.Enabled = False
        Catch ex As Exception
            Button1.Enabled = True
            TextBox1.ReadOnly = False
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
            StopToolStripMenuItem.Enabled = False
            MsgBox("There was a problem occured" & vbNewLine & "Details : " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            BackgroundWorker1.CancelAsync()
            processa.Kill()
            processa.StartInfo.FileName = "taskkill.exe"
            processa.StartInfo.Arguments = "/F /IM attrib.exe"
            processa.Start()
        Catch ex As Exception
            End
        End Try
    End Sub
End Class
