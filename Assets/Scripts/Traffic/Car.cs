using System;
using Core;
using Helpers;
using UnityEngine;
using UnityEngine.Assertions;

namespace Traffic
{
    public class Car : MonoBehaviour
    {
        private bool isCarInFront = false;
        private float groundCastDistance = 5;
        private bool crashed;
        private bool grounded;
        private Rigidbody rigidBody;
        private float acceleration = 1f;

        [SerializeField]
        private GameStateHolder gameState;

        [Header("Attributes")]
        [SerializeField]
        private float distanceBetweenCars = 2;
        
        [SerializeField]
        private float speed = 20;

        [SerializeField]
        private Vector3 driveDirection;

        public bool IsCrashed => crashed;
        
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
            
            isCarInFront = false;
            
            // Find any objects in front of us.
            var objectsInFront = Physics.RaycastAll(transform.position, driveDirection, distanceBetweenCars);
            foreach (var hit in objectsInFront)
            {
                // See if we've found a car heading in the same direction as us that's in front of us.
                var car = hit.transform.gameObject.GetComponent<Car>();
                if (car != null && car != this && car.driveDirection == this.driveDirection)
                {
                    isCarInFront = true;
                    StopCar();
                    break;
                }
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == null)
                return;
            
            // Detect crashes. Find a car on the other object.
            var otherCar = collision.gameObject.GetComponent<Car>();

            if (otherCar != null)
                this.crashed = true;
        }

        private void FixedUpdate()
        {
            if (grounded && !crashed && !isCarInFront)
                this.rigidBody.AddForce(this.driveDirection * (speed * acceleration));
        }

        public void SetDrivingDirection(Vector3 drivingDirection)
        {
            this.driveDirection = drivingDirection.normalized;
        }

        public void SetAcceleration(float accel)
        {
            acceleration = accel;
        }
        
        public void StopCar()
        {
            rigidBody.velocity = Vector3.zero;
        }
    }
}