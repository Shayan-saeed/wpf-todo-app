using System.Windows;
using System.Windows.Controls;

namespace WPFDemo
{
    public partial class MyView : UserControl
    {
        public MyView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SetTextProperty =
            DependencyProperty.Register(
                "SetText",
                typeof(string),
                typeof(MyView),
                new PropertyMetadata("", OnSetTextChanged)
            );

        public string SetText
        {
            get => (string)GetValue(SetTextProperty);
            set => SetValue(SetTextProperty, value);
        }

        private static void OnSetTextChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var control = d as MyView;
            control.TextBlockDisplay.Text = e.NewValue?.ToString();
        }
    }
}
