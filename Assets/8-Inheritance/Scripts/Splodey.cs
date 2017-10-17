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

        protected override void Update()
        {
            base.Update();

            splosionTimer += Time.deltaTime;
        }

        protected override void OnAttackEnd()
        {
            // IF splosionTimer > splosionRate
            if (splosionTimer > splosionRate)
            {
                // Call Explode(): Argument is where "center" is, in this example it's this GameObject
                Splode();
                Destroy(gameObject);
            }
        }

        void Splode()
        {
            // Perform Physics OverlapSphere with splosionRadius
            Collider[] hits = Physics.OverlapSphere(transform.position, splosionRadius);

            // Loop through all hits: all individual hitCols in the hitColliders array
            foreach (Collider hitCol in hits)
            {
                Health h = hitCol.GetComponent<Health>();

                if(h != null)
                {
                    h.TakeDamage(damage);
                }

                Rigidbody r = hitCol.GetComponent<Rigidbody>();

                if(r != null)
                {
                    r.AddExplosionForce(impactForce, transform.position, splosionRadius);
                }

                /*// IF Player
                if (hitCol.gameObject.name == "Player")
                {
                    h.TakeDamage(damage);

                    // Add impactForce to Rigidbody
                    rigid.AddExplosionForce(impactForce, transform.position, splosionRadius);
                }*/
            }
        }
    }
}
