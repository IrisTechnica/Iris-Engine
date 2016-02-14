using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Utils
{
    public static class PropertyHelper
    {
        private readonly static Dictionary<string, PropertyChangedEventArgs> cached = new Dictionary<string, PropertyChangedEventArgs>(512);
        private static PropertyChangedEventArgs factory(string name)
        {
            PropertyChangedEventArgs e;
            if (cached.TryGetValue(name, out e))
                return e;
            e = new PropertyChangedEventArgs(name);
            cached[name] = e;
            return e;
        }

        public static void Raise<TSource>(this TSource source, PropertyChangedEventHandler handler, [CallerMemberName] string propertyName = null)
            where TSource : class, INotifyPropertyChanged
        {
            if (handler != null)
                handler(source, factory(propertyName));
        }

        public static void Raise<TSource>(this TSource source, PropertyChangedEventHandler handler, params string[] propertyNames)
            where TSource : class, INotifyPropertyChanged
        {
            if (handler == null)
                return;
            foreach (var x in propertyNames)
                handler(source, factory(x));
        }

        public static bool Setter<TSource, T>(this TSource source, PropertyChangedEventHandler handler, ref T target, T value, [CallerMemberName] string propertyName = null)
            where TSource : class, INotifyPropertyChanged
            where T : class
        {
            if (Interlocked.CompareExchange(ref target, value, target) != value)
            {
                Raise(source, handler, propertyName);
                return true;
            }
            return false;
        }

        public static bool Setter<TSource, T>(this TSource source, PropertyChangedEventHandler handler, ref T target, ref T value, [CallerMemberName] string propertyName = null)
            where TSource : class, INotifyPropertyChanged
        {
            if (EqualHelper.Equals(target, value))
            {
                target = value;
                return false;
            }
            target = value;
            Raise(source, handler, propertyName);
            return true;
        }

        public static bool Setter<TSource>(this TSource source, PropertyChangedEventHandler handler, ref string target, string value, [CallerMemberName] string propertyName = null)
            where TSource : class, INotifyPropertyChanged
        {
            if (!string.Equals(Interlocked.CompareExchange(ref target, value, target), value, StringComparison.Ordinal))
            {
                Raise(source, handler, propertyName);
                return true;
            }
            return false;
        }
    }
}
