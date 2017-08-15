using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoopsArrays

{
    // Time spent writing visualisation code is never wasted. --John Carmack.

    public class Loops : MonoBehaviour
    {

        public GameObject[] spawnPrefabs;
        public GameObject spawnPrefab;
        public float spawnRadius = 5f;
        public int spawnAmount = 10;
        public float frequency = 5;
        public float amplitude = 6;

        public string message = "Print This";
        public float printTime = 2f;

        private float timer = 0;

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        // Use this for initialization
        void Start()
        {
            /* while (condition)
            {
                statement
            } */

            /* int iteration = 0;
            while (iteration < 998)
            {
                print(message);
                iteration++;
            } */

            // SpawnObjects();
            // SpawnObjectsWithSine();
            SpawnObjectsWithArray();

        }

        // Update is called once per frame
        void Update()
        {



            //// loop through until timer gets to printTime
            //while (timer <= printTime)
            //{
            //     {
            //        timer += Time.deltaTime; // count up timer in seconds
            //        print("PUT THE COOKIE DOWN!");
            //     }
            //}

        }

        void SpawnObjects() // spawning GameObjects
        {
            /*
            for (initialization; condition; iteration)
            {
                // Statement(s)
            }
            */

            for (int i = 0; i < spawnAmount; i++)
            {
                // Spawned new GameObject
                GameObject clone = Instantiate(spawnPrefab);



                // Calculate random position within sphere
                Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius; // calculate random position

                // Cancel out the Z
                randomPos.z = 0;

                // Set spawned object's position
                clone.transform.position = randomPos;
            }
        }

        void SpawnObjectsWithSine() // spawning GameObjects in a Sine Wave
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                // Spawned new GameObject
                GameObject clone = Instantiate(spawnPrefab);

                // Grab MeshRenderer
                MeshRenderer rend = clone.GetComponent<MeshRenderer>();

                // Change the Colour
                float r = Random.Range(0, 2); // first number is Inclusive, second number is Exclusive.
                float g = Random.Range(0, 2);
                float b = Random.Range(0, 2);
                float a = 1;
                rend.material.color = new Color(r, g, b, a);

                // Calculate random position within sphere
                float x = Mathf.Sin(i * frequency) * amplitude; // Play around with Frequent number.
                float y = i;
                float z = 0; // or: float z = Mathf.Cos(i * frequency) * amplitude; <= for 3D
                Vector3 randomPos = transform.position + new Vector3(x, y, z); // calculate random position

                // Cancel out the Z
                randomPos.z = 0;

                // Set spawned object's position
                clone.transform.position = randomPos;
            }
        }

        void SpawnObjectsWithArray()
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                // Spawned new GameObject
                int randomIndex = Random.Range(0, spawnPrefabs.Length);

                // Store randomly selected prefab
                GameObject randomPrefab = spawnPrefabs[randomIndex];

                // Instantiate randomly selected prefab
                GameObject clone = Instantiate(randomPrefab);

                // Grab MeshRenderer
                MeshRenderer rend = clone.GetComponent<MeshRenderer>();

                // Change the Colour
                float r = Random.Range(0, 2); // first number is Inclusive, second number is Exclusive.
                float g = Random.Range(0, 2);
                float b = Random.Range(0, 2);
                float a = 1;
                rend.material.color = new Color(r, g, b, a);

                // Calculate random position within sphere
                float x = Mathf.Sin(i * frequency) * amplitude; // Play around with Frequent number.
                float y = i;
                float z = Mathf.Cos(i * frequency) * amplitude;
                Vector3 randomPos = transform.position + new Vector3(x, y, z); // calculate random position
                
                // Cancel out the Z
                // randomPos.z = 0; <= remove for 3D

                // Set spawned object's position
                clone.transform.position = randomPos;
            }
        }
    }
}

