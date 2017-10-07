using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AHundredBalls
{
    public class ManageScoreScript : MonoBehaviour
    {
        public Text countText;
        public static int scoreCount;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            SetCountText();
        }

        void SetCountText()
        {
            countText.text = "Balls in Buckets: " + scoreCount.ToString();
        }
    }
}
