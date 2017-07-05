using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CommandButton
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<ChildClass> myList { get; set; }
        public ChildClass child { get; set; }
        public ICommand RemoveAliasCommand
        {
            get
            {
                return new MyAddCommand(s => { this.RemoveChildren(s as Button); }, true);
            }
        }

        private void RemoveChildren(Button button)
        {
            Debug.WriteLine("remove");
        }

        public ICommand AddAliasCommand
        {
            get
            {
                return new MyAddCommand(s => { this.AddChildren(s as Button); }, true);
            }
        }

        private void AddChildren(Button button)
        {
            Debug.WriteLine("Add");
        }

        public MainPage()
        {
            this.InitializeComponent();
            ParentClass parent = new ParentClass();
            myList = parent.AliasValues;
            child = new ChildClass();
            this.DataContext = this;
        }

        private void RemoveAlias_Click(object sender, RoutedEventArgs e)
        {

        }
    }


    public class ParentClass
    {
        public ParentClass()
        {
            AliasValues = new ObservableCollection<ChildClass>();
            AliasValues.Add(new ChildClass() { Id = "0", MyAliasValue = "hello Id=0"});
            AliasValues.Add(new ChildClass() { Id = "1", MyAliasValue = "hello Id=1" });
            AliasValues.Add(new ChildClass() { Id = "2", MyAliasValue = "hello Id=2" });
            AliasValues.Add(new ChildClass() { Id = "3", MyAliasValue = "hello Id=3" });
            AliasValues.Add(new ChildClass() { Id = "4", MyAliasValue = "hello Id=4" });
        }

        public ObservableCollection<ChildClass> AliasValues { get; set; }

        public static void AddChildren(Button bt)
        {
            Debug.WriteLine("add");
        }

        public static void RemoveChildren(Button bt)
        {
            Debug.WriteLine("remove");
        }

    }

    public class ChildClass
    {
        //public ICommand AddAliasCommand
        //{
        //    get
        //    {
        //        return new MyAddCommand(s => { ParentClass.AddChildren(s as Button); }, true);
        //    }
        //}

        //public ICommand RemoveAliasCommand
        //{
        //    get
        //    {
        //        return new MyAddCommand(s => { ParentClass.RemoveChildren(s as Button); }, true);
        //    }
        //}


        public string Id { get; set; }

        public string MyAliasValue { get; set; }

    }


    public class MyAddCommand : ICommand
    {
        private Action<object> _action;
        private bool _canExecute;

        public event EventHandler CanExecuteChanged;

        public MyAddCommand(Action<object> action,bool canExecute)
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
}
