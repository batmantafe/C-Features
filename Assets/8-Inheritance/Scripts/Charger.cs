using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{

    public class Charger : Enemy // The script to inherit from
    {
        [Header("Charger")]
        public float impactForce = 10f;
        public float knockback = 5f;

        private Rigidbody rigidCharger;

        public override void Attack()
        {
            // Add force to self

        }

        void OnCollisionEnter(Collision col)
        {
            // IF collision hits player

                // Add impactForce to player

        }
    }
}
