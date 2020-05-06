Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Xpo.Metadata
Imports System.Drawing
Imports System.ComponentModel

Public Enum TipoMaterial As Integer
    Agencia = 1
    Franquiciado = 2
End Enum

<DefaultClassOptions()>
<DefaultProperty("Nombre")>
Public Class Material
    Inherits XPBaseObject

#Region "PK"
    Dim _IdMaterial As Integer
    <Index(0)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Key(True)>
    Public Property IdMaterial() As Integer
        Get
            Return _IdMaterial
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(Of Integer)("IdMaterial", _IdMaterial, Value)
        End Set
    End Property
#End Region

#Region "Propiedades"
    Private _Nombre As String
    <Index(1)>
    <Size(30)>
    <VisibleInDetailView(True)>
    <VisibleInListView(True)>
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            SetPropertyValue(Of String)("Nombre", _Nombre, value)
        End Set
    End Property

    Private _TipoMaterial As TipoMaterial
    <Index(2)>
    <Size(30)>
    <VisibleInDetailView(True)>
    <VisibleInListView(True)>
    Public Property Tipo() As TipoMaterial
        Get
            Return _TipoMaterial
        End Get
        Set(ByVal value As TipoMaterial)
            SetPropertyValue(Of TipoMaterial)("TipoMaterial", _TipoMaterial, value)
        End Set
    End Property
    Private _Importe As Decimal
    <Index(3)>
    <VisibleInDetailView(True)>
    <VisibleInListView(True)>
    Public Property Importe() As Decimal
        Get
            Return _Importe
        End Get
        Set(ByVal value As Decimal)
            SetPropertyValue(Of Decimal)("Importe", _Importe, value)
        End Set
    End Property
    Private _Imagen As XPDelayedProperty = New XPDelayedProperty
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    <Size(SizeAttribute.Unlimited), Delayed("_Imagen"), ValueConverter(GetType(ImageValueConverter))>
    Public Property Imagen() As Image
        Get
            Return CType(_Imagen.Value, Image)
        End Get
        Set(ByVal value As Image)
            _Imagen.Value = value
            OnChanged("_Imagen")
        End Set
    End Property
    Dim _Habilitado As Boolean
    <Index(4)>
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
