Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports System.ComponentModel

<DefaultProperty("Nombre")>
<DefaultClassOptions()>
Public Class TipoIva
    Inherits XPBaseObject

#Region "PK"
    Dim _IdTipoIva As Integer
    <Index(0)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Key(True)>
    Public Property IdTipoIva() As Integer
        Get
            Return _IdTipoIva
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(Of Integer)("IdTipoIva", _IdTipoIva, Value)
        End Set
    End Property
#End Region

#Region "Propiedades"
    Private _Nombre As String
    <Size(50)>
    <Index(1)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Of String)("Nombre", _Nombre, Value)
        End Set
    End Property

    Private _CodigoAfip As Integer
    <Size(80)>
    <Index(2)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    Public Property CodigoAfip() As Integer
        Get
            Return _CodigoAfip
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(Of Integer)("CodigoAfip", _CodigoAfip, Value)
        End Set
    End Property

    Dim _CalculaIva As Boolean
    <Index(3)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    Public Property CalculaIva() As Boolean
        Get
            Return _CalculaIva
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue(Of Boolean)("CalculaIva", _CalculaIva, Value)
        End Set
    End Property

    Dim _DiscriminaEnIva As Boolean
    <Index(4)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    Public Property DiscriminaEnIva() As Boolean
        Get
            Return _DiscriminaEnIva
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue(Of Boolean)("DiscriminaEnIva", _DiscriminaEnIva, Value)
        End Set
    End Property

    Dim _Letra As String
    <Index(5)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    Public Property Letra() As String
        Get
            Return _Letra
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Of String)("Letra", _Letra, Value)
        End Set
    End Property

    Dim _Habilitado As Boolean
    <Index(6)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    Public Property Habilitado() As Boolean
        Get
            Return _Habilitado
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue(Of Boolean)("Habilitado", _Habilitado, Value)
        End Set
    End Property
#End Region

#Region "Colecciones"
    <Association("TipoIva-TipoReferenciaVenta")>
    Public ReadOnly Property TiposReferenciaVenta() As XPCollection(Of TipoReferencia)
        Get
            Return GetCollection(Of TipoReferencia)("TiposReferenciaVenta")
        End Get
    End Property


#End Region

#Region "Eventos"
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub
#End Region

End Class