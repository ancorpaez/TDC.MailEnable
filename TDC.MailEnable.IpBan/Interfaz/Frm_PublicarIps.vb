Imports System.Net.NetworkInformation
Imports TDC.MailEnable.IpBan.MailEnable
Imports TDC.MailEnable.Core
Imports System.ComponentModel
Imports TDC.MailEnable.Core.Bucle

Namespace Interfaz
    Public Class Frm_PublicarIps
        Private Publicador As Bucle.DoBucle
        Private IndexIp As Integer = 0
        Private ListaSMTP As MailEnableDenyIp
        Private ListaPOP As MailEnableDenyIp
        Private ListaWEB As IISDenyIp
        Public Property ListaIPBaneadas As Collections.Concurrent.ConcurrentQueue(Of String)
        Private Enum EnumEstado
            Cargando
            Cargado
        End Enum
        Private Estado As EnumEstado = EnumEstado.Cargando
        Private Sub Frm_PublicarIps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ListaSMTP = New MailEnableDenyIp(MailEnable.Main.Configuracion.SMTP_DENY)
            ListaPOP = New MailEnableDenyIp(MailEnable.Main.Configuracion.POP_DENY)
            ListaWEB = New IISDenyIp()
            Publicador = Core.Bucle.GetOrCreate("PublicadorIpNegra")
            AddHandler Publicador.BackGround, AddressOf Publicador_Background
            AddHandler Publicador.ForeGround, AddressOf Publicador_Foreground
            AddHandler Publicador.EndGround, AddressOf Publicador_Endground
            AddHandler Publicador.ErrorGround, AddressOf Publicador_ErrorGround
        End Sub
        Private Sub Frm_PublicarIps_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
            RemoveHandler Publicador.BackGround, AddressOf Publicador_Background
            RemoveHandler Publicador.ForeGround, AddressOf Publicador_Foreground
            RemoveHandler Publicador.EndGround, AddressOf Publicador_Endground
            RemoveHandler Publicador.ErrorGround, AddressOf Publicador_ErrorGround
        End Sub
        Private Sub Frm_PublicarIps_Activated(sender As Object, e As EventArgs) Handles Me.Activated
            If Estado = EnumEstado.Cargando Then
                Estado = EnumEstado.Cargado
                ActualizarIps()
            End If
        End Sub
        Public Sub ActualizarIps()
            'Limpiar las listas
            ListaPOP.Clear()
            ListaSMTP.Clear()
            ListaWEB.Clear()

            'Intervalo
            If IsNumeric(MailEnable.Main.Configuracion.TIMER_PROPAGACION) Then Publicador.Intervalo = MailEnable.Main.Configuracion.TIMER_PROPAGACION Else Publicador.Intervalo = 1

            'Interfaz
            Progreso.Maximum = ListaIPBaneadas.Count
            lblIndex.Text = Progreso.Maximum

            'Publicar
            Publicador.Iniciar()

        End Sub
        Private Sub Publicador_Background(Sender As Object, e As BackgroundEventArgs)
            If IsNumeric(MailEnable.Main.Configuracion.TIMER_PROPAGACION) Then Publicador.Intervalo = MailEnable.Main.Configuracion.TIMER_PROPAGACION Else Publicador.Intervalo = 1
            'Proteger
            If ListaIPBaneadas.IsEmpty Then
                e.Detener = True
                Exit Sub
            End If

            'Meterdatos
            Dim cIp As String = String.Empty
            If ListaIPBaneadas.TryDequeue(cIp) Then
                ListaPOP.Add(cIp)
                ListaSMTP.Add(cIp)
                ListaWEB.Add(cIp)
            End If
        End Sub

        Private Sub Publicador_Foreground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs)
            If Not Publicador.Cancelar Then
                If Not ListaIPBaneadas.IsEmpty Then
                    Progreso.Value = Progreso.Maximum - (ListaIPBaneadas.Count - 1)
                    lblCount.Text = ListaIPBaneadas.Count
                    lblIp.Text = ListaIPBaneadas.First
                End If
            End If
        End Sub



        Private Sub Publicador_Endground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs)

            'Salvar los datos
            If Not Publicador.AsUserCancel AndAlso Not Publicador.esErroneo Then
                ListaPOP.Guardar()
                ListaSMTP.Guardar()
                Do While Not ListaWEB.Guardar()
                    Threading.Thread.Sleep(100)
                Loop
            End If

            'Limpiar Memoria
            ListaPOP.Clear()
            ListaSMTP.Clear()
            ListaWEB.Clear()

            ListaSMTP.Dispose()
            ListaPOP.Dispose()

            'Salir
            Me.Close()
        End Sub
        Private Sub Publicador_ErrorGround(Sender As Object, e As BackgroundEventArgs)
            MsgBox($"{e.Excepcion.Message}{vbNewLine}{vbNewLine}¡No se ha podido propagar la lista IP!", MsgBoxStyle.Critical, "Error")
            e.Detener = True
            Me.Close()
        End Sub
        Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
            Publicador.Detener(True)
        End Sub


    End Class
End Namespace