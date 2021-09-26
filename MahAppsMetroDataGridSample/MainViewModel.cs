using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using MahAppsMetroDataGridSample.Models;

namespace MahAppsMetroDataGridSample
{
    public class MainViewModel
    {
        private readonly DispatcherTimer _timer;
        private readonly Random _random;

        public MainViewModel()
        {
            _random = new Random(int.MaxValue);

            _timer = new DispatcherTimer(DispatcherPriority.Background, Application.Current.Dispatcher)
            {
                Interval = TimeSpan.FromMilliseconds(100)
            };
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (AlbumCollection.Count >= 5000)
            {
                Stop();
            }

            var newAlbum = new Album
            {
                Title = SampleData.Albums.ElementAt(_random.Next(0, SampleData.Albums.Count - 1)).Title,
                Genre = SampleData.Genres.ElementAt(_random.Next(0, SampleData.Genres.Count - 1)),
                Price = (decimal)_random.NextDouble() * _random.Next(1, 100),
                Artist = SampleData.Artists.ElementAt(_random.Next(0, SampleData.Artists.Count - 1)),
                AlbumArtUrl = "/Content/Images/placeholder.gif"
            };

            _ = Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => { AlbumCollection.Add(newAlbum); }));
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public ObservableCollection<Album> AlbumCollection { get; } = new ObservableCollection<Album>();
    }
}