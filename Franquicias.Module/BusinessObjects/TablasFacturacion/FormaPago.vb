Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Validation
Imports System.ComponentModel

<DefaultClassOptions()>
<DefaultProperty("Nombre")>
Public Class FormaPago
    Inherits XPLiteObject

#Region "PK"
    Dim _IdFormaPago As Integer
    <Index(0)>
    <DevExpress.ExpressApp.Model.ModelDefault("Caption", "Id")>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Key(True)>
    Public Property IdFormaPago() As Integer
        Get
            Return _IdFormaPago
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(Of Integer)("IdFormaPago", _IdFormaPago, Value)
        End Set
    End Property
#End Region

#Region "Propiedades"
    Dim _Nombre As String
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Index(1)>
    <RuleRequiredField("ReglaRequerido.FormaPago.Nombre", DefaultContexts.Save, "Dato obligatorio")>
    <Size(30)>
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Of String)("Nombre", _Nombre, Value)
        End Set
    End Property
#End Region

#Region "Metodos"
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
#End Region

End Class
