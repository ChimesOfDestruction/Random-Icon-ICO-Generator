Imports System.IO
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = AppDomain.CurrentDomain.BaseDirectory & "\Icons\" & Path.GetRandomFileName & ".ico"
        ComboBox1.SelectedItem = "48x48"
        Dim YourPath = AppDomain.CurrentDomain.BaseDirectory & "\Icons\"

        If Not System.IO.Directory.Exists(YourPath) Then
            System.IO.Directory.CreateDirectory(YourPath)
        End If



    End Sub
    Public Function generateicon() As String
        Dim tamaño As String
        If ComboBox1.Text = "32x32" Then
            tamaño = "33"
        End If
        If ComboBox1.Text = "48x48" Then
            tamaño = "49"
        End If
        If ComboBox1.Text = "52x52" Then
            tamaño = "53"
        End If
        If ComboBox1.Text = "64x64" Then
            tamaño = "64"
        End If
        Dim ancho As Integer = tamaño
        Dim alto As Integer = tamaño
        Dim bmp As New Bitmap(ancho, alto)
        Dim rand As Random = New Random()
        For y As Integer = 0 To alto - 1
            For x As Integer = 0 To ancho - 1
                '   Dim a As Integer = rand.Next(256)
                Dim a As Integer = 255
                Dim r As Integer = rand.Next(NumericUpDown4.Value)
                Dim g As Integer = rand.Next(NumericUpDown6.Value)
                Dim b As Integer = rand.Next(NumericUpDown8.Value)
                bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b))
            Next
        Next
        Dim HIcon As IntPtr = bmp.GetHicon()
        Dim nuevoicono As Icon = Icon.FromHandle(HIcon)

        ' Dim rutafinal As String = Path.GetTempPath() + "iconorandom.ico"
        Dim rutafinal As String = TextBox1.Text
        Dim oFileStream As FileStream = New IO.FileStream(rutafinal, FileMode.CreateNew)
        nuevoicono.Save(oFileStream)
        oFileStream.Close()
        Return rutafinal
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Randomize()

        Timer5.Start()
        Timer1.Start()
        Timer2.Start()
        Timer3.Start()
        Timer4.Start()






    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Randomize()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        NumericUpDown4.Value = GetRandom(1, 256)
        NumericUpDown6.Value = GetRandom(1, 256)
        NumericUpDown8.Value = GetRandom(1, 256)
        Randomize()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        '  NumericUpDown6.Value = GetRandom(1, 256)
        Randomize()
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        '  NumericUpDown8.Value = GetRandom(1, 256)
        Randomize()
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        Timer1.Stop()
        Timer2.Stop()
        Timer3.Stop()
        Timer4.Stop()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub HuraButton1_Click(sender As Object, e As EventArgs) Handles HuraButton1.Click
        Application.Exit()
    End Sub

    Private Sub HuraButton2_Click(sender As Object, e As EventArgs) Handles HuraButton2.Click

        Dim rutaicono As String = TextBox1.Text
        Dim tamaño As String
        If ComboBox1.Text = "32x32" Then
            tamaño = "33"
        End If
        If ComboBox1.Text = "48x48" Then
            tamaño = "49"
        End If
        If ComboBox1.Text = "52x52" Then
            tamaño = "53"
        End If
        If ComboBox1.Text = "64x64" Then
            tamaño = "64"
        End If
        If File.Exists(rutaicono) Then
            File.Delete(rutaicono)
            Call generateicon()

        Else
            Call generateicon()
            TextBox1.Text = AppDomain.CurrentDomain.BaseDirectory & "\Icons\" & Path.GetRandomFileName & ".ico"
        End If

    End Sub

    Private Sub HuraCheckBox1_CheckedChanged(sender As Object) Handles HuraCheckBox1.CheckedChanged
        If HuraCheckBox1.Checked = True Then
            Timer2.Start()
        Else
            Timer2.Stop()
        End If
    End Sub
End Class
