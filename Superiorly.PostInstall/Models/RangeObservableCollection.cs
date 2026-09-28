using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Superiorly.PostInstall.Models;

public sealed class RangeObservableCollection<T> : ObservableCollection<T>
{
    public void AddRange(IEnumerable<T> items)
    {
        var list = items as IList<T> ?? items.ToList();
        if (list.Count == 0) return;
        CheckReentrancy();
        foreach (var item in list) Items.Add(item);
        OnPropertyChanged(new PropertyChangedEventArgs("Count"));
        OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    public void Reset(IEnumerable<T> items)
    {
        var list = items as IList<T> ?? items.ToList();
        CheckReentrancy();
        Items.Clear();
        foreach (var item in list) Items.Add(item);
        OnPropertyChanged(new PropertyChangedEventArgs("Count"));
        OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
}
