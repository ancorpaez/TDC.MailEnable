Imports System.Net
Imports System.Net.NetworkInformation

Namespace Aplicacion
    Module Core
        Public WithEvents MainForm As Interfaz.Main
        Private esIniciado As Boolean = False
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

            'Iniciar Escuchadores
            If Not Escuchadores.Existe(Escuchadores.Core.EnumEscuchadores.ImapSSl) Then
                If Escuchadores.Crear(Escuchadores.Core.EnumEscuchadores.ImapSSl, 993) Then
                    AddHandler Escuchadores.Obtener(Escuchadores.Core.EnumEscuchadores.ImapSSl).ConexionEntrante, AddressOf ConexionEntranteSsl
                End If
            End If
            If Not Escuchadores.Existe(Escuchadores.Core.EnumEscuchadores.Imap) Then
                If Escuchadores.Crear(Escuchadores.Core.EnumEscuchadores.Imap, 143) Then
                    AddHandler Escuchadores.Obtener(Escuchadores.Core.EnumEscuchadores.Imap).ConexionEntrante, AddressOf ConexionEntranteSsl
                End If
            End If

        End Sub
        Private Sub ConexionEntranteSsl()
            Dim Aceptar As New Enrutadores.AcceptSocketSubProcess(Escuchadores.Obtener(Escuchadores.Core.EnumEscuchadores.ImapSSl).GetFirst, 994)
            AddHandler Aceptar.ConexionAceptada, AddressOf ConexionAceptada
            AddHandler Aceptar.ConexionRechadaza, AddressOf ConexionRechazada
        End Sub
        Private Sub ConexionEntrante()
            Dim Aceptar As New Enrutadores.AcceptSocketSubProcess(Escuchadores.Obtener(Escuchadores.Core.EnumEscuchadores.Imap).GetFirst, 144)
            AddHandler Aceptar.ConexionAceptada, AddressOf ConexionAceptada
            AddHandler Aceptar.ConexionRechadaza, AddressOf ConexionRechazada
        End Sub

        Private Sub ConexionAceptada(Aceptador As Enrutadores.AcceptSocketSubProcess, Conexion As Sockets.Socket)
            RemoveHandler Aceptador.ConexionAceptada, AddressOf ConexionAceptada
            RemoveHandler Aceptador.ConexionRechadaza, AddressOf ConexionRechazada
            Console.WriteLine($"Aceptada: {Conexion.RemoteEndPoint.ToString}")
            Dim Visualizar As New Interfaz.Conexion(Enrutadores.Obtener(Conexion.RemoteEndPoint.ToString)) With {.TopLevel = False}
            MainForm.FlowPanel.Controls.Add(Visualizar)
            Visualizar.Show()
        End Sub
        Private Sub ConexionRechazada(Aceptador As Enrutadores.AcceptSocketSubProcess, Conexion As Sockets.Socket)
            RemoveHandler Aceptador.ConexionAceptada, AddressOf ConexionAceptada
            RemoveHandler Aceptador.ConexionRechadaza, AddressOf ConexionRechazada
            Try
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
    End Module
End Namespace