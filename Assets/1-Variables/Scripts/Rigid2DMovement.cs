using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CTRL+K+D (Clean Up Code)

// Namespace / Class / Function

namespace Variables
{

    public class Rigid2DMovement : MonoBehaviour
    {

        // Creating Variables
        public float movementSpeed = 20f;
        public float rotationSpeed = 20f;
        public float deceleration = 0.1f;

        private Rigidbody2D rigid2D;

        // Use this for initialization
        void Start()
        {
            // Get component from GameObject
            rigid2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame; Update can be used to check Movement
        void Update()
        {
            // Call Movement and Rotation Functions so Unity knows about it!
            Movement();
            Rotation();
        }

        // Void creates Functions. Do NOT put Functions inside other Functions. No Order of Functions within the Class. Order matters within a Function.
        void Movement()
        {
            float inputV = Input.GetAxis("Vertical");
            rigid2D.AddForce(transform.right * inputV * movementSpeed);
            rigid2D.velocity += -rigid2D.velocity * deceleration * Time.deltaTime; // Velocity = Direction & Speed
        }

        void Rotation()
        {
            float inputH = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.back * inputH * rotationSpeed * Time.deltaTime);
        }
    }
}
