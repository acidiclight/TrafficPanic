using System;
using Core;
using Traffic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Gameplay
{
    public class ScoreGiverZone : MonoBehaviour
    {
        [SerializeField]
        private GameStateHolder gameState;

        private void Awake()
        {
            Assert.IsNotNull(gameState);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == null)
                return;
            
            // Did a car enter our area?
            var car = other.gameObject.GetComponent<Car>();
            
            // If the car isn't crashed, then we can add points to the current score.
            if (car.IsCrashed)
                return;

            // TODO: Score should be determined by type of car.
            gameState.Value.AddPoints(50);
        }
    }
}