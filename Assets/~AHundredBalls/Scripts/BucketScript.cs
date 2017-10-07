using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AHundredBalls
{
    public class BucketScript : MonoBehaviour
    {
        public float movementSpeed = 10.0f;

        private Rigidbody2D rigid2D;
        private Renderer[] renderers;

        //public Text countText;
        private int count;
        public static int bucketCount;

        public Material[] mats = null;
        public GameObject buck1;
        public GameObject buck2;
        public GameObject buck3;
        public Renderer buck1mat;
        public Renderer buck2mat;
        public Renderer buck3mat;

        // Use this for initialization
        void Start()
        {
            rigid2D = GetComponent<Rigidbody2D>();
            renderers = GetComponentsInChildren<Renderer>(); // Get multiple components from children that are of type 'Renderer'

            count = 0;

            RandomMats();
        }

        // Update is called once per frame
        void Update()
        {
            HandlePosition();
            HandleBoundary();
        }

        // Handles bucket position
        void HandlePosition()
        {
            rigid2D.velocity = Vector3.left * movementSpeed;
        }

        // Handles the screen boundaries for game object
        void HandleBoundary()
        {
            Vector3 transformPos = transform.position;

            // Get the viewport position of where the bucket is
            Vector3 viewportPos = Camera.main.WorldToViewportPoint(transformPos);

            // Is the GameObject visible from the camera? AND on the left hand side of it?
            if (IsVisible() == false && viewportPos.x < 0)
            {
                Destroy(gameObject); // Then destroy the GameObject
            }
        }

        // Checks whether or not any renderer attached to this GameObject
        // and its children is visible
        bool IsVisible()
        {
            foreach (var renderer in renderers)
            {
                if (renderer.isVisible)
                {
                    return true;
                }
            }

            return false;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("HundredBall"))
            {
                count = 1;

                ManageScoreScript.scoreCount = ManageScoreScript.scoreCount + count;

                count = 0;
            }
        }

        void RandomMats()
        {
            int randomMatIndex = Random.Range(0, mats.Length);

            buck1mat = buck1.GetComponent<Renderer>();
            buck2mat = buck2.GetComponent<Renderer>();
            buck3mat = buck3.GetComponent<Renderer>();

            buck1mat.material = mats[randomMatIndex];
            buck2mat.material = mats[randomMatIndex];
            buck3mat.material = mats[randomMatIndex];
        }
    }
}
