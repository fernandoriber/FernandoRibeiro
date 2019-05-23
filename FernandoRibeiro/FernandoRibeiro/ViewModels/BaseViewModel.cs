using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FernandoRibeiro.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public BaseViewModel()
        {
        }

        private string title = string.Empty;
        public const string TitlePropertyName = "Title";

        /// <summary>
        /// Gets or sets the "Title" property
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string subtitle = string.Empty;
        /// <summary>
        /// Gets or sets the "Subtitle" property
        /// </summary>
        public const string SubtitlePropertyName = "Subtitle";
        public string Subtitle
        {
            get { return subtitle; }
            set { SetProperty(ref subtitle, value); }
        }

        private string icon = null;
        /// <summary>
        /// Gets or sets the "Icon" of the viewmodel
        /// </summary>
        public const string IconPropertyName = "Icon";
        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        private bool isBusy;
        /// <summary>
        /// Gets or sets if VM is busy working
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged("IsBusy"); }
        }

        bool isNotBusy = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is not busy.
        /// </summary>
        /// <value><c>true</c> if this instance is not busy; otherwise, <c>false</c>.</value>
        public bool IsNotBusy
        {
            get { return isNotBusy; }
            private set { SetProperty(ref isNotBusy, value); }
        }

        private bool canLoadMore = true;
        /// <summary>
        /// Gets or sets if we can load more.
        /// </summary>
        public const string CanLoadMorePropertyName = "CanLoadMore";
        public bool CanLoadMore
        {
            get { return canLoadMore; }
            set { SetProperty(ref canLoadMore, value); }
        }

        protected bool SetProperty<T>(
            ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {


            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;

            if (onChanged != null)
                onChanged();

            OnPropertyChanged(propertyName);
            return true;
        }

        protected bool SetPropertyChanged<T>(ref T oldProperty, T newProperty, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(oldProperty, newProperty))
            {
                return false;
            }
            oldProperty = newProperty;
            ChangeProperty(propertyName);

            return true;
        }

        protected virtual void ChangeProperty([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void DisplayAlert(String title, String message, String cancel)
        {
            Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }
        protected Task<bool> DisplayAlert(String title, String message, String cancel, String accept)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
        /*public void DisplayAlert(ONErrorHandler error)
        {
            Application.Current.MainPage.DisplayAlert(error.Title, error.Msg, "OK");
        }*/
    }
}