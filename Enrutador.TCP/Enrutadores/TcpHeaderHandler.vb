Imports System.Net
Imports System.Net.Sockets

Public Class TcpHeaderHandler
    Private Const TCP_HEADER_LENGTH As Integer = 20

    Public Shared Function ReadTcpHeader(buffer As Byte(), offset As Integer) As TcpHeader
        Dim header As New TcpHeader With {
            .SourcePort = BitConverter.ToUInt16(buffer, offset),
            .DestinationPort = BitConverter.ToUInt16(buffer, offset + 2),
            .SequenceNumber = BitConverter.ToUInt32(buffer, offset + 4),
            .AcknowledgmentNumber = BitConverter.ToUInt32(buffer, offset + 8),
            .DataOffset = buffer(offset + 12) >> 4,
            .Reserved = buffer(offset + 12) And &HF,
            .Urg = buffer(offset + 13) And &H20 >> 5 = 1,
            .Ack = buffer(offset + 13) And &H10 >> 4 = 1,
            .Psh = buffer(offset + 13) And &H8 >> 3 = 1,
            .Rst = buffer(offset + 13) And &H4 >> 2 = 1,
            .Sync = buffer(offset + 13) And &H2 >> 1 = 1,
            .Fin = buffer(offset + 13) And &H1 = 1,
            .WindowSize = BitConverter.ToUInt16(buffer, offset + 14),
            .Checksum = BitConverter.ToUInt16(buffer, offset + 16),
            .UrgentPointer = BitConverter.ToUInt16(buffer, offset + 18)
        }

        Return header
    End Function

    Public Shared Sub WriteTcpHeader(header As TcpHeader, buffer As Byte(), offset As Integer)
        buffer.BlockCopy(BitConverter.GetBytes(header.SourcePort), 0, buffer, offset, 2)
        buffer.BlockCopy(BitConverter.GetBytes(header.DestinationPort), 0, buffer, offset + 2, 2)
        buffer.BlockCopy(BitConverter.GetBytes(header.SequenceNumber), 0, buffer, offset + 4, 4)
        buffer.BlockCopy(BitConverter.GetBytes(header.AcknowledgmentNumber), 0, buffer, offset + 8, 4)
        buffer(offset + 12) = (header.DataOffset << 4) Or (header.Reserved And &HF)
        buffer(offset + 13) = (CByte((header.Urg << 7) Or (header.Ack << 6) Or (header.Psh << 5) Or (header.Rst << 4) Or (header.Sync << 3) Or (header.Fin << 0)))
        buffer.BlockCopy(BitConverter.GetBytes(header.WindowSize), 0, buffer, offset + 14, 2)
        buffer.BlockCopy(BitConverter.GetBytes(header.Checksum), 0, buffer, offset + 16, 2)
        buffer.BlockCopy(BitConverter.GetBytes(header.UrgentPointer), 0, buffer, offset + 18, 2)
    End Sub

    Public Class TcpHeader
        Public Property SourcePort As UInt16
        Public Property DestinationPort As UInt16
        Public Property SequenceNumber As UInt32
        Public Property AcknowledgmentNumber As UInt32
        Public Property DataOffset As Byte
        Public Property Reserved As Byte
        Public Property Urg As Boolean
        Public Property Ack As Boolean
        Public Property Psh As Boolean
        Public Property Rst As Boolean
        Public Property Sync As Boolean
        Public Property Fin As Boolean
        Public Property WindowSize As UInt16
        Public Property Checksum As UInt16
        Public Property UrgentPointer As UInt16
    End Class
End Class