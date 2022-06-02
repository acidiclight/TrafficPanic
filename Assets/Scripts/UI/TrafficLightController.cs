using System;
using Helpers;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace UI
{
    public class TrafficLightController : MonoBehaviour
    {
        private RectTransform rect;
        private bool isGreen;

        [Header("UI")]
        [SerializeField]
        private Image redLight;
        
        [SerializeField]
        private Image greenLight;

        public bool IsGreen
        {
            get => isGreen;
            set
            {
                if (isGreen == value) return;
                isGreen = value;
                UpdateLight();
            }
        }
        
        private void Awake()
        {
            Assert.IsNotNull(redLight);
            Assert.IsNotNull(greenLight);

            this.MustGetComponent(out rect);
        }

        private void UpdateLight()
        {
            redLight.enabled = !isGreen;
            greenLight.enabled = isGreen;
        }
    }
}