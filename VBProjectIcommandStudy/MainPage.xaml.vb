' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Public Sub New()
        Me.InitializeComponent()
        Dim class1 = New MyClass1()
        AliasValues = class1.AliasValues
        AddAliasCommand = class1.AddAliasCommand
        Me.DataContext = Me
    End Sub
    Public Property AddAliasCommand() As MyAddAliasCommand
        Get
            Return m_AddAliasCommand
        End Get
        Set
            m_AddAliasCommand = Value
        End Set
    End Property
    Private m_AddAliasCommand As MyAddAliasCommand
    Public Property AliasValues() As ObservableCollection(Of MyClass2)
        Get
            Return m_AliasValues
        End Get
        Set
            m_AliasValues = Value
        End Set
    End Property
    Private m_AliasValues As ObservableCollection(Of MyClass2)

End Class


Public Class MyClass1
    Public Property AliasValues() As ObservableCollection(Of MyClass2)
        Get
            Return m_AliasValues
        End Get
        Set
            m_AliasValues = Value
        End Set
    End Property
    Private m_AliasValues As ObservableCollection(Of MyClass2)
    Public Property AddAliasCommand() As MyAddAliasCommand
        Get
            Return m_AddAliasCommand
        End Get
        Set
            m_AddAliasCommand = Value
        End Set
    End Property
    Private m_AddAliasCommand As MyAddAliasCommand

    Public Sub New()
        Dim a As String
        Dim myclassg As New MyClass2()

        myclassg.MyAliasValue = "Hello first1"


        AliasValues = New ObservableCollection(Of MyClass2)()
        AddAliasCommand = New MyAddAliasCommand(Function(s)
                                                    Me.MyMethod(TryCast(s, Button))

                                                End Function, True)
        AliasValues.Add(New MyClass2() With {
            .MyAliasValue = "Hello first1",
            .AddAliasCommand = Me.AddAliasCommand,
            .Id = 0
        })
        AliasValues.Add(New MyClass2() With {
            .MyAliasValue = "Hello first2",
            .AddAliasCommand = Me.AddAliasCommand,
            .Id = 1
        })
        AliasValues.Add(New MyClass2() With {
            .MyAliasValue = "Hello first3",
            .AddAliasCommand = Me.AddAliasCommand,
            .Id = 2
        })
        AliasValues.Add(New MyClass2() With {
            .MyAliasValue = "Hello first4",
            .AddAliasCommand = Me.AddAliasCommand,
            .Id = 3
        })
        AliasValues.Add(New MyClass2() With {
            .MyAliasValue = "Hello first5",
            .AddAliasCommand = Me.AddAliasCommand,
            .Id = 4
        })
    End Sub

    Public Sub MyMethod(param As Button)
        If param.Name = "AddAlias" Then
            Dim num As Integer = AliasValues.Count
            AliasValues.Add(New MyClass2() With {
                .MyAliasValue = "Hello first",
                .AddAliasCommand = Me.AddAliasCommand,
                .Id = num
            })
        Else
            AliasValues.RemoveAt(CInt(param.Tag))
        End If

    End Sub
End Class


Public Class MyClass2
    Inherits DependencyObject
    Implements INotifyPropertyChanged
    Public Shared ReadOnly MyAliasValueProperty As DependencyProperty = DependencyProperty.Register("MyAliasValue", GetType(String), GetType(MyClass2), New PropertyMetadata(Nothing))
    Public Property MyAliasValue() As String
        Get
            Return DirectCast(GetValue(MyAliasValueProperty), String)
        End Get
        Set
            Me.SetValue(MyAliasValueProperty, Value)
        End Set
    End Property

    Private Event INotifyPropertyChanged_PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property AddAliasCommand() As ICommand
        Get
            Return m_AddAliasCommand
        End Get
        Set
            m_AddAliasCommand = Value
        End Set
    End Property
    Private m_AddAliasCommand As ICommand
    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set
            m_Id = Value
        End Set
    End Property
    Private m_Id As Integer
End Class



Public Class MyAddAliasCommand
    Implements ICommand
    Public Event CanExecuteChanged As EventHandler
    Private Event ICommand_CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Private _action As Action(Of Object)
    Private _canExecute As Boolean

    Public Sub New(action As Action(Of Object), canExecute As Boolean)
        _action = action
        _canExecute = canExecute
    End Sub

    'Public Function CanExecute(parameter As Object) As Boolean
    '    Return _canExecute
    'End Function

    Public Sub Execute(parameter As Object)
        _action(parameter)
    End Sub

    Private Function ICommand_CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return _canExecute
    End Function

    Private Sub ICommand_Execute(parameter As Object) Implements ICommand.Execute
        _action(parameter)
    End Sub
End Class

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
