using System;
using System.Linq.Expressions;

namespace Utils
{
    class EqualHelper
    {
        /// <summary>
        /// 2つの値型が等価かどうか判定します。
        /// </summary>
        public static bool ValueEquals<T>(T x, T y) where T : struct => Inner<T>.ValueEquals(ref x, ref y);
        /// <summary>
        /// 2つのオブジェクトが等価かどうか判定します。
        /// </summary>
        public static bool Equals<T>(T x, T y) => Inner<T>.Equals(ref x, ref y);
        /// <summary>
        /// オブジェクトの<see cref="object.GetHashCode"/>を取得します。
        /// オブジェクトがnullの場合、0を返します。
        /// </summary>
        public static int TryGetHashCode<T>(T value) => Inner<T>.TryGetHashCode(ref value);

        struct Inner<T>
        {
            private delegate bool EqualsFunc(ref T x, ref T y);
            private readonly static EqualsFunc equals;
            private readonly static bool IsClass = typeof(T).IsClass;

            static Inner()
            {
                if (typeof(IEquatable<T>).IsAssignableFrom(typeof(T)))
                {
                    var _equals = typeof(IEquatable<T>).GetMethod(nameof(IEquatable<T>.Equals), new[] { typeof(T) });
                    if (_equals != null)
                    {
                        var x = Expression.Parameter(typeof(T).MakeByRefType());
                        var y = Expression.Parameter(typeof(T).MakeByRefType());
                        equals = Expression.Lambda<EqualsFunc>(Expression.Call(x, _equals, y), x, y).Compile();
                    }
                }
                if (equals == null)
                    equals = (ref T x, ref T y) => x.Equals(y);
            }

            public static bool Equals(ref T x, ref T y)
            {
                if (IsClass)
                {
                    // 参照型の場合
                    if (ReferenceEquals(x, y))
                        return true;
                    if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                        return false;
                }
                return equals(ref x, ref y);
            }

            public static bool ValueEquals(ref T x, ref T y) => equals(ref x, ref y);

            public static int TryGetHashCode(ref T value)
            {
                if (IsClass)
                    return ReferenceEquals(value, null) ? 0 : value.GetHashCode();
                return value.GetHashCode();
            }
        }
    }
}
