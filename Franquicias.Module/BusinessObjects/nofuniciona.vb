'Imports System.ComponentModel
'Imports DevExpress.Xpo
'Imports DevExpress.Data.Filtering
'Imports DevExpress.ExpressApp
'Imports DevExpress.Persistent.Base
'Imports DevExpress.Persistent.Validation
'Imports DevExpress.ExpressApp.SystemModule
'Imports DevExpress.ExpressApp.ConditionalAppearance
'Imports DevExpress.ExpressApp.Editors
'Imports DevExpress.ExpressApp.Model

'Public Enum LocalBrutoNeto As Integer
'    Bruto = 1
'    Neto = 2
'End Enum

'' NOTA: Si el Local es Inhabilitado, la unica propiedad que se puede modificar es justamente HABILITADO
'<RuleIsReferenced("Local.Facturas", DefaultContexts.Delete, GetType(DPS_Factura), "Local", InvertResult:=True,
' CriteriaEvaluationBehavior:=PersistentCriteriaEvaluationBehavior.BeforeTransaction,
' CustomMessageTemplate:="Hay FACTURAS relacionadas con el Local.")>
'<RuleIsReferenced("Local.Pauta", DefaultContexts.Delete, GetType(Pauta), "Local", InvertResult:=True,
' CriteriaEvaluationBehavior:=PersistentCriteriaEvaluationBehavior.BeforeTransaction,
' CustomMessageTemplate:="Hay PAUTAS relacionadas con el Local.")>
'<RuleIsReferenced("Local.Imputacion", DefaultContexts.Delete, GetType(Imputacion), "Local", InvertResult:=True,
' CriteriaEvaluationBehavior:=PersistentCriteriaEvaluationBehavior.BeforeTransaction,
' CustomMessageTemplate:="Hay IMPUTACIONES CONTABLES relacionadas con el Local.")>
'<RuleIsReferenced("Local.EstimadoCostos", DefaultContexts.Delete, GetType(EstimadoCostos), "Local", InvertResult:=True,
' CriteriaEvaluationBehavior:=PersistentCriteriaEvaluationBehavior.BeforeTransaction,
' CustomMessageTemplate:="Hay ESTIMADOS relacionados con el Local.")>
'<RuleIsReferenced("Local.Horas", DefaultContexts.Delete, GetType(DPS_Hora), "Local", InvertResult:=True,
' CriteriaEvaluationBehavior:=PersistentCriteriaEvaluationBehavior.BeforeTransaction,
' CustomMessageTemplate:="Hay HORAS relacionadas con el Local.")>
'<RuleIsReferenced("Local.Fee", DefaultContexts.Delete, GetType(Fee), "Local", InvertResult:=True,
' CriteriaEvaluationBehavior:=PersistentCriteriaEvaluationBehavior.BeforeTransaction,
' CustomMessageTemplate:="Hay FEE'S relacionados con el Local.")>
'<Appearance("Local", TargetItems:="*;Habilitado", Criteria:="Habilitado='False'", Enabled:=False, FontColor:="Red")>
'<ListViewFilter("Habilitados", "[Habilitado] = True")>
'<ListViewFilter("Todos", "", True)>
'<ListViewFilter("Inhabilitados", "[Habilitado] = False")>
'<DefaultProperty("Nombre")>
'<DefaultClassOptions()>
'<DeferredDeletion(False)>
'Public Class Local
'    Inherits XPLiteObject
'    Private _IsNew As Boolean
'    Private P_VisiblePorPais As Boolean
'    Private P_VisiblePorcentajeImpuestoMunicipal As Boolean

'#Region "PK"
'    Dim _IdLocal As Integer
'    <Index(0)>
'    <VisibleInListView(True)>
'    <VisibleInDetailView(True)>
'    <DevExpress.ExpressApp.Model.ModelDefault("Caption", "Nº")>
'    <DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "{0:00000}")>
'    <DevExpress.ExpressApp.Model.ModelDefault("EditMask", "00000")>
'    <RuleUniqueValue("ReglaUnicoValor.Local.IdLocal", DefaultContexts.Save, "Local ya existe.")>
'    <RuleRange("ReglaRango.Local.IdLocal", DefaultContexts.Save, 1, 999999, "El ID del Local debe ser de 1 a 999999")>
'    <Key()>
'    Public Property IdLocal() As Integer
'        Get
'            Return _IdLocal
'        End Get
'        Set(ByVal Value As Integer)
'            SetPropertyValue(Of Integer)("IdLocal", _IdLocal, Value)
'        End Set
'    End Property
'#End Region

'#Region "Propiedades para validar"
'    <RuleFromBoolProperty("ReglaCuitUnico", DefaultContexts.Save, "CUIT ya existe", UsedProperties:="Cuit")>
'    <NonPersistent()>
'    <Browsable(False)>
'    Public ReadOnly Property CuitUnicoLocal() As Boolean
'        Get
'            Return ValidaCuitUnicoLocals(Cuit)
'        End Get
'    End Property
'    <RuleFromBoolProperty("ReglaValida.Local.CuitValido", DefaultContexts.Save, "CUIT invalido", UsedProperties:="Cuit")>
'    <NonPersistent()>
'    <Browsable(False)>
'    Public ReadOnly Property CuitValido() As Boolean
'        Get
'            'Return ValidaCuitArgentina(TipoDocumento, Cuit)
'            Return ValidaCuit.ValidaDocumentoPorPaisActual(TipoDocumento, Cuit)
'        End Get
'    End Property
'#End Region

'#Region "Propiedades"
'    Dim _Nombre As String
'    <Index(1)>
'    <VisibleInListView(True)>
'    <VisibleInDetailView(True)>
'    <RuleRequiredField("ReglaRequerido.Local.Nombre", DefaultContexts.Save, "Falta: Nombre Local")>
'    <Size(250)>
'    Public Property Nombre() As String
'        Get
'            Return _Nombre
'        End Get
'        Set(ByVal Value As String)
'            SetPropertyValue(Of String)("Nombre", _Nombre, Value)
'        End Set
'    End Property

'    Dim _TipoIva As TipoIva
'    <Index(4)>
'    <VisibleInListView(True)>
'    <VisibleInDetailView(True)>
'    <RuleRequiredField("ReglaRequerido.Local.TipoIva", DefaultContexts.Save, "Falta: Tipo Iva")>
'    Public Property TipoIva() As TipoIva
'        Get
'            Return _TipoIva
'        End Get
'        Set(ByVal Value As TipoIva)
'            SetPropertyValue(Of TipoIva)("TipoIva", _TipoIva, Value)
'        End Set
'    End Property
'    Dim _Cuit As String
'    <Index(5)>
'    <VisibleInListView(True)>
'    <VisibleInDetailView(True)>
'    <Size(20)>
'    <RuleRequiredField("ReglaRequerido.Local.Cuit", DefaultContexts.Save, "Falta: Número de documento")>
'    Public Property Cuit() As String
'        Get
'            Return _Cuit
'        End Get
'        Set(ByVal Value As String)
'            SetPropertyValue(Of String)("Cuit", _Cuit, Value)
'        End Set
'    End Property
'    Dim _Habilitado As Boolean
'    <Index(6)>
'    <VisibleInListView(True)>
'    <VisibleInDetailView(True)>
'    Public Property Habilitado() As Boolean
'        Get
'            Return _Habilitado
'        End Get
'        Set(ByVal Value As Boolean)
'            SetPropertyValue(Of Boolean)("Habilitado", _Habilitado, Value)
'        End Set
'    End Property
'    Dim _DatosGenerales As DatosGenerales
'    <VisibleInListView(False)>
'    <VisibleInDetailView(True)>
'    <DevExpress.ExpressApp.Model.ModelDefault("Caption", "Dirección, Mail, TE")>
'    <Aggregated(), ExpandObjectMembers(ExpandObjectMembers.Never)>
'    Public Property DatosGenerales() As DatosGenerales
'        Get
'            Return _DatosGenerales
'        End Get
'        Set(ByVal Value As DatosGenerales)
'            SetPropertyValue(Of DatosGenerales)("DatosGenerales", _DatosGenerales, Value)
'        End Set
'    End Property

'    Dim _PercibeIva As Boolean
'    <VisibleInListView(False)>
'    <VisibleInDetailView(True)>
'    <Appearance("ReglaRango.Local.PercibeIva.HidePorPais", TargetItems:="PercibeIva", Criteria:="P_VisiblePorPais ='False'", Visibility:=ViewItemVisibility.Hide, Context:="DetailView")>
'    Public Property PercibeIva() As Boolean
'        Get
'            Return _PercibeIva
'        End Get
'        Set(ByVal Value As Boolean)
'            SetPropertyValue(Of Boolean)("PercibeIva", _PercibeIva, Value)
'        End Set
'    End Property

'    Dim _CondicionPago As CondicionPago
'    <VisibleInListView(False)>
'    <VisibleInDetailView(True)>
'    Public Property CondicionPago() As CondicionPago
'        Get
'            Return _CondicionPago
'        End Get
'        Set(ByVal Value As CondicionPago)
'            SetPropertyValue(Of CondicionPago)("CondicionPago", _CondicionPago, Value)
'        End Set
'    End Property

'    Dim _Notas As String
'    <VisibleInDetailView(True), VisibleInListView(False), VisibleInLookupListView(False)>
'    <Size(4000)>
'    Public Property Notas() As String
'        Get
'            Return _Notas
'        End Get
'        Set(ByVal Value As String)
'            SetPropertyValue(Of String)("Notas", _Notas, Value)
'        End Set
'    End Property

'    Dim _GranContribuyente As Boolean
'    <VisibleInListView(False)>
'    <VisibleInDetailView(True)>
'    Public Property GranContribuyente As Boolean
'        Get
'            Return _GranContribuyente
'        End Get
'        Set(value As Boolean)
'            SetPropertyValue(Of Boolean)("GranContribuyente", _GranContribuyente, value)
'        End Set
'    End Property

'#End Region

'    '#Region "Propiedades de Auditoria"
'    '    Dim _UsuarioAlta As IPermissionPolicyUser
'    '    <VisibleInListView(False)>
'    '    <VisibleInDetailView(True)>
'    '    <DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")>
'    '    Public Property UsuarioAlta() As IPermissionPolicyUser
'    '        Get
'    '            Return _UsuarioAlta
'    '        End Get
'    '        Set(ByVal Value As IPermissionPolicyUser)
'    '            SetPropertyValue(Of IPermissionPolicyUser)("UsuarioAlta", _UsuarioAlta, Value)
'    '        End Set
'    '    End Property
'    '    Dim _FechaAlta As DateTime
'    '    <VisibleInListView(False)>
'    '    <VisibleInDetailView(True)>
'    '    <DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")>
'    '    Public Property FechaAlta() As DateTime
'    '        Get
'    '            Return _FechaAlta
'    '        End Get
'    '        Set(ByVal Value As DateTime)
'    '            SetPropertyValue(Of DateTime)("FechaAlta", _FechaAlta, Value)
'    '        End Set
'    '    End Property

'    '#End Region


'#Region "Colecciones"
'    Public ReadOnly Property Locales() As XPCollection(Of Local)
'        Get
'            Return GetCollection(Of Local)("Locales")
'        End Get
'    End Property

'#End Region

'#Region "Funciones"
'    Public Function ObtenerPrimerLibre() As Integer
'        Dim _MaxCli As Local = Nothing
'        Dim _NuevoId As Integer = 1

'        'Dim ds As DevExpress.Xpo.DB.SelectedData

'        ' Ejemplo de uso de SQL
'        '_NuevoId = Me.Session.ExecuteScalar("SELECT MAX(IdLocal) FROM Local WHERE IdLocal <> 999 AND IdLocal <> 99999")
'        'LocalMessageBox.ShowLocalMessage(_NuevoId, vbOKOnly, "", MyApplicationHelper.XafApplication)

'        'ds = Me.Session.ExecuteQuery("Select * from Local")
'        'For Each _row As SelectStatementResultRow In ds.ResultSet(0).Rows
'        '  LocalMessageBox.ShowLocalMessage(_row.Values(0).ToString(), vbOKOnly, "", MyApplicationHelper.XafApplication)
'        '  LocalMessageBox.ShowLocalMessage(_row.Values(1).ToString(), vbOKOnly, "", MyApplicationHelper.XafApplication)
'        '  LocalMessageBox.ShowLocalMessage(_row.Values(2).ToString(), vbOKOnly, "", MyApplicationHelper.XafApplication)
'        'Next

'        ' Ejemplo de uso de SQL
'        '_NuevoId = Me.Session.ExecuteScalar("SELECT MAX(IdLocal) FROM Local WHERE IdLocal <> 999 AND IdLocal <> 99999")
'        '_NuevoId = _NuevoId + 1
'        ' Me.Nombre = Me.Session.ExecuteScalar("SELECT Nombre FROM Local WHERE IdLocal = 1")

'        ' Defino un criterio de filtrado para ser aplicado a la clase Local
'        Dim criCli As CriteriaOperator = CriteriaOperator.Parse("IdLocal <> 999 AND IdLocal <> 9999 AND IdLocal <> 99999")

'        ' Defino la coleccion de Locals,aplicandole el filtro
'        Using colCli As New XPCollection(Of Local)(Session, criCli)
'            ' Recorro la coleccion de Locals
'            For Each _Local In colCli
'                _MaxCli = _Local
'            Next
'        End Using

'        ' Verifica que no sea nulo, sino es el primer Local
'        If Not IsNothing(_MaxCli) Then
'            _NuevoId = _MaxCli.IdLocal + 1
'        End If

'        Return _NuevoId

'    End Function
'    Public Function ValidaCuitUnicoLocals(ByVal _Cuit As String) As Boolean

'        ' Defino un criterio de filtrado para ser aplicado a la clase Locals
'        Dim criCli As CriteriaOperator = CriteriaOperator.Parse("Cuit = ?", _Cuit)

'        ' Defino la coleccion de Locals,aplicandole el filtro
'        Using colCli As New XPCollection(Of Local)(Session, criCli)

'            '  Leo el Parametro de Administracion
'            If MyHelperParametrosAdministracion.ParametrosAdministracion.PermiteCuitDuplicadoEnLocals = True Then
'                Return True
'            Else
'                If (_IsNew And colCli.Count = 1) Or (Not _IsNew And colCli.Count > 1) Then
'                    Return False
'                Else
'                    Return True
'                End If
'            End If

'        End Using

'        Return False

'        'Falta resolver el caso en el que se modifica el cuit de un Local ingresando un cuit ya existente. Actualmente permitiria hacer esta operacion.

'    End Function
'#End Region


'#Region "Eventos"
'    Public Sub New(ByVal session As Session)
'        MyBase.New(session)
'    End Sub
'    Protected Overrides Sub OnSaving()
'        With Me
'            '' Si es NO HABILITADO y la fecha de baja esta vacia
'            'If .Habilitado = False And .UsuarioBaja Is Nothing Then
'            '    .FechaBaja = Date.Now
'            '    .UsuarioBaja = Session.GetObjectByKey(Of Usuario)(SecuritySystem.CurrentUserId).Empleado
'            'End If

'            '' Si es HABILITADO y la fecha de baja NO esta vacia
'            'If .Habilitado = True And Not .UsuarioBaja Is Nothing Then
'            '    .FechaBaja = Nothing
'            '    .UsuarioBaja = Nothing
'            'End If


'        End With

'        MyBase.OnSaving()

'    End Sub
'    Public Overrides Sub AfterConstruction()

'        MyBase.AfterConstruction()

'        _IsNew = Me.IdLocal = 0
'        'Obtengo de la clase Local, el Primer ID Libre
'        IdLocal = ObtenerPrimerLibre()

'        ' Obtengo del Parametro de Administracion el Tipo de IVA por defecto
'        TipoIva = Me.Session.GetObjectByKey(Of TipoIva)(MyHelperParametrosAdministracion.ParametrosAdministracion.TipoIva_x_Defecto.IdTipoIva)

'        PercibeIva = False

'        'FechaAlta = Date.Now
'        'UsuarioAlta = Session.GetObjectByKey(Of Usuario)(SecuritySystem.CurrentUserId).Empleado
'        Habilitado = True

'        'MinimoFCE = 0
'        GranContribuyente = False

'    End Sub
'    Protected Overrides Sub OnDeleting()
'        MyBase.OnDeleting()

'        If Not IsNothing(Me.DatosGenerales) Then
'            Me.DatosGenerales.Delete()
'        End If

'    End Sub
'    Protected Overrides Sub OnSaved()
'        MyBase.OnSaved()
'        _IsNew = False
'    End Sub
'    Protected Overrides Sub OnLoading()
'        MyBase.OnLoading()

'    End Sub
'#End Region

'End Class
