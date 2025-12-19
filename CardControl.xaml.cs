using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for CardControl.xaml
    /// </summary>
    public partial class CardControl : UserControl
    {
        public CardControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                nameof(Title),
                typeof(string),
                typeof(CardControl),
                new PropertyMetadata(string.Empty)
                );

        public static readonly DependencyProperty CardBackgroundProperty =
            DependencyProperty.Register(
                nameof(CardBackground),
                typeof(Brush),
                typeof(CardControl),
                new PropertyMetadata(Brushes.White)
                );
        public static readonly DependencyProperty FontColorProperty =
            DependencyProperty.Register(
                nameof(FontColor),
                typeof(Brush),
                typeof(CardControl),
                new PropertyMetadata(Brushes.Black)
                );
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public Brush CardBackground
        {
            get => (Brush)GetValue(CardBackgroundProperty);
            set => SetValue(CardBackgroundProperty, value);
        }

        public Brush FontColor
        {
            get => (Brush)GetValue(FontColorProperty);
            set => SetValue(FontColorProperty, value);
        }
    }
}
