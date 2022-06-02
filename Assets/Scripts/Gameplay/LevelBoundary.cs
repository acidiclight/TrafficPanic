using System;
using Core;
using Traffic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Gameplay
{
    public class LevelBoundary : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField]
        private GameStateHolder gameSTateHolder;

        private void Awake()
        {
            Assert.IsNotNull(gameSTateHolder);
        }

        private void OnTriggerEnter(Collider other)
        {
            var otherObject = other.gameObject;
            var car = otherObject.GetComponent<Car>();

            if (car == null)
                return;
            
            // Tell the game that this car is effectively no longer real.
            this.gameSTateHolder.Value.RemoveCarFromLevel(car);
            
            // And destroy it.
            Destroy(car.gameObject);
        }
    }
}