' BY : PERMIL GARG
' TWO CLOCKS CONTROLS
' DATE : 19 OCT-20 OCT

Public Class Clock : Inherits Panel

    Dim abc As Bitmap = New Bitmap(1000, 1000, Imaging.PixelFormat.Format32bppRgb)
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private components As System.ComponentModel.IContainer
    Dim _Backcolor As Color = Color.LightCyan
    Dim _HourHand As Color = Color.Black
    Dim _MinuteHand As Color = Color.Black
    Dim _SecondHand As Color = Color.Red
    Dim _Facecolor As Color = Color.Brown
    Dim _datecolor As Color = Color.Red
    Dim fo As Font = New Font("Arial", 50)

    Public Sub New()
        Me.DoubleBuffered = True
        InitializeComponent()
    End Sub

    Private Function FindPointOnCircle(ByVal originPoint As Point, ByVal radius As Double, ByVal angleDegrees As Double) As Point
        Dim x As Double = radius * Math.Cos(Math.PI * angleDegrees / 180.0) + originPoint.X
        Dim y As Double = radius * Math.Sin(Math.PI * angleDegrees / 180.0) + originPoint.Y
        Return New Point(x, y)
    End Function

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.DrawImage(DrawClock(), 0, 0, Me.Width, Me.Height)
    End Sub

    Private Function DrawClock() As Image
        drawclockface()
        Dim degreesMinutes As Double = (System.DateTime.Now.Minute * 6) - 90.0
        Dim degreesHours As Double = (System.DateTime.Now.Hour * 30) - 90.0
        Dim degreesSeconds As Double = (System.DateTime.Now.Second * 6) - 90.0
        Dim clockimage As Bitmap = abc
        Dim g As Graphics = Graphics.FromImage(clockimage)
        Dim radius As Double = (clockimage.Width / 2) * 0.8
        Dim origin As New Point(clockimage.Width / 2, clockimage.Height / 2)
        Dim minutesPoint As Point = FindPointOnCircle(origin, radius, degreesMinutes)
        Dim hoursPoint As Point = FindPointOnCircle(origin, radius / 2, degreesHours)
        Dim secondsPoint As Point = FindPointOnCircle(origin, radius, degreesSeconds)
        Dim p As New Pen(_HourHand, 50)
        g.DrawLine(p, origin, hoursPoint)
        p.Color = _MinuteHand
        g.DrawLine(p, origin, minutesPoint)
        p.Width = 4
        p.Color = _SecondHand
        g.DrawLine(p, origin, secondsPoint)
        g.Dispose()
        Return clockimage
    End Function

    Private Sub drawclockface()
        Dim p As Pen = New Pen(_Facecolor, 10)
        Dim p2 As Pen = New Pen(_Facecolor, 20)
        Dim g As Graphics = Graphics.FromImage(abc)
        g.Clear(_Backcolor)
        g.DrawEllipse(p, 15, 15, abc.Width - 30, abc.Height - 30)
        g.DrawArc(p2, 40, 40, abc.Width - 80, abc.Width - 80, 359, 3)
        g.DrawArc(p2, 40, 40, abc.Width - 80, abc.Width - 80, 89, 3)
        g.DrawArc(p2, 40, 40, abc.Width - 80, abc.Width - 80, 179, 3)
        g.DrawArc(p2, 40, 40, abc.Width - 80, abc.Width - 80, 269, 3)
        'g.FillRectangle(Brushes.White, 62, 92, 5, 5)
        'g.FillRectangle(Brushes.White, 212, 92, 5, 5)
        'g.FillRectangle(Brushes.White, 137, 17, 5, 5)
        'g.FillRectangle(Brushes.White, 137, 167, 5, 5)
        g.DrawEllipse(Pens.White, 132, 87, 10, 10)
        g.DrawArc(p, 40, 40, abc.Width - 80, abc.Width - 80, 29, 1)
        g.DrawArc(p, 40, 40, abc.Width - 80, abc.Width - 80, 59, 1)
        g.DrawArc(p, 40, 40, abc.Width - 80, abc.Width - 80, 119, 1)
        g.DrawArc(p, 40, 40, abc.Width - 80, abc.Width - 80, 149, 1)
        g.DrawArc(p, 40, 40, abc.Width - 80, abc.Width - 80, 209, 1)
        g.DrawArc(p, 40, 40, abc.Width - 80, abc.Width - 80, 239, 1)
        g.DrawArc(p, 40, 40, abc.Width - 80, abc.Width - 80, 299, 1)
        g.DrawArc(p, 40, 40, abc.Width - 80, abc.Width - 80, 329, 1)
        Dim str As String
        Dim sf As StringFormat = New StringFormat()
        Dim b As SolidBrush = New SolidBrush(_datecolor)
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        str = month(DateTime.Now.Month) & "  " & DateTime.Now.Day
        g.DrawString(str, fo, b, 500, 300, sf)
        g.Save()
        g.Dispose()
        p.Dispose()
        p2.Dispose()
        sf.Dispose()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        Me.ResumeLayout(False)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MyBase.Refresh()
    End Sub

    Public Overrides Property backcolor As Color
        Get
            Return _Backcolor
        End Get
        Set(ByVal value As Color)
            _Backcolor = value
        End Set
    End Property

    Public Property FaceColor As Color
        Get
            Return _Facecolor
        End Get
        Set(ByVal value As Color)
            _Facecolor = value
        End Set
    End Property

    Public Property HourHandColor As Color
        Get
            Return _HourHand
        End Get
        Set(ByVal value As Color)
            _HourHand = value
        End Set
    End Property

    Public Property MinuteHandColor As Color
        Get
            Return _MinuteHand
        End Get
        Set(ByVal value As Color)
            _MinuteHand = value
        End Set
    End Property

    Public Property SecondHandColor As Color
        Get
            Return _SecondHand
        End Get
        Set(ByVal value As Color)
            _SecondHand = value
        End Set
    End Property

    Private Function month(ByVal a As Integer) As String
        Dim str As String
        Select Case a
            Case 1
                str = "January"
            Case 2
                str = "February"
            Case 3
                str = "March"
            Case 4
                str = "April"
            Case 5
                str = "May"
            Case 6
                str = "June"
            Case 7
                str = "July"
            Case 8
                str = "August"
            Case 9
                str = "September"
            Case 10
                str = "October"
            Case 11
                str = "November"
            Case 12
                str = "December"
        End Select
        Return str
    End Function

    Public Property DATEFont As Font
        Get
            Return fo
        End Get
        Set(ByVal value As Font)
            fo = value
        End Set
    End Property

    Public Property DateColor As Color
        Get
            Return _datecolor
        End Get
        Set(ByVal value As Color)
            _datecolor = value
        End Set
    End Property

End Class

Public Class AllCLOCK : Inherits Panel

    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Private components As System.ComponentModel.IContainer
    Dim abc As Bitmap = New Bitmap(1000, 1000, Imaging.PixelFormat.Format32bppRgb)
    Dim fo As Font = New Font("Arial", 50)
    Dim _Backcolor As Color = Color.Black
    Dim _outline As Color = Color.White
    Dim _HourBarColor As Color = Color.Red
    Dim _MinuteBarColor As Color = Color.Blue
    Dim _SecondBarColor As Color = Color.Green
    Dim barwidth As Integer = 150
    Dim radius As Integer = abc.Width - barwidth
    Dim offset As Integer = abc.Width - radius

    Public Sub New()
        Me.DoubleBuffered = True
        InitializeComponent()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.DrawImage(DrawClock(), 0, 0, Me.Width, Me.Height)
    End Sub

    Private Function DrawClock() As Image
        Dim tmp As Integer = offset
        Dim tmp2 As Integer = radius
        Dim sf As StringFormat = New StringFormat()
        Dim BackBrush As SolidBrush = New SolidBrush(_Backcolor)
        Dim HourBrush As SolidBrush = New SolidBrush(_HourBarColor)
        Dim MinuteBrush As SolidBrush = New SolidBrush(_MinuteBarColor)
        Dim SecondBrush As SolidBrush = New SolidBrush(_SecondBarColor)
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        Dim g As Graphics = Graphics.FromImage(abc)
        Dim p As Pen = New Pen(_outline, 4)
        g.Clear(_Backcolor)
        tmp /= 2
        g.FillPie(BackBrush, tmp, tmp, tmp2, tmp2, 270, 360)
        g.FillPie(HourBrush, tmp, tmp, tmp2, tmp2, 270, degree(0))
        g.DrawEllipse(p, tmp, tmp, tmp2, tmp2)
        tmp = offset + barwidth
        tmp /= 2
        tmp2 -= barwidth
        g.FillPie(BackBrush, tmp, tmp, tmp2, tmp2, 270, 360)
        g.FillPie(MinuteBrush, tmp, tmp, tmp2, tmp2, 270, degree(1))
        g.DrawEllipse(p, tmp, tmp, tmp2, tmp2)
        tmp = offset + (2 * barwidth)
        tmp /= 2
        tmp2 -= barwidth
        g.FillPie(BackBrush, tmp, tmp, tmp2, tmp2, 270, 360)
        g.FillPie(SecondBrush, tmp, tmp, tmp2, tmp2, 270, degree(2))
        g.DrawEllipse(p, tmp, tmp, tmp2, tmp2)
        'g.FillPie(_backcolor, 200, 200, 600, 600, 270, 360)
        tmp = offset + (3 * barwidth)
        tmp /= 2
        tmp2 -= barwidth
        g.FillEllipse(BackBrush, tmp, tmp, tmp2, tmp2)
        g.DrawEllipse(p, tmp, tmp, tmp2, tmp2)
        Dim str As String = DateTime.Now.Hour & " : " & DateTime.Now.Minute & " : " & DateTime.Now.Second
        g.DrawString(str, fo, Brushes.Red, 500, 530, sf)
        str = month(DateTime.Now.Month) & "  " & DateTime.Now.Day
        g.DrawString(str, fo, Brushes.Red, 500, 450, sf)
        g.Save()
        g.Dispose()
        p.Dispose()
        SecondBrush.Dispose()
        MinuteBrush.Dispose()
        HourBrush.Dispose()
        BackBrush.Dispose()
        sf.Dispose()
        Return abc
    End Function

    Private Function degree(ByVal a As Integer) As Integer
        Dim rv As Integer
        Select Case a
            Case 0
                rv = System.DateTime.Now.Hour
                rv *= 360
                rv = Convert.ToInt32(rv / 24)
            Case 1
                rv = System.DateTime.Now.Minute
                rv *= 360
                rv = Convert.ToInt32(rv / 60)
            Case 2
                rv = System.DateTime.Now.Second
                rv *= 360
                rv = Convert.ToInt32(rv / 60)
        End Select
        Return rv
    End Function

    Private Function month(ByVal a As Integer) As String
        Dim str As String
        Select Case a
            Case 1
                str = "January"
            Case 2
                str = "February"
            Case 3
                str = "March"
            Case 4
                str = "April"
            Case 5
                str = "May"
            Case 6
                str = "June"
            Case 7
                str = "July"
            Case 8
                str = "August"
            Case 9
                str = "September"
            Case 10
                str = "October"
            Case 11
                str = "November"
            Case 12
                str = "December"
        End Select
        Return str
    End Function

    Public Property Bar_Width As Integer
        Get
            Return barwidth
        End Get
        Set(ByVal value As Integer)
            barwidth = value
        End Set
    End Property

    Public Property HourBarColor As Color
        Get
            Return _HourBarColor
        End Get
        Set(ByVal value As Color)
            _HourBarColor = value
        End Set
    End Property

    Public Property MinuteBarColor As Color
        Get
            Return _MinuteBarColor
        End Get
        Set(ByVal value As Color)
            _MinuteBarColor = value
        End Set
    End Property

    Public Property SecondBarColor As Color
        Get
            Return _SecondBarColor
        End Get
        Set(ByVal value As Color)
            _SecondBarColor = value
        End Set
    End Property

    Public Overrides Property Backcolor As Color
        Get
            Return _Backcolor
        End Get
        Set(ByVal value As Color)
            _Backcolor = value
        End Set
    End Property

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 500
        Me.ResumeLayout(False)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.Refresh()
    End Sub

    Public Property TimeFont As Font
        Get
            Return fo
        End Get
        Set(ByVal value As Font)
            fo = value
        End Set
    End Property

End Class