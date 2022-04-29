using System;
using Core;
using Helpers;
using UnityEngine;
using UnityEngine.Assertions;

namespace Traffic
{
    public class Car : MonoBehaviour
    {
        private float groundCastDistance = 5;
        private bool grounded;
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

        private void Update()
        {
            // Kill the car if it's below a certain Y value. This stops the game from having thousands of cars off-screen.
            if (transform.position.y <= -5)
                Destroy(this.gameObject);
            
            // We can only drive if we're grounded.
            this.grounded = Physics.Raycast(transform.position, Vector3.down, groundCastDistance);
        }

        private void FixedUpdate()
        {
            if (grounded)
                this.rigidBody.AddForce(this.driveDirection * speed);
        }

        public void SetDrivingDirection(Vector3 drivingDirection)
        {
            this.driveDirection = drivingDirection.normalized;
        }
    }
}