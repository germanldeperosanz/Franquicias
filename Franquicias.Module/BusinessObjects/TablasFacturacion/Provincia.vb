Imports System.ComponentModel
Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Validation

<DefaultClassOptions()>
<DefaultProperty("Nombre")>
Public Class Provincia
    Inherits XPLiteObject

#Region "PK"
    Dim _IdProvincia As Integer
    <Index(0)>
    <DevExpress.ExpressApp.Model.ModelDefault("Caption", "Id")>
    <RuleUniqueValue("ReglaUnicoValor.IdProvincia", DefaultContexts.Save, "Provincia ya existe.")>
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Key()>
    Public Property IdProvincia() As Integer
        Get
            Return _IdProvincia
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(Of Integer)("IdProvincia", _IdProvincia, Value)
        End Set
    End Property
#End Region

#Region "Propiedades"
    Dim _Nombre As String
    <VisibleInListView(True)>
    <VisibleInDetailView(True)>
    <Index(1)>
    <RuleRequiredField("ReglaRequerido.Provincia.Nombre", DefaultContexts.Save, "Dato obligatorio")>
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
