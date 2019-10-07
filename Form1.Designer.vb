<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.txtReport = New System.Windows.Forms.TextBox()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.txtDest = New System.Windows.Forms.TextBox()
        Me.txtSkipDir = New System.Windows.Forms.TextBox()
        Me.txtSkipSuffix = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOlder = New System.Windows.Forms.TextBox()
        Me.calendar1 = New System.Windows.Forms.MonthCalendar()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(399, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This app will copy all source content to destination under a date-stamped sub-fol" &
    "der"
        '
        'BackgroundWorker1
        '
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(693, 244)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Run backup"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(693, 275)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 2
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'txtReport
        '
        Me.txtReport.Location = New System.Drawing.Point(34, 246)
        Me.txtReport.Multiline = True
        Me.txtReport.Name = "txtReport"
        Me.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReport.Size = New System.Drawing.Size(639, 285)
        Me.txtReport.TabIndex = 3
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(34, 169)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(734, 20)
        Me.txtSource.TabIndex = 4
        '
        'txtDest
        '
        Me.txtDest.Location = New System.Drawing.Point(34, 208)
        Me.txtDest.Name = "txtDest"
        Me.txtDest.Size = New System.Drawing.Size(734, 20)
        Me.txtDest.TabIndex = 5
        '
        'txtSkipDir
        '
        Me.txtSkipDir.Location = New System.Drawing.Point(34, 49)
        Me.txtSkipDir.Name = "txtSkipDir"
        Me.txtSkipDir.Size = New System.Drawing.Size(734, 20)
        Me.txtSkipDir.TabIndex = 6
        '
        'txtSkipSuffix
        '
        Me.txtSkipSuffix.Location = New System.Drawing.Point(34, 87)
        Me.txtSkipSuffix.Name = "txtSkipSuffix"
        Me.txtSkipSuffix.Size = New System.Drawing.Size(734, 20)
        Me.txtSkipSuffix.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Exclude these diretories (comma separator)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(189, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Exclude file suffixes (comma separator)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Source path (with trailing \)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Destination path (with trailing \)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Exclude files older than"
        '
        'txtOlder
        '
        Me.txtOlder.Location = New System.Drawing.Point(34, 127)
        Me.txtOlder.Name = "txtOlder"
        Me.txtOlder.Size = New System.Drawing.Size(252, 20)
        Me.txtOlder.TabIndex = 13
        '
        'calendar1
        '
        Me.calendar1.Location = New System.Drawing.Point(298, 127)
        Me.calendar1.Name = "calendar1"
        Me.calendar1.TabIndex = 14
        Me.calendar1.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 543)
        Me.Controls.Add(Me.calendar1)
        Me.Controls.Add(Me.txtOlder)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSkipSuffix)
        Me.Controls.Add(Me.txtSkipDir)
        Me.Controls.Add(Me.txtDest)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.txtReport)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Backup 2019"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnStart As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents txtReport As TextBox
    Friend WithEvents txtSource As TextBox
    Friend WithEvents txtDest As TextBox
    Friend WithEvents txtSkipDir As TextBox
    Friend WithEvents txtSkipSuffix As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtOlder As TextBox
    Friend WithEvents calendar1 As MonthCalendar
End Class
