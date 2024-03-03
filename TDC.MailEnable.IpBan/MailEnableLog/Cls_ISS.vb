Imports System.Xml
Imports TDC.MailEnable.IpBan.MailEnableLog

Class Cls_ISS
    ' Ruta del archivo de configuración de IIS
    Private xmlDoc As New XmlDocument()
    Private filePath As String = Configuracion.WEB_DENY

    'NODOS
    Private Location As XmlNode
    Private SystemWebServer As XmlNode
    Private Security As XmlNode
    Private ipSecurity As XmlNode
    Private XmlCargado As Boolean = False

    Public Sub New()
        If String.IsNullOrEmpty(filePath) Then Exit Sub
        Try
            xmlDoc.Load(filePath)
            Location = FindNodeByAttribute(xmlDoc, "location", "path", "MailEnable WebMail")
            SystemWebServer = BuscarNodo(Location, "system.webServer")
            Security = BuscarNodo(SystemWebServer, "security")
            ipSecurity = BuscarNodo(Security, "ipSecurity")
            XmlCargado = True
        Catch ex As Exception
        End Try
    End Sub

    Private Function BuscarNodo(Nodos As XmlNode, Nodo As String) As XmlNode
        For Each Nod As XmlNode In Nodos.ChildNodes
            If Nod.Name = Nodo Then
                Return Nod
            End If
        Next
        Return Nothing
    End Function

    Private Function BuscarIp(Nodo As XmlNode, Ip As String) As XmlNode
        If Not IsNothing(Nodo) Then
            Dim Busqueda As String = $"//add[@ipAddress='{Ip}']"
            Return Nodo.SelectSingleNode(Busqueda)
        Else
            Return Nothing
        End If
    End Function

    Function FindNodeByAttribute(xmlDoc As XmlDocument, elementName As String, attributeName As String, attributeValue As String) As XmlNode
        Dim xpath As String = $"//{elementName}[@{attributeName}='{attributeValue}']"
        Return xmlDoc.SelectSingleNode(xpath)
    End Function

    Private Sub AddIpSecurityElement(xmlDoc As XmlDocument, securityNode As XmlNode, ipAddress As String, allowed As String)
        ' Crea un nuevo elemento <add>
        Dim Element As XmlElement = xmlDoc.CreateElement("add")

        ' Añade atributos al elemento <add>
        Element.SetAttribute("ipAddress", ipAddress)
        Element.SetAttribute("allowed", allowed)

        ' Añade el elemento <add> a la lista <ipSecurity>
        If Not IsNothing(securityNode) Then securityNode.AppendChild(Element)
    End Sub
    Private Sub RemoveIpSecurityElement(securityNode As XmlNode, Node As XmlNode)

        ' Elimina el elemento <add> a la lista <ipSecurity>
        securityNode.RemoveChild(Node)
    End Sub
    Private Sub ClearIpSecurityElement(securityNode As XmlNode)
        If Not IsNothing(securityNode) Then securityNode.RemoveAll()
    End Sub
    Public Function Cargado() As Boolean
        Return XmlCargado
    End Function

    Public Function Contains(Ip As String) As Boolean
        If Not IsNothing(BuscarIp(ipSecurity, Ip)) Then Return True
        Return False
    End Function
    Public Function Add(Ip As String) As Boolean
        Try
            If IsNothing(BuscarIp(ipSecurity, Ip)) Then AddIpSecurityElement(xmlDoc, ipSecurity, Ip, "false")
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function Remove(Ip As String) As Boolean
        Try
            If Not IsNothing(BuscarIp(ipSecurity, Ip)) Then RemoveIpSecurityElement(ipSecurity, BuscarIp(ipSecurity, Ip))
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Public Function Clear() As Boolean
        Try
            ClearIpSecurityElement(ipSecurity)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Public Function Count() As Integer
        Return ipSecurity.ChildNodes.Count
    End Function
    Public Function Guardar() As Boolean
        Try
            xmlDoc.Save(filePath)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function


End Class
