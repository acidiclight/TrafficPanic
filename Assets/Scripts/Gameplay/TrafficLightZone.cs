using System;
using System.Collections.Generic;
using CustomInputs;
using Helpers;
using Sanity;
using Traffic;
using UI;
using UnityEngine;
using UnityEngine.Assertions;

namespace Gameplay
{
    public class TrafficLightZone : MonoBehaviour
    {
        private bool isActive = true;
        private readonly List<Car> carsInArea = new List<Car>();
        private BoxCollider collider;
        private GameInputs gameInputs;
        private TrafficLightController hudUi;

        [Header("Dependencies")]
        [SerializeField]
        private PlayerHolder player;
        
        [Header("Level")]
        [SerializeField]
        private TrafficStopper stopper;
        
        private void Awake()
        {
            Assert.IsNotNull(player);
            Assert.IsNotNull(stopper);
            this.MustGetComponent(out collider);
            gameInputs = new GameInputs();
        }

        private void Start()
        {
            gameInputs.Enable();

            this.hudUi = player.Value.Hud.SpawnTrafficLightHud(this.transform);
        }

        private void OnDestroy()
        {
            gameInputs.Disable();

            Destroy(hudUi.gameObject);
            hudUi = null;
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
                car.SetAcceleration( 0);
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

        private void Update()
        {
            if (gameInputs.Main.ToggleTrafficLight.triggered)
            {
                Toggle();
            }

            if (hudUi == null)
                return;

            hudUi.IsGreen = !isActive;
        }

        private void Toggle()
        {
            isActive = !isActive;

            stopper.SetActive(isActive);
            
            if (isActive)
            {
                stopper.StopAllTraffic();
                foreach (var car in carsInArea)
                    car.SetAcceleration(0);
            }
            else
            {
                stopper.StartAllTraffic();
                foreach (var car in carsInArea)
                    car.SetAcceleration(1);
            }
        }
    }
}