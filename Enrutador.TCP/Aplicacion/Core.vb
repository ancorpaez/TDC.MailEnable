Imports System.Net
Imports System.Net.NetworkInformation

Namespace Aplicacion
    Module Core
        Public WithEvents MainForm As Interfaz.Main
        Private esIniciado As Boolean = False
        Public ReadOnly VC As New Concurrent.ConcurrentBag(Of Interfaz.Conexion)
        Private WithEvents VCView As New TDC.MailEnable.Core.Bucle.DoBucle("VCView")

        Private Sub ActivatedMainForm() Handles MainForm.Activated
            If Not esIniciado Then
                esIniciado = Not esIniciado
                Iniciar()
            End If
        End Sub
        Public Sub Iniciar()
            'Establecer la tarjeta para el ENAT
            ENAT.Tarjeta = "ENRUTADOR"
            'Proteger IP de Eliminación
            ENAT.IpProtegidas.Add(IPAddress.Parse("10.0.0.0"))
            'Limpiar Tarjeta de Red
            ENAT.Clear()

            'Inicar Lista de Bloqueo
            IpBanPipe.Main()
            If Not IsNothing(IpBanPipe.Pipe) Then AddHandler IpBanPipe.Pipe.AlObtenerLaLista, AddressOf AlActualizarPipe

            'Iniciar Escuchadores
            If Not Escuchadores.Existe(Escuchadores.Core.EnumEscuchadores.ImapSSl) Then
                With MainForm.lblImapSsl
                    If Escuchadores.Crear(Escuchadores.Core.EnumEscuchadores.ImapSSl, 993) Then
                        AddHandler Escuchadores.Obtener(Escuchadores.Core.EnumEscuchadores.ImapSSl).ConexionEntrante, AddressOf ConexionEntranteSsl
                        .Text = "Ssl (True)"
                        .ForeColor = Color.DarkGreen
                    Else
                        .Font = New Font(.Font, FontStyle.Bold)
                        .ForeColor = Color.DarkRed
                    End If
                End With
            End If

            If Not Escuchadores.Existe(Escuchadores.Core.EnumEscuchadores.Imap) Then
                With MainForm.lblImap
                    If Escuchadores.Crear(Escuchadores.Core.EnumEscuchadores.Imap, 143) Then
                        AddHandler Escuchadores.Obtener(Escuchadores.Core.EnumEscuchadores.Imap).ConexionEntrante, AddressOf ConexionEntrante
                        .Text = "Imap (True)"
                        .ForeColor = Color.DarkGreen
                    Else
                        .Font = New Font(.Font, FontStyle.Bold)
                        .ForeColor = Color.DarkRed
                    End If
                End With
            End If

            'Activar VC
            VCView.Intervalo = 1000
            VCView.Iniciar()

            'RouteTable.Test()
        End Sub
        Private Sub ConexionEntranteSsl()
            Dim Retirar As Sockets.Socket = Escuchadores.Obtener(Escuchadores.Core.EnumEscuchadores.ImapSSl).GetFirst
            If Retirar IsNot Nothing Then
                Dim Aceptar As New Enrutadores.AcceptSocketSubProcess(Retirar, 994)
                AddHandler Aceptar.ConexionAceptada, AddressOf ConexionAceptada
                AddHandler Aceptar.ConexionRechadaza, AddressOf ConexionRechazada
            End If
        End Sub
        Private Sub ConexionEntrante()
            Dim Retirar As Sockets.Socket = Escuchadores.Obtener(Escuchadores.Core.EnumEscuchadores.Imap).GetFirst
            If Retirar IsNot Nothing Then
                Dim Aceptar As New Enrutadores.AcceptSocketSubProcess(Retirar, 144)
                AddHandler Aceptar.ConexionAceptada, AddressOf ConexionAceptada
                AddHandler Aceptar.ConexionRechadaza, AddressOf ConexionRechazada
            End If
        End Sub

        Private Sub ConexionAceptada(Aceptador As Enrutadores.AcceptSocketSubProcess, Conexion As Sockets.Socket)
            Try
                RemoveHandler Aceptador.ConexionAceptada, AddressOf ConexionAceptada
                RemoveHandler Aceptador.ConexionRechadaza, AddressOf ConexionRechazada

                Console.WriteLine($"Aceptada: {Conexion.RemoteEndPoint.ToString}")
                VC.Add(New Interfaz.Conexion(Enrutadores.Obtener(Conexion.RemoteEndPoint.ToString)) With {.TopLevel = False, .ShowInTaskbar = False, .ControlBox = False})
            Catch ex As Exception
                Stop
            End Try
        End Sub
        Private Sub ConexionRechazada(Aceptador As Enrutadores.AcceptSocketSubProcess, Conexion As Sockets.Socket)
            Try
                RemoveHandler Aceptador.ConexionAceptada, AddressOf ConexionAceptada
                RemoveHandler Aceptador.ConexionRechadaza, AddressOf ConexionRechazada

                Dim cKey As String = CType(Aceptador.Conexion.RemoteEndPoint, IPEndPoint).Address.ToString
                Dim lstControl As ListView = MainForm.lstRechazadas
                With lstControl
                    If Not .Items.ContainsKey(cKey) Then
                        Dim nItem As New ListViewItem(cKey) With {.Name = cKey}
                        Dim nSubitem As New ListViewItem.ListViewSubItem()
                        nSubitem.Text = 1
                        nSubitem.Name = $"c{cKey}"
                        nItem.SubItems.Add(nSubitem)
                        lstControl.Items.Add(nItem)
                    Else
                        Dim nItem As ListViewItem = lstControl.Items(cKey) 'Stop
                        Dim nSubItem As ListViewItem.ListViewSubItem = nItem.SubItems($"c{cKey}")
                        nSubItem.Text = CInt(nSubItem.Text) + 1
                    End If
                End With
                MainForm.lblRechazadas.Text = CInt(MainForm.lblRechazadas.Text) + 1
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Sub AlActualizarPipe(Lista As List(Of String))
            MainForm.lblIpBan.Text = $"IpBan ({Lista.Count})"
        End Sub

        Private Sub VCView_Foreground(Sender As Object, ByRef Detener As Boolean) Handles VCView.Foreground
            For Each VCCreate In VC
                If Not VCCreate.Created AndAlso Not VCCreate.Disposing AndAlso Not VCCreate.IsDisposed Then
                    MainForm.FlowPanel.Controls.Add(VCCreate)
                    VCCreate.CreateControl()
                    VCCreate.Show()
                End If
            Next
        End Sub
    End Module
End Namespace