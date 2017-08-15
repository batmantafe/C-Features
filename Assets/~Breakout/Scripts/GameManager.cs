using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class GameManager : MonoBehaviour
    {

        public int width = 20;
        public int height = 20;
        public Vector2 spacing = new Vector2(25f, 10f); // how far are blocks set apart
        public Vector2 offset = new Vector2(25f, 10f); // ?
        public GameObject[] blockPrefabs;

        [Header("Debug")]
        public bool isDebugging = false;

        private GameObject[,] spawnedBlocks; // just a Comma makes a 2D array (x,y)


        // Use this for initialization
        void Start()
        {
            GenerateBlocks();
        }

        /**********************
        //Function with arguments
        //<return-type> <function-name> (arguments)    
        GameObject GetBlockByIndex(int index)
        {
            // Error handling
            if (index > blockPrefabs.Length || index < 0)
                return null;

            // Creating a new block at given index
            GameObject clone = Instantiate(blockPrefabs[index]);

            // ...and return it
            return clone;
        }
        **********************/

        GameObject GetRandomBlock() // creating a Function, needs a return
        {
            // Randomly Spawn a new GameObject
            int randomIndex = Random.Range(0, blockPrefabs.Length);
            GameObject randomPrefab = blockPrefabs[randomIndex];
            GameObject clone = Instantiate(randomPrefab);
            // ...and return it.
            return clone;
        }

        void GenerateBlocks()
        {
            spawnedBlocks = new GameObject[width, height];

            
            // Loop through the Width
            for (int x = 0; x < width; x++)
            {// open brace

                for (int y = 0; y < height; y++)
                {
                    // Create new instance of the block
                    GameObject block = GetRandomBlock(); // refering to a block that's been created above
                    // Set the new position
                    Vector3 pos = new Vector3(x, y, 0);
                    block.transform.position = pos;

                    // Add block to 2D array
                    spawnedBlocks[x, y] = block;
                }

            }// close brace
        }

        void UpdateBlocks()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2 pos = new Vector2(x * spacing.x, y * spacing.y);
                    GameObject currentBlock = spawnedBlocks[x, y];
                    currentBlock.transform.position = pos;
                }
            }
        }


        // Update is called once per frame
        void Update()
        {
            if(isDebugging)
            {
                UpdateBlocks();
            }
        }
    }
}
