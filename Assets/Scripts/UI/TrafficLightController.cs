using System;
using Helpers;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace UI
{
    public class TrafficLightController : MonoBehaviour
    {
        private Camera cam;
        private Transform associatedTransform;
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

        private void Start()
        {
            UpdateLight();
            
            cam = Camera.main;
            Assert.IsNotNull(cam);
        }

        private void UpdateLight()
        {
            redLight.enabled = !isGreen;
            greenLight.enabled = isGreen;
        }

        private void Update()
        {
            if (associatedTransform is null) return;

            var parent = rect.parent as RectTransform;
            var worldPos = associatedTransform.position;
            var screenPos = cam.WorldToScreenPoint(worldPos);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, screenPos, cam, out var actualPos);

            rect.anchoredPosition = actualPos;

        }

        public void AssociateWithLevelObject(Transform levelObject)
        {
            this.associatedTransform = levelObject;
        }
    }
}