using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace WPFDemo
{
    public class StatCardsViewModel : INotifyPropertyChanged
    {
        private string _title;
        private int _value;
        private string _status;
        private Brush _statusColor;

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }
        public int Value
        {
            get => _value;
            set { _value = value; OnPropertyChanged(); }
        }
        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }
        public Brush StatusColor
        {
            get => _statusColor;
            set { _statusColor = value; OnPropertyChanged(); }
        }

        public ICommand ClickCommand { get; }

        public StatCardsViewModel(ICommand clickCommand)
        {
            ClickCommand = clickCommand;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
