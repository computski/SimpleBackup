Imports System.ComponentModel
Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'https://www.dotnetperls.com/backgroundworker-vbnet
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        txtSource.Text = GetSetting("bak2019", "general", "sourceDir", "C:\Users\v817353\Documents\FOLDER_A\")
        txtDest.Text = GetSetting("bak2019", "general", "destDir", "C:\Users\v817353\Documents\FOLDER_B\")
        txtSkipDir.Text = GetSetting("bak2019", "general", "skipDir", "bin,packages,.vs")
        txtSkipSuffix.Text = GetSetting("bak2019", "general", "skipSuffix", "zip")
        txtOlder.Text = GetSetting("bak2019", "general", "oldest", "1-Jan-17")

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ' Do some time-consuming work on this thread.
        'System.Threading.Thread.Sleep(1000)

        Dim worker As BackgroundWorker = sender

        Dim sBackupDir As String = "BAK" & Format(Now(), "yyyy-MM-dd-hhmm")
        worker.ReportProgress(0, sBackupDir & vbCrLf)

        '*** problem is the screen does not update.
        'https://stackoverflow.com/questions/9612506/textbox-text-not-updating-while-for-each-loop-running



        Dim sourceDirectory As String = txtSource.Text
        Dim targetDirectory As String = txtDest.Text & sBackupDir

        Dim diSource As DirectoryInfo = New DirectoryInfo(sourceDirectory)
        Dim diTarget As DirectoryInfo = New DirectoryInfo(targetDirectory)

        copySelected(diSource, diTarget, worker, e)

        worker.ReportProgress(1, vbCrLf & "+++ Complete +++")

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'txtReport.Text = (e.ProgressPercentage.ToString() + "%")
        txtReport.AppendText(e.UserState.ToString & vbCrLf)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If (e.Cancelled = True) Then

            txtReport.AppendText("Canceled!")

        ElseIf Not (e.Error Is Nothing) Then

            txtReport.AppendText("Error: " + e.Error.Message)

        Else
            'txtReport.Text = "Done!"
        End If

    End Sub


    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        '*** run the background process once, do not allow retriggers
        If (BackgroundWorker1.IsBusy = False) Then BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click

        If BackgroundWorker1.WorkerSupportsCancellation Then

            'Cancel the asynchronous operation.
            BackgroundWorker1.CancelAsync()
        End If
    End Sub

    Private Sub txtSkipDir_TextChanged(sender As Object, e As EventArgs) Handles txtSkipDir.TextChanged
        SaveSetting("bak2019", "general", "skipDir", txtSkipDir.Text)
    End Sub

    Private Sub txtSkipSuffix_TextChanged(sender As Object, e As EventArgs) Handles txtSkipSuffix.TextChanged
        SaveSetting("bak2019", "general", "skipSuffix", txtSkipSuffix.Text)
    End Sub

    Private Sub txtSource_TextChanged(sender As Object, e As EventArgs) Handles txtSource.TextChanged
        SaveSetting("bak2019", "general", "sourceDir", txtSource.Text)
    End Sub

    Private Sub txtDest_TextChanged(sender As Object, e As EventArgs) Handles txtDest.TextChanged
        SaveSetting("bak2019", "general", "destDir", txtDest.Text)
    End Sub


    Sub copySelected(source As DirectoryInfo, target As DirectoryInfo, sender As Object, e As DoWorkEventArgs)

        ' worker.ReportProgress(0, copySelected(diSource, diTarget))

        If (sender.CancellationPending = True) Then e.Cancel = True : Return



        'https://docs.microsoft.com/en-us/dotnet/api/system.io.directoryinfo?view=netframework-4.8
        'will copy an entire source to target including all subdirectories
        'will exclude those dirs and file types specified
        Dim exDir() As String = Split(txtSkipDir.Text.ToUpper, ",")
            Dim exFile() As String = Split(txtSkipSuffix.Text.ToUpper, ",")


            If source.FullName.ToLower() = target.FullName.ToLower() Then Return

            '*** if target dir is to be excluded then bail
            If exDir.Length > 0 Then
                If exDir.Contains(target.Name.ToUpper) Then
                    sender.ReportProgress(0, "skip dir: " & target.Name)
                End If
            End If



            ' Check if the target directory exists, if Not, create it.
            If Directory.Exists(target.FullName) = False Then
                Directory.CreateDirectory(target.FullName)
                sender.ReportProgress(0, "create dir: " & target.Name)
            End If




        ' Copy each file into it's new directory, overwrite any existing file of same name.
        For Each fi As FileInfo In source.GetFiles()
            If (sender.CancellationPending = True) Then e.Cancel = True : Return

            '***2019-08-27 exclude old files
            If DateDiff(DateInterval.Minute, CDate(txtOlder.Text), fi.LastWriteTime) > 0 Then

                If exFile.Length > 0 Then
                    '*** do not copy a file if its excluded by suffix, remember suffix will have a . as first char
                    If Not exFile.Contains(Mid(fi.Extension, 2).ToUpper) Then
                        fi.CopyTo(Path.Combine(target.ToString(), fi.Name), True)
                        sender.ReportProgress(0, "write file: " & fi.Name)
                    Else
                        sender.ReportProgress(0, "skip file: " & fi.Name)
                    End If
                Else
                    '*** no suffix filters specified
                    fi.CopyTo(Path.Combine(target.ToString(), fi.Name), True)
                    sender.ReportProgress(0, "write file: " & fi.Name)
                End If
            Else
                '*** drop old files
                sender.ReportProgress(0, "skip file (age): " & fi.Name)
            End If
        Next

        'Copy each subdirectory using recursion.
        For Each diSourceSubDir As DirectoryInfo In source.GetDirectories()

            If (sender.CancellationPending = True) Then e.Cancel = True : Return
            '*** also need to skip subdir creation here if is on the exclude list
            '*** if target dir is to be excluded then bail
            If exDir.Length > 0 Then
                    If exDir.Contains(diSourceSubDir.Name.ToUpper) Then
                        sender.ReportProgress(0, "skip dir: " & diSourceSubDir.Name)
                    Else
                        '*** DO create the subdir
                        Dim nextTargetSubDir As DirectoryInfo = target.CreateSubdirectory(diSourceSubDir.Name)
                    copySelected(diSourceSubDir, nextTargetSubDir, sender, e)
                End If
                End If



            Next

    End Sub
    Private Sub txtOlder_Click(sender As Object, e As EventArgs) Handles txtOlder.Click
        calendar1.Visible = True
        calendar1.SetDate(txtOlder.Text)
    End Sub

    Private Sub calendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles calendar1.DateSelected
        txtOlder.Text = calendar1.SelectionStart
        calendar1.Visible = False
        SaveSetting("bak2019", "general", "oldest", calendar1.SelectionStart)
    End Sub


    Private Sub calendar1_MouseLeave(sender As Object, e As EventArgs) Handles calendar1.MouseLeave
        calendar1.Visible = False
    End Sub
End Class
