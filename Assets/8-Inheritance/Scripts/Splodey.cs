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
            splosionTimer++;

            // IF splosionTimer > splosionRate
            if (splosionTimer > splosionRate)
            {
                // Call Explode(): Argument is where "center" is, in this example it's this GameObject
                Explode(transform.position);
            }
        }

        void Explode(Vector3 center)
        {
            // Perform Physics OverlapSphere with splosionRadius
            Collider[] hitColliders = Physics.OverlapSphere(center, splosionRadius);

            // Loop through all hits: all individual hitCols in the hitColliders array
            foreach (Collider hitCol in hitColliders)
            {
                // IF Player
                if (hitCol.gameObject.name == "Player")
                {
                    // Add impactForce to Rigidbody
                    hitCol.GetComponent<Rigidbody>().AddExplosionForce(impactForce, center, splosionRadius);
                }
            }

            // Destroy self
            Destroy(gameObject);
        }
    }
}
