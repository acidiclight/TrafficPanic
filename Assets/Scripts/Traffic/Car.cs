using System;
using Core;
using Helpers;
using UnityEngine;
using UnityEngine.Assertions;

namespace Traffic
{
    public class Car : MonoBehaviour
    {
        private Rigidbody rigidBody;

        [SerializeField]
        private GameStateHolder gameState;

        [Header("Attributes")]
        [SerializeField]
        private float speed = 20;

        [SerializeField]
        private Vector3 driveDirection;
        
        private void Awake()
        {
            Assert.IsNotNull(gameState);
            this.MustGetComponent(out rigidBody);
        }

        private void FixedUpdate()
        {
            this.rigidBody.AddForce(this.driveDirection * speed);
        }

        public void SetDrivingDirection(Vector3 drivingDirection)
        {
            this.driveDirection = drivingDirection.normalized;
        }
    }
}