using Core;
using UnityEngine;
using UnityEngine.Assertions;

namespace Traffic
{
    public class TrafficSpawner : MonoBehaviour
    {
        private float timeSinceLastSpawn;
        private float spawnInterval;
        
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

        private void Start()
        {
            spawnInterval = Random.Range(1, 9);
        }

        private void Update()
        {
            if (gameState.Value.CurrentState != CurrentGameState.Playing)
                return;
            
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
            {
                timeSinceLastSpawn += Time.deltaTime;
                if (timeSinceLastSpawn >= spawnInterval)
                {
                    timeSinceLastSpawn = 0;
                    SpawnCar();
                }
            }


        }

        private void SpawnCar()
        {
            // Pick a random prefab from the traffic manager.
            var carPrefab = trafficSettings.GetRandomCarPrefab();
            
            // Instantiate the car.
            var instance = Instantiate(carPrefab, this.transform);
            
            // Be sure to set the driving direction.
            instance.SetDrivingDirection(drivingDirection);
            
            // Report the car to the game.
            this.gameState.Value.ReportNewCar(instance);
        }
    }
}