using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Inheritance
{

    public class Enemy : MonoBehaviour
    {
        [Header("Base Enemy")]
        public Transform target;
        public float damage = 50f;
        public float attackDuration = 2f;
        public float attackRate = 2f;
        public float attackRange = 2f;

        protected Rigidbody rigid;
        protected NavMeshAgent nav;

        private float attackTimer = 0f;

        // Use this for initialization
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigid = GetComponent<Rigidbody>();
        }

        protected virtual void Attack() { }

        protected virtual void OnAttackEnd() { }

        IEnumerator AttackDelay(float delay)
        {
            // Do this stuff now!
            nav.Stop();
            yield return new WaitForSeconds(delay);
            // Do this after a delay!
            nav.Resume();
            OnAttackEnd();
        }

        // Update is called once per frame
        protected virtual void Update() // "protected" for Child to be able to access, "virtual" function for all classes to override the base class?
        {
            // Set the Nav destination
            nav.SetDestination(target.position);

            // Increase attack timer
            attackTimer += Time.deltaTime;

            // IF attack timer reaches the rate
            if (attackTimer >= attackRate)
            {
                // Get distance to target
                float distance = Vector3.Distance(transform.position, target.position);

                // IF close to Target
                if(distance <= attackRange)
                {
                    Attack();
                    attackTimer = 0f;
                    StartCoroutine(AttackDelay(attackDuration));
                }

            }
        }
    }
}
