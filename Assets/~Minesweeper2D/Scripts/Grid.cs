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

        // private Ray mouseRay; // the Ray of the Mouse for CheckForMine below

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
                    if (desiredX >= 0 && desiredY >= 0 && desiredX < width && desiredY < height)
                    {
                        // calculate adjacent mines using
                        // desiredX + currentX (b.x) + x index(x); // <= ??

                        Tile tile = tiles[desiredX, desiredY];

                        // IF the element at index is a mine
                        if (tile.isMine)
                        {
                            // increment count by 1
                            count++; // mine
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
        void FixedUpdate()
        {
            // When MouseDown
            if (Input.GetMouseButtonDown(0))
            {
                // Calculate the Mouse Ray before performing Raycast
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                // raycast Hit container for the hit information
                RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);

                // if Tile is clicked

                if (hit.collider != null)
                {
                    // LET tile = hit collider's Tile component
                    Tile t = hit.collider.GetComponent<Tile>();

                    // IF tile != null
                    if (t != null)
                    {
                        // LET adjacentMines = GetAdjacentMinesAt(tile)
                        int adjacentMines = GetAdjacentMineCountAt(t);

                        // CALL tile.Reveal(adjacentMines)
                        t.Reveal(adjacentMines);
                    }

                }

            }
        }

        void Update()
        {
            // IF Mouse Button 0 is Down
            if (Input.GetKey(KeyCode.Mouse0))
            {
                // LET ray = Ray from Camera using Input.mousePosition
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                // LET hit = Physics2D RayCast (ray.origin, ray.direction)
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                // IF hit's collider != null
                if (hit.collider != null)
                {
                    // LET hitTile = hit Collider's Tile component
                    Tile hitTile = hit.collider.GetComponent<Tile>();

                    // IF hitTile != null
                    if (hitTile != null)
                    {
                        // CALL SelectTile(hitTile)
                        SelectTile(hitTile);
                    }
                }
            }
        }

        public void FFuncover(int x, int y, bool[,] visited)
        {
            // IF x >= 0 AND y >= 0 AND x < width AND y < height
            if (x >= 0 && y >= 0 && x < width && y < height)
            {

                // IF visited[x,y]
                if (visited[x,y])
                {
                    // RETURN
                    return;
                }
            }

            // LET tile = tiles[x,y]
            Tile tile = tiles[x,y];

            // LET adjacentMines = GetAdjacentMineCountAt(tile)
            int adjacentMines = GetAdjacentMineCountAt(tile);

            // CALL tile.Reveal(adjacentMines)
            tile.Reveal(adjacentMines);

            // IF adjacentMines > 0
            if (adjacentMines > 0)
            {
                // RETURN
                return;
            }

            // SET visited[x,y] = true
            visited[x, y] = true;

            // CALL FFuncover(x - 1, y, visited)
            FFuncover(x - 1, y, visited);

            // CALL FFuncover(x + 1, y, visited)
            FFuncover(x + 1, y, visited);

            // CALL FFuncover(x, y - 1, visited)
            FFuncover(x, y - 1, visited);

            // CALL FFuncover(x, y + 1, visited)
            FFuncover(x, y + 1, visited);
        
        }

        // Uncovers all mines that are in the grid
        public void UncoverMines(int mineState)
        {
            // FOR x = 0 to x < width
            for (int x = 0; x < width; x++)
            {
                // FOR y = 0 to y < height
                for (int y = 0; y < height; y++)
                {
                    // LET currentTile = tiles[x, y]
                    Tile currentTile = tiles[x, y];

                    // IF currentTile isMine
                    if (currentTile.isMine)
                    {

                        // LET adjacentMines = GetAdjacentMineCountAt(currentTile)
                        int adjacentMines = GetAdjacentMineCountAt(currentTile);

                        // CALL currentTile.Reveal(adjacentMines, mineState)
                        currentTile.Reveal(adjacentMines, mineState);
                    }
                }
            }
        }

        // Detects if there are no more empty tiles in the game
        bool NoMoreEmptyTiles()
        {
            // LET emptyTileCount = 0
            int emptyTileCount = 0;

            // FOR x = 0 to x < width
            for (int x = 0; x < width; x++)
            {

                // FOR y = 0 to y < height
                for (int y = 0; y < height; y++)
                {

                    // LET currentTile = tile[x, y]
                    Tile currentTile = tiles[x, y];

                    // IF !currentTile.isRevealed AND !currentTile.isMine
                    if (!currentTile.isRevealed && !currentTile.isMine)
                    {
                        // SET emptyTileCount = emptyTileCount + 1
                        emptyTileCount = emptyTileCount + 1;
                    }

                    
                }

            }

            // RETURN emptyTileCount
            return emptyTileCount == 0;
        }

        // Takes in a tile selected by the user in some way to reveal it
        public void SelectTile(Tile selectedTile)
        {
            // LET adjacentMines = GetAdjacentMineCountAt(selectedTile)
            int adjacentMines = GetAdjacentMineCountAt(selectedTile);

            // CALL selectedTile.Reveal(adjacentMines)
            selectedTile.Reveal(adjacentMines);

            // IF selectedTile isMine
            if (selectedTile.isMine)
            {
                // CALL UncoverMines(0)
                UncoverMines(0);

                // [EXTRA] Perform Game-Over logic

            }
            // ELSEIF adjacentMines == 0
            else if (adjacentMines == 0)
            {
                // LET x = selectedTile.x
                int x = selectedTile.x;

                // LET y = selectedTile.y
                int y = selectedTile.y;

                // CALL FFuncover(x, y, new bool[width, height])
                FFuncover(x, y, new bool[width, height]);
            }

            // IF NoMoreEmptyTiles()
            if (NoMoreEmptyTiles())
            {
                // CALL UncoverMines(1)
                UncoverMines(1);

                // [EXTRA] Perform Win logic
            }
        }
    }
}
