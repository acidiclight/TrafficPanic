using UnityEngine;
using UnityEngine.Assertions;

namespace Traffic
{
    [CreateAssetMenu(menuName = "ScriptableObject/Settings/Traffic Settings")]
    public class TrafficManagerSettings : ScriptableObject
    {
        [SerializeField]
        private Car[] carPool;


        public Car GetRandomCarPrefab()
        {
            Assert.IsTrue(carPool.Length > 0, "No cars available in the pool.");
            return carPool[Random.Range(0, carPool.Length - 1)];
        }
    }
}