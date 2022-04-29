// Unity Helpers
//
// This is a class containing several helper methods that make it easier
// to do a lot of repetitive Unity boilerplate without needing to actually
// write that code more than once. I'm lazy, so that's ideal.
//
// Mostly these are my own implementations of helper methods provided in
// Socially Distant and other commercial games I work on, that don't tie into
// any of their APIs, but that are *extremely* useful and you'd be shooting yourself
// in the foot by not using.

using UnityEngine;
using UnityEngine.Assertions;

namespace Helpers
{
    public static class UnityHelpers
    {
        public static void MustGetComponent<T>(this MonoBehaviour component, out T result) where T : class
        {
            var requiredComponent = component.GetComponent<T>();
            Assert.IsNotNull(requiredComponent,
                $"{component.GetType().Name} on {component.gameObject.name} requires component {typeof(T).Name} which was not found on the GameObject.");

            result = requiredComponent;

        }
    }
}