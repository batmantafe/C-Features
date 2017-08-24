using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{

    public class Ball : MonoBehaviour
    {

        public float stopSpeed = 0.2f;

        private Rigidbody rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        // Anything Physics related should be done in FixedUpdate
        void FixedUpdate()
        {
            Vector3 vel = rigid.velocity;

            // Check if velocity is going Up (positive) on the Y-axis
            if(vel.y > 0)
            {
                // If it is, cap velocity on Y-axis to 0
                vel.y = 0;
            }

            // If the velocity's speed is less than the stop speed
            if(vel.magnitude < stopSpeed)
            {
                // Cancel out velocity
                vel = Vector3.zero;
            }

            // Apply desired 'vel' to rigid's velocity
            rigid.velocity = vel;

            
        }

        public void Hit(Vector3 dir, float impactForce)
        {
            rigid.AddForce(dir * impactForce, ForceMode.Impulse);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pocket"))
            {
                Destroy(gameObject);
                // count = count + 1; // to increase Count by 1 when each Pickup is collided with and deactivated
                // SetCountText(); // countText.text = "Count: " + count.ToString(); // update Text property every time we Pickup
            }

        }


    }
}
