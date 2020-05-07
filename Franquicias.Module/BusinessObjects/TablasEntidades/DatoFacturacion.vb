Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports System.ComponentModel
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.ConditionalAppearance
Imports DevExpress.ExpressApp

'<DefaultClassOptions()>
<DefaultProperty("Domicilio")>
Public Class DatoFacturacion
    Inherits XPBaseObject
    Implements IFranquiciado

#Region "PK"
    Dim _IdDatoFacturacion As Integer
    <Index(0)>
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    <Key(True)>
    Public Property IdDatoFacturacion() As Integer
        Get
            Return _IdDatoFacturacion
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(Of Integer)("IdDatoFacturacion", _IdDatoFacturacion, Value)
        End Set
    End Property
#End Region

#Region "Propiedades"
    Private _Nombre As String
    <Index(1)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Size(50)>
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Of String)("Nombre", _Nombre, Value)
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

    Dim _TipoIva As TipoIva
    <Index(6)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <RuleRequiredField("ReglaRequerido.Local.TipoIva", DefaultContexts.Save, "Falta: Tipo Iva")>
    Public Property TipoIva() As TipoIva
        Get
            Return _TipoIva
        End Get
        Set(ByVal Value As TipoIva)
            SetPropertyValue(Of TipoIva)("TipoIva", _TipoIva, Value)
        End Set
    End Property

    Dim _Cuit As String
    <Index(7)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Size(11)>
    Public Property Cuit() As String
        Get
            Return _Cuit
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Of String)("Cuit", _Cuit, Value)
        End Set
    End Property

    Dim _Habilitado As Boolean
    <Index(8)>
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

    Private _Franquiciado As Franquiciado
    <VisibleInDetailView(True)>
    <VisibleInListView(True)>
    <Association("Franquiciado-DatoFacturacion")>
    Public Property Franquiciado() As Franquiciado Implements IFranquiciado.Franquiciado
        Get
            Return _Franquiciado
        End Get
        Set(ByVal value As Franquiciado)
            SetPropertyValue(Of Franquiciado)("Franquiciado", _Franquiciado, value)
        End Set
    End Property

    Private _Local As Local
    <VisibleInDetailView(True)>
    <VisibleInListView(True)>
    Public Property Local() As Local
        Get
            Return _Local
        End Get
        Set(ByVal value As Local)
            SetPropertyValue(Of Local)("Local", _Local, value)
        End Set
    End Property



    'Private _Factura As Factura
    '<VisibleInDetailView(True)>
    '<VisibleInListView(True)>
    'Public Property Factura() As Factura
    '    Get
    '        Return _Factura
    '    End Get
    '    Set(ByVal value As Factura)
    '        SetPropertyValue(Of Factura)("Factura", _Factura, value)
    '    End Set
    'End Property
#End Region

#Region "Propiedades de CBU"
    Dim _CBU_1_BANCO As String
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    <Size(3)>
    Public Property CBU_1_BANCO() As String
        Get
            Return _CBU_1_BANCO
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Of String)("CBU_1_BANCO", _CBU_1_BANCO, Value)
        End Set
    End Property

    Dim _CBU_1_SUCURSAL As String
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    <Size(4)>
    Public Property CBU_1_SUCURSAL() As String
        Get
            Return _CBU_1_SUCURSAL
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Of String)("CBU_1_SUCURSAL", _CBU_1_SUCURSAL, Value)
        End Set
    End Property

    Dim _CBU_1_DV As String
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    <Size(1)>
    Public Property CBU_1_DV() As String
        Get
            Return _CBU_1_DV
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Of String)("CBU_1_DV", _CBU_1_DV, Value)
        End Set
    End Property

    Dim _CBU_2_CUENTA As String
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    <Size(13)>
    Public Property CBU_2_CUENTA() As String
        Get
            Return _CBU_2_CUENTA
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Of String)("CBU_2_CUENTA", _CBU_2_CUENTA, Value)
        End Set
    End Property

    Dim _CBU_2_DV As String
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    <Size(1)>
    Public Property CBU_2_DV() As String
        Get
            Return _CBU_2_DV
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Of String)("CBU_2_DV", _CBU_2_DV, Value)
        End Set
    End Property
#End Region

#Region "Eventos"
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        If SecuritySystem.CurrentUserName <> "Admin" And IsNothing(Me.Franquiciado) Then
            Me.Franquiciado = Session.GetObjectByKey(Of Franquiciado)(SecuritySystem.CurrentUserId)
        End If
    End Sub
#End Region


End Class
