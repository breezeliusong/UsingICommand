using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace HelloWorld
{
    public sealed class MyControl : Button
    {
        public MyControl()
        {
            this.DefaultStyleKey = typeof(MyControl);
        }

        public CornerRadius MyCorner
        {
            get { return (CornerRadius)GetValue(MyCornerProperty); }
            set { SetValue(MyCornerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyCorner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyCornerProperty =
            DependencyProperty.Register("MyCorner", typeof(CornerRadius), typeof(MyControl), new PropertyMetadata(null, new PropertyChangedCallback(OnConnerValueChanged)));

        private static void OnConnerValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MyControl btn = d as MyControl;
            if (!e.NewValue.Equals(e.OldValue))
            {
                btn.MyCorner = (CornerRadius)e.NewValue;
            }
        }
    }
}
