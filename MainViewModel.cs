using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFDemo
{
    public static class ObservableCollectionExtensions
    {
        public static void RemoveAll<T>(this ObservableCollection<T> collection, Func<T, bool> condition)
        {
            var itemsToRemove = collection.Where(condition).ToList();

            foreach (var item in itemsToRemove)
            {
                collection.Remove(item);
            }
        }

    }

    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<StatCardsViewModel> Cards { get; }
        private StatCardsViewModel _selectedCards;
        public StatCardsViewModel SelectedCards
        {
            get => _selectedCards;
            set
            {
                _selectedCards = value;
                OnPropertyChanged(nameof(SelectedCards));
            }
        }

        //private double _someAngle;
        //public double SomeAngle
        //{
        //    get => _someAngle;
        //    set { _someAngle = value; OnPropertyChanged(nameof(SomeAngle)); }
        //}

        //public class TaskItem
        //{
        //    public required string Title { get; set; }
        //    public bool IsCompleted { get; set; }
        //}

        //public ObservableCollection<TaskItem> Tasks { get; }
        //    = new ObservableCollection<TaskItem>();

        //private readonly ICollectionView _tasksView;
        //public ICollectionView TasksView => _tasksView;

        //private string _newItemText;
        //public string NewItemText
        //{
        //    get => _newItemText;
        //    set {
        //        _newItemText = value;
        //        OnPropertyChanged(nameof(NewItemText));
        //    }
        //}

        //public ICommand AddItemCommand { get; }
        //public ICommand DeleteCompletedCommand { get; }
        //public ICommand ShowAllCommand { get; }
        //public ICommand ShowActiveCommand { get; }
        //public ICommand ShowCompletedCommand { get; }
        public ICommand CardSelectedCommand { get; }

        public MainViewModel()
        {
            //AddItemCommand = new RelayCommand(AddItem);
            //DeleteCompletedCommand = new RelayCommand(RemoveItems);
            //ShowAllCommand = new RelayCommand(ShowAll);
            //ShowActiveCommand = new RelayCommand(ShowActive);
            //ShowCompletedCommand = new RelayCommand(ShowCompleted);
            //_tasksView = CollectionViewSource.GetDefaultView(Tasks);
            //_tasksView.Filter = FilterTasks;
            CardSelectedCommand = new RelayCommand<StatCardsViewModel>(card =>
            {
                SelectedCards = card;
            });
            Cards =
            [
                new(CardSelectedCommand)
                {
                    Title = "Users",
                    Value = 124,
                    Status = "OK",
                    StatusColor = Brushes.Green
                },
                new(CardSelectedCommand)
                {
                    Title = "Orders",
                    Value = 32,
                    Status = "Pending",
                    StatusColor = Brushes.Gold
                },
                new(CardSelectedCommand)
                {
                    Title = "Errors",
                    Value = 5,
                    Status = "Critical",
                    StatusColor = Brushes.Red
                }
            ];
        }

        //private void AddItem()
        //{
        //    if (!string.IsNullOrWhiteSpace(NewItemText))
        //    {
        //        Tasks.Add(new TaskItem { Title= NewItemText, IsCompleted = false});
        //        NewItemText = "";

        //    }
        //}

        //private enum FilterMode
        //{
        //    All,
        //    Active,
        //    Completed
        //}

        //private FilterMode _currentFilter = FilterMode.All;

        //private bool FilterTasks(object obj)
        //{
        //    if (obj is not TaskItem task)
        //        return false;

        //    return _currentFilter switch
        //    {
        //        FilterMode.All => true,
        //        FilterMode.Active => !task.IsCompleted,
        //        FilterMode.Completed => task.IsCompleted,
        //        _ => true
        //    };
        //}

        //private void RemoveItems()
        //{
        //    if (Tasks.Count > 0) {
        //        Tasks.RemoveAll(t => t.IsCompleted);
        //    }
        //    else
        //    {
        //        MessageBox.Show("No items to delete.");
        //    }
        //}

        //private void ShowAll()
        //{
        //    _currentFilter = FilterMode.All;
        //    _tasksView.Refresh();
        //}

        //private void ShowActive()
        //{
        //    _currentFilter = FilterMode.Active;
        //    _tasksView.Refresh();
        //}

        //private void ShowCompleted()
        //{
        //    _currentFilter = FilterMode.Completed;
        //    _tasksView.Refresh();
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name) =>        
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
