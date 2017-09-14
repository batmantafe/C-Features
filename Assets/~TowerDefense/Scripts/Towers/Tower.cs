using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class Tower : MonoBehaviour
    {

        public Cannon cannon; // Reference to Cannon inside of Tower
        public float attackRate = 0.25f; // Rate of attack in seconds
        public float attackRadius = 5f; // Distance of attack in world units
        private float attackTimer = 0f; // Timer to count up to attackRate
        private List<Enemy> enemies = new List<Enemy>(); // List of enemies within radius

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // SET attackTimer = attackTimer + deltaTime
            attackTimer = attackTimer + Time.deltaTime;

            // IF attackTimer >= attackRate
            if (attackTimer >= attackRate)
            {
                // CALL Attack()
                Attack();

                // SET attackTimer = 0
                attackTimer = 0;

            }
        }

        void OnTriggerEnter(Collider col)
        {
            // LET e = col's Enemy component
            Enemy e = col.GetComponent<Enemy>();

            // IF e != null
            if (e != null)
            {
                // Add e to enemies list
                enemies.Add(e);
            }
        }

        void OnTriggerExit(Collider col)
        {
            // LET e = col's Enemy component
            Enemy e = col.GetComponent<Enemy>();

            // IF e != null
            if (e != null)
            {
                // Remove e from enemies list
                enemies.Remove(e);
            }
        }

        
        Enemy GetClosestEnemy()
        {
            // SET enemies = RemoveAllNulls(enemies)
            enemies = RemoveAllNulls(enemies);
            
            // LET closest = null
            Enemy closest = null;

            // LET minDistance = float.MaxValue
            float minDistance = float.MaxValue;

            // FOREACH enemy in enemies list
            // for (int i = 0; i < enemies.Count; i++) <= use if FOR
            foreach (Enemy currentEnemy in enemies)
            {
                // Enemy currentEnemy = enemies[i]; <= use if FOR


                // LET distance = the distance between transform's position and enemy's position
                // float distance = (transform.position - currentEnemy.transform.position).magnitude; // magnitude: length of Vector 
                float distance = Vector3.Distance(transform.position, currentEnemy.transform.position); // does same thing as magnitude but easier

                // IF distance < minDistance
                if (distance < minDistance)
                {
                    // SET minDistance = distance
                    minDistance = distance;

                    // SET closest = enemy
                    // closest = enemies[i]; // this Iteration of the Enemy in the List!!!! <= use if FOR
                    closest = currentEnemy;
                }
            }
            // RETURN closest
            return closest;
        }

        List<Enemy> RemoveAllNulls(List<Enemy> listWithNulls)
        {
            // LET listWithoutNulls = new List
            List<Enemy> listWithoutNulls = new List<Enemy>();

            // >> ALGORITHM GOES HERE
            foreach (Enemy e in listWithNulls)
            {
                if (e != null)
                {
                    listWithoutNulls.Add(e);
                }
            }

            // RETURN new list "listWithoutNulls"
            return listWithoutNulls;
        }

        void Attack()
        {
            // LET closest to GetClosestEnemy()
            Enemy closest = GetClosestEnemy();

            // IF closest != null
            if (closest != null)
            {
                // CALL cannon.Fire() and pass closest as argument
                cannon.Fire(closest);
            }
        }
        
        
    }
}


