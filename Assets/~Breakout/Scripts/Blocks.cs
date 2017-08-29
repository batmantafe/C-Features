using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Breakout
{

    

    public class Blocks : MonoBehaviour
    {

        // public Text countText;
        // private int count;

        // Use this for initialization
        void Start()
        {
            // count = 0;
            // SetCountText();
        }

        // Update is called once per frame
        void Update()
        {

        }

        /*void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                Destroy(gameObject);
            }
        }*/

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                Destroy(gameObject);
                // count = count + 1; // to increase Count by 1 when each Pickup is collided with and deactivated
                // SetCountText(); // countText.text = "Count: " + count.ToString(); // update Text property every time we Pickup
            }

        }

        /*void SetCountText()
        {
            countText.text = "Count: " + count;

        }*/
    }
}
