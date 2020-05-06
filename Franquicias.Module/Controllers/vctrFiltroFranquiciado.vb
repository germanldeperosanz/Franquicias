Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.Persistent.BaseImpl.PermissionPolicy

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class vctrFiltroFranquiciado
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' APLICA a los ListView el Filtro de la empresa logeada, una vez que se eligió.


        If SecuritySystem.CurrentUserName <> "Admin" And (TypeOf View Is ListView) AndAlso (View.ObjectTypeInfo.Implements(Of IFranquiciado)) Then
            CType(View, ListView).CollectionSource.Criteria("Filtro Franquiciado") = New BinaryOperator(
                 "Franquiciado.Oid", SecuritySystem.CurrentUserId, BinaryOperatorType.Equal)

            'ElseIf (TypeOf View Is ListView) AndAlso (View.ObjectTypeInfo.Implements(Of IFranquiciado)) And View.Id = "OrdenPublicidad_ListView" Then
            '    CType(View, ListView).CollectionSource.Criteria("Filtro Franquiciado") = New BinaryOperator(
            '         "Local.Franquiciado.OID", SecuritySystem.CurrentUserId, BinaryOperatorType.Equal)
        End If


    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        '''MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()

    End Sub
End Class
