using System.Collections.Generic;
using Helpers;
using Traffic;
using UnityEngine;

namespace Gameplay
{
    public class TrafficStopper : MonoBehaviour
    {
        private readonly List<Car> carsInArea = new List<Car>();
        private BoxCollider collider;
        private bool isActive = true;
        
        private void Awake()
        {
            this.MustGetComponent(out collider);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == null)
                return;

            var car = other.gameObject.GetComponent<Car>();
            if (car == null)
                return;

            this.carsInArea.Add(car);
            
            if (isActive)
                car.StopCar();
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == null)
                return;

            var car = other.gameObject.GetComponent<Car>();
            if (car == null)
                return;

            this.carsInArea.Remove(car);
        }

        public void SetActive(bool shouldBeActive)
        {
            isActive = shouldBeActive;
        }

        public void StopAllTraffic()
        {
            foreach (var car in carsInArea)
            {
                car.StopCar();
            }
        }

        public void StartAllTraffic()
        {
            foreach (var car in carsInArea)
            {
                car.SetAcceleration(1);
            }
        }
    }
}