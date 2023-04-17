Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Namespace Ej_U6
    Partial Public Class Form1
        Inherits Form

        Private Const FILENAME As String = "peliculas.dat"

        Private Sub InitializeComponent()
            Me.label4 = New System.Windows.Forms.Label()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.TextBox2 = New System.Windows.Forms.TextBox()
            Me.TextBox3 = New System.Windows.Forms.TextBox()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'label4
            '
            Me.label4.Font = New System.Drawing.Font("MS Reference Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label4.Location = New System.Drawing.Point(137, 60)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(624, 29)
            Me.label4.TabIndex = 9
            Me.label4.Text = "Escribe el Nombre de la Pelicula, su Director y Su Año de Estreno"
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(259, 163)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(316, 20)
            Me.TextBox1.TabIndex = 10
            '
            'TextBox2
            '
            Me.TextBox2.Location = New System.Drawing.Point(259, 217)
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Size = New System.Drawing.Size(316, 20)
            Me.TextBox2.TabIndex = 11
            '
            'TextBox3
            '
            Me.TextBox3.Location = New System.Drawing.Point(259, 284)
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.Size = New System.Drawing.Size(316, 20)
            Me.TextBox3.TabIndex = 12
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(623, 163)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(102, 60)
            Me.Button1.TabIndex = 13
            Me.Button1.Text = "Guardar"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(623, 242)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(102, 62)
            Me.Button2.TabIndex = 14
            Me.Button2.Text = "Mostrar"
            Me.Button2.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(121, 170)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(44, 13)
            Me.Label1.TabIndex = 15
            Me.Label1.Text = "Pelicula"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(121, 220)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(44, 13)
            Me.Label2.TabIndex = 16
            Me.Label2.Text = "Director"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(121, 287)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(26, 13)
            Me.Label3.TabIndex = 17
            Me.Label3.Text = "Año"
            '
            'Form1
            '
            Me.ClientSize = New System.Drawing.Size(1031, 646)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.Button2)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.TextBox3)
            Me.Controls.Add(Me.TextBox2)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.label4)
            Me.Name = "Form1"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Private WithEvents label4 As Label
        Friend WithEvents TextBox1 As Windows.Forms.TextBox
        Friend WithEvents TextBox2 As Windows.Forms.TextBox
        Friend WithEvents TextBox3 As Windows.Forms.TextBox
        Friend WithEvents Button1 As Windows.Forms.Button
        Friend WithEvents Button2 As Windows.Forms.Button
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents Label3 As Label

        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        End Sub

        Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
            Try
                Dim pelicula As Pelicula = New Pelicula(TextBox1.Text, TextBox2.Text, Integer.Parse(TextBox3.Text))
                Using archivo As FileStream = New FileStream(FILENAME, FileMode.Append, FileAccess.Write)
                    Dim escritor As BinaryWriter = New BinaryWriter(archivo)
                    pelicula.Serializar(escritor)
                End Using

                MessageBox.Show("La película ha sido guardada correctamente.")
            Catch __unusedFormatException1__ As FormatException
                MessageBox.Show("El año ingresado no es un número válido.")
            Catch ex As Exception
                MessageBox.Show("Se produjo un error al intentar guardar la película: " & ex.Message)
            End Try
        End Sub

        Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
            Try

                Using archivo As FileStream = New FileStream(FILENAME, FileMode.Open, FileAccess.Read)
                    Dim lector As BinaryReader = New BinaryReader(archivo)

                    While archivo.Position < archivo.Length
                        Dim pelicula As Pelicula = New Pelicula()
                        pelicula.Deserializar(lector)
                        MessageBox.Show(pelicula.ToString())
                    End While
                End Using

            Catch __unusedFileNotFoundException1__ As FileNotFoundException
                MessageBox.Show("No se encontró el archivo de películas.")
            Catch ex As Exception
                MessageBox.Show("Se produjo un error al intentar leer el archivo de películas: " & ex.Message)
            End Try
        End Sub
    End Class
End Namespace