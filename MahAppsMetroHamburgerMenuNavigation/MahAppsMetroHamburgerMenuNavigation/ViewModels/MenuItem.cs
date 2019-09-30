using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using JetBrains.Annotations;
using MahApps.Metro.Controls;
using MahAppsMetroHamburgerMenuNavigation.Mvvm;

namespace MahAppsMetroHamburgerMenuNavigation.ViewModels
{
    internal class MenuItem : HamburgerMenuItem, INotifyPropertyChanged
    {
        private object _icon;
        private string _text;
        private bool _isEnabled = true;
        private DelegateCommand _command;
        private Uri _navigationDestination;

        public object Icon
        {
            get { return this._icon; }
            set { this.SetProperty(ref this._icon, value); }
        }

        public string Text
        {
            get { return this._text; }
            set { this.SetProperty(ref this._text, value); }
        }

        public bool IsEnabled
        {
            get { return this._isEnabled; }
            set { this.SetProperty(ref this._isEnabled, value); }
        }

        public ICommand Command
        {
            get { return this._command; }
            set { this.SetProperty(ref this._command, (DelegateCommand)value); }
        }

        public Uri NavigationDestination
        {
            get { return this._navigationDestination; }
            set { this.SetProperty(ref this._navigationDestination, value); }
        }

        public bool IsNavigation => this._navigationDestination != null;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Checks if a property already matches a desired value.  Sets the property and
        /// notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers that
        /// support CallerMemberName.</param>
        /// <returns>True if the value was changed, false if the existing value matched the
        /// desired value.</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}