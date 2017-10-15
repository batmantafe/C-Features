using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // For AI!

namespace Inheritance
{
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy")]
        public Transform target;
        public int health = 100;
        public int damage = 20;
        public float attackRange = 2f;
        public float attackRate = .5f;

        private float attackTimer = 0f;
        private NavMeshAgent nav;
        // private Rigidbody rigid;
        public static Rigidbody rigid;
        
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigid = GetComponent<Rigidbody>();
        }

        void Update()
        {
            // Increase attackTimer
            attackTimer += Time.deltaTime;

            // Get distance from Enemy to Target
            float distance = Vector3.Distance(transform.position, target.position);

            // IF distance < attackRange
            if(distance < attackRange)
            {
                // Call Attack()
                Attack();

                // Reset attackTimer
                attackTimer = 0f;
            }

            // IF Target != null
            if(target != null)
            {
                // Navigate to Target
                nav.SetDestination(target.position);
            }

        }

        public virtual void Attack() // Virtual is replaced by Override
        {
            print("Attack() called");
        }
    }
}
