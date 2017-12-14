﻿namespace DataCare.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A generic object comparerer that would only use object's reference,
    /// ignoring any <see cref="IEquatable{T}"/> or <see cref="object.Equals(object)"/>  overrides.
    /// </summary>
    public class ObjectReferenceEqualityComparer<T> : EqualityComparer<T>
        where T : class
    {
        private static IEqualityComparer<T> defaultComparer;

        public static new IEqualityComparer<T> Default
        {
            get { return defaultComparer ?? (defaultComparer = new ObjectReferenceEqualityComparer<T>()); }
        }

        #region IEqualityComparer<T> Members

        public override bool Equals(T x, T y)
        {
            Contract.Ensures(Contract.Result<bool>() == x.Equals(y));

            return ReferenceEquals(x, y);
        }

        public override int GetHashCode(T obj)
        {
            ////return ((object)obj).GetHashCode();
            return RuntimeHelpers.GetHashCode(this);
        }

        #endregion IEqualityComparer<T> Members
    }
}