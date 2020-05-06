Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl.PermissionPolicy

<DefaultClassOptions()>
Public Class Franquiciado
    Inherits PermissionPolicyUser
    Implements IFranquiciado


#Region "Propiedades"
    Private _Franquiciado As Franquiciado
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
#End Region

#Region "Colecciones"
    <Association("Franquiciado-Local"), DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property Locales() As XPCollection(Of Local)
        Get
            Return GetCollection(Of Local)("Locales")
        End Get
    End Property

    <Association("Franquiciado-Factura"), DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property Facturas() As XPCollection(Of Factura)
        Get
            Return GetCollection(Of Factura)("Facturas")
        End Get
    End Property

    <Association("Franquiciado-OrdenPublicidad"), DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property OrdenesPublicidad() As XPCollection(Of OrdenPublicidad)
        Get
            Return GetCollection(Of OrdenPublicidad)("OrdenesPublicidad")
        End Get
    End Property

    <Association("Franquiciado-DatoFacturacion"), DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property DatosFacturacion() As XPCollection(Of DatoFacturacion)
        Get
            Return GetCollection(Of DatoFacturacion)("DatosFacturacion")
        End Get
    End Property
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
