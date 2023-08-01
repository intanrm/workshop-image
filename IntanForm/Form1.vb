Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openFileDialog1 As New OpenFileDialog()

        ' Set the image file filter to allow only image files
        openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim originalImage As New Bitmap(openFileDialog1.FileName)

            ' Create a new bitmap with the same dimensions as the original image
            Dim modifiedImage As New Bitmap(originalImage.Width, originalImage.Height)

            ' Define the five different colors with reduced opacity
            Dim colors() As Color = {Color.FromArgb(100, Color.Red), Color.FromArgb(100, Color.Blue), Color.FromArgb(100, Color.Green), Color.FromArgb(100, Color.Yellow), Color.FromArgb(100, Color.Purple)}

            ' Calculate the width for each color band
            Dim bandWidth As Integer = originalImage.Width \ colors.Length

            ' Draw the original image on the modified image
            Using graphics As Graphics = Graphics.FromImage(modifiedImage)
                graphics.DrawImage(originalImage, 0, 0)

                ' Draw the bands with different colors and reduced opacity on the modified image
                For i As Integer = 0 To colors.Length - 1
                    Dim startX As Integer = i * bandWidth
                    Dim endX As Integer = (i + 1) * bandWidth

                    Dim brush As New SolidBrush(colors(i))
                    graphics.FillRectangle(brush, startX, 0, endX - startX, originalImage.Height)
                Next
            End Using

            ' Display the original and modified images in the PictureBox controls
            PictureBox1.Image = originalImage
            PictureBox2.Image = modifiedImage

            ' Save the result image
            Dim savePath As String = "result.png"
            modifiedImage.Save(savePath, ImageFormat.Png)

            MsgBox("Result image saved successfully.")
        End If
    End Sub
End Class