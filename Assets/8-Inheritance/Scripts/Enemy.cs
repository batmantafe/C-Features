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
        public float attackDuration = 1f;
        private float attackTimer = 0f;
        protected NavMeshAgent nav;
        protected Rigidbody rigid;
        // public static Rigidbody rigid;
        
        protected virtual void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigid = GetComponent<Rigidbody>();
        }

        protected virtual void Attack() // Virtual is replaced by Override
        {

        }

        protected virtual void OnAttackEnd()
        {

        }

        IEnumerator AttackDelay(float delay)
        {
            // Stop Navigation
            nav.Stop();

            yield return new WaitForSeconds(delay);

            if (nav.isOnNavMesh)
            {
                // Resume Navigation
                nav.Resume();
            }

            // CALL OnAttackEnd()
            OnAttackEnd();
        }

        protected virtual void Update()
        {
            if(target == null)
            {
                return;
            }
            
            // Increase attackTimer
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackRate)
            {

                // Get distance from Enemy to Target
                float distance = Vector3.Distance(transform.position, target.position);

                // IF distance < attackRange
                if (distance < attackRange)
                {
                    // Call Attack()
                    Attack();

                    // Reset attackTimer
                    attackTimer = 0f;

                    // StartCoroutine for attackDelay
                    StartCoroutine(AttackDelay(attackDuration));
                }
            }

                // Navigate to Target
                nav.SetDestination(target.position);
        }
       
    }
}
