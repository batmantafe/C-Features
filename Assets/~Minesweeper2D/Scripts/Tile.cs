using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{

    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        // Store x and y coordinate in array for later use
        public int x = 0;
        public int y = 0;
        public bool isMine = false; // is the current tile a mine?
        public bool isRevealed = false; // has the tile already been revealed?

        
        [Header("References")]
        public Sprite[] emptySprites; // list of empty sprites i.e. empty, 1, 2, 3, 4, etc...
        public Sprite[] mineSprites; // the mine sprites

        private SpriteRenderer rend; // reference to sprite renderer

        private Ray mouseRay; // the Ray of the Mouse for CheckForMine below

        // Use this for initialization
        void Awake()
        {
            // grab reference to Sprite Renderer
            rend = GetComponent<SpriteRenderer>();
        }

        void Start()
        {
            // randomly decide if it's a mine or not
            isMine = Random.value < .05f;
        }

        public void Reveal(int adjacentMines, int mineState = 0)
        {
            // flags the tile as being revealed
            isRevealed = true;

            // checks if tile is a mine
            if (isMine)
            {
                // sets the sprite to mine sprite
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                // sets sprite to appropriate texture based on adjacent mines
                rend.sprite = emptySprites[adjacentMines];
            }
        }

        
        // HOMEWORK, 3: Deactivating a Tile on MouseDown
        void CheckForMine()
        {
            // When MouseDown
            if (Input.GetMouseButtonDown(0))
            {
                // Calculate the Mouse Ray before performing Raycast
                // mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                mouseRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // raycast Hit container for the hit information
                // RaycastHit hit;
                RaycastHit2D hit;

                // if Tile is clicked
                // if (Physics.Raycast(mouseRay, out hit))
                if (Physics2D.Raycast(mouseRay, out hit))
                {
                    gameObject.SetActive(false);
                    Reveal();
                }

            }
            
        }



        // Update is called once per frame
        void FixedUpdate()
        {
            CheckForMine();
        }
    }
}
