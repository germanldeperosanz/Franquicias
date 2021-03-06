﻿Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Security.ClientServer

' For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Web.WebApplication
Partial Public Class FranquiciasAspNetApplication
    Inherits WebApplication
    Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
    Private module3 As Franquicias.Module.FranquiciasModule
    Private module4 As Franquicias.Module.Web.FranquiciasAspNetModule

    Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
    Private securityStrategyComplex1 As DevExpress.ExpressApp.Security.SecurityStrategyComplex
    Private authenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard
    Private objectsModule As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
    Private chartModule As DevExpress.ExpressApp.Chart.ChartModule
    Private chartAspNetModule As DevExpress.ExpressApp.Chart.Web.ChartAspNetModule
    Private cloneObjectModule As DevExpress.ExpressApp.CloneObject.CloneObjectModule
    Private conditionalAppearanceModule As DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule
    Private dashboardsModule As DevExpress.ExpressApp.Dashboards.DashboardsModule
    Private dashboardsAspNetModule As DevExpress.ExpressApp.Dashboards.Web.DashboardsAspNetModule
    Private fileAttachmentsAspNetModule As DevExpress.ExpressApp.FileAttachments.Web.FileAttachmentsAspNetModule
    Private htmlPropertyEditorAspNetModule As DevExpress.ExpressApp.HtmlPropertyEditor.Web.HtmlPropertyEditorAspNetModule
    Private mapsAspNetModule As DevExpress.ExpressApp.Maps.Web.MapsAspNetModule
    Private pivotChartModuleBase As DevExpress.ExpressApp.PivotChart.PivotChartModuleBase
    Private pivotChartAspNetModule As DevExpress.ExpressApp.PivotChart.Web.PivotChartAspNetModule
    Private pivotGridModule As DevExpress.ExpressApp.PivotGrid.PivotGridModule
    Private pivotGridAspNetModule As DevExpress.ExpressApp.PivotGrid.Web.PivotGridAspNetModule
    Private reportsModuleV2 As DevExpress.ExpressApp.ReportsV2.ReportsModuleV2
    Private reportsAspNetModuleV2 As DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2
    Private stateMachineModule As DevExpress.ExpressApp.StateMachine.StateMachineModule
    Private validationModule As DevExpress.ExpressApp.Validation.ValidationModule
    Private validationAspNetModule As DevExpress.ExpressApp.Validation.Web.ValidationAspNetModule
    Private viewVariantsModule As DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule

#Region "Default XAF configuration options (https://www.devexpress.com/kb=T501418)"
    Shared Sub New()
		EnableMultipleBrowserTabsSupport = True
        DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor.AllowFilterControlHierarchy = True
        DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor.MaxFilterControlHierarchyDepth = 3
        DevExpress.ExpressApp.Web.Editors.ASPx.ASPxCriteriaPropertyEditor.AllowFilterControlHierarchyDefault = True
        DevExpress.ExpressApp.Web.Editors.ASPx.ASPxCriteriaPropertyEditor.MaxHierarchyDepthDefault = 3
		DevExpress.Persistent.Base.PasswordCryptographer.EnableRfc2898 = True
        DevExpress.Persistent.Base.PasswordCryptographer.SupportLegacySha512 = False
    End Sub
	Private Sub InitializeDefaults()
        LinkNewObjectToParentImmediately = False
        OptimizedControllersCreation = True
    End Sub
#End Region
    Public Sub New()
        InitializeComponent()
        InitializeDefaults()
    End Sub

    Protected Overrides Function CreateViewUrlManager() As IViewUrlManager
        Return New ViewUrlManager()
    End Function

    Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
        args.ObjectSpaceProvider = New SecuredObjectSpaceProvider(DirectCast(Me.Security, ISelectDataSecurityProvider), GetDataStoreProvider(args.ConnectionString, args.Connection), True)
        args.ObjectSpaceProviders.Add(New NonPersistentObjectSpaceProvider(TypesInfo, Nothing))
    End Sub
    Private Function GetDataStoreProvider(ByVal connectionString As String, ByVal connection As System.Data.IDbConnection) As IXpoDataStoreProvider
        Dim application As System.Web.HttpApplicationState = If((System.Web.HttpContext.Current IsNot Nothing), System.Web.HttpContext.Current.Application, Nothing)
        Dim dataStoreProvider As IXpoDataStoreProvider = Nothing
        If Not application Is Nothing AndAlso application("DataStoreProvider") IsNot Nothing Then
            dataStoreProvider = TryCast(application("DataStoreProvider"), IXpoDataStoreProvider)
        Else
		    dataStoreProvider = XPObjectSpaceProvider.GetDataStoreProvider(connectionString, connection, True)
            If Not application Is Nothing Then
                application("DataStoreProvider") = dataStoreProvider
            End If
        End If
        Return dataStoreProvider
    End Function
    Private Sub FranquiciasAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
        e.Updater.Update()
        e.Handled = True
#Else
        If System.Diagnostics.Debugger.IsAttached Then
            e.Updater.Update()
            e.Handled = True
        Else
            Dim message As String = "The application cannot connect to the specified database, " & _
				"because the database doesn't exist, its version is older " & _
				"than that of the application or its schema does not match " & _
				"the ORM data model structure. To avoid this error, use one " & _
				"of the solutions from the https://www.devexpress.com/kb=T367835 KB Article."

            If e.CompatibilityError IsNot Nothing AndAlso e.CompatibilityError.Exception IsNot Nothing Then
                message &= Constants.vbCrLf & Constants.vbCrLf & "Inner exception: " & e.CompatibilityError.Exception.Message
            End If
            Throw New InvalidOperationException(message)
        End If
#End If
    End Sub
    Private Sub InitializeComponent()
        Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
        Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
        Me.module3 = New Franquicias.Module.FranquiciasModule()
        Me.module4 = New Franquicias.Module.Web.FranquiciasAspNetModule()
        Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
        Me.securityStrategyComplex1 = New DevExpress.ExpressApp.Security.SecurityStrategyComplex()
        Me.securityStrategyComplex1.SupportNavigationPermissionsForTypes = False
        Me.authenticationStandard1 = New DevExpress.ExpressApp.Security.AuthenticationStandard()
        Me.objectsModule = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
        Me.chartModule = New DevExpress.ExpressApp.Chart.ChartModule()
        Me.chartAspNetModule = New DevExpress.ExpressApp.Chart.Web.ChartAspNetModule()
        Me.cloneObjectModule = New DevExpress.ExpressApp.CloneObject.CloneObjectModule()
        Me.conditionalAppearanceModule = New DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule()
        Me.dashboardsModule = New DevExpress.ExpressApp.Dashboards.DashboardsModule()
        Me.dashboardsAspNetModule = New DevExpress.ExpressApp.Dashboards.Web.DashboardsAspNetModule()
        Me.fileAttachmentsAspNetModule = New DevExpress.ExpressApp.FileAttachments.Web.FileAttachmentsAspNetModule()
        Me.htmlPropertyEditorAspNetModule = New DevExpress.ExpressApp.HtmlPropertyEditor.Web.HtmlPropertyEditorAspNetModule()
        Me.mapsAspNetModule = New DevExpress.ExpressApp.Maps.Web.MapsAspNetModule()
        Me.pivotChartModuleBase = New DevExpress.ExpressApp.PivotChart.PivotChartModuleBase()
        Me.pivotChartAspNetModule = New DevExpress.ExpressApp.PivotChart.Web.PivotChartAspNetModule()
        Me.pivotGridModule = New DevExpress.ExpressApp.PivotGrid.PivotGridModule()
        Me.pivotGridAspNetModule = New DevExpress.ExpressApp.PivotGrid.Web.PivotGridAspNetModule()
        Me.reportsModuleV2 = New DevExpress.ExpressApp.ReportsV2.ReportsModuleV2()
        Me.reportsAspNetModuleV2 = New DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2()
        Me.stateMachineModule = New DevExpress.ExpressApp.StateMachine.StateMachineModule()
        Me.validationModule = New DevExpress.ExpressApp.Validation.ValidationModule()
        Me.validationAspNetModule = New DevExpress.ExpressApp.Validation.Web.ValidationAspNetModule()
        Me.viewVariantsModule = New DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        ' 
        ' securityStrategyComplex1
        ' 
        Me.securityStrategyComplex1.Authentication = Me.authenticationStandard1
        Me.securityStrategyComplex1.RoleType = GetType(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyRole)
        Me.securityStrategyComplex1.UserType = GetType(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyUser)
        ' 
        ' securityModule1
        ' 
        Me.securityModule1.UserType = GetType(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyUser)
        ' 
        ' authenticationStandard1
        ' 
        Me.authenticationStandard1.LogonParametersType = GetType(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters)
        '
        ' dashboardsModule
        '
        Me.dashboardsModule.DashboardDataType = GetType(DevExpress.Persistent.BaseImpl.DashboardData)
        '
        ' reportsModuleV2
        '
        Me.reportsModuleV2.EnableInplaceReports = True
        Me.reportsModuleV2.ReportDataType = GetType(DevExpress.Persistent.BaseImpl.ReportDataV2)
        Me.reportsModuleV2.ShowAdditionalNavigation = False
        Me.reportsAspNetModuleV2.ReportViewerType = DevExpress.ExpressApp.ReportsV2.Web.ReportViewerTypes.HTML5
        Me.reportsModuleV2.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML
        '
        ' stateMachineModule
        '
        Me.stateMachineModule.StateMachineStorageType = GetType(DevExpress.ExpressApp.StateMachine.Xpo.XpoStateMachine)
        ' 
        ' FranquiciasAspNetApplication
        ' 
        Me.ApplicationName = "Franquicias"
        Me.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema
        Me.Modules.Add(Me.module1)
        Me.Modules.Add(Me.module2)
        Me.Modules.Add(Me.module3)
        Me.Modules.Add(Me.module4)
        Me.Modules.Add(Me.securityModule1)
        Me.Security = Me.securityStrategyComplex1
        Me.Modules.Add(Me.objectsModule)
        Me.Modules.Add(Me.chartModule)
        Me.Modules.Add(Me.chartAspNetModule)
        Me.Modules.Add(Me.cloneObjectModule)
        Me.Modules.Add(Me.conditionalAppearanceModule)
        Me.Modules.Add(Me.dashboardsModule)
        Me.Modules.Add(Me.dashboardsAspNetModule)
        Me.Modules.Add(Me.fileAttachmentsAspNetModule)
        Me.Modules.Add(Me.htmlPropertyEditorAspNetModule)
        Me.Modules.Add(Me.mapsAspNetModule)
        Me.Modules.Add(Me.pivotChartModuleBase)
        Me.Modules.Add(Me.pivotChartAspNetModule)
        Me.Modules.Add(Me.pivotGridModule)
        Me.Modules.Add(Me.pivotGridAspNetModule)
        Me.Modules.Add(Me.reportsModuleV2)
        Me.Modules.Add(Me.reportsAspNetModuleV2)
        Me.Modules.Add(Me.stateMachineModule)
        Me.Modules.Add(Me.validationModule)
        Me.Modules.Add(Me.validationAspNetModule)
        Me.Modules.Add(Me.viewVariantsModule)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub
End Class

