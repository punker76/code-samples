using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;
using JetBrains.Annotations;
using MahAppsMetroDataGridSample.Models;

namespace MahAppsMetroDataGridSample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DispatcherTimer timer;
        private Random random;

        public MainViewModel()
        {
            random = new Random(Int32.MaxValue);
            timer = new DispatcherTimer(DispatcherPriority.Background, Application.Current.Dispatcher);
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (AlbumCollection.Count >= 5000)
            {
                Stop();
            }
            var newAlbum = new Album
            {
                Title = SampleData.Albums.ElementAt(random.Next(0, SampleData.Albums.Count - 1)).Title,
                Genre = SampleData.Genres.ElementAt(random.Next(0, SampleData.Genres.Count - 1)),
                Price = (decimal) random.NextDouble()*random.Next(1, 100),
                Artist = SampleData.Artists.ElementAt(random.Next(0, SampleData.Artists.Count - 1)),
                AlbumArtUrl = "/Content/Images/placeholder.gif"
            };
            Action action = () => { AlbumCollection.Add(newAlbum); };
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(action));
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public ObservableCollection<Album> AlbumCollection { get; } = new ObservableCollection<Album>();
    }
}