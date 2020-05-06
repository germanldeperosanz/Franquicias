Imports System.ComponentModel
Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp

<DefaultClassOptions()>
<DefaultProperty("ReferenciaDPS")>
<DevExpress.ExpressApp.Model.ModelDefault("AllowDelete", "False")>
<DevExpress.ExpressApp.Model.ModelDefault("AllowAdd", "False")>
Public Class TipoReferencia
    Inherits XPLiteObject

#Region "PK"
    Dim _IdTipoReferencia As Integer
    <DevExpress.ExpressApp.Model.ModelDefault("Caption", "Id")>
    <VisibleInListView(False)>
    <VisibleInDetailView(False)>
    <Key(True)>
    Public Property IdTipoReferencia() As Integer
        Get
            Return _IdTipoReferencia
        End Get
        Set(ByVal value As Integer)
            SetPropertyValue(Of Integer)("IdTipoReferencia", _IdTipoReferencia, value)
        End Set
    End Property
#End Region

#Region "Propiedades"
    Dim _CodigoAFIP As Integer
    <DevExpress.ExpressApp.Model.ModelDefault("Caption", "AFIP")>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Index(0)>
    Public Property CodigoAFIP() As Integer
        Get
            Return _CodigoAFIP
        End Get
        Set(ByVal value As Integer)
            SetPropertyValue(Of Integer)("CodigoAFIP", _CodigoAFIP, value)
        End Set
    End Property
    Dim _ReferenciaDPS As String
    <DevExpress.ExpressApp.Model.ModelDefault("Caption", "DPS")>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Index(1)>
    <Size(2)>
    Public Property ReferenciaDPS() As String
        Get
            Return _ReferenciaDPS
        End Get
        Set(ByVal value As String)
            SetPropertyValue(Of String)("ReferenciaDPS", _ReferenciaDPS, value)
        End Set
    End Property
    Dim _Nombre As String
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Index(2)>
    <Size(80)>
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            SetPropertyValue(Of String)("Nombre", _Nombre, value)
        End Set
    End Property
    Dim _TipoReferenciaDeudor As Boolean
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property TipoReferenciaDeudor() As Boolean
        Get
            Return _TipoReferenciaDeudor
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue(Of Boolean)("TipoReferenciaDeudor", _TipoReferenciaDeudor, value)
        End Set
    End Property
    Dim _AplicaIVAVentas As Boolean
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property AplicaIVAVentas() As Boolean
        Get
            Return _AplicaIVAVentas
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue(Of Boolean)("AplicaIVAVentas", _AplicaIVAVentas, value)
        End Set
    End Property
    Dim _AplicaIVACompras As Boolean
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property AplicaIVACompras() As Boolean
        Get
            Return _AplicaIVACompras
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue(Of Boolean)("AplicaIVACompras", _AplicaIVACompras, value)
        End Set
    End Property
    Dim _TipoReferenciaCompra As Boolean
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property TipoReferenciaCompra() As Boolean
        Get
            Return _TipoReferenciaCompra
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue(Of Boolean)("TipoReferenciaCompra", _TipoReferenciaCompra, value)
        End Set
    End Property
    Dim _Letra As String
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    <Size(1)>
    Public Property Letra() As String
        Get
            Return _Letra
        End Get
        Set(ByVal value As String)
            SetPropertyValue(Of String)("Letra", _Letra, value)
        End Set
    End Property
    Dim _TipoReferenciaOtros As Boolean
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property TipoReferenciaOtros() As Boolean
        Get
            Return _TipoReferenciaOtros
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue(Of Boolean)("TipoReferenciaOtros", _TipoReferenciaOtros, value)
        End Set
    End Property
    Dim _SignoDeudor As Decimal
    <DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "{0:n0}")>
    <DevExpress.ExpressApp.Model.ModelDefault("EditMask", "n0")>
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property SignoDeudor() As Decimal
        Get
            Return _SignoDeudor
        End Get
        Set(ByVal value As Decimal)
            SetPropertyValue(Of Decimal)("SignoDeudor", _SignoDeudor, value)
        End Set
    End Property
    Dim _SignoAcreedor
    <DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "{0:n0}")>
    <DevExpress.ExpressApp.Model.ModelDefault("EditMask", "n0")>
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property SignoAcreedor() As Decimal
        Get
            Return _SignoAcreedor
        End Get
        Set(ByVal value As Decimal)
            SetPropertyValue(Of Decimal)("SignoAcreedor", _SignoAcreedor, value)
        End Set
    End Property
    Dim _SolicitaCAE As Boolean
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property SolicitaCAE() As Boolean
        Get
            Return _SolicitaCAE
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue(Of Boolean)("SolicitaCAE", _SolicitaCAE, value)
        End Set
    End Property
    Dim _EsDebito As Boolean
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property EsDebito() As Boolean
        Get
            Return _EsDebito
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue(Of Boolean)("EsDebito", _EsDebito, value)
        End Set
    End Property
    Dim _EsCredito As Boolean
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property EsCredito() As Boolean
        Get
            Return _EsCredito
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue(Of Boolean)("EsCredito", _EsCredito, value)
        End Set
    End Property

    Dim _FCE As Boolean
    <VisibleInListView(False)>
    <VisibleInDetailView(True)>
    Public Property FCE() As Boolean
        Get
            Return _FCE
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue(Of Boolean)("FCE", _FCE, value)
        End Set
    End Property

#End Region

#Region "Asociaciones"
    <Association("TipoIva-TipoReferenciaVenta")>
    Public ReadOnly Property TiposIvaVenta() As XPCollection(Of TipoIva)
        Get
            Return GetCollection(Of TipoIva)("TiposIvaVenta")
        End Get
    End Property
    '<Association("TipoReferencia-NumeradorFacturaNegocioTipoReferencia")>
    'Public ReadOnly Property Numeradores() As XPCollection(Of NumeradorFacturaNegocioTipoReferencia)
    '    Get
    '        Return GetCollection(Of NumeradorFacturaNegocioTipoReferencia)("Numeradores")
    '    End Get
    'End Property
#End Region

#Region "Eventos"
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
    End Sub
#End Region

End Class
