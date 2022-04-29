using System;
using Core;
using UnityEngine;
using UnityEngine.Assertions;

namespace Traffic
{
    public class TrafficSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameStateHolder gameState;
        
        [SerializeField]
        private TrafficManagerSettings trafficSettings;

        [SerializeField]
        private Vector3 drivingDirection;

        [SerializeField]
        private Vector3 carDetectionRange;
        
        private void Awake()
        {
            Assert.IsNotNull(gameState);
            Assert.IsNotNull(trafficSettings);
        }

        private void Update()
        {
            // Check for nearby cars. Can't spawn a car if there's already one nearby, otherwise that'll cause a traffic accident
            // and unintentionally cause a Game Over.
            var overlappingObjects = Physics.OverlapBox(this.transform.position, this.carDetectionRange);
            var canSpawn = true;

            // Don't use LINQ, it's slow.
            foreach (var collider in overlappingObjects)
            {
                if (collider.gameObject.GetComponent<Car>() != null)
                {
                    canSpawn = false;
                    break;
                }
            }

            if (canSpawn)
                SpawnCar();


        }

        private void SpawnCar()
        {
            // Pick a random prefab from the traffic manager.
            var carPrefab = trafficSettings.GetRandomCarPrefab();
            
            // Instantiate the car.
            var instance = Instantiate(carPrefab, this.transform);
            
            // Be sure to set the driving direction.
            instance.SetDrivingDirection(drivingDirection);
        }
    }
}