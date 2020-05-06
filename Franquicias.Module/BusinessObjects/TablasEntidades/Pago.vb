Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation


<DefaultClassOptions()>
Public Class Pago
    Inherits XPBaseObject

    '#Region "PK"
    '    Dim _IdProvincia As Integer
    '    <Index(0)>
    '    <DevExpress.ExpressApp.Model.ModelDefault("Caption", "Id")>
    '    <RuleUniqueValue("ReglaUnicoValor.IdProvincia", DefaultContexts.Save, "Provincia ya existe.")>
    '    <VisibleInListView(True)>
    '    <VisibleInDetailView(True)>
    '    <Key()>
    '    Public Property IdProvincia() As Integer
    '        Get
    '            Return _IdProvincia
    '        End Get
    '        Set(ByVal Value As Integer)
    '            SetPropertyValue(Of Integer)("IdProvincia", _IdProvincia, Value)
    '        End Set
    '    End Property
    '#End Region

    '#Region "Propiedades"
    '    Dim _Nombre As String
    '    <VisibleInListView(True)>
    '    <VisibleInDetailView(True)>
    '    <Index(1)>
    '    <RuleRequiredField("ReglaRequerido.Provincia.Nombre", DefaultContexts.Save, "Dato obligatorio")>
    '    <Size(30)>
    '    Public Property Nombre() As String
    '        Get
    '            Return _Nombre
    '        End Get
    '        Set(ByVal Value As String)
    '            SetPropertyValue(Of String)("Nombre", _Nombre, Value)
    '        End Set
    '    End Property
    '#End Region

    '#Region "Eventos"
    '    Public Sub New(ByVal session As Session)
    '        MyBase.New(session)
    '    End Sub
    '    Public Overrides Sub AfterConstruction()
    '        MyBase.AfterConstruction()
    '        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    '    End Sub

    '#End Region
End Class
