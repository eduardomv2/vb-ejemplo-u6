Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Ej_U6
    <Serializable>
    Public Class Pelicula
        Public Property Titulo As String
        Public Property Director As String
        Public Property Anio As Integer

        Public Sub New()
        End Sub

        Public Sub New(ByVal titulo As String, ByVal director As String, ByVal anio As Integer)
            titulo = titulo
            director = director
            anio = anio
        End Sub

        Public Sub Serializar(ByVal escritor As BinaryWriter)
            escritor.Write(Titulo)
            escritor.Write(Director)
            escritor.Write(Anio)
        End Sub

        Public Sub Deserializar(ByVal lector As BinaryReader)
            Titulo = lector.ReadString()
            Director = lector.ReadString()
            Anio = lector.ReadInt32()
        End Sub

        Public Overrides Function ToString() As String
            Return $"Título: {Titulo}\nDirector: {Director}\nAño: {Anio}\n"
        End Function
    End Class
End Namespace
