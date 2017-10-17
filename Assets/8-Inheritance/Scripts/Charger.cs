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

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Attack()
        {
            // Add force to self
            // Enemy.rigid.AddForce(-transform.forward * knockback);
            rigid.AddForce(-transform.forward * knockback);
            Debug.Log("knockback on Charger");
        }

        void OnCollisionEnter(Collision col)
        {
            Health h = col.gameObject.GetComponent<Health>();

            // IF collision hits player
            if (col.gameObject.name == "Player")
            {
                h.TakeDamage(damage);
                
                // Add impactForce to player
                col.rigidbody.AddForce(transform.forward * impactForce);
                Debug.Log("impactForce to Player");
            }
        }
    }
}
