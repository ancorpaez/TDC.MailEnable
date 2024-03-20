Imports System.Net
Imports System.Net.NetworkInformation
Imports Enrutador.TCP.Enrutadores

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
            'Pruebas
            'RouteTable.Test()

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
                    .Text = $"Ssl ({NET.EasyPortManagerSsl.Listen})"
                    If Escuchadores.Crear(Escuchadores.Core.EnumEscuchadores.ImapSSl, NET.EasyPortManagerSsl.Listen) Then
                        AddHandler Escuchadores.Obtener(Escuchadores.Core.EnumEscuchadores.ImapSSl).ConexionEntrante, AddressOf ConexionEntranteSsl
                        .ForeColor = Color.DarkGreen
                    Else
                        .Font = New Font(.Font, FontStyle.Bold)
                        .ForeColor = Color.DarkRed
                    End If
                End With
            End If

            If Not Escuchadores.Existe(Escuchadores.Core.EnumEscuchadores.Imap) Then
                With MainForm.lblImap
                    .Text = $"Imap ({NET.EasyPortManager.Listen})"
                    If Escuchadores.Crear(Escuchadores.Core.EnumEscuchadores.Imap, NET.EasyPortManager.Listen) Then
                        AddHandler Escuchadores.Obtener(Escuchadores.Core.EnumEscuchadores.Imap).ConexionEntrante, AddressOf ConexionEntrante
                        .ForeColor = Color.DarkGreen
                    Else
                        .Font = New Font(.Font, FontStyle.Bold)
                        .ForeColor = Color.DarkRed
                    End If
                End With
            End If

            MainForm.lblConexionesConcurrentes.Text = $"Límite Concurrentes( {Enrutadores.MaximunRoutersPerIp} )"
            MainForm.lblTemporizadorIcantividad.Text = $"Cerrar ENAT ( {Enrutadores.InactiveTimeOut} )"


        End Sub
        Private Sub ConexionEntranteSsl()
            Dim Recoger As Sockets.Socket = Escuchadores.Obtener(Escuchadores.Core.EnumEscuchadores.ImapSSl).GetFirst
            If Recoger IsNot Nothing Then
                Dim Analizar As New Enrutadores.AcceptSocketSubProcess(Recoger, NET.EasyPortManagerSsl.Route)
                AddHandler Analizar.ConexionAceptada, AddressOf ConexionAceptada
                AddHandler Analizar.ConexionRechadaza, AddressOf ConexionRechazada
            End If
        End Sub
        Private Sub ConexionEntrante()
            Dim Recoger As Sockets.Socket = Escuchadores.Obtener(Escuchadores.Core.EnumEscuchadores.Imap).GetFirst
            If Recoger IsNot Nothing Then
                Dim Analizar As New Enrutadores.AcceptSocketSubProcess(Recoger, NET.EasyPortManager.Route)
                AddHandler Analizar.ConexionAceptada, AddressOf ConexionAceptada
                AddHandler Analizar.ConexionRechadaza, AddressOf ConexionRechazada
            End If
        End Sub

        Private Sub ConexionAceptada(Aceptador As Enrutadores.AcceptSocketSubProcess, Conexion As Sockets.Socket)
            Try
                'Asignar el Control de Lista
                If IsNothing(Interfaz.ListViewAceptadas) Then Interfaz.ListViewAceptadas = MainForm.lstAceptadas
                If IsNothing(Interfaz.ListViewConexiones) Then Interfaz.ListViewConexiones = MainForm.lstConexiones

                'Remover eventos
                RemoveHandler Aceptador.ConexionAceptada, AddressOf ConexionAceptada
                RemoveHandler Aceptador.ConexionRechadaza, AddressOf ConexionRechazada

                'Actualizar Control
                Dim cKey As String = CType(Aceptador.Conexion.RemoteEndPoint, IPEndPoint).Address.ToString
                Dim nItem As New ListViewItem(cKey) With {.Name = cKey}
                Dim nSubitem As New ListViewItem.ListViewSubItem()
                nSubitem.Text = 1
                nSubitem.Name = $"c{cKey}"
                nItem.SubItems.Add(nSubitem)
                Interfaz.ToAddAceptadas(nItem)
                MainForm.lblAceptadas.Text = MainForm.lstAceptadas.Items.Count
                Console.WriteLine($"Aceptada: { CType(Aceptador.Conexion.RemoteEndPoint, IPEndPoint).Address.ToString}")

                Dim cFullKey As String = Aceptador.Conexion.RemoteEndPoint.ToString
                Dim cItem As New ListViewItem(cFullKey) With {.Name = cFullKey}
                Dim cSubItem As New ListViewItem.ListViewSubItem()
                cSubItem.Text = Enrutadores.InactiveTimeOut
                cSubItem.Name = $"c{cFullKey}"
                cItem.SubItems.Add(cSubItem)
                Interfaz.ToAddConexiones(cItem)
                MainForm.lblConexiones.Text = MainForm.lstConexiones.Items.Count
                Console.WriteLine($"Conexión: {Conexion.RemoteEndPoint.ToString}")

                'Activar Eventos del Enrutador
                AddHandler Enrutadores.Obtener(Conexion.RemoteEndPoint.ToString).Actividad, AddressOf AlActualizarEnrutador
                AddHandler Enrutadores.Obtener(Conexion.RemoteEndPoint.ToString).AlCerrarEnrutador, AddressOf AlCerrarEnrutador

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub
        Private Sub ConexionRechazada(Aceptador As Enrutadores.AcceptSocketSubProcess, Conexion As Sockets.Socket)
            Try
                'Asignar el Control de Lista
                If IsNothing(Interfaz.ListViewRechazadas) Then Interfaz.ListViewRechazadas = MainForm.lstRechazadas

                'Remover eventos
                RemoveHandler Aceptador.ConexionAceptada, AddressOf ConexionAceptada
                RemoveHandler Aceptador.ConexionRechadaza, AddressOf ConexionRechazada

                'Actualizar Control
                Dim cKey As String = CType(Aceptador.Conexion.RemoteEndPoint, IPEndPoint).Address.ToString
                Dim nItem As New ListViewItem(cKey) With {.Name = cKey}
                Dim nSubitem As New ListViewItem.ListViewSubItem()
                nSubitem.Text = 1
                nSubitem.Name = $"c{cKey}"
                nItem.SubItems.Add(nSubitem)
                Interfaz.ToRechazadas(nItem)
                MainForm.lblRechazadas.Text = MainForm.lstRechazadas.Items.Count
                Console.WriteLine($"Rechazada: {Conexion.RemoteEndPoint.ToString}")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Sub AlActualizarPipe(Lista As List(Of String))
            MainForm.lblIpBan.Text = $"IpBan ({Lista.Count})"
        End Sub

        Private Sub AlActualizarEnrutador(Activo As Integer, Enrutador As Enrutadores.Enrutador)
            Interfaz.ToContadorEnrutador(Enrutador.Conexion.RemoteEndPoint.ToString, Activo)
        End Sub
        Private Sub AlCerrarEnrutador(Enrutador As Enrutadores.Enrutador)
            RemoveHandler Enrutador.Actividad, AddressOf AlActualizarEnrutador
            RemoveHandler Enrutador.AlCerrarEnrutador, AddressOf AlCerrarEnrutador
            Interfaz.ToRemoveConexiones(Enrutador.Conexion.RemoteEndPoint.ToString)
            MainForm.lblConexiones.Text = MainForm.lstConexiones.Items.Count
            Interfaz.ToRemoveAceptadas(CType(Enrutador.Conexion.RemoteEndPoint, IPEndPoint).Address.ToString)
            MainForm.lblAceptadas.Text = MainForm.lstAceptadas.Items.Count
        End Sub
    End Module
End Namespace