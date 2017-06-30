using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloWorld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var class1 = new MyClass1();
            AliasValues=class1.AliasValues;
            AddAliasCommand = class1.AddAliasCommand;
            this.DataContext = this;
        }
        public MyAddAliasCommand AddAliasCommand { get; set; }
        public ObservableCollection<MyClass2> AliasValues { get; set; }
    }

    public class MyClass1
    {
        public ObservableCollection<MyClass2> AliasValues { get; set; }
        public MyAddAliasCommand AddAliasCommand { get; set; }

        public MyClass1()
        {
            AliasValues = new ObservableCollection<MyClass2>();
            AddAliasCommand = new MyAddAliasCommand(s=> { this.MyMethod(s as Button); } , true);
            AliasValues.Add(new MyClass2() { MyAliasValue = "Hello first1", AddAliasCommand = this.AddAliasCommand ,Id=0});
            AliasValues.Add(new MyClass2() { MyAliasValue = "Hello first2", AddAliasCommand = this.AddAliasCommand ,Id=1});
            AliasValues.Add(new MyClass2() { MyAliasValue = "Hello first3" , AddAliasCommand = this.AddAliasCommand ,Id=2});
            AliasValues.Add(new MyClass2() { MyAliasValue = "Hello first4", AddAliasCommand = this.AddAliasCommand ,Id=3});
            AliasValues.Add(new MyClass2() { MyAliasValue = "Hello first5", AddAliasCommand = this.AddAliasCommand, Id =4 });
        }

        public void MyMethod(Button  param)
        {
            if(param.Name== "AddAlias")
            {
                int num = AliasValues.Count;
                AliasValues.Add(new MyClass2() { MyAliasValue = "Hello first", AddAliasCommand = this.AddAliasCommand, Id = num });
            }
            else
            {
                AliasValues.RemoveAt((int)param.Tag);
            }

        }
    }

    public class MyAddAliasCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> _action;
        private bool _canExecute;

        public MyAddAliasCommand(Action<object> action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }


    public class MyClass2 : DependencyObject, INotifyPropertyChanged
    {
        public static readonly DependencyProperty MyAliasValueProperty = DependencyProperty.Register("MyAliasValue", typeof(string), typeof(MyClass2), new PropertyMetadata(null));
        public string MyAliasValue
        {
            get { return (string)GetValue(MyAliasValueProperty); }
            set { this.SetValue(MyAliasValueProperty, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddAliasCommand { get; set; }
        public int Id { get; set; }
    }
}
