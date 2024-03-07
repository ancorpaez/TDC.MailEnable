Imports System.Runtime.InteropServices
Namespace Routing
    Public Class Program
        Private Const AF_INET As Integer = 2

        <DllImport("Kernel32.dll", SetLastError:=True)>
        Private Shared Function CloseHandle(ByVal handle As IntPtr) As Boolean
        End Function

        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
        Public Structure AdapterInfo
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)>
            Public AdapterName As String
            Public Family As Integer
            Public DhcpEnabled As Boolean
        End Structure

        <DllImport("iphlpapi.dll", SetLastError:=True)>
        Private Shared Function CreateAdapter(
        <[In]> ByVal AdapterInfo As IntPtr,
        <[Out]> ByRef AdapterHandle As IntPtr) As Integer
        End Function

        Public Shared Sub CreateLoopbackAdapter()
            ' Crear la estructura AdapterInfo
            Dim adapterInfo As New AdapterInfo()
            adapterInfo.AdapterName = "Loopback Adapter"
            adapterInfo.Family = AF_INET
            adapterInfo.DhcpEnabled = False

            ' Convertir la estructura en un puntero
            Dim adapterInfoPtr As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(adapterInfo))
            Marshal.StructureToPtr(adapterInfo, adapterInfoPtr, False)


            ' Crear la tarjeta de bucle invertido
            Dim adapterHandle As IntPtr
            Dim result As Integer = CreateAdapter(adapterInfoPtr, adapterHandle)

            If result <> 0 Then
                Throw New Exception("Error al crear la tarjeta de bucle invertido")
            End If

            ' Cerrar el handle de la tarjeta
            CloseHandle(adapterHandle)
        End Sub
    End Class
End Namespace