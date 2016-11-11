Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Controls
Imports Vintasoft.WpfTwain
Imports Vintasoft.WpfTwain.ImageEncoders

''' <summary>
''' Interaction logic for PdfSaveSettingsForm.xaml
''' </summary>
Partial Public Class PdfSaveSettingsWindow
    Inherits Window

#Region "Fields & properties"

    Private _saveAllImages As Boolean = False
    Public ReadOnly Property SaveAllImages() As Boolean
        Get
            Return _saveAllImages
        End Get
    End Property

    Private _multiPage As Boolean = True
    Public ReadOnly Property MultiPage() As Boolean
        Get
            Return _multiPage
        End Get
    End Property

    Private _pdfACompatible As Boolean = True
    Public ReadOnly Property PdfACompatible() As Boolean
        Get
            Return _pdfACompatible
        End Get
    End Property

    Private _pdfAuthor As String = String.Empty
    Public ReadOnly Property PdfAuthor() As String
        Get
            Return _pdfAuthor
        End Get
    End Property

    Private _pdfTitle As String = String.Empty
    Public ReadOnly Property PdfTitle() As String
        Get
            Return _pdfTitle
        End Get
    End Property

    Private _compression As PdfImageCompression = PdfImageCompression.Auto
    Public ReadOnly Property Compression() As PdfImageCompression
        Get
            Return _compression
        End Get
    End Property

    Private _jpegQuality As Integer = 90
    Public ReadOnly Property JpegQuality() As Integer
        Get
            Return _jpegQuality
        End Get
    End Property

#End Region



#Region "Constructor"

    Public Sub New(ByVal owner As Window, ByVal isFileExist As Boolean)
        InitializeComponent()

        Me.Owner = owner

        If Not isFileExist Then
            rbCreateNewDocument.IsChecked = True
            rbAddToDocument.IsEnabled = False
        End If
    End Sub

#End Region



#Region "Methods"

    Private Sub bOk_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        _saveAllImages = CBool(rbSaveAllImages.IsChecked)

        _multiPage = CBool(rbAddToDocument.IsChecked)
        _pdfACompatible = CBool(chkPdfACompatible.IsChecked)
        _pdfAuthor = txtPdfAuthor.Text
        _pdfTitle = txtPdfTitle.Text

        If CBool(rbComprNone.IsChecked) Then
            _compression = PdfImageCompression.None
        ElseIf CBool(rbComprCCITT.IsChecked) Then
            _compression = PdfImageCompression.CcittFax
        ElseIf CBool(rbComprLzw.IsChecked) Then
            _compression = PdfImageCompression.LZW
        ElseIf CBool(rbComprJpeg.IsChecked) Then
            _compression = PdfImageCompression.JPEG
            _jpegQuality = jpegQualityNumericUpDown.Value
        ElseIf CBool(rbComprZip.IsChecked) Then
            _compression = PdfImageCompression.ZIP
        ElseIf CBool(rbComprAuto.IsChecked) Then
            _compression = PdfImageCompression.Auto
        End If

        DialogResult = True
    End Sub

    Private Sub EnableJpegCompressionQuality(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not Me.IsVisible Then
            Return
        End If

        gbJpegCompression.IsEnabled = True
    End Sub

    Private Sub DisableJpegCompressionQuality(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not Me.IsVisible Then
            Return
        End If

        gbJpegCompression.IsEnabled = False
    End Sub

    Private Sub bCancel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        DialogResult = False
        Close()
    End Sub

#End Region

End Class
