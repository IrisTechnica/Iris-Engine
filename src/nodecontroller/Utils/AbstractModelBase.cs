using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Utils
{
    /// <summary>
    /// Abstract base for view-model classes that need to implement INotifyPropertyChanged.
    /// </summary>
    public abstract class AbstractModelBase : INotifyPropertyChanged
    {
#if DEBUG
        private static int nextObjectId = 0;
        private int objectDebugId = nextObjectId++;

        public int ObjectDebugId
        {
            get
            {
                return objectDebugId;
            }
        }
#endif //  DEBUG

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Event Methods

        protected virtual void Raise([CallerMemberName] string propertyName = null)
        {
            this.Raise(this.PropertyChanged, propertyName);
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);

            return true;
        }

        #endregion


        private PropertyChangedEventArgs factory(string name)
        {
            PropertyChangedEventArgs e;
            if (cached.TryGetValue(name, out e))
                return e;
            e = new PropertyChangedEventArgs(name);
            cached[name] = e;
            return e;
        }

        /// <summary>
        /// Event raised to indicate that a property value has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Chached PropertyChangedEventArgs
        /// </summary>
        private readonly Dictionary<string, PropertyChangedEventArgs> cached = new Dictionary<string, PropertyChangedEventArgs>(512);
    }
}
