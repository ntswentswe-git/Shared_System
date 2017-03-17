Imports DevExpress
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Win.Templates
Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Win.SystemModule
Imports DevExpress.ExpressApp.Win.Templates.ActionContainers
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Docking
Imports DevExpress.XtraBars.Ribbon

Partial Public Class MainForm2
    Inherits MainFormTemplateBase
    Implements IDockManagerHolder, ISupportClassicToRibbonTransform

    Public Overloads Property FormStyle() As RibbonFormStyle Implements ISupportClassicToRibbonTransform.FormStyle
        Get
            Return MyBase.FormStyle
        End Get
        Set(value As RibbonFormStyle)
            MyBase.FormStyle = value
        End Set
    End Property

    Public Overloads ReadOnly Property ISupportClassicToRibbonTransform_RibbonOptions() As IModelOptionsRibbon Implements ISupportClassicToRibbonTransform.RibbonOptions
        Get
            Return MyBase.RibbonOptions
        End Get
    End Property

    Public Overrides Sub SetSettings(ByVal modelTemplate As IModelTemplate)
        MyBase.SetSettings(modelTemplate)
        Navigation.Model = TemplatesHelper.GetNavBarCustomizationNode()
        formStateModelSynchronizerComponent.Model = GetFormStateNode()
        modelSynchronizationManager.ModelSynchronizableComponents.Add(Navigation)
    End Sub
    Protected Overridable Sub InitializeImages()
        BarMdiChildrenListItem.Glyph = ImageLoader.Instance.GetImageInfo("Action_WindowList").Image
        BarMdiChildrenListItem.LargeGlyph = ImageLoader.Instance.GetLargeImageInfo("Action_WindowList").Image
        barSubItemPanels.Glyph = ImageLoader.Instance.GetImageInfo("Action_Navigation").Image
        barSubItemPanels.LargeGlyph = ImageLoader.Instance.GetLargeImageInfo("Action_Navigation").Image
    End Sub
    Public Sub New()
        InitializeComponent()
        InitializeImages()
        UpdateMdiModeDependentProperties()
        DocumentManager.BarAndDockingController = mainBarAndDockingController
        DocumentManager.MenuManager = mainBarManager
        BarManager.ForceLinkCreate()
    End Sub
    Public ReadOnly Property ClassicStatusBar() As Bar
        Get
            Return _statusBar
        End Get
    End Property
    Public ReadOnly Property DockPanelNavigation() As DockPanel
        Get
            Return dockPanelNavigation_Renamed
        End Get
    End Property
    Public ReadOnly Property DockManager() As DockManager Implements IDockManagerHolder.DockManager
        Get
            Return mainDockManager
        End Get
    End Property
    Protected Overrides Sub UpdateMdiModeDependentProperties()
        MyBase.UpdateMdiModeDependentProperties()
        Dim isMdi As Boolean = UIType = UIType.StandardMDI OrElse UIType = UIType.TabbedMDI
        viewSitePanel.Visible = Not isMdi
        If isMdi Then
            barSubItemWindow.Visibility = BarItemVisibility.Always
            BarMdiChildrenListItem.Visibility = BarItemVisibility.Always
        Else
            barSubItemWindow.Visibility = BarItemVisibility.Never
            BarMdiChildrenListItem.Visibility = BarItemVisibility.Never
        End If
    End Sub
    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)
        If ModelTemplate IsNot Nothing AndAlso (Not String.IsNullOrEmpty(ModelTemplate.DockManagerSettings)) Then
            Dim stream As New MemoryStream(Encoding.UTF8.GetBytes(ModelTemplate.DockManagerSettings))
            DockManager.SerializationOptions.RestoreDockPanelsText = False
            DockManager.RestoreLayoutFromStream(stream)
        End If
    End Sub
    Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
        If ModelTemplate IsNot Nothing Then
            Dim stream As New MemoryStream()
            DockManager.SaveLayoutToStream(stream)
            ModelTemplate.DockManagerSettings = Encoding.UTF8.GetString(stream.ToArray())
        End If
        MyBase.OnClosing(e)
    End Sub
    Private Sub mainBarManager_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainBarManager.Disposed
        If Me.mainBarManager IsNot Nothing Then
            RemoveHandler mainBarManager.Disposed, AddressOf mainBarManager_Disposed
        End If
        modelSynchronizationManager.ModelSynchronizableComponents.Remove(BarManager)
        Me.BarManager = Nothing
        Me.mainBarManager = Nothing
        Me._mainMenuBar = Nothing
        Me._statusBar = Nothing
        Me.standardToolBar = Nothing
        Me.barDockControlBottom = Nothing
        Me.barDockControlLeft = Nothing
        Me.barDockControlRight = Nothing
        Me.barDockControlTop = Nothing
    End Sub
End Class
