using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{

    public class Splodey : Enemy
    {
        [Header("Splodey")]
        public float splosionRadius = 5f;
        public float splosionRate = 3f;
        public float impactForce = 10f;
        public GameObject splosionParticles;

        private float splosionTimer = 0f;



        public override void Attack()
        {
            // Start splosionTimer
            // IF splosionTimer > splosionRate
                // Call Explode()
        }

        void Explode()
        {
            // Perform Physics OverlapSphere with splosionRadius
                // Loop through all hits
                    // IF Player
                        // Add impactForce to Rigidbody
            // Destroy self
        }
    }
}
