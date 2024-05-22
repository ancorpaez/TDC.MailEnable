Imports System.Windows.Forms

Namespace LOG
    Public Module MemoryLOG
        'Almacena Diferentes Logs y sus Salidas en Pantalla
        'Visualiza las lineas del Log en Memoria en un RichTextBox
        'Tiene AutoAjuste hasta 30 Segundos 
        Private WithEvents Recuperador As New Bucle.DoBucle("iFaceMemoryLogLine") With {.Intervalo = 100}
        Public Enum EnumLogs
            General
            CrossDomain
        End Enum
        Public Logs As New Collections.Concurrent.ConcurrentDictionary(Of EnumLogs, LogConfig)

        Public Sub Main()
            For Each Config In Logs
                If IsNothing(Config.Value.Salida) Then Throw New Exception($"La salida no está definida de {Config.Key.ToString}.")
            Next
            Recuperador.Iniciar()
        End Sub

        Private Sub Recuperador_Background(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles Recuperador.BackGround
            For Each Visionar In Logs
                Visionar.Value.Lineas.TryDequeue(Visionar.Value.Linea)
            Next
        End Sub

        Private Sub Recuperador_Foreground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles Recuperador.ForeGround
            Dim esLog As Boolean = False
            For Each Visionar In Logs.Values
                If Not String.IsNullOrEmpty(Visionar.Linea) Then
                    esLog = True
                    If Not Visionar.Salida.IsDisposed AndAlso Not Visionar.Salida.Disposing Then Visionar.Salida.AppendText(Visionar.Linea)
                End If
            Next
            If Not esLog Then
                If Recuperador.Intervalo = 10000 Then Recuperador.Intervalo = 30000
                If Recuperador.Intervalo = 1000 Then Recuperador.Intervalo = 10000
                If Recuperador.Intervalo = 100 Then Recuperador.Intervalo = 1000
            Else
                If Recuperador.Intervalo <> 100 Then Recuperador.Intervalo = 100
            End If
        End Sub
    End Module
    Public Class LogConfig
        Public Property Salida As RichTextBox = Nothing
        Public Property Lineas As New Collections.Concurrent.ConcurrentQueue(Of String)
        Public Property Linea As String = String.Empty
    End Class
End Namespace