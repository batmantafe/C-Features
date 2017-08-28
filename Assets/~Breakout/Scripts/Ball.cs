using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{

    public class Ball : MonoBehaviour
    {
        public float speed = 5f; // Speed that the ball travels

        private Vector3 velocity; // Velocity of the ball (Direction X Speed)

        // public Text countText;
        // private int count;

        // Use this for initialization
        void Start()
        {
            // count = 0;
            // SetCountText();
        }

        // Update is called once per frame
        void Update()
        {
            // Moves ball using velocity & deltaTime
            transform.position += velocity * Time.deltaTime;
        }

        // Fires off ball in a given direction (sends the ball flying in a given direction)
        public void Fire(Vector3 direction)
        {
            // Calculate velocity
            velocity = direction * speed;
        }

        // Detect collisions (reflects ball depending on collision)
        void OnCollisionEnter2D(Collision2D other)
        {
            // Grab contact point of collision
            ContactPoint2D contact = other.contacts[0];

            // Calculate the reflection point of the ball using the velocity & contact normal
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);

            // Calculate new velocity from reflection multiply by the same speed (velocity.magnitude)
            velocity = reflect.normalized * velocity.magnitude;
        }

        // Homework 2 & 4: Destroying blocks when colliding, Recording a score
        /* void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Block"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText ();
            }
        }

        void SetCountText ()
        {
            countText.text = "Count: " + count.ToString ();
            
        } */

    }
}
