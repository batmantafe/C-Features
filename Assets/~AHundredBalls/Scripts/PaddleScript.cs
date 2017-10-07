using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHundredBalls
{

    public class PaddleScript : MonoBehaviour
    {
        private Animator anim;

        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>(); // Get the Animator component
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.DownArrow)) // Check if Down Arrow pressed
            {
                // Modify parameter we created earlier
                anim.SetBool("isOpened", true);
            }

            else // If the Down Arrow isn't pressed
            {
                // Set that parameter to false
                anim.SetBool("isOpened", false);
            }
        }
    }
}
