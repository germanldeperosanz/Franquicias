Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports System.Math
Imports AfipServices
Imports System.ComponentModel
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.ConditionalAppearance
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.Persistent.BaseImpl
Imports System.Xml
Imports System.Text
Imports System.IO
Imports DevExpress.ExpressApp.Xpo

Public Enum enumEstadoFactura
    Emitida = 1
    AutorizadaAfip = 2
    CanceladaParcial = 3
    CanceladaTotal = 4
    Anulada = 5
End Enum
<ListViewFilter("Año Actual", "GetYear([FechaReferencia]) = GetYear(LocalDateTimeToday())", Index:=0)>
<ListViewFilter("Todos", "", True, Index:=1)>
<ListViewFilter("Mes Actual", "GetYear([FechaReferencia]) = GetYear(LocalDateTimeToday()) AND GetMonth([FechaReferencia]) = GetMonth(LocalDateTimeToday())", Index:=2)>
<ListViewFilter("Año Anterior", "GetYear([FechaReferencia]) = GetYear(LocalDateTimeToday()) - 1", Index:=3)>
<System.ComponentModel.DisplayName("Facturas, Debitos y Creditos")>
<DefaultClassOptions()>
<DefaultProperty("NumeroReferencia")>
Public Class Factura
    Inherits XPLiteObject
    Implements IFranquiciado

    'Implements iFactura
    'Implements iFacturaFE
#Region "PK"
    Dim _IdFactura As Integer
    <Key(True)>
    Public Property IdDFactura() As Integer
        Get
            Return _IdFactura
        End Get
        Set(ByVal value As Integer)
            SetPropertyValue(Of Integer)("IdFactura", _IdFactura, value)
        End Set
    End Property
#End Region

#Region "Propiedades"

    Private _AAAAMM As String
    <VisibleInListView(True)>
    <VisibleInDetailView(False)>
    <Size(6)>
    Public Property AAAAMM As String
        Get
            Return Format(Year(FechaReferencia), "0000") & Format(Month(FechaReferencia), "00")
        End Get
        Set(ByVal value As String)
            SetPropertyValue(Of String)("AAAAMM", _AAAAMM, value)
        End Set
    End Property

    Private _ComprobanteACancelar As Factura
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property ComprobanteACancelar As Factura
        Get
            Return _ComprobanteACancelar
        End Get
        Set(ByVal value As Factura)
            SetPropertyValue(Of Factura)("ComprobanteACancelar", _ComprobanteACancelar, value)
        End Set
    End Property

    Dim _FechaReferencia As DateTime
    <DevExpress.ExpressApp.Model.ModelDefault("Caption", "Fecha")>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    Public Property FechaReferencia() As DateTime
        Get
            Return _FechaReferencia
        End Get
        Set(ByVal value As DateTime)
            SetPropertyValue(Of DateTime)("FechaReferencia", _FechaReferencia, value)
        End Set
    End Property

    Dim _FechaVencimiento As DateTime
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property FechaVencimiento() As DateTime
        Get
            Return _FechaVencimiento
        End Get
        Set(ByVal value As DateTime)
            SetPropertyValue(Of DateTime)("FechaVencimiento", _FechaVencimiento, value)
        End Set
    End Property

    Dim _TipoReferencia As TipoReferencia
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <DevExpress.ExpressApp.Model.ModelDefault("Caption", "TR")>
    Public Property TipoReferencia() As TipoReferencia
        Get
            Return _TipoReferencia
        End Get
        Set(ByVal value As TipoReferencia)
            SetPropertyValue(Of TipoReferencia)("TipoReferencia", _TipoReferencia, value)
        End Set
    End Property

    Dim _NumeroReferencia As String
    <Size(13)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <DevExpress.ExpressApp.Model.ModelDefault("Caption", "N° Referencia")>
    Public Property NumeroReferencia() As String
        Get
            Return _NumeroReferencia
        End Get
        Set(ByVal value As String)
            SetPropertyValue(Of String)("NumeroReferencia", _NumeroReferencia, value)
        End Set
    End Property

    Dim _DatoFacturacion As DatoFacturacion
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    Public Property DatoFacturacion() As DatoFacturacion
        Get
            Return _DatoFacturacion
        End Get
        Set(ByVal value As DatoFacturacion)
            SetPropertyValue(Of DatoFacturacion)("DatoFacturacion", _DatoFacturacion, value)
        End Set
    End Property

    'Private _TipoAsiento As TipoAsiento
    '<DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")>
    '<VisibleInListView(True)>
    '<VisibleInDetailView(True)>
    '<DevExpress.ExpressApp.Model.ModelDefault("Caption", "TA")>
    'Public Property TipoAsiento() As TipoAsiento
    '    Get
    '        Return _TipoAsiento
    '    End Get
    '    Set(ByVal value As TipoAsiento)
    '        SetPropertyValue(Of TipoAsiento)("TipoAsiento", _TipoAsiento, value)
    '    End Set
    'End Property

    'Dim _Asiento As Asiento
    '<VisibleInListView(True)>
    '<VisibleInDetailView(True)>
    '<DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")>
    '<Aggregated()>
    '<ExpandObjectMembers(ExpandObjectMembers.Never)>
    '<DevExpress.ExpressApp.Model.ModelDefault("Caption", "N° Asiento")>
    'Public Property Asiento() As Asiento
    '    Get
    '        Return _Asiento
    '    End Get
    '    Set(ByVal value As Asiento)
    '        SetPropertyValue(Of Asiento)("Asiento", _Asiento, value)
    '    End Set
    'End Property

    Dim _Cai As String
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Size(14)>
    Public Property Cai() As String
        Get
            Return _Cai
        End Get
        Set(ByVal value As String)
            SetPropertyValue(Of String)("Cai", _Cai, value)
        End Set
    End Property

    Dim _FechaVencimientoCai As DateTime
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property FechaVencimientoCai() As DateTime
        Get
            Return _FechaVencimientoCai
        End Get
        Set(ByVal value As DateTime)
            SetPropertyValue(Of DateTime)("FechaVencimientoCai", _FechaVencimientoCai, value)
        End Set
    End Property

    Dim _Local As Local
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <DevExpress.ExpressApp.Model.ModelDefault("Caption", "Local")>
    <Association("Local-Factura")>
    Public Property Local() As Local
        Get
            Return _Local
        End Get
        Set(ByVal value As Local)
            SetPropertyValue(Of Local)("Local", _Local, value)
        End Set
    End Property

    Private _Franquiciado As Franquiciado
    <Association("Franquiciado-Factura")>
    <Index(3)>
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

    Dim _Estado As enumEstadoFactura
    <Appearance("Factura.Pintar.Estado1", FontColor:="Blue", Criteria:="Estado = 1", FontStyle:=Drawing.FontStyle.Bold)>
    <Appearance("Factura.Pintar.Estado2", FontColor:="Green", Criteria:="Estado = 2", FontStyle:=Drawing.FontStyle.Bold)>
    <Appearance("Factura.Pintar.Estado5", FontColor:="Red", Criteria:="Estado = 5", FontStyle:=Drawing.FontStyle.Bold)>
    <DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    Public Property Estado As enumEstadoFactura
        Get
            Return _Estado
        End Get
        Set(ByVal value As enumEstadoFactura)
            SetPropertyValue(Of enumEstadoFactura)("Estado", _Estado, value)
        End Set
    End Property

    Dim _FormaPago As FormaPago
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property FormaPago() As FormaPago
        Get
            Return _FormaPago
        End Get
        Set(ByVal value As FormaPago)
            SetPropertyValue(Of FormaPago)("FormaPago", _FormaPago, value)
        End Set
    End Property

    Dim _IdLoteFEX As Long
    <VisibleInListView(False)>
    <VisibleInDetailView(False)>
    <VisibleInLookupListView(False)>
    Public Property IdLoteFEX() As Long
        Get
            Return _IdLoteFEX
        End Get
        Set(ByVal value As Long)
            SetPropertyValue(Of Long)("IdLoteFEX", _IdLoteFEX, value)
        End Set
    End Property

#End Region



#Region "Propiedades ReadOnly"
    <VisibleInListView(False)>
    <VisibleInDetailView(False)>
    Public ReadOnly Property TieneCai() As Boolean
        Get

            If Cai Is Nothing Then
                Return False
            Else
                If Cai = "" Or Cai = "00000000000000" Or Len(Cai) < 14 Then
                    Return False
                Else
                    Return True
                End If
            End If
        End Get
    End Property

#End Region

#Region "Funciones"

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
