Imports System.Net.NetworkInformation
Imports TDC.MailEnable.IpBan.MailEnableLog
Imports TDC.MailEnable.Core

Namespace Interfaz
    Public Class Frm_PublicarIps
        Private WithEvents Publicador As New Bucle.DoBucle
        Private IndexIp As Integer = 0
        Private ListaSMTP As Cls_MailEnableDeny
        Private ListaPOP As Cls_MailEnableDeny
        Private ListaWEB As Cls_ISS
        Public Lista As List(Of String)
        Private Enum EnumEstado
            Cargando
            Cargado
        End Enum
        Private Estado As EnumEstado = EnumEstado.Cargando
        Private Sub Frm_PublicarIps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ListaSMTP = New Cls_MailEnableDeny(Mod_Core.Configuracion.SMTP_DENY)
            ListaPOP = New Cls_MailEnableDeny(Mod_Core.Configuracion.POP_DENY)
            ListaWEB = New Cls_ISS()
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

            If IsNumeric(Configuracion.TIMER_PROPAGACION) Then Publicador.Intervalo = Configuracion.TIMER_PROPAGACION Else Publicador.Intervalo = 1
            Publicador.Iniciar()
            If Not IsNothing(Lista) AndAlso Lista.Count > 0 Then
                Progreso.Maximum = Lista.Count - 1
            End If
        End Sub
        Private Sub Publicador_Background(Sender As Object, ByRef Detener As Boolean) Handles Publicador.Background
            If IsNumeric(Configuracion.TIMER_PROPAGACION) Then Publicador.Intervalo = Configuracion.TIMER_PROPAGACION Else Publicador.Intervalo = 1
            'Proteger
            If Lista.Count = 0 Then Exit Sub
            'Meterdatos
            If Not ListaPOP.Contais(Lista(IndexIp)) Then ListaPOP.Add(Lista(IndexIp))
            If Not ListaSMTP.Contais(Lista(IndexIp)) Then ListaSMTP.Add(Lista(IndexIp))
            If Not ListaWEB.Contains(Lista(IndexIp)) Then ListaWEB.Add(Lista(IndexIp))

            'Comprobar el Index
            If IndexIp < (Lista.Count - 1) Then
                'Aumentar uno
                'Me.Invoke(Sub() Progreso.Value = IndexIp)
                'Me.Invoke(Sub() lblIp.Text = Lista(IndexIp))
                'Me.Invoke(Sub() lblIndex.Text = IndexIp)
                'Me.Invoke(Sub() lblCount.Text = Lista.Count)

                IndexIp += 1
            Else
                'Salvar los datos
                ListaPOP.Guardar()
                ListaSMTP.Guardar()
                ListaWEB.Guardar()

                'Detener la publicacion
                Publicador.Detener()
                Try
                    Me.Invoke(Sub() Me.Close())
                Catch ex As Exception
                End Try
            End If
        End Sub

        Private Sub Publicador_Foreground(Sender As Object, ByRef Detener As Boolean) Handles Publicador.Foreground
            If IndexIp < (Lista.Count - 1) Then
                Progreso.Value = IndexIp
                lblIp.Text = Lista(IndexIp)
                lblIndex.Text = IndexIp
                lblCount.Text = Lista.Count
            End If
        End Sub
        Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
            Publicador.Detener()
            Me.Close()
        End Sub

    End Class
End Namespace