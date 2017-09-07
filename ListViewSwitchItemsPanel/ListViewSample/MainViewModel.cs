using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ListViewSample.Annotations;

namespace ListViewSample
{
  public enum ListViewMode
  {
    Standard,
    Tile
  }

  public class SimpleItem
  {
    public string Text { get; set; }

    public override string ToString()
    {
      return Text;
    }
  }

  public class MainViewModel : INotifyPropertyChanged
  {
    public MainViewModel()
    {
      this.SimpleItems = new ObservableCollection<SimpleItem>(new[]
      {
        new SimpleItem() {Text = "Item 1"},
        new SimpleItem() {Text = "Item 2"},
        new SimpleItem() {Text = "Item 3"},
        new SimpleItem() {Text = "Item 4"},
        new SimpleItem() {Text = "Item 5"},
      });
    }

    public ObservableCollection<SimpleItem> SimpleItems { get; set; }

    private ListViewMode _listViewMode;

    public ListViewMode ListViewMode
    {
      get { return _listViewMode; }
      set
      {
        if (value == _listViewMode) return;
        _listViewMode = value;
        OnPropertyChanged();
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}