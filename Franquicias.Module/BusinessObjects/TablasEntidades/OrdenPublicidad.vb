Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports System.ComponentModel
Imports DevExpress.ExpressApp

<DefaultProperty("Nombre")>
<DefaultClassOptions()>
Public Class OrdenPublicidad
    Inherits XPBaseObject
    Implements IFranquiciado

#Region "PK"
    Dim _IdOrdenPublicidad As Integer
    <Index(0)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Key(True)>
    Public Property IdOrdenPublicidad() As Integer
        Get
            Return _IdOrdenPublicidad
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(Of Integer)("IdOrdenPublicidad", _IdOrdenPublicidad, Value)
        End Set
    End Property
#End Region

#Region "Propiedades"
    Private _Nombre As String
    <Index(1)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            SetPropertyValue(Of String)("Nombre", _Nombre, value)
        End Set
    End Property

    Private _Local As Local
    <Association("Local-OrdenPublicidad")>
    <Index(2)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    Public Property Local() As Local
        Get
            Return _Local
        End Get
        Set(ByVal value As Local)
            SetPropertyValue(Of Local)("Local", _Local, value)
        End Set
    End Property

    Private _Franquiciado As Franquiciado
    <Association("Franquiciado-OrdenPublicidad")>
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

    Private _Material As Material
    <Index(5)>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    Public Property Material() As Material
        Get
            Return _Material
        End Get
        Set(ByVal value As Material)
            SetPropertyValue(Of Material)("Material", _Material, value)
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
