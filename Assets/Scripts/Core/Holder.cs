using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// A <see cref="ScriptableObject"/> that contains a single, shared instance of a particular class.
    /// Singletons are evil and stupid so use this instead.
    /// </summary>
    /// <typeparam name="T">The type of object held within the holder.</typeparam>
    public abstract class Holder<T> : ScriptableObject where T : class
    {
        /// <summary>
        /// Gets or sets the object contained in the holder.
        /// </summary>
        public T Value { get; set; }
    }
}