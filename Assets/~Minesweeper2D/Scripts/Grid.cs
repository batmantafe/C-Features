using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{

    public class Grid : MonoBehaviour
    {

        public GameObject tilePrefab;
        public int width = 10;
        public int height = 10;
        public float spacing = .155f;


        public float offsetPos = .5f;


        public Tile[,] tiles;

        // Functionality for spawning tiles
        Tile SpawnTile(Vector3 pos)
        {
            // clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos; // position tile
            Tile currentTile = clone.GetComponent<Tile>(); // get Tile component
            return currentTile; // return it
        }

        
        void GenerateTiles()
        {
            // create new 2D array of size width x height
            tiles = new Tile[width, height];

            // loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {

                    // store half size for later use
                    Vector2 halfSize = new Vector2(width / 2, height / 2);

                    // pivot tiles around Grid
                    Vector2 pos = new Vector2(x - (halfSize.x - offsetPos), y - (halfSize.y - offsetPos)); // HOMEWORK, 1: Center the Spawn Point: created Offset variable at .5f to adjust creation Pos of Grid

                    // apply spacing
                    pos *= spacing;

                    // spawn the tile
                    Tile tile = SpawnTile(pos);

                    // attach newly spawned tile to
                    tile.transform.SetParent(transform);

                    // store it's array coordinates within itself for future reference
                    tile.x = x;
                    tile.y = y;

                    // store tile in array at those coordinates
                    tiles[x, y] = tile;
                }

            }
        }


        // HOMEWORK, 2: Detecting Adjacent Mines
        // Count adjacent mines at element
        public int GetAdjacentMineCountAt(Tile t)
        {
            int count = 0;

            // Loop through all elements and have each axis go between -1 to 1
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    // Calculate Desired coordinates from ones attained
                    int desiredX = t.x + x; //  number of X values within GenerateTiles, limited by range x and y above (getting tiles 1 step away from this tile)
                    int desiredY = t.y + y;

                    // IF desiredX is within range of tiles array length
                    if (desiredX < width && desiredY < height)
                    {
                        // IF the element at index is a mine
                        if (tiles[x,y].isMine)
                        {
                            // increment count by 1
                            count = count + 1; // mine
                        }
                    }

                }
            }
            return count;
        }

        // Use this for initialization
        void Start()
        {

            GenerateTiles();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
