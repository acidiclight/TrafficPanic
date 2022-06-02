using UnityEngine;

namespace Sanity
{
    public abstract class Holder<T> : ScriptableObject
    {
        private T heldValue;

        public T Value
        {
            get => heldValue;
            set => heldValue = value;
        }
    }
}