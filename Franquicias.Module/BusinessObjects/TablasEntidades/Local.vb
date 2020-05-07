Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp
Imports System.ComponentModel

<DefaultClassOptions()>
<DefaultProperty("Nombre")>
Public Class Local
    Inherits XPBaseObject
    Implements IFranquiciado
    'Implements IMapsMarker

#Region "PK"
    Dim _IdLocal As Integer
    <Index(0)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Key(True)>
    Public Property IdLocal() As Integer
        Get
            Return _IdLocal
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(Of Integer)("IdLocal", _IdLocal, Value)
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

    Private _Domicilio As String
    <Index(2)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Size(80)>
    Public Property Domicilio() As String
        Get
            Return _Domicilio
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Of String)("Domicilio", _Domicilio, Value)
        End Set
    End Property

    Private _Localidad As String
    <Index(3)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Size(50)>
    Public Property Localidad() As String
        Get
            Return _Localidad
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Of String)("Localidad", _Localidad, Value)
        End Set
    End Property

    Private _CodigoPostal As String
    <Index(4)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Size(10)>
    Public Property CodigoPostal() As String
        Get
            Return _CodigoPostal
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Of String)("CodigoPostal", _CodigoPostal, Value)
        End Set
    End Property

    Private _Provincia As Provincia
    <Index(5)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    Public Property Provincia() As Provincia
        Get
            Return _Provincia
        End Get
        Set(ByVal value As Provincia)
            SetPropertyValue(Of Provincia)("Provincia", _Provincia, value)
        End Set
    End Property

    Private _Franquiciado As Franquiciado
    <Association("Franquiciado-Local")>
    <Index(6)>
    <VisibleInDetailView(True)>
    <VisibleInListView(True)>
    Public Property Franquiciado() As Franquiciado Implements IFranquiciado.Franquiciado
        Get
            Return _Franquiciado
        End Get
        Set(ByVal value As Franquiciado)
            SetPropertyValue(Of Franquiciado)("Franquiciado", _Franquiciado, value)
        End Set
    End Property

    Private _DatoFacturacion As DatoFacturacion
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Index(7)>
    Public Property DatoFacturacion() As DatoFacturacion
        Get
            Return _DatoFacturacion
        End Get
        Set(ByVal value As DatoFacturacion)
            SetPropertyValue(Of DatoFacturacion)("DatoFacturacion", _DatoFacturacion, value)
        End Set
    End Property
#End Region

    '#Region "Mapas"
    '    '<Browsable(False)>
    '    'Public ReadOnly Property MapsMarkerLatitude As Double Implements IMapsMarker.Latitude
    '    '    Get
    '    '        Return Me.Latitude
    '    '    End Get
    '    'End Property
    '    '<Browsable(False)>
    '    'Public ReadOnly Property MapsMarkerLongitude As Double Implements IMapsMarker.Longitude
    '    '    Get
    '    '        Return Longitude
    '    '    End Get
    '    'End Property
    '    <Browsable(False)>
    '    Public ReadOnly Property MapsMarkerTitle As String Implements IMapsMarker.Title
    '        Get
    '            Return Me.Nombre
    '        End Get
    '    End Property

    '    Dim _Latitude As Double
    '    <VisibleInListView(False), VisibleInLookupListView(False)>
    '    Public Property Latitude() As Double Implements IMapsMarker.Latitude
    '        Get
    '            Return _Latitude
    '        End Get
    '        Set(value As Double)
    '            Return _Logitude
    '            SetPropertyValue(Of Double)("Latitude", _Latitude, value)
    '        End Set
    '    End Property

    '    Dim _Logitude As Double
    '    <VisibleInListView(False), VisibleInLookupListView(False)>
    '    Public Property Longitude() As Double Implements IMapsMarker.Longitude
    '        Get
    '        End Get
    '        Set(value As Double)
    '            SetPropertyValue(Of Double)("Longitude", _Logitude, value)
    '        End Set
    '    End Property

    '#End Region


#Region "Colecciones"
    <Association("Local-OrdenPublicidad"), DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property Publicidades() As XPCollection(Of OrdenPublicidad)
        Get
            Return GetCollection(Of OrdenPublicidad)("Publicidades")
        End Get
    End Property

    <Association("Local-Factura"), DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property Facturas() As XPCollection(Of Factura)
        Get
            Return GetCollection(Of Factura)("Facturas")
        End Get
    End Property


    '    Public ReadOnly Property Title As String Implements IBaseMapsMarker.Title
    '        Get
    '            Throw New NotImplementedException()
    '        End Get
    '    End Property

    '    Public ReadOnly Property Latitude As Double Implements IBaseMapsMarker.Latitude
    '        Get
    '            Throw New NotImplementedException()
    '        End Get
    '    End Property

    '    Public ReadOnly Property Longitude As Double Implements IBaseMapsMarker.Longitude
    '        Get
    '            Throw New NotImplementedException()
    '        End Get
    '    End Property


#End Region

#Region "Eventos"
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).

        If SecuritySystem.CurrentUserName <> "Admin" And IsNothing(Me.Franquiciado) Then
            Me.Franquiciado = Session.GetObjectByKey(Of Franquiciado)(SecuritySystem.CurrentUserId)
        End If

    End Sub
#End Region



End Class
