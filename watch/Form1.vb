' BY PERMIL GARG
' DIFF TYPE OF CLOCKS
' DATE : 19 OCT - 20 OCT

Public Class Form1

    Private abc As Bitmap = New Bitmap(1000, 1000)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolStripStatusLabel1.Text = System.DateTime.Now
        Timer1.Enabled = True
        Digital()
        progess()
        'AllCLOCK1.BackColor = Color.Orange
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = System.DateTime.Now
        Select Case TabControl1.SelectedIndex
            Case 0
                Digital()
            Case 1
                progess()
        End Select
    End Sub

    Private Sub Digital()
        Label4.Text = System.DateTime.Now.Hour
        Label5.Text = System.DateTime.Now.Minute
        Label6.Text = System.DateTime.Now.Second
        If Label8.Visible = True And Label9.Visible = True Then
            Label8.Visible = False
            Label9.Visible = False
        Else
            Label8.Visible = True
            Label9.Visible = True
        End If
    End Sub
    Private Sub progess()
        ProgressBar1.Value = System.DateTime.Now.Hour
        ProgressBar2.Value = System.DateTime.Now.Minute
        ProgressBar3.Value = System.DateTime.Now.Second
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Threading.Thread.Sleep(2000)
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        TabControl1.Width = Me.Width - 40
        TabControl1.Height = Me.Height - 73
        Panel1.Top = Convert.ToInt32((TabControl1.Height - Panel1.Height) / 2)
        Panel1.Left = Convert.ToInt32((TabControl1.Width - Panel1.Width) / 2)
        Panel2.Top = Convert.ToInt32((TabControl1.Height - Panel2.Height) / 2)
        Panel2.Left = Convert.ToInt32((TabControl1.Width - Panel2.Width) / 2)
    End Sub
End Class
